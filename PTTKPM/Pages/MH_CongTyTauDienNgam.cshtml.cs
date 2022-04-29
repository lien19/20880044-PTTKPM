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
    public class MH_CongTyTauDienNgamModel : PageModel
    {
        //form: search
        [BindProperty] public string keyword { get; set; }
        //form: create
        [BindProperty] public string MaSoCongTyTDN { get; set; }
        [BindProperty] public string TenCongTyTDN { get; set; }
        [BindProperty] public string DiaChiCongTyTDN { get; set; }
        [BindProperty] public string Website { get; set; }
        [BindProperty] public string SoDienThoai { get; set; }
        //biến
        [BindProperty(SupportsGet = true)] public int Id { get; set; }
        public string chuoi { get; set; }
        public string email_session { get; set; }
        public string PhanLoai_session { get; set; }
        public string CongTyTDNId_session { get; set; }
        public string QuanTriHeThong_session { get; set; }

        public List<CongTyTauDienNgam> danhsach { get; set; }
        private XuLy_CongTyTauDienNgam XuLy { get; set; }
        //------------------------------------------
        public MH_CongTyTauDienNgamModel() : base()
        {
            XuLy = new XuLy_CongTyTauDienNgam();               
        }

        public void OnGet()
        {
            email_session          = HttpContext.Session.GetString("email");
            PhanLoai_session       = HttpContext.Session.GetString("PhanLoai");
            CongTyTDNId_session    = HttpContext.Session.GetString("CongTyTDNId"); //query bảng theo mã số công ty
            QuanTriHeThong_session = HttpContext.Session.GetString("QuanTriHeThong");

            if (email_session == null || PhanLoai_session != "SoGiaoThong")
                Response.Redirect("/Index");
            //***********************************************
            if (Id == 0)
            {
                danhsach = XuLy.LayDS();
            }
            else
            {
                danhsach = XuLy.LayDS();

                CongTyTauDienNgam item = XuLy.Doc(Id);
                if (item != null)
                {
                    MaSoCongTyTDN = item.MaSoCongTyTDN;
                    TenCongTyTDN = item.TenCongTyTDN;
                    DiaChiCongTyTDN = item.DiaChiCongTyTDN;
                    Website = item.Website;
                    SoDienThoai = item.SoDienThoai;
                }
                else chuoi = "Ma nay khong ton tai";
            }                
        }
        public void OnPostSearch()
        {
            email_session          = HttpContext.Session.GetString("email");
            PhanLoai_session       = HttpContext.Session.GetString("PhanLoai");
            CongTyTDNId_session    = HttpContext.Session.GetString("CongTyTDNId"); //query bảng theo mã số công ty
            QuanTriHeThong_session = HttpContext.Session.GetString("QuanTriHeThong");

            danhsach = XuLy.TimKiem(keyword);
        }
        public void OnPostCreate()
        {
            CongTyTauDienNgam item = new CongTyTauDienNgam(MaSoCongTyTDN, TenCongTyTDN, DiaChiCongTyTDN, Website, SoDienThoai);
            if (XuLy.daTonTai(item))
                chuoi = "Mã này đã tồn tại. Bấm vào đây để quay trở lại.";
            else 
            {
                int result = XuLy.Them(item);
                if (result > 0)
                    Response.Redirect("/MH_CongTyTauDienNgam");
                else chuoi = "Không thêm được. Bấm vào đây để quay trở lại.";
            }
            
        }
        public void OnPostUpdate()
        {
            CongTyTauDienNgam item = new CongTyTauDienNgam(Id, MaSoCongTyTDN, TenCongTyTDN, DiaChiCongTyTDN, Website, SoDienThoai);
            XuLy.Capnhat(item);
            chuoi = "Da luu thanh cong";
            danhsach = XuLy.LayDS();
            Response.Redirect("/MH_CongTyTauDienNgam");
        }
        public void OnPostDelete()
        {
            if (XuLy.daDuocDung(Id))
                chuoi = "Mã này đã được sử dụng. Bấm vào đây để quay trở lại.";
            else
            {
                XuLy.Xoa(Id);
                chuoi = "Da xoa thanh cong";
                danhsach = XuLy.LayDS();
                Response.Redirect("/MH_CongTyTauDienNgam");
            }
                
        }




    }
}
