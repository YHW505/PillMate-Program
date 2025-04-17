using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using PillMate.DTO;
using PillMate.Services;

namespace PillMate.ApiClients
{
    public class PatientApi : ApiService
    {
        public PatientApi() : base("Patients") { }

        // 환자 등록 (Create)
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

        // 환자 수정 (Update)
        public async Task<bool> UpdateAsync(UpdatePatientDto dto)
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

        // 환자 삭제 (Delete)
        public async Task<bool> DeleteAsync(DeletePatientDto dto)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_baseUrl}/{dto.Id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DeleteAsync] 오류: {ex.Message}");
                return false;
            }
        }

        // 모든 환자 목록 불러오기
        public async Task<List<PatientDto>> GetAllAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<PatientDto>>(_baseUrl)
                    ?? new List<PatientDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GetAllAsync] 오류: {ex.Message}");
                return new List<PatientDto>();
            }
        }
    }
}
