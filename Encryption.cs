using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FYP
{
    class Encryption
    {
        public string Encrypt(string Text, byte[] key, byte[] VectorBytes)
        {


            try
            {
                byte[] TextBytes = Encoding.UTF8.GetBytes(Text);
                RijndaelManaged rijKey = new RijndaelManaged();
                //       rijKey.Padding = PaddingMode.None;
                //    rijKey.Padding = PaddingMode.None;
                rijKey.Mode = CipherMode.CBC;
                ICryptoTransform encryptor = rijKey.CreateEncryptor(key, VectorBytes);
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
                cryptoStream.Write(TextBytes, 0, TextBytes.Length);
                cryptoStream.FlushFinalBlock();
                byte[] cipherTextBytes = memoryStream.ToArray();
                memoryStream.Close();
                cryptoStream.Close();
                // string cipherText = Encoding.UTF8.GetString(cipherTextBytes);
                string cipherText = Convert.ToBase64String(cipherTextBytes);
                return cipherText;
            }
            catch (Exception e)
            {
                MessageBox.Show("Password " + e.Message.ToString());
                string t = "";
                return t;
            }

        }
    }
}
