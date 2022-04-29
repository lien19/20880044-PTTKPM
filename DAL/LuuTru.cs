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
    public class LuuTru
    {
        //------------------------Thành phần dữ liệu
        public SqlConnection conn { get; set; }
        string path = @"Data Source=PVNOTHI-7MLA3V1\SQLEXPRESS;Initial Catalog=e-Metro;" + "Integrated Security=True";
        string chuoi = string.Empty;

        public LuuTru()
        {            
            conn = new SqlConnection(path);
        }

        //-----------------------Thành phần xử lý
        public DataTable LayDS (string sql)
        {            
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, conn);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            return dataTable;
        }
        
        public int ThucThi (string sql)
        {
            SqlCommand sqlCommand = new SqlCommand(sql, conn); //phải mở và đóng SqlConnection
            conn.Open();
            var result = sqlCommand.ExecuteNonQuery();
            conn.Close();
            return result; //trả về số dòng kết quả
        }
        




    }
}
