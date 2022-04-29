using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class LichSuSuDung
    {
        public int Id { get; set; }
        public int VeThangId { get; set; }
        public DateTime NgaySuDung { get; set; }

        public LichSuSuDung()
        {
        }
        public LichSuSuDung(int id, int veThangId, DateTime NgaySuDung) //lấy DS
        {
            this.Id = id;
            this.VeThangId = veThangId;
            this.NgaySuDung = NgaySuDung;
        }
        public LichSuSuDung(int veThangId, DateTime NgaySuDung)  //Thêm
        {
            this.VeThangId = veThangId;
            this.NgaySuDung = NgaySuDung;
        }



    }
}
