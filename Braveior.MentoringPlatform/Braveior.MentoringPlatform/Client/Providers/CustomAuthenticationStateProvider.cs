using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Net.Http;
using Braveior.MentoringPlatform.Client.Services;
using Braveior.MentoringPlatform.DTO;
using Braveior.MentoringPlatform.Client.State.Common;
using Fluxor;
using System;

namespace Braveior.MentoringPlatform.Client.Providers
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private ILocalStorageService _localStorageService { get; }

        private IDispatcher _dispatcher { get; }
        private ILoginService _loginService { get; set; }        
        private HttpClient _httpClient;        


        public CustomAuthenticationStateProvider(ILocalStorageService localStorageService,
            ILoginService loginService,
            HttpClient httpClient, IDispatcher dispatcher)
        {
            _localStorageService = localStorageService;
            _loginService = loginService;
            _httpClient = httpClient;
            _dispatcher = dispatcher;
        }
        /// <summary>
        /// Method called when the 
        /// </summary>
        /// <returns></returns>
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            ClaimsPrincipal claimsprincipal;
            try
            {
                //Get Access token stored in the Browser Local storage
                var accessToken = await _localStorageService.GetItemAsync<string>("accessToken");
                

                if (accessToken != null && accessToken != string.Empty)
                {
                    //REST API call to authenticate User by Access Token
                    UserDTO member = await _loginService.GetUserByAccessTokenAsync(accessToken);
                    claimsprincipal = GetClaimsPrincipal(member);
                    if (member.Email != null)
                    {
                        //Set the Authenticated User data in Fluxor Global State
                        _dispatcher.Dispatch(new CommonAction(member));
                    }
                }
                else
                {
                    claimsprincipal = new ClaimsPrincipal(new ClaimsIdentity());
                }
            }
            catch (Exception ex)
            {
                await _localStorageService.RemoveItemAsync("accessToken");
                claimsprincipal = new ClaimsPrincipal(new ClaimsIdentity());
            }
            return await Task.FromResult(new AuthenticationState(claimsprincipal));
        }

        /// <summary>
        /// Method called when the User is authenticated during Login
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public async Task MarkUserAsAuthenticated(UserDTO member)
        {
            //Store the Access token in the Browser Local storage
            await _localStorageService.SetItemAsync("accessToken", member.AccessToken);

            var claimsPrincipal = GetClaimsPrincipal(member);

            if (member.Email != null)
            {
                //Set the Authenticated User data in Fluxor Global State
                _dispatcher.Dispatch(new CommonAction(member));
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }
        /// <summary>
        /// Method called when the User is logged out
        /// </summary>
        /// <returns></returns>
        public async Task MarkUserAsLoggedOut()
        {
            //Remove the Access token in the Browser Local storage
            await _localStorageService.RemoveItemAsync("accessToken");

            var identity = new ClaimsIdentity();

            var member = new ClaimsPrincipal(identity);

            //_dispatcher.Dispatch(new CommonAction(new UserDTO()));

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(member)));
        }

        /// <summary>
        /// Set the Authorization data - Loggedin User Name and  Role to the ClaimsIdentity
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        private ClaimsPrincipal GetClaimsPrincipal(UserDTO member)
        {
            var claimsIdentity = new ClaimsIdentity();


            if (member.Email != null)
            { 
                claimsIdentity = new ClaimsIdentity(new[]
                                {
                                    new Claim(ClaimTypes.Email, member.Email),
                                     new Claim(ClaimTypes.Role, member.Role.ToString().Trim())
                                }, "apiauth_type");
            }
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            

            return claimsPrincipal;
        }

    }
}
