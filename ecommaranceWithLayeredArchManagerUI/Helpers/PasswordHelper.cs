using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ecommaranceWithLayeredArchManagerUI.Helpers
{
    public class PasswordHelper
    {
        public static string DESSifrele(string metin)
        {
            string textToEncyriypt = metin;
            string ToReturn = "";
            string publickey = "12503624";
            string secretkey = "12345678";

            byte[] secretkeyByte = Encoding.UTF8.GetBytes(secretkey);
            byte[] publickeyByte = Encoding.UTF8.GetBytes(publickey);
            byte[] inputbyArray = Encoding.UTF8.GetBytes(textToEncyriypt);

            using(DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(publickeyByte, secretkeyByte), CryptoStreamMode.Write);
                cs.Write(inputbyArray, 0, inputbyArray.Length);
                cs.FlushFinalBlock();
                ToReturn = Convert.ToBase64String(ms.ToArray());
            }

            return ToReturn;
        }

        public string DESCoz(string metin)
        {
            string textToDecrypt = metin;
            string ToReturn = "";
            string publickey = "12503624";
            string secretkey = "12345678";

            byte[] secretkeyByte = Encoding.UTF8.GetBytes(secretkey);
            byte[] publickeyByte = Encoding.UTF8.GetBytes(publickey);
            byte[] inputbyArray = new byte[textToDecrypt.Replace(" ", "+").Length];
            inputbyArray = Convert.FromBase64String(textToDecrypt.Replace(" ", "+"));

            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(publickeyByte, secretkeyByte), CryptoStreamMode.Write);
                cs.Write(inputbyArray, 0, inputbyArray.Length);
                cs.FlushFinalBlock();
                Encoding encoder = Encoding.UTF8;
                ToReturn = encoder.GetString(ms.ToArray());
            }

            return ToReturn;
        }
    }
}