using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace Maps_Temp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        private readonly MyConfigSettings _myConfigSettings;


        public IndexModel(ILogger<IndexModel> logger, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _myConfigSettings = new MyConfigSettings
            {
                OneMapEmail = configuration["MyConfigSettings:OneMapEmail"],
                OneMapPwd = configuration["MyConfigSettings:OneMapPwd"]
            };
        }


        public async Task OnGet()
        {
            string authJson = $@"{{""email"":""{_myConfigSettings.OneMapEmail}"",""password"":""{_myConfigSettings.OneMapPwd}"" }}";
            //string authJson = string.Format(authTemplate, _myConfigSettings.OneMapEmail, _myConfigSettings.OneMapPwd);
            var authInfo = new StringContent(
                authJson,
                Encoding.UTF8,
                Application.Json);

            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.PostAsync("https://developers.onemap.sg/privateapi/auth/post/getToken", authInfo);

            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                return;
            }
            OneMapToken? token = JsonSerializer.Deserialize<OneMapToken>(await httpResponseMessage.Content.ReadAsStringAsync());
            if (token == null)
            {
                return;
            }
            // routing service API

        }
    }
}