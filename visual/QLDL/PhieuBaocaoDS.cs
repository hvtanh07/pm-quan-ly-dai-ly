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
    public partial class PhieuBaocaoDS : Form
    {
        PhieubaocaodtBUS bcdtBUS;
        ChitietphieubcdtBUS ctbcdsBUS;
        public PhieuBaocaoDS()
        {
            InitializeComponent();
        }
        private void PhieuBaocaoDS_Load(object sender, EventArgs e)
        {
            ctbcdsBUS = new ChitietphieubcdtBUS();
            bcdtBUS = new PhieubaocaodtBUS();
            loadData_Vao_GridView();
        }
        //search
        private void Button2_Click(object sender, EventArgs e)
        {
            string sKeyword = txtKeyword.Text.Trim();
            if (sKeyword == null || sKeyword == string.Empty || sKeyword.Length == 0) // tìm tất cả
            {
                List<PhieubaocaodtDTO> listpbcdt = bcdtBUS.select();
                this.loadData_Vao_GridView(listpbcdt);
            }
            else
            {
                List<PhieubaocaodtDTO> listpbcdt = bcdtBUS.selectByKeyWord(sKeyword);
                this.loadData_Vao_GridView(listpbcdt);
            }
        }
        //lap phieu
        private void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Matxt.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã phiếu");
                Matxt.Focus();
                return;
            }
            PhieubaocaodtDTO dt = new PhieubaocaodtDTO();
            dt.madt = Matxt.Text;
            dt.ngaylap = DateTime.Today;
            dt.tongdt = 0;
            bool kq = bcdtBUS.Them(dt);
            if (kq == false)
                MessageBox.Show("Thêm hồ sơ thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                MessageBox.Show("Thêm hồ sơ thành công");
                Matxt.Text = "";
            }
            if (dt != null)
            {
                ChitietPhieubaocaodoanhso frm = new ChitietPhieubaocaodoanhso(dt, false);
                frm.ShowDialog();
            }
            loadData_Vao_GridView();
        }
        private void loadData_Vao_GridView()
        {
            List<PhieubaocaodtDTO> listbcdt = bcdtBUS.select();

            if (listbcdt == null)
            {
                MessageBox.Show("Có lỗi khi lấy hồ sơ từ DB");
                return;
            }

            dsphieu.Columns.Clear();
            dsphieu.DataSource = null;

            dsphieu.AutoGenerateColumns = false;
            dsphieu.AllowUserToAddRows = false;
            dsphieu.DataSource = listbcdt;

            DataGridViewTextBoxColumn clMaxh = new DataGridViewTextBoxColumn();
            clMaxh.Name = "MaDT";
            clMaxh.HeaderText = "Mã phiếu báo cáo doanh số";
            clMaxh.DataPropertyName = "MaDT";
            dsphieu.Columns.Add(clMaxh);

            DataGridViewTextBoxColumn clTen = new DataGridViewTextBoxColumn();
            clTen.Name = "ngaylap";
            clTen.HeaderText = "Ngày lập phiếu";
            clTen.DataPropertyName = "ngaylap";
            dsphieu.Columns.Add(clTen);

            DataGridViewTextBoxColumn clMamh = new DataGridViewTextBoxColumn();
            clMamh.Name = "TongDT";
            clMamh.HeaderText = "Tổng doanh số";
            clMamh.DataPropertyName = "TongDT";
            dsphieu.Columns.Add(clMamh);

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dsphieu.DataSource];
            myCurrencyManager.Refresh();
            autosize();
        }
        private void loadData_Vao_GridView(List<PhieubaocaodtDTO> listpbcdt)
        {
            if (listpbcdt == null)
            {
                MessageBox.Show("Có lỗi khi lấy hồ sơ từ DB");
                return;
            }

            dsphieu.Columns.Clear();
            dsphieu.DataSource = null;

            dsphieu.AutoGenerateColumns = false;
            dsphieu.AllowUserToAddRows = false;
            dsphieu.DataSource = listpbcdt;

            DataGridViewTextBoxColumn clMaxh = new DataGridViewTextBoxColumn();
            clMaxh.Name = "MaDT";
            clMaxh.HeaderText = "Mã phiếu báo cáo doanh số";
            clMaxh.DataPropertyName = "MaDT";
            dsphieu.Columns.Add(clMaxh);

            DataGridViewTextBoxColumn clTen = new DataGridViewTextBoxColumn();
            clTen.Name = "ngaylap";
            clTen.HeaderText = "Ngày lập phiếu";
            clTen.DataPropertyName = "ngaylap";
            dsphieu.Columns.Add(clTen);

            DataGridViewTextBoxColumn clMamh = new DataGridViewTextBoxColumn();
            clMamh.Name = "TongDT";
            clMamh.HeaderText = "Tổng doanh số";
            clMamh.DataPropertyName = "TongDT";
            dsphieu.Columns.Add(clMamh);

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dsphieu.DataSource];
            myCurrencyManager.Refresh();
            autosize();
        }
        private void autosize()
        {
            for (int i = 0; i < dsphieu.Columns.Count; i++)
            {
                dsphieu.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }
        //xem thong tin
        private void XemThôngTinPhiếuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ' Get the current cell location.
            int currentRowIndex = dsphieu.CurrentCellAddress.Y;// 'current row selected
            //'Verify that indexing OK
            if (-1 < currentRowIndex && currentRowIndex < dsphieu.RowCount)
            {
                PhieubaocaodtDTO dt = (PhieubaocaodtDTO)dsphieu.Rows[currentRowIndex].DataBoundItem;
                if (dt != null)
                {
                    ChitietPhieubaocaodoanhso frm = new ChitietPhieubaocaodoanhso(dt,true);
                    frm.ShowDialog();
                }
            }
            this.loadData_Vao_GridView();
        }
        //xoa
        private void XóaPhiếuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn xóa phiếu doanh thu này không ?", "Xóa thông tin", MessageBoxButtons.YesNo);
            if (dlr == DialogResult.Yes)
            {
                // ' Get the current cell location.
                int currentRowIndex = dsphieu.CurrentCellAddress.Y;// 'current row selected                
                //'Verify that indexing OK
                if (-1 < currentRowIndex && currentRowIndex < dsphieu.RowCount)
                {
                    PhieubaocaodtDTO dt = (PhieubaocaodtDTO)dsphieu.Rows[currentRowIndex].DataBoundItem;
                    if (dt != null)
                    {
                        bool kq1 = ctbcdsBUS.Xoatheophieuxuat(dt.madt);
                        if (kq1 == false)
                            MessageBox.Show("Xóa chi tiết phiếu thất bại. Vui lòng kiểm tra lại dũ liệu");
                        else
                        {
                            bool kq2 = bcdtBUS.Xoa(dt);
                            if (kq2 == false)
                                MessageBox.Show("Xóa phiếu thất bại. Vui lòng kiểm tra lại dũ liệu");
                            else
                            {
                                MessageBox.Show("Xóa phiếu thành công");
                            }
                        }
                    }
                }
                this.loadData_Vao_GridView();
            }
        }

        private void Dsphieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Matxt.Text = dsphieu.CurrentRow.Cells[0].Value.ToString();                     
        }
    }
}
