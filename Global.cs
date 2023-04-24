using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
        /// The endpoint used for generating a token from user data.
        /// </summary>
        public const string Authorize = APIPath + "Auth.php";


        /// <summary>
        /// This endpoint is intended for internal use only.
        /// </summary>
        public const string Login = APIPath + "Login.php";

        /// <summary>
        /// This endpoint is intended for internal use only.
        /// </summary>
        public const string Create = APIPath + "Create.php";
    }
    internal static class Global
    {
        public const string APIPath = "https://accounts.magma-mc.net/API/";
        
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
