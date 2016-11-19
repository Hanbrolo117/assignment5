using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace ourLibrary
{
    // Example class
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

}
