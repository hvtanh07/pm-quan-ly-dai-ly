using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using QLDL_BUS;
using QLDL_DTO;

namespace QLDL
{

    public partial class QuanLyDaiLyForm : System.Windows.Controls.UserControl
    {
        private CHoSoDaiLyBUS hsBUS;
        private NoThangtruocBUS nttBUS;
        private PhieuThuTienBUS pttBUS;
        private ChitietphieubcdtBUS ctbcdtBUS;
        private ChitietphieubcnoBUS ctbcnoBUS;
        private ChitietphieuxuatBUS ctpxBUS;
        private PhieuxuathangBUS pxhBUS;
        public QuanLyDaiLyForm()
        {
            InitializeComponent();
        }
        private void QuanlyDailyForm_Load(object sender, EventArgs e)
        {
            hsBUS = new CHoSoDaiLyBUS();
            nttBUS = new NoThangtruocBUS();
            pttBUS = new PhieuThuTienBUS();
            ctbcdtBUS = new ChitietphieubcdtBUS();
            ctbcnoBUS = new ChitietphieubcnoBUS();
            ctpxBUS = new ChitietphieuxuatBUS();
            pxhBUS = new PhieuxuathangBUS();
            this.loadData_Vao_GridView();
        }

        
        //Search bằng nút search
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            string sKeyword = txtKeyword.Text.Trim();
            if (sKeyword == null || sKeyword == string.Empty || sKeyword.Length == 0) // tìm tất cả
            {
                List<CHoSoDaiLyDTO> listHoSoDaiLy = hsBUS.select();
                this.loadData_Vao_GridView(listHoSoDaiLy);
            }
            else
            {
                List<CHoSoDaiLyDTO> listHoSoDaiLy = hsBUS.selectByKeyWord(sKeyword);
                this.loadData_Vao_GridView(listHoSoDaiLy);
            }
        }
        //Search bằng nút enter
        private void TxtKeyword_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                string sKeyword = txtKeyword.Text.Trim();
                if (sKeyword == null || sKeyword == string.Empty || sKeyword.Length == 0) // tìm tất cả
                {
                    List<CHoSoDaiLyDTO> listHoSoDaiLy = hsBUS.select();
                    this.loadData_Vao_GridView(listHoSoDaiLy);
                }
                else
                {
                    List<CHoSoDaiLyDTO> listHoSoDaiLy = hsBUS.selectByKeyWord(sKeyword);
                    this.loadData_Vao_GridView(listHoSoDaiLy);
                }
            }
        }
        
        private void loadData_Vao_GridView(List<CHoSoDaiLyDTO> listHoSoDaiLy)
        {
            if (listHoSoDaiLy == null)
            {
                System.Windows.MessageBox.Show("Có lỗi khi lấy hồ sơ từ DB");
                return;
            }
            dgvBangDanhSach.ItemsSource = null;
            dgvBangDanhSach.ItemsSource = listHoSoDaiLy;
        }
        //Load ListView
        private void loadData_Vao_GridView()
        {
            List<CHoSoDaiLyDTO> listHoSoDaiLy = hsBUS.select();
            if (listHoSoDaiLy == null)
            {
                System.Windows.Forms.MessageBox.Show("Có lỗi khi lấy hồ sơ từ DB");
                return;
            }
            dgvBangDanhSach.ItemsSource = null;
            dgvBangDanhSach.ItemsSource = listHoSoDaiLy;
        }
        //Sửa
        private void SửaĐạiLý_Click(object sender, RoutedEventArgs e)
        {

            CHoSoDaiLyDTO hs = (CHoSoDaiLyDTO)dgvBangDanhSach.SelectedItem;
            if (hs!=null)
            {
                Window win = new SuaDaiLyForm(hs);
                win.ShowDialog();
            }
            this.loadData_Vao_GridView();
        }

        private void XóaĐạiLý_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult dlr = System.Windows.MessageBox.Show("Bạn có chắc muốn xóa đại lý này không ?", "Xóa thông tin", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (dlr == MessageBoxResult.Yes)
            {
                CHoSoDaiLyDTO dl = (CHoSoDaiLyDTO)dgvBangDanhSach.SelectedItem;
                
                List<string> dsmapx = pxhBUS.layMAtheoDL(dl.madl);
                foreach (string mapx in dsmapx)
                {
                    if (!ctpxBUS.Xoatheophieuxuat(mapx))
                    {
                        System.Windows.MessageBox.Show("Xóa đại lý thất bại. Có lỗi xóa chi tiết phiếu xuất");
                        return;
                    }
                }
                bool kq5 = pxhBUS.XoatheoDL(dl.madl);
                bool kq2 = pttBUS.XoatheoDL(dl.madl);
                bool kq3 = ctbcdtBUS.XoatheoDL(dl.madl);
                bool kq4 = ctbcnoBUS.XoatheoDL(dl.madl);
                bool kq1 = nttBUS.XoatheoDL(dl.madl);

                if (dl != null)
                {

                    bool kq6 = hsBUS.Xoa(dl);
                    if (kq1 == false || kq2 == false || kq3 == false || kq4 == false || kq5 == false || kq6 == false)
                        System.Windows.MessageBox.Show("Xóa đại lý thất bại. Vui lòng kiểm tra lại dũ liệu");
                    else
                    {
                        System.Windows.MessageBox.Show("Xóa đại lý thành công");
                        this.loadData_Vao_GridView();
                    }
                    
                }
                this.loadData_Vao_GridView();
            }
        }
    }

}
