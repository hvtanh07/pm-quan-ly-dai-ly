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
            return hsDAL.select();
        }
        public List<CHoSoDaiLyDTO> selectByKeyWord(string sKeyword)
        {
            return hsDAL.selectByKeyWord(sKeyword);
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
        public List<DanhsachmathangDTO> select()
        {
            return mhDAL.select();
        }
        public List<DanhsachmathangDTO> selectByKeyWord(string sKeyword)
        {
            return mhDAL.selectByKeyWord(sKeyword);
        }
    }
    public class CQuyDinhBUS
    {
        private CQuiDinhDAL qdDAL;
        public CQuyDinhBUS()
        {
            qdDAL = new CQuiDinhDAL();
        }
        public bool Sua(QuiDinhDTO QD)
        {
            bool re = qdDAL.Sua(QD);
            return re;
        }
        public QuiDinhDTO Laydulieu()
        {
            return qdDAL.Laydulieu();
        }
    }
    public class CLoaiDaiLyBUS
    {
        private CLoaiDaiLyDAL ldlDAL;
        public CLoaiDaiLyBUS()
        {
            ldlDAL = new CLoaiDaiLyDAL();
        }
        public bool Them(LoaiDaiLyDTO MH)
        {
            bool re = ldlDAL.Them(MH);
            return re;
        }
        public bool Sua(LoaiDaiLyDTO MH)
        {
            bool re = ldlDAL.Sua(MH);
            return re;
        }

        public bool Xoa(LoaiDaiLyDTO MH)
        {
            bool re = ldlDAL.Xoa(MH);
            return re;
        }
        public List<LoaiDaiLyDTO> select()
        {
            return ldlDAL.select();
        }
        public List<LoaiDaiLyDTO> selectByKeyWord(string sKeyword)
        {
            return ldlDAL.selectByKeyWord(sKeyword);
        }
    }
    public class DanhsachDonviBUS
    {
        private DanhsachDonviDAL dvDAL;
        public DanhsachDonviBUS()
        {
            dvDAL = new DanhsachDonviDAL();
        }
        public bool Them(DanhsachDonviDTO dv)
        {
            bool re = dvDAL.Them(dv);
            return re;
        }       
        public bool Xoa(DanhsachDonviDTO dv)
        {
            bool re = dvDAL.Xoa(dv);
            return re;
        }
        public List<DanhsachDonviDTO> select()
        {
            return dvDAL.select();
        }
        public List<DanhsachDonviDTO> selectByKeyWord(string sKeyword)
        {
            return dvDAL.selectByKeyWord(sKeyword);
        }
    }
}
