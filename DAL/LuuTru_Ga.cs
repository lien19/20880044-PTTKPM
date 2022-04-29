using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LuuTru_Ga
    {
        LuuTru LuuTru = new LuuTru();

        public List<Ga> LayDS()
        {
            string sql = "Select * from Ga";
            List<Ga> danhsach = new List<Ga>();
            DataTable DataTable = LuuTru.LayDS(sql);
            if (DataTable.Rows.Count == 0)
                return null;

            foreach (DataRow row in DataTable.Rows)
            {
                Ga item = this.KhoiTao(row);
                danhsach.Add(item);
            }
            return danhsach;
        }
        public Ga Doc(int Id) //có 2 cách Đọc 1 dòng để lấy thông tin lên popup : 1 là query trong bảng, 2 là query sau khi lấy danh sách
        {
            var danhsach = this.LayDS();
            if (danhsach == null)
                return null;
            return danhsach.FirstOrDefault(p => p.Id == Id);
        }
        public int Them(Ga Ga)
        {
            List<Ga> danhsach = this.LayDS();
            int maxId = 0;
            if (danhsach != null)
                maxId = danhsach.Max(p => p.Id); //duyệt dòng, sau đó duyệt cột
            Ga.Id = maxId + 1;

            string sql = string.Format("Insert into Ga (Id, MaSoGa, TenGa, ViTri, TinhTrangHoatDong, BanDo) Values ({0},'{1}','{2}','{3}','{4}','{5}')", Ga.Id, Ga.MaSoGa, Ga.TenGa, Ga.ViTri, Ga.TinhTrangHoatDong, Ga.BanDo);
            return LuuTru.ThucThi(sql);
        }
        public int Capnhat(Ga Ga)
        {
            string sql = string.Format("Update Ga Set MaSoGa='{0}', TenGa='{1}', ViTri='{2}', TinhTrangHoatDong='{3}', BanDo='{4}' Where Id={5}", Ga.MaSoGa, Ga.TenGa, Ga.ViTri, Ga.TinhTrangHoatDong, Ga.BanDo, Ga.Id);
            return LuuTru.ThucThi(sql);
        }
        public int Xoa(int Id)
        {
            string sql = string.Format("Delete From Ga Where Id={0}", Id);
            return LuuTru.ThucThi(sql);
        }

        //--------------------------------------------------------------------
        public Ga KhoiTao(DataRow row) //convert dataRow thành object
        {
            var Id = int.Parse(row["Id"].ToString().Trim());
            var MaSoGa = row["MaSoGa"].ToString().Trim();
            var TenGa = row["TenGa"].ToString().Trim();
            var ViTri = row["ViTri"].ToString().Trim();
            var TinhTrangHoatDong = row["TinhTrangHoatDong"].ToString().Trim();
            var BanDo = row["BanDo"].ToString().Trim();

            Ga item = new Ga(Id, MaSoGa, TenGa, ViTri, TinhTrangHoatDong, BanDo);
            return item;
        }







    }
}
