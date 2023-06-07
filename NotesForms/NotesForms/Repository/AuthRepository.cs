using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ContactApp.Core.Entities;
using ContactApp.Core.Repository.API;
using Newtonsoft.Json;
using NotesCarlos.Core.Models.API;
using NotesForms.Services;

namespace NotesForms.Repository
{
	public class AuthRepository:IAuthService
	{
        string endpoint = "https://fakestoreapi.com";

        HttpClient _client;

        public User CurrentUser
        {
            get;
            private set;
        }

        public Task<bool> RefreshAuth()
        {
            return Task.FromResult( false );
        }

        public async Task<bool> SignInAsync( string userName, string password)
        {

            _client = Connection.Instance;

            var requestHttp = new HttpRequestMessage();

            requestHttp.Method = HttpMethod.Post;
            requestHttp.RequestUri = new Uri( endpoint + "/auth/login");

            var user = new UserToken
            {
                Username = userName,
                Password = password
            };

            var jsonRequest = JsonConvert.SerializeObject( user );

            requestHttp.Content = new StringContent( jsonRequest,Encoding.UTF8,"application/json");

            //Add bearer token if needed
            //requestHttp.Headers.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjYyIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZSI6IlNpbHZpYSBTYWlueiBMb3BleiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2VtYWlsYWRkcmVzcyI6InNzYWluekBzdWVtYWlsLmNvbSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IjgiLCJleHAiOjE2NzcwMzU0NjUsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6MTAyMDQiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjEwMjA0In0.7R-EggX7rieFL-Qe0tu6O5WE7PQHGysm8IamHFUVRm8");

            var response = await _client.SendAsync( requestHttp );

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();

                var token = JsonConvert.DeserializeObject<UserToken>( jsonResponse );

                Console.WriteLine($"Token: {token.Token}");

                CurrentUser = new User
                {
                    UserName = userName,
                    PassWord = password
                };

                return true;
            }
            else return true;
        }

        public async Task<bool> SignOutAsync()
        {
            CurrentUser = null;

            return await Task.FromResult(true);
        }
    }
}