using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Ve
    {
        public int Id { get; set; }
        public string MaSoVe { get; set; }
        public double Gia { get; set; }
        public DateTime NgayBanVe { get; set; }
        public int TuyenTauId { get; set; }
        public int CongTyTDNId { get; set; }

        public Ve()
        {
        }
        public Ve(int id, string maSoVe, double gia, DateTime ngayBanVe, int tuyenTauId, int congTyTDNId) //lấy DS
        {
            this.Id = id;
            this.MaSoVe = maSoVe;
            this.Gia = gia;
            this.NgayBanVe = ngayBanVe;
            this.TuyenTauId = tuyenTauId;
            this.CongTyTDNId = congTyTDNId;
        }
        public Ve(string maSoVe, double gia, DateTime ngayBanVe, int tuyenTauId, int congTyTDNId)  //Thêm
        {
            this.MaSoVe = maSoVe;
            this.Gia = gia;
            this.NgayBanVe = ngayBanVe;
            this.TuyenTauId = tuyenTauId;
            this.CongTyTDNId = congTyTDNId;
        }



    }
}
