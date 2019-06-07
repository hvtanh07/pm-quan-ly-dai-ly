using QLDL_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDL_DTO
{
    public class CHoSoDaiLyDTO
    {
        private string maDL;
        private string tenDaiLy;
        private string maloaiDaiLy;
        private string Quan;
        private string dienThoai;
        private string diaChi;
        private string Email;
        private int Nohientai;
        private DateTime ngayTiepNhan;

        public string madl { get => maDL; set => maDL = value; }
        public string tendaily { get => tenDaiLy; set => tenDaiLy = value; }
        public string quan { get => Quan; set => Quan = value; }
        public string dienthoai { get => dienThoai; set => dienThoai = value; }
        public string diachi { get => diaChi; set => diaChi = value; }
        public string email { get => Email; set => Email = value; }
        public string loaidaily { get => maloaiDaiLy; set => maloaiDaiLy = value; }
        public int nohientai { get => Nohientai; set => Nohientai = value; }
        public DateTime ngaytiepnhan { get => ngayTiepNhan; set => ngayTiepNhan = value; }
    }
    public class DanhsachmathangDTO
    {
        private string MaMH;
        private string tenMH;
        private DateTime HanSuDung;
        private int Gia;
        private string DonViTinh;

        public string mamh { get => MaMH; set => MaMH = value; }
        public string tenmh { get => tenMH; set => tenMH = value; }
        public DateTime hansudung { get => HanSuDung; set => HanSuDung = value; }
        public int gia { get => Gia; set => Gia = value; }
        public string donvitinh { get => DonViTinh; set => DonViTinh = value; }
    }
    public class QuiDinhDTO
    {
        private int maxloaidl;
        private int soluongmh;
        private int soluongdvt;
        private int maxsodl; //max số đại lý trong 1 quận
             
        public int Maxloaidl { get => maxloaidl; set => maxloaidl = value; }
        public int soluongMH { get => soluongmh; set => soluongmh = value; }
        public int soluongDVT { get => soluongdvt; set => soluongdvt = value; }
        public int Maxsodl { get => maxsodl; set => maxsodl = value; }    
    }
    public class LoaiDaiLyDTO
    {
        private string maldl;
        private int loaiDaiLy;
        private int maxno;

        public string maLDL { get => maldl; set => maldl = value; }
        public int loaidaily { get => loaiDaiLy; set => loaiDaiLy = value; }
        public int MaxNo { get => maxno; set => maxno = value; }
    }
    public class DanhsachDonviDTO
    {
        private string DonViTinh;
        public string donvitinh { get => DonViTinh; set => DonViTinh = value; }
    }
    public class PhieuxuathangDTO
    {
        private string MaXH;
        private string MaDL;
        private DateTime Ngaylap;
        private int Tongtien;
        
        public string maxh { get => MaXH; set => MaXH = value; }
        public string madl { get => MaDL; set => MaDL = value; }
        public DateTime ngaylap { get => Ngaylap; set => Ngaylap = value; }
        public int tongtien { get => Tongtien; set => Tongtien = value; }
    }
    public class ChitietphieuxuatDTO
    {       
        private string MaXH;
        private string MaMH;
        private int Soluong;
        private int Tongtien;
       
        public string maxh { get => MaXH; set => MaXH = value; }
        public string mamh { get => MaMH; set => MaMH = value; }      
        public int soluong { get => Soluong; set => Soluong = value; }
        public int tongtien { get => Tongtien; set => Tongtien = value; }
    }
    public class PhieuThuTienDTO
    {
        private string maThutien;
        private string maDL;
        private string tenDaiLy;
        private string dienThoai;
        private string diaChi;
        private string Email;
        private DateTime ngayThu;
        private int soTienThu;

        public string mathutien { get => maThutien; set => maThutien = value; }
        public string madl { get => maDL; set => maDL = value; }
        public string tendaily { get => tenDaiLy; set => tenDaiLy = value; }
        public string dienthoai { get => dienThoai; set => dienThoai = value; }
        public string diachi { get => diaChi; set => diaChi = value; }
        public string email { get => Email; set => Email = value; }
        public DateTime ngaythu { get => ngayThu; set => ngayThu = value; }
        public int sotienthu { get => soTienThu; set => soTienThu = value; }
    }
    public class PhieubaocaodtDTO
    {
        private string MaDT;        
        private DateTime Ngaylap;
        private int TongDT;

        public string madt { get => MaDT; set => MaDT = value; }
        public DateTime ngaylap { get => Ngaylap; set => Ngaylap = value; }
        public int tongdt { get => TongDT; set => TongDT = value; }
    }
    public class ChitietphieubcdtDTO
    {
        private string MaDT;
        private string MaDL;
        private int soPX;
        private float Tyle;
        private int TongDT;

        public string madt { get => MaDT; set => MaDT = value; }
        public string madl { get => MaDL; set => MaDL = value; }
        public int sophieuxuat { get => soPX; set => soPX = value; }
        public float tyle { get => Tyle; set => Tyle = value; }
        public int tongdt { get => TongDT; set => TongDT = value; }
    }

}


