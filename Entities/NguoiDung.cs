using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class NguoiDung
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhanLoai { get; set; } //Sở giao thông hay Công ty tàu điện ngầm
        public DateTime ThoiGian { get; set; }
        public int CongTyTDNId { get; set; } //null nếu là Sở giao thông, có giá trị nếu là Công ty tàu điện ngầm
        public int QuanTriHeThong { get; set; } //số 1 là đúng, 0 là sai

        public NguoiDung()
        {

        }
        public NguoiDung(int id, string email, string password, string phanLoai, DateTime thoiGian, int congTyTDNId, int quanTriHeThong) // fn LayDS, CongTyTDN
        {
            this.Id = id;
            this.Email = email;
            this.Password = password;
            this.PhanLoai = phanLoai;
            this.ThoiGian = thoiGian;
            this.CongTyTDNId = congTyTDNId;
            this.QuanTriHeThong = quanTriHeThong;
        }
        public NguoiDung(string email, string password, string phanLoai, DateTime thoiGian, int congTyTDNId, int quanTriHeThong) // fn Them_NguoiDung, CongTyTDN
        {
            this.Email = email;
            this.Password = password;
            this.PhanLoai = phanLoai;
            this.ThoiGian = thoiGian;
            this.CongTyTDNId = congTyTDNId;
            this.QuanTriHeThong = quanTriHeThong;
        }
        public NguoiDung(string email, string password, string phanLoai, int congTyTDNId, int quanTriHeThong) //MH_DangNhap, CongTyTDN
        {
            this.Email = email;
            this.Password = password;
            this.PhanLoai = phanLoai;
            this.CongTyTDNId = congTyTDNId;
            this.QuanTriHeThong = quanTriHeThong;
        }


    }
}
