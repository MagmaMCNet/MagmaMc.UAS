using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace MagmaMc.AUU
{
    /// <summary>
    /// Magma's Universal Accounts API Paths
    /// </summary>
    public readonly struct APIEndPoints
    {
        /// <summary>
        /// The base URL of the Magma's Universal Accounts API.
        /// </summary>
        public const string APIPath = "https://accounts.magma-mc.net/API/";

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
    }
    public class APIData: Dictionary<string, string> { }
    internal class Global
    {
        protected Global() { }
        public const string APIPath = "https://accounts.magma-mc.net/API/";

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
        public static string CallAPI(string Path, APIData Input)
        {
            HttpClient Client = new HttpClient();
            HttpResponseMessage Response = Client.GetAsync(Path + ToQueryString(Input)).GetAwaiter().GetResult();
            Client.Dispose();
            if (Response.IsSuccessStatusCode)
                return RemoveHTML(Response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
            else return null;
        }

        public static UserData CreateJson(string Data)
        {
            try
            {
                return (UserData)JsonSerializer.Deserialize<JsonElement>(Data);
            } catch
            {
                try
                {
                    return (UserData)JsonSerializer.Deserialize<JsonElement>(RemoveHTML(Data));
                }
                catch
                {
                    return null;
                }
            }

        }
            


        /// <summary>
        /// A Quick Simple Way To Hash A String
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string md5(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }

        /// <summary>
        /// Removes <c><![CDATA[<script></script>]]></c> tags From HTML Returned Data
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string RemoveHTML(string html)
        {
            return Regex.Replace(html, @"<script\b[^<]*(?:(?!</script>)<[^<]*)*</script>", string.Empty);
        }
        public static readonly JsonSerializerOptions Options = new JsonSerializerOptions()
        {
            AllowTrailingCommas = true,
            IgnoreReadOnlyFields = false,
        };
    }
}
