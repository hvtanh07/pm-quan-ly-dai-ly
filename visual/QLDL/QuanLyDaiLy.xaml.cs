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

    public partial class QuanLyDaiLy : System.Windows.Controls.UserControl
    {
        public QuanLyDaiLy()
        {
            InitializeComponent();
            
        }
        Window win;
        private void QuanLyDaiLy_Loaded(object sender, RoutedEventArgs e)
        {
            usc = new QuanLyDaiLyForm();
            GridQLDL.Children.Add(usc);
        }
        private void QuanLyDaiLyButton_Click(object sender, RoutedEventArgs e)
        {
            usc = new QuanLyDaiLyForm();
            GridQLDL.Children.Add(usc);
        }

        private void TiepNhanDaiLyButton_Click(object sender, RoutedEventArgs e)
        {
            win = new TiepNhanDaiLyForm();
            win.ShowDialog();
        }

        private void LapPhieuThuTienButton_Click(object sender, RoutedEventArgs e)
        {
            win = new LapPhieuThuTienForm();
            win.ShowDialog();
        }

        private void QuanLyNoThangTruocButton_Click(object sender, RoutedEventArgs e)
        {
            win = new NoThangTruocForm();
            win.ShowDialog();
        }
    }

   }
   