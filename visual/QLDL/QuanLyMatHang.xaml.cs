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

    public partial class QuanLyMatHang : System.Windows.Controls.UserControl
    {
        private CQuyDinhBUS qdBUS;
        private CMatHangBUS mhbus;
        private DanhsachDonviBUS dvBUS;
        private ChitietphieuxuatBUS ctpxBUS;
        public QuanLyMatHang()
        {
            InitializeComponent();
        }
        private void QuanLyMatHangForm_Load(object sender, RoutedEventArgs e)
        {
            ctpxBUS = new ChitietphieuxuatBUS();
            dvBUS = new DanhsachDonviBUS();
            qdBUS = new CQuyDinhBUS();
            mhbus = new CMatHangBUS();
            this.loadData_Vao_GridView();
            Taodatasource();
        }
        private void Taodatasource()
        {
            List<string> madv = new List<string>();
            madv = dvBUS.Laydonvi();
            dvt.ItemsSource = madv;
        }
        //Search
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            string sKeyword = txtKeyword.Text.Trim();
            if (sKeyword == null || sKeyword == string.Empty || sKeyword.Length == 0) // tìm tất cả
            {
                List<DanhsachmathangDTO> listMatHang = mhbus.select();
                this.loadData_Vao_GridView(listMatHang);
            }
            else
            {
                List<DanhsachmathangDTO> listMatHang = mhbus.selectByKeyWord(sKeyword);
                this.loadData_Vao_GridView(listMatHang);
            }
        }

        private void TxtKeyword_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                string sKeyword = txtKeyword.Text.Trim();
                if (sKeyword == null || sKeyword == string.Empty || sKeyword.Length == 0) // tìm tất cả
                {
                    List<DanhsachmathangDTO> listMatHang = mhbus.select();
                    this.loadData_Vao_GridView(listMatHang);
                }
                else
                {
                    List<DanhsachmathangDTO> listMatHang = mhbus.selectByKeyWord(sKeyword);
                    this.loadData_Vao_GridView(listMatHang);
                }
            }
        }
        //Them
        
        private void ButtonThem_Click(object sender, RoutedEventArgs e)
        {
            if (!testtext())
            {
                return;
            }
            DanhsachmathangDTO mh = new DanhsachmathangDTO();
            mh.mamh = mamh.Text;
            mh.tenmh = tmh.Text;
            mh.hansudung = hsd.SelectedDate.Value;
            mh.gia = int.Parse(gia.Text);
            mh.donvitinh = dvt.Text;
            //2. Kiểm tra data hợp lệ or not
            QuiDinhDTO qd = qdBUS.Laydulieu();
            int somh = mhbus.Laysomathang();
            if (somh > qd.soluongMH)
            {
                System.Windows.MessageBox.Show("Thêm mặt hàng thất bại. Số mặt hàng đã đạt tối đa theo qui định");
                return;
            }
            //3. Thêm vào DB
            bool kq = mhbus.Them(mh);
            if (kq == false)
                System.Windows.MessageBox.Show("Thêm mặt hàng thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                System.Windows.MessageBox.Show("Thêm mặt hàng thành công");
                clear();
            }
            loadData_Vao_GridView();
        }
        //Sửa 
        private void SửaMặtHàng_Click(object sender, RoutedEventArgs e)
        {

            if (!testtext())
            {
                return;
            }

            DanhsachmathangDTO mh = new DanhsachmathangDTO();
            mh.mamh = mamh.Text;
            mh.tenmh = tmh.Text;
            mh.hansudung = hsd.SelectedDate.Value;
            mh.gia = int.Parse(gia.Text);
            mh.donvitinh = dvt.Text;
            bool kq = mhbus.Sua(mh);
            if (kq == false)
                System.Windows.MessageBox.Show("Sửa mặt hàng thất bại. Vui lòng kiểm tra lại dữ liệu");
            else
                System.Windows.MessageBox.Show("Sửa mặt hàng thành công");

            this.loadData_Vao_GridView();
        }
        private void ButtonSua_Click(object sender, RoutedEventArgs e)
        {
            if (!testtext())
            {
                return;
            }
            DanhsachmathangDTO mh = new DanhsachmathangDTO();
            mh.mamh = mamh.Text;
            mh.tenmh = tmh.Text;
            mh.hansudung = hsd.SelectedDate.Value;
            mh.gia = int.Parse(gia.Text);
            mh.donvitinh = dvt.Text;
            //2. Kiểm tra data hợp lệ or not            
            //3. Thêm vào DB
            bool kq = mhbus.Sua(mh);
            if (kq == false)
                System.Windows.MessageBox.Show("Sửa mặt hàng thất bại. Vui lòng kiểm tra lại dữ liệu");
            else
                System.Windows.MessageBox.Show("Sửa mặt hàng thành công");
            loadData_Vao_GridView();
        }
        //Xoa
        private void ButtonXoa_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tmh.Text))
            {
                System.Windows.MessageBox.Show("Xóa mặt hàng thất bại. Chưa nhập mã mặt hàng cần xóa.");
                tmh.Focus();
                return;
            }
            MessageBoxResult dlr = System.Windows.MessageBox.Show("Bạn có chắc muốn xóa mặt hàng này không ?", "Xóa thông tin", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (dlr == MessageBoxResult.Yes)
            {
                DanhsachmathangDTO mh = new DanhsachmathangDTO();
                mh.mamh = mamh.Text;
                //2. Kiểm tra data hợp lệ or not
                //3. Thêm vào DB
                bool kq1 = ctpxBUS.XoatheoMH(mh.mamh);
                bool kq2 = mhbus.Xoa(mh);
                if (kq2 == false || kq1 == false)
                    System.Windows.MessageBox.Show("Xóa mặt hàng thất bại. Vui lòng kiểm tra lại dũ liệu");
                else
                {
                    System.Windows.MessageBox.Show("Xóa mặt hàng thành công");
                    clear();
                }
            }
            loadData_Vao_GridView();
        }

        
        private void XóaMặtHàng_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult dlr = System.Windows.MessageBox.Show("Bạn có chắc muốn xóa mặt hàng này không ?", "Xóa thông tin", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (dlr == MessageBoxResult.Yes)
            {
                {

                    DanhsachmathangDTO dl = (DanhsachmathangDTO)dsmathang.SelectedItem;
                    if (dl != null)
                    {
                        bool kq1 = ctpxBUS.XoatheoMH(dl.mamh);
                        bool kq2 = mhbus.Xoa(dl);
                        if (kq1 == false || kq2 == false)
                            System.Windows.MessageBox.Show("Xóa mặt hàng thất bại. Vui lòng kiểm tra lại dũ liệu");
                        else
                        {
                            System.Windows.MessageBox.Show("Xóa mặt hàng thành công");
                            this.loadData_Vao_GridView();
                        }
                    }

                }
            }
            loadData_Vao_GridView();
        }
        private void loadData_Vao_GridView()
        {
            List<DanhsachmathangDTO> listMatHang = mhbus.select();

            if (listMatHang == null)
            {
                System.Windows.MessageBox.Show("Có lỗi khi lấy hồ sơ từ DB");
                return;
            }
            dsmathang.ItemsSource = listMatHang;
        }
        private void loadData_Vao_GridView(List<DanhsachmathangDTO> listMatHang)
        {
            if (listMatHang == null)
            {
                System.Windows.MessageBox.Show("Có lỗi khi lấy hồ sơ từ DB");
                return;
            }

            dsmathang.ItemsSource = listMatHang;

        }
        //XÓA CÁC Ô ĐIỀN DỮ LIỆU
        private void clear()
        {
            mamh.Text = "";
            tmh.Text = "";
            hsd.DisplayDate = DateTime.Today;
            gia.Text = "";
            dvt.Text = "";
        }
        //RÀNG BUỘC CỦA DỮ LIỆU NHẬP VÀO
        bool testtext()//kiểm tra ô dữ liệu trống
        {
            if (string.IsNullOrWhiteSpace(mamh.Text))
            {
                System.Windows.MessageBox.Show("Bạn chưa nhập mã mặt hàng.", "Lỗi");
                mamh.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(tmh.Text))
            {
                System.Windows.MessageBox.Show("Bạn chưa nhập tên mặt hàng.", "Lỗi");
                tmh.Focus();
                return false;
            }
            if (DateTime.Compare(hsd.DisplayDate, DateTime.Today) < 0)
            {
                System.Windows.MessageBox.Show("Mặt hàng đã hết hạn sử dụng hoặc hạn sử dụng không đúng, vui lòng thử lại", "Lỗi");
                return false;
            }//check hạn sử dụng
            if (string.IsNullOrWhiteSpace(gia.Text))
            {
                System.Windows.MessageBox.Show("Bạn chưa nhập giá.", "Lỗi");
                gia.Focus();
                return false;
            }//gia 
            if (string.IsNullOrWhiteSpace(dvt.Text))//quan
            {
                System.Windows.MessageBox.Show("Bạn chưa nhập đơn vị tính.", "Lỗi");
                dvt.Focus();
                return false;
            }//don vi tinh      

            return true;//all true then gud to go
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
        private void Dsmathang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DanhsachmathangDTO mh = new DanhsachmathangDTO();
            mh = (DanhsachmathangDTO)dsmathang.SelectedItem;
            if (mh != null)
            {
                mamh.Text = mh.mamh;
                tmh.Text = mh.tenmh;
                hsd.SelectedDate = mh.hansudung;
                gia.Text = mh.gia.ToString();
                dvt.Text = mh.donvitinh;
            }
        }

        private void LapPhieuXuatHangButton_Click(object sender, RoutedEventArgs e)
        {
            Window win = new LapPhieuXuatHangForm();
            win.ShowDialog();
        }
    }
}
