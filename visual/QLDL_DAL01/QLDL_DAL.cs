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
                    cmd.Parameters.AddWithValue("@maDaiLy", HoSo.madl);
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
            string query = string.Empty;
            query += "SELECT [maDaiLy],[tenDaiLy],[diachi],[email],[loaiDaiLy],[dientich],[sonhanvien],[ngayTiepNhan],[quan],[dienthoai]";
            query += "FROM [tblHoSoDaiLy]";

            List<CHoSoDaiLyDTO> lsHoSoDaiLy = new List<CHoSoDaiLyDTO>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;

                    try
                    {
                        con.Open();
                        SqlDataReader reader = null;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                CHoSoDaiLyDTO hs = new CHoSoDaiLyDTO();
                                hs.madl = int.Parse(reader["maDaiLy"].ToString());
                                hs.tendaily = reader["tenDaiLy"].ToString();
                                hs.diachi = reader["diachi"].ToString();
                                hs.dienthoai = reader["dienthoai"].ToString();
                                hs.dientich = int.Parse(reader["dientich"].ToString());
                                hs.email = reader["dientich"].ToString();
                                hs.loaidaily= int.Parse(reader["dientich"].ToString());
                                hs.dientich = int.Parse(reader["dientich"].ToString());
                                lsHoSoDaiLy.Add(hs);
                            }
                        }

                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return null;
                    }
                }
            }
            return lsHoSoDaiLy;
        }
    }
    public class CMatHangDAL
    {
        private string connectionString;

        public CMatHangDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }

        public string ConnectionString { get => connectionString; set => connectionString = value; }

        public bool Them(DanhsachmathangDTO MH)
        {
            string query = string.Empty;
            query += "INSERT INTO [dbo].[tblMatHang] ([maMatHang], [tenmathang], [soluong], [khoiluong], [hanSuDung], [gia], [donViTinh])";
            query += "VALUES (@maMatHang, @tenmathang, @soluong, @khoiluong, @hanSuDung, @gia, @donViTinh)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maMatHang", MH.Mamh);
                    cmd.Parameters.AddWithValue("@tenmathang", MH.tenmh);
                    cmd.Parameters.AddWithValue("@soluong", MH.soluong);
                    cmd.Parameters.AddWithValue("@khoiluong", MH.khoiluong);
                    cmd.Parameters.AddWithValue("@hanSuDung", MH.hansudung);
                    cmd.Parameters.AddWithValue("@gia", MH.gia);
                    cmd.Parameters.AddWithValue("@donViTinh", MH.donvitinh);

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
        public bool Sua(DanhsachmathangDTO MH)
        {
            string query = string.Empty;
            query += "UPDATE tblMatHang SET [tenmathang]=@tenmathang, [soluong] = @soluong, [khoiluong] = @khoiluong, [hanSuDung] = @hanSuDung, [gia] = @gia, [donViTinh] = @donViTinh WHERE [maMatHang] = @maMatHang";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maMatHang", MH.Mamh);
                    cmd.Parameters.AddWithValue("@tenmathang", MH.tenmh);
                    cmd.Parameters.AddWithValue("@soluong", MH.soluong);
                    cmd.Parameters.AddWithValue("@khoiluong", MH.khoiluong);
                    cmd.Parameters.AddWithValue("@hanSuDung", MH.hansudung);
                    cmd.Parameters.AddWithValue("@gia", MH.gia);
                    cmd.Parameters.AddWithValue("@donViTinh", MH.donvitinh);
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

        public bool Xoa(DanhsachmathangDTO MH)
        {
            string query = string.Empty;
            query += "DELETE FROM tblMatHang WHERE [maMatHang] = @maMatHang";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maMatHang", MH.Mamh);
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
        public List<DanhsachmathangDTO> select()
        {
            return null;
        }

    }
   
}
