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

        // 그리드 번호용(클라이언트에서 채움)
        public string Yank_Name { get; set; }        // 품명
        public string Yank_Num { get; set; }         // 약품 번호
        public int Yank_Cnt { get; set; }            // 수량
        public string Manufacturer { get; set; }     // 제조사
        public string Category { get; set; }         // 분류
        public DateTime? ExpirationDate { get; set; } // 유통기한 (없을 수도 있으니 Nullable 권장)
        public string Description { get; set; }      // 설명
        public string StorageLocation { get; set; }  // 보관 위치
    }

    public class CreatePillDto
    {
        public string Yank_Name { get; set; }
        public int Yank_Cnt { get; set; }
        public string Yank_Num { get; set; }
    }

    public class UpdatePillDto : PillDto
    {

    }

    public class DeletePillDto
    {
        public int Id { get; set; }
    }
}

