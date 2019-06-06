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
            query += "INSERT INTO [tblHoSoDaiLy] ([maDaiLy], [tenDaiLy], [diachi],[email], [maloaiDaiLy], [ngayTiepNhan], [quan], [dienthoai], [nohientai])";
            query += "VALUES (@maDaiLy, @tenDaiLy, @diachi, @email, @maloaiDaiLy,@ngayTiepNhan , @quan, @dienthoai, @nohientai)";
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
            query += "UPDATE tblHoSoDaiLy SET [tenDaiLy] = @tenDaiLy, [diachi] = @diachi, [email] = @email, [maloaiDaiLy] = @maloaiDaiLy, [quan] = @quan, [dienthoai] = @dienthoai, [nohientai] = @nohientai WHERE [maDaiLy] = @maDaiLy";

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
            query += "SELECT [maDaiLy],[tenDaiLy],[diachi],[email],[maloaiDaiLy],[ngayTiepNhan],[quan],[dienthoai],[nohientai]";
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
            query += "INSERT INTO [dbo].[tblMatHang] ([maMatHang],[tenmathang], [hanSuDung], [gia], [donViTinh])";
            query += "VALUES (@maMatHang,@tenmathang,@hanSuDung, @gia, @donViTinh)";
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
            query += "SELECT [maMatHang], [tenmathang], [hanSuDung], [gia], [donViTinh]";
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
            query += "UPDATE tblQuiDinh SET [maxloaidl] = @maxloaidl, [soluongmathang] = @soluongmathang, [soluongdvt] = @soluongdvt, [maxdl] = @maxdl WHERE [getkey]=@getkey";
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
        public List<LoaiDaiLyDTO> select()
        {
            string query = string.Empty;
            query += "SELECT [maLoaiDaiLy], [loaiDaiLy], [maxno]";
            query += "FROM [tblLoaiDaiLy]";

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
        public List<DanhsachDonviDTO> select()
        {
            string query = string.Empty;
            query += "SELECT  [donViTinh]";
            query += "FROM [tblDonvi]";

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
                                dv.donvitinh= reader["loaiDaiLy"].ToString();
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
            query += "SELECT [maXuatHang], [maDaiLy], [ngayLapPhieu], [tongtien]";
            query += "FROM [tblPhieuXuatHang]";

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
            query += "SELECT [maXuatHang], [maDaiLy], [ngayLapPhieu], [tongtien]";
            query += "FROM [tblPhieuXuatHang]";
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
            query += "SELECT [maMatHang], [soluong], [tongtien]";
            query += "FROM [tblChitietPhieuXuatHang]";
            query += "WHERE [maXuatHang]=@maXuatHang";
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
            query += "SELECT [maMatHang], [soluong], [tongtien]";
            query += "FROM [tblPhieuXuatHang]";
            query += "WHERE [maXuatHang]=@maXuatHang";
            query += " WHERE ([maXuatHang] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " WHERE ([maMatHang] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " WHERE ([soluong] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " WHERE ([tongtien] LIKE CONCAT('%',@sKeyword,'%'))";

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
                                CTXH.maxh = reader["maXuatHang"].ToString();
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

}
