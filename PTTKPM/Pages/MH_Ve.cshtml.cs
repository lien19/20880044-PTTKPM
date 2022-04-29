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
    public class MH_VeModel : PageModel
    {
        [BindProperty] public string keyword { get; set; }
        //form: create
        [BindProperty] public string MaSoVe { get; set; }
        [BindProperty] public double Gia { get; set; }
        [BindProperty] public DateTime NgayBanVe { get; set; }
        [BindProperty] public int TuyenTauId { get; set; }
        [BindProperty] public int CongTyTDNId { get; set; }

        //biến
        [BindProperty(SupportsGet = true)] public int Id { get; set; }
        public string chuoi { get; set; }
        public string email_session { get; set; }
        public string PhanLoai_session { get; set; }
        public string CongTyTDNId_session { get; set; }
        public string QuanTriHeThong_session { get; set; }

        public List<Ve> danhsach { get; set; }
        public List<TuyenTau> DS_TuyenTau { get; set; }
        public List<CongTyTauDienNgam> DS_CongTyTDN { get; set; }
        //xử lý
        private XuLy_Ve XuLy { get; set; }
        private XuLy_TuyenTau XL_TuyenTau { get; set; }

        public MH_VeModel() : base()
        {
            XuLy         = new XuLy_Ve();
            XL_TuyenTau  = new XuLy_TuyenTau();
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
                DS_TuyenTau = XL_TuyenTau.LayDS_CoDieuKien(CongTyTDNId_session);
                CongTyTDNId = int.Parse(CongTyTDNId_session);

            }
            else
            {
                danhsach = XuLy.LayDS_CoDieuKien(CongTyTDNId_session);
                DS_TuyenTau = XL_TuyenTau.LayDS_CoDieuKien(CongTyTDNId_session);
                CongTyTDNId = int.Parse(CongTyTDNId_session);

                //***********************************************
                Ve item = XuLy.Doc(Id, CongTyTDNId_session);
                if (item != null)
                {
                    MaSoVe = item.MaSoVe;
                    Gia = item.Gia;
                    NgayBanVe = item.NgayBanVe;
                    TuyenTauId = item.TuyenTauId;
                    CongTyTDNId = item.CongTyTDNId;
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
                DS_TuyenTau = XL_TuyenTau.LayDS_CoDieuKien(CongTyTDNId_session);   //nếu location.href có thêm /search thì khi bấm nút thêm mới, DS_CongTyTDN không lấy lên đc => khi post search phải lấy lại DS
                CongTyTDNId = int.Parse(CongTyTDNId_session);
            }
                
        }
        public void OnPostCreate()
        {
            Ve item = new Ve(MaSoVe, Gia, NgayBanVe, TuyenTauId, CongTyTDNId);
            if (XuLy.daTonTai(item))
                chuoi = "Mã này đã tồn tại. Bấm vào đây để quay trở lại.";
            else
            {
                int result = XuLy.Them(item);
                if (result > 0)
                    Response.Redirect("/MH_Ve");
                else chuoi = "Không thêm được. Bấm vào đây để quay trở lại.";
            }

        }
        public void OnPostUpdate()
        {
            Ve item = new Ve(Id, MaSoVe, Gia, NgayBanVe, TuyenTauId, CongTyTDNId);
            XuLy.Capnhat(item);
            chuoi = "Da luu thanh cong";
            Response.Redirect("/MH_Ve");
        }
        public void OnPostDelete()
        {
            if (XuLy.daDuocDung(Id))
                chuoi = "Mã này đã được sử dụng. Bấm vào đây để quay trở lại.";
            else
            {
                XuLy.Xoa(Id);
                chuoi = "Da xoa thanh cong";
                Response.Redirect("/MH_Ve");
            }
                
        }



    }
}
