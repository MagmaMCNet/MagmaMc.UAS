using System;
using System.Net;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Text;
using System.Text.Json;
using System.IO;
using MagmaMc.MagmaSimpleConfig;
using static MagmaMc.JEF.JEF;
using static MagmaMc.UAA.UDUtils;

namespace MagmaMc.UAA
{
    public abstract class IUserData
    {
        public static string Filename { get; } = Folder + "Auth.db";
        public static string Folder { get; } = Utils.Folders.LocalUserAppData + "\\MagmaMc\\UAA\\";
        public string Username { get; set; }
        public string Email { get; set; }
        public string Icon { get; set; }
        public string Password { get; set; }
        public string Authorisation { get; set; }


        public static explicit operator IUserData(JsonElement Input)
        {
            UserData Data = new UserData();
            Data.Username = Input.GetProperty("Username").ToString();
            Data.Email = Input.GetProperty("Email").ToString();
            Data.Password = Input.GetProperty("Password").ToString();
            Data.Icon = Input.GetProperty("Icon").ToString();
            Data.Authorisation = CallAPI(APIEndPoints.Token, (APIData)Data);
            return Data;
        }
    }
    public class UserData : IUserData
    {
        public UserData() { }
        public UserData(string username, string password)
        {
            Username = username;
            Password = password;
        }
        public UserData(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
        }
        /// <summary>
        /// Allows Comparing A Token And Checking if it is valid
        /// </summary>
        /// <param name="Token"></param>
        /// <returns></returns>
        public static bool ValidToken(string Token) =>
            GetUserData(Token) != null;

        /// <summary>
        /// Generates A Token From UserData
        /// </summary>
        /// <param name="UserData"></param>
        /// <returns></returns>
        public static string GetToken(APIData UserData) =>
            CallAPI(APIEndPoints.Token, UserData);

        public static UserData GetUserData(APIData UserData) =>
            ToUserData(CallAPI(APIEndPoints.UserData, UserData));

        public static UserData GetUserData(string Token) =>
            ToUserData(CallAPI(APIEndPoints.UserData, new APIData() { { "Token", Token } }));

        public static UserData Read()
        {
            if (!Directory.Exists(Folder))
                Directory.CreateDirectory(Folder);

            SimpleConfig Data = new SimpleConfig(Filename);
            UserData UserData = new UserData();
            UserData.Username = Data.GetValue("Username", "", "Config").ToString();
            UserData.Email = Data.GetValue("Email", "", "Config").ToString();
            UserData.Icon = Data.GetValue("Icon", "", "Config").ToString();
            UserData.Authorisation = Data.GetValue("Authorisation", "", "Config").ToString();
            if (ValidToken(UserData.Authorisation))
                return UserData;
            else
                return null;

        }
        /// <summary>
        /// Gets the custom data for a given filename using the provided developer token and access token.
        /// </summary>
        /// <param name="DevToken">Developer token to use for authentication.</param>
        /// <param name="Token">Access token to use for authentication.</param>
        /// <param name="Filename">Name of the file to retrieve custom data for.</param>
        /// <returns>A string containing the custom data for the specified file.</returns>
        public static string GetCustomData(string DevToken, string Token, string Filename)
        {
            return CallAPI(APIEndPoints.CustomData, new APIData() { { "DevToken", DevToken }, { "Token", Token }, { "Filename", Filename } });
        }

        /// <summary>
        /// Sets the custom data for a given filename using the provided developer token and access token.
        /// </summary>
        /// <param name="DevToken">Developer token to use for authentication.</param>
        /// <param name="Token">Access token to use for authentication.</param>
        /// <param name="Filename">Name of the file to set custom data for.</param>
        /// <param name="Data">Custom data to set for the specified file.</param>
        public static void SetCustomData(string DevToken, string Token, string Filename, string Data)
        {
            CallAPI(APIEndPoints.CustomData, new APIData() { { "DevToken", DevToken }, { "Token", Token }, { "Filename", Filename }, { "Data", Data } });
        }

        public void Save()
        {
            if (!Directory.Exists(Folder))
                Directory.CreateDirectory(Folder);

            SimpleConfig Data = new SimpleConfig(Filename);
            File.AppendAllText(Filename, "");
            File.AppendAllText(Filename, "[Config]\r\n// WARNING -- Do Not Share Your Authorisation Token -- WARNING\r\n");
            Data.SetValue("Authorisation", "", "Config");
            Data.SetValue("Username", Username, "Config");
            Data.SetValue("Email", Email, "Config");
            Data.SetValue("Icon", Icon, "Config");
        }

    }
}
