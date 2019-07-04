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
using System.Windows.Shapes;

namespace QLDL
{
    /// <summary>
    /// Interaction logic for LapPhieuThuTienForm.xaml
    /// </summary>
    public partial class LapPhieuThuTienForm : Window
    {
        int tienthucu = 0;
        private CHoSoDaiLyBUS hsBUS;
        private PhieuThuTienBUS pttBUS;
        public LapPhieuThuTienForm()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LapPhieuThuTien(object sender, RoutedEventArgs e)
        {
            hsBUS = new CHoSoDaiLyBUS();
            pttBUS = new PhieuThuTienBUS();
            this.loadData_Vao_GridView();
            Taodatasource();
            Ngaythu.SelectedDate = DateTime.Today;
        }
        private void Taodatasource()
        {
            List<string> madl = new List<string>();
            madl = hsBUS.Laymadl();
            madltxt.ItemsSource = madl;
        }
        //them
        private void ButtonThem(object sender, RoutedEventArgs e)
        {
            if (!testtext())
            {
                return;
            }
            PhieuThuTienDTO ptt = new PhieuThuTienDTO();
            ptt.madl = madltxt.Text;
            ptt.mathutien = maptt.Text;
            ptt.ngaythu = Ngaythu.SelectedDate.Value;
            ptt.sotienthu = int.Parse(tienthu.Text);
            //2. Kiểm tra data hợp lệ or not
            //kiểm tra trong quận đã đạt tối đa số đại lý chưa
            if (ptt.sotienthu > hsBUS.Laytienno(ptt.madl))
            {
                System.Windows.MessageBox.Show("Thêm thông tin phiếu thu thất bại. Số tiền thu không được vượt quá số tiền đang nợ");
                return;
            }
            int noht = hsBUS.Laytienno(ptt.madl) - ptt.sotienthu;

            //3. Thêm vào DB

            {
                bool kq1 = hsBUS.Suano(ptt.madl, noht);
                bool kq2 = pttBUS.Them(ptt);
                if (kq1 == false && kq2 == false)
                    System.Windows.MessageBox.Show("Thêm thông tin phiếu thu thất bại. Vui lòng kiểm tra lại dữ liệu");
                else
                {
                    System.Windows.MessageBox.Show("Thêm thông tin phiếu thu thành công");
                    maptt.Text = "";
                    tienthu.Text = "";
                    Ngaythu.DisplayDate = DateTime.Today;
                }
            }
            loadData_Vao_GridView();
        }
        //sua
        private void SửaBảnGhi_Click(object sender, RoutedEventArgs e)
        {

            if (!testtext())
            {
                return;
            }

            PhieuThuTienDTO ptt = new PhieuThuTienDTO();
            ptt.mathutien = maptt.Text;
            ptt.madl = madltxt.Text;
            ptt.ngaythu = Ngaythu.SelectedDate.Value;
            ptt.sotienthu = int.Parse(tienthu.Text);
            //check data hợp lệ
            int thuphatsinh = ptt.sotienthu - tienthucu;
            int nochuathutien = hsBUS.Laytienno(ptt.madl) + tienthucu;
            if (ptt.sotienthu > nochuathutien)
            {
                System.Windows.MessageBox.Show("Thêm thông tin phiếu thu thất bại. Số tiền thu không được vượt quá số tiền đang nợ");
                return;
            }
            int noht = hsBUS.Laytienno(ptt.madl) - thuphatsinh;
            //load vào database
            bool kq1 = hsBUS.Suano(ptt.madl, noht);
            bool kq2 = pttBUS.Sua(ptt);
            if (kq1 == false && kq2 == false)
                System.Windows.MessageBox.Show("Sửa thông tin phiếu thu thất bại. Vui lòng kiểm tra lại dữ liệu");
            else
                System.Windows.MessageBox.Show("Sửa thông tin phiếu thu thành công");

            this.loadData_Vao_GridView();
        }
        //xoa
        private void XóaBảnGhi_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult dlr = System.Windows.MessageBox.Show("Bạn có chắc muốn xóa mặt hàng này không ?", "Xóa thông tin", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (dlr == MessageBoxResult.Yes)
            {

                PhieuThuTienDTO ptt = (PhieuThuTienDTO)Dsphieuthu.SelectedItem;
                if (ptt != null)
                {
                    bool kq = pttBUS.Xoa(ptt);
                    if (kq == false)
                        System.Windows.MessageBox.Show("Xóa thông tin phiếu thu thất bại. Vui lòng kiểm tra lại dũ liệu");
                    else
                    {
                        System.Windows.MessageBox.Show("Xóa thông tin phiếu thu thành công");
                        this.loadData_Vao_GridView();
                    }
                }
                    
            }
            loadData_Vao_GridView();
        }
        //search
        private void Button1_Click(object sender, EventArgs e)
        {
            string sKeyword = txtKeyword.Text.Trim();
            if (sKeyword == null || sKeyword == string.Empty || sKeyword.Length == 0) // tìm tất cả
            {
                List<PhieuThuTienDTO> listphieuthu = pttBUS.select();
                this.loadData_Vao_GridView(listphieuthu);
            }
            else
            {
                List<PhieuThuTienDTO> listphieuthu = pttBUS.selectByKeyWord(sKeyword);
                this.loadData_Vao_GridView(listphieuthu);
            }
        }
        private void TxtKeyword_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                string sKeyword = txtKeyword.Text.Trim();
                if (sKeyword == null || sKeyword == string.Empty || sKeyword.Length == 0) // tìm tất cả
                {
                    List<PhieuThuTienDTO> listphieuthu = pttBUS.select();
                    this.loadData_Vao_GridView(listphieuthu);
                }
                else
                {
                    List<PhieuThuTienDTO> listphieuthu = pttBUS.selectByKeyWord(sKeyword);
                    this.loadData_Vao_GridView(listphieuthu);
                }
            }
        }
        
        bool testtext()//kiểm tra ô dữ liệu trống
        {
            if (string.IsNullOrWhiteSpace(maptt.Text))
            {
                System.Windows.MessageBox.Show("Bạn chưa nhập số mã phiếu thu.", "Lỗi");
                maptt.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(tienthu.Text))
            {
                System.Windows.MessageBox.Show( "Bạn chưa nhập số tiền thu.", "Lỗi");
                tienthu.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(maptt.Text))
            {
                System.Windows.MessageBox.Show("Bạn chưa nhập mã phiếu thu.", "Lỗi");
                maptt.Focus();
                return false;
            }
            return true;//all true then gud to go
        }

        private void loadData_Vao_GridView()
        {
            List<PhieuThuTienDTO> listMatHang = pttBUS.select();

            if (listMatHang == null)
            {
                System.Windows.MessageBox.Show("Có lỗi khi lấy hồ sơ từ DB");
                return;
            }


            Dsphieuthu.ItemsSource = listMatHang;

            
        }
        private void loadData_Vao_GridView(List<PhieuThuTienDTO> listptt)
        {
            if (listptt == null)
            {
                System.Windows.MessageBox.Show("Có lỗi khi lấy hồ sơ từ DB");
                return;
            }

            Dsphieuthu.ItemsSource = listptt;
            
        }


        private void Dsphieuthu_CellClick(object sender, SelectionChangedEventArgs e)
        {
            PhieuThuTienDTO ptt = new PhieuThuTienDTO();
            ptt = (PhieuThuTienDTO)Dsphieuthu.SelectedItem;
            if (ptt != null)
            {
                maptt.Text = ptt.mathutien;
                madltxt.Text = ptt.madl;
                Ngaythu.SelectedDate = ptt.ngaythu;
                tienthu.Text = ptt.sotienthu.ToString();
                tienthucu = int.Parse(tienthu.Text);

            }
        }
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
    }
}
