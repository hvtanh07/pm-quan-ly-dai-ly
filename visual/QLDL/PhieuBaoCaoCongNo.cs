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
    public partial class PhieuBaoCaoCongNo : Form
    {
        PhieubaocaonoBUS bcnoBUS;
        ChitietphieubcnoBUS ctbcnoBUS;
        public PhieuBaoCaoCongNo()
        {
            InitializeComponent();
        }

        private void PhieuBaoCaoCongNo_Load(object sender, EventArgs e)
        {
            ctbcnoBUS = new ChitietphieubcnoBUS();
            bcnoBUS = new PhieubaocaonoBUS();
            loadData_Vao_GridView();
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
            PhieubaocaonoDTO no = new PhieubaocaonoDTO();
            no.mano = Matxt.Text;
            no.ngaylap = DateTime.Today;
            if (bcnoBUS.Check(DateTime.Today.Month, DateTime.Today.Year))
            {
                MessageBox.Show("Thêm hồ sơ thất bại. Tháng này đã có phiếu báo cáo công nợ");
                return;
            }
            bool kq = bcnoBUS.Them(no);
            if (kq == false)
                MessageBox.Show("Thêm hồ sơ thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                MessageBox.Show("Thêm hồ sơ thành công");
                Matxt.Text = "";
            }
            if (no != null)
            {
                CTPhieuBaoCaoCongNo frm = new CTPhieuBaoCaoCongNo(no, false);
                frm.ShowDialog();
            }
            loadData_Vao_GridView();
        }
        //search
        private void Button2_Click(object sender, EventArgs e)
        {
            string sKeyword = txtKeyword.Text.Trim();
            if (sKeyword == null || sKeyword == string.Empty || sKeyword.Length == 0) // tìm tất cả
            {
                List<PhieubaocaonoDTO> listpbcdt = bcnoBUS.select();
                this.loadData_Vao_GridView(listpbcdt);
            }
            else
            {
                List<PhieubaocaonoDTO> listpbcdt = bcnoBUS.selectByKeyWord(sKeyword);
                this.loadData_Vao_GridView(listpbcdt);
            }
        }
        private void loadData_Vao_GridView()
        {
            List<PhieubaocaonoDTO> listpbcno = bcnoBUS.select();

            if (listpbcno == null)
            {
                MessageBox.Show("Có lỗi khi lấy hồ sơ từ DB");
                return;
            }

            dsphieu.Columns.Clear();
            dsphieu.DataSource = null;

            dsphieu.AutoGenerateColumns = false;
            dsphieu.AllowUserToAddRows = false;
            dsphieu.DataSource = listpbcno;

            DataGridViewTextBoxColumn clMaxh = new DataGridViewTextBoxColumn();
            clMaxh.Name = "MaNO";
            clMaxh.HeaderText = "Mã phiếu báo cáo công nợ";
            clMaxh.DataPropertyName = "MaNO";
            dsphieu.Columns.Add(clMaxh);

            DataGridViewTextBoxColumn clTen = new DataGridViewTextBoxColumn();
            clTen.Name = "ngaylap";
            clTen.HeaderText = "Ngày lập phiếu";
            clTen.DataPropertyName = "ngaylap";
            dsphieu.Columns.Add(clTen);

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dsphieu.DataSource];
            myCurrencyManager.Refresh();
            autosize();
        }
        private void loadData_Vao_GridView(List<PhieubaocaonoDTO> listpbcno)
        {
            if (listpbcno == null)
            {
                MessageBox.Show("Có lỗi khi lấy hồ sơ từ DB");
                return;
            }

            dsphieu.Columns.Clear();
            dsphieu.DataSource = null;

            dsphieu.AutoGenerateColumns = false;
            dsphieu.AllowUserToAddRows = false;
            dsphieu.DataSource = listpbcno;

            DataGridViewTextBoxColumn clMaxh = new DataGridViewTextBoxColumn();
            clMaxh.Name = "MaNO";
            clMaxh.HeaderText = "Mã phiếu báo cáo công nợ";
            clMaxh.DataPropertyName = "MaNO";
            dsphieu.Columns.Add(clMaxh);

            DataGridViewTextBoxColumn clTen = new DataGridViewTextBoxColumn();
            clTen.Name = "ngaylap";
            clTen.HeaderText = "Ngày lập phiếu";
            clTen.DataPropertyName = "ngaylap";
            dsphieu.Columns.Add(clTen);
           
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

        private void XóaBảnGhiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn xóa phiếu công nợ này không ?, Thông tin nợ tháng trước sẽ không thay đổi", "Xóa thông tin", MessageBoxButtons.YesNo);
            if (dlr == DialogResult.Yes)
            {
                // ' Get the current cell location.
                int currentRowIndex = dsphieu.CurrentCellAddress.Y;// 'current row selected                
                //'Verify that indexing OK
                if (-1 < currentRowIndex && currentRowIndex < dsphieu.RowCount)
                {
                    PhieubaocaonoDTO no = (PhieubaocaonoDTO)dsphieu.Rows[currentRowIndex].DataBoundItem;
                    if (no != null)
                    {
                        bool kq1 = ctbcnoBUS.Xoatheophieuno(no.mano);
                        if (kq1 == false)
                            MessageBox.Show("Xóa chi tiết phiếu thất bại. Vui lòng kiểm tra lại dũ liệu");
                        else
                        {
                            bool kq2 = bcnoBUS.Xoa(no);
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

        private void XemBảnGhiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ' Get the current cell location.
            int currentRowIndex = dsphieu.CurrentCellAddress.Y;// 'current row selected
            //'Verify that indexing OK
            if (-1 < currentRowIndex && currentRowIndex < dsphieu.RowCount)
            {
                PhieubaocaonoDTO no = (PhieubaocaonoDTO)dsphieu.Rows[currentRowIndex].DataBoundItem;
                if (no != null)
                {
                    CTPhieuBaoCaoCongNo frm = new CTPhieuBaoCaoCongNo(no, true);
                    frm.ShowDialog();
                }
            }
            this.loadData_Vao_GridView();
        }

        private void Dsphieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Matxt.Text = dsphieu.CurrentRow.Cells[0].Value.ToString();
        }
    }
}
