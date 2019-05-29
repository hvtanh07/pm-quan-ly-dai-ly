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
        private void ThemXoaSuaMatHangfrm_Load(object sender, EventArgs e)
        {
            mhbus = new CMatHangBUS();
        }
        //THEM
        private void Button1_Click(object sender, EventArgs e)
        {
            if (!testtext())
            {
                return;
            }
            DanhsachmathangDTO mh = new DanhsachmathangDTO();
            mh.Mamh = int.Parse(ma.Text);
            mh.tenmh = tmh.Text;
            mh.khoiluong = int.Parse(kl.Text);
            mh.soluong = int.Parse(sl.Text);
            mh.hansudung = hsd.Value;
            mh.gia = int.Parse(gia.Text);
            mh.donvitinh = dvt.Text;
            //2. Kiểm tra data hợp lệ or not
            
            //3. Thêm vào DB
            bool kq = mhbus.Them(mh);
            if (kq == false)
                MessageBox.Show("Thêm mặt hàng thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                MessageBox.Show("Thêm mặt hàng thành công");
                clear();                
            }
            
        }

        
        //XOA
        private void Button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ma.Text))
            {
                MessageBox.Show("Xóa mặt hàng thất bại. Chưa nhập mã mặt hàng cần xóa.");
                ma.Focus();
                return;
            }
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn xóa mặt hàng này không ?", "Xóa thông tin", MessageBoxButtons.YesNo);
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
                {
                    MessageBox.Show("Xóa mặt hàng thành công");
                    clear();
                }                    
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
            mh.hansudung = hsd.Value;
            mh.gia = int.Parse(gia.Text);
            mh.donvitinh = dvt.Text;
            //2. Kiểm tra data hợp lệ or not
            
            //3. Thêm vào DB
            bool kq = mhbus.Sua(mh);
            if (kq == false)
                MessageBox.Show("Sửa mặt hàng thất bại. Vui lòng kiểm tra lại dữ liệu");
            else
                MessageBox.Show("Sửa mặt hàng thành công");
        }

        //XÓA CÁC Ô ĐIỀN DỮ LIỆU
        private void clear()
        {   
            ma.Text="";
            tmh.Text="";
            kl.Text="";
            sl.Text = "";
            hsd.Value = DateTime.Today;
            gia.Text = "";
            dvt.Text = "";
        }
        //RÀNG BUỘC CỦA DỮ LIỆU NHẬP VÀO
        bool testtext()//kiểm tra ô dữ liệu trống
        {

            if (string.IsNullOrWhiteSpace(ma.Text))
            {
                MessageBox.Show(ma, "Bạn chưa nhập mã mặt hàng.");
                ma.Focus();
                return false;
            }//ma
            if (string.IsNullOrWhiteSpace(tmh.Text))
            {
                MessageBox.Show(tmh, "Bạn chưa nhập tên mặt hàng.");
                tmh.Focus();
                return false;
            }//tên
            if (string.IsNullOrWhiteSpace(sl.Text))
            {
                MessageBox.Show(sl, "Bạn chưa nhập số lượng.");
                sl.Focus();
                return false;
            }//số lượng
            if (string.IsNullOrWhiteSpace(kl.Text))
            {
                MessageBox.Show(kl, "Bạn chưa nhập khối lượng.");
                kl.Focus();
                return false;
            }//khối lượng
            if (DateTime.Compare(hsd.Value, DateTime.Today) < 0)
            {
                MessageBox.Show("Mặt hàng đã hết hạn sử dụng hoặc hạn sử dụng không đúng, vui lòng thử lại");
                return false;
            }//check hạn sử dụng
            if (string.IsNullOrWhiteSpace(gia.Text))
            {
                MessageBox.Show(gia, "Bạn chưa nhập giá.");
                gia.Focus();
                return false;
            }//gia 
            if (string.IsNullOrWhiteSpace(dvt.Text))//quan
            {
                MessageBox.Show(dvt, "Bạn chưa nhập đơn vị tính.");
                dvt.Focus();
                return false;
            }//don vi tinh      
            
            return true;//all true then gud to go
        }
    }
}
