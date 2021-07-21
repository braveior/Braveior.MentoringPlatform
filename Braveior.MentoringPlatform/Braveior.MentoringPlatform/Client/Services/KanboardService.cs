using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Braveior.MentoringPlatform.DTO;
using Blazored.LocalStorage;
using System.Net.Http.Json;
using System.Net;

namespace Braveior.MentoringPlatform.Client.Services
{
    public class KanboardService : IKanboardService
    {
        private HttpClient _httpClient { get; }

        private ILocalStorageService _localStorageService { get; }

        private ILoginService _loginService { get; }
        public KanboardService(HttpClient httpClient, IConfiguration config, ILocalStorageService localStorageService, ILoginService loginService)
        {
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Blazor Web Assembly");
            _httpClient = httpClient;
            _loginService = loginService;
            _localStorageService = localStorageService;
        }
        /// <summary>
        /// REST API call to search Member data
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<List<StoryDTO>> GetStories(long kanboardId)
        {
            string authToken = "";
            //Get AccessToken from local storage
            authToken = await _localStorageService.GetItemAsync<string>("accessToken");
            if (authToken == null)
            {
                throw new Exception("Access Token not found");
            }
            //Add AccessToken to the Bearer header
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authToken);

            //REST API call for Search
            var response = await _httpClient.GetAsync($"api/Kanboard/getstories/{kanboardId}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<StoryDTO>>();
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

        public async Task<StoryDTO> GetStory(long storyid)
        {
            string authToken = "";
            //Get AccessToken from local storage
            authToken = await _localStorageService.GetItemAsync<string>("accessToken");
            if (authToken == null)
            {
                throw new Exception("Access Token not found");
            }
            //Add AccessToken to the Bearer header
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authToken);

            //REST API call for Search
            var response = await _httpClient.GetAsync($"api/Kanboard/getstory/{storyid}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<StoryDTO>();
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
