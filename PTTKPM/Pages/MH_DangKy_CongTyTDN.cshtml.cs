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
    public class MH_DangKy_CongTyTDNModel : PageModel
    {
        [BindProperty] public string email { get; set; }
        [BindProperty] public string password { get; set; }
        [BindProperty] public string confirmpassword { get; set; }
        [BindProperty] public int CongTyTDNId { get; set; }
        public string PhanLoai { get; set; }
        public DateTime thoigian { get; set; }
        private int QuanTriHeThong { get; set; }
        
        //biến
        [BindProperty] public string chuoi { get; set; }
        public List<CongTyTauDienNgam> DS_CongTyTDN { get; set; }

        private XuLy_NguoiDung XuLy { get; set; }
        private XuLy_CongTyTauDienNgam XL_CongTyTDN { get; set; }

        //------------------------------------------
        public MH_DangKy_CongTyTDNModel() : base()
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
            this.PhanLoai       = "CongTyTDN";
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
                        Response.Redirect("MH_DangNhap_CongTyTDN"); 
                    }
                    else
                    {
                        chuoi = "Thêm KHÔNG thành công";
                        DS_CongTyTDN = XL_CongTyTDN.LayDS();
                    }
                }
                else
                {
                    chuoi = "Email này đã tồn tại.";
                    DS_CongTyTDN = XL_CongTyTDN.LayDS();
                }
            }
            else
            {
                chuoi = "Password không giống";
                DS_CongTyTDN = XL_CongTyTDN.LayDS();
            }

        }
        



    }
}
