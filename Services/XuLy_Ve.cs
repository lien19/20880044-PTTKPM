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
    public class XuLy_Ve
    {
        LuuTru_Ve LuuTru = new LuuTru_Ve();

        public List<Ve> LayDS_CoDieuKien(string CongTyTDNId )
        {
            return LuuTru.LayDS_CoDieuKien(CongTyTDNId);
        }
        public List<Ve> LayDS_ChuaDuocDung(string CongTyTDNId ) //Mã số Vé chỉ được sử dụng 1 lần, nên ds này để đổ vào input select VeId của 2 bảng Vé thường và Vé tháng
        {
            var ds_CoDieuKien   = this.LayDS_CoDieuKien(CongTyTDNId);
            if (ds_CoDieuKien == null)
                return null;

            var ds_ChuaDuocDung = ds_CoDieuKien.Where(p => this.daDuocDung(p.Id)==false).ToList();
            return ds_ChuaDuocDung;
        }
        public List<Ve> LayDS()
        {
            return LuuTru.LayDS();
        }
        public int Them(Ve Ve)
        {
            return LuuTru.Them(Ve);
        }
        public int Capnhat(Ve Ve)
        {
            return LuuTru.Capnhat(Ve);
        }
        public int Xoa(int Id)
        {
            return LuuTru.Xoa(Id);
        }
        public Ve Doc(int Id, string CongTyTDNId ) //Đọc 1 dòng để lấy thông tin lên popup
        {
            return LuuTru.Doc(Id, CongTyTDNId);
        }
        public List<Ve> TimKiem(string keyword, string CongTyTDNId)
        {
            var danhsach = this.LayDS_CoDieuKien(CongTyTDNId);
            if (danhsach == null)
                return null;
            if (!string.IsNullOrEmpty(keyword))
                danhsach = danhsach.Where(p => p.MaSoVe.Contains(keyword)).ToList();
            return danhsach;
        }

        public bool daTonTai(Ve Ve)  //Kiểm tra mã đã tồn tại chưa trước khi Thêm
        {
            List<Ve> danhsach = this.LayDS();
            if (danhsach == null)
                return false;
            bool daTonTai = danhsach.Any(p => p.MaSoVe == Ve.MaSoVe);
            return daTonTai;
        }
        public bool daDuocDung(int Id)                      //Kiểm tra mã đã được sử dụng chưa trước khi Xóa
        {
            XuLy_VeThuong xl_vthuong = new XuLy_VeThuong();
            XuLy_VeThang xl_vthang = new XuLy_VeThang();
            var dsVThuong = xl_vthuong.LayDS();
            var dsVThang = xl_vthang.LayDS();

            if (dsVThuong == null && dsVThang == null)
                return false;
            else
            {
                if (dsVThuong != null)
                    foreach (var item in dsVThuong)
                        if (item.VeId == Id) return true;

                if (dsVThang != null)
                    foreach (var item in dsVThang)
                        if (item.VeId == Id) return true;
            }
            return false;
        }








    }
}
