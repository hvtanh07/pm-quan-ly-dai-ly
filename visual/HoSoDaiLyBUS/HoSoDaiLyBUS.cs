using QLDL_DTO;
using QLDL_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDL_BUS
{
    public class CHoSoDaiLyBUS
    {
        private CHoSoDaiLyDAL hsDAL;
        public CHoSoDaiLyBUS()
        {
            hsDAL = new CHoSoDaiLyDAL();
        }
        public bool Them(CHoSoDaiLyDTO hs)
        {
            bool re = hsDAL.Them(hs);
            return re;
        }
        public bool Sua(CHoSoDaiLyDTO hs)
        {
            bool re = hsDAL.Sua(hs);
            return re;
        }

        public bool Xoa(CHoSoDaiLyDTO hs)
        {
            bool re = hsDAL.Xoa(hs);
            return re;
        }
        public List<CHoSoDaiLyDTO> select()
        {
            return null;
        }
    }
    public class CMatHangBUS
    {
        private CMatHangDAL mhDAL;
        public CMatHangBUS()
        {
            mhDAL = new CMatHangDAL();
        }
        public bool Them(DanhsachmathangDTO MH)
        {
            bool re = mhDAL.Them(MH);
            return re;
        }
        public bool Sua(DanhsachmathangDTO MH)
        {
            bool re = mhDAL.Sua(MH);
            return re;
        }

        public bool Xoa(DanhsachmathangDTO MH)
        {
            bool re = mhDAL.Xoa(MH);
            return re;
        }
        public List<CHoSoDaiLyDTO> select()
        {
            return null;
        }
    }
}
