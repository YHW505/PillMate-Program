using System;

namespace PillMate.DTO
{
    // 📦 서버에서 응답받을 DTO (읽기용)
    public class StockTransactionDto
    {
        public int Id { get; set; }
        public int PillId { get; set; }
        public string PillName { get; set; } = string.Empty; // 서버에서 매핑해주는 용도
        public int Quantity { get; set; }
        public DateTime ReleasedAt { get; set; }
        public string PharmacistName { get; set; } = string.Empty;
        public string? Note { get; set; }
    }

    // 🧾 서버로 전송할 DTO (등록용)
    public class CreateStockTransactionDto
    {
        public int PillId { get; set; }
        public int Quantity { get; set; }
        public string PharmacistName { get; set; } = string.Empty;
        public string? Note { get; set; }
    }
}
