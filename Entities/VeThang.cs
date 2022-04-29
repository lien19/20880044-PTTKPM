using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class VeThang
    {
        public int Id { get; set; }
        public int VeId { get; set; }
        public DateTime NgayHetHan { get; set; }

        public VeThang()
        {
        }
        public VeThang(int id, int veId, DateTime ngayHetHan) //lấy DS
        {
            this.Id = id;
            this.VeId = veId;
            this.NgayHetHan = ngayHetHan;
        }
        public VeThang(int veId, DateTime ngayHetHan)  //Thêm
        {
            this.VeId = veId;
            this.NgayHetHan = ngayHetHan;
        }

    }
}
