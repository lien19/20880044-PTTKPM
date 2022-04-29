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
    public class XuLy_Ga
    {
        LuuTru_Ga LuuTru = new LuuTru_Ga();

        public List<Ga> LayDS()
        {
            return LuuTru.LayDS();
        }
        public int Them(Ga Ga)
        {
            return LuuTru.Them(Ga);
        }
        public int Capnhat(Ga Ga)
        {
            return LuuTru.Capnhat(Ga);
        }
        public int Xoa(int Id)
        {
            return LuuTru.Xoa(Id);
        }
        public Ga Doc(int Id) //Đọc 1 dòng để lấy thông tin lên popup
        {
            return LuuTru.Doc(Id);
        }
        public List<Ga> TimKiem(string keyword = "")
        {
            var danhsach = this.LayDS();
            if (danhsach == null)
                return null;
            if (!string.IsNullOrEmpty(keyword))
                danhsach = danhsach.Where(p => p.TenGa.Contains(keyword)).ToList();
            return danhsach;
        }
        public bool daTonTai(Ga Ga)
        {
            List<Ga> danhsach = this.LayDS();
            if (danhsach == null)
                return false;
            bool daTonTai = danhsach.Any(p => p.MaSoGa == Ga.MaSoGa);
            return daTonTai;
        }
        public bool daDuocDung(int Id)                      //Kiểm tra mã đã được sử dụng chưa trước khi Xóa
        {
            XuLy_TuyenTau_GaTrungGian xl_tt_gtg = new XuLy_TuyenTau_GaTrungGian();
            XuLy_TuyenTau xl_tt                 = new XuLy_TuyenTau();
            var dsTTGTG = xl_tt_gtg.LayDS();
            var dsTT    = xl_tt.LayDS();

            if (dsTTGTG == null && dsTT == null)
                return false;
            else
            {
                if (dsTTGTG != null)
                    foreach (var item in dsTTGTG)
                        if (item.GaId == Id) return true;

                if (dsTT != null)
                    foreach (var item in dsTT)
                        if (item.GaBatDauId == Id || item.GaKetThucId == Id) return true;
            }
            return false;
        }








    }
}
