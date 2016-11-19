using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Xml;

namespace ourLibrary
{
     public class Crypto 
     {
        private byte[] key;
        private byte[] iv;

        public Crypto()
        {
            //Set up Default 32-Byte Key:
            this.key = Encoding.UTF8.GetBytes("7sdfasdfasdfasdfasdfasdfasdfasd7");

            //Set up Default 16-Byte Initialization Vector:
            this.iv = Encoding.UTF8.GetBytes("1quinnzxcasdqwe1");
        }

        public String encryption(string plainText)
        {
            //Initial Setup:
            //------------------------------------------------------------------------------------------------------------------
            String ciphertext = "";
            //------------------------------------------------------------------------------------------------------------------


            //Do Initial Error Checking before encryption:
            //------------------------------------------------------------------------------------------------------------------
            if (plainText == null || plainText.Length <= 0) { throw new ArgumentException("plaintext"); }
            if (this.key == null || this.key.Length <= 0) { throw new ArgumentException("key"); }
            if (this.iv == null || this.iv.Length <= 0) { throw new ArgumentException("iv"); }
            //------------------------------------------------------------------------------------------------------------------


            //Declare encrypted Byte Array:
            //------------------------------------------------------------------------------------------------------------------
            byte[] encrypted;
            //------------------------------------------------------------------------------------------------------------------


            //Encrypt plaintext:
            //------------------------------------------------------------------------------------------------------------------
            using (Rijndael rij = Rijndael.Create())
            {
                rij.Key = this.key;
                rij.IV = this.iv;

                ICryptoTransform encryptor = rij.CreateEncryptor(rij.Key, rij.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter westream = new StreamWriter(csEncrypt))
                        {
                            westream.Write(plainText);
                        }//END OF STREAM-WRITER.
                        encrypted = msEncrypt.ToArray();
                    }//END OF CRYPTO_STREAM.
                }//END OF MEMORY-STREAM.
            }//END OF RIJNDAEL.
            //------------------------------------------------------------------------------------------------------------------


            //Convert Byte array to string:
            //------------------------------------------------------------------------------------------------------------------
            ciphertext = System.Text.Encoding.Default.GetString(encrypted);
            //------------------------------------------------------------------------------------------------------------------


            //Return Encrypted String:
            //------------------------------------------------------------------------------------------------------------------
            return ciphertext;
            //------------------------------------------------------------------------------------------------------------------
        }//END OF ENCRYPTION FUNCTION.


        public String decryption(string ciphertext)
        {
            //Initial setup:
            //------------------------------------------------------------------------------------------------------------------
            string plaintext = null;
            byte[] ctByteArray = System.Text.Encoding.Default.GetBytes(ciphertext);

            //------------------------------------------------------------------------------------------------------------------


            //Do Initial Error Checking before encryption:
            //------------------------------------------------------------------------------------------------------------------
            if (ciphertext == null || ciphertext.Length <= 0) { throw new ArgumentException("ciphertext"); }
            if (this.key == null || this.key.Length <= 0) { throw new ArgumentException("key"); }
            if (this.iv == null || this.iv.Length <= 0) { throw new ArgumentException("iv"); }
            //------------------------------------------------------------------------------------------------------------------


            //Decrypt Encrypted Byte Array from the ciphertext string passed in:
            //------------------------------------------------------------------------------------------------------------------
            using (Rijndael rij = Rijndael.Create())
            {
                rij.Key = this.key;
                rij.IV = this.iv;

                ICryptoTransform decryptor = rij.CreateDecryptor(rij.Key, rij.IV);

                using (MemoryStream msdecrypt = new MemoryStream(ctByteArray))
                {
                    using (CryptoStream csdecrypt = new CryptoStream(msdecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader dereader = new StreamReader(csdecrypt))
                        {
                            plaintext = dereader.ReadToEnd();
                        }//END OF STREAM-READER.
                    }//END OF CRYPTO-STREAM.
                }//END OF MEMORY-STREAM.
            }//END OF RIJNDAEL.
             //------------------------------------------------------------------------------------------------------------------


            //Return Decrypted PlainText:
            //------------------------------------------------------------------------------------------------------------------
            return plaintext;
            //------------------------------------------------------------------------------------------------------------------

        }//END OF DECRYPTION FUNCTION.
    }

    public class XMLProccess
    {
        
        public static XmlNode findUser(string XMLPath, string username)
        {
            FileStream fs = null;
            XmlNode node = null;
            try
            {
                if (File.Exists(XMLPath))
                {
                    fs = new FileStream(XMLPath, FileMode.Open, FileAccess.Read);
                    XmlDocument xd = new XmlDocument();
                    xd.Load(fs);
                    fs.Close();
                    node = xd["Staffs"];
                    node = node.SelectSingleNode("descendant::user/userName[text()='" + username + "']");
                    if(node != null)
                        node = node.ParentNode;
                }
            }
            finally
            {
                fs.Close();
            }
            return node;
        }
        //return array of string. First element will be "Error" if error occur
        public static string[] getUserList(string XMLPath)
        {
            string[] ret;
            FileStream fs = null;
            string fLocation = XMLPath;
            try
            {
                if (File.Exists(fLocation))
                {
                    fs = new FileStream(fLocation, FileMode.Open, FileAccess.Read);
                    XmlDocument xd = new XmlDocument();
                    xd.Load(fs);
                    fs.Close();
                    XmlNode node = xd["Staffs"];
                    XmlNodeList children = node.ChildNodes;
                    ret = new string[children.Count];
                    int i = 0;

                    foreach (XmlNode child in children)
                    {
                        ret[i] = child["userName"].InnerText;
                        i++;
                    }
                    return ret;
                }
            }
            finally
            {
                fs.Close();
            }
            ret = new string[1];
            ret[1] = "Error";
            return ret;
        }
    }

}
