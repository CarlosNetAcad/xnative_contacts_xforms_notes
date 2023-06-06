using System;
using Newtonsoft.Json;

namespace NotesCarlos.Core.Models.API
{
    public class UserToken
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }
}