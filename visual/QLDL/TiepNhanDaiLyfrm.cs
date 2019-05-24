using QLDL_BUS;
using QLDL_DTO;
using System;
using System.Windows.Forms;

namespace QLDL
{
    public partial class TiepNhanDaiLyfrm : Form
    {
        private CHoSoDaiLyBUS hsBUS;
        public TiepNhanDaiLyfrm()
        {
            InitializeComponent();
        }
        private void TiepNhanDaiLyfrm_Load(object sender, EventArgs e)
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
            hs.ngaytiepnhan = Convert.ToDateTime(DateTime.Today.ToShortDateString());
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
            bool kq = hsBUS.Them(hs);
            if (kq == false)
                MessageBox.Show("Thêm hồ sơ thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
                MessageBox.Show("Thêm hồ sơ thành công");
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox2.Checked = false;
            }
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
            }
        }

       
    }
}
