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
    public class LuuTru_LichSuSuDung
    {
        LuuTru LuuTru = new LuuTru();

        public List<LichSuSuDung> LayDS_CoDieuKien(string CongTyTDNId )
        {
            string sql = string.Format("SELECT * FROM LichSuSuDung AS lssd " +
                                            "JOIN VeThang AS vt " +
                                            "ON lssd.VeThangId=vt.Id " +
                                            "JOIN Ve AS v " +
                                            "ON vt.VeId=v.Id " +
                                            "WHERE v.CongTyTDNId='{0}'", CongTyTDNId);

            List<LichSuSuDung> danhsach = new List<LichSuSuDung>();
            DataTable DataTable = LuuTru.LayDS(sql);
            if (DataTable.Rows.Count == 0)
                return null;
            foreach (DataRow row in DataTable.Rows)
            {
                LichSuSuDung item = this.KhoiTao(row);
                danhsach.Add(item);
            }
            return danhsach;
        }
        public List<LichSuSuDung> LayDS()
        {
            string sql = string.Format("Select * from LichSuSuDung");

            List<LichSuSuDung> danhsach = new List<LichSuSuDung>();
            DataTable DataTable = LuuTru.LayDS(sql);
            if (DataTable.Rows.Count == 0)
                return null;
            foreach (DataRow row in DataTable.Rows)
            {
                LichSuSuDung item = this.KhoiTao(row);
                danhsach.Add(item);
            }
            return danhsach;
        }
        public LichSuSuDung Doc(int Id, string CongTyTDNId ) //có 2 cách Đọc 1 dòng để lấy thông tin lên popup : 1 là query trong bảng, 2 là query sau khi lấy danh sách
        {
            var danhsach = this.LayDS_CoDieuKien(CongTyTDNId);
            if (danhsach == null)
                return null;
            return danhsach.FirstOrDefault(p => p.Id == Id);
        }
        public int Them(LichSuSuDung LichSuSuDung)
        {
            List<LichSuSuDung> danhsach = this.LayDS();
            int maxId = 0;
            if (danhsach != null)
                maxId = danhsach.Max(p => p.Id);
            LichSuSuDung.Id = maxId + 1;

            //------use "sqlCommand.Parameters.AddWithValue" to avoid error of conversion
            string sql = string.Format("Insert into LichSuSuDung Values (@Id, @VeThangId, @NgaySuDung)");
            return this.ThucThi(sql, LichSuSuDung);
        }

        public int Capnhat(LichSuSuDung LichSuSuDung)
        {
            string sql = string.Format("Update LichSuSuDung Set VeThangId=@VeThangId, NgaySuDung=@NgaySuDung Where Id=@Id");
            return this.ThucThi(sql, LichSuSuDung);
        }
        public int Xoa(int Id)
        {
            string sql = string.Format("Delete From LichSuSuDung Where Id={0} ", Id);
            return LuuTru.ThucThi(sql);
        }

        //------------------------------------------------------------------------------------

        public LichSuSuDung KhoiTao(DataRow row) //convert dataRow thành object
        {
            var Id = int.Parse(row["Id"].ToString().Trim());
            var VeThangId = int.Parse(row["VeThangId"].ToString().Trim());
            var NgaySuDung = DateTime.Parse(row["NgaySuDung"].ToString());

            LichSuSuDung item = new LichSuSuDung(Id, VeThangId, NgaySuDung);
            return item;
        }
        public int ThucThi(string sql, LichSuSuDung LichSuSuDung) //Thêm hay cập nhật giá trị vào SQL
        {
            SqlCommand sqlCommand = new SqlCommand(sql, LuuTru.conn); //phải mở và đóng SqlConnection
            LuuTru.conn.Open();

            sqlCommand.Parameters.AddWithValue("@Id", LichSuSuDung.Id);
            sqlCommand.Parameters.AddWithValue("@VeThangId", LichSuSuDung.VeThangId);
            sqlCommand.Parameters.AddWithValue("@NgaySuDung", LichSuSuDung.NgaySuDung);

            var result = sqlCommand.ExecuteNonQuery();
            LuuTru.conn.Close();
            return result; //trả về số dòng kết quả
        }









    }
}
