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
    public class XuLy_CongTyTauDienNgam
    {
         LuuTru_CongTyTauDienNgam LuuTru = new LuuTru_CongTyTauDienNgam();

        public List<CongTyTauDienNgam> LayDS()
        {
            return LuuTru.LayDS();
        }
        public int Them(CongTyTauDienNgam CongTyTauDienNgam)
        {
            return LuuTru.Them(CongTyTauDienNgam);
        }
        public int Capnhat(CongTyTauDienNgam CongTyTauDienNgam)
        {
            return LuuTru.Capnhat(CongTyTauDienNgam);
        }
        public int Xoa(int Id)
        {
            return LuuTru.Xoa(Id);
        }
        public CongTyTauDienNgam Doc(int Id) //Đọc 1 dòng để lấy thông tin lên popup
        {
            return LuuTru.Doc(Id);
        }

        public List<CongTyTauDienNgam> TimKiem(string keyword="")
        {
            var danhsach = this.LayDS();
            if (danhsach == null)
                return null;
            if (! string.IsNullOrEmpty(keyword))
                danhsach = danhsach.Where(p => p.TenCongTyTDN.Contains(keyword)).ToList();
            return danhsach;
        }

        public bool daTonTai(CongTyTauDienNgam CongTyTauDienNgam)
        {
            List<CongTyTauDienNgam> danhsach = this.LayDS();
            if (danhsach == null)
                return false;
            bool daTonTai = danhsach.Any(p => p.MaSoCongTyTDN == CongTyTauDienNgam.MaSoCongTyTDN);            
            return daTonTai;
        }
        public bool daDuocDung(int Id)                      //Kiểm tra mã đã được sử dụng chưa trước khi Xóa
        {
            XuLy_TuyenTau xl_tt = new XuLy_TuyenTau();
            XuLy_Ve xl_v = new XuLy_Ve();
            XuLy_NguoiDung xl_nd = new XuLy_NguoiDung();
            var dsTT = xl_tt.LayDS();
            var dsVe = xl_v.LayDS();
            var dsND = xl_nd.LayDS();

            if (dsTT == null && dsVe == null && dsND == null)
                return false;
            else
            {
                if (dsTT != null)
                    foreach (var item in dsTT)
                        if (item.CongTyTDNId == Id) return true;

                if (dsVe != null)
                    foreach (var item in dsVe)
                        if (item.CongTyTDNId == Id) return true;

                if (dsND != null)
                    foreach (var item in dsND)
                        if (item.CongTyTDNId == Id) return true;
            }
            return false;
        }







    }
}
