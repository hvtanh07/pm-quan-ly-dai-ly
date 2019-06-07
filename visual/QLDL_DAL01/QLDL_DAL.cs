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
            query += " INSERT INTO [tblHoSoDaiLy] ([maDaiLy], [tenDaiLy], [diachi],[email], [maloaiDaiLy], [ngayTiepNhan], [quan], [dienthoai], [nohientai])";
            query += " VALUES (@maDaiLy, @tenDaiLy, @diachi, @email, @maloaiDaiLy,@ngayTiepNhan , @quan, @dienthoai, @nohientai)";
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
                    cmd.Parameters.AddWithValue("@maloaiDaiLy", HoSo.loaidaily);
                    cmd.Parameters.AddWithValue("@ngayTiepNhan", HoSo.ngaytiepnhan);
                    cmd.Parameters.AddWithValue("@quan", HoSo.quan);
                    cmd.Parameters.AddWithValue("@dienthoai", HoSo.dienthoai);
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
        public bool Sua(CHoSoDaiLyDTO HoSo)
        {
            string query = string.Empty;
            query += " UPDATE tblHoSoDaiLy SET [tenDaiLy] = @tenDaiLy, [diachi] = @diachi, [email] = @email, [maloaiDaiLy] = @maloaiDaiLy, [quan] = @quan, [dienthoai] = @dienthoai, [nohientai] = @nohientai WHERE [maDaiLy] = @maDaiLy";

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
                    cmd.Parameters.AddWithValue("@maloaiDaiLy", HoSo.loaidaily);
                    cmd.Parameters.AddWithValue("@quan", HoSo.quan);
                    cmd.Parameters.AddWithValue("@dienthoai", HoSo.dienthoai);
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
            query += " DELETE FROM tblHoSoDaiLy WHERE [maDaiLy] = @maDaiLy";

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
            query += " SELECT [maDaiLy],[tenDaiLy],[diachi],[email],[maloaiDaiLy],[ngayTiepNhan],[quan],[dienthoai],[nohientai]";
            query += " FROM [tblHoSoDaiLy]";

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
                                hs.madl = reader["maDaiLy"].ToString();
                                hs.tendaily = reader["tenDaiLy"].ToString();
                                hs.diachi = reader["diachi"].ToString();
                                hs.email = reader["email"].ToString();
                                hs.loaidaily = reader["maloaiDaiLy"].ToString();
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
            query += " SELECT [maDaiLy],[tenDaiLy],[diachi],[email],[maloaiDaiLy],[ngayTiepNhan],[quan],[dienthoai],[nohientai]";
            query += " FROM [tblHoSoDaiLy]";
            query += " WHERE ([maDaiLy] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([tenDaiLy] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([diachi] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([email] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([maloaiDaiLy] LIKE CONCAT('%',@sKeyword,'%'))";
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
                                hs.madl = reader["maDaiLy"].ToString();
                                hs.tendaily = reader["tenDaiLy"].ToString();
                                hs.diachi = reader["diachi"].ToString();
                                hs.email = reader["email"].ToString();
                                hs.loaidaily = reader["maloaiDaiLy"].ToString();
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
        public List<string> Laymadl()
        {
            List<string> dsmadl = new List<string>();
            string query = string.Empty;
            query += " SELECT [maDaiLy]";
            query += " FROM [tblHoSoDaiLy]";           
            using (SqlConnection con = new SqlConnection(ConnectionString))
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
                                string madl = reader["maDaiLy"].ToString();
                                dsmadl.Add(madl);
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
            return dsmadl;
        }
        public int Laytienno(string madl)
        {
            int tienno = 0;
            string query = string.Empty;
            query += " SELECT [nohientai]";
            query += " FROM [tblHoSoDaiLy]";
            query += " WHERE ([maDaiLy] LIKE CONCAT('%',@sKeyword,'%'))";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@sKeyword", madl);
                    try
                    {
                        con.Open();
                        SqlDataReader reader = null;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            reader.Read();
                            tienno = int.Parse(reader["nohientai"].ToString());
                        }

                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return 0;
                    }
                }
            }
            return tienno;
        }
        public int Laysodaily(string quan)
        {
            int sodl = 0;
            string query = string.Empty;
            query += " SELECT COUNT(*) as [sodl]";
            query += " FROM tblHoSoDaiLy";
            query += " WHERE quan = @sKeyword";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@sKeyword", quan);
                    try
                    {
                        con.Open();
                        SqlDataReader reader = null;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            reader.Read();
                            sodl = int.Parse(reader["sodl"].ToString());
                        }

                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return 0;
                    }
                }
            }
            return sodl;
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
            query += " INSERT INTO [dbo].[tblMatHang] ([maMatHang],[tenmathang], [hanSuDung], [gia], [donViTinh])";
            query += " VALUES (@maMatHang,@tenmathang,@hanSuDung, @gia, @donViTinh)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maMatHang", MH.mamh);
                    cmd.Parameters.AddWithValue("@tenmathang", MH.tenmh);
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
            query += "UPDATE tblMatHang SET [tenmathang]=@tenmathang, [hanSuDung] = @hanSuDung, [gia] = @gia, [donViTinh] = @donViTinh WHERE [maMatHang]=@maMatHang";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maMatHang", MH.mamh);
                    cmd.Parameters.AddWithValue("@tenmathang", MH.tenmh);
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
            query += "DELETE FROM tblMatHang WHERE [maMatHang]=@maMatHang";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maMatHang", MH.mamh);
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
            query += " SELECT [maMatHang], [tenmathang], [hanSuDung], [gia], [donViTinh]";
            query += " FROM [tblMatHang]";

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
                                mh.mamh = reader["maMatHang"].ToString();
                                mh.tenmh = reader["tenmathang"].ToString();
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
            query += " SELECT [maMatHang], [tenmathang], [hanSuDung], [gia], [donViTinh]";
            query += " FROM [tblMatHang]";
            query += " WHERE ([maMatHang] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([tenmathang] LIKE CONCAT('%',@sKeyword,'%'))";
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
                                mh.mamh = reader["maMatHang"].ToString();
                                mh.tenmh = reader["tenmathang"].ToString();
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
        public List<string> Laymamh()
        {
            List<string> dsmamh = new List<string>();
            string query = string.Empty;
            query += " SELECT [maMatHang]";
            query += " FROM [tblMatHang]";
            using (SqlConnection con = new SqlConnection(ConnectionString))
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
                                string mamh = reader["maMatHang"].ToString();
                                dsmamh.Add(mamh);
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
            return dsmamh;
        }
        public int Laygiatienmh(string mamh)
        {
            int gia =0;
            string query = string.Empty;
            query += " SELECT [gia]";
            query += " FROM [tblMatHang]";
            query += " WHERE ([maMatHang] LIKE CONCAT('%',@sKeyword,'%'))";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {               
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@sKeyword", mamh);
                    try
                    {
                        con.Open();
                        SqlDataReader reader = null;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            reader.Read();
                            gia = int.Parse(reader["gia"].ToString());
                        }

                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return 0;
                    }
                }
            }
            return gia;
        }
        public int Laysomathang()
        {
            int somh = 0;
            string query = string.Empty;
            query += " SELECT COUNT(*) as [somh]";
            query += " FROM tblHoSoDaiLy";
            using (SqlConnection con = new SqlConnection(ConnectionString))
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
                            reader.Read();
                            somh = int.Parse(reader["somh"].ToString());
                        }

                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return 0;
                    }
                }
            }
            return somh;
        }
    }
    public class CQuiDinhDAL
    {
        private string connectionString;

        public CQuiDinhDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }

        public string ConnectionString { get => connectionString; set => connectionString = value; }//chỉnh sửa qui định

        public bool Sua(QuiDinhDTO QD)
        {
            string query = string.Empty;
            query += " UPDATE tblQuiDinh SET [maxloaidl] = @maxloaidl, [soluongmathang] = @soluongmathang, [soluongdvt] = @soluongdvt, [maxdl] = @maxdl WHERE [getkey]=@getkey";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maxloaidl", QD.Maxloaidl);
                    cmd.Parameters.AddWithValue("@soluongmathang", QD.soluongMH);
                    cmd.Parameters.AddWithValue("@soluongdvt", QD.soluongDVT);
                    cmd.Parameters.AddWithValue("@maxdl", QD.Maxsodl);
                    cmd.Parameters.AddWithValue("@getkey", 1);
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
        public QuiDinhDTO Laydulieu()//Lấy dữ liệu
        {
            QuiDinhDTO re = new QuiDinhDTO();            
            string query = string.Empty;
            query += " SELECT [maxloaidl],[soluongmathang],[soluongdvt],[maxdl]";
            query += " FROM [tblQuiDinh]";
            //query += " WHERE [getkey] LIKE 1";
            using (SqlConnection con = new SqlConnection(ConnectionString))
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
                            reader.Read();                            
                            re.Maxloaidl = int.Parse(reader["maxloaidl"].ToString());
                            re.Maxsodl = int.Parse(reader["maxdl"].ToString());
                            re.soluongDVT = int.Parse(reader["soluongdvt"].ToString());
                            re.soluongMH = int.Parse(reader["soluongmathang"].ToString());                          
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
            return re;
        }        
    }
    public class CLoaiDaiLyDAL
    {
        private string connectionString;
        public CLoaiDaiLyDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }
        public string ConnectionString { get => connectionString; set => connectionString = value; }//chỉnh sửa qui định
        public bool Sua(LoaiDaiLyDTO LDL)
        {
            string query = string.Empty;
            query += "UPDATE tblLoaiDaiLy SET [loaiDaiLy]=@loaiDaiLy, [maxno] = @maxno WHERE [maLoaiDaiLy]=@maLoaiDaiLy";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maLoaiDaiLy", LDL.maLDL);
                    cmd.Parameters.AddWithValue("@maxno", LDL.MaxNo);
                    cmd.Parameters.AddWithValue("@loaiDaiLy", LDL.loaidaily);
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
        public bool Them(LoaiDaiLyDTO LDL)
        {
            string query = string.Empty;
            query += "INSERT INTO [dbo].[tblLoaiDaiLy] ([maLoaiDaiLy], [loaiDaiLy], [maxno])";
            query += "VALUES (@loaiDaiLy,@maxno)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maLoaiDaiLy", LDL.maLDL);
                    cmd.Parameters.AddWithValue("@maxno", LDL.MaxNo);
                    cmd.Parameters.AddWithValue("@loaiDaiLy", LDL.loaidaily);
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
        public bool Xoa(LoaiDaiLyDTO LDL)
        {
            string query = string.Empty;
            query += "DELETE FROM tblLoaiDaiLy WHERE [maLoaiDaiLy]=@maLoaiDaiLy";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maLoaiDaiLy", LDL.maLDL);
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
        public List<string> Layloaidl()
        {
            List<string> dsmaldl = new List<string>();
            string query = string.Empty;
            query += " SELECT [maLoaiDaiLy]";
            query += " FROM [tblLoaiDaiLy]";
            using (SqlConnection con = new SqlConnection(ConnectionString))
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
                                string maldl = reader["maLoaiDaiLy"].ToString();
                                dsmaldl.Add(maldl);
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
            return dsmaldl;
        }
        public List<LoaiDaiLyDTO> select()
        {
            string query = string.Empty;
            query += " SELECT [maLoaiDaiLy], [loaiDaiLy], [maxno]";
            query += " FROM [tblLoaiDaiLy]";

            List<LoaiDaiLyDTO> listloaidl = new List<LoaiDaiLyDTO>();

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
                                LoaiDaiLyDTO ldl = new LoaiDaiLyDTO();
                                ldl.maLDL = reader["maLoaiDaiLy"].ToString();
                                ldl.loaidaily = int.Parse(reader["loaiDaiLy"].ToString());
                                ldl.MaxNo = int.Parse(reader["maxno"].ToString());
                                listloaidl.Add(ldl);
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
            return listloaidl;
        }
        public List<LoaiDaiLyDTO> selectByKeyWord(string sKeyword)
        {
            string query = string.Empty;
            query += " SELECT [maLoaiDaiLy], [loaiDaiLy], [maxno]";
            query += " FROM [tblLoaiDaiLy]";
            query += " WHERE ([maLoaiDaiLy] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([loaiDaiLy] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([maxno] LIKE CONCAT('%',@sKeyword,'%'))";

            List<LoaiDaiLyDTO> listloaidl = new List<LoaiDaiLyDTO>();

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
                                LoaiDaiLyDTO ldl = new LoaiDaiLyDTO();
                                ldl.maLDL = reader["maLoaiDaiLy"].ToString();
                                ldl.loaidaily = int.Parse(reader["loaiDaiLy"].ToString());
                                ldl.MaxNo = int.Parse(reader["maxno"].ToString());
                                listloaidl.Add(ldl);
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
            return listloaidl;
        }
        public int Laysoloaidl()
        {
            int soldl = 0;
            string query = string.Empty;
            query += " SELECT COUNT(*) as [soldl]";
            query += " FROM tblHoSoDaiLy";
            using (SqlConnection con = new SqlConnection(ConnectionString))
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
                            reader.Read();
                            soldl = int.Parse(reader["soldl"].ToString());
                        }

                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return 0;
                    }
                }
            }
            return soldl;
        }
    }
    public class DanhsachDonviDAL
    {
        private string connectionString;

        public DanhsachDonviDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }

        public string ConnectionString { get => connectionString; set => connectionString = value; }//chỉnh sửa qui định
       
        public bool Them(DanhsachDonviDTO dv)
        {
            string query = string.Empty;
            query += "INSERT INTO [dbo].[tblDonvi] ([donViTinh])";
            query += "VALUES (@donViTinh)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@donViTinh", dv.donvitinh);
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
        public bool Xoa(DanhsachDonviDTO dv)
        {
            string query = string.Empty;
            query += "DELETE FROM [dbo].[tblDonvi] WHERE [donViTinh]=@donViTinh";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@donViTinh", dv.donvitinh);
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
        public List<string> Laydonvi()
        {
            List<string> dsdv = new List<string>();
            string query = string.Empty;
            query += " SELECT [donViTinh]";
            query += " FROM [tblDonvi]";
            using (SqlConnection con = new SqlConnection(ConnectionString))
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
                                string madv = reader["donViTinh"].ToString();
                                dsdv.Add(madv);
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
            return dsdv;
        }
        public List<DanhsachDonviDTO> select()
        {
            string query = string.Empty;
            query += " SELECT  [donViTinh]";
            query += " FROM [tblDonvi]";

            List<DanhsachDonviDTO> listdonvi = new List<DanhsachDonviDTO>();

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
                                DanhsachDonviDTO dv = new DanhsachDonviDTO();
                                dv.donvitinh = reader["donViTinh"].ToString();
                                listdonvi.Add(dv);
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
            return listdonvi;
        }
        public List<DanhsachDonviDTO> selectByKeyWord(string sKeyword)
        {
            string query = string.Empty;
            query += " SELECT [donViTinh]";
            query += " FROM [tblDonvi]";
            query += " WHERE ([donViTinh] LIKE CONCAT('%',@sKeyword,'%'))";

            List<DanhsachDonviDTO> listdonvi = new List<DanhsachDonviDTO>();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@sKeyword", sKeyword);
                    //try
                    //{
                        con.Open();
                        SqlDataReader reader = null;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                DanhsachDonviDTO dv = new DanhsachDonviDTO();
                                dv.donvitinh= reader["donViTinh"].ToString();
                                listdonvi.Add(dv);
                            }
                        }

                        con.Close();
                        con.Dispose();
                    //}
                    //catch (Exception ex)
                    //{
                    //    con.Close();
                    //    return null;
                    //}
                }
            }
            return listdonvi;
        }
        public int Laysodonvi()
        {
            int sodv = 0;
            string query = string.Empty;
            query += " SELECT COUNT(*) as [sodv]";
            query += " FROM tblHoSoDaiLy";
            using (SqlConnection con = new SqlConnection(ConnectionString))
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
                            reader.Read();
                            sodv = int.Parse(reader["sodv"].ToString());
                        }

                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        return 0;
                    }
                }
            }
            return sodv;
        }
    }
    public class PhieuxuathangDAL
    {
        private string connectionString;

        public PhieuxuathangDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }

        public string ConnectionString { get => connectionString; set => connectionString = value; }

        public bool Them(PhieuxuathangDTO XH)
        {
            string query = string.Empty;
            query += "INSERT INTO [dbo].[tblPhieuXuatHang] ([maXuatHang],[maDaiLy], [ngayLapPhieu], [tongtien])";
            query += "VALUES (@maXuatHang,@maDaiLy,@ngayLapPhieu, @tongtien)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maXuatHang", XH.maxh);
                    cmd.Parameters.AddWithValue("@maDaiLy", XH.madl);
                    cmd.Parameters.AddWithValue("@ngayLapPhieu", XH.ngaylap);
                    cmd.Parameters.AddWithValue("@tongtien", XH.tongtien);
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
        public bool Sua(PhieuxuathangDTO XH)
        {
            string query = string.Empty;
            query += "UPDATE tblPhieuXuatHang SET [tongtien] = @tongtien WHERE [maXuatHang]=@maXuatHang";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maXuatHang", XH.maxh);
                    cmd.Parameters.AddWithValue("@tongtien", XH.tongtien);
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

        public bool Xoa(PhieuxuathangDTO XH)
        {            
            string query = string.Empty;
            query += "DELETE FROM tblPhieuXuatHang WHERE [maXuatHang]=@maXuatHang";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maXuatHang", XH.maxh);
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
        public List<PhieuxuathangDTO> select()
        {
            string query = string.Empty;
            query += " SELECT [maXuatHang], [maDaiLy], [ngayLapPhieu], [tongtien]";
            query += " FROM [tblPhieuXuatHang]";

            List<PhieuxuathangDTO> listXuatHang = new List<PhieuxuathangDTO>();

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
                                PhieuxuathangDTO XH = new PhieuxuathangDTO();
                                XH.maxh = reader["maXuatHang"].ToString();
                                XH.madl = reader["maDaiLy"].ToString();
                                XH.ngaylap = Convert.ToDateTime(reader["ngayLapPhieu"].ToString());
                                XH.tongtien = int.Parse(reader["tongtien"].ToString());                          
                                listXuatHang.Add(XH);
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
            return listXuatHang;
        }
        public List<PhieuxuathangDTO> selectByKeyWord(string sKeyword)
        {
            string query = string.Empty;
            query += " SELECT [maXuatHang], [maDaiLy], [ngayLapPhieu], [tongtien]";
            query += " FROM [tblPhieuXuatHang]";
            query += " WHERE ([maXuatHang] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([maDaiLy] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([ngayLapPhieu] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([tongtien] LIKE CONCAT('%',@sKeyword,'%'))";

            List<PhieuxuathangDTO> listXuatHang = new List<PhieuxuathangDTO>();

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
                                PhieuxuathangDTO XH = new PhieuxuathangDTO();
                                XH.maxh = reader["maXuatHang"].ToString();
                                XH.madl = reader["maDaiLy"].ToString();
                                XH.ngaylap = Convert.ToDateTime(reader["ngayLapPhieu"].ToString());
                                XH.tongtien = int.Parse(reader["tongtien"].ToString());
                                listXuatHang.Add(XH);
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
            return listXuatHang;
        }
    }
    public class ChitietphieuxuatDAL
    {
        private string connectionString;

        public ChitietphieuxuatDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }

        public string ConnectionString { get => connectionString; set => connectionString = value; }

        public bool Them(ChitietphieuxuatDTO CTXH)
        {
            string query = string.Empty;
            query += "INSERT INTO [dbo].[tblChitietPhieuXuatHang] ([maXuatHang], [maMatHang], [soluong], [tongtien])";
            query += "VALUES (@maXuatHang,@maMatHang,@soluong, @tongtien)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maXuatHang", CTXH.maxh);
                    cmd.Parameters.AddWithValue("@maMatHang", CTXH.mamh);
                    cmd.Parameters.AddWithValue("@soluong", CTXH.soluong);
                    cmd.Parameters.AddWithValue("@tongtien", CTXH.tongtien);
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
        public bool Sua(ChitietphieuxuatDTO CTXH)
        {
            string query = string.Empty;
            query += "UPDATE tblChitietPhieuXuatHang SET [soluong]=@soluong, [tongtien] = @tongtien WHERE [maXuatHang]=@maXuatHang AND [maMatHang]=@maMatHang";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maXuatHang", CTXH.maxh);
                    cmd.Parameters.AddWithValue("@maMatHang", CTXH.mamh);
                    cmd.Parameters.AddWithValue("@soluong", CTXH.soluong);
                    cmd.Parameters.AddWithValue("@tongtien", CTXH.tongtien);
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
        public bool Xoa(ChitietphieuxuatDTO XH)
        {
            string query = string.Empty;
            query += "DELETE FROM tblChitietPhieuXuatHang WHERE [maXuatHang]=@maXuatHang AND [maMatHang]=@maMatHang";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maXuatHang", XH.maxh);
                    cmd.Parameters.AddWithValue("@maMatHang", XH.mamh);
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
        public bool Xoatheophieuxuat(string maxh)
        {
            string query = string.Empty;
            query += "DELETE FROM tblChitietPhieuXuatHang WHERE [maXuatHang]=@maXuatHang ";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maXuatHang", maxh);                   
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
        public List<ChitietphieuxuatDTO> select(string maxh)
        {
            string query = string.Empty;
            query += " SELECT [maMatHang], [soluong], [tongtien]";
            query += " FROM [tblChitietPhieuXuatHang]";
            query += " WHERE [maXuatHang]=@maXuatHang";
            List<ChitietphieuxuatDTO> listCTXuatHang = new List<ChitietphieuxuatDTO>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {                    
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maXuatHang", maxh);
                    try
                    {
                        con.Open();
                        SqlDataReader reader = null;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                ChitietphieuxuatDTO CTXH = new ChitietphieuxuatDTO();
                                CTXH.mamh = reader["maMatHang"].ToString();
                                CTXH.soluong = int.Parse(reader["soluong"].ToString());                                
                                CTXH.tongtien = int.Parse(reader["tongtien"].ToString());
                                listCTXuatHang.Add(CTXH);
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
            return listCTXuatHang;
        }
        public List<ChitietphieuxuatDTO> selectByKeyWord(string sKeyword, string maxh)
        {
            string query = string.Empty;
            query += " SELECT [maMatHang], [soluong], [tongtien]";
            query += " FROM [tblChitietPhieuXuatHang]";
            query += " WHERE [maXuatHang]=@maXuatHang";            
            query += " AND (([maMatHang] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([soluong] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([tongtien] LIKE CONCAT('%',@sKeyword,'%')))";

            List<ChitietphieuxuatDTO> listCTXuatHang = new List<ChitietphieuxuatDTO>();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maXuatHang", maxh);
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
                                ChitietphieuxuatDTO CTXH = new ChitietphieuxuatDTO();
                                CTXH.mamh = reader["maMatHang"].ToString();
                                CTXH.soluong = int.Parse(reader["soluong"].ToString());
                                CTXH.tongtien = int.Parse(reader["tongtien"].ToString());
                                listCTXuatHang.Add(CTXH);
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
            return listCTXuatHang;
        }
    }
    public class PhieuThuTienDAL
    {
        private string connectionString;

        public PhieuThuTienDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }

        public string ConnectionString { get => connectionString; set => connectionString = value; }

        public bool Them(PhieuThuTienDTO PTT)
        {
            string query = string.Empty;
            query += "INSERT INTO [tblPhieuThuTien] ([maPhieu], [maDaiLy], [ngayThuTien], [soTienThu])";
            query += "VALUES (@maPhieu, @maDaiLy, @ngayThuTien, @soTienThu)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maPhieu", PTT.mathutien);
                    cmd.Parameters.AddWithValue("@maDaiLy", PTT.madl);
                    cmd.Parameters.AddWithValue("@ngayThuTien", PTT.ngaythu);
                    cmd.Parameters.AddWithValue("@soTienThu", PTT.sotienthu);
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
        public bool Sua(PhieuThuTienDTO PTT)
        {
            string query = string.Empty;
            query += "UPDATE tblPhieuThuTien SET [ngayThuTien] = @ngayThuTien, [soTienThu] = @soTienThu WHERE [maPhieu] = @maPhieu";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maPhieu", PTT.mathutien);
                    cmd.Parameters.AddWithValue("@ngayThuTien", PTT.ngaythu);
                    cmd.Parameters.AddWithValue("@soTienThu", PTT.sotienthu);
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
        public bool Xoa(PhieuThuTienDTO PTT)
        {
            string query = string.Empty;
            query += "DELETE FROM tblPhieuThuTien WHERE [maPhieu] = @maPhieu";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maPhieu", PTT.mathutien);
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

        public List<PhieuThuTienDTO> select()
        {
            string query = string.Empty;
            query += " SELECT ptt.maPhieu, hsdl.maDaiLy, hsdl.diachi, hsdl.dienthoai, hsdl.email, ptt.ngayThuTien , ptt.soTienThu";
            query += " FROM tblHoSoDaiLy hsdl, tblPhieuThuTien ptt";
            query += " WHERE hsdl.maDaiLy = ptt.maDaiLy";
            List<PhieuThuTienDTO> listphieuthu = new List<PhieuThuTienDTO>();

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
                                PhieuThuTienDTO ptt = new PhieuThuTienDTO();
                                ptt.mathutien = reader["maPhieu"].ToString();
                                ptt.madl = reader["maDaiLy"].ToString();
                                ptt.diachi = reader["diachi"].ToString();
                                ptt.dienthoai = reader["dienthoai"].ToString();
                                ptt.email = reader["email"].ToString();                            
                                ptt.ngaythu = Convert.ToDateTime(reader["ngayThuTien"].ToString());
                                ptt.sotienthu = int.Parse(reader["soTienThu"].ToString());
                                listphieuthu.Add(ptt);
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
            return listphieuthu;
        }

        public List<PhieuThuTienDTO> selectByKeyWord(string sKeyword)
        {
            string query = string.Empty;
            query += " SELECT ptt.maPhieu, hsdl.maDaiLy, hsdl.diachi, hsdl.dienthoai, hsdl.email, ptt.ngayThuTien , ptt.soTienThu";
            query += " FROM tblHoSoDaiLy hsdl, tblPhieuThuTien ptt";
            query += " WHERE hsdl.maDaiLy = ptt.maDaiLy";
            query += " AND((hsdl.[maDaiLy] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([maPhieu] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([diachi] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([email] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([dienthoai] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([ngayThuTien] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([soTienThu] LIKE CONCAT('%',@sKeyword,'%')))";

            List<PhieuThuTienDTO> listphieuthu = new List<PhieuThuTienDTO>();

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
                                PhieuThuTienDTO ptt = new PhieuThuTienDTO();
                                ptt.mathutien = reader["maPhieu"].ToString();
                                ptt.madl = reader["maDaiLy"].ToString();
                                ptt.diachi = reader["diachi"].ToString();
                                ptt.dienthoai = reader["dienthoai"].ToString();
                                ptt.email = reader["email"].ToString();
                                ptt.ngaythu = Convert.ToDateTime(reader["ngayThuTien"].ToString());
                                ptt.sotienthu = int.Parse(reader["soTienThu"].ToString());
                                listphieuthu.Add(ptt);
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
            return listphieuthu;
        }        
    }
    public class PhieubaocaodtDAL
    {
        private string connectionString;

        public PhieubaocaodtDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }

        public string ConnectionString { get => connectionString; set => connectionString = value; }

        public bool Them(PhieubaocaodtDTO DT)
        {
            string query = string.Empty;
            query += "INSERT INTO [dbo].[tblPhieubaocaoDoanhThu] ([maPhieu], [tongDoanhThu], [ngayLapPhieu])";
            query += "VALUES (@maPhieu,@tongDoanhThu, @ngayLapPhieu)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maPhieu", DT.madt);
                    cmd.Parameters.AddWithValue("@tongDoanhThu", DT.tongdt);
                    cmd.Parameters.AddWithValue("@ngayLapPhieu", DT.ngaylap);
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
        public bool Sua(PhieubaocaodtDTO DT)
        {
            string query = string.Empty;
            query += "UPDATE [dbo].[tblPhieubaocaoDoanhThu] SET [tongDoanhThu] = @tongDoanhThu WHERE [maPhieu]=@maPhieu";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maPhieu", DT.madt);
                    cmd.Parameters.AddWithValue("@tongDoanhThu", DT.tongdt);
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
        public bool Xoa(PhieubaocaodtDTO DT)
        {
            string query = string.Empty;
            query += "DELETE FROM tblPhieubaocaoDoanhThu WHERE [maPhieu]=@maPhieu";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maXuatHang", DT.madt);
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
        public List<PhieubaocaodtDTO> select()
        {
            string query = string.Empty;
            query += " SELECT [maPhieu], [tongDoanhThu], [ngayLapPhieu]";
            query += " FROM [tblPhieubaocaoDoanhThu]";

            List<PhieubaocaodtDTO> listdoanhthu = new List<PhieubaocaodtDTO>();

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
                                PhieubaocaodtDTO DT = new PhieubaocaodtDTO();
                                DT.madt = reader["maXuatHang"].ToString();
                                DT.ngaylap = Convert.ToDateTime(reader["ngayLapPhieu"].ToString());
                                DT.tongdt = int.Parse(reader["tongDoanhThu"].ToString());
                                listdoanhthu.Add(DT);
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
            return listdoanhthu;
        }
        public List<PhieubaocaodtDTO> selectByKeyWord(string sKeyword)
        {
            string query = string.Empty;
            query += " SELECT [maPhieu], [tongDoanhThu], [ngayLapPhieu]";
            query += " FROM [tblPhieubaocaoDoanhThu]";
            query += " WHERE ([maPhieu] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([ngayLapPhieu] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([tongDoanhThu] LIKE CONCAT('%',@sKeyword,'%'))";

            List<PhieubaocaodtDTO> listdoanhthu = new List<PhieubaocaodtDTO>();

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
                                PhieubaocaodtDTO DT = new PhieubaocaodtDTO();
                                DT.madt = reader["maXuatHang"].ToString();
                                DT.ngaylap = Convert.ToDateTime(reader["ngayLapPhieu"].ToString());
                                DT.tongdt = int.Parse(reader["tongDoanhThu"].ToString());
                                listdoanhthu.Add(DT);
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
            return listdoanhthu;
        }
    }
    public class ChitietphieubcdtDAL
    {
        private string connectionString;
        public ChitietphieubcdtDAL()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }
        public string ConnectionString { get => connectionString; set => connectionString = value; }
        public bool Them(ChitietphieubcdtDTO CTDT)
        {
            string query = string.Empty;
            query += "INSERT INTO [dbo].[tblChitietPhieubaocaoDT] ([maPhieu], [maDaiLy], [soPhieuXuat], [tongDoanhThu], [Tyle])";
            query += "VALUES (@maPhieu,@maDaiLy,@soPhieuXuat, @tongDoanhThu, @Tyle)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maPhieu", CTDT.madt);
                    cmd.Parameters.AddWithValue("@maDaiLy", CTDT.madl);
                    cmd.Parameters.AddWithValue("@soPhieuXuat", CTDT.sophieuxuat);
                    cmd.Parameters.AddWithValue("@tongDoanhThu", CTDT.tongdt);
                    cmd.Parameters.AddWithValue("@Tyle", CTDT.tyle);
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
        public bool XoatheophieuBCDT(string madt)
        {
            string query = string.Empty;
            query += "DELETE FROM tblChitietPhieubaocaoDT WHERE [maPhieu]=@maPhieu ";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maPhieu", madt);
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
        public List<ChitietphieubcdtDTO> select(string madt)
        {
            string query = string.Empty;
            query += " SELECT [maDaiLy], [soPhieuXuat], [tongDoanhThu], [Tyle] ";
            query += " FROM [tblChitietPhieubaocaoDT]";
            query += " WHERE [maPhieu]=@maPhieu";
            List<ChitietphieubcdtDTO> listCTbcdt = new List<ChitietphieubcdtDTO>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maPhieu", madt);
                    try
                    {
                        con.Open();
                        SqlDataReader reader = null;
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                ChitietphieubcdtDTO CTDT = new ChitietphieubcdtDTO();
                                CTDT.madl = reader["maDaiLy"].ToString();
                                CTDT.sophieuxuat = int.Parse(reader["soPhieuXuat"].ToString());
                                CTDT.tongdt = int.Parse(reader["tongDoanhThu"].ToString());
                                CTDT.tyle = float.Parse(reader["Tyle"].ToString());
                                listCTbcdt.Add(CTDT);
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
            return listCTbcdt;
        }
        public List<ChitietphieubcdtDTO> selectByKeyWord(string sKeyword, string madt)
        {
            string query = string.Empty;
            query += " SELECT [maDaiLy], [soPhieuXuat], [tongDoanhThu], [Tyle] ";
            query += " FROM [tblChitietPhieubaocaoDT]";
            query += " WHERE [maPhieu]=@maPhieu";
            query += " AND (([maDaiLy] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([soPhieuXuat] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([tongDoanhThu] LIKE CONCAT('%',@sKeyword,'%')))";
            query += " OR ([Tyle] LIKE CONCAT('%',@sKeyword,'%')))";

            List<ChitietphieubcdtDTO> listCTbcdt = new List<ChitietphieubcdtDTO>();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@maPhieu", madt);
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
                                ChitietphieubcdtDTO CTDT = new ChitietphieubcdtDTO();
                                CTDT.madl = reader["maDaiLy"].ToString();
                                CTDT.sophieuxuat = int.Parse(reader["soPhieuXuat"].ToString());
                                CTDT.tongdt = int.Parse(reader["tongDoanhThu"].ToString());
                                CTDT.tyle = float.Parse(reader["Tyle"].ToString());
                                listCTbcdt.Add(CTDT);
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
            return listCTbcdt;
        }
    }
}
