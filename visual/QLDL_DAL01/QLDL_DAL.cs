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
            query += "INSERT INTO [tblHoSoDaiLy] ([maDaiLy], [tenDaiLy], [diachi],[email], [loaiDaiLy], [ngayTiepNhan], [quan], [dienthoai], [dientich], [sonhanvien], [nohientai])";
            query += "VALUES (@maDaiLy, @tenDaiLy, @diachi, @email, @loaiDaiLy,@ngayTiepNhan , @quan, @dienthoai, @dientich, @sonhanvien, @nohientai)";
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
                    cmd.Parameters.AddWithValue("@nohientai", HoSo.nohientai);

                    //try
                    //{
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        con.Dispose();
                    //}
                    //catch (Exception ex)
                    //{
                    //    con.Close();
                    //    return false;
                    //}
                }
            }
            return true;
        }
        public bool Sua(CHoSoDaiLyDTO HoSo)
        {
            string query = string.Empty;
            query += "UPDATE tblHoSoDaiLy SET [tenDaiLy] = @tenDaiLy, [diachi] = @diachi, [email] = @email, [loaiDaiLy] = @loaiDaiLy, [quan] = @quan, [dienthoai] = @dienthoai, [dientich] = @dientich, [sonhanvien] = @sonhanvien,[nohientai] = @nohientai WHERE [maDaiLy] = @maDaiLy";

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
                    cmd.Parameters.AddWithValue("@nohientai", HoSo.nohientai);
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
            query += "SELECT [maDaiLy],[tenDaiLy],[diachi],[email],[loaiDaiLy],[dientich],[sonhanvien],[ngayTiepNhan],[quan],[dienthoai],[nohientai]";
            query += "FROM [tblHoSoDaiLy]";

            List<CHoSoDaiLyDTO> listHoSoDaiLy = new List<CHoSoDaiLyDTO>();

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
                                hs.email = reader["email"].ToString();
                                hs.loaidaily = int.Parse(reader["loaiDaiLy"].ToString());
                                hs.dientich = int.Parse(reader["dientich"].ToString());
                                hs.sonhanvien = int.Parse(reader["sonhanvien"].ToString());
                                hs.ngaytiepnhan= Convert.ToDateTime(reader["ngayTiepNhan"].ToString());
                                hs.quan = reader["quan"].ToString();
                                hs.dienthoai = reader["dienthoai"].ToString();    
                                hs.nohientai= int.Parse(reader["nohientai"].ToString());
                                listHoSoDaiLy.Add(hs);
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
            return listHoSoDaiLy;
        }

        public List<CHoSoDaiLyDTO> selectByKeyWord(string sKeyword)
        {
            string query = string.Empty;
            query += " SELECT [maDaiLy],[tenDaiLy],[diachi],[email],[loaiDaiLy],[dientich],[sonhanvien],[ngayTiepNhan],[quan],[dienthoai],[nohientai]";
            query += " FROM [tblHoSoDaiLy]";
            query += " WHERE ([maDaiLy] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([tenDaiLy] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([diachi] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([email] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([loaiDaiLy] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([diachi] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([dientich] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([sonhanvien] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([ngayTiepNhan] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([quan] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([dienthoai] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([nohientai] LIKE CONCAT('%',@sKeyword,'%'))";
            
            List<CHoSoDaiLyDTO> listHoSoDaiLy = new List<CHoSoDaiLyDTO>();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@sKeyword", sKeyword);
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
                                hs.email = reader["email"].ToString();
                                hs.loaidaily = int.Parse(reader["loaiDaiLy"].ToString());
                                hs.dientich = int.Parse(reader["dientich"].ToString());
                                hs.sonhanvien = int.Parse(reader["sonhanvien"].ToString());
                                hs.ngaytiepnhan = Convert.ToDateTime(reader["ngayTiepNhan"].ToString());
                                hs.quan = reader["quan"].ToString();
                                hs.dienthoai = reader["dienthoai"].ToString();
                                hs.nohientai = int.Parse(reader["nohientai"].ToString());
                                listHoSoDaiLy.Add(hs);
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
            return listHoSoDaiLy;
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
            string query = string.Empty;
            query += "SELECT [maMatHang], [tenmathang], [soluong], [khoiluong], [hanSuDung], [gia], [donViTinh]";
            query += "FROM [tblMatHang]";

            List<DanhsachmathangDTO> listMatHang = new List<DanhsachmathangDTO>();

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
                                DanhsachmathangDTO mh = new DanhsachmathangDTO();
                                mh.Mamh = int.Parse(reader["maMatHang"].ToString());
                                mh.tenmh = reader["tenmathang"].ToString();
                                mh.soluong = int.Parse(reader["soluong"].ToString());
                                mh.khoiluong = int.Parse(reader["khoiluong"].ToString());
                                mh.hansudung = Convert.ToDateTime(reader["hanSuDung"].ToString());
                                mh.gia = int.Parse(reader["gia"].ToString()); 
                                mh.donvitinh = reader["donViTinh"].ToString();
                                listMatHang.Add(mh);
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
            return listMatHang;
        }

        public List<DanhsachmathangDTO> selectByKeyWord(string sKeyword)
        {
            string query = string.Empty;
            query += " SELECT [maMatHang], [tenmathang], [soluong], [khoiluong], [hanSuDung], [gia], [donViTinh]";
            query += " FROM [tblMatHang]";
            query += " WHERE ([maMatHang] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([tenmathang] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([soluong] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([khoiluong] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([hanSuDung] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([gia] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([donViTinh] LIKE CONCAT('%',@sKeyword,'%'))";

            List<DanhsachmathangDTO> listMatHang = new List<DanhsachmathangDTO>();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@sKeyword", sKeyword);
                    try
                    {
                        con.Open();
                        SqlDataReader reader = null;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                DanhsachmathangDTO mh = new DanhsachmathangDTO();
                                mh.Mamh = int.Parse(reader["maMatHang"].ToString());
                                mh.tenmh = reader["tenmathang"].ToString();
                                mh.soluong = int.Parse(reader["soluong"].ToString());
                                mh.khoiluong = int.Parse(reader["khoiluong"].ToString());
                                mh.hansudung = Convert.ToDateTime(reader["hanSuDung"].ToString());
                                mh.gia = int.Parse(reader["gia"].ToString());
                                mh.donvitinh = reader["donViTinh"].ToString();
                                listMatHang.Add(mh);
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
            return listMatHang;
        }

    }
   
}
