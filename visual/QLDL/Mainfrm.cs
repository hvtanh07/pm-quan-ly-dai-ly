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
            CapNhatSuaDaiLy frm = new CapNhatSuaDaiLy();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
