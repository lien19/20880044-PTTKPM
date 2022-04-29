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
    public class MH_DangNhap_CongTyTDNModel : PageModel
    {
        [BindProperty] public string email { get; set; }
        [BindProperty] public string password { get; set; }
        public int CongTyTDNId { get; set; }
        private string PhanLoai { get; set; }
        private DateTime thoigian { get; set; }
        private int QuanTriHeThong { get; set; }

        //biến
        public string chuoi { get; set; }
        private string CongTyTDNId_DangNhap { get; set; }

        public List<CongTyTauDienNgam> DS_CongTyTDN { get; set; }
        private XuLy_NguoiDung XuLy { get; set; }
        private XuLy_CongTyTauDienNgam XL_CongTyTDN { get; set; }

        //------------------------------------------
        public MH_DangNhap_CongTyTDNModel() : base()
        {
            XuLy         = new XuLy_NguoiDung();
            XL_CongTyTDN = new XuLy_CongTyTauDienNgam();
        }
        public void OnGet()
        {
            DS_CongTyTDN = XL_CongTyTDN.LayDS();
        }
        public void OnPost()
        {
            PhanLoai            = "CongTyTDN";
            NguoiDung NguoiDung = new NguoiDung(email, password, PhanLoai, CongTyTDNId, QuanTriHeThong);
            var result          = XuLy.DangNhap(NguoiDung, PhanLoai);
            if (result!=null)
            {
                HttpContext.Session.SetString("email", result.Email);
                HttpContext.Session.SetString("PhanLoai", result.PhanLoai);
                HttpContext.Session.SetString("CongTyTDNId", result.CongTyTDNId.ToString());
                HttpContext.Session.SetString("QuanTriHeThong", result.QuanTriHeThong.ToString());

                Response.Redirect("/Index");
            }
            else
                chuoi = "Đăng nhập không thành công. Kiểm tra lại email hoặc password";
        }



    }
}
