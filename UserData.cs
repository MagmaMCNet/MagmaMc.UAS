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
        public string Username { get; set; }
        public string Email { get; set; }
        public string Icon { get; set; }
        public string Password { get; set; }
        public string Authorisation { get; set; }
    }
    public class UserData: IUserData
    {
        public static string Filename { get; } = Utils.Folders.LocalUserAppData + "\\MagmaMc\\AUU\\Auth.db";
        public static string Folder { get; } = Utils.Folders.LocalUserAppData + "\\MagmaMc\\AUU\\";
        public string Username { get; set; }
        public string Email { get; set; }
        public string Icon { get; set; }
        public string Password { get; set; }
        public string Authorisation { get; set; }

        public static UserData Read()
        {
            SimpleConfig Data = new SimpleConfig(Filename);
            UserData UserData = new UserData();
            UserData.Username = Data.GetValue("Username", "", "Cache").ToString();
            UserData.Email = Data.GetValue("Email", "", "Cache").ToString();
            UserData.Icon = Data.GetValue("Icon", "", "Cache").ToString();
            UserData.Authorisation = Data.GetValue("Authorisation", "", "Cache").ToString();
            if (VaildToken(UserData.Authorisation))
                return UserData;
            else
                return null;

        }
        public void Save()
        {

            SimpleConfig Data = new SimpleConfig(Filename);
            File.AppendAllText(Filename, "[Cache]\r\n// WARNING -- Do Not Share Your Authorisation Token -- WARNING\r\n");
            Data.SetValue("Authorisation", "", "Cache");
            Data.SetValue("Username", Username, "Cache");
            Data.SetValue("Email", Email, "Cache");
            Data.SetValue("Icon", Icon, "Cache");
        }

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
        public UserData(string user, string pass) { Username = user; Password = pass; }
        public UserData() { }
        public static bool VaildLogin(UserData UserData)
        {
            using (WebClient Client = new WebClient())
            {
                return (RemoveHTML(Client.DownloadString(
                    $"{APIEndPoints.Create}/?Username={UserData.Username}&Password={UserData.Password}")) != "failed");
            }
        }

        public static string RecieveToken(UserData userData)
        {
            using (WebClient Client = new WebClient())
            {
                return RemoveHTML
                    (
                    Client.DownloadString($"{APIPath}Auth.php?{CreateParms(userData.Username, userData.Password)}")
                    );
            }
        }
        public static string CreateParms(string Username, string Password)
        {
            return $"Username={Username}&Password={Password}";
        }
        public static UserData GetUserData(string Token)
        {
            using (WebClient Client = new WebClient())
            {
                return JsonSerializer.Deserialize<UserData>(RemoveHTML(Client.DownloadString(
                    $"{APIEndPoints.UserData}?Token={Token}")));
            }
        }
        public static UserData GetUserData(UserData UserData)
        {
            using (WebClient Client = new WebClient())
            {
                return (UserData)JsonSerializer.Deserialize<dynamic>(RemoveHTML(Client.DownloadString(
                    $"{APIEndPoints.UserData}?Username={UserData.Username}&Password={UserData.Password}")), Options);
            }
        }
        public static bool VaildToken(string Token)
        {
            using (WebClient Client = new WebClient())
            {
                return RemoveHTML(Client.DownloadString(
                    $"{APIPath}/UserData.php/?Token={Token}")) != "failed";

            }
        }


        public static explicit operator UserData(JsonElement Input)
        {
            UserData Data = new UserData();
            Data.Username = Input.GetProperty("Username").ToString();
            Data.Email = Input.GetProperty("Email").ToString();
            Data.Password = Input.GetProperty("Password").ToString();
            Data.Icon = Input.GetProperty("Icon").ToString();
            Data.Authorisation = Security.MD5Hash(Data.Email + "||" + Data.Password);
            return Data;
        }
        
    }
}
