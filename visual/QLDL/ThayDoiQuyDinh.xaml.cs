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

    public partial class ThayDoiQuyDinh : UserControl
    {
        public ThayDoiQuyDinh()
        {
            InitializeComponent();
            usc = new ThayDoiQuyDinhForm();
            MainGrid.Children.Add(usc);
        }

        private void ThayDoiQuyDinhButton_Click(object sender, RoutedEventArgs e)
        {
            usc = null;
            usc = new ThayDoiQuyDinhForm();
            MainGrid.Children.Add(usc);
        }

        private void QLDLVDVButton_Click(object sender, RoutedEventArgs e)
        {
            usc = null;
            usc = new QuanLyDaiLyVaDonVi();
            MainGrid.Children.Add(usc);
        }
    }
}
