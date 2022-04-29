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
    public class XuLy_TuyenTau
    {
        LuuTru_TuyenTau LuuTru = new LuuTru_TuyenTau();

        public List<TuyenTau> LayDS_CoDieuKien(string CongTyTDNId )
        {
            return LuuTru.LayDS_CoDieuKien(CongTyTDNId);
        }
        public List<TuyenTau> LayDS()
        {
            return LuuTru.LayDS();
        }
        public int Them(TuyenTau TuyenTau)
        {
            return LuuTru.Them(TuyenTau);
        }
        public int Capnhat(TuyenTau TuyenTau)
        {
            return LuuTru.Capnhat(TuyenTau);
        }
        public int Xoa(int Id)
        {
            return LuuTru.Xoa(Id);
        }
        public TuyenTau Doc(int Id, string CongTyTDNId ) //Đọc 1 dòng để lấy thông tin lên popup
        {
            return LuuTru.Doc(Id, CongTyTDNId);
        }
        public List<TuyenTau> TimKiem(string CongTyTDNId , string keyword = "")
        {
            var danhsach = this.LayDS_CoDieuKien(CongTyTDNId);
            if (danhsach == null)
                return null;
            if (!string.IsNullOrEmpty(keyword))
                danhsach = danhsach.Where(p => p.TenTuyenTau.Contains(keyword)).ToList();
            return danhsach;
        }
        public bool daTonTai(TuyenTau TuyenTau)             //Kiểm tra mã đã tồn tại chưa trước khi Thêm
        {
            List<TuyenTau> danhsach = this.LayDS();
            if (danhsach == null)
                return false;
            bool daTonTai = danhsach.Any(p => p.MaSoTuyenTau == TuyenTau.MaSoTuyenTau);
            return daTonTai;
        }
        public bool daDuocDung(int Id)                      //Kiểm tra mã đã được sử dụng chưa trước khi Xóa
        {
            XuLy_TuyenTau_GaTrungGian xl_tt_gtg = new XuLy_TuyenTau_GaTrungGian();
            XuLy_Ve xl_v                        = new XuLy_Ve();
            var dsTTGTG = xl_tt_gtg.LayDS();
            var dsVe    = xl_v.LayDS();

            if (dsTTGTG == null && dsVe == null)
                return false;
            else
            {
                if (dsTTGTG != null)
                    foreach (var item in dsTTGTG)
                        if (item.TuyenTauId == Id) return true;

                if (dsVe != null)
                    foreach (var item in dsVe)
                        if (item.TuyenTauId == Id) return true;
            }
            return false;
        }






    }
}
