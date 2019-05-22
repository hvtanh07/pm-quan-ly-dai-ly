using QLDL_DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QLDL_DAL
{
    public class CHoSoDaiLyDAL
    {
        private string connectionString;

        public CHoSoDaiLyDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }

        public string ConnectionString { get => connectionString; set => connectionString = value; }

        public bool Them(CHoSoDaiLyDTO HoSo)
        {
            string query = string.Empty;
            query += "INSERT INTO [tblKieuNau] ([maKieuNau], [tenKieuNau], [mota])";
            query += "VALUES (@maKieuNau,@tenKieuNau,@mota)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maKieuNau", kn.Ma);
                    cmd.Parameters.AddWithValue("@tenKieuNau", kn.Ten);
                    cmd.Parameters.AddWithValue("@mota", kn.Mota);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return false;
                    }
                }
            }
            return true;
        }
        public bool Sua(CHoSoDaiLyDTO HoSo)
        {
            return true;
        }

        public bool Xoa(CHoSoDaiLyDTO HoSo)
        {
            return true;
        }
        public List<CHoSoDaiLyDTO> select()
        {
            return null;
        }
    }
}
