using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using PillMate.DTO;
using PillMate.Services;

namespace PillMate.Client.ApiClients
{
    public class StockTransactionApi : ApiService
    {
        public StockTransactionApi() : base("StockTransactions") { }

        // ✅ 전체 거래 내역 조회
        public async Task<List<StockTransactionDto>> GetAllAsync()
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<StockTransactionDto>>(_baseUrl);
                return result ?? new List<StockTransactionDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[StockTransactionApi.GetAllAsync] 오류: {ex.Message}");
                return new List<StockTransactionDto>();
            }
        }

        // ✅ 단일 거래 등록 (출고)
        public async Task<bool> CreateAsync(CreateStockTransactionDto dto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(_baseUrl, dto);
                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"[StockTransactionApi.CreateAsync] 실패: {content}");
                }
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[StockTransactionApi.CreateAsync] 오류: {ex.Message}");
                return false;
            }
        }

        // ✅ 거래 삭제
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[StockTransactionApi.DeleteAsync] 오류: {ex.Message}");
                return false;
            }
        }
    }
}
