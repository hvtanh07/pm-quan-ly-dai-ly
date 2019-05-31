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
            query += "INSERT INTO [tblHoSoDaiLy] ([tenDaiLy], [diachi],[email], [loaiDaiLy], [ngayTiepNhan], [quan], [dienthoai], [nohientai])";
            query += "VALUES (@tenDaiLy, @diachi, @email, @loaiDaiLy,@ngayTiepNhan , @quan, @dienthoai, @nohientai)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@tenDaiLy", HoSo.tendaily);
                    cmd.Parameters.AddWithValue("@diachi", HoSo.diachi);
                    cmd.Parameters.AddWithValue("@email", HoSo.email);
                    cmd.Parameters.AddWithValue("@loaiDaiLy", HoSo.loaidaily);
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
            query += "UPDATE tblHoSoDaiLy SET [diachi] = @diachi, [email] = @email, [loaiDaiLy] = @loaiDaiLy, [quan] = @quan, [dienthoai] = @dienthoai, [nohientai] = @nohientai WHERE [tenDaiLy] = @tenDaiLy";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@tenDaiLy", HoSo.tendaily);
                    cmd.Parameters.AddWithValue("@diachi", HoSo.diachi);
                    cmd.Parameters.AddWithValue("@email", HoSo.email);
                    cmd.Parameters.AddWithValue("@loaiDaiLy", HoSo.loaidaily);
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
            query += "DELETE FROM tblHoSoDaiLy WHERE [tenDaiLy] = @tenDaiLy";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@tenDaiLy", HoSo.tendaily);
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
            query += "SELECT [tenDaiLy],[diachi],[email],[loaiDaiLy],[ngayTiepNhan],[quan],[dienthoai],[nohientai]";
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
                                hs.tendaily = reader["tenDaiLy"].ToString();
                                hs.diachi = reader["diachi"].ToString();
                                hs.email = reader["email"].ToString();
                                hs.loaidaily = int.Parse(reader["loaiDaiLy"].ToString());
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
            query += " SELECT [tenDaiLy],[diachi],[email],[loaiDaiLy],[ngayTiepNhan],[quan],[dienthoai],[nohientai]";
            query += " FROM [tblHoSoDaiLy]";
            query += " WHERE ([tenDaiLy] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([diachi] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([email] LIKE CONCAT('%',@sKeyword,'%'))";
            query += " OR ([loaiDaiLy] LIKE CONCAT('%',@sKeyword,'%'))";
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
                                hs.tendaily = reader["tenDaiLy"].ToString();
                                hs.diachi = reader["diachi"].ToString();
                                hs.email = reader["email"].ToString();
                                hs.loaidaily = int.Parse(reader["loaiDaiLy"].ToString());
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
            query += "INSERT INTO [dbo].[tblMatHang] ([tenmathang], [hanSuDung], [gia], [donViTinh])";
            query += "VALUES (@tenmathang,@hanSuDung, @gia, @donViTinh)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
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
            query += "UPDATE tblMatHang SET [hanSuDung] = @hanSuDung, [gia] = @gia, [donViTinh] = @donViTinh WHERE [tenmathang]=@tenmathang";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
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
            query += "DELETE FROM tblMatHang WHERE [tenmathang]=@tenmathang";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@tenmathang", MH.tenmh);
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
            query += "SELECT [tenmathang], [hanSuDung], [gia], [donViTinh]";
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
            query += " SELECT [tenmathang], [hanSuDung], [gia], [donViTinh]";
            query += " FROM [tblMatHang]";
            query += " WHERE ([tenmathang] LIKE CONCAT('%',@sKeyword,'%'))";
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
            query += " WHERE [getkey] LIKE 1";
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
                                re.Maxloaidl = int.Parse(reader["maxloaidl"].ToString());
                                re.Maxsodl = int.Parse(reader["maxdl"].ToString());
                                re.soluongDVT = int.Parse(reader["soluongdvt"].ToString());
                                re.soluongMH = int.Parse(reader["soluongmathang"].ToString());
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
            query += "UPDATE tblLoaiDaiLy SET [maxno] = @maxno WHERE [loaiDaiLy]=@loaiDaiLy";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
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
            query += "INSERT INTO [dbo].[tblLoaiDaiLy] ([loaiDaiLy], [maxno])";
            query += "VALUES (@loaiDaiLy,@maxno)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
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
            query += "DELETE FROM tblLoaiDaiLy WHERE [loaiDaiLy]=@loaiDaiLy";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
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
        public List<LoaiDaiLyDTO> select()
        {
            string query = string.Empty;
            query += "SELECT [loaiDaiLy], [maxno]";
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
            query += " SELECT [loaiDaiLy], [maxno]";
            query += " FROM [tblLoaiDaiLy]";
            query += " WHERE ([loaiDaiLy] LIKE CONCAT('%',@sKeyword,'%'))";
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

}
