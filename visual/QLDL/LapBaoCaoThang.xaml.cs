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
    /// Interaction logic for LapBaoCaoThang.xaml
    /// </summary>
    public partial class LapBaoCaoThang : UserControl
    {
        public LapBaoCaoThang()
        {
            InitializeComponent();
            usc = new BaoCaoDoanhSo();
            MainGrid.Children.Add(usc);
        }

        private void BaoCaoDoanhSoButton_Click(object sender, RoutedEventArgs e)
        {
            usc = null;
            usc = new BaoCaoDoanhSo();
            MainGrid.Children.Add(usc);
        }

        private void BaoCaoCongNoDaiLyButton_Click(object sender, RoutedEventArgs e)
        {
            usc = null;
            usc = new BaoCaoCongNoDaiLy();
            MainGrid.Children.Add(usc);
        }
    }
}
