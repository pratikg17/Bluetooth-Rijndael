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
    class Decryption
    {
        public string Decrypt(string Text, byte[] keyBytes, byte[] VectorBytes)
        {
            try
            {
                //System.IO.StreamReader inFile;
                //string base64String;
                //try
                //{
                //    char[] base64CharArray;
                //    inFile = new StreamReader(Text, System.Text.Encoding.ASCII);
                //    base64CharArray = new char[inFile.BaseStream.Length];
                //    inFile.Read(base64CharArray, 0,(int)inFile.BaseStream.Length);
                //    base64String = new string(base64CharArray);
                //}
                //catch(SystemException exp )
                //{
                //    MessageBox.Show(exp.Message);
                //}

                /*-------------------------------------------------------*/
                //MessageBox.Show(Text);

                //byte[] TextBytes = Encoding.UTF8.GetBytes(Text);
                byte[] TextBytes = Convert.FromBase64String(Text);
                //FixBase64Length(TextBytes.ToString());
                //byte[] TextBytes = Encoding.ASCII.GetBytes(Text);
                //    byte[] TextBytes = Convert.FromBase64String(Text.Replace(" ", "+"));
                //       byte [] TextBytes = Convert.fro
                //MessageBox.Show(TextBytes.ToString());
                RijndaelManaged rijKey = new RijndaelManaged();
                //
                //    rijKey.Padding = PaddingMode.None;
                rijKey.Mode = CipherMode.CBC;
                ICryptoTransform decryptor = rijKey.CreateDecryptor(keyBytes, VectorBytes);
                MemoryStream memoryStream = new MemoryStream(TextBytes);
                CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
                byte[] pTextBytes = new byte[TextBytes.Length];
                int decryptedByteCount = cryptoStream.Read(pTextBytes, 0, pTextBytes.Length);
                memoryStream.Close();
                cryptoStream.Close();
                string plainText = Encoding.UTF8.GetString(pTextBytes, 0, decryptedByteCount);
                MessageBox.Show(plainText);
                return plainText;
            }
            catch (Exception a)
            {
                MessageBox.Show("Password " + a.Message.ToString());
                string t = "";
                return t;
            }

        }


        //private string FixBase64Length(string additionalQueryStringEncoded)
        //{
        //    int length = additionalQueryStringEncoded.Length;
        //    int remainder = length % 4;
        //    if (remainder == 0)
        //    {
        //        return additionalQueryStringEncoded.Replace(" ", "+");
        //    }

        //    remainder = 4 - remainder;
        //    for (int i = 0; i < remainder; i++)
        //    {
        //        additionalQueryStringEncoded += "=";
        //    }

        //    return additionalQueryStringEncoded.Replace(" ", "+");
        //}







    }
}
