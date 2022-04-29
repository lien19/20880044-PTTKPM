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
    public class MH_TuyenTauModel : PageModel
    {
        [BindProperty] public string keyword { get; set; }
        //form: create
        [BindProperty] public string MaSoTuyenTau { get; set; }
        [BindProperty] public string TenTuyenTau { get; set; }
        [BindProperty] public double GiaVeHienHanh { get; set; }
        [BindProperty] public string GioBatDau { get; set; }
        [BindProperty] public string GioKetThuc { get; set; }
        [BindProperty] public double ThoiGianCho2Chuyen { get; set; }
        [BindProperty] public string TinhTrang { get; set; }
        [BindProperty] public int GaBatDauId { get; set; }
        [BindProperty] public int GaKetThucId { get; set; }
        [BindProperty] public int CongTyTDNId { get; set; }
        //-----biến
        [BindProperty(SupportsGet = true)] public int Id { get; set; }
        public string chuoi { get; set; }
        public string email_session { get; set; }
        public string PhanLoai_session { get; set; }
        public string CongTyTDNId_session { get; set; }
        public string QuanTriHeThong_session { get; set; }

        //-----danh sách
        public List<TuyenTau> danhsach { get; set; }
        public List<Ga> DS_Ga { get; set; }
        public List<CongTyTauDienNgam> DS_CongTyTDN { get; set; }
        //------xử lý
        private XuLy_TuyenTau XuLy { get; set; }
        private XuLy_Ga XL_Ga { get; set; }
        public MH_TuyenTauModel() : base()
        {
            XuLy         = new XuLy_TuyenTau();
            XL_Ga        = new XuLy_Ga();
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
                CongTyTDNId = int.Parse(CongTyTDNId_session);
                DS_Ga = XL_Ga.LayDS();
            }
            else
            {
                danhsach = XuLy.LayDS_CoDieuKien(CongTyTDNId_session);
                CongTyTDNId = int.Parse(CongTyTDNId_session);
                DS_Ga = XL_Ga.LayDS();
                
                //***********************************************
                TuyenTau item = XuLy.Doc(Id, CongTyTDNId_session);
                if (item != null)
                {
                    MaSoTuyenTau = item.MaSoTuyenTau;
                    TenTuyenTau = item.TenTuyenTau;
                    GiaVeHienHanh = item.GiaVeHienHanh;
                    GioBatDau = item.GioBatDau;
                    GioKetThuc = item.GioKetThuc;
                    ThoiGianCho2Chuyen = item.ThoiGianCho2Chuyen;
                    TinhTrang = item.TinhTrang;
                    GaBatDauId = item.GaBatDauId;
                    GaKetThucId = item.GaKetThucId;
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
                danhsach = XuLy.TimKiem(CongTyTDNId_session, keyword);
                CongTyTDNId = int.Parse(CongTyTDNId_session);
            }
            DS_Ga = XL_Ga.LayDS();           //nếu location.href có thêm /search thì khi bấm nút thêm mới, DS_Ga không lấy lên đc => khi post search phải lấy lại DS

        }
        public void OnPostCreate()
        {
            TuyenTau item = new TuyenTau(MaSoTuyenTau, TenTuyenTau, GiaVeHienHanh, GioBatDau, GioKetThuc, ThoiGianCho2Chuyen, TinhTrang, GaBatDauId, GaKetThucId, CongTyTDNId);
            if (XuLy.daTonTai(item))
                chuoi = "Mã này đã tồn tại. Bấm vào đây để quay trở lại.";
            else
            {
                int result = XuLy.Them(item);
                if (result > 0)
                    Response.Redirect("/MH_TuyenTau");
                else chuoi = "Không thêm được. Bấm vào đây để quay trở lại.";
            }
        }
        public void OnPostUpdate()
        {
            TuyenTau item = new TuyenTau(Id, MaSoTuyenTau, TenTuyenTau, GiaVeHienHanh, GioBatDau, GioKetThuc, ThoiGianCho2Chuyen, TinhTrang, GaBatDauId, GaKetThucId, CongTyTDNId);
            XuLy.Capnhat(item);
            chuoi = "Da luu thanh cong";
            Response.Redirect("/MH_TuyenTau");
        }
        public void OnPostDelete()
        {
            if (XuLy.daDuocDung(Id))
                chuoi = "Mã này đã được sử dụng. Bấm vào đây để quay trở lại.";
            else
            {
                XuLy.Xoa(Id);
                chuoi = "Da xoa thanh cong";
                Response.Redirect("/MH_TuyenTau");
            }
                
        }


    }
}
