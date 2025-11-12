namespace PillMate.DTO
{
    public class PatientDto
    {
        public int? Id { get; set; } 
        public int No { get; set; }  // UI 전용 순번
        public string Hwanja_Name { get; set; }
        public string Hwanja_Gender { get; set; }
        public string Hwanja_No { get; set; }
        public string Hwanja_Room { get; set; }
        public string Hwanja_PhoneNumber { get; set; }
        public string Bohoja_Name { get; set; }
        public string Bohoja_PhoneNumber { get; set; }
        public int Hwanja_Age { get; set; }
    }

    public class CreatePatientDto
    {
        public string Hwanja_Name { get; set; }
        public string Hwanja_Gender { get; set; }
        public string Hwanja_No { get; set; }
        public string Hwanja_Room { get; set; }
        public string Hwanja_PhoneNumber { get; set; }
        public string Bohoja_Name { get; set; }
        public string Bohoja_PhoneNumber { get; set; }
        public int Hwanja_Age { get; set; }

    }

    public class UpdatePatientDto : PatientDto
    {
        // 이곳에서 Id를 사용
    }

    // 환자 삭제용 DTO
    public class DeletePatientDto
    {
        public int Id { get; set; }  // 환자의 Id
    }
}
