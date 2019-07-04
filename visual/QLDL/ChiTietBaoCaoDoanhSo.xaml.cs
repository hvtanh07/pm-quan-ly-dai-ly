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
    /// Interaction logic for ChiTietBaoCaoDoanhSo.xaml
    /// </summary>
    public partial class ChiTietBaoCaoDoanhSo : Window
    {
        ChitietphieubcdtBUS ctbcdtBUS;
        PhieubaocaodtBUS bcdtBUS;
        PhieubaocaodtDTO bcdtDTO;
        bool xemornot;
        int tongtien;
        public ChiTietBaoCaoDoanhSo()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (bcdtDTO != null)
            {
                Matxt.Text = bcdtDTO.madt;
                thang.Text = bcdtDTO.ngaylap.Month.ToString();
            }
            if (xemornot)
            {
                tongtientxt.Text = bcdtDTO.tongdt.ToString();
                loadData_Vao_GridViewXem();
                ButtonXacNhan.IsEnabled = false;
            }
            else
            {
                loadData_Vao_GridView();
                capnhattien();
                laptyle();
                ButtonXacNhan.IsEnabled = true;
            }
        }
        public ChiTietBaoCaoDoanhSo(PhieubaocaodtDTO dt, bool xem)
        {
            ctbcdtBUS = new ChitietphieubcdtBUS();
            bcdtBUS = new PhieubaocaodtBUS();
            bcdtDTO = dt;
            xemornot = xem;
            InitializeComponent();
        }
        private void loadData_Vao_GridView()
        {
            List<ChitietphieubcdtDTO> listctpx = ctbcdtBUS.laydoanhthu(bcdtDTO.ngaylap.Month, bcdtDTO.ngaylap.Year);

            if (listctpx == null)
            {
                MessageBox.Show("Có lỗi khi lấy hồ sơ từ DB");
                return;
            }
            dsDL.ItemsSource = listctpx;
        }
        private void laptyle()
        {
            foreach (ChitietphieubcdtDTO row in dsDL.ItemsSource)
            {
                float i = (float)row.tongdt;
                float j = (float)tongtien;
                row.tyle = i/j * 100;
            }
        }
        private void loadData_Vao_GridViewXem()
        {
            List<ChitietphieubcdtDTO> listctpx = ctbcdtBUS.select(Matxt.Text);

            if (listctpx == null)
            {
                MessageBox.Show("Có lỗi khi lấy hồ sơ từ DB");
                return;
            }
            dsDL.ItemsSource = listctpx;
        }
        private void loadData_Vao_GridView(List<ChitietphieubcdtDTO> listctpx)
        {
            if (listctpx == null)
            {
                MessageBox.Show("Có lỗi khi lấy hồ sơ từ DB");
                return;
            }
            dsDL.ItemsSource = listctpx;
        }
        private void capnhattien()
        {
            tongtien = 0;
            foreach (ChitietphieubcdtDTO row in dsDL.ItemsSource)
            {
                tongtien += row.tongdt;
            }
            tongtientxt.Text = tongtien.ToString();
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        //Search
        private void TxtKeyword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                string sKeyword = txtKeyword.Text.Trim();
                if (sKeyword == null || sKeyword == string.Empty || sKeyword.Length == 0) // tìm tất cả
                {
                    List<ChitietphieubcdtDTO> listctpx = ctbcdtBUS.select(Matxt.Text);
                    this.loadData_Vao_GridView(listctpx);
                }
                else
                {
                    List<ChitietphieubcdtDTO> listctpx = ctbcdtBUS.selectByKeyWord(sKeyword, Matxt.Text);
                    this.loadData_Vao_GridView(listctpx);
                }
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string sKeyword = txtKeyword.Text.Trim();
            if (sKeyword == null || sKeyword == string.Empty || sKeyword.Length == 0) // tìm tất cả
            {
                List<ChitietphieubcdtDTO> listctpx = ctbcdtBUS.select(Matxt.Text);
                this.loadData_Vao_GridView(listctpx);
            }
            else
            {
                List<ChitietphieubcdtDTO> listctpx = ctbcdtBUS.selectByKeyWord(sKeyword, Matxt.Text);
                this.loadData_Vao_GridView(listctpx);
            }
        }


        //Xác nhận
        private void ButtonXacNhan_Click(object sender, RoutedEventArgs e)
        {
            bool check = true;
            foreach (ChitietphieubcdtDTO row in dsDL.ItemsSource)
            {
                row.madt = bcdtDTO.madt;
                check = ctbcdtBUS.Them(row);
            }
            if (check == false)
                MessageBox.Show("Lưu thông tin phiếu thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                PhieubaocaodtDTO bcds = new PhieubaocaodtDTO();
                bcds.madt = bcdtDTO.madt;
                bcds.tongdt = tongtien;
                bool kq = bcdtBUS.Sua(bcds);
                if (kq == false)
                    MessageBox.Show("Lưu thông tin phiếu thất bại. Vui lòng kiểm tra lại dũ liệu");
                else
                {
                    MessageBox.Show("Lưu thông tin phiếu thành công");
                    this.Close();
                }
            }
        }
       

    }
}
