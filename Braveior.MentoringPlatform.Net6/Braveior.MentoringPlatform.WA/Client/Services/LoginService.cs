using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Braveior.MentoringPlatform.DTO;
using System.Net.Http.Json;
using System.Net;
using Braveior.MentoringPlatform.WA.Client.Services;

namespace Braveior.MentoringPlatform.WA.Client.Services
{
    public class LoginService : ILoginService
    {
        private HttpClient _httpClient { get; }

        public LoginService(HttpClient httpClient, IConfiguration config)
        {
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Blazor Web Assembly");
            _httpClient = httpClient;
        }
        /// <summary>
        /// REST API call to authenticate a User by Email and Password
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        public async Task<UserDTO> LoginAsync(LoginDTO userDTO)
        {
           var response = await _httpClient.PostAsJsonAsync($"api/Login/Login", userDTO);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<UserDTO>();
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new Exception("Invalid Access Token");
            }
            else
            {
                throw new Exception("Internal Server Error");
            }
        }

       
        /// <summary>
        /// REST API call to validate an accesstoken to authenticate a user
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public async Task<UserDTO> GetUserByAccessTokenAsync(string accessToken)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/Login/GetUserByAccessToken", accessToken);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<UserDTO>();
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new Exception("Invalid Access Token");
            }
            else
            {
                throw new Exception("Internal Server Error");
            }

        }

      
    }
}
