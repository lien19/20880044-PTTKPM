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
    public class XuLy_TuyenTau_GaTrungGian
    {
        LuuTru_TuyenTau_GaTrungGian LuuTru = new LuuTru_TuyenTau_GaTrungGian();

        public List<TuyenTau_GaTrungGian> LayDS_CoDieuKien(string CongTyTDNId)
        {
            return LuuTru.LayDS_CoDieuKien(CongTyTDNId);
        }
        public List<TuyenTau_GaTrungGian> LayDS()
        {
            return LuuTru.LayDS();
        }
        public int Them(TuyenTau_GaTrungGian TuyenTau_GaTrungGian)
        {
            return LuuTru.Them(TuyenTau_GaTrungGian);
        }
        public int Capnhat(TuyenTau_GaTrungGian TuyenTau_GaTrungGian)
        {
            return LuuTru.Capnhat(TuyenTau_GaTrungGian);
        }
        public int Xoa(int Id)
        {
            return LuuTru.Xoa(Id);
        }
        public TuyenTau_GaTrungGian Doc(int Id, string CongTyTDNId ) //Đọc 1 dòng để lấy thông tin lên popup
        {
            return LuuTru.Doc(Id, CongTyTDNId);
        }

        public List<TuyenTau_GaTrungGian> TimKiem(string CongTyTDNId , string keyword="")
        {
            var danhsach = this.LayDS_CoDieuKien(CongTyTDNId);
            if (danhsach == null)
                return null;
            if (! string.IsNullOrEmpty(keyword))
                danhsach = danhsach.Where(p => p.TuyenTauId.ToString().Contains(keyword)).ToList();
            return danhsach;
        }

        public bool daTonTai(TuyenTau_GaTrungGian TuyenTau_GaTrungGian)  //Kiểm tra mã đã tồn tại chưa trước khi Thêm
        {
            List<TuyenTau_GaTrungGian> danhsach = this.LayDS();
            if (danhsach == null)
                return false;
            bool daTonTai = danhsach.Any(p => p.GaId == TuyenTau_GaTrungGian.GaId && p.TuyenTauId == TuyenTau_GaTrungGian.TuyenTauId);            
            return daTonTai;
        }





    }
}
