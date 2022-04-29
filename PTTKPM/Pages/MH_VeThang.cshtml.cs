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
    public class MH_VeThangModel : PageModel
    {
        [BindProperty] public string keyword { get; set; }
        //form: create
        [BindProperty] public int VeId { get; set; }
        [BindProperty] public DateTime NgayHetHan { get; set; }

        //biến
        [BindProperty(SupportsGet = true)] public int Id { get; set; }
        public string chuoi { get; set; }
        public string email_session { get; set; }
        public string PhanLoai_session { get; set; }
        public string CongTyTDNId_session { get; set; }
        public string QuanTriHeThong_session { get; set; }
        //danh sách
        public List<VeThang> danhsach { get; set; }
        public List<Ve> DS_Ve { get; set; }
        //xử lý
        private XuLy_VeThang XuLy { get; set; }
        private XuLy_Ve XL_Ve { get; set; }

        public MH_VeThangModel() : base()
        {
            XuLy = new XuLy_VeThang();
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
            }
            else
            {
                danhsach = XuLy.LayDS_CoDieuKien(CongTyTDNId_session);
                DS_Ve = XL_Ve.LayDS_ChuaDuocDung(CongTyTDNId_session);

                VeThang item = XuLy.Doc(Id, CongTyTDNId_session);
                if (item != null)
                {
                    VeId = item.VeId;
                    NgayHetHan = item.NgayHetHan;
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
                DS_Ve = XL_Ve.LayDS_ChuaDuocDung(CongTyTDNId_session);
            }
                
        }
        public void OnPostCreate()
        {
            VeThang item       = new VeThang(VeId, NgayHetHan);
            var tinhNgayHetHan = XuLy.tinhNgayHetHan(item);
            if (XuLy.daTonTai(item))
                chuoi = "Mã này đã tồn tại. Bấm vào đây để quay trở lại.";
            else if (tinhNgayHetHan == null)
                chuoi = "Cần tạo Mã số Vé mới trước khi tạo mới Vé tháng. Bấm vào đây để quay trở lại.";
            else
            {
                NgayHetHan = (DateTime)tinhNgayHetHan;
                item       = new VeThang(VeId, NgayHetHan);

                int result = XuLy.Them(item);
                if (result > 0)
                    Response.Redirect("/MH_VeThang");
                else chuoi = "Không thêm được. Bấm vào đây để quay trở lại.";

            }
        }
        public void OnPostUpdate()
        {
            VeThang item = new VeThang(Id, VeId, NgayHetHan);
            var tinhNgayHetHan = XuLy.tinhNgayHetHan(item);
            if (tinhNgayHetHan == null)
                chuoi = "Cần tạo Mã số Vé mới trước khi thêm mới Vé tháng. Bấm vào đây để quay trở lại.";
            //else if (XuLy.daDuocDung(Id))
            //    chuoi = "Mã này đã được sử dụng nên không thể thay đổi được. Bấm vào đây để quay trở lại.";
            else
            {
                NgayHetHan = (DateTime)tinhNgayHetHan;
                item = new VeThang(VeId, NgayHetHan);
                XuLy.Capnhat(item);
                Response.Redirect("/MH_VeThang");
            }                
        }
        public void OnPostDelete()
        {
            if (XuLy.daDuocDung(Id))
                chuoi = "Mã này đã được sử dụng. Bấm vào đây để quay trở lại.";
            else
            {
                XuLy.Xoa(Id);
                chuoi = "Da xoa thanh cong";
                Response.Redirect("/MH_VeThang");
            }
            
        }



    }
}
