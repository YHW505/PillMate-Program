using System;

namespace PillMate.DTO
{
    public class TakenMedicineDto
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public int PillId { get; set; }

        public string Dosage { get; set; }

        public PillDto Pill { get; set; }

        // 주의: 아래는 QR 코드 등 다른 API에서 필요하지 않으면 생략 가능
        public PatientDto Patient { get; set; }
    }

    public class CreateTakenMedicineDto
    {
        public int PatientId { get; set; }

        public int PillId { get; set; }

        public string Dosage { get; set; }

        public PillDto Pill { get; set; }

        public PatientDto Patient { get; set; } // 필요 없다면 생략
    }

    public class UpdateTakenMedicineDto : CreateTakenMedicineDto
    {
        public int Id { get; set; }
    }

    public class DeleteTakenMedicineDto
    {
        public int Id { get; set; }
    }
}
