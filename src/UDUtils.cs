using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.Http;
using System.Security.Permissions;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Web;

namespace MagmaMc.UAS
{
    /// <summary>
    /// Magma's Universal Accounts API Paths
    /// </summary>
    public readonly struct APIEndPoints
    {
        /// <summary>
        /// The base URL of the Magma's Universal Accounts API. PROXY
        /// </summary>
        public const string APIPathProxy = "https://accounts.magma-mc.net/API/";
        /// <summary>
        /// The base URL of the Magma's Universal Accounts API.
        /// </summary>
        public const string APIPath = "http://www.magma-mc.net:5555/Accounts/API/";


        /// <summary>
        /// The endpoint used for retrieving user data or validating the user.
        /// </summary>
        public const string UserData = APIPath + "UserData.php";

        /// <summary>
        /// The endpoint used for generating or validating a token from user data.
        /// </summary>
        public const string Token = APIPath + "Token.php";

        /// <summary>
        /// This endpoint is intended for internal use only.
        /// </summary>
        public const string Login = APIPath + "Login.php";

        /// <summary>
        /// This endpoint is intended for internal use only.
        /// </summary>
        public const string Create = APIPath + "Create.php";

        /// <summary>
        /// This endpoint is used to create custom application user data
        /// </summary>
        public const string CustomData = APIPath + "CustomData.php";
    }
    /// <summary>
    /// A Simple Web Response That Can Be Converted From Or To a string
    /// </summary>
    /// 
    public class APIResponse
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public ushort ResponseCode { get; set; }
        public APIResponse() { }
        public APIResponse(string Message, bool Successful)
        {
            Success = Successful;
            this.Message = Message;
        }

        public static implicit operator APIResponse(string Input)
        {
            if (Input == null)
                return new APIResponse("", false);
            if (Input.ToLower().StartsWith("invalid") || Input.ToLower().StartsWith("fail"))
                return new APIResponse(Input, false);
            else
                return new APIResponse(Input, true);
        }

        public static implicit operator string(APIResponse Input) =>
            Input.Message;

        public override string ToString() => Message;

    }
    /// <summary>
    /// 
    /// </summary>
    public class APIData : Dictionary<string, string>
    {
        public static explicit operator APIData(JsonElement Input)
        {
            APIData Data = new APIData
            {
                { "Username", Input.GetProperty("Username").ToString()  },
                { "Password", Input.GetProperty("Password").ToString()  },
                { "Email", Input.GetProperty("Email").ToString()  }
            };
            return Data;
        }
        public static explicit operator APIData(IUserData Input)
        {
            APIData Data = new APIData
            {
                { "Username", Input.Username },
                { "Password", Input.Password },
                { "Email", Input.Email },
                { "Token", Input.Authorisation }
            };
            return Data;
        }
    }
    public static class Extensions
    {
        /// <summary>
        /// Converts A Stringed Json Into JsonElement
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public static JsonElement Jsonify(this string Data)
        {
            return JsonSerializer.Deserialize<JsonElement>(Data);
        }
    }
    /// <summary>
    /// User Data Utils
    /// </summary>
    public class UDUtils
    {
        protected UDUtils() { }
        /// <summary>
        /// Converts A Dictionary Into A QueryString For URLs
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static string ToQueryString(Dictionary<string, string> parameters)
        {
            if (parameters == null)
                return "";

            if (parameters.Count == 0)
                return "";

            List<string> encodedParameters = new List<string>();
            foreach (var kvp in parameters)
            {
                var encodedKey = HttpUtility.UrlEncode(kvp.Key);
                var encodedValue = HttpUtility.UrlEncode(kvp.Value);
                encodedParameters.Add($"{encodedKey}={encodedValue}");
            }

            return "?" + string.Join("&", encodedParameters);
        }
        /// <summary>
        /// Direct Way To Call The Website API
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="Input"></param>
        /// <returns></returns>
        public static APIResponse CallAPI(string Path, APIData Input)
        {
            HttpClient Client = new HttpClient();
            Client.Timeout = TimeSpan.FromSeconds(10);
            Client.MaxResponseContentBufferSize = 1048576; // 1MB

            try
            {
                
                HttpResponseMessage Response = Client.GetAsync(Path + ToQueryString(Input)).GetAwaiter().GetResult();
                APIResponse APIResponse = new APIResponse(Response.Content.ReadAsStringAsync().GetAwaiter().GetResult(), Response.IsSuccessStatusCode);
                APIResponse.ResponseCode = (ushort)Response.StatusCode;
                Client.Dispose();
                return APIResponse;
            }
            catch
            {
                Client.Dispose();
                return new APIResponse() { Message = "", ResponseCode = 444, Success = false };
            }
        }

        /// <summary>
        /// Converts Stringed Json Data To UserData Class
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public static UserData ToUserData(string Data)
        {
            try
            {
                return (UserData)JsonSerializer.Deserialize<JsonElement>(Data);
            }
            catch
            {
                try
                {
                    return (UserData)JsonSerializer.Deserialize<JsonElement>(Data);
                }
                catch
                {
                    return null;
                }
            }

        }


        public static Bitmap DownloadBitmap(string url)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    byte[] imageData = client.DownloadData(url);
                    using (var ms = new System.IO.MemoryStream(imageData))
                    {
                        Bitmap bitmap = new Bitmap(ms);
                        return bitmap;
                    }
                } catch { return null; }
            }
        }


        /// <summary>
        /// Removes <c><![CDATA[<script></script>]]></c> tags From HTML Returned Data
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        [Obsolete("Redundant due to the fact the website no longer returns the tag '<script>'", false)]
        public static string RemoveHTML(string html) => html; 
            //Regex.Replace(html, @"<script\b[^<]*(?:(?!</script>)<[^<]*)*</script>", string.Empty);

        public static readonly JsonSerializerOptions Options = new JsonSerializerOptions()
        {
            AllowTrailingCommas = true,
            IgnoreReadOnlyFields = false,
        };
    }
}
