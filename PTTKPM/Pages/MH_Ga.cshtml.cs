using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using Entities;
using Microsoft.AspNetCore.Http;

namespace PTTKPM.Pages
{
    public class MH_GaModel : PageModel
    {
        [BindProperty] public string keyword { get; set; }
        //form: create
        [BindProperty] public string MaSoGa { get; set; }
        [BindProperty] public string TenGa { get; set; }
        [BindProperty] public string ViTri { get; set; }
        [BindProperty] public string TinhTrangHoatDong { get; set; }
        [BindProperty] public string BanDo { get; set; }
        //biến
        [BindProperty(SupportsGet = true)] public int Id { get; set; }
        public string chuoi { get; set; }
        public string email_session { get; set; }
        public string PhanLoai_session { get; set; }
        public string CongTyTDNId_session { get; set; }
        public string QuanTriHeThong_session { get; set; }
        //danh sách
        public List<string> TinhTrangHoatDong_List = new List<string>() { "Binh thuong", "Dang sua chua", "Ngung hoat dong" };
        public List<Ga> danhsach { get; set; }
        private XuLy_Ga XuLy { get; set; }
        public MH_GaModel() : base()
        {
            XuLy = new XuLy_Ga();
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
                //... lấy danh sách lên TABLE
                danhsach = XuLy.LayDS();
            }
            else
            {
                //... lấy danh sách lên TABLE
                danhsach = XuLy.LayDS();
                //... lấy thông tin 1 dòng lên popup
                Ga item = XuLy.Doc(Id);
                if (item != null)
                {
                    MaSoGa = item.MaSoGa;
                    TenGa = item.TenGa;
                    ViTri = item.ViTri;
                    TinhTrangHoatDong = item.TinhTrangHoatDong;
                    BanDo = item.BanDo;
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
            Ga item = new Ga(MaSoGa, TenGa, ViTri, TinhTrangHoatDong, BanDo);
            if (XuLy.daTonTai(item))
                chuoi = "Mã này đã tồn tại. Bấm vào đây để quay trở lại.";
            else
            {
                int result = XuLy.Them(item);
                if (result > 0)
                    Response.Redirect("/MH_Ga");
                else chuoi = "Không thêm được. Bấm vào đây để quay trở lại.";

            }
        }
        public void OnPostUpdate()
        {
            Ga item = new Ga(Id, MaSoGa, TenGa, ViTri, TinhTrangHoatDong, BanDo);
            XuLy.Capnhat(item);
            chuoi = "Da luu thanh cong";
            danhsach = XuLy.LayDS();
            Response.Redirect("/MH_Ga");
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
                Response.Redirect("/MH_Ga");
            }
                
        }

    }
}
