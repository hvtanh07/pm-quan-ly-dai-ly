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
    public partial class Mainfrm : Form
    {
        public Mainfrm()
        {
            InitializeComponent();
        }

        private void TiếpNhậnĐạiLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TiepNhanDaiLyfrm frm = new TiepNhanDaiLyfrm();
            frm.MdiParent = this;
            frm.Show();
        }

        private void SửaThôngTinĐạiLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SuaDaiLy frm = new SuaDaiLy();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ThêmXóaMặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanlyMatHangfrm frm = new QuanlyMatHangfrm();
            frm.MdiParent = this;
            frm.Show();
        }

        private void QuảnLýĐạiLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanlyDaily frm = new QuanlyDaily();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ThayĐổiSốLượngCácĐạiLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyLoaiDaily frm = new QuanLyLoaiDaily();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ThayĐổiSốĐạiLýTốiĐaTrongQuậnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuiDinhfrm frm = new QuiDinhfrm();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
