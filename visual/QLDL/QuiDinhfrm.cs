using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using QLDL_BUS;
using QLDL_DTO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDL
{
    public partial class QuiDinhfrm : Form
    {
        CMatHangBUS mhBUS;
        CLoaiDaiLyBUS ldlBUS;
        DanhsachDonviBUS dvBUS;
        private CQuyDinhBUS qdbus;
        public QuiDinhfrm()
        {
            InitializeComponent();
        }       
        private void QuiDinhfrm_Load(object sender, EventArgs e)
        {
            mhBUS = new CMatHangBUS();
            ldlBUS = new CLoaiDaiLyBUS();
            dvBUS = new DanhsachDonviBUS();
            qdbus = new CQuyDinhBUS();
            LayduLieu();
        }
        private void LayduLieu()
        {
            try
            {
                QuiDinhDTO qd = qdbus.Laydulieu();
                maxloaidl.Text = qd.Maxloaidl.ToString();
                soluongmh.Text = qd.soluongMH.ToString();
                soluongdvt.Text = qd.soluongDVT.ToString();
                maxsodl.Text = qd.Maxsodl.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lấy dữ liệu qui định thất bại");
                return;
            }
        }
        private void numOnly(object sender, KeyPressEventArgs e)// I have no idea how this shit work, so dont touch it
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void capnhat()
        {
            QuiDinhDTO qd = new QuiDinhDTO();
            qd.Maxloaidl = int.Parse(maxloaidl.Text);
            qd.soluongMH = int.Parse(soluongmh.Text);
            qd.soluongDVT = int.Parse(soluongdvt.Text);
            qd.Maxsodl = int.Parse(maxsodl.Text);
            
            //3. Thêm vào DB
            bool kq = qdbus.Sua(qd);
            if (kq == false)
                MessageBox.Show("Sửa qui định thất bại. Vui lòng kiểm tra lại dữ liệu");
            else
                MessageBox.Show("Sửa qui định thành công");
        }
        //------------------LOAI DAI LY & DON VI-------------------------
        private void Button2_Click(object sender, EventArgs e)//them max loai dai ly
        {
            maxloaidl.Text = (int.Parse(maxloaidl.Text) + 1).ToString();
            capnhat();
        }
        private void Button9_Click(object sender, EventArgs e)//tru max loai dai ly
        {
            maxloaidl.Text = (int.Parse(maxloaidl.Text) - 1).ToString();
            capnhat();
            //dung ham dem so dai ly neu vuot qua max thi show form            
            int soldl = ldlBUS.Laysoloaidl();
            if (soldl > int.Parse(maxloaidl.Text))
            {
                QuanLyLoaiDailyDonvi frm = new QuanLyLoaiDailyDonvi();
                frm.ShowDialog();
            }            
        }
        private void Button4_Click(object sender, EventArgs e)//them max don vi
        {
            soluongdvt.Text = (int.Parse(soluongdvt.Text) + 1).ToString();
            capnhat();            
        }
        private void Button7_Click(object sender, EventArgs e)//tru max loai dai ly
        {
            soluongdvt.Text = (int.Parse(soluongdvt.Text) - 1).ToString();
            capnhat();
            //dung ham dem don vi neu vuot qua max thi show form
            int sodv = dvBUS.Laysodonvi();
            if (sodv > int.Parse(soluongdvt.Text))
            {
                QuanLyLoaiDailyDonvi frm = new QuanLyLoaiDailyDonvi();
                frm.ShowDialog();
            }
        }
        //-----------------------------MAT HANG-------------------------------
        private void Button3_Click(object sender, EventArgs e)//them max mat hang
        {
            soluongmh.Text = (int.Parse(soluongmh.Text) + 1).ToString();
            capnhat();            
        }    
        private void Button8_Click(object sender, EventArgs e)//tru max mat hang
        {
            soluongmh.Text = (int.Parse(soluongmh.Text) - 1).ToString();
            capnhat();
            //dung ham dem so mat hang neu vuot qua max thi show form
            int somh = mhBUS.Laysomathang();
            if (somh > int.Parse(soluongmh.Text))
            {
                QuanlyMatHangfrm frm = new QuanlyMatHangfrm();
                frm.Show();
            }
        }
        //--------------------------SO DAI LY 1 QUAN-------------------------------
        private void Button5_Click(object sender, EventArgs e)//them
        {
            maxsodl.Text = (int.Parse(maxsodl.Text) + 1).ToString();
            capnhat();
        }
        private void Button6_Click(object sender, EventArgs e)//tru
        {
            maxsodl.Text = (int.Parse(maxsodl.Text) - 1).ToString();
            capnhat();
        }
    }
}
