using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class VeThuong
    {
        public int Id { get; set; }
        public int VeId { get; set; }
        public string TrangThaiSuDung { get; set; }
        public DateTime ThoiDiemSuDung { get; set; }

        public VeThuong()
        {
        }
        public VeThuong(int id, int veId, string trangThaiSuDung, DateTime thoiDiemSuDung) //lấy DS
        {
            this.Id = id;
            this.VeId = veId;
            this.TrangThaiSuDung = trangThaiSuDung;
            this.ThoiDiemSuDung = thoiDiemSuDung;
        }
        public VeThuong(int veId, string trangThaiSuDung, DateTime thoiDiemSuDung)  //Thêm
        {
            this.VeId = veId;
            this.TrangThaiSuDung = trangThaiSuDung;
            this.ThoiDiemSuDung = thoiDiemSuDung;
        }

    }
}
