using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using PillMate.DTO;
using PillMate.Services;

namespace PillMate.ApiClients
{
    public class BukyoungStatusApi : ApiService
    {
        public BukyoungStatusApi() : base("BukyoungStatuses") { }

        // 복약 여부 등록 (Create)
        public async Task<bool> AddAsync(CreateBukyoungStatusDto dto)
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

        // 복약 여부 수정 (Update)
        public async Task<bool> UpdateAsync(UpdateBukyoungStatusDto dto)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/{dto.Id}", dto);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UpdateAsync] 오류: {ex.Message}");
                return false;
            }
        }

        // 복약 여부 삭제 (Delete)
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

        // 전체 목록 불러오기
        public async Task<List<BukyoungStatusDto>> GetAllAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<BukyoungStatusDto>>(_baseUrl)
                       ?? new List<BukyoungStatusDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GetAllAsync] 오류: {ex.Message}");
                return new List<BukyoungStatusDto>();
            }
        }

        // 특정 환자의 복약 여부 조회
        public async Task<List<BukyoungStatusDto>> GetByPatientIdAsync(int patientId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<BukyoungStatusDto>>($"{_baseUrl}/patient/{patientId}")
                       ?? new List<BukyoungStatusDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GetByPatientIdAsync] 오류: {ex.Message}");
                return new List<BukyoungStatusDto>();
            }
        }
    }
}
