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
        public List<string> Laymadl()
        {
            return hsDAL.Laymadl();
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
        public List<string> Laymamh()
        {
            return mhDAL.Laymamh();
        }
        public int Laygiatienmh(string mamh)
        {
            return mhDAL.Laygiatienmh(mamh);
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
    public class PhieuxuathangBUS
    {
        private PhieuxuathangDAL pxhDAL;
        public PhieuxuathangBUS()
        {
            pxhDAL = new PhieuxuathangDAL();
        }
        public bool Them(PhieuxuathangDTO XH)
        {
            bool re = pxhDAL.Them(XH);
            return re;
        }
        public bool Sua(PhieuxuathangDTO XH)
        {
            bool re = pxhDAL.Sua(XH);
            return re;
        }
        public bool Xoa(PhieuxuathangDTO XH)
        {
            bool re = pxhDAL.Xoa(XH);
            return re;
        }
        public List<PhieuxuathangDTO> select()
        {
            return pxhDAL.select();
        }
        public List<PhieuxuathangDTO> selectByKeyWord(string sKeyword)
        {
            return pxhDAL.selectByKeyWord(sKeyword);
        }
    }
    public class ChitietphieuxuatBUS
    {
        private ChitietphieuxuatDAL pxhDAL;
        public ChitietphieuxuatBUS()
        {
            pxhDAL = new ChitietphieuxuatDAL();
        }
        public bool Them(ChitietphieuxuatDTO CTXH)
        {
            bool re = pxhDAL.Them(CTXH);
            return re;
        }
        public bool Sua(ChitietphieuxuatDTO CTXH)
        {
            bool re = pxhDAL.Sua(CTXH);
            return re;
        }
        public bool Xoa(ChitietphieuxuatDTO CTXH)
        {
            bool re = pxhDAL.Xoa(CTXH);
            return re;
        }
        public bool Xoatheophieuxuat(string maxh)
        {
            bool re = pxhDAL.Xoatheophieuxuat(maxh);
            return re;
        }
        public List<ChitietphieuxuatDTO> select(string maxh)
        {
            return pxhDAL.select(maxh);
        }
        public List<ChitietphieuxuatDTO> selectByKeyWord(string sKeyword, string maxh)
        {
            return pxhDAL.selectByKeyWord(sKeyword, maxh);
        }
    }
}
