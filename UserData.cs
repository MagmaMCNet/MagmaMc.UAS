using System;
using System.Net;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Text;
using System.Text.Json;
using System.IO;
using MagmaMc.MagmaSimpleConfig;
using static MagmaMc.JEF.JEF;
using static MagmaMc.AUU.Global;

namespace MagmaMc.AUU
{
    public class IUserData
    {
        public static string Filename { get; } = Utils.Folders.LocalUserAppData + "\\MagmaMc\\AUU\\Auth.db";
        public static string Folder { get; } = Utils.Folders.LocalUserAppData + "\\MagmaMc\\AUU\\";
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
        public static explicit operator APIData(IUserData UserData)
        {
            APIData Data = new APIData
            {
                { "Username", UserData.Username },
                { "Password", UserData.Password },
                { "Email", UserData.Email },
                { "Token", UserData.Authorisation }
            };
            return Data;
        }
    }
    public class UserData: IUserData
    {
        public UserData() { }
        public UserData(string username, string password)
        {
            Username = username;
            Password = password;
        }
        public static bool ValidToken(string Token)
        {
            return true;
        }
        public static UserData Read()
        {
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
        public void Save()
        {
            SimpleConfig Data = new SimpleConfig(Filename);
            File.AppendAllText(Filename, "[Config]\r\n// WARNING -- Do Not Share Your Authorisation Token -- WARNING\r\n");
            Data.SetValue("Authorisation", "", "Config");
            Data.SetValue("Username", Username, "Config");
            Data.SetValue("Email", Email, "Config");
            Data.SetValue("Icon", Icon, "Config");
        }


        
    }
}
