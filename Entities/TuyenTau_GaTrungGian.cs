using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TuyenTau_GaTrungGian
    {
        public int Id { get; set; }
        public int TuyenTauId { get; set; }
        public int GaId { get; set; }
        public int ThoiGianDung { get; set; }

        public TuyenTau_GaTrungGian()
        {
        }
        public TuyenTau_GaTrungGian(int id, int tuyenTauId, int gaId, int thoiGianDung) //lấy DS
        {
            this.Id = id;
            this.TuyenTauId = tuyenTauId;
            this.GaId = gaId;
            this.ThoiGianDung = thoiGianDung;
        }
        public TuyenTau_GaTrungGian(int tuyenTauId, int gaId, int thoiGianDung)  //Thêm
        {
            this.TuyenTauId = tuyenTauId;
            this.GaId = gaId;
            this.ThoiGianDung = thoiGianDung;
        }



    }
}
