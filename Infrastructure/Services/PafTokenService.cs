using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Infrastructure.Services
{
    public class PafTokenService : IPafTokenService
    {
        private readonly IConfiguration _config;

        public PafTokenService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<string> GetAddressApiToken(string referer)
        {
            var pafUsername = _config.GetSection("PAF").GetSection("PAFUsername").Value;
            var pafPassword = _config.GetSection("PAF").GetSection("PAFPassword").Value;
            var addressApi = _config.GetSection("PAF").GetSection("AddressAPI").Value;

            var client = new HttpClient();
            var url = $"{addressApi}/user/authenticate";
            var values = new Dictionary<string, string> { { "username", pafUsername }, { "password", pafPassword }, { "referer", referer } };

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync(url, content);
            var json = await response.Content.ReadAsStringAsync();
            var token = JsonConvert.DeserializeObject<PafUser>(json)?.Token;
            return token;
        }

        public class PafUser
        {
            public string Token { get; set; }
        }
    }
}
