using QLDL_BUS;
using QLDL_DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDL
{
    public partial class NoThangTruoc : Form
    {
        NoThangtruocBUS nttBUS;
        CHoSoDaiLyBUS hsdlBUS;
        public NoThangTruoc()
        {
            InitializeComponent();
        }
        private void Taodatasource()
        {
            List<string> madl = new List<string>();
            madl = hsdlBUS.Laymadl();
            madltxt.DataSource = madl;
        }
        private void Button1_Click(object sender, EventArgs e)
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

        private void NoThangTruoc_Load(object sender, EventArgs e)
        {
            nttBUS = new NoThangtruocBUS();
            hsdlBUS = new CHoSoDaiLyBUS();
            Taodatasource();
        }

        private void Madltxt_TextChanged(object sender, EventArgs e)
        {
            notxt.Text = nttBUS.Laytientheoma(madltxt.Text).ToString();
        }

        private void Madltxt_TextUpdate(object sender, EventArgs e)
        {
            notxt.Text = nttBUS.Laytientheoma(madltxt.Text).ToString();
        }
    }
}
