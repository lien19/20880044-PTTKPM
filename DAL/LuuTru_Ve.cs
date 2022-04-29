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
    public class LuuTru_Ve
    {
        LuuTru LuuTru = new LuuTru();

        public List<Ve> LayDS_CoDieuKien(string CongTyTDNId )
        {
            string sql = string.Format("Select * from Ve Where CongTyTDNId='{0}'", CongTyTDNId);

            List<Ve> danhsach = new List<Ve>();
            DataTable DataTable = LuuTru.LayDS(sql);
            if (DataTable.Rows.Count == 0)
                return null;
            foreach (DataRow row in DataTable.Rows)
            {
                Ve item = this.KhoiTao(row);
                danhsach.Add(item);
            }
            return danhsach;
        }
        public List<Ve> LayDS()
        {
            string sql = string.Format("Select * from Ve");

            List<Ve> danhsach = new List<Ve>();
            DataTable DataTable = LuuTru.LayDS(sql);
            if (DataTable.Rows.Count == 0)
                return null;
            foreach (DataRow row in DataTable.Rows)
            {
                Ve item = this.KhoiTao(row);
                danhsach.Add(item);
            }
            return danhsach;
        }
        public Ve Doc(int Id, string CongTyTDNId ) //có 2 cách Đọc 1 dòng để lấy thông tin lên popup : 1 là query trong bảng, 2 là query sau khi lấy danh sách
        {
            var danhsach = this.LayDS_CoDieuKien(CongTyTDNId);
            if (danhsach == null)
                return null;
            return danhsach.FirstOrDefault(p => p.Id == Id);
        }
        public int Them(Ve Ve)
        {
            List<Ve> danhsach = this.LayDS();
            int maxId = 0;
            if (danhsach != null)
                maxId = danhsach.Max(p => p.Id);
            Ve.Id = maxId + 1;

            //------use "sqlCommand.Parameters.AddWithValue" to avoid error of conversion
            string sql = string.Format("Insert into Ve Values (@Id, @MaSoVe, @Gia, @NgayBanVe, @TuyenTauId, @CongTyTDNId)");
            return this.ThucThi(sql, Ve);            
        }
        
        public int Capnhat(Ve Ve)
        {
            string sql = string.Format("Update Ve Set MaSoVe=@MaSoVe, Gia=@Gia, NgayBanVe=@NgayBanVe, TuyenTauId=@TuyenTauId, CongTyTDNId=@CongTyTDNId Where Id=@Id");
            return this.ThucThi(sql, Ve);
        }
        public int Xoa(int Id)
        {
            string sql = string.Format("Delete From Ve Where Id={0} ", Id);
            return LuuTru.ThucThi(sql);
        }

        //------------------------------------------------------------------------------------
        
        public Ve KhoiTao(DataRow row) //convert dataRow thành object
        {
            var Id          = int.Parse(row["Id"].ToString().Trim());
            var MaSoVe      = row["MaSoVe"].ToString().Trim();
            var Gia         = double.Parse(row["Gia"].ToString().Trim());
            var NgayBanVe   = DateTime.Parse(row["NgayBanVe"].ToString());
            var TuyenTauId  = int.Parse(row["TuyenTauId"].ToString().Trim());
            var CongTyTDNId = int.Parse(row["CongTyTDNId"].ToString().Trim());

            Ve item = new Ve(Id, MaSoVe, Gia, NgayBanVe, TuyenTauId, CongTyTDNId);
            return item;
        }
        public int ThucThi(string sql, Ve Ve) //Thêm hay cập nhật giá trị vào SQL
        {
            SqlCommand sqlCommand = new SqlCommand(sql, LuuTru.conn); //phải mở và đóng SqlConnection
            LuuTru.conn.Open();

            sqlCommand.Parameters.AddWithValue("@Id", Ve.Id);
            sqlCommand.Parameters.AddWithValue("@MaSoVe", Ve.MaSoVe);
            sqlCommand.Parameters.AddWithValue("@Gia", Ve.Gia);
            sqlCommand.Parameters.AddWithValue("@NgayBanVe", Ve.NgayBanVe);
            sqlCommand.Parameters.AddWithValue("@TuyenTauId", Ve.TuyenTauId);
            sqlCommand.Parameters.AddWithValue("@CongTyTDNId", Ve.CongTyTDNId);

            var result = sqlCommand.ExecuteNonQuery();
            LuuTru.conn.Close();
            return result; //trả về số dòng kết quả
        }







    }
}
