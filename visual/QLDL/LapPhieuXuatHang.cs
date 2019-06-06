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
    public partial class LapPhieuXuatHang : Form
    {
        private ChitietphieuxuatBUS ctpxBUS;
        private CHoSoDaiLyBUS hsBUS;
        private PhieuxuathangBUS pxhBUS;
        public LapPhieuXuatHang()
        {
            InitializeComponent();
        }
        private void loadData_Vao_GridView()
        {
            List<PhieuxuathangDTO> listpx = pxhBUS.select();

            if (listpx == null)
            {
                MessageBox.Show("Có lỗi khi lấy hồ sơ từ DB");
                return;
            }

            dsphieuxh.Columns.Clear();
            dsphieuxh.DataSource = null;

            dsphieuxh.AutoGenerateColumns = false;
            dsphieuxh.AllowUserToAddRows = false;
            dsphieuxh.DataSource = listpx;

            DataGridViewTextBoxColumn clMaxh = new DataGridViewTextBoxColumn();
            clMaxh.Name = "maxh";
            clMaxh.HeaderText = "Mã phiếu xuất hàng";
            clMaxh.DataPropertyName = "maxh";
            dsphieuxh.Columns.Add(clMaxh);

            DataGridViewTextBoxColumn clMamh = new DataGridViewTextBoxColumn();
            clMamh.Name = "madl";
            clMamh.HeaderText = "Mã đại lý";
            clMamh.DataPropertyName = "madl";
            dsphieuxh.Columns.Add(clMamh);

            DataGridViewTextBoxColumn clTen = new DataGridViewTextBoxColumn();
            clTen.Name = "ngaylap";
            clTen.HeaderText = "Ngày lập phiếu";
            clTen.DataPropertyName = "ngaylap";
            dsphieuxh.Columns.Add(clTen);

            DataGridViewTextBoxColumn clhsd = new DataGridViewTextBoxColumn();
            clhsd.Name = "tongtien";
            clhsd.HeaderText = "Tổng trị giá phiếu";
            clhsd.DataPropertyName = "tongtien";
            dsphieuxh.Columns.Add(clhsd);

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dsphieuxh.DataSource];
            myCurrencyManager.Refresh();
            autosize();
        }
        private void loadData_Vao_GridView(List<PhieuxuathangDTO> listpx)
        {
            if (listpx == null)
            {
                MessageBox.Show("Có lỗi khi lấy hồ sơ từ DB");
                return;
            }

            dsphieuxh.Columns.Clear();
            dsphieuxh.DataSource = null;

            dsphieuxh.AutoGenerateColumns = false;
            dsphieuxh.AllowUserToAddRows = false;
            dsphieuxh.DataSource = listpx;

            DataGridViewTextBoxColumn clMaxh = new DataGridViewTextBoxColumn();
            clMaxh.Name = "maxh";
            clMaxh.HeaderText = "Mã phiếu xuất hàng";
            clMaxh.DataPropertyName = "maxh";
            dsphieuxh.Columns.Add(clMaxh);

            DataGridViewTextBoxColumn clMamh = new DataGridViewTextBoxColumn();
            clMamh.Name = "madl";
            clMamh.HeaderText = "Mã đại lý";
            clMamh.DataPropertyName = "madl";
            dsphieuxh.Columns.Add(clMamh);

            DataGridViewTextBoxColumn clTen = new DataGridViewTextBoxColumn();
            clTen.Name = "ngaylap";
            clTen.HeaderText = "Ngày lập phiếu";
            clTen.DataPropertyName = "ngaylap";
            dsphieuxh.Columns.Add(clTen);

            DataGridViewTextBoxColumn clhsd = new DataGridViewTextBoxColumn();
            clhsd.Name = "tongtien";
            clhsd.HeaderText = "Tổng trị giá phiếu";
            clhsd.DataPropertyName = "tongtien";
            dsphieuxh.Columns.Add(clhsd);

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dsphieuxh.DataSource];
            myCurrencyManager.Refresh();
            autosize();
        }
        private void autosize()
        {
            for (int i = 0; i < dsphieuxh.Columns.Count; i++)
            {
                dsphieuxh.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }
        bool testtext()//kiểm tra ô dữ liệu trống
        {
            if (string.IsNullOrWhiteSpace(maPhieu.Text))
            {
                MessageBox.Show(maPhieu, "Bạn chưa nhập mã phiếu xuất.");
                maPhieu.Focus();
                return false;
            }
            return true;
        }
        private void LapPhieuXuatHang_Load(object sender, EventArgs e)
        {
            ctpxBUS = new ChitietphieuxuatBUS();
            hsBUS = new CHoSoDaiLyBUS();
            pxhBUS = new PhieuxuathangBUS();
            loadData_Vao_GridView();
            Taodatasource();
            thang.Text = DateTime.Now.ToString("MM");
        }
        private void Taodatasource()
        {
            List<string> madl = new List<string>();
            madl = hsBUS.Laymadl();
            madltxt.DataSource = madl;
        }
        //them
        private void Button4_Click(object sender, EventArgs e)
        {
            if (!testtext())
            {
                return;
            }
            PhieuxuathangDTO xh = new PhieuxuathangDTO();
            xh.maxh = maPhieu.Text;
            xh.madl = madltxt.Text;
            xh.ngaylap = DateTime.Today;
            xh.tongtien = 0;
            bool kq = pxhBUS.Them(xh);
            if (kq == false)
                MessageBox.Show("Thêm hồ sơ thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                MessageBox.Show("Thêm hồ sơ thành công");
                maPhieu.Text = "";
                madltxt.Text = "";
            }
            PhieuXuatHang frm = new PhieuXuatHang(xh);
            frm.ShowDialog();
        }
        //search
        private void Button1_Click(object sender, EventArgs e)
        {
            string sKeyword = txtKeyword.Text.Trim();
            if (sKeyword == null || sKeyword == string.Empty || sKeyword.Length == 0) // tìm tất cả
            {
                List<PhieuxuathangDTO> listctpx = pxhBUS.select();
                this.loadData_Vao_GridView(listctpx);
            }
            else
            {
                List<PhieuxuathangDTO> listctpx = pxhBUS.selectByKeyWord(sKeyword);
                this.loadData_Vao_GridView(listctpx);
            }
        }
        private void Dsphieuxh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            maPhieu.Text = dsphieuxh.CurrentRow.Cells[0].Value.ToString();
            madltxt.Text = dsphieuxh.CurrentRow.Cells[1].Value.ToString();
            thang.Text = Convert.ToDateTime(dsphieuxh.CurrentRow.Cells[2].Value.ToString()).Month.ToString();
        }
        //xóa
        private void XóaBảnGhiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn xóa đại lý này không ?", "Xóa thông tin", MessageBoxButtons.YesNo);
            if (dlr == DialogResult.Yes)
            {
                // ' Get the current cell location.
                int currentRowIndex = dsphieuxh.CurrentCellAddress.Y;// 'current row selected                
                //'Verify that indexing OK
                if (-1 < currentRowIndex && currentRowIndex < dsphieuxh.RowCount)
                {
                    PhieuxuathangDTO px = (PhieuxuathangDTO)dsphieuxh.Rows[currentRowIndex].DataBoundItem;                   
                    if (px != null)
                    {
                        bool kq1 = ctpxBUS.Xoatheophieuxuat(px.maxh);
                        if (kq1 == false)
                            MessageBox.Show("Xóa chi tiết phiếu thất bại. Vui lòng kiểm tra lại dũ liệu");
                        else
                        {
                            bool kq2 = pxhBUS.Xoa(px);
                            if (kq2 == false)
                                MessageBox.Show("Xóa phiếu thất bại. Vui lòng kiểm tra lại dũ liệu");
                            else
                            {
                                MessageBox.Show("Xóa phiếu thành công");
                                this.loadData_Vao_GridView();
                            }
                        }                       
                    }
                }
                this.loadData_Vao_GridView();
            }
        }
        //sửa
        private void SửaBảnGhiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ' Get the current cell location.
            int currentRowIndex = dsphieuxh.CurrentCellAddress.Y;// 'current row selected


            //'Verify that indexing OK
            if (-1 < currentRowIndex && currentRowIndex < dsphieuxh.RowCount)
            {
                PhieuxuathangDTO xh = (PhieuxuathangDTO)dsphieuxh.Rows[currentRowIndex].DataBoundItem;
                if (xh != null)
                {
                    PhieuXuatHang frm = new PhieuXuatHang(xh);
                    frm.ShowDialog();
                }
            }
            this.loadData_Vao_GridView();
        }
    }
}
