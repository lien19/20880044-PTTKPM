using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class XuLy_VeThang
    {
        LuuTru_VeThang LuuTru = new LuuTru_VeThang();

        public List<VeThang> LayDS_CoDieuKien(string CongTyTDNId )
        {
            return LuuTru.LayDS_CoDieuKien(CongTyTDNId);
        }
        public List<VeThang> LayDS()
        {
            return LuuTru.LayDS();
        }
        public int Them(VeThang VeThang)
        {
            return LuuTru.Them(VeThang);
        }
        public int Capnhat(VeThang VeThang)
        {
            return LuuTru.Capnhat(VeThang);
        }
        public int Xoa(int Id)
        {
            return LuuTru.Xoa(Id);
        }
        public VeThang Doc(int Id, string CongTyTDNId ) //Đọc 1 dòng để lấy thông tin lên popup
        {
            return LuuTru.Doc(Id, CongTyTDNId);
        }
        public List<VeThang> TimKiem(string keyword, string CongTyTDNId)
        {
            var danhsach = this.LayDS_CoDieuKien(CongTyTDNId);
            if (danhsach == null)
                return null;
            if (!string.IsNullOrEmpty(keyword))
                danhsach = danhsach.Where(p => p.VeId.ToString().Contains(keyword)).ToList();
            return danhsach;
        }

        public bool daTonTai(VeThang VeThang)  //Kiểm tra mã đã tồn tại chưa trước khi Thêm
        {
            List<VeThang> danhsach = this.LayDS();
            if (danhsach == null)
                return false;
            bool daTonTai = danhsach.Any(p => p.VeId == VeThang.VeId);
            return daTonTai;
        }
        public bool daDuocDung(int Id)                      //Kiểm tra mã đã được sử dụng chưa trước khi Xóa
        {
            XuLy_LichSuSuDung xl = new XuLy_LichSuSuDung();
            var ds = xl.LayDS();

            if (ds == null)
                return false;
            else
            {
                foreach (var item in ds)
                    if (item.VeThangId == Id) return true;
            }
            return false;
        }
        public DateTime? tinhNgayHetHan(VeThang VeThang)
        {
            XuLy_Ve xl_v = new XuLy_Ve();
            var dsVe = xl_v.LayDS();
            if (dsVe == null)
                return null;

            var ve = dsVe.FirstOrDefault(p => p.Id == VeThang.VeId);
            TimeSpan TimeSpan = new TimeSpan(30, 0, 0, 0);
            return ve.NgayBanVe.Add(TimeSpan);
        }






    }
}
