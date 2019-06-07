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
            QuanLyLoaiDailyDonvi frm = new QuanLyLoaiDailyDonvi();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ThayĐổiSốĐạiLýTốiĐaTrongQuậnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuiDinhfrm frm = new QuiDinhfrm();
            frm.MdiParent = this;
            frm.Show();
        }
      
        private void LậpPhiếuThuTiềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PhieuThuTien frm = new PhieuThuTien();
            frm.MdiParent = this;
            frm.Show();
        }

        private void LậpPhiếuXuấtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LapPhieuXuatHang frm = new LapPhieuXuatHang();
            frm.MdiParent = this;
            frm.Show();
        }

        private void BáoCáoDoanhSốToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PhieuBaocaoDT frm = new PhieuBaocaoDT();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
