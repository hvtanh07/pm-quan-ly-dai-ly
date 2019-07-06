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
    /// Interaction logic for QuanLyDaiLyVaDonVi.xaml
    /// </summary>
    public partial class QuanLyDaiLyVaDonVi : System.Windows.Controls.UserControl
    {
        private CLoaiDaiLyBUS ldlbus;
        private DanhsachDonviBUS dvbus;
        private CQuyDinhBUS quidinhBUS;
        public QuanLyDaiLyVaDonVi()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ldlbus = new CLoaiDaiLyBUS();
            dvbus = new DanhsachDonviBUS();
            quidinhBUS = new CQuyDinhBUS();
            this.loadData_Vao_GridView();
            this.loadData_Vao_GridViewDV();
        }
        
        private void clear()
        {
            maldl.Text = "";
            ldltxt.Text = "";
            stntxt.Text = "";
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
        //-------------------------------LOAI DAI LY----------------------------------
        private void loadData_Vao_GridView()
        {
            List<LoaiDaiLyDTO> listldl = ldlbus.select();

            if (listldl == null)
            {
                System.Windows.MessageBox.Show("Có lỗi khi lấy hồ sơ từ DB");
                return;
            }
            danhsachldl.ItemsSource = listldl;
        }
        private void loadData_Vao_GridView(List<LoaiDaiLyDTO> listldl)
        {
            if (listldl == null)
            {
                System.Windows.MessageBox.Show("Có lỗi khi lấy hồ sơ từ DB");
                return;
            }
            danhsachldl.ItemsSource = listldl;
        }
        //Search
        private void TxtKeyword1_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                string sKeyword = txtKeyword1.Text.Trim();
                if (sKeyword == null || sKeyword == string.Empty || sKeyword.Length == 0) // tìm tất cả
                {
                    List<LoaiDaiLyDTO> listldl = ldlbus.select();
                    this.loadData_Vao_GridView(listldl);
                }
                else
                {
                    List<LoaiDaiLyDTO> listldl = ldlbus.selectByKeyWord(sKeyword);
                    this.loadData_Vao_GridView(listldl);
                }
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string sKeyword = txtKeyword1.Text.Trim();
            if (sKeyword == null || sKeyword == string.Empty || sKeyword.Length == 0) // tìm tất cả
            {
                List<LoaiDaiLyDTO> listldl = ldlbus.select();
                this.loadData_Vao_GridView(listldl);
            }
            else
            {
                List<LoaiDaiLyDTO> listldl = ldlbus.selectByKeyWord(sKeyword);
                this.loadData_Vao_GridView(listldl);
            }
        }
        bool testtext1()//kiểm tra ô dữ liệu trống
        {
            if (string.IsNullOrWhiteSpace(maldl.Text))
            {
                System.Windows.MessageBox.Show("Bạn chưa nhập loại đại lý.", "Lỗi" );
                maldl.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(ldltxt.Text))
            {
                System.Windows.MessageBox.Show("Bạn chưa nhập loại đại lý.", "Lỗi");
                ldltxt.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(stntxt.Text))
            {
                System.Windows.MessageBox.Show("Bạn chưa nhập số tiền nợ đại lý.", "Lỗi");
                stntxt.Focus();
                return false;
            }
            return true;//all true then gud to go
        }
        private void danhsachldl_CellClick(object sender, SelectionChangedEventArgs e)
        {
            LoaiDaiLyDTO ldl = (LoaiDaiLyDTO)danhsachldl.SelectedItem;
            if (ldl != null)
            {
                maldl.Text = ldl.maLDL;
                ldltxt.Text = ldl.loaidaily.ToString();
                stntxt.Text = ldl.MaxNo.ToString();
            }

        }
        //Thêm
        private void ThemLDL_Click(object sender, RoutedEventArgs e)
        {
            if (!testtext1())
            {
                return;
            }
            LoaiDaiLyDTO ldl = new LoaiDaiLyDTO();
            ldl.maLDL = maldl.Text;
            ldl.loaidaily = int.Parse(ldltxt.Text);
            ldl.MaxNo = int.Parse(stntxt.Text);
            //2. Kiểm tra data hợp lệ or not
            QuiDinhDTO qd = quidinhBUS.Laydulieu();
            int soldl = ldlbus.Laysoloaidl();
            if (soldl >= qd.Maxloaidl)
            {
                System.Windows.MessageBox.Show("Thêm loại đại lý thất bại. Số loại đại lý đã đạt tối đa theo qui định");
                return;
            }
            //3. Thêm vào DB
            bool kq = ldlbus.Them(ldl);
            if (kq == false)
                System.Windows.MessageBox.Show("Thêm loại đại lý thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                System.Windows.MessageBox.Show("Thêm loại đại lý thành công");
                clear();
            }
            loadData_Vao_GridView();
        } 
        //Sửa
        private void SuaLDL_Click(object sender, RoutedEventArgs e)
        {
            if (!testtext1())
            {
                return;
            }
            LoaiDaiLyDTO ldl = new LoaiDaiLyDTO();
            ldl.maLDL = maldl.Text;
            ldl.loaidaily = int.Parse(ldltxt.Text);
            ldl.MaxNo = int.Parse(stntxt.Text);
            //2. Kiểm tra data hợp lệ or not

            //3. Thêm vào DB
            bool kq = ldlbus.Sua(ldl);
            if (kq == false)
                System.Windows.MessageBox.Show("Sửa loại đại lý thất bại. Vui lòng kiểm tra lại dữ liệu");
            else
                System.Windows.MessageBox.Show("Sửa loại đại lý thành công");
            loadData_Vao_GridView();
        }
        //Xóa
        private void XóaLoạiĐạiLý_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult dlr = System.Windows.MessageBox.Show("Bạn có chắc muốn xóa loại đại lý này không ?", "Xóa thông tin", MessageBoxButton.YesNo,MessageBoxImage.Question);
            if (dlr == MessageBoxResult.Yes)
            {

                LoaiDaiLyDTO ldl = (LoaiDaiLyDTO)danhsachldl.SelectedItem;
                if (ldl != null)
                {
                    bool kq = ldlbus.Xoa(ldl);
                    if (kq == false)
                        System.Windows.MessageBox.Show("Xóa loại đại lý thất bại. Loại đại lý có thể đang được sử dụng bởi một đại lý, Sửa hoặc Xóa đại lý để tiếp tục");
                    else
                    {
                        System.Windows.MessageBox.Show("Xóa loại đại lý thành công");
                        this.loadData_Vao_GridView();
                    }

                }
            }
        }
        //-------------------------------DON VI----------------------------------
        private void loadData_Vao_GridViewDV()
        {
            List<DanhsachDonviDTO> listdv = dvbus.select();
            if (listdv == null)
            {
                System.Windows.MessageBox.Show("Có lỗi khi lấy hồ sơ từ DB");
                return;
            }
            dsDonvi.ItemsSource = listdv; 
        }
        private void loadData_Vao_GridViewDV(List<DanhsachDonviDTO> listdv)
        {
            if (listdv == null)
            {
                System.Windows.MessageBox.Show("Có lỗi khi lấy hồ sơ từ DB");
                return;
            }
            dsDonvi.ItemsSource = listdv;
        }
        private void danhsachdv_CellClick(object sender, SelectionChangedEventArgs e)
        {
            DanhsachDonviDTO dv = (DanhsachDonviDTO)dsDonvi.SelectedItem;
            if(dv!=null)
            {
                Donvitxt.Text = dv.donvitinh;
            }
        }
        bool testtext2()//kiểm tra ô dữ liệu trống
        {
            if (string.IsNullOrWhiteSpace(Donvitxt.Text))
            {
                System.Windows.MessageBox.Show( "Bạn chưa nhập đơn vị.", "Lỗi");
                Donvitxt.Focus();
                return false;
            }
            return true;//all true then gud to go
        }
        //Search
        private void SearchDonVi_Click(object sender, RoutedEventArgs e)
        {
            string sKeyword = txtKeyword2.Text.Trim();
            if (sKeyword == null || sKeyword == string.Empty || sKeyword.Length == 0) // tìm tất cả
            {
                List<DanhsachDonviDTO> listdv = dvbus.select();
                this.loadData_Vao_GridViewDV(listdv);
            }
            else
            {
                List<DanhsachDonviDTO> listdv = dvbus.selectByKeyWord(sKeyword);
                this.loadData_Vao_GridViewDV(listdv);
            }
        }

        private void TxtKeyword2_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                string sKeyword = txtKeyword2.Text.Trim();
                if (sKeyword == null || sKeyword == string.Empty || sKeyword.Length == 0) // tìm tất cả
                {
                    List<DanhsachDonviDTO> listdv = dvbus.select();
                    this.loadData_Vao_GridViewDV(listdv);
                }
                else
                {
                    List<DanhsachDonviDTO> listdv = dvbus.selectByKeyWord(sKeyword);
                    this.loadData_Vao_GridViewDV(listdv);
                }
            }
        }
        //Xóa
        private void XóaĐơnVị_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult dlr = System.Windows.MessageBox.Show("Bạn có chắc muốn xóa đơn vị này không ?", "Xóa thông tin", MessageBoxButton.YesNo, MessageBoxImage.Question);


            DanhsachDonviDTO dv = (DanhsachDonviDTO)dsDonvi.SelectedItem;
            if (dv != null)
            {
                bool kq = dvbus.Xoa(dv);
                if (kq == false)
                    System.Windows.MessageBox.Show("Xóa đơn vị thất bại. Đơn vị có thể đang được sử dụng bởi một mặt hàng, Sửa hoặc Xóa mặt hàng để tiếp tục");
                else
                {
                    System.Windows.MessageBox.Show("Xóa đơn vị thành công");
                    this.loadData_Vao_GridViewDV();
                }
            }

        }
            
        //Thêm
        private void ThemDV_Click(object sender, RoutedEventArgs e)
        {
            if (!testtext2())
            {
                return;
            }
            DanhsachDonviDTO dv = new DanhsachDonviDTO();
            dv.donvitinh = Donvitxt.Text;
            //2. Kiểm tra data hợp lệ or not
            QuiDinhDTO qd = quidinhBUS.Laydulieu();
            int sodv = dvbus.Laysodonvi();
            if (sodv >= qd.soluongDVT)
            {
                System.Windows.MessageBox.Show("Thêm đơn vị thất bại. Số đơn vị đã đạt tối đa theo qui định");
                return;
            }
            //3. Thêm vào DB
            bool kq = dvbus.Them(dv);
            if (kq == false)
                System.Windows.MessageBox.Show("Thêm đơn vị thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                System.Windows.MessageBox.Show("Thêm đơn vị thành công");
                clear();
            }
            loadData_Vao_GridViewDV();
        }

        
    }
}
