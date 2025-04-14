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
using PillMate.Services;

namespace PillMate.Client.ApiClients
{
    public class PillAPI : ApiService
    {

        public PillAPI() : base("Pills") { }


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