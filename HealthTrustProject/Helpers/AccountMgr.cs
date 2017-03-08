using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Security.Cryptography;

namespace HealthTrustProject.Models
{
    public class AccountMgr
    {
        public static bool Login(string email, string password)
        {
            HealthTrustContext ctx = new HealthTrustContext();
            bool isValid = false;
            try
            {
                Accounts account = ctx.Accounts.FirstOrDefault(P => P.email == email);
                byte[] pw1 = System.Text.Encoding.ASCII.GetBytes(account.password);
                byte[] pw2 = System.Text.Encoding.ASCII.GetBytes(CreatePasswordHash(password, account.PasswordHash));
                if (CompareByteArrays(pw1,pw2))
                {
                    isValid = true;
                }
                else
                {
                    isValid = false;
                }                
            }
            catch (Exception ex)
            {

            }
            return isValid;
        }
        public static bool Register(string email, string password)
        {
            HealthTrustContext ctx = new HealthTrustContext();
            bool isValid = false;
            try
            {
                string salt = CreateSalt(20);
                string hash = CreatePasswordHash(password, salt);
                Accounts account = new Accounts();
                account.email = email;
                account.password = hash;
                account.PasswordHash = salt;
                ctx.Accounts.Add(account);
                ctx.SaveChanges();
                isValid = true;
            }
            catch (Exception ex)
            {

            }
            return isValid;
        }
        private static string CreateSalt(int size)
        {
            //Generate a cryptographic random number.
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);

            // Return a Base64 string representation of the random number.
            return Convert.ToBase64String(buff);
        }

        private static string CreatePasswordHash(string pwd, string salt)
        {
            string saltAndPwd = String.Concat(pwd, salt);
            string hashedPwd =
                FormsAuthentication.HashPasswordForStoringInConfigFile(saltAndPwd, "sha1");
            return hashedPwd;
        }

        public static bool CompareByteArrays(byte[] array1, byte[] array2)
        {
            if (array1.Length != array2.Length)
            {
                return false;
            }

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}