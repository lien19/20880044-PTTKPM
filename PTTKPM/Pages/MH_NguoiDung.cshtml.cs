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
    public class MH_NguoiDungModel : PageModel
    {
        //form: search
        [BindProperty] public string keyword { get; set; }
        //form: create
        [BindProperty] public string Email { get; set; }
        [BindProperty] public string Password { get; set; }
        [BindProperty] public string PhanLoai { get; set; }
        [BindProperty] public DateTime ThoiGian { get; set; }
        [BindProperty] public int CongTyTDNId { get; set; }
        [BindProperty] public int QuanTriHeThong { get; set; }  //1 là admin, 0 là người dùng
        //biến
        [BindProperty(SupportsGet = true)] public int Id { get; set; }
        public string email_session { get; set; }
        public string PhanLoai_session { get; set; }
        public string CongTyTDNId_session { get; set; }        
        public string QuanTriHeThong_session { get; set; }        
        public string chuoi { get; set; }
        //Danh sách        
        public List<NguoiDung> danhsach { get; set; }
        public List<CongTyTauDienNgam> DS_CongTyTDN { get; set; }
        //Xử lý
        private XuLy_NguoiDung XuLy { get; set; }
        private XuLy_CongTyTauDienNgam XL_CongTyTDN { get; set; }
        //------------------------------------------
        public MH_NguoiDungModel() : base()
        {
            XuLy         = new XuLy_NguoiDung();
            XL_CongTyTDN = new XuLy_CongTyTauDienNgam();
        }

        public void OnGet()
        {
            email_session          = HttpContext.Session.GetString("email");
            PhanLoai_session       = HttpContext.Session.GetString("PhanLoai");
            CongTyTDNId_session    = HttpContext.Session.GetString("CongTyTDNId"); //query bảng theo mã số công ty
            QuanTriHeThong_session = HttpContext.Session.GetString("QuanTriHeThong");

            if (email_session == null || QuanTriHeThong_session != "1" || string.IsNullOrEmpty(PhanLoai_session))
                Response.Redirect("/Index");
            //***********************************************
            if (Id == 0)
            {
                danhsach = XuLy.LayDS_CoDieuKien(PhanLoai_session, CongTyTDNId_session);
                if(PhanLoai_session != "SoGiaoThong") CongTyTDNId = int.Parse(CongTyTDNId_session);
                DS_CongTyTDN = XL_CongTyTDN.LayDS();
            }
            else
            {
                danhsach = XuLy.LayDS_CoDieuKien(PhanLoai_session, CongTyTDNId_session);
                if (PhanLoai_session != "SoGiaoThong") CongTyTDNId = int.Parse(CongTyTDNId_session);
                DS_CongTyTDN = XL_CongTyTDN.LayDS();

                NguoiDung item = XuLy.Doc(Id, PhanLoai_session, CongTyTDNId_session);  //lấy lên popup
                if (item != null)
                {
                    Email = item.Email;
                    Password = item.Password;
                    ThoiGian = item.ThoiGian;
                    PhanLoai = item.PhanLoai;
                    CongTyTDNId = item.CongTyTDNId;
                    QuanTriHeThong = item.QuanTriHeThong;
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

            if (!string.IsNullOrEmpty(PhanLoai_session))
            {
                danhsach = XuLy.TimKiem(PhanLoai_session, CongTyTDNId_session, keyword);
                if (PhanLoai_session != "SoGiaoThong") CongTyTDNId = int.Parse(CongTyTDNId_session);
            }
            DS_CongTyTDN = XL_CongTyTDN.LayDS();  //nếu location.href có thêm /search thì khi bấm nút thêm mới, DS_CongTyTDN không lấy lên đc => khi post search phải lấy lại DS

        }
        //public void OnPostCreate() //không cần màn hình thêm vì người dùng tự đăng ký
        //{
        //    NguoiDung item = new NguoiDung(Email, Password, PhanLoai, ThoiGian, CongTyTDNId, QuanTriHeThong);
        //    if (XuLy.daTonTai(item))
        //        chuoi = "Mã này đã tồn tại. Bấm vào đây để quay trở lại.";
        //    else
        //    {
        //        int result = XuLy.Them(item);
        //        if (result > 0)
        //            Response.Redirect("/MH_NguoiDung");
        //        else chuoi = "Không thêm được";
        //        
        //    }

        //}
        public void OnPostUpdate()
        {
            NguoiDung item = new NguoiDung(Id, Email, Password, PhanLoai, ThoiGian, CongTyTDNId, QuanTriHeThong);
            XuLy.Capnhat(item);
            chuoi = "Da luu thanh cong";
            Response.Redirect("/MH_NguoiDung");
        }
        public void OnPostDelete()
        {
            XuLy.Xoa(Id);
            chuoi = "Da xoa thanh cong";
            Response.Redirect("/MH_NguoiDung");
        }




    }
}
