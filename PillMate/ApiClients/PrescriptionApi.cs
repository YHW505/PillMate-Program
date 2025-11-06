using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using PillMate.DTO;
using PillMate.Services;

namespace PillMate.ApiClients
{
    public class PrescriptionApi : ApiService
    {
        public PrescriptionApi() : base("PrescriptionRecords") { }

        // ✅ 환자별 복약 이력 조회
        public async Task<List<PrescriptionRecordDto>> GetPrescriptionsAsync(int patientId)
        {
            var result = await _httpClient.GetFromJsonAsync<List<PrescriptionRecordDto>>($"{_baseUrl}/patient/{patientId}");
            return result ?? new List<PrescriptionRecordDto>();
        }

        // ✅ 특정 이력 재출고 (추후 StockTransaction 연동 예정)
        public async Task<bool> ReorderAsync(int recordId)
        {
            var response = await _httpClient.PostAsync($"{_baseUrl}/{recordId}/reorder", null);
            return response.IsSuccessStatusCode;
        }
        // ✅ 복약이력 신규 등록
        public async Task<bool> CreatePrescriptionAsync(CreatePrescriptionRecordDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync(_baseUrl, dto);
            return response.IsSuccessStatusCode;
        }
    }
}
