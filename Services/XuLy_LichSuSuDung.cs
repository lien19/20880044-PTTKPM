using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class XuLy_LichSuSuDung
    {
        LuuTru_LichSuSuDung LuuTru = new LuuTru_LichSuSuDung();

        public List<LichSuSuDung> LayDS_CoDieuKien(string CongTyTDNId )
        {
            return LuuTru.LayDS_CoDieuKien(CongTyTDNId);
        }
        public List<LichSuSuDung> LayDS()
        {
            return LuuTru.LayDS();
        }
        public int Them(LichSuSuDung LichSuSuDung)
        {
            return LuuTru.Them(LichSuSuDung);
        }
        public int Capnhat(LichSuSuDung LichSuSuDung)
        {
            return LuuTru.Capnhat(LichSuSuDung);
        }
        public int Xoa(int Id)
        {
            return LuuTru.Xoa(Id);
        }
        public LichSuSuDung Doc(int Id, string CongTyTDNId ) //Đọc 1 dòng để lấy thông tin lên popup
        {
            return LuuTru.Doc(Id, CongTyTDNId);
        }
        public List<LichSuSuDung> TimKiem(string keyword, string CongTyTDNId )
        {
            var danhsach = this.LayDS_CoDieuKien(CongTyTDNId);
            if (danhsach == null)
                return null;
            if (!string.IsNullOrEmpty(keyword))
                danhsach = danhsach.Where(p => p.VeThangId.ToString().Contains(keyword)).ToList();
            return danhsach;
        }

        public bool daTonTai(LichSuSuDung LichSuSuDung)  //Kiểm tra mã đã tồn tại chưa trước khi Thêm
        {
            List<LichSuSuDung> danhsach = this.LayDS();
            if (danhsach == null)
                return false;
            bool daTonTai = danhsach.Any(p => p.VeThangId == LichSuSuDung.VeThangId);
            return daTonTai;
        }



    }
}
