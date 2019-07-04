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
    /// Interaction logic for BaoCaoCongNoDaiLy.xaml
    /// </summary>
    public partial class BaoCaoCongNoDaiLy : UserControl
    {
        PhieubaocaonoBUS bcnoBUS;
        ChitietphieubcnoBUS ctbcnoBUS;
        public BaoCaoCongNoDaiLy()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ctbcnoBUS = new ChitietphieubcnoBUS();
            bcnoBUS = new PhieubaocaonoBUS();
            loadData_Vao_GridView();
        }
        private void loadData_Vao_GridView()
        {
            List<PhieubaocaonoDTO> listpbcno = bcnoBUS.select();

            if (listpbcno == null)
            {
                MessageBox.Show("Có lỗi khi lấy hồ sơ từ DB");
                return;
            }
            dsphieu.ItemsSource = listpbcno;
        }
        private void loadData_Vao_GridView(List<PhieubaocaonoDTO> listpbcno)
        {
            if (listpbcno == null)
            {
                MessageBox.Show("Có lỗi khi lấy hồ sơ từ DB");
                return;
            }
            dsphieu.ItemsSource = listpbcno;
        }
        //Search
        private void TxtKeyword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                string sKeyword = txtKeyword.Text.Trim();
                if (sKeyword == null || sKeyword == string.Empty || sKeyword.Length == 0) // tìm tất cả
                {
                    List<PhieubaocaonoDTO> listpbcdt = bcnoBUS.select();
                    this.loadData_Vao_GridView(listpbcdt);
                }
                else
                {
                    List<PhieubaocaonoDTO> listpbcdt = bcnoBUS.selectByKeyWord(sKeyword);
                    this.loadData_Vao_GridView(listpbcdt);
                }
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string sKeyword = txtKeyword.Text.Trim();
            if (sKeyword == null || sKeyword == string.Empty || sKeyword.Length == 0) // tìm tất cả
            {
                List<PhieubaocaonoDTO> listpbcdt = bcnoBUS.select();
                this.loadData_Vao_GridView(listpbcdt);
            }
            else
            {
                List<PhieubaocaonoDTO> listpbcdt = bcnoBUS.selectByKeyWord(sKeyword);
                this.loadData_Vao_GridView(listpbcdt);
            }
        }
        //Xem thông tin
        private void XemThôngTin_Click(object sender, RoutedEventArgs e)
        {

            PhieubaocaonoDTO no = (PhieubaocaonoDTO)dsphieu.SelectedItem;
            if (no != null)
            {
                ChiTietBaoCaoCongNo frm = new ChiTietBaoCaoCongNo(no, true);
                frm.ShowDialog();
            }
            this.loadData_Vao_GridView();
        }
        //Xóa
        private void XóaPhiếu_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult dlr = MessageBox.Show("Bạn có chắc muốn xóa phiếu công nợ này không ?, Thông tin nợ tháng trước sẽ không thay đổi", "Xóa thông tin", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (dlr == MessageBoxResult.Yes)
            {

                PhieubaocaonoDTO no = (PhieubaocaonoDTO)dsphieu.SelectedItem;
                if (no != null)
                {
                    bool kq1 = ctbcnoBUS.Xoatheophieuno(no.mano);
                    if (kq1 == false)
                        MessageBox.Show("Xóa chi tiết phiếu thất bại. Vui lòng kiểm tra lại dũ liệu");
                    else
                    {
                        bool kq2 = bcnoBUS.Xoa(no);
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
        private void dsphieu_CellClick(object sender, SelectionChangedEventArgs e)
        {
            PhieubaocaonoDTO no = (PhieubaocaonoDTO)dsphieu.SelectedItem;
            if (no != null)
            {
                Matxt.Text = no.mano;
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
            PhieubaocaonoDTO no = new PhieubaocaonoDTO();
            no.mano = Matxt.Text;
            no.ngaylap = DateTime.Today;
            if (bcnoBUS.Check(DateTime.Today.Month, DateTime.Today.Year))
            {
                MessageBox.Show("Thêm hồ sơ thất bại. Tháng này đã có phiếu báo cáo công nợ");
                return;
            }
            bool kq = bcnoBUS.Them(no);
            if (kq == false)
                MessageBox.Show("Thêm hồ sơ thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                MessageBox.Show("Thêm hồ sơ thành công");
                Matxt.Text = "";
            }
            if (no != null)
            {
                ChiTietBaoCaoCongNo frm = new ChiTietBaoCaoCongNo(no, false);
                frm.ShowDialog();
            }
            loadData_Vao_GridView();
        }
    }
}
