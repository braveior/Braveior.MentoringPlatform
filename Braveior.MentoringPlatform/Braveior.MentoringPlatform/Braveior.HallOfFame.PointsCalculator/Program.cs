using Braveior.MentoringPlatform.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Braveior.HallOfFame.PointsCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new braveiordbContext())
            {
                var users = db.Users.Include(a => a.StudentActivities).ToList();
                foreach (var user in users)
                {
                    var totalpoints = user.StudentActivities.Sum(a => a.Points);
                    user.Points = totalpoints;
                    //user.Password = Encrypt("password");
                    db.Users.Update(user);
                }
                db.SaveChanges();
            }
         }
        private static string Encrypt(string text)
        {
            var b = Encoding.UTF8.GetBytes(text);
            var encrypted = getAes().CreateEncryptor().TransformFinalBlock(b, 0, b.Length);
            return Convert.ToBase64String(encrypted);
        }

        private static string Decrypt(string encrypted)
        {
            var b = Convert.FromBase64String(encrypted);
            var decrypted = getAes().CreateDecryptor().TransformFinalBlock(b, 0, b.Length);
            return Encoding.UTF8.GetString(decrypted);
        }

        private static Aes getAes()
        {
            var keyBytes = new byte[16];
            var skeyBytes = Encoding.UTF8.GetBytes("12345678901234567890123456789012");
            Array.Copy(skeyBytes, keyBytes, Math.Min(keyBytes.Length, skeyBytes.Length));

            Aes aes = Aes.Create();
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.KeySize = 128;
            aes.Key = keyBytes;
            aes.IV = keyBytes;

            return aes;
        }

    }
}
