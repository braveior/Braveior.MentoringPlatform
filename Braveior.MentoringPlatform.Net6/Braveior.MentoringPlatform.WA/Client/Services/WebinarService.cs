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
    public class WebinarService : IWebinarService
    {
        private HttpClient _httpClient { get; }

        private ILocalStorageService _localStorageService { get; }

        public WebinarService(HttpClient httpClient,ILocalStorageService localStorageService)
        {
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Blazor Web Assembly");
            _httpClient = httpClient;
            _localStorageService = localStorageService;
        }
        


        
 
         
        public async Task<BootCampActivityDTO> GetBootCampActivity(long bootCampActivityId)
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
        var response = await _httpClient.GetAsync($"api/Webinar/getbootcampactivity/{bootCampActivityId}");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<BootCampActivityDTO>();
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
    public async Task<List<BootCampActivityDTO>> GetBootCampActivities()
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
            var response = await _httpClient.GetAsync($"api/Webinar/getbootcampactivities");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<BootCampActivityDTO>>();
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

        public async Task<List<BootCampDTO>> GetBootCamps()
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
            var response = await _httpClient.GetAsync($"api/Webinar/getbootcamps");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<BootCampDTO>>();
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
        public async Task AddBootCampActivity(BootCampActivityDTO bootCampActivityDTO)
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
            var response = await _httpClient.PostAsJsonAsync($"api/Webinar/addbootcampactivity", bootCampActivityDTO);
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

        public async Task UpdateBootCampActivity(BootCampActivityDTO bootCampActivityDTO)
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
            var response = await _httpClient.PostAsJsonAsync($"api/Webinar/updatebootcampactivity", bootCampActivityDTO);
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

        public async Task DeleteBootCampActivity(long bootCampActivityId)
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
            var response = await _httpClient.DeleteAsync($"api/Webinar/deletebootcampactivity/{bootCampActivityId}");
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
