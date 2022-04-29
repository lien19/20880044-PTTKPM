using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LuuTru_TuyenTau_GaTrungGian
    {
        LuuTru LuuTru = new LuuTru();

        public List<TuyenTau_GaTrungGian> LayDS_CoDieuKien(string CongTyTDNId )
        {
            string sql = string.Format("SELECT * FROM TuyenTau_GaTrungGian AS gtg " +
                                                            "JOIN TuyenTau AS tt " +
                                                        "ON gtg.TuyenTauId=tt.Id " +
                                                        "WHERE CongTyTDNId='{0}'", CongTyTDNId);

            List<TuyenTau_GaTrungGian> danhsach = new List<TuyenTau_GaTrungGian>();
            DataTable DataTable = LuuTru.LayDS(sql);
            if (DataTable.Rows.Count == 0)
                return null;

            foreach (DataRow row in DataTable.Rows)
            {
                TuyenTau_GaTrungGian item = KhoiTao(row);
                danhsach.Add(item);
            }
            return danhsach;
        }
        public List<TuyenTau_GaTrungGian> LayDS()
        {
            string sql = string.Format("SELECT * FROM TuyenTau_GaTrungGian");

            List<TuyenTau_GaTrungGian> danhsach = new List<TuyenTau_GaTrungGian>();
            DataTable DataTable = LuuTru.LayDS(sql);
            if (DataTable.Rows.Count == 0)
                return null;

            foreach (DataRow row in DataTable.Rows)
            {
                TuyenTau_GaTrungGian item = KhoiTao(row);
                danhsach.Add(item);
            }
            return danhsach;
        }
        public TuyenTau_GaTrungGian Doc1(int Id) //có 2 cách Đọc 1 dòng để lấy thông tin lên popup : 1 là query trong bảng, 2 là query sau khi lấy danh sách
        {
            string sql = string.Format("Select * from TuyenTau_GaTrungGian Where Id={0}", Id);
            DataTable DataTable = LuuTru.LayDS(sql);
            return KhoiTao(DataTable.Rows[0]);
        }
        public TuyenTau_GaTrungGian Doc(int Id, string CongTyTDNId ) //có 2 cách Đọc 1 dòng để lấy thông tin lên popup : 1 là query trong bảng, 2 là query sau khi lấy danh sách
        {
            var danhsach = this.LayDS_CoDieuKien(CongTyTDNId);
            if (danhsach == null)
                return null;
            return danhsach.FirstOrDefault(p => p.Id == Id);
        }

        public int Them(TuyenTau_GaTrungGian TuyenTau_GaTrungGian)
        {
            List<TuyenTau_GaTrungGian> danhsach = this.LayDS();
            int maxId = 0;
            if (danhsach != null)
                maxId = danhsach.Max(p => p.Id);
            TuyenTau_GaTrungGian.Id = maxId + 1;

            string sql = string.Format("Insert into TuyenTau_GaTrungGian (Id, TuyenTauId, GaId, ThoiGianDung) Values ({0},'{1}','{2}',{3})", TuyenTau_GaTrungGian.Id, TuyenTau_GaTrungGian.TuyenTauId, TuyenTau_GaTrungGian.GaId, TuyenTau_GaTrungGian.ThoiGianDung);
            return LuuTru.ThucThi(sql);
        }
        public int Capnhat(TuyenTau_GaTrungGian TuyenTau_GaTrungGian)
        {
            string sql = string.Format("Update TuyenTau_GaTrungGian Set TuyenTauId='{0}', GaId='{1}', ThoiGianDung={2} Where Id={3}", TuyenTau_GaTrungGian.TuyenTauId, TuyenTau_GaTrungGian.GaId, TuyenTau_GaTrungGian.ThoiGianDung, TuyenTau_GaTrungGian.Id);
            return LuuTru.ThucThi(sql);
        }
        public int Xoa(int Id)
        {
            string sql = string.Format("Delete From TuyenTau_GaTrungGian Where Id={0} ", Id);
            return LuuTru.ThucThi(sql);
        }

        //----------------------------------------------------------------------------------
        public TuyenTau_GaTrungGian KhoiTao(DataRow row)
        {
            var Id           = int.Parse(row["Id"].ToString());
            var TuyenTauId   = int.Parse(row["TuyenTauId"].ToString());
            var GaId         = int.Parse(row["GaId"].ToString());
            var ThoiGianDung = int.Parse(row["ThoiGianDung"].ToString());

            TuyenTau_GaTrungGian item = new TuyenTau_GaTrungGian(Id, TuyenTauId, GaId, ThoiGianDung);
            return item;
        }







    }
}
