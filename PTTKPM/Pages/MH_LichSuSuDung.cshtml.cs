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
    public class MH_LichSuSuDungModel : PageModel
    {
        [BindProperty] public string keyword { get; set; }
        //form: create
        [BindProperty] public int VeThangId { get; set; }
        [BindProperty] public DateTime NgaySuDung { get; set; }

        //biến
        [BindProperty(SupportsGet = true)] public int Id { get; set; }
        public string chuoi { get; set; }
        public string email_session { get; set; }
        public string PhanLoai_session { get; set; }
        public string CongTyTDNId_session { get; set; }
        public string QuanTriHeThong_session { get; set; }
        //danh sách
        public List<LichSuSuDung> danhsach { get; set; }
        public List<VeThang> DS_VeThang { get; set; }

        //xử lý
        private XuLy_LichSuSuDung XuLy { get; set; }
        private XuLy_VeThang XL_VeThang { get; set; }

        public MH_LichSuSuDungModel() : base()
        {
            XuLy = new XuLy_LichSuSuDung();
            XL_VeThang = new XuLy_VeThang();
        }
        public void OnGet()
        {
            email_session          = HttpContext.Session.GetString("email");
            PhanLoai_session       = HttpContext.Session.GetString("PhanLoai");
            CongTyTDNId_session    = HttpContext.Session.GetString("CongTyTDNId"); //query bảng theo mã số công ty
            QuanTriHeThong_session = HttpContext.Session.GetString("QuanTriHeThong");

            if (email_session == null || PhanLoai_session != "CongTyTDN" || string.IsNullOrEmpty(CongTyTDNId_session))
                Response.Redirect("/Index");
            //***********************************************
            if (Id == 0)
            {
                danhsach = XuLy.LayDS_CoDieuKien(CongTyTDNId_session);
                DS_VeThang = XL_VeThang.LayDS_CoDieuKien(CongTyTDNId_session);
            }
            else
            {
                danhsach = XuLy.LayDS_CoDieuKien(CongTyTDNId_session);
                DS_VeThang = XL_VeThang.LayDS_CoDieuKien(CongTyTDNId_session);

                //***********************************************
                LichSuSuDung item = XuLy.Doc(Id, CongTyTDNId_session);
                if (item != null)
                {
                    VeThangId = item.VeThangId;
                    NgaySuDung = item.NgaySuDung;
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

            if (!string.IsNullOrEmpty(CongTyTDNId_session))
            {
                danhsach = XuLy.TimKiem(keyword, CongTyTDNId_session);
                DS_VeThang = XL_VeThang.LayDS_CoDieuKien(CongTyTDNId_session);
            }
                
        }
        public void OnPostCreate()
        {
            LichSuSuDung item = new LichSuSuDung(VeThangId, NgaySuDung);
            if (XuLy.daTonTai(item))
                chuoi = "Mã này đã tồn tại. Bấm vào đây để quay trở lại.";
            else
            {
                int result = XuLy.Them(item);
                if (result > 0)
                    Response.Redirect("/MH_LichSuSuDung");
                else chuoi = "Không thêm được. Bấm vào đây để quay trở lại.";
            }
        }
        public void OnPostUpdate()
        {
            LichSuSuDung item = new LichSuSuDung(Id, VeThangId, NgaySuDung);
            XuLy.Capnhat(item);
            chuoi = "Da luu thanh cong";
            Response.Redirect("/MH_LichSuSuDung");
        }
        public void OnPostDelete()
        {
            XuLy.Xoa(Id);
            chuoi = "Da xoa thanh cong";
            Response.Redirect("/MH_LichSuSuDung");
        }



    }
}