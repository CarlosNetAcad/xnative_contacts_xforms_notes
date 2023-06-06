using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ContactApp.Core.Repository.API;
using Newtonsoft.Json;
using NotesCarlos.Core.Models.API;
using NotesForms.Services;

namespace NotesForms.Repository
{
    public class APIRepository : IArticleService
    {
        #region Flds
        string endpoint = "https://newsapi.org/v2/top-headlines";

        HttpClient _client;

        #endregion Flds

        #region Props
        #endregion Props

        public async Task<IList<Article>> GetAllAsync()
        {
            _client = Connection.Instance;

            var requestHttp = new HttpRequestMessage();

            requestHttp.Method = HttpMethod.Get;
            requestHttp.RequestUri = new Uri( endpoint + "?country=us&apiKey=7e12ba233c3649c6bdcb6a1eece22aa4&category=technology");

            var response = await _client.SendAsync( requestHttp );

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();

                var articleResponse = JsonConvert.DeserializeObject<APINewsResponse>( jsonResponse );

                return articleResponse.Articles;
            }

            //-> We must close the connection because consume so much resource
            //-> Could be by Disposible pattern using "using (var httpClient = new HttpClient())"
            _client.Dispose();

            return new List<Article>();
        }
    }
}

