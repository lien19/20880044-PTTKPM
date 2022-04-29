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
    public class LuuTru_TuyenTau
    {
        LuuTru LuuTru = new LuuTru();

        public List<TuyenTau> LayDS_CoDieuKien(string CongTyTDNId ) //Lọc theo CongTyTDNId và QuanTriHeThong
        {
            string sql = string.Format("Select * from TuyenTau Where CongTyTDNId='{0}'", CongTyTDNId);

            List<TuyenTau> danhsach = new List<TuyenTau>();
            DataTable DataTable = LuuTru.LayDS(sql);
            if (DataTable.Rows.Count == 0)
                return null;

            foreach (DataRow row in DataTable.Rows)
            {
                TuyenTau item = this.KhoiTao(row);
                danhsach.Add(item);
            }
            return danhsach;
        }
        public List<TuyenTau> LayDS() //lấy tất cả danh sách
        {
            string sql = string.Format("Select * from TuyenTau");

            List<TuyenTau> danhsach = new List<TuyenTau>();
            DataTable DataTable = LuuTru.LayDS(sql);
            if (DataTable.Rows.Count == 0)
                return null;

            foreach (DataRow row in DataTable.Rows)
            {
                TuyenTau item = this.KhoiTao(row);
                danhsach.Add(item);
            }
            return danhsach;
        }
        public TuyenTau Doc(int Id, string CongTyTDNId ) //có 2 cách Đọc 1 dòng để lấy thông tin lên popup : 1 là query trong bảng, 2 là query sau khi lấy danh sách
        {
            var danhsach = this.LayDS_CoDieuKien(CongTyTDNId);
            if (danhsach == null)
                return null;
            return danhsach.FirstOrDefault(p => p.Id == Id);
        }
        public int Them(TuyenTau TuyenTau)  //chỉ thêm mới cần LayDS_admin() để tính Id max
        {
            //------Tính: TuyenTau.Id
            List<TuyenTau> danhsach = this.LayDS();
            int maxId = 0;
            if (danhsach != null)
                maxId = danhsach.Max(p => p.Id); //duyệt dòng, sau đó duyệt cột
            TuyenTau.Id = maxId + 1;

            //------use "sqlCommand.Parameters.AddWithValue" to avoid error of conversion
            string sql = string.Format("Insert into TuyenTau Values (@Id, @MaSoTuyenTau, @TenTuyenTau, @GiaVeHienHanh, @GioBatDau, @GioKetThuc, @ThoiGianCho2Chuyen, @TinhTrang, @GaBatDauId, @GaKetThucId, @CongTyTDNId)");
            return this.ThucThi(sql, TuyenTau); //trả về số dòng kết quả
        }
        public int Capnhat(TuyenTau TuyenTau)
        {
            //------use "sqlCommand.Parameters.AddWithValue" to avoid error of conversion
            string sql = string.Format("Update TuyenTau Set MaSoTuyenTau=@MaSoTuyenTau, TenTuyenTau=@TenTuyenTau, GiaVeHienHanh=@GiaVeHienHanh, GioBatDau=@GioBatDau, GioKetThuc=@GioKetThuc, ThoiGianCho2Chuyen=@ThoiGianCho2Chuyen, TinhTrang=@TinhTrang, GaBatDauId=@GaBatDauId, GaKetThucId=@GaKetThucId, CongTyTDNId=@CongTyTDNId Where Id=@Id");
            return this.ThucThi(sql, TuyenTau); //trả về số dòng kết quả
        }

        public int Xoa(int Id)
        {
            string sql = string.Format("Delete From TuyenTau Where Id={0} ", Id);
            return LuuTru.ThucThi(sql);
        }
        //------------------------------------------------------------------------------
        public int ThucThi(string sql, TuyenTau TuyenTau) //Thêm hay cập nhật giá trị vào SQL
        {
            SqlCommand sqlCommand = new SqlCommand(sql, LuuTru.conn); //phải mở và đóng SqlConnection
            LuuTru.conn.Open();

            sqlCommand.Parameters.AddWithValue("@Id", TuyenTau.Id);
            sqlCommand.Parameters.AddWithValue("@MaSoTuyenTau", TuyenTau.MaSoTuyenTau);
            sqlCommand.Parameters.AddWithValue("@TenTuyenTau", TuyenTau.TenTuyenTau);
            sqlCommand.Parameters.AddWithValue("@GiaVeHienHanh", TuyenTau.GiaVeHienHanh);
            sqlCommand.Parameters.AddWithValue("@GioBatDau", TuyenTau.GioBatDau);
            sqlCommand.Parameters.AddWithValue("@GioKetThuc", TuyenTau.GioKetThuc);
            sqlCommand.Parameters.AddWithValue("@ThoiGianCho2Chuyen", TuyenTau.ThoiGianCho2Chuyen);
            sqlCommand.Parameters.AddWithValue("@TinhTrang", TuyenTau.TinhTrang);
            sqlCommand.Parameters.AddWithValue("@GaBatDauId", TuyenTau.GaBatDauId);
            sqlCommand.Parameters.AddWithValue("@GaKetThucId", TuyenTau.GaKetThucId);
            sqlCommand.Parameters.AddWithValue("@CongTyTDNId", TuyenTau.CongTyTDNId);

            var result = sqlCommand.ExecuteNonQuery();
            LuuTru.conn.Close();
            return result; //trả về số dòng kết quả
        }
        public TuyenTau KhoiTao(DataRow row) //convert dataRow thành object
        {
            var Id                 = int.Parse(row["Id"].ToString().Trim());
            var MaSoTuyenTau       = row["MaSoTuyenTau"].ToString().Trim();
            var TenTuyenTau        = row["TenTuyenTau"].ToString().Trim();
            var GiaVeHienHanh      = double.Parse(row["GiaVeHienHanh"].ToString().Trim());
            var GioBatDau          = row["GioBatDau"].ToString().Trim();
            var GioKetThuc         = row["GioKetThuc"].ToString().Trim();
            var ThoiGianCho2Chuyen = double.Parse(row["ThoiGianCho2Chuyen"].ToString().Trim());
            var TinhTrang          = row["TinhTrang"].ToString().Trim();
            var GaBatDauId         = int.Parse(row["GaBatDauId"].ToString().Trim());
            var GaKetThucId        = int.Parse(row["GaKetThucId"].ToString().Trim());
            var CongTyTDNId        = int.Parse(row["CongTyTDNId"].ToString().Trim());

            TuyenTau item = new TuyenTau(Id, MaSoTuyenTau, TenTuyenTau, GiaVeHienHanh, GioBatDau, GioKetThuc, ThoiGianCho2Chuyen, TinhTrang, GaBatDauId, GaKetThucId, CongTyTDNId);
            return item;
        }






    }
}
