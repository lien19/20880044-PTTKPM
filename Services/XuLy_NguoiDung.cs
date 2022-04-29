using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class XuLy_NguoiDung
    {
        LuuTru_NguoiDung LuuTru = new LuuTru_NguoiDung();

        public List<NguoiDung> LayDS_CoDieuKien(string PhanLoai, string CongTyTDNId)
        {
            return LuuTru.LayDS_CoDieuKien(PhanLoai, CongTyTDNId);
        }
        public List<NguoiDung> LayDS_DangNhap(string PhanLoai)
        {
            return LuuTru.LayDS_DangNhap(PhanLoai);
        }
        public List<NguoiDung> LayDS()
        {
            return LuuTru.LayDS();
        }

        public int Them(NguoiDung NguoiDung)
        {
            return LuuTru.Them(NguoiDung);
        }
        public int Capnhat(NguoiDung NguoiDung)
        {
            return LuuTru.Capnhat(NguoiDung);
        }
        public int Xoa(int Id)
        {
            return LuuTru.Xoa(Id);
        }
        public NguoiDung Doc(int Id, string PhanLoai, string CongTyTDNId) //Đọc 1 dòng để lấy thông tin lên popup
        {
            return LuuTru.Doc(Id, PhanLoai, CongTyTDNId);
        }
        public List<NguoiDung> TimKiem(string PhanLoai, string CongTyTDNId, string keyword = "")
        {
            var danhsach = this.LayDS_CoDieuKien(PhanLoai, CongTyTDNId);
            if (danhsach == null)
                return null;
            if (!string.IsNullOrEmpty(keyword))
                danhsach = danhsach.Where(p => p.Email.Contains(keyword)).ToList();
            return danhsach;
        }
        public bool daTonTai(NguoiDung NguoiDung) //MH đăng ký   //Kiểm tra mã đã tồn tại chưa trước khi Thêm
        {
            List<NguoiDung> danhsach = this.LayDS();
            if (danhsach == null)
                return false;

            foreach (var item in danhsach)
                if (item.Email == NguoiDung.Email)
                    return true;
            return false;
        }

        public NguoiDung DangNhap(NguoiDung NguoiDung, string PhanLoai)
        {
            List<NguoiDung> danhsach = this.LayDS_DangNhap(PhanLoai);
            if (danhsach == null)
                return null;

            foreach (var item in danhsach)
                if (item.Email == NguoiDung.Email && item.PhanLoai == NguoiDung.PhanLoai && item.Password == NguoiDung.Password)
                    return item;  //để lấy CongTyTDNId
            return null;
        }
        




    }
}
