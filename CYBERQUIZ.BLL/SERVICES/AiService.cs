using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace CYBERQUIZ.BLL.SERVICES
{
    //I princip direktkopierad från movie api projektet vi gjorde
    public class AiService
    {

        private readonly HttpClient _httpClient;

        public AiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:11434"); //KONTROLLERA DENNA
        }

        public async Task<string> AskAsync(string prompt)
        {
            var request = new
            {
                model = "phi3", //Här byter man modell, men måste göra en pull först (ex. powershell)
                prompt = prompt,
                stream = false
            };

            var response = await _httpClient.PostAsJsonAsync("/api/generate", request);
            var result = await response.Content.ReadFromJsonAsync<OllamaResponse>();

            return result.response;

        }

        public class OllamaResponse
        {
            public string response { get; set; }
        }

    }
}
