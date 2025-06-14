using PillMate.DTOs;
using PillMate.Services;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System;

namespace PillMate.ApiClients
{
    public class DashboardApi : ApiService
    {
        public DashboardApi() : base("Dashboard") { }

        public async Task<DashboardDto?> GetSummaryAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<DashboardDto>(_baseUrl);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GetSummaryAsync] 오류: {ex.Message}");
                return null;
            }
        }

        public async Task<List<MedicationStatusDto>> GetMedicationsAsync()
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<MedicationStatusDto>>($"{_baseUrl}/medications");
                return result ?? new List<MedicationStatusDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GetMedicationsAsync] 오류: {ex.Message}");
                return new List<MedicationStatusDto>();
            }
        }
    }

    public class MedicationStatusDto
    {
        public string PatientName { get; set; } = string.Empty;
        public string PillName { get; set; } = string.Empty;
        public bool IsTaken { get; set; }
    }
}
