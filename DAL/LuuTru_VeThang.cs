using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LuuTru_VeThang
    {
        LuuTru LuuTru = new LuuTru();

        public List<VeThang> LayDS_CoDieuKien(string CongTyTDNId)
        {
            string sql = string.Format("SELECT * FROM VeThang AS vt " +
                                        "JOIN Ve AS v " +
                                        "ON vt.VeId=v.Id " +
                                        "WHERE CongTyTDNId='{0}'", CongTyTDNId);

            List<VeThang> danhsach = new List<VeThang>();
            DataTable DataTable = LuuTru.LayDS(sql);
            if (DataTable.Rows.Count == 0)
                return null;
            foreach (DataRow row in DataTable.Rows)
            {
                VeThang item = this.KhoiTao(row);
                danhsach.Add(item);
            }
            return danhsach;
        }
        public List<VeThang> LayDS()
        {
            string sql = string.Format("Select * from VeThang");

            List<VeThang> danhsach = new List<VeThang>();
            DataTable DataTable = LuuTru.LayDS(sql);
            if (DataTable.Rows.Count == 0)
                return null;
            foreach (DataRow row in DataTable.Rows)
            {
                VeThang item = this.KhoiTao(row);
                danhsach.Add(item);
            }
            return danhsach;
        }
        public VeThang Doc(int Id, string CongTyTDNId ) //có 2 cách Đọc 1 dòng để lấy thông tin lên popup : 1 là query trong bảng, 2 là query sau khi lấy danh sách
        {
            var danhsach = this.LayDS_CoDieuKien(CongTyTDNId);
            if (danhsach == null)
                return null;
            return danhsach.FirstOrDefault(p => p.Id == Id);
        }
        public int Them(VeThang VeThang)
        {
            List<VeThang> danhsach = this.LayDS();
            int maxId = 0;
            if (danhsach != null)
                maxId = danhsach.Max(p => p.Id);
            VeThang.Id = maxId + 1;

            //------use "sqlCommand.Parameters.AddWithValue" to avoid error of conversion
            string sql = string.Format("Insert into VeThang Values (@Id, @VeId, @NgayHetHan)");
            return this.ThucThi(sql, VeThang);
        }

        public int Capnhat(VeThang VeThang)
        {
            string sql = string.Format("Update VeThang Set VeId=@VeId, NgayHetHan=@NgayHetHan Where Id=@Id");
            return this.ThucThi(sql, VeThang);
        }
        public int Xoa(int Id)
        {
            string sql = string.Format("Delete From VeThang Where Id={0} ", Id);
            return LuuTru.ThucThi(sql);
        }

        //------------------------------------------------------------------------------------

        public VeThang KhoiTao(DataRow row) //convert dataRow thành object
        {
            var Id = int.Parse(row["Id"].ToString().Trim());
            var VeId = int.Parse(row["VeId"].ToString().Trim());
            var NgayHetHan = DateTime.Parse(row["NgayHetHan"].ToString());

            VeThang item = new VeThang(Id, VeId, NgayHetHan);
            return item;
        }
        public int ThucThi(string sql, VeThang VeThang) //Thêm hay cập nhật giá trị vào SQL
        {
            SqlCommand sqlCommand = new SqlCommand(sql, LuuTru.conn); //phải mở và đóng SqlConnection
            LuuTru.conn.Open();

            sqlCommand.Parameters.AddWithValue("@Id", VeThang.Id);
            sqlCommand.Parameters.AddWithValue("@VeId", VeThang.VeId);
            sqlCommand.Parameters.AddWithValue("@NgayHetHan", VeThang.NgayHetHan);

            var result = sqlCommand.ExecuteNonQuery();
            LuuTru.conn.Close();
            return result; //trả về số dòng kết quả
        }










    }
}
