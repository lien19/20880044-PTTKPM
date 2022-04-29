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
    public class MH_VeThuongModel : PageModel
    {
        [BindProperty] public string keyword { get; set; }
        //form: create
        [BindProperty] public int VeId { get; set; }
        [BindProperty] public string TrangThaiSuDung { get; set; }
        [BindProperty] public DateTime ThoiDiemSuDung { get; set; }

        //biến
        [BindProperty(SupportsGet = true)] public int Id { get; set; }
        public string chuoi { get; set; }
        public string email_session { get; set; }
        public string PhanLoai_session { get; set; }
        public string CongTyTDNId_session { get; set; }
        public string QuanTriHeThong_session { get; set; }
        //danh sách
        public List<VeThuong> danhsach { get; set; }
        public List<Ve> DS_Ve { get; set; }

        //xử lý
        private XuLy_VeThuong XuLy { get; set; }
        private XuLy_Ve XL_Ve { get; set; }

        public MH_VeThuongModel() : base()
        {
            XuLy = new XuLy_VeThuong();
            XL_Ve = new XuLy_Ve();
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
                DS_Ve = XL_Ve.LayDS_ChuaDuocDung(CongTyTDNId_session);
                TrangThaiSuDung = "Đã bán";
            }
            else
            {
                danhsach = XuLy.LayDS_CoDieuKien(CongTyTDNId_session);
                DS_Ve = XL_Ve.LayDS_ChuaDuocDung(CongTyTDNId_session);

                VeThuong item = XuLy.Doc(Id, CongTyTDNId_session);
                if (item != null)
                {
                    VeId = item.VeId;
                    TrangThaiSuDung = item.TrangThaiSuDung;
                    ThoiDiemSuDung = item.ThoiDiemSuDung;
                }
                else chuoi = "Ma nay khong ton tai";

            }
        }
        public void OnPostSearch()
        {
            //Nếu url có thêm chữ search thì phải tạo lại những biến này để Thêm mới
            email_session          = HttpContext.Session.GetString("email");
            PhanLoai_session       = HttpContext.Session.GetString("PhanLoai");
            CongTyTDNId_session    = HttpContext.Session.GetString("CongTyTDNId"); //query bảng theo mã số công ty
            QuanTriHeThong_session = HttpContext.Session.GetString("QuanTriHeThong");

            if (!string.IsNullOrEmpty(CongTyTDNId_session))
            {
                danhsach = XuLy.TimKiem(keyword, CongTyTDNId_session);
                DS_Ve = XL_Ve.LayDS_ChuaDuocDung(CongTyTDNId_session);
            }                

        }
        public void OnPostCreate()
        {            
            VeThuong item = new VeThuong(VeId, TrangThaiSuDung, ThoiDiemSuDung);
            if (XuLy.daTonTai(item))
                chuoi = "Mã này đã tồn tại. Bấm vào đây để quay trở lại.";
            else if (XuLy.kiemTraNgay(item) == false)
                chuoi = "Ngày sử dụng phải sau ngày mua. Bấm vào đây để quay trở lại.";
            else
            {
                int result = XuLy.Them(item);
                if (result > 0)
                    Response.Redirect("/MH_VeThuong");
                else chuoi = "Không thêm được. Bấm vào đây để quay trở lại.";
            }
        }
        public void OnPostUpdate()
        {
            TrangThaiSuDung = "Đã bán";
            VeThuong item = new VeThuong(Id, VeId, TrangThaiSuDung, ThoiDiemSuDung);
            if (XuLy.kiemTraNgay(item) == false)
                chuoi = "Ngày sử dụng phải sau ngày mua. Bấm vào đây để quay trở lại.";
            else
            {
                XuLy.Capnhat(item);
                chuoi = "Da luu thanh cong"; Response.Redirect("/MH_VeThuong");
            }
        }
        public void OnPostDelete()
        {
            XuLy.Xoa(Id);
            chuoi = "Da xoa thanh cong";
            Response.Redirect("/MH_VeThuong");
        }



    }
}