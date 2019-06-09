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
    public partial class TiepNhanDaiLyfrm : Form
    {
        private CHoSoDaiLyBUS hsBUS;
        private CQuyDinhBUS qdBUS;
        private CLoaiDaiLyBUS ldlBUS;
        private NoThangtruocBUS nttBUS;
        public TiepNhanDaiLyfrm()
        {
            InitializeComponent();
        }
        private void TiepNhanDaiLyfrm_Load(object sender, EventArgs e)
        {
            qdBUS = new CQuyDinhBUS();
            hsBUS = new CHoSoDaiLyBUS();
            nttBUS = new NoThangtruocBUS();
            ldlBUS = new CLoaiDaiLyBUS();
            Taodatasource();
        }
        private void Taodatasource()
        {
            List<string> maldl = new List<string>();
            maldl = ldlBUS.Layloaidl();
            ldl.DataSource = maldl;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (!testtext())
            {
                return;
            }
            CHoSoDaiLyDTO hs = new CHoSoDaiLyDTO();
            hs.madl = madl.Text;
            hs.quan = quantxt.Text;
            hs.tendaily = tentxt.Text;
            hs.diachi = dc.Text;
            hs.email = mail.Text;
            hs.dienthoai = dttxt.Text;
            hs.ngaytiepnhan = DateTime.Today;
            hs.nohientai = 0;
            hs.loaidaily = ldl.Text;
            NoThangtruocDTO ntt = new NoThangtruocDTO();
            ntt.madl = madl.Text;
            ntt.nothangtruoc = 0;
            //2. Kiểm tra data hợp lệ or not
            QuiDinhDTO qd = qdBUS.Laydulieu();
            int sodl = hsBUS.Laysodaily(quantxt.Text);
            if (sodl >= qd.Maxsodl)
            {
                MessageBox.Show("Thêm hồ sơ thất bại. Số đại lý trong " + quantxt.Text + " đã đạt tối đa theo quy định");
                return;
            }
            //3. Thêm vào DB
            bool kq2 = hsBUS.Them(hs);
            bool kq1 = nttBUS.Them(ntt);           
            if (kq1 == false || kq2 == false)
                MessageBox.Show("Thêm hồ sơ thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                MessageBox.Show("Thêm hồ sơ thành công");
                madl.Text = "";
                quantxt.Text = "";
                tentxt.Text = "";
                dc.Text = "";
                mail.Text = "";
                dttxt.Text = "";
                ldl.Text = "";
            }
            QuanlyDaily frm = new QuanlyDaily();
            frm.ShowDialog();
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
            if (string.IsNullOrWhiteSpace(madl.Text))
            {
                MessageBox.Show(madl, "Bạn chưa nhập mã đại lý.");
                madl.Focus();
                return false;
            }//ten
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
