using Newtonsoft.Json;
using System.Text;
using System.Web;
using Effortless.Net.Encryption;
using Microsoft.IdentityModel.Tokens;
using MhanoHarkness;

namespace MgChitDotNetCore.Shared
{
    public static class DevCode
    {
        public static Dictionary<string, object> ToDictionary<T>(this T obj)
        {
            var keyValue = new Dictionary<string, object>();
            var type = typeof(T);
            foreach (var property in type.GetProperties())
            {
                var value = property.GetValue(obj);
                keyValue.Add($"@{property.Name}", value);
            }
            return keyValue;
        }

        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T ToObject<T>(this string str)
        {
            return JsonConvert.DeserializeObject<T>(str);
        }

        public static List<T> ToObjectLst<T>(this string str)
        {
            return JsonConvert.DeserializeObject<List<T>>(str);
        }

        public static string ToFormattedJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }

        public static string ToUrlObject(this object obj)
        {
            string jsonStr = "";
            if (obj is string)
            {
                jsonStr = obj.ToString();
            }
            else
            {
                jsonStr = obj.ToJson();
            }
            string encryptedStr = jsonStr.ToEncrypt();
            string encodedStr = encryptedStr.ToEncode();
            return encodedStr;
        }
        public static string ToEncode(this string queryString)
        {
            return HttpUtility.UrlEncode(queryString);
        }

        private static byte[] key = "C4162ECDB4594969BB1040E846869706".ToByte();
        private static byte[] iv1 = "AC507B7DAC7B458CBE781F3916E1F8AB".ToByte();
        private static byte[] iv = "BE781F3916E1F8AB".ToByte();
        public static string ToEncrypt(this string str)
        {
            string encrypted = Strings.Encrypt(str, key, iv);
            return encrypted;
        }

        public static byte[] ToByte(this string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }

        public static T ToUrlObject<T>(this string str, bool IsDecode = true)
        {
            string decodedStr = str;
            if (IsDecode)
                decodedStr = str.ToDecode();
            string decryptedStr = decodedStr.ToDecrypt();
            T obj = decryptedStr.ToObject<T>();
            return obj;
        }

        public static string ToDecode(this string queryString)
        {
            return HttpUtility.UrlDecode(queryString);
        }

        public static string ToDecrypt(this string str)
        {
            string decrypted = "";
            try
            {
                if (!str.IsNullOrEmpty())
                {
                    decrypted = Strings.Decrypt(str, key, iv);
                }
            }
            catch (Exception ex)
            {
                decrypted = str;
            }
            return decrypted;
        }

        public static string ToBase3264UrlEncoder(this string str)
        {
            byte[] myByteArray = Encoding.ASCII.GetBytes(str);
            return Convert.ToBase64String(myByteArray);
        }

        public static string ToBase3264UrlDecoder(this string str)
        {
            //byte[] myByteArray = Base32Url.FromBase32String(str);
            byte[] myByteArray = Convert.FromBase64String(str);
            return Encoding.UTF8.GetString(myByteArray);
        }
    }
}
