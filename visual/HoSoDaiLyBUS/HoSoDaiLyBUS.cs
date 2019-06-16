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
        public int Laytienno(string madl)
        {
            return hsDAL.Laytienno(madl);
        }
        public int Laysodaily(string quan)
        {
            return hsDAL.Laysodaily(quan);
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
        public int Laysomathang()
        {
            return mhDAL.Laysomathang();
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
        public List<string> Layloaidl()
        {
            return ldlDAL.Layloaidl();
        }
        public List<LoaiDaiLyDTO> select()
        {
            return ldlDAL.select();
        }
        public List<LoaiDaiLyDTO> selectByKeyWord(string sKeyword)
        {
            return ldlDAL.selectByKeyWord(sKeyword);
        }
        public int Laysoloaidl()
        {
            return ldlDAL.Laysoloaidl();
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
        public List<string> Laydonvi()
        {
            return dvDAL.Laydonvi();
        }
        public List<DanhsachDonviDTO> select()
        {
            return dvDAL.select();
        }
        public List<DanhsachDonviDTO> selectByKeyWord(string sKeyword)
        {
            return dvDAL.selectByKeyWord(sKeyword);
        }
        public int Laysodonvi()
        {
            return dvDAL.Laysodonvi();
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
        public bool XoatheoDL(string madl)
        {
            return pxhDAL.XoatheoDL(madl);
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
        public List<string> layMAtheoDL(string madl)
        {
            return pxhDAL.layMAtheoDL(madl);
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
        public bool XoatheoMH(string mamh)
        {
            return pxhDAL.XoatheoMH(mamh);
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
    public class PhieuThuTienBUS
    {
        private PhieuThuTienDAL pttDAL;
        public PhieuThuTienBUS()
        {
            pttDAL = new PhieuThuTienDAL();
        }
        public bool Them(PhieuThuTienDTO ptt)
        {
            bool re = pttDAL.Them(ptt);
            return re;
        }
        public bool Sua(PhieuThuTienDTO ptt)
        {
            bool re = pttDAL.Sua(ptt);
            return re;
        }

        public bool Xoa(PhieuThuTienDTO ptt)
        {
            bool re = pttDAL.Xoa(ptt);
            return re;
        }
        public bool XoatheoDL(string madl)
        {
            return pttDAL.XoatheoDL(madl);
        }
        public List<PhieuThuTienDTO> select()
        {
            return pttDAL.select();
        }
        public List<PhieuThuTienDTO> selectByKeyWord(string sKeyword)
        {
            return pttDAL.selectByKeyWord(sKeyword);
        }
    }
    public class PhieubaocaodtBUS
    {
        private PhieubaocaodtDAL pbcdtDAL;
        public PhieubaocaodtBUS()
        {
            pbcdtDAL = new PhieubaocaodtDAL();
        }
        public bool Them(PhieubaocaodtDTO DT)
        {
            bool re = pbcdtDAL.Them(DT);
            return re;
        }
        public bool Sua(PhieubaocaodtDTO DT)
        {
            bool re = pbcdtDAL.Sua(DT);
            return re;
        }
        public bool Xoa(PhieubaocaodtDTO DT)
        {
            bool re = pbcdtDAL.Xoa(DT);
            return re;
        }
        public List<PhieubaocaodtDTO> select()
        {
            return pbcdtDAL.select();
        }
        public List<PhieubaocaodtDTO> selectByKeyWord(string sKeyword)
        {
            return pbcdtDAL.selectByKeyWord(sKeyword);
        }
        public bool Check(int thang,int year)
        {
            return pbcdtDAL.Check(thang,year);
        }
    }
    public class ChitietphieubcdtBUS
    {
        private ChitietphieubcdtDAL pbcdtDAL;
        public ChitietphieubcdtBUS()
        {
            pbcdtDAL = new ChitietphieubcdtDAL();
        }
        public bool Them(ChitietphieubcdtDTO CTXH)
        {
            bool re = pbcdtDAL.Them(CTXH);
            return re;
        }
        public bool XoatheoDL(string madl)
        {
            return pbcdtDAL.XoatheoDL(madl);
        }
        public bool Xoatheophieuxuat(string mabcdt)
        {
            bool re = pbcdtDAL.XoatheophieuBCDT(mabcdt);
            return re;
        }
        public List<ChitietphieubcdtDTO> select(string mabcdt)
        {
            return pbcdtDAL.select(mabcdt);
        }
        public List<ChitietphieubcdtDTO> selectByKeyWord(string sKeyword, string mabcdt)
        {
            return pbcdtDAL.selectByKeyWord(sKeyword, mabcdt);
        }
        public List<ChitietphieubcdtDTO> laydoanhthu(int thang, int year)
        {
            return pbcdtDAL.laydoanhthu(thang, year);
        }
    }
    public class PhieubaocaonoBUS
    {
        private PhieubaocaonoDAL pbcnoDAL;
        public PhieubaocaonoBUS()
        {
            pbcnoDAL = new PhieubaocaonoDAL();
        }
        public bool Them(PhieubaocaonoDTO DT)
        {
            bool re = pbcnoDAL.Them(DT);
            return re;
        }        
        public bool Xoa(PhieubaocaonoDTO DT)
        {
            bool re = pbcnoDAL.Xoa(DT);
            return re;
        }
        public List<PhieubaocaonoDTO> select()
        {
            return pbcnoDAL.select();
        }
        public List<PhieubaocaonoDTO> selectByKeyWord(string sKeyword)
        {
            return pbcnoDAL.selectByKeyWord(sKeyword);
        }
        public bool Check(int thang,int year)
        {
            return pbcnoDAL.Check(thang,year);
        }
    }
    public class ChitietphieubcnoBUS
    {
        private ChitietphieubcnoDAL pbcnoDAL;
        public ChitietphieubcnoBUS()
        {
            pbcnoDAL = new ChitietphieubcnoDAL();
        }
        public bool Them(ChitietphieubcnoDTO CTNO)
        {
            bool re = pbcnoDAL.Them(CTNO);
            return re;
        }
        public bool Xoatheophieuno(string mabcdt)
        {
            bool re = pbcnoDAL.XoatheophieuBCNO(mabcdt);
            return re;
        }
        public bool XoatheoDL(string madl)
        {
            return pbcnoDAL.XoatheoDL(madl);
        }
        public List<ChitietphieubcnoDTO> select(string mabcno)
        {
            return pbcnoDAL.select(mabcno);
        }
        public List<ChitietphieubcnoDTO> selectByKeyWord(string sKeyword, string mabcno)
        {
            return pbcnoDAL.selectByKeyWord(sKeyword, mabcno);
        }
        public List<ChitietphieubcnoDTO> layno()
        {
            return pbcnoDAL.layno();
        }
    }
    public class NoThangtruocBUS
    {
        private NoThangtruocDAL noDAL;
        public NoThangtruocBUS()
        {
            noDAL = new NoThangtruocDAL();
        }
        public int Laytientheoma(string ma)
        {
            return noDAL.Laytientheoma(ma);
        }
        public bool Them(NoThangtruocDTO no)
        {
            bool re = noDAL.Them(no);
            return re;
        }
        public bool Sua(NoThangtruocDTO no)
        {
            bool re = noDAL.Sua(no);
            return re;
        }
        public bool XoatheoDL(string madl)
        {
            return noDAL.XoatheoDL(madl);
        }
        public bool Xoa(NoThangtruocDTO no)
        {
            bool re = noDAL.Xoa(no);
            return re;
        }
    }
}
