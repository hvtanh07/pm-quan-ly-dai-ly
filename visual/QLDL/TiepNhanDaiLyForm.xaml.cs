using QLDL_BUS;
using QLDL_DTO;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QLDL
{
    /// <summary>
    /// Interaction logic for TiepNhanDaiLyForm.xaml
    /// </summary>
    public partial class TiepNhanDaiLyForm : Window
    {
        private CHoSoDaiLyBUS hsBUS;
        private CQuyDinhBUS qdBUS;
        private CLoaiDaiLyBUS ldlBUS;
        private NoThangtruocBUS nttBUS;
        public TiepNhanDaiLyForm()
        {
            InitializeComponent();
        }


        private void TiepNhanDaiLyForm_Loaded(object sender, RoutedEventArgs e)
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
            ldl.ItemsSource = maldl;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
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
                System.Windows.MessageBox.Show("Thêm hồ sơ thất bại. Số đại lý trong " + quantxt.Text + " đã đạt tối đa theo quy định");
                return;
            }
            //3. Thêm vào DB
            bool kq2 = hsBUS.Them(hs);
            bool kq1 = nttBUS.Them(ntt);
            if (kq1 == false || kq2 == false)
                System.Windows.MessageBox.Show("Thêm hồ sơ thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                System.Windows.MessageBox.Show("Thêm hồ sơ thành công");
                madl.Text = "";
                quantxt.Text = "";
                tentxt.Text = "";
                dc.Text = "";
                mail.Text = "";
                dttxt.Text = "";
                ldl.Text = "";
            }
            this.Close();
            // QuanlyDaily frm = new QuanlyDaily();
            //frm.ShowDialog();
        }
        //RÀNG BUỘC CỦA DỮ LIỆU NHẬP VÀO
        private static readonly Regex _regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void PreviewTextInputHandler(Object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        // Use the DataObject.Pasting Handler  
        private void PastingHandler(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!IsTextAllowed(text)) e.CancelCommand();
            }
            else e.CancelCommand();
        }
        bool testtext()//kiểm tra ô dữ liệu trống
        {
            if (string.IsNullOrWhiteSpace(madl.Text))
            {
                System.Windows.MessageBox.Show("Bạn chưa nhập mã đại lý.", "Lỗi");
                madl.Focus();
                return false;
            }//ten
            if (string.IsNullOrWhiteSpace(tentxt.Name))
            {
                System.Windows.MessageBox.Show("Bạn chưa nhập tên đại lý.", "Lỗi");
                tentxt.Focus();
                return false;
            }//ten
            if (string.IsNullOrWhiteSpace(dc.Text))
            {
                System.Windows.MessageBox.Show( "Bạn chưa nhập địa chỉ.", "Lỗi");
                dc.Focus();
                return false;
            }//dia chi
            if (string.IsNullOrWhiteSpace(quantxt.Text))//quan
            {
                System.Windows.MessageBox.Show("Bạn chưa nhập địa chỉ quận.", "Lỗi");
                quantxt.Focus();
                return false;
            }//quan      
            if (string.IsNullOrWhiteSpace(dttxt.Text))
            {
                System.Windows.MessageBox.Show( "Bạn chưa nhập số điện thoại.", "Lỗi");
                dttxt.Focus();
                return false;
            }//dien thoai
            if (string.IsNullOrWhiteSpace(mail.Text))
            {
                System.Windows.MessageBox.Show("Bạn chưa nhập Email.", "Lỗi");
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
                    System.Windows.MessageBox.Show("Email Không hợp lệ", "Lỗi");
                    mail.Text = "";
                    mail.Focus();
                    return false;
                }
            }//email valid or not

            return true;//all true then gud to go
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
