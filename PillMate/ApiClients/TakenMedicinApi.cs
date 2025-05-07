using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using PillMate.DTO;
using PillMate.Services;

namespace PillMate.Client.ApiClients
{
    public class TakenMedicineAPI : ApiService
    {
        public TakenMedicineAPI() : base("TakenMedicine") { }

        // 복약 정보 등록
        public async Task<bool> CreateTakenMedicineAsync(TakenMedicineDto dto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(_baseUrl, dto);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CreateTakenMedicineAsync] 오류: {ex.Message}");
                return false;
            }
        }

        // 복약 정보 수정
        //public async Task<bool> UpdateTakenMedicineAsync(int id, TakenMedicineDto dto)
        //{
        //    try
        //    {
        //        var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/{id}", dto);
        //        return response.IsSuccessStatusCode;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"[UpdateTakenMedicineAsync] 오류: {ex.Message}");
        //        return false;
        //    }
        //}

        // 복약 정보 삭제
        public async Task<bool> DeleteTakenMedicineAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DeleteTakenMedicineAsync] 오류: {ex.Message}");
                return false;
            }
        }

        // 복약 정보 목록 불러오기
        public async Task<List<TakenMedicineDto>> GetTakenMedicinesAsync(int patientId)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<TakenMedicineDto>>($"{_baseUrl}/patient/{patientId}");
                return response ?? new List<TakenMedicineDto>();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GetTakenMedicinesByPatientIdAsync] 오류: {ex.Message}");
                return new List<TakenMedicineDto>();
            }
        }


        // alias 역할
        public async Task<List<TakenMedicineDto>> GetAllAsync(int patientId) => await GetTakenMedicinesAsync(patientId);

    }
}
