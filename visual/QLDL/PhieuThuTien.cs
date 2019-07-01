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
    public partial class PhieuThuTien : Form
    {
        int tienthucu = 0;
        private CHoSoDaiLyBUS hsBUS;
        private PhieuThuTienBUS pttBUS;
        public PhieuThuTien()
        {
            InitializeComponent();
        }
        private void PhieuThuTien_Load(object sender, EventArgs e)
        {
            hsBUS = new CHoSoDaiLyBUS();
            pttBUS = new PhieuThuTienBUS();
            this.loadData_Vao_GridView();
            Taodatasource();
            Ngaythu.Value = DateTime.Today;
        }
        private void Taodatasource()
        {
            List<string> madl = new List<string>();
            madl = hsBUS.Laymadl();
            madltxt.DataSource = madl;
        }
        //them
        private void Button2_Click(object sender, EventArgs e)
        {
            if (!testtext())
            {
                return;
            }
            PhieuThuTienDTO ptt = new PhieuThuTienDTO();
            ptt.madl = madltxt.Text;
            ptt.mathutien = maptt.Text;
            ptt.ngaythu = Ngaythu.Value;
            ptt.sotienthu = int.Parse(tienthu.Text);
            //2. Kiểm tra data hợp lệ or not
            //kiểm tra trong quận đã đạt tối đa số đại lý chưa
            if (ptt.sotienthu > hsBUS.Laytienno(ptt.madl))
            {
                MessageBox.Show("Thêm hồ sơ thất bại. Số tiền thu không được vượt quá số tiền đang nợ");
                return;
            }
            int noht = hsBUS.Laytienno(ptt.madl) - ptt.sotienthu;
            
            //3. Thêm vào DB

            {
                bool kq1 = hsBUS.Suano(ptt.madl, noht);
                bool kq2 = pttBUS.Them(ptt);
                if (kq1 == false && kq2 == false)
                    MessageBox.Show("Thêm hồ sơ thất bại. Vui lòng kiểm tra lại dũ liệu");
                else
                {
                    MessageBox.Show("Thêm hồ sơ thành công");
                    maptt.Text = "";
                    tienthu.Text = "";
                    Ngaythu.Value = DateTime.Today;
                }
            }
            loadData_Vao_GridView();
        }
        //sua
        private void SửaBảnGhiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ' Get the current cell location.
            int currentRowIndex = Dsphieuthu.CurrentCellAddress.Y;// 'current row selected
            if (!testtext())
            {
                return;
            }
            //'Verify that indexing OK
            if (-1 < currentRowIndex && currentRowIndex < Dsphieuthu.RowCount)
            {
                PhieuThuTienDTO ptt = new PhieuThuTienDTO();
                ptt.mathutien = maptt.Text;
                ptt.madl = madltxt.Text;
                ptt.ngaythu = Ngaythu.Value;
                ptt.sotienthu = int.Parse(tienthu.Text);
                //check data hợp lệ
                int thuphatsinh = ptt.sotienthu - tienthucu;
                int nochuathutien = hsBUS.Laytienno(ptt.madl) + tienthucu;
                if (ptt.sotienthu > nochuathutien)
                {
                    MessageBox.Show("Thêm hồ sơ thất bại. Số tiền thu không được vượt quá số tiền đang nợ");
                    return;
                }
                int noht = hsBUS.Laytienno(ptt.madl) - thuphatsinh;
                //load vào database
                bool kq1 = hsBUS.Suano(ptt.madl, noht);
                bool kq2 = pttBUS.Sua(ptt);
                if (kq1 == false && kq2 == false)
                    MessageBox.Show("Sửa thông tin phiếu thu thất bại. Vui lòng kiểm tra lại dữ liệu");
                else
                    MessageBox.Show("Sửa thông tin phiếu thu thành công");
            }
            this.loadData_Vao_GridView();
        }
        //xoa
        private void XóaBảnGhiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn xóa mặt hàng này không ?", "Xóa thông tin", MessageBoxButtons.YesNo);
            if (dlr == DialogResult.Yes)
            {
                {
                    // ' Get the current cell location.
                    int currentRowIndex = Dsphieuthu.CurrentCellAddress.Y;// 'current row selected
                    //'Verify that indexing OK
                    if (-1 < currentRowIndex && currentRowIndex < Dsphieuthu.RowCount)
                    {
                        PhieuThuTienDTO ptt = (PhieuThuTienDTO)Dsphieuthu.Rows[currentRowIndex].DataBoundItem;
                        if (ptt != null)
                        {
                            bool kq = pttBUS.Xoa(ptt);
                            if (kq == false)
                                MessageBox.Show("Xóa thông tin phiếu thu thất bại. Vui lòng kiểm tra lại dũ liệu");
                            else
                            {
                                MessageBox.Show("Xóa thông tin phiếu thu thành công");
                                this.loadData_Vao_GridView();
                            }
                        }
                    }
                }
            }
            loadData_Vao_GridView();
        }
        //search
        private void Button1_Click(object sender, EventArgs e)
        {
            string sKeyword = txtKeyword.Text.Trim();
            if (sKeyword == null || sKeyword == string.Empty || sKeyword.Length == 0) // tìm tất cả
            {
                List<PhieuThuTienDTO> listphieuthu = pttBUS.select();
                this.loadData_Vao_GridView(listphieuthu);
            }
            else
            {
                List<PhieuThuTienDTO> listphieuthu = pttBUS.selectByKeyWord(sKeyword);
                this.loadData_Vao_GridView(listphieuthu);
            }
        }
        private void numOnly(object sender, KeyPressEventArgs e)// I have no idea how this shit work, so dont touch it
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        bool testtext()//kiểm tra ô dữ liệu trống
        {
            if (string.IsNullOrWhiteSpace(maptt.Text))
            {
                MessageBox.Show(maptt, "Bạn chưa nhập số mã phiếu thu.");
                maptt.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(tienthu.Text))
            {
                MessageBox.Show(tienthu, "Bạn chưa nhập số tiền thu.");
                tienthu.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(maptt.Text))
            {
                MessageBox.Show(maptt, "Bạn chưa nhập mã phiếu thu.");
                maptt.Focus();
                return false;
            }          
            return true;//all true then gud to go
        }
        private void autosize()
        {
            for (int i = 0; i < Dsphieuthu.Columns.Count; i++)
            {
                Dsphieuthu.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }
        private void loadData_Vao_GridView()
        {
            List<PhieuThuTienDTO> listMatHang = pttBUS.select();

            if (listMatHang == null)
            {
                MessageBox.Show("Có lỗi khi lấy hồ sơ từ DB");
                return;
            }

            Dsphieuthu.Columns.Clear();
            Dsphieuthu.DataSource = null;

            Dsphieuthu.AutoGenerateColumns = false;
            Dsphieuthu.AllowUserToAddRows = false;
            Dsphieuthu.DataSource = listMatHang;

            DataGridViewTextBoxColumn clMA = new DataGridViewTextBoxColumn();
            clMA.Name = "mathutien";
            clMA.HeaderText = "Mã phiếu thu";
            clMA.DataPropertyName = "mathutien";
            Dsphieuthu.Columns.Add(clMA);

            DataGridViewTextBoxColumn clMAdl = new DataGridViewTextBoxColumn();
            clMAdl.Name = "madl";
            clMAdl.HeaderText = "Mã đại lý";
            clMAdl.DataPropertyName = "madl";
            Dsphieuthu.Columns.Add(clMAdl);

            DataGridViewTextBoxColumn cldc = new DataGridViewTextBoxColumn();
            cldc.Name = "diachi";
            cldc.HeaderText = "Địa chỉ";
            cldc.DataPropertyName = "diachi";
            Dsphieuthu.Columns.Add(cldc);

            DataGridViewTextBoxColumn cldt = new DataGridViewTextBoxColumn();
            cldt.Name = "dienthoai";
            cldt.HeaderText = "Điện thoại";
            cldt.DataPropertyName = "dienthoai";
            Dsphieuthu.Columns.Add(cldt);

            DataGridViewTextBoxColumn clmail = new DataGridViewTextBoxColumn();
            clmail.Name = "email";
            clmail.HeaderText = "Email";
            clmail.DataPropertyName = "email";
            Dsphieuthu.Columns.Add(clmail);

            DataGridViewTextBoxColumn cldate = new DataGridViewTextBoxColumn();
            cldate.Name = "ngaythu";
            cldate.HeaderText = "Ngày thu tiền";
            cldate.DataPropertyName = "ngaythu";
            Dsphieuthu.Columns.Add(cldate);

            DataGridViewTextBoxColumn clstt = new DataGridViewTextBoxColumn();
            clstt.Name = "sotienthu";
            clstt.HeaderText = "Số tiền thu";
            clstt.DataPropertyName = "sotienthu";
            Dsphieuthu.Columns.Add(clstt);

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[Dsphieuthu.DataSource];
            autosize();
            myCurrencyManager.Refresh();           
        }
        private void loadData_Vao_GridView(List<PhieuThuTienDTO> listptt)
        {
            if (listptt == null)
            {
                MessageBox.Show("Có lỗi khi lấy hồ sơ từ DB");
                return;
            }

            Dsphieuthu.Columns.Clear();
            Dsphieuthu.DataSource = null;

            Dsphieuthu.AutoGenerateColumns = false;
            Dsphieuthu.AllowUserToAddRows = false;
            Dsphieuthu.DataSource = listptt;

            DataGridViewTextBoxColumn clMA = new DataGridViewTextBoxColumn();
            clMA.Name = "mathutien";
            clMA.HeaderText = "Mã phiếu thu";
            clMA.DataPropertyName = "mathutien";
            Dsphieuthu.Columns.Add(clMA);

            DataGridViewTextBoxColumn clMAdl = new DataGridViewTextBoxColumn();
            clMAdl.Name = "madl";
            clMAdl.HeaderText = "Mã đại lý";
            clMAdl.DataPropertyName = "madl";
            Dsphieuthu.Columns.Add(clMAdl);

            DataGridViewTextBoxColumn cldc = new DataGridViewTextBoxColumn();
            cldc.Name = "diachi";
            cldc.HeaderText = "Địa chỉ";
            cldc.DataPropertyName = "diachi";
            Dsphieuthu.Columns.Add(cldc);

            DataGridViewTextBoxColumn cldt = new DataGridViewTextBoxColumn();
            cldt.Name = "dienthoai";
            cldt.HeaderText = "Điện thoại";
            cldt.DataPropertyName = "dienthoai";
            Dsphieuthu.Columns.Add(cldt);

            DataGridViewTextBoxColumn clmail = new DataGridViewTextBoxColumn();
            clmail.Name = "email";
            clmail.HeaderText = "Email";
            clmail.DataPropertyName = "email";
            Dsphieuthu.Columns.Add(clmail);

            DataGridViewTextBoxColumn cldate = new DataGridViewTextBoxColumn();
            cldate.Name = "ngaythu";
            cldate.HeaderText = "Ngày thu tiền";
            cldate.DataPropertyName = "ngaythu";
            Dsphieuthu.Columns.Add(cldate);

            DataGridViewTextBoxColumn clstt = new DataGridViewTextBoxColumn();
            clstt.Name = "sotienthu";
            clstt.HeaderText = "Số tiền thu";
            clstt.DataPropertyName = "sotienthu";
            Dsphieuthu.Columns.Add(clstt);

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[Dsphieuthu.DataSource];
            autosize();
            myCurrencyManager.Refresh();       
        }
        private void Dsphieuthu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            maptt.Text= Dsphieuthu.CurrentRow.Cells[0].Value.ToString();
            madltxt.Text = Dsphieuthu.CurrentRow.Cells[1].Value.ToString();
            Ngaythu.Value = Convert.ToDateTime(Dsphieuthu.CurrentRow.Cells[5].Value.ToString());
            tienthu.Text = Dsphieuthu.CurrentRow.Cells[6].Value.ToString();
            tienthucu = int.Parse(tienthu.Text);
        }
        
    }
}
