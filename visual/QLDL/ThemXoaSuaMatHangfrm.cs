using QLDL_BUS;
using QLDL_DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDL
{
    public partial class ThemXoaSuaMatHangfrm : Form
    {
        public ThemXoaSuaMatHangfrm()
        {
            InitializeComponent();
        }
        private CMatHangBUS mhbus;
        //THEM
        private void Button1_Click(object sender, EventArgs e)
        {          
            DanhsachmathangDTO mh = new DanhsachmathangDTO();
            mh.Mamh = int.Parse(ma.Text);
            mh.tenmh = tmh.Text;
            mh.khoiluong = int.Parse(kl.Text);
            mh.soluong = int.Parse(sl.Text);
            mh.hansudung = Convert.ToDateTime(hsd.Value.ToShortDateString());
            mh.gia = int.Parse(gia.Text);
            mh.donvitinh = dvt.Text;
            //2. Kiểm tra data hợp lệ or not

            //3. Thêm vào DB
            bool kq = mhbus.Them(mh);
            if (kq == false)
                MessageBox.Show("Thêm mặt hàng thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
                MessageBox.Show("Thêm mặt hàng thành công");
        }

        private void ThemXoaSuaMatHangfrm_Load(object sender, EventArgs e)
        {
            mhbus = new CMatHangBUS();
        }
        //XOA
        private void Button2_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn xóa đại lý này không ?", "Xóa thông tin", MessageBoxButtons.YesNo);
            if (dlr == DialogResult.Yes)
            {
                DanhsachmathangDTO mh = new DanhsachmathangDTO();
                mh.Mamh = int.Parse(ma.Text);
                //2. Kiểm tra data hợp lệ or not

                //3. Thêm vào DB
                bool kq = mhbus.Xoa(mh);
                if (kq == false)
                    MessageBox.Show("Xóa mặt hàng thất bại. Vui lòng kiểm tra lại dũ liệu");
                else
                    MessageBox.Show("Xóa mặt hàng thành công");
            }
        }
        //SUA
        private void Button3_Click(object sender, EventArgs e)
        {
            DanhsachmathangDTO mh = new DanhsachmathangDTO();
            mh.Mamh = int.Parse(ma.Text);
            mh.tenmh = tmh.Text;
            mh.khoiluong = int.Parse(kl.Text);
            mh.soluong = int.Parse(sl.Text);
            mh.hansudung = Convert.ToDateTime(hsd.Value.ToShortDateString());
            mh.gia = int.Parse(gia.Text);
            mh.donvitinh = dvt.Text;
            //2. Kiểm tra data hợp lệ or not

            //3. Thêm vào DB
            bool kq = mhbus.Sua(mh);
            if (kq == false)
                MessageBox.Show("Sửa mặt hàng thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
                MessageBox.Show("Sửa mặt hàng thành công");
        }
    }
}
