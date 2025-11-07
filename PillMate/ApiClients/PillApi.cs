using PillMate.DTO;
using PillMate.Services;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace PillMate.Client.ApiClients
{
    public class PillApi : ApiService
    {
        public PillApi() : base("Pills") { }

        // ✅ 알약 등록
        public async Task<bool> CreateAsync(PillDto pill)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(_baseUrl, pill);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CreateAsync] 오류: {ex.Message}");
                return false;
            }
        }

        // ✅ 알약 수정
        public async Task<bool> UpdateAsync(int id, PillDto pill)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/{id}", pill);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UpdateAsync] 오류: {ex.Message}");
                return false;
            }
        }


        // ✅ 알약 삭제
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DeleteAsync] 오류: {ex.Message}");
                return false;
            }
        }

        // ✅ 알약 목록 불러오기
        public async Task<List<PillDto>> GetAllAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<PillDto>>(_baseUrl)
                    ?? new List<PillDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GetAllAsync] 오류: {ex.Message}");
                return new List<PillDto>();
            }
        }

        // PillApi.cs 파일에 추가
        public async Task<PillDto> GetByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/pills/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<PillDto>(jsonContent, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                }
                else
                {
                    return null; // 약물을 찾을 수 없는 경우
                }
            }
            catch (Exception ex)
            {
                // 로그 기록 (필요시)
                Console.WriteLine($"PillApi.GetByIdAsync 오류: {ex.Message}");
                return null;
            }
        }

    }
}
