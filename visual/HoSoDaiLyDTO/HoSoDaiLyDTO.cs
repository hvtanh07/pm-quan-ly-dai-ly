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
        private int soNhanVien;
        private int dienTich;
        private string dienThoai;
        private string diaChi;
        private string Email;
        private DateTime ngayTiepNhan;


        public int madl { get => maDL; set => maDL = value; }
        public int sonhanvien { get => soNhanVien; set => soNhanVien = value; }
        public int dientich { get => dienTich; set => dienTich = value; }
        public string tendaily { get => tenDaiLy; set => tenDaiLy = value; }
        public string quan { get => Quan; set => Quan = value; }
        public string dienthoai { get => dienThoai; set => dienThoai = value; }
        public string diachi { get => diaChi; set => diaChi = value; }
        public string email { get => Email; set => Email = value; }
        public int loaidaily { get => loaiDaiLy; set => loaiDaiLy = value; }
        public DateTime ngaytiepnhan { get => ngayTiepNhan; set => ngayTiepNhan = value; }
    }
    public class DanhsachmathangDTO
    {
        private int MaMH;
        private string tenMH;
        private int Soluong;
        private int KhoiLuong;
        private DateTime HanSuDung;
        private int Gia;
        private string DonViTinh;

        public int Mamh { get => MaMH; set => MaMH = value; }
        public string tenmh { get => tenMH; set => tenMH = value; }
        public int soluong { get => Soluong; set => Soluong = value; }
        public int khoiluong { get => KhoiLuong; set => KhoiLuong = value; }
        public DateTime hansudung { get => HanSuDung; set => HanSuDung = value; }
        public int gia { get => Gia; set => Gia = value; }
        public string donvitinh { get => DonViTinh; set => DonViTinh = value; }
    }
}
