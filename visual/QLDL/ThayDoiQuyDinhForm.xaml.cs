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
    /// Interaction logic for ThayDoiQuyDinhForm.xaml
    /// </summary>
    public partial class ThayDoiQuyDinhForm : System.Windows.Controls.UserControl
    {
        CMatHangBUS mhBUS;
        CLoaiDaiLyBUS ldlBUS;
        DanhsachDonviBUS dvBUS;
        private CQuyDinhBUS qdbus;
        public ThayDoiQuyDinhForm()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            mhBUS = new CMatHangBUS();
            ldlBUS = new CLoaiDaiLyBUS();
            dvBUS = new DanhsachDonviBUS();
            qdbus = new CQuyDinhBUS();
            LayduLieu();
        }
        private void LayduLieu()
        {
            try
            {
                QuiDinhDTO qd = qdbus.Laydulieu();
                maxloaidl.Text = qd.Maxloaidl.ToString();
                soluongmh.Text = qd.soluongMH.ToString();
                soluongdvt.Text = qd.soluongDVT.ToString();
                maxsodl.Text = qd.Maxsodl.ToString();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Lấy dữ liệu qui định thất bại");
                return;
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
        private void capnhat()
        {
            QuiDinhDTO qd = new QuiDinhDTO();
            if (ldlBUS.Laysoloaidl() > int.Parse(maxloaidl.Text))            
                System.Windows.MessageBox.Show("Số loại đại lý hiện đang lớn hơn " + int.Parse(maxloaidl.Text) + " .Nên xóa 1 loại đại lý trước khi tiếp tục.");                    
            qd.Maxloaidl = int.Parse(maxloaidl.Text);


            if (mhBUS.Laysomathang() > int.Parse(soluongmh.Text))
                System.Windows.MessageBox.Show("Số mặt hàng hiện đang lớn hơn " + int.Parse(soluongmh.Text) + " .Nên xóa 1 mặt hàng trước khi tiếp tục.");
            qd.soluongMH = int.Parse(soluongmh.Text);    
            

            if (dvBUS.Laysodonvi()> int.Parse(soluongdvt.Text))
                System.Windows.MessageBox.Show("Số đơn vị hiện đang lớn hơn " + int.Parse(soluongdvt.Text) + " .Nên xóa 1 đơn vị trước khi tiếp tục.");
            qd.soluongDVT = int.Parse(maxloaidl.Text);
            qd.Maxsodl = int.Parse(maxsodl.Text);
            //3. Thêm vào DB
            bool kq = qdbus.Sua(qd);
            if (kq == false)
                System.Windows.MessageBox.Show("Sửa qui định thất bại. Vui lòng kiểm tra lại dữ liệu");
            else
                System.Windows.MessageBox.Show("Sửa qui định thành công");
        }
        //------------------LOAI DAI LY-------------------------

        private void TangLDL_Click(object sender, RoutedEventArgs e)
        {
            maxloaidl.Text = (int.Parse(maxloaidl.Text) + 1).ToString();
            capnhat();
            // QuanLyDaiLyVaDonVi frm = new QuanLyDaiLyVaDonVi();
            //frm.ShowDialog();
        }

        private void GiamLDL_Click(object sender, RoutedEventArgs e)
        {
            maxloaidl.Text = (int.Parse(maxloaidl.Text) - 1).ToString();
            capnhat();
            //dung ham dem so dai ly neu vuot qua max thi show form            
            int soldl = ldlBUS.Laysoloaidl();
        }
        //------------------MAT HANG-------------------------
        private void TangMH_Click(object sender, RoutedEventArgs e)
        {
            soluongmh.Text = (int.Parse(soluongmh.Text) + 1).ToString();
            capnhat();
        }

        private void GiamMH_Click(object sender, RoutedEventArgs e)
        {
            soluongmh.Text = (int.Parse(soluongmh.Text) - 1).ToString();
            capnhat();
        }
        //------------------DON VI TINH-------------------------
        private void TangDVT_Click(object sender, RoutedEventArgs e)
        {
            soluongdvt.Text = (int.Parse(soluongdvt.Text) + 1).ToString();
            capnhat();
        }

        private void GiamDVT_Click(object sender, RoutedEventArgs e)
        {
            soluongdvt.Text = (int.Parse(soluongdvt.Text) - 1).ToString();
            capnhat();
        }
        //------------------SO DAI LY-------------------------
        private void TangDL_Click(object sender, RoutedEventArgs e)
        {
            maxsodl.Text = (int.Parse(maxsodl.Text) + 1).ToString();
            capnhat();
        }

        private void GiamDL_Click(object sender, RoutedEventArgs e)
        {
            maxsodl.Text = (int.Parse(maxsodl.Text) - 1).ToString();
            capnhat();
        }
    }
}
