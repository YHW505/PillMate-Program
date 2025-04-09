using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillMate.DTOs
{
    public class PatientDto
    {
        public int Id { get; set; }
        public string Hwanja_Name { get; set; }
        public string Hwanja_Gender { get; set; }
        public string Hwanja_No { get; set; }
        public string Hwanja_Room { get; set; }
        public string Hwanja_PhoneNumber { get; set; }
        public string Bohoja_Name { get; set; }
        public string Bohoja_PhoneNumber { get; set; }
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
    }

    public class UpdatePatientDto : CreatePatientDto
    {
        public int Id { get; set; }
    }

    public class DeletePatientDto
    {
        public int Id { get; set; }
    }
}
