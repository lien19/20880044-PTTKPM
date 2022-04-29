using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class XuLy_VeThuong
    {
        LuuTru_VeThuong LuuTru = new LuuTru_VeThuong();

        public List<VeThuong> LayDS_CoDieuKien(string CongTyTDNId )
        {
            return LuuTru.LayDS_CoDieuKien(CongTyTDNId);
        }
        public List<VeThuong> LayDS()
        {
            return LuuTru.LayDS();
        }
        public int Them(VeThuong VeThuong)
        {
            return LuuTru.Them(VeThuong);
        }
        public int Capnhat(VeThuong VeThuong)
        {
            return LuuTru.Capnhat(VeThuong);
        }
        public int Xoa(int Id)
        {
            return LuuTru.Xoa(Id);
        }
        public VeThuong Doc(int Id, string CongTyTDNId ) //Đọc 1 dòng để lấy thông tin lên popup
        {
            return LuuTru.Doc(Id, CongTyTDNId);
        }
        public List<VeThuong> TimKiem(string keyword, string CongTyTDNId)
        {
            var danhsach = this.LayDS_CoDieuKien(CongTyTDNId);
            if (danhsach == null)
                return null;
            if (!string.IsNullOrEmpty(keyword))
                danhsach = danhsach.Where(p => p.VeId.ToString().Contains(keyword)).ToList();
            return danhsach;
        }

        public bool daTonTai(VeThuong VeThuong)  //Kiểm tra mã đã tồn tại chưa trước khi Thêm
        {
            List<VeThuong> danhsach = this.LayDS();
            if (danhsach == null)
                return false;
            bool daTonTai = danhsach.Any(p => p.VeId == VeThuong.VeId);
            return daTonTai;
        }
        public bool kiemTraNgay(VeThuong VeThuong)
        {
            XuLy_Ve xl_v = new XuLy_Ve();
            var dsVe = xl_v.LayDS();
            if (dsVe == null) 
                return false;

            var ve = dsVe.FirstOrDefault(p => p.Id == VeThuong.VeId);
            if (VeThuong.ThoiDiemSuDung >= ve.NgayBanVe)
                return true;
            return false;
        }





    }
}
