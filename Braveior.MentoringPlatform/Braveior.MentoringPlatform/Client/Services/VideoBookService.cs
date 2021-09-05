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

namespace Braveior.MentoringPlatform.Client.Services
{
    public class VideoBookService : IVideoBookService
    {
        private HttpClient _httpClient { get; }

        private ILocalStorageService _localStorageService { get; }

        private IStoryService _storyService { get; }
        public VideoBookService(HttpClient httpClient,ILocalStorageService localStorageService)
        {
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Blazor Web Assembly");
            _httpClient = httpClient;
            _localStorageService = localStorageService;
        }
        
    public async Task<VideoBookDTO> GetVideoBook(long videoBookId)
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
        var response = await _httpClient.GetAsync($"api/VideoBook/getvideobooks/{videoBookId}");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<VideoBookDTO>();
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
    public async Task<List<VideoBookDTO>> GetVideoBooks()
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
            var response = await _httpClient.GetAsync($"api/VideoBook/getvideobooks");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<VideoBookDTO>>();
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

        public async Task<List<LessonDTO>> GetVideoBookLessons(long videoBookId)
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
            var response = await _httpClient.GetAsync($"api/VideoBook/getvideobooklessons/{videoBookId}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<LessonDTO>>();
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

        public async Task AddVideoBook(VideoBookDTO videoBookDTO)
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
            var response = await _httpClient.PostAsJsonAsync($"api/VideoBook/addvideobook", videoBookDTO);
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

        public async Task UpdateVideoBook(VideoBookDTO videoBookDTO)
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
            var response = await _httpClient.PostAsJsonAsync($"api/VideoBook/updatevideobook", videoBookDTO);
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

        public async Task AddVideoBookLesson(LessonDTO videoBookLessonDTO)
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
            var response = await _httpClient.PostAsJsonAsync($"api/VideoBook/addvideobooklesson", videoBookLessonDTO);
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

        public async Task UpdateVideoBookLesson(LessonDTO videoBookLessonDTO)
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
            var response = await _httpClient.PostAsJsonAsync($"api/VideoBook/updatevideobooklesson", videoBookLessonDTO);
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
        public async Task DeleteVideoBook(long videoBookId)
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
            var response = await _httpClient.DeleteAsync($"api/VideoBook/deletevideobook/{videoBookId}");
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
        public async Task DeleteVideoBookLesson(long videoBookLessonId)
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
            var response = await _httpClient.DeleteAsync($"api/VideoBook/deletevideobooklesson/{videoBookLessonId}");
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
    }
}
