using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using QLDL_BUS;
using QLDL_DTO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDL
{
    public partial class QuiDinhfrm : Form
    {
        public QuiDinhfrm()
        {
            InitializeComponent();
        }
        private CQuyDinhBUS qdbus;
        private void QuiDinhfrm_Load(object sender, EventArgs e)
        {
            qdbus = new CQuyDinhBUS();
            LayduLieu();
        }
        private void LayduLieu()
        {
            QuiDinhDTO qd = qdbus.Laydulieu();
            maxloaidl.Text = qd.Maxloaidl.ToString();
            soluongmh.Text = qd.soluongMH.ToString();
            soluongdvt.Text = qd.soluongDVT.ToString();
            maxsodl.Text = qd.Maxsodl.ToString();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            QuiDinhDTO qd = new QuiDinhDTO();
            qd.Maxloaidl = int.Parse(maxloaidl.Text);
            qd.soluongMH = int.Parse(soluongmh.Text);
            qd.soluongDVT = int.Parse(soluongdvt.Text);
            qd.Maxsodl = int.Parse(maxsodl.Text);
            //2. Kiểm tra data hợp lệ or not

            //3. Thêm vào DB
            bool kq = qdbus.Sua(qd);
            if (kq == false)
                MessageBox.Show("Sửa qui định thất bại. Vui lòng kiểm tra lại dữ liệu");
            else
                MessageBox.Show("Sửa qui định thành công");
        }
    }
}
