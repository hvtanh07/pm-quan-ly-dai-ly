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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QLDL
{
    /// <summary>
    /// Interaction logic for BaoCaoDoanhThu.xaml
    /// </summary>
    public partial class BaoCaoDoanhSo : UserControl
    {
        PhieubaocaodtBUS bcdtBUS;
        ChitietphieubcdtBUS ctbcdsBUS;
        public BaoCaoDoanhSo()
        {
            InitializeComponent();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ctbcdsBUS = new ChitietphieubcdtBUS();
            bcdtBUS = new PhieubaocaodtBUS();
            loadData_Vao_GridView();
        }
        private void loadData_Vao_GridView()
        {
            List<PhieubaocaodtDTO> listbcdt = bcdtBUS.select();

            if (listbcdt == null)
            {
                MessageBox.Show("Có lỗi khi lấy hồ sơ từ DB");
                return;
            }
            dsphieu.ItemsSource = listbcdt;
        }
        private void loadData_Vao_GridView(List<PhieubaocaodtDTO> listpbcdt)
        {
            if (listpbcdt == null)
            {
                MessageBox.Show("Có lỗi khi lấy hồ sơ từ DB");
                return;
            }
            dsphieu.ItemsSource = listpbcdt;
        }
        //Xóa
        private void XóaPhiếu_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult dlr = MessageBox.Show("Bạn có chắc muốn xóa phiếu doanh thu này không ?", "Xóa thông tin", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (dlr == MessageBoxResult.Yes)
            {

                PhieubaocaodtDTO dt = (PhieubaocaodtDTO)dsphieu.SelectedItem;
                if (dt != null)
                {
                    bool kq1 = ctbcdsBUS.Xoatheophieuxuat(dt.madt);
                    if (kq1 == false)
                        MessageBox.Show("Xóa chi tiết phiếu thất bại. Vui lòng kiểm tra lại dũ liệu");
                    else
                    {
                        bool kq2 = bcdtBUS.Xoa(dt);
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
        //Xem thông tin
        private void XemThôngTin_Click(object sender, RoutedEventArgs e)
        {

            PhieubaocaodtDTO dt = (PhieubaocaodtDTO)dsphieu.SelectedItem;
            if (dt != null)
            {
                ChiTietBaoCaoDoanhSo frm = new ChiTietBaoCaoDoanhSo(dt, true);
                frm.ShowDialog();
            }

            this.loadData_Vao_GridView();
        }
        //Search
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string sKeyword = txtKeyword.Text.Trim();
            if (sKeyword == null || sKeyword == string.Empty || sKeyword.Length == 0) // tìm tất cả
            {
                List<PhieubaocaodtDTO> listpbcdt = bcdtBUS.select();
                this.loadData_Vao_GridView(listpbcdt);
            }
            else
            {
                List<PhieubaocaodtDTO> listpbcdt = bcdtBUS.selectByKeyWord(sKeyword);
                this.loadData_Vao_GridView(listpbcdt);
            }
        }

        private void TxtKeyword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                string sKeyword = txtKeyword.Text.Trim();
                if (sKeyword == null || sKeyword == string.Empty || sKeyword.Length == 0) // tìm tất cả
                {
                    List<PhieubaocaodtDTO> listpbcdt = bcdtBUS.select();
                    this.loadData_Vao_GridView(listpbcdt);
                }
                else
                {
                    List<PhieubaocaodtDTO> listpbcdt = bcdtBUS.selectByKeyWord(sKeyword);
                    this.loadData_Vao_GridView(listpbcdt);
                }
            }
        }
        //Lập phiếu
        private void LapPhieuButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Matxt.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã phiếu");
                Matxt.Focus();
                return;
            }
            PhieubaocaodtDTO dt = new PhieubaocaodtDTO();
            dt.madt = Matxt.Text;
            dt.ngaylap = DateTime.Today;
            dt.tongdt = 0;
            if (bcdtBUS.Check(DateTime.Today.Month, DateTime.Today.Year))
            {
                MessageBox.Show("Thêm hồ sơ thất bại. Tháng này đã có phiếu báo cáo doanh thu");
                return;
            }
            bool kq = bcdtBUS.Them(dt);
            if (kq == false)
                MessageBox.Show("Thêm hồ sơ thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                MessageBox.Show("Thêm hồ sơ thành công");
                Matxt.Text = "";
            }
            if (dt != null)
            {
                ChiTietBaoCaoDoanhSo frm = new ChiTietBaoCaoDoanhSo(dt, false);
                frm.ShowDialog();
            }
            loadData_Vao_GridView();
        }

        private void dsphieu_CellClick(object sender, SelectionChangedEventArgs e)
        {
            PhieubaocaodtDTO dt = (PhieubaocaodtDTO)dsphieu.SelectedItem;
            if (dt!= null)
            {
                Matxt.Text = dt.madt;
            }
        }
    }
}
