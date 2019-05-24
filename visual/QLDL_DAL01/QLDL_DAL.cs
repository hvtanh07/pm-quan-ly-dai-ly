using QLDL_DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
            query += "INSERT INTO [tblHoSoDaiLy] ([maDaiLy], [tenDaiLy], [diachi],[email], [loaiDaiLy], [ngayTiepNhan], [quan], [dienthoai], [dientich], [sonhanvien])";
            query += "VALUES (@maDaiLy, @tenDaiLy, @diachi, @email, @loaiDaiLy,@ngayTiepNhan , @quan, @dienthoai, @dientich, @sonhanvien)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maDaiLy", HoSo.madl);
                    cmd.Parameters.AddWithValue("@tenDaiLy", HoSo.tendaily);
                    cmd.Parameters.AddWithValue("@diachi", HoSo.diachi);
                    cmd.Parameters.AddWithValue("@email", HoSo.email);
                    cmd.Parameters.AddWithValue("@loaiDaiLy", HoSo.loaidaily);
                    cmd.Parameters.AddWithValue("@ngayTiepNhan", HoSo.ngaytiepnhan);
                    cmd.Parameters.AddWithValue("@quan", HoSo.quan);
                    cmd.Parameters.AddWithValue("@dienthoai", HoSo.dienthoai);
                    cmd.Parameters.AddWithValue("@dientich", HoSo.dientich);
                    cmd.Parameters.AddWithValue("@sonhanvien", HoSo.sonhanvien);

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
            string query = string.Empty;
            query += "UPDATE tblHoSoDaiLy SET [tenDaiLy] = @tenDaiLy, [diachi] = @diachi, [email] = @email, [loaiDaiLy] = @loaiDaiLy, [quan] = @quan, [dienthoai] = @dienthoai, [dientich] = @dientich, [sonhanvien] = @sonhanvien WHERE [maDaiLy] = @maDaiLy";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maDaiLy", HoSo.madl);
                    cmd.Parameters.AddWithValue("@tenDaiLy", HoSo.tendaily);
                    cmd.Parameters.AddWithValue("@diachi", HoSo.diachi);
                    cmd.Parameters.AddWithValue("@email", HoSo.email);
                    cmd.Parameters.AddWithValue("@loaiDaiLy", HoSo.loaidaily);                   
                    cmd.Parameters.AddWithValue("@quan", HoSo.quan);
                    cmd.Parameters.AddWithValue("@dienthoai", HoSo.dienthoai);
                    cmd.Parameters.AddWithValue("@dientich", HoSo.dientich);
                    cmd.Parameters.AddWithValue("@sonhanvien", HoSo.sonhanvien);
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

            public bool Xoa(CHoSoDaiLyDTO HoSo)
            {
            string query = string.Empty;
            query += "DELETE FROM tblHoSoDaiLy WHERE [maDaiLy] = @maDaiLy";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maKieuNau", HoSo.madl);
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
            public List<CHoSoDaiLyDTO> select()
            {
                return null;
            }
        }
}
