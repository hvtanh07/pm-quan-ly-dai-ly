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
    public partial class CapNhatSuaDaiLy : Form
    {
        private CHoSoDaiLyBUS hsBUS;
        public CapNhatSuaDaiLy()
        {
            InitializeComponent();
        }
        private void CapNhatSuaDaiLy_Load(object sender, EventArgs e)
        {
            hsBUS = new CHoSoDaiLyBUS();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            CHoSoDaiLyDTO hs = new CHoSoDaiLyDTO();
            hs.madl = int.Parse(matxt.Text);
            hs.quan = quantxt.Text;
            hs.dientich = int.Parse(dt.Text);
            hs.sonhanvien = int.Parse(snv.Text);
            hs.tendaily = tentxt.Text;
            hs.diachi = dc.Text;
            hs.email = mail.Text;
            hs.dienthoai = dttxt.Text;
            if (checkBox1.Checked == true)
            {
                hs.loaidaily = 1;
            }
            else if (checkBox2.Checked == true)
            {
                hs.loaidaily = 2;
            }
            else
            {
                hs.loaidaily = 1;
            }

            //2. Kiểm tra data hợp lệ or not

            //3. Thêm vào DB
            bool kq = hsBUS.Sua(hs);
            if (kq == false)
                MessageBox.Show("Cập nhật hồ sơ thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                MessageBox.Show("Cập nhật hồ sơ thành công");
                matxt.Text = "";           
                quantxt.Text = "";
                dt.Text = "";
                snv.Text = "";
                tentxt.Text = "";
                dc.Text = "";
                mail.Text = "";
                dttxt.Text = "";
                checkBox1.Checked = false;
                checkBox2.Checked = false;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            CHoSoDaiLyDTO hs = new CHoSoDaiLyDTO();
            hs.madl = int.Parse(matxt.Text);
            bool kq = hsBUS.Xoa(hs);
            if (kq == false)
                MessageBox.Show("Xóa hồ sơ thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                MessageBox.Show("Xóa hồ sơ thành công");
                matxt.Text = "";
                quantxt.Text = "";
                dt.Text = "";
                snv.Text = "";
                tentxt.Text = "";
                dc.Text = "";
                mail.Text = "";
                dttxt.Text = "";
                checkBox1.Checked = false;
                checkBox2.Checked = false;
            }
        }

        
    }
}
