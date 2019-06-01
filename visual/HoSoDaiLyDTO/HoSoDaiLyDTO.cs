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
        private int maDL;
        private string tenDaiLy;
        private int loaiDaiLy;
        private string Quan;
        private string dienThoai;
        private string diaChi;
        private string Email;
        private int Nohientai;
        private DateTime ngayTiepNhan;

        public int madl { get => maDL; set => maDL = value; }
        public string tendaily { get => tenDaiLy; set => tenDaiLy = value; }
        public string quan { get => Quan; set => Quan = value; }
        public string dienthoai { get => dienThoai; set => dienThoai = value; }
        public string diachi { get => diaChi; set => diaChi = value; }
        public string email { get => Email; set => Email = value; }
        public int loaidaily { get => loaiDaiLy; set => loaiDaiLy = value; }
        public int nohientai { get => Nohientai; set => Nohientai = value; }
        public DateTime ngaytiepnhan { get => ngayTiepNhan; set => ngayTiepNhan = value; }
    }
    public class DanhsachmathangDTO
    {
        private int MaMH;
        private string tenMH;
        private DateTime HanSuDung;
        private int Gia;
        private string DonViTinh;

        public int mamh { get => MaMH; set => MaMH = value; }
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
        private int maldl;
        private int loaiDaiLy;
        private int maxno;

        public int maLDL { get => maldl; set => maldl = value; }
        public int loaidaily { get => loaiDaiLy; set => loaiDaiLy = value; }
        public int MaxNo { get => maxno; set => maxno = value; }
    }
    public class DanhsachDonviDTO
    {
        private string DonViTinh;
        public string donvitinh { get => DonViTinh; set => DonViTinh = value; }
    }
  
}
