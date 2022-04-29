using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;

namespace PTTKPM.Pages
{
    public class MH_DangNhap_SoGiaoThongModel : PageModel
    {
        [BindProperty] public string email { get; set; }
        [BindProperty] public string password { get; set; }
        public string PhanLoai { get; set; }
        public DateTime thoigian { get; set; }
        private int CongTyTDNId { get; set; }
        private int QuanTriHeThong { get; set; }


        //---biến
        public string chuoi { get; set; }
        public string chuoi1 { get; set; }
        private string CongTyTDNId_DangNhap { get; set; }

        private XuLy_NguoiDung XuLy { get; set; }
        //------------------------------------------
        public MH_DangNhap_SoGiaoThongModel() : base()
        {
            XuLy = new XuLy_NguoiDung();
        }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            PhanLoai = "SoGiaoThong";
            NguoiDung NguoiDung = new NguoiDung(email, password, PhanLoai, CongTyTDNId, QuanTriHeThong);
            var result = XuLy.DangNhap(NguoiDung, PhanLoai);  //trả về người dùng
            if (result != null)
            {
                HttpContext.Session.SetString("email", result.Email);
                HttpContext.Session.SetString("PhanLoai", result.PhanLoai);
                HttpContext.Session.SetString("QuanTriHeThong", result.QuanTriHeThong.ToString());

                Response.Redirect("/Index");
            }
            else
                chuoi = "Đăng nhập không thành công. Kiểm tra lại email hoặc password";
        }



    }
}
