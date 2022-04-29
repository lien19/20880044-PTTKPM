using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entities;
using Services;

namespace PTTKPM.Pages
{
    public class MH_DangKy_SoGiaoThongModel : PageModel
    {
        [BindProperty] public string email { get; set; }
        [BindProperty] public string password { get; set; }
        [BindProperty] public string confirmpassword { get; set; }
        private string PhanLoai { get; set; }
        public DateTime thoigian { get; set; }
        private int CongTyTDNId { get; set; }
        private int QuanTriHeThong { get; set; }


        //--biến
        [BindProperty] public string chuoi { get; set; }

        private XuLy_NguoiDung XuLy { get; set; }
        //------------------------------------------
        public MH_DangKy_SoGiaoThongModel() : base()
        {
            XuLy = new XuLy_NguoiDung();
        }

        public void OnGet()
        {

        }
        public void OnPost()
        {
            this.PhanLoai       = "SoGiaoThong";
            this.thoigian       = DateTime.Now;
            this.QuanTriHeThong = 0;

            if (this.password == this.confirmpassword)
            {
                NguoiDung item = new NguoiDung(email, password, PhanLoai, thoigian, CongTyTDNId, QuanTriHeThong);
                if (!XuLy.daTonTai(item))
                {
                    var x = XuLy.Them(item);
                    if (x > 0) 
                    { 
                        chuoi = "Them thanh cong"; 
                        Response.Redirect("MH_DangNhap_SoGiaoThong"); 
                    }
                    else chuoi = "Thêm KHÔNG thành công";
                }
                else chuoi = "Email này đã tồn tại.";
            }
            else chuoi = "Password không giống";
        }
    }
}
