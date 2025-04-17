using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using PillMate.DTO;
using PillMate.Services;

namespace PillMate.Client.ApiClients
{
    public class PillAPI : ApiService
    {
        public PillAPI() : base("Pills") { }



        // 알약 등록
        public async Task<bool> CreatePillAsync(PillDto pill)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(_baseUrl, pill);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CreatePillAsync] 오류: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> AddAsync(CreatePatientDto dto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}", dto);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[AddAsync] 오류: {ex.Message}");
                return false;
            }
        }

        // 알약 수정
        public async Task<bool> UpdatePillAsync(int id, PillDto pill)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/{id}", pill);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UpdatePillAsync] 오류: {ex.Message}");
                return false;
            }
        }

        // 알약 삭제
        public async Task<bool> DeletePillAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DeletePillAsync] 오류: {ex.Message}");
                return false;
            }
        }

        // 알약 목록 불러오기
        public async Task<List<PillDto>> GetPillsAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<PillDto>>(_baseUrl)
                    ?? new List<PillDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GetPillsAsync] 오류: {ex.Message}");
                return new List<PillDto>();
            }
        }

        // alias 역할 (기존과 동일한 기능)
        public async Task<List<PillDto>> GetAllAsync() => await GetPillsAsync();
    }
}