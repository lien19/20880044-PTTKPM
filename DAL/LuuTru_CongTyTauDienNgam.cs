using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LuuTru_CongTyTauDienNgam
    {
        LuuTru LuuTru = new LuuTru();

        public List<CongTyTauDienNgam> LayDS()
        {
            string sql = "Select * from CongTyTauDienNgam";
            List<CongTyTauDienNgam> danhsach = new List<CongTyTauDienNgam>();
            DataTable DataTable = LuuTru.LayDS(sql);
            if (DataTable.Rows.Count == 0)
                return null;

            foreach (DataRow row in DataTable.Rows)
            {
                CongTyTauDienNgam item = KhoiTao(row);
                danhsach.Add(item);
            }
            return danhsach;
        }
        public CongTyTauDienNgam Doc1(int Id) //có 2 cách Đọc 1 dòng để lấy thông tin lên popup : 1 là query trong bảng, 2 là query sau khi lấy danh sách
        {
            string sql = string.Format("Select * from CongTyTauDienNgam Where Id={0}", Id);
            DataTable DataTable = LuuTru.LayDS(sql);
            return KhoiTao(DataTable.Rows[0]);
        }
        public CongTyTauDienNgam Doc(int Id) //có 2 cách Đọc 1 dòng để lấy thông tin lên popup : 1 là query trong bảng, 2 là query sau khi lấy danh sách
        {
            var danhsach = this.LayDS();
            if (danhsach == null)
                return null;
            return danhsach.FirstOrDefault(p => p.Id == Id);
        }

        public int Them(CongTyTauDienNgam CongTyTauDienNgam)
        {
            List<CongTyTauDienNgam> danhsach = this.LayDS();
            int maxId = 0;
            if (danhsach != null)
                maxId = danhsach.Max(p => p.Id);
            CongTyTauDienNgam.Id = maxId + 1;

            string sql = string.Format("Insert into CongTyTauDienNgam (Id, MaSoCongTyTDN, TenCongTyTDN, DiaChiCongTyTDN, Website, SoDienThoai) Values ({0},'{1}','{2}','{3}','{4}','{5}')", CongTyTauDienNgam.Id, CongTyTauDienNgam.MaSoCongTyTDN, CongTyTauDienNgam.TenCongTyTDN, CongTyTauDienNgam.DiaChiCongTyTDN, CongTyTauDienNgam.Website, CongTyTauDienNgam.SoDienThoai);
            return LuuTru.ThucThi(sql);
        }
        public int Capnhat(CongTyTauDienNgam CongTyTauDienNgam)
        {
            string sql = string.Format("Update CongTyTauDienNgam Set MaSoCongTyTDN='{0}', TenCongTyTDN='{1}', DiaChiCongTyTDN='{2}', Website='{3}', SoDienThoai='{4}' Where Id={5}", CongTyTauDienNgam.MaSoCongTyTDN, CongTyTauDienNgam.TenCongTyTDN, CongTyTauDienNgam.DiaChiCongTyTDN, CongTyTauDienNgam.Website, CongTyTauDienNgam.SoDienThoai, CongTyTauDienNgam.Id);
            return LuuTru.ThucThi(sql);
        }
        public int Xoa(int Id)
        {
            string sql = string.Format("Delete From CongTyTauDienNgam Where Id={0} ", Id);
            return LuuTru.ThucThi(sql);
        }

        //----------------------------------------------------------------------------------
        public CongTyTauDienNgam KhoiTao(DataRow row)
        {
            var Id = int.Parse(row["Id"].ToString().Trim());
            var MaSoCongTyTDN = row["MaSoCongTyTDN"].ToString().Trim();
            var TenCongTyTDN = row["TenCongTyTDN"].ToString().Trim();
            var DiaChiCongTyTDN = row["DiaChiCongTyTDN"].ToString().Trim();
            var Website = row["Website"].ToString().Trim();
            var SoDienThoai = row["SoDienThoai"].ToString().Trim();

            CongTyTauDienNgam item = new CongTyTauDienNgam(Id, MaSoCongTyTDN, TenCongTyTDN, DiaChiCongTyTDN, Website, SoDienThoai);
            return item;
        }







    }
}
