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
    public class LuuTru_VeThuong
    {
        LuuTru LuuTru = new LuuTru();

        public List<VeThuong> LayDS_CoDieuKien(string CongTyTDNId)
        {
            string sql = string.Format("SELECT * FROM VeThuong AS vt " +
                                        "JOIN Ve AS v " +
                                        "ON vt.VeId=v.Id " +
                                        "WHERE CongTyTDNId='{0}'", CongTyTDNId);

            List<VeThuong> danhsach = new List<VeThuong>();
            DataTable DataTable = LuuTru.LayDS(sql);
            if (DataTable.Rows.Count == 0)
                return null;
            foreach (DataRow row in DataTable.Rows)
            {
                VeThuong item = this.KhoiTao(row);
                danhsach.Add(item);
            }
            return danhsach;
        }
        public List<VeThuong> LayDS()
        {
            string sql = string.Format("Select * from VeThuong");

            List<VeThuong> danhsach = new List<VeThuong>();
            DataTable DataTable = LuuTru.LayDS(sql);
            if (DataTable.Rows.Count == 0)
                return null;
            foreach (DataRow row in DataTable.Rows)
            {
                VeThuong item = this.KhoiTao(row);
                danhsach.Add(item);
            }
            return danhsach;
        }
        public VeThuong Doc(int Id, string CongTyTDNId) //có 2 cách Đọc 1 dòng để lấy thông tin lên popup : 1 là query trong bảng, 2 là query sau khi lấy danh sách
        {
            var danhsach = this.LayDS_CoDieuKien(CongTyTDNId);
            if (danhsach == null)
                return null;
            return danhsach.FirstOrDefault(p => p.Id == Id);
        }
        public int Them(VeThuong VeThuong)
        {
            List<VeThuong> danhsach = this.LayDS();
            int maxId = 0;
            if (danhsach != null)
                maxId = danhsach.Max(p => p.Id);
            VeThuong.Id = maxId + 1;

            //------use "sqlCommand.Parameters.AddWithValue" to avoid error of conversion
            string sql = string.Format("Insert into VeThuong Values (@Id, @VeId, @TrangThaiSuDung, @ThoiDiemSuDung)");
            return this.ThucThi(sql, VeThuong);
        }

        public int Capnhat(VeThuong VeThuong)
        {
            string sql = string.Format("Update VeThuong Set VeId=@VeId, TrangThaiSuDung=@TrangThaiSuDung, ThoiDiemSuDung=@ThoiDiemSuDung Where Id=@Id");
            return this.ThucThi(sql, VeThuong);
        }
        public int Xoa(int Id)
        {
            string sql = string.Format("Delete From VeThuong Where Id={0} ", Id);
            return LuuTru.ThucThi(sql);
        }

        //------------------------------------------------------------------------------------

        public VeThuong KhoiTao(DataRow row) //convert dataRow thành object
        {
            var Id = int.Parse(row["Id"].ToString().Trim());
            var VeId = int.Parse(row["VeId"].ToString().Trim());
            var TrangThaiSuDung = row["TrangThaiSuDung"].ToString().Trim();
            var ThoiDiemSuDung = DateTime.Parse(row["ThoiDiemSuDung"].ToString());

            VeThuong item = new VeThuong(Id, VeId, TrangThaiSuDung, ThoiDiemSuDung);
            return item;
        }
        public int ThucThi(string sql, VeThuong VeThuong) //Thêm hay cập nhật giá trị vào SQL
        {
            SqlCommand sqlCommand = new SqlCommand(sql, LuuTru.conn); //phải mở và đóng SqlConnection
            LuuTru.conn.Open();

            sqlCommand.Parameters.AddWithValue("@Id", VeThuong.Id);
            sqlCommand.Parameters.AddWithValue("@VeId", VeThuong.VeId);
            sqlCommand.Parameters.AddWithValue("@TrangThaiSuDung", VeThuong.TrangThaiSuDung);
            sqlCommand.Parameters.AddWithValue("@ThoiDiemSuDung", VeThuong.ThoiDiemSuDung);

            var result = sqlCommand.ExecuteNonQuery();
            LuuTru.conn.Close();
            return result; //trả về số dòng kết quả
        }









    }
}
