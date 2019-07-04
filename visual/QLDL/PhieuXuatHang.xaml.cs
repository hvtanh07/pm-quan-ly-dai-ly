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
    /// Interaction logic for PhieuXuatHang.xaml
    /// </summary>
    public partial class PhieuXuatHang : Window
    {
        bool suaornot;
        int tongtien = 0;
        int tongtiencu = 0;
        private CMatHangBUS mhBUS;
        private PhieuxuathangBUS pxhBUS;
        private CHoSoDaiLyBUS hsBUS;
        private CLoaiDaiLyBUS ldlBUS;
        private CHoSoDaiLyBUS dlBUS;
        private ChitietphieuxuatBUS ctpxBUS;
        private PhieuxuathangDTO pxhDTO;
        public PhieuXuatHang()
        {
            InitializeComponent();
        }
        public PhieuXuatHang(PhieuxuathangDTO xh, bool sua)
        {
            ldlBUS = new CLoaiDaiLyBUS();
            hsBUS = new CHoSoDaiLyBUS();
            dlBUS = new CHoSoDaiLyBUS();
            pxhBUS = new PhieuxuathangBUS();
            ctpxBUS = new ChitietphieuxuatBUS();
            mhBUS = new CMatHangBUS();
            pxhDTO = xh;
            suaornot = sua;
            InitializeComponent();
        }
        private void PhieuXuatHang_Load(object sender, RoutedEventArgs e)
        {
            if (pxhDTO != null)
            {
                maPhieu.Text = pxhDTO.maxh;
                madltxt.Text = pxhDTO.madl;
                thang.Text = pxhDTO.ngaylap.Month.ToString();
                Taodatasource();
            }
            loadData_Vao_GridView();
            capnhattien();
            tongtiencu = tongtien;
        }



        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
        bool testtext()//kiểm tra ô dữ liệu trống
        {
            if (string.IsNullOrWhiteSpace(soluong.Text))
            {
                System.Windows.MessageBox.Show(soluong.Name, "Bạn chưa nhập số lượng mặt hàng.");
                soluong.Focus();
                return false;
            }
            return true;//all true then gud to go
        }

        //lấy datasouce cho comboox
        private void Taodatasource()
        {
            List<string> mamh = new List<string>();
            mamh = mhBUS.Laymamh();
            mamhtxt.ItemsSource = mamh;
        }
        private void loadData_Vao_GridView()
        {
            List<ChitietphieuxuatDTO> listctpx = ctpxBUS.select(maPhieu.Text);

            if (listctpx == null)
            {
                System.Windows.MessageBox.Show("Có lỗi khi lấy hồ sơ từ DB");
                return;
            }
            danhsachmh.ItemsSource = listctpx;
        }
        private void loadData_Vao_GridView(List<ChitietphieuxuatDTO> listctpx)
        {
            if (listctpx == null)
            {
                System.Windows.MessageBox.Show("Có lỗi khi lấy hồ sơ từ DB");
                return;
            }
            danhsachmh.ItemsSource = listctpx;
        }
        private void capnhattien()
        {
            tongtien = 0;
            foreach (ChitietphieuxuatDTO item in danhsachmh.ItemsSource)
            {
                tongtien += item.tongtien;
            }
            tongtientxt.Text = tongtien.ToString();
        }
        //Thêm
        private void ButtonThem_Click(object sender, RoutedEventArgs e)
        {
            if (!testtext())
            {
                return;
            }
            ChitietphieuxuatDTO ctpx = new ChitietphieuxuatDTO();
            ctpx.maxh = maPhieu.Text;
            ctpx.mamh = mamhtxt.Text;
            ctpx.soluong = int.Parse(soluong.Text);
            ctpx.tongtien = int.Parse(soluong.Text) * mhBUS.Laygiatienmh(mamhtxt.Text);
            //2. Kiểm tra data hợp lệ or not
            if(ctpxBUS.Timmathangtrongphieuxuat(ctpx.maxh, ctpx.mamh))
            {
                System.Windows.MessageBox.Show("Thêm mặt hàng thất bại. mặt hàng đã tồn tại.");
                return;
            }
            //3. Thêm vào DB
            bool kq = ctpxBUS.Them(ctpx);
            if (kq == false)
                System.Windows.MessageBox.Show("Thêm mặt hàng thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                System.Windows.MessageBox.Show("Thêm mặt hàng thành công");
            }
            loadData_Vao_GridView();
            capnhattien();
        }
        //Sửa
        private void ButtonSua_Click(object sender, RoutedEventArgs e)
        {
            if (!testtext())
            {
                return;
            }
            ChitietphieuxuatDTO ctpx = new ChitietphieuxuatDTO();
            ctpx.maxh = maPhieu.Text;
            ctpx.mamh = mamhtxt.Text;
            ctpx.soluong = int.Parse(soluong.Text);
            ctpx.tongtien = int.Parse(soluong.Text) * mhBUS.Laygiatienmh(mamhtxt.Text);
            //2. Kiểm tra data hợp lệ or not

            //3. Thêm vào DB           
            bool kq = ctpxBUS.Sua(ctpx);
            if (kq == false)
                System.Windows.MessageBox.Show("Sửa mặt hàng thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                System.Windows.MessageBox.Show("Sửa mặt hàng thành công");
            }
            loadData_Vao_GridView();
            capnhattien();
        }
        //Xóa
        private void Xóa_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult dlr = System.Windows.MessageBox.Show("Bạn có chắc muốn xóa mặt hàng này không ?", "Xóa thông tin", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (dlr == MessageBoxResult.Yes)
            {

                ChitietphieuxuatDTO ctpxc = (ChitietphieuxuatDTO)danhsachmh.SelectedItem;
                ctpxc.maxh = maPhieu.Text;
                if (ctpxc != null)
                {
                    bool kq = ctpxBUS.Xoa(ctpxc);
                    if (kq == false)
                        System.Windows.MessageBox.Show("Xóa mặt hàng thất bại. Vui lòng kiểm tra lại dũ liệu");
                    else
                    {
                        System.Windows.MessageBox.Show("Xóa mặt hàng thành công");
                        this.loadData_Vao_GridView();
                        capnhattien();
                    }


                }
            }
        }
        //Search
        private void TxtKeyword_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                string sKeyword = txtKeyword.Text.Trim();
                if (sKeyword == null || sKeyword == string.Empty || sKeyword.Length == 0) // tìm tất cả
                {
                    List<ChitietphieuxuatDTO> listctpx = ctpxBUS.select(maPhieu.Text);
                    this.loadData_Vao_GridView(listctpx);
                }
                else
                {
                    List<ChitietphieuxuatDTO> listctpx = ctpxBUS.selectByKeyWord(sKeyword, maPhieu.Text);
                    this.loadData_Vao_GridView(listctpx);
                }
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string sKeyword = txtKeyword.Text.Trim();
            if (sKeyword == null || sKeyword == string.Empty || sKeyword.Length == 0) // tìm tất cả
            {
                List<ChitietphieuxuatDTO> listctpx = ctpxBUS.select(maPhieu.Text);
                this.loadData_Vao_GridView(listctpx);
            }
            else
            {
                List<ChitietphieuxuatDTO> listctpx = ctpxBUS.selectByKeyWord(sKeyword, maPhieu.Text);
                this.loadData_Vao_GridView(listctpx);
            }
        }
        //Hoàn tất
        private void ButtonLuu(object sender, RoutedEventArgs e)
        {
            PhieuxuathangDTO px = new PhieuxuathangDTO();
            px.maxh = maPhieu.Text;
            px.tongtien = tongtien;
            //2. Kiểm tra data hợp lệ or not
            int noht = dlBUS.Layno(madltxt.Text);
            int nomax = ldlBUS.Laysotiennomax(hsBUS.Layloaidl(madltxt.Text));
            int nomoi = noht;
            if (!suaornot)
            {
                nomoi += tongtien;
            }
            else
            {
                //lay tong tien moi - tong tien cu = tien phat sinh sau khi sua 
                nomoi = noht + (tongtien - tongtiencu);
            }
            if (nomoi > nomax)
            {
                System.Windows.MessageBox.Show("Đại lý đã vượt quá số tiền nợ tối đa cho phép, vui lòng thử lại");
                return;
            }
            //thay no hien tại
            //3. Thêm vào DB
            //bool kq1 = dlBUS.Suano(madltxt.Text, nomoi);
            bool kq1 = dlBUS.Suano(madltxt.Text, nomoi);
            bool kq2 = pxhBUS.Sua(px);
            if (kq2 == false && kq1 == false)
                System.Windows.MessageBox.Show("Lưu thông tin phiếu thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                System.Windows.MessageBox.Show("Lưu thông tin phiếu thành công");
                this.Close();
            }
        }

        private void danhsachmh_CellClick(object sender, SelectionChangedEventArgs e)
        {
            ChitietphieuxuatDTO ctpxc = (ChitietphieuxuatDTO)danhsachmh.SelectedItem;
            if (ctpxc!=null)
            {
                mamhtxt.Text = ctpxc.mamh;
                soluong.Text = ctpxc.soluong.ToString();
            }
            
        }

        
    }
}
