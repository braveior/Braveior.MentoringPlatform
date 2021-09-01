using AutoMapper;
using Braveior.MentoringPlatform.DTO;
using Braveior.MentoringPlatform.Services.Interfaces;
using Braveior.MentoringPlatform.Repository.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.DataProtection;
using Braveior.MentoringPlatform.Repository;
using System.Security.Cryptography;
using System.IO;

namespace Braveior.MentoringPlatform.Services
{
    /// <summary>
    /// Login service for Authentication and Authorization
    /// </summary>
    public class LoginService : ILoginService
    {

        braveiordbContext _dbContext;
        private readonly IMapper _mapper;
        public LoginService(IMapper mapper, braveiordbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }


        public void Register(UserDTO userDTO)
        {
            //using (var db = new braveiordbContext())
            //{
                User newUser = new User()
                {

                     Email = userDTO.Email,
                     InstitutionId = userDTO.InstitutionId,
                     Role = userDTO.Role,
                     Password = userDTO.Password
                          
                };
            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
            //}
        }


        /// <summary>
        /// Method to Authenticate the user credentials - Email and password
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserDTO Login(LoginDTO userDTO)
        {
            //using (var db = new braveiordbContext())
            //{
                //var user = db.Users.Where(a => a.Email == userDTO.Email && a.Password == userDTO.Password).Include(g => g.Group).ThenInclude(k => k.Kanboards).FirstOrDefault();
                var user = _dbContext.Users.Where(a => a.Email == userDTO.Email && a.Password == Encrypt(userDTO.Password)).Include(g=>g.Group).ThenInclude(i=>i.Institution).FirstOrDefault();


                if (user == null)
                {
                    throw new Exception("User not found");
                }
                else
                {
                    var userWithToken = _mapper.Map<UserDTO>(user);
                    userWithToken.AccessToken = GenerateAccessToken(userWithToken);
                    return userWithToken;
                }
            //}

        }
        /// <summary>
        /// Get the User ( Member) mapped to the accessToken
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public async Task<UserDTO> GetUserFromAccessToken(string accessToken)
        {
            var email = ValidateAccessToken(accessToken);
            if (!String.IsNullOrEmpty(email))
            {
               // using (var db = new braveiordbContext())
               // {
                    var user = _dbContext.Users.Where(a => a.Email == email).Include(g => g.Group).ThenInclude(i => i.Institution).FirstOrDefault();
                    return _mapper.Map<UserDTO>(user);
              //  }
            }

            throw new Exception("Invalid access Token");
        }



        /// <summary>
        /// Generate the Access Token for the member ID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        private string GenerateAccessToken(UserDTO userDTO)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("thisisasecretkeyanddontsharewithanyone");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, userDTO.Email),
                    new Claim(ClaimTypes.Role, userDTO.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddYears(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        /// <summary>
        /// Validate the Access Token and returns the member Id
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        private string ValidateAccessToken(string accessToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("thisisasecretkeyanddontsharewithanyone");

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };

            SecurityToken securityToken;
            var principle = tokenHandler.ValidateToken(accessToken, tokenValidationParameters, out securityToken);

            JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;

            if (jwtSecurityToken != null && jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                var email = principle.FindFirst(ClaimTypes.Email)?.Value;
                if (!String.IsNullOrEmpty(email))
                {
                    return email;
                }
                else
                    throw new Exception("Invalid access Token");
            }
            throw new Exception("Invalid access Token");
        }

        private string Encrypt(string text)
        {
            var b = Encoding.UTF8.GetBytes(text);
            var encrypted = getAes().CreateEncryptor().TransformFinalBlock(b, 0, b.Length);
            return Convert.ToBase64String(encrypted);
        }

        private string Decrypt(string encrypted)
        {
            var b = Convert.FromBase64String(encrypted);
            var decrypted = getAes().CreateDecryptor().TransformFinalBlock(b, 0, b.Length);
            return Encoding.UTF8.GetString(decrypted);
        }

        private Aes getAes()
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
