using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Ga
    {
        public int Id { get; set; }
        public string MaSoGa { get; set; }
        public string TenGa { get; set; }
        public string ViTri { get; set; }
        public string TinhTrangHoatDong { get; set; }
        public string BanDo { get; set; }
        public Ga()
        {

        }
        public Ga(int id, string maSoGa, string tenGa, string viTri, string tinhTrangHoatDong, string banDo) //lấy DS
        {
            this.Id = id;
            this.MaSoGa = maSoGa;
            this.TenGa = tenGa;
            this.ViTri = viTri;
            this.TinhTrangHoatDong = tinhTrangHoatDong;
            this.BanDo = banDo;
        }
        public Ga(string maSoGa, string tenGa, string viTri, string tinhTrangHoatDong, string banDo) //thêm
        {
            this.MaSoGa = maSoGa;
            this.TenGa = tenGa;
            this.ViTri = viTri;
            this.TinhTrangHoatDong = tinhTrangHoatDong;
            this.BanDo = banDo;
        }



    }
}
