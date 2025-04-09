using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillMate.DTO
{
    public class PillDto
    {
        public int Id { get; set; }
        public string Yank_Name { get; set; }
        public int Yank_Cnt { get; set; }
        public string Yank_Num { get; set; }
    }

    public class CreatePillDto
    {
        public string Yank_Name { get; set; }
        public int Yank_Cnt { get; set; }
        public string Yank_Num { get; set; }
    }

    public class UpdatePillDto : CreatePillDto
    {
        public int Id { get; set; }
    }

    public class DeletePillDto
    {
        public int Id { get; set; }
    }
}

