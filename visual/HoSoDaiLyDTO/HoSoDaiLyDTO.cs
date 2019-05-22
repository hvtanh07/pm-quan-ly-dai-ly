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
        private DateTime ngayTiepNhan;


        public int madl { get => maDL; set => maDL = value; }
        public string tendaily { get => tenDaiLy; set => tenDaiLy = value; }
        public string quan { get => Quan; set => Quan = value; }
        public string dienthoai { get => dienThoai; set => dienThoai = value; }
        public string diachi { get => diaChi; set => diaChi = value; }
        public string email { get => Email; set => Email = value; }
        public int loaidaily { get => loaiDaiLy; set => loaiDaiLy = value; }
        public DateTime ngaytiepnhan { get => ngayTiepNhan; set => ngayTiepNhan = value; }
    }
}
