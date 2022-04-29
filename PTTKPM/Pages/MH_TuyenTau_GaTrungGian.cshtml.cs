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
    public class MH_TuyenTau_GaTrungGianModel : PageModel
    {
        //form: search
        [BindProperty] public string keyword { get; set; }
        //form: create
        [BindProperty] public int TuyenTauId { get; set; }
        [BindProperty] public int GaId { get; set; }
        [BindProperty] public int ThoiGianDung { get; set; }

        //biến - 
        [BindProperty(SupportsGet = true)] public int Id { get; set; }
        public string chuoi { get; set; }
        public string email_session { get; set; }
        public string PhanLoai_session { get; set; }
        public string CongTyTDNId_session { get; set; }
        public string QuanTriHeThong_session { get; set; }

        //danh sách
        public List<TuyenTau_GaTrungGian> danhsach { get; set; }
        public List<TuyenTau> DS_TuyenTau { get; set; }
        public List<Ga> DS_Ga { get; set; }
        //xử lý
        private XuLy_TuyenTau_GaTrungGian XuLy { get; set; }
        private XuLy_TuyenTau XL_TuyenTau { get; set; }
        private XuLy_Ga XL_Ga { get; set; }
        //------------------------------------------
        public MH_TuyenTau_GaTrungGianModel() : base()
        {
            XuLy        = new XuLy_TuyenTau_GaTrungGian();
            XL_TuyenTau = new XuLy_TuyenTau();
            XL_Ga       = new XuLy_Ga();
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
                DS_Ga = XL_Ga.LayDS();
            }
            else
            {
                danhsach = XuLy.LayDS_CoDieuKien(CongTyTDNId_session);
                DS_TuyenTau = XL_TuyenTau.LayDS_CoDieuKien(CongTyTDNId_session);

                DS_Ga = XL_Ga.LayDS();

                //***********************************************
                TuyenTau_GaTrungGian item = XuLy.Doc(Id, CongTyTDNId_session);
                if (item != null)
                {
                    TuyenTauId = item.TuyenTauId;
                    GaId = item.GaId;
                    ThoiGianDung = item.ThoiGianDung;
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
                danhsach = XuLy.TimKiem(CongTyTDNId_session, keyword);
                DS_TuyenTau = XL_TuyenTau.LayDS_CoDieuKien(CongTyTDNId_session);   //nếu location.href có thêm /search thì khi bấm nút thêm mới, DS_CongTyTDN không lấy lên đc => khi post search phải lấy lại DS
            }                
            DS_Ga = XL_Ga.LayDS();   //nếu location.href có thêm /search thì khi bấm nút thêm mới, DS_CongTyTDN không lấy lên đc => khi post search phải lấy lại DS
        }
        public void OnPostCreate()
        {
            TuyenTau_GaTrungGian item = new TuyenTau_GaTrungGian(TuyenTauId, GaId, ThoiGianDung);
            if (XuLy.daTonTai(item))
                chuoi = "Mã này đã tồn tại. Bấm vào đây để quay trở lại.";
            else
            {
                int result = XuLy.Them(item);
                if (result > 0)
                    Response.Redirect("/MH_TuyenTau_GaTrungGian");
                else chuoi = "Không thêm được. Bấm vào đây để quay trở lại.";
            }
        }
        public void OnPostUpdate()
        {
            TuyenTau_GaTrungGian item = new TuyenTau_GaTrungGian(Id, TuyenTauId, GaId, ThoiGianDung);
            XuLy.Capnhat(item);
            chuoi = "Da luu thanh cong";
            Response.Redirect("/MH_TuyenTau_GaTrungGian");
        }
        public void OnPostDelete()
        {
            XuLy.Xoa(Id);
            chuoi = "Da xoa thanh cong";
            Response.Redirect("/MH_TuyenTau_GaTrungGian");
        }




    }
}

