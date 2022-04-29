using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class LuuTru_NguoiDung
    {
        LuuTru LuuTru = new LuuTru();

        public List<NguoiDung> LayDS_CoDieuKien(string PhanLoai, string CongTyTDNId)
        {
            string sql = string.Format("Select * from NguoiDung Where PhanLoai = '{0}' AND CongTyTDNId = '{1}'", PhanLoai, CongTyTDNId);
            
            List<NguoiDung> danhsach = new List<NguoiDung>();
            DataTable DataTable = LuuTru.LayDS(sql);

            if (DataTable == null && DataTable.Rows.Count ==0)
                return null;

            foreach (DataRow row in DataTable.Rows)
            {
                NguoiDung item = this.KhoiTao(row);
                danhsach.Add(item);
            }
            return danhsach;
        }
        public List<NguoiDung> LayDS_DangNhap(string PhanLoai)
        {
            string sql = string.Format("Select * from NguoiDung Where PhanLoai = '{0}'", PhanLoai);

            List<NguoiDung> danhsach = new List<NguoiDung>();
            DataTable DataTable = LuuTru.LayDS(sql);

            if (DataTable == null && DataTable.Rows.Count == 0)
                return null;

            foreach (DataRow row in DataTable.Rows)
            {
                NguoiDung item = this.KhoiTao(row);
                danhsach.Add(item);
            }
            return danhsach;
        }
        public List<NguoiDung> LayDS()
        {
            string sql = string.Format("Select * from NguoiDung");
            List<NguoiDung> danhsach = new List<NguoiDung>();
            DataTable DataTable = LuuTru.LayDS(sql);

            if (DataTable == null && DataTable.Rows.Count == 0)
                return null;

            foreach (DataRow row in DataTable.Rows)
            {
                NguoiDung item = this.KhoiTao(row);
                danhsach.Add(item);
            }
            return danhsach;
        }
        public NguoiDung Doc(int Id, string PhanLoai, string CongTyTDNId) //có 2 cách Đọc 1 dòng để lấy thông tin lên popup : 1 là query trong bảng, 2 là query sau khi lấy danh sách
        {
            var danhsach = this.LayDS_CoDieuKien(PhanLoai, CongTyTDNId);
            if (danhsach == null)
                return null;
            return danhsach.FirstOrDefault(p => p.Id == Id);
        }
        public int Them(NguoiDung NguoiDung)
        {
            //Tính "NguoiDung.Id"  
            List<NguoiDung> danhsach = this.LayDS();
            if (danhsach == null)
                NguoiDung.Id = 1;
            else
            {
                int maxId = danhsach.Max(p => p.Id); //duyệt dòng, sau đó duyệt cột
                NguoiDung.Id = maxId + 1;
            }
            //format DateTime => tránh lỗi: conversion of a varchar data type to a datetime data type resulted in an out-of-range value error
            string sql = string.Format("Insert into NguoiDung Values (@Id, @Email, @Password, @PhanLoai, @ThoiGian, @CongTyTDNId, @QuanTriHeThong)");

            return this.ThucThi(sql, NguoiDung);
        }

        public int Capnhat(NguoiDung NguoiDung)
        {
            string sql = string.Format("Update NguoiDung Set Email=@Email, Password=@Password, PhanLoai=@PhanLoai, ThoiGian=@ThoiGian, CongTyTDNId=@CongTyTDNId, QuanTriHeThong=@QuanTriHeThong  Where Id=@Id");
            return this.ThucThi(sql, NguoiDung);
        }
        public int Xoa(int Id)
        {
            string sql = string.Format("Delete From NguoiDung Where Id={0} ", Id);
            return LuuTru.ThucThi(sql);
        }

        //-------------------------------------------------------------------------
        public NguoiDung KhoiTao(DataRow row)
        {
            var Id             = int.Parse(row["Id"].ToString().Trim());
            var Email          = row["Email"].ToString().Trim();
            var Password       = row["Password"].ToString().Trim();
            var PhanLoai       = row["PhanLoai"].ToString().Trim();
            DateTime ThoiGian  = DateTime.Parse(row["ThoiGian"].ToString().Trim());
            var CongTyTDNId    = string.IsNullOrEmpty(row["CongTyTDNId"].ToString().Trim())? 0: int.Parse(row["CongTyTDNId"].ToString().Trim());
            var QuanTriHeThong = string.IsNullOrEmpty(row["QuanTriHeThong"].ToString().Trim())? 0: int.Parse(row["QuanTriHeThong"].ToString().Trim());

            NguoiDung item = new NguoiDung(Id, Email, Password, PhanLoai, ThoiGian, CongTyTDNId, QuanTriHeThong);
            return item;
        }

        public int ThucThi(string sql, NguoiDung NguoiDung) //convert dataRow thành object
        {
            SqlCommand sqlCommand = new SqlCommand(sql, LuuTru.conn); //phải mở và đóng SqlConnection
            LuuTru.conn.Open();

            sqlCommand.Parameters.AddWithValue("@Id", NguoiDung.Id);
            sqlCommand.Parameters.AddWithValue("@Email", NguoiDung.Email);
            sqlCommand.Parameters.AddWithValue("@Password", NguoiDung.Password);
            sqlCommand.Parameters.AddWithValue("@PhanLoai", NguoiDung.PhanLoai);
            sqlCommand.Parameters.AddWithValue("@ThoiGian", NguoiDung.ThoiGian);
            //sqlCommand.Parameters.AddWithValue("@CongTyTDNId", (Object)NguoiDung.CongTyTDNId ?? DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@CongTyTDNId", NguoiDung.CongTyTDNId);
            sqlCommand.Parameters.AddWithValue("@QuanTriHeThong", NguoiDung.QuanTriHeThong);

            var result = sqlCommand.ExecuteNonQuery();
            LuuTru.conn.Close();
            return result;
        }





    }
}
