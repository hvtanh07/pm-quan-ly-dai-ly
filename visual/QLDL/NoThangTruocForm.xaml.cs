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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QLDL
{
    /// <summary>
    /// Interaction logic for NoThangTruocForm.xaml
    /// </summary>
    public partial class NoThangTruocForm : Window
    {
        NoThangtruocBUS nttBUS;
        CHoSoDaiLyBUS hsdlBUS;
        public NoThangTruocForm()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Taodatasource()
        {
            List<string> madl = new List<string>();
            madl = hsdlBUS.Laymadl();
            madltxt.ItemsSource = madl;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NoThangtruocDTO ntt = new NoThangtruocDTO();
            ntt.madl = madltxt.Text;
            ntt.nothangtruoc = int.Parse(notxt.Text);
            bool kq = nttBUS.Sua(ntt);
            if (kq == false)
                MessageBox.Show("Cập nhật thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                MessageBox.Show("Cập nhật thành công");
            }
        }

        private void Madltxt_TextUpdate(object sender, EventArgs e)
        {
            notxt.Text = nttBUS.Laytientheoma(madltxt.Text).ToString();
        }

        private void ComboBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            notxt.Text = nttBUS.Laytientheoma(madltxt.Text).ToString();
        }

        private void NoThangTruoc_Load(object sender, RoutedEventArgs e)
        {
            nttBUS = new NoThangtruocBUS();
            hsdlBUS = new CHoSoDaiLyBUS();
            Taodatasource();
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

        private void Madltxt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
