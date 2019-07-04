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
    public partial class SuaDaiLy : Form
    {
        private CHoSoDaiLyBUS hsBUS;
        private CHoSoDaiLyDTO dlDTO = null;
        private CLoaiDaiLyBUS ldlBUS;
        public SuaDaiLy()
        {
            InitializeComponent();
        }
        private void CapNhatSuaDaiLy_Load(object sender, EventArgs e)
        {
            ldlBUS = new CLoaiDaiLyBUS();
            if (this.dlDTO != null)
            {
                madl.Text = dlDTO.madl.ToString();
                quantxt.Text = dlDTO.quan.ToString();
                tentxt.Text = dlDTO.tendaily.ToString();
                dc.Text = dlDTO.diachi.ToString();
                mail.Text = dlDTO.email.ToString();
                dttxt.Text = dlDTO.dienthoai.ToString();
                notxt.Text = dlDTO.nohientai.ToString();
                ldl.Text = dlDTO.loaidaily.ToString();
            }
            Taodatasource();
        }
        private void Taodatasource()
        {
            List<string> maldl = new List<string>();
            maldl = ldlBUS.Layloaidl();
            ldl.DataSource = maldl;
        }
        public SuaDaiLy(CHoSoDaiLyDTO dl)
        {
            hsBUS = new CHoSoDaiLyBUS();
            this.dlDTO = dl;
            InitializeComponent();
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
            hs.nohientai = int.Parse(notxt.Text);
            hs.loaidaily = ldl.Text;
            //2. Kiểm tra data hợp lệ or not
            int nomax = ldlBUS.Laysotiennomax(hsBUS.Layloaidl(hs.madl));
            //kiểm tra no vuot tối đa chưa
            
            if (hs.nohientai > nomax)
            {
                MessageBox.Show("Đại lý đã vượt quá số tiền nợ tối đa cho phép, vui lòng thử lại");
                return;
            }
            //3. Thêm vào DB
            bool kq = hsBUS.Sua(hs);
            if (kq == false)
                MessageBox.Show("Cập nhật hồ sơ thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                MessageBox.Show("Cập nhật hồ sơ thành công");                
                this.Close();
            }
        }                
        //RÀNG BUỘC CỦA DỮ LIỆU NHẬP VÀO
        private void numOnly(object sender, KeyPressEventArgs e)//chỉ cho nhập số
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
            if (string.IsNullOrWhiteSpace(quantxt.Text))
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
