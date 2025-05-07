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
        public PatientDto Patient { get; set; }
    }

    public class CreateTakenMedicineDto
    {
        public int PatientId { get; set; }
        public int PillId { get; set; }
        public string Dosage { get; set; }
        public PillDto Pill { get; set; }
        public PatientDto Patient { get; set; }
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
