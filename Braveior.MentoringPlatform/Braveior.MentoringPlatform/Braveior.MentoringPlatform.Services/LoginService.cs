using AutoMapper;
using Braveior.MentoringPlatform.DTO;
using Braveior.MentoringPlatform.Services.Interfaces;
using Braveior.MentoringPlatform.Repository.Models;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using Microsoft.AspNetCore.DataProtection;
using Braveior.MentoringPlatform.Repository.Contexts;

namespace Braveior.MentoringPlatform.Services
{
    /// <summary>
    /// Login service for Authentication and Authorization
    /// </summary>
    public class LoginService : ILoginService
    {


        private readonly IMapper _mapper;
        public LoginService( IMapper mapper)
        {
            _mapper = mapper;
        }
        /// <summary>
        /// Method to Authenticate the user credentials - Email and password
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserDTO Login(LoginDTO userDTO)
        {
            using (var db = new BraveiorDBContext())
            {
                var user = db.Users.Where(a => a.Email == userDTO.Email && a.Password == userDTO.Password).FirstOrDefault();


                if (user == null)
                {
                    throw new Exception("User not found");
                }
                else
                {
                    var userWithToken = _mapper.Map<UserDTO>(user);
                    userWithToken.AccessToken = GenerateAccessToken(user.Email);
                    return userWithToken;
                }
            }

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
                    using (var db = new BraveiorDBContext())
                    {
                        var user = db.Users.Where(a => a.Email == email).FirstOrDefault();
                        return _mapper.Map<UserDTO>(user);
                    }
                }

            throw new Exception("Invalid access Token");
        }

    

        /// <summary>
        /// Generate the Access Token for the member ID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        private string GenerateAccessToken(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("thisisasecretkeyanddontsharewithanyone");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, email)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
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
               
    }
}
