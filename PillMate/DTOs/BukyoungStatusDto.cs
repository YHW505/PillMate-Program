using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillMate.DTO
{
    public class BukyoungStatusDto
    {
        public int Id { get; set; }
        public string Hwanja_No { get; set; }
        public string Hwanja_Name { get; set; }
        public bool Bukyoung_Chk { get; set; }
        public int PatientId { get; set; }
    }

    public class CreateBukyoungStatusDto
    {
        public string Hwanja_No { get; set; }
        public string Hwanja_Name { get; set; }
        public bool Bukyoung_Chk { get; set; }
        public int PatientId { get; set; }
    }

    public class UpdateBukyoungStatusDto : CreateBukyoungStatusDto
    {
        public int Id { get; set; }
    }

    public class DeleteBukyoungStatusDto
    {
        public int Id { get; set; }
    }
}

