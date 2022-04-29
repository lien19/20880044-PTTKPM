using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TuyenTau
    {
        public int Id { get; set; }
        public string MaSoTuyenTau { get; set; }
        public string TenTuyenTau { get; set; }
        public double GiaVeHienHanh { get; set; }
        public string GioBatDau { get; set; }
        public string GioKetThuc { get; set; }
        public double ThoiGianCho2Chuyen { get; set; }
        public string TinhTrang { get; set; }
        public int GaBatDauId { get; set; }
        public int GaKetThucId { get; set; }
        public int CongTyTDNId { get; set; }

        public TuyenTau()
        {

        }
        public TuyenTau(int id, string maSoTuyenTau, string tenTuyenTau, double giaVeHienHanh, string gioBatDau, string gioKetThuc, double thoiGianCho2Chuyen, string tinhTrang, int gaBatDauId, int gaKetThucId, int congTyTDNId) //lấy DS
        {
            this.Id = id;
            this.MaSoTuyenTau = maSoTuyenTau;
            this.TenTuyenTau = tenTuyenTau;
            this.GiaVeHienHanh = giaVeHienHanh;
            this.GioBatDau = gioBatDau;
            this.GioKetThuc = gioKetThuc;
            this.ThoiGianCho2Chuyen = thoiGianCho2Chuyen;
            this.TinhTrang = tinhTrang;
            //this.MaSoGaTrungGian = maSoGaTrungGian;
            this.GaBatDauId = gaBatDauId;
            this.GaKetThucId = gaKetThucId;
            this.CongTyTDNId = congTyTDNId;
        }
        public TuyenTau(string maSoTuyenTau, string tenTuyenTau, double giaVeHienHanh, string gioBatDau, string gioKetThuc, double thoiGianCho2Chuyen, string tinhTrang, int gaBatDauId, int gaKetThucId, int congTyTDNId) //thêm
        {
            this.MaSoTuyenTau = maSoTuyenTau;
            this.TenTuyenTau = tenTuyenTau;
            this.GiaVeHienHanh = giaVeHienHanh;
            this.GioBatDau = gioBatDau;
            this.GioKetThuc = gioKetThuc;
            this.ThoiGianCho2Chuyen = thoiGianCho2Chuyen;
            this.TinhTrang = tinhTrang;
            //this.MaSoGaTrungGian = maSoGaTrungGian;
            this.GaBatDauId = gaBatDauId;
            this.GaKetThucId = gaKetThucId;
            this.CongTyTDNId = congTyTDNId;
        }



    }
}

