using QLDL_BUS;
using QLDL_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QLDL
{
    /// <summary>
    /// Interaction logic for LapPhieuXuatHangForm.xaml
    /// </summary>
    public partial class LapPhieuXuatHangForm : Window
    {
        private ChitietphieuxuatBUS ctpxBUS;
        private CHoSoDaiLyBUS hsBUS;
        private PhieuxuathangBUS pxhBUS;
        public LapPhieuXuatHangForm()
        {
            InitializeComponent();
        }
        private void loadData_Vao_GridView()
        {
            List<PhieuxuathangDTO> listpx = pxhBUS.select();

            if (listpx == null)
            {
                MessageBox.Show("Có lỗi khi lấy hồ sơ từ DB");
                return;
            }


            dsphieuxh.ItemsSource = listpx;

        }
        private void loadData_Vao_GridView(List<PhieuxuathangDTO> listpx)
        {
            if (listpx == null)
            {
                MessageBox.Show("Có lỗi khi lấy hồ sơ từ DB");
                return;
            }

            dsphieuxh.ItemsSource = listpx;

        }
        bool testtext()//kiểm tra ô dữ liệu trống
        {
            if (string.IsNullOrWhiteSpace(maPhieu.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã phiếu xuất.", "Lỗi" );
                maPhieu.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(madltxt.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã đại lý.", "Lỗi");
                maPhieu.Focus();
                return false;
            }
            return true;
        }
        private void Taodatasource()
        {
            List<string> madl = new List<string>();
            madl = hsBUS.Laymadl();
            madltxt.ItemsSource = madl;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Them
        private void ButtonThem(object sender, RoutedEventArgs e)
        {
            if (!testtext())
            {
                return;
            }
            PhieuxuathangDTO xh = new PhieuxuathangDTO();
            xh.maxh = maPhieu.Text;
            xh.madl = madltxt.Text;
            xh.ngaylap = DateTime.Today;
            xh.tongtien = 0;
            bool kq = pxhBUS.Them(xh);
            if (kq == false)
                MessageBox.Show("Thêm hồ sơ thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                MessageBox.Show("Thêm hồ sơ thành công");
                maPhieu.Text = "";
                madltxt.Text = "";
            }
            if (xh != null)
            {
                PhieuXuatHang frm = new PhieuXuatHang(xh, true);
                frm.ShowDialog();
            }
            loadData_Vao_GridView();
        }
        //Search
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            string sKeyword = txtKeyword.Text.Trim();
            if (sKeyword == null || sKeyword == string.Empty || sKeyword.Length == 0) // tìm tất cả
            {
                List<PhieuxuathangDTO> listctpx = pxhBUS.select();
                this.loadData_Vao_GridView(listctpx);
            }
            else
            {
                List<PhieuxuathangDTO> listctpx = pxhBUS.selectByKeyWord(sKeyword);
                this.loadData_Vao_GridView(listctpx);
            }
        }

        private void TxtKeyword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                string sKeyword = txtKeyword.Text.Trim();
                if (sKeyword == null || sKeyword == string.Empty || sKeyword.Length == 0) // tìm tất cả
                {
                    List<PhieuxuathangDTO> listctpx = pxhBUS.select();
                    this.loadData_Vao_GridView(listctpx);
                }
                else
                {
                    List<PhieuxuathangDTO> listctpx = pxhBUS.selectByKeyWord(sKeyword);
                    this.loadData_Vao_GridView(listctpx);
                }
            }
        }

       

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ctpxBUS = new ChitietphieuxuatBUS();
            hsBUS = new CHoSoDaiLyBUS();
            pxhBUS = new PhieuxuathangBUS();
            loadData_Vao_GridView();
            Taodatasource();
            thang.Text = DateTime.Now.ToString("MM");
        }

        private void Dsphieuxh_CellClick(object sender, SelectionChangedEventArgs e)
        {
            PhieuxuathangDTO pxhBUS = new PhieuxuathangDTO();
            pxhBUS = (PhieuxuathangDTO)dsphieuxh.SelectedItem;
            if (pxhBUS != null)
            {
                maPhieu.Text = pxhBUS.maxh;
                madltxt.SelectedItem = pxhBUS.madl;
                thang.Text = pxhBUS.ngaylap.Month.ToString();
            }

        }
        //Xoa
        private void XóaBảnGhi_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult dlr = MessageBox.Show("Bạn có chắc muốn xóa đại lý này không ?", "Xóa thông tin", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (dlr == MessageBoxResult.Yes)
            {
                
                    PhieuxuathangDTO px = (PhieuxuathangDTO)dsphieuxh.SelectedItem;
                if (px != null)
                {
                    bool kq1 = ctpxBUS.Xoatheophieuxuat(px.maxh);
                    if (kq1 == false)
                        MessageBox.Show("Xóa chi tiết phiếu thất bại. Vui lòng kiểm tra lại dũ liệu");
                    else
                    {
                        bool kq2 = pxhBUS.Xoa(px);
                        if (kq2 == false)
                            MessageBox.Show("Xóa phiếu thất bại. Vui lòng kiểm tra lại dũ liệu");
                        else
                        {
                            MessageBox.Show("Xóa phiếu thành công");
                        }
                    }
                }
                this.loadData_Vao_GridView();
            }
        }
        //Sửa
        private void SửaBảnGhi_Click(object sender, RoutedEventArgs e)
        {
            PhieuxuathangDTO xh = (PhieuxuathangDTO)dsphieuxh.SelectedItem;
            if (xh != null)
            {
                PhieuXuatHang frm = new PhieuXuatHang(xh, true);
                frm.ShowDialog();
            }
            this.loadData_Vao_GridView();
        }

    }
}
