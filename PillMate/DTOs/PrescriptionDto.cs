using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PillMate.DTO
{
    public class PrescriptionRecordDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string PharmacistName { get; set; }
        public string Note { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<PrescriptionItemDto> Items { get; set; } = new();
    }

    public class PrescriptionItemDto
    {
        public int PillId { get; set; }

        // 서버 JSON의 "yank_Name"을 PillName으로 매핑
        [JsonPropertyName("yank_Name")]
        public string PillName { get; set; }

        public int Quantity { get; set; }
    }
}
