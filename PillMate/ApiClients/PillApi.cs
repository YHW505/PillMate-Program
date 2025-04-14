using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using PillMate.DTO;

namespace PillMate.Client.ApiClients
{
    internal class PillAPI
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly string _baseUrl = "https://localhost:14188/api/Pills"; // 서버 주소 맞출것

        public PillAPI()
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };

            _httpClient = new HttpClient(handler);
        }

        // 알약 목록 불러오기
        public async Task<List<PillDto>> GetPillsAsync()
        {
            var response = await _httpClient.GetAsync(_baseUrl);

            response.EnsureSuccessStatusCode();
            string json = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<List<PillDto>>(json, options);
        }

        // 알약 등록
        public async Task<bool> CreatePillAsync(PillDto pill)
        {
            string json = JsonSerializer.Serialize(pill);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_baseUrl, content); // var response = await _httpClient.PostAsJsonAsync("/api/pill", pill);
            response.EnsureSuccessStatusCode();

            return response.IsSuccessStatusCode;
        }

        // 알약 수정
        public async Task UpdatePillAsync(int id, PillDto pill)
        {
            string json = JsonSerializer.Serialize(pill);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"{_baseUrl}/{id}", content);
            response.EnsureSuccessStatusCode();
        }

        // 알약 삭제
        public async Task DeletePillAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
            response.EnsureSuccessStatusCode();


        }

    }


}