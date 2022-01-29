using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Braveior.MentoringPlatform.DTO;
using Blazored.LocalStorage;
using System.Net.Http.Json;
using System.Net;
using Microsoft.AspNetCore.Components.WebAssembly.Http;

namespace Braveior.MentoringPlatform.WA.Client.Services
{
    public class StoryService : IStoryService
    {
        private HttpClient _httpClient { get; }

        private ILocalStorageService _localStorageService { get; }

        private IStoryService _storyService { get; }
        public StoryService(HttpClient httpClient,ILocalStorageService localStorageService)
        {
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Blazor Web Assembly");
            _httpClient = httpClient;
            _localStorageService = localStorageService;
        }

        /// <summary>
        /// REST API call to add Rating to a member
        /// </summary>
        /// <param name="rating"></param>
        /// <returns></returns>
        public async Task CreateStory(StoryDTO storyDTO)
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
            //REST API call to add the rating for a member
            var response = await _httpClient.PostAsJsonAsync($"api/Story/createstory", storyDTO);
            if (response.IsSuccessStatusCode)
            {

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
        /// REST API call to add Rating to a member
        /// </summary>
        /// <param name="rating"></param>
        /// <returns></returns>
        public async Task CreateTask(TaskDTO taskDTO)
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

            //REST API call to add the rating for a member
            var response = await _httpClient.PostAsJsonAsync($"api/Story/createtask", taskDTO);
            if (response.IsSuccessStatusCode)
            {

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
        /// REST API call to add Rating to a member
        /// </summary>
        /// <param name="rating"></param>
        /// <returns></returns>
        public async Task UpdateStory(StoryDTO storyDTO)
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

            //REST API call to add the rating for a member
            var response = await _httpClient.PostAsJsonAsync($"api/Story/updatestory", storyDTO);
            if (response.IsSuccessStatusCode)
            {

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
        /// REST API call to add Rating to a member
        /// </summary>
        /// <param name="rating"></param>
        /// <returns></returns>
        public async Task UpdateTask(TaskDTO taskDTO)
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

            //REST API call to add the rating for a member
            var response = await _httpClient.PostAsJsonAsync($"api/Story/updatetask", taskDTO);
            if (response.IsSuccessStatusCode)
            {

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
        /// REST API call to add Rating to a member
        /// </summary>
        /// <param name="rating"></param>
        /// <returns></returns>
        public async Task UpdateTaskStatus(TaskDTO taskDTO)
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

            //REST API call to add the rating for a member
            var response = await _httpClient.PostAsJsonAsync($"api/Story/updatetaskstatus", taskDTO);
            if (response.IsSuccessStatusCode)
            {

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
        /// REST API call to add Rating to a member
        /// </summary>
        /// <param name="rating"></param>
        /// <returns></returns>
        public async Task UpdateStoryStatus(StoryDTO storyDTO)
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

            //REST API call to add the rating for a member
            var response = await _httpClient.PostAsJsonAsync($"api/Story/updatestorystatus", storyDTO);
            if (response.IsSuccessStatusCode)
            {

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
        /// REST API call to search Member data
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<List<StoryDTO>> GetStories(long userId)
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
            var response = await _httpClient.GetAsync($"api/Story/getkanboardstories/{userId}?{DateTime.Now.ToLongTimeString()}");
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
            var response = await _httpClient.GetAsync($"api/Story/getstory/{storyid}?{DateTime.Now.ToLongTimeString()}");
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

        /// <summary>
        /// REST API call to search Member data
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<List<TaskDTO>> GetTasks(long storyId)
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
            var response = await _httpClient.GetAsync($"api/Story/gettasks/{storyId}?{DateTime.Now.ToLongTimeString()}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<TaskDTO>>();
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

        public async Task<TaskDTO> GetTask(long taskid)
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
            var response = await _httpClient.GetAsync($"api/Story/gettask/{taskid}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TaskDTO>();
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

        public async Task<KanboardDTO> GetKanboard(long kanboardId)
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
            var response = await _httpClient.GetAsync($"api/Story/getkanboard/{kanboardId}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<KanboardDTO>();
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
