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
    /// Interaction logic for ChiTietBaoCaoCongNo.xaml
    /// </summary>
    public partial class ChiTietBaoCaoCongNo : Window
    {
        ChitietphieubcnoBUS ctbcnoBUS;
        PhieubaocaonoBUS bcnoBUS;
        PhieubaocaonoDTO bcnoDTO;
        NoThangtruocBUS nottBUS;
        bool xemornot;
        public ChiTietBaoCaoCongNo()
        {
            InitializeComponent();
        }
        public ChiTietBaoCaoCongNo(PhieubaocaonoDTO dt, bool xem)
        {
            ctbcnoBUS = new ChitietphieubcnoBUS();
            bcnoBUS = new PhieubaocaonoBUS();
            nottBUS = new NoThangtruocBUS();
            bcnoDTO = dt;
            xemornot = xem;
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (bcnoDTO != null)
            {
                Matxt.Text = bcnoDTO.mano;
                thang.Text = bcnoDTO.ngaylap.Month.ToString();
            }
            if (xemornot)
            {
                loadData_Vao_GridViewXem();
                ButtonXacNhan.IsEnabled = false;
            }
            else
            {
                loadData_Vao_GridView();
                ButtonXacNhan.IsEnabled = true;
            }
        }
        private void loadData_Vao_GridView()
        {
            List<ChitietphieubcnoDTO> listctpx = ctbcnoBUS.layno();

            if (listctpx == null)
            {
                MessageBox.Show("Có lỗi khi lấy hồ sơ từ DB");
                return;
            }
            dsDL.ItemsSource = listctpx;
        }
        private void loadData_Vao_GridViewXem()
        {
            List<ChitietphieubcnoDTO> listctpx = ctbcnoBUS.select(Matxt.Text);

            if (listctpx == null)
            {
                MessageBox.Show("Có lỗi khi lấy hồ sơ từ DB");
                return;
            }

            dsDL.ItemsSource = listctpx;
        }
        private void loadData_Vao_GridView(List<ChitietphieubcnoDTO> listctpx)
        {
            if (listctpx == null)
            {
                MessageBox.Show("Có lỗi khi lấy hồ sơ từ DB");
                return;
            }
            dsDL.ItemsSource = listctpx;
        }
        //Search
        private void TxtKeyword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                string sKeyword = txtKeyword.Text.Trim();
                if (sKeyword == null || sKeyword == string.Empty || sKeyword.Length == 0) // tìm tất cả
                {
                    List<ChitietphieubcnoDTO> listctpx = ctbcnoBUS.select(Matxt.Text);
                    this.loadData_Vao_GridView(listctpx);
                }
                else
                {
                    List<ChitietphieubcnoDTO> listctpx = ctbcnoBUS.selectByKeyWord(sKeyword, Matxt.Text);
                    this.loadData_Vao_GridView(listctpx);
                }
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string sKeyword = txtKeyword.Text.Trim();
            if (sKeyword == null || sKeyword == string.Empty || sKeyword.Length == 0) // tìm tất cả
            {
                List<ChitietphieubcnoDTO> listctpx = ctbcnoBUS.select(Matxt.Text);
                this.loadData_Vao_GridView(listctpx);
            }
            else
            {
                List<ChitietphieubcnoDTO> listctpx = ctbcnoBUS.selectByKeyWord(sKeyword, Matxt.Text);
                this.loadData_Vao_GridView(listctpx);
            }
        }
        //Xác nhận
        private void ButtonXacNhan_Click(object sender, RoutedEventArgs e)
        {
            bool check = true;
            foreach (ChitietphieubcnoDTO row in dsDL.ItemsSource)
            {
                row.mano = bcnoDTO.mano;
                check = ctbcnoBUS.Them(row);
            }
            if (check == false)
                MessageBox.Show("Lưu thông tin phiếu thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                MessageBox.Show("Lưu thông tin phiếu thành công, Thông tin nợ kỳ trước đã được cập nhật");
                this.Close();
                foreach (ChitietphieubcnoDTO row in dsDL.ItemsSource)
                {
                    NoThangtruocDTO ntt = new NoThangtruocDTO();
                    ntt.madl = row.madl;
                    ntt.nothangtruoc = row.nocuoi;
                    nottBUS.Sua(ntt);
                }
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
