using QLDL_BUS;
using QLDL_DTO;
using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

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
            if (!testtext())
            {
                return;
            }
            CHoSoDaiLyDTO hs = new CHoSoDaiLyDTO();
            hs.quan = quantxt.Text;
            hs.tendaily = tentxt.Text;
            hs.diachi = dc.Text;
            hs.email = mail.Text;
            hs.dienthoai = dttxt.Text;
            hs.ngaytiepnhan = DateTime.Today;
            hs.nohientai = 0;
            hs.loaidaily = int.Parse(ldl.Text);

            //2. Kiểm tra data hợp lệ or not
            //kiểm tra trong quận đã đạt tối đa số đại lý chưa
                    
            //3. Thêm vào DB
            bool kq = hsBUS.Them(hs);
            if (kq == false)
                MessageBox.Show("Thêm hồ sơ thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                MessageBox.Show("Thêm hồ sơ thành công");
                quantxt.Text = "";
                tentxt.Text = "";
                dc.Text = "";
                mail.Text = "";
                dttxt.Text = "";
                ldl.Text = "";
            }
        }
        //RÀNG BUỘC CỦA DỮ LIỆU NHẬP VÀO
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
        bool testtext()//kiểm tra ô dữ liệu trống
        {

            if (string.IsNullOrWhiteSpace(tentxt.Text))
            {
                MessageBox.Show(tentxt, "Bạn chưa nhập tên đại lý.");
                tentxt.Focus();
                return false;
            }//ten
            if (string.IsNullOrWhiteSpace(dc.Text))
            {
                MessageBox.Show(dc, "Bạn chưa nhập địa chỉ.");
                dc.Focus();
                return false;
            }//dia chi
            if (string.IsNullOrWhiteSpace(quantxt.Text))//quan
            {
                MessageBox.Show(quantxt, "Bạn chưa nhập địa chỉ quận.");
                quantxt.Focus();
                return false;
            }//quan      
            if (string.IsNullOrWhiteSpace(dttxt.Text))
            {
                MessageBox.Show(dttxt, "Bạn chưa nhập số điện thoại.");
                dttxt.Focus();
                return false;
            }//dien thoai
            if (string.IsNullOrWhiteSpace(mail.Text))
            {
                MessageBox.Show(mail, "Bạn chưa nhập Email.");
                mail.Focus();
                return false;
            }//mail
            else
            {
                try
                {
                    var eMailValidator = new System.Net.Mail.MailAddress(mail.Text);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(mail, "Email Không hợp lệ");
                    mail.Text = "";
                    mail.Focus();
                    return false;
                }
            }//email valid or not

            return true;//all true then gud to go
        }
    }
}
