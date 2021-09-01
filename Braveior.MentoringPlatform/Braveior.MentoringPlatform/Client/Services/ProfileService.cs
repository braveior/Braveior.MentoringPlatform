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
    public class ProfileService : IProfileService
    {
        private HttpClient _httpClient { get; }

        private ILocalStorageService _localStorageService { get; }

        private IStoryService _storyService { get; }
        public ProfileService(HttpClient httpClient,ILocalStorageService localStorageService)
        {
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Blazor Web Assembly");
            _httpClient = httpClient;
            _localStorageService = localStorageService;
        }


        //public async Task<List<AssetDTO>> GetAssets(long userId)
        //{
        //    string authToken = "";
        //    //Get AccessToken from local storage
        //    authToken = await _localStorageService.GetItemAsync<string>("accessToken");
        //    if (authToken == null)
        //    {
        //        throw new Exception("Access Token not found");
        //    }
        //    //Add AccessToken to the Bearer header
        //    _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authToken);

        //    //REST API call for Search
        //    var response = await _httpClient.GetAsync($"api/Profile/getassets/{userId}");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        return await response.Content.ReadFromJsonAsync<List<AssetDTO>>();
        //    }
        //    else if (response.StatusCode == HttpStatusCode.Unauthorized)
        //    {
        //        throw new Exception("Invalid Access Token");
        //    }
        //    else
        //    {
        //        throw new Exception("Internal Server Error");
        //    }
        //}

        public async Task<List<InstitutionDTO>> GetColleges()
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
            var response = await _httpClient.GetAsync($"api/Profile/getcolleges");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<InstitutionDTO>>();
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

        public async Task<List<UserDTO>> GetStudents(long collegeId, string key)
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
            var response = await _httpClient.GetAsync($"api/Profile/getstudents/{collegeId}/{key}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<UserDTO>>();
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

        public async Task<List<SkillDTO>> GetSkills(string key)
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
            var response = await _httpClient.GetAsync($"api/Profile/getskills/{key}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<SkillDTO>>();
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

        
        public async Task<List<UserSkillDTO>> GetUserSkills(long userId)
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
            var response = await _httpClient.GetAsync($"api/Profile/getuserskills/{userId}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<UserSkillDTO>>();
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

        public async Task<List<EventDTO>> GetEvents()
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
            var response = await _httpClient.GetAsync($"api/Profile/getevents");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<EventDTO>>();
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
        public async Task<List<ChallengeDTO>> GetChallenges()
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
            var response = await _httpClient.GetAsync($"api/Profile/getchallenges");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<ChallengeDTO>>();
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
        public async Task<List<StudentActivityDTO>> GetStudentActivities(long userId)
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
            var response = await _httpClient.GetAsync($"api/Profile/getstudentactivities/{userId}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<StudentActivityDTO>>();
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

        public async Task<List<StudentActivityDTO>> GetPendingStudentActivities()
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
            var response = await _httpClient.GetAsync($"api/Profile/getpendingstudentactivities");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<StudentActivityDTO>>();
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
        public async Task<List<UserSkillDTO>> GetStudent(long userId)
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
            var response = await _httpClient.GetAsync($"api/Profile/getuserskills/{userId}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<UserSkillDTO>>();
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
        public async Task UpdateUserSkill(UserSkillDTO userSkillDTO)
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
            var response = await _httpClient.PostAsJsonAsync($"api/Profile/updateuserskill", userSkillDTO);
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
        public async Task UpdateUserProfile(UserDTO userDTO)
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
            var response = await _httpClient.PostAsJsonAsync($"api/Profile/updateuserprofile", userDTO);
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
        public async Task UpdateStudentEvent(StudentActivityDTO studentActitityDTO)
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
            var response = await _httpClient.PostAsJsonAsync($"api/Profile/updatestudentevent", studentActitityDTO);
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
        public async Task ResetPassword(UserDTO userDTO)
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
            var response = await _httpClient.PostAsJsonAsync($"api/Profile/resetpassword", userDTO);
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
        public async Task ApproveStudentActivity(StudentActivityDTO studentActivityDTO)
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
            var response = await _httpClient.PostAsJsonAsync($"api/Profile/approvestudentactivity", studentActivityDTO);
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
        public async Task DeleteUserSkill(long userSkillId)
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
            var response = await _httpClient.DeleteAsync($"api/Profile/deleteuserskill/{userSkillId}");
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
        public async Task DeleteStudentActivity(long studentActivityId)
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
            var response = await _httpClient.DeleteAsync($"api/Profile/deletestudentactivity/{studentActivityId}");
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
        public async Task UpdateStudentChallenge(StudentActivityDTO studentActitityDTO)
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
            var response = await _httpClient.PostAsJsonAsync($"api/Profile/updatestudentchallenge", studentActitityDTO);
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
        public async Task UpdateStudentAsset(StudentActivityDTO studentActitityDTO)
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
            var response = await _httpClient.PostAsJsonAsync($"api/Profile/updatestudentasset", studentActitityDTO);
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
        public async Task AddUserSkill(UserSkillDTO userSkillDTO)
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
            var response = await _httpClient.PostAsJsonAsync($"api/Profile/addstudentskill", userSkillDTO);
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
        public async Task AddStudentAsset(StudentActivityDTO studentActivityDTO)
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
            var response = await _httpClient.PostAsJsonAsync($"api/Profile/addstudentasset", studentActivityDTO);
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
        public async Task AddStudentEvent(StudentActivityDTO studentActivityDTO)
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
            var response = await _httpClient.PostAsJsonAsync($"api/Profile/addstudentevent", studentActivityDTO);
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
        public async Task AddStudentChallenge(StudentActivityDTO studentActivityDTO)
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
            var response = await _httpClient.PostAsJsonAsync($"api/Profile/addstudentchallenge", studentActivityDTO);
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
