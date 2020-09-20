using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace expresshmac
{
    class Program
    {

        public static String GetHash(String text, String key)
        {
            // change according to your needs, an UTF8Encoding
            // could be more suitable in certain situations
            ASCIIEncoding encoding = new ASCIIEncoding();

            Byte[] textBytes = encoding.GetBytes(text);
            Byte[] keyBytes = encoding.GetBytes(key);

            Byte[] hashBytes;

            using (HMACSHA256 hash = new HMACSHA256(keyBytes))
                hashBytes = hash.ComputeHash(textBytes);

            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }

   
        public static string GetMD5(string input){
              String result;
              using (var md5 = MD5.Create())
                {
                    result = BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(input)))
                        .Replace("-", string.Empty).ToLower();
                }
                //Console.WriteLine(result);
                return result;
        }


        static void Main(string[] args)
        {
            byte[] key = Encoding.ASCII.GetBytes("secret");
            string currentTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
            string input = "";
            foreach (string s in new string[] { currentTime, "POST", "/protected", GetMD5("{\"a\":\"b\"}") })
            {
                input += s;
            }
            //Console.WriteLine(input);
            //System.Console.WriteLine( "HMAC " + currentTime + ":" + Encode(input.ToLower(), key) );
            System.Console.WriteLine( "HMAC " + currentTime + ":" + GetHash(input, "secret") );

            return;
        }


    }
}
