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
    public partial class QuanLyLoaiDaily : Form
    {
        public QuanLyLoaiDaily()
        {
            InitializeComponent();
        }
        private CLoaiDaiLyBUS ldlbus;
        private void QuanLyLoaiDaily_Load(object sender, EventArgs e)
        {
            ldlbus = new CLoaiDaiLyBUS();
            this.loadData_Vao_GridView();
        }
        private void loadData_Vao_GridView()
        {
            List<LoaiDaiLyDTO> listldl = ldlbus.select();

            if (listldl == null)
            {
                MessageBox.Show("Có lỗi khi lấy hồ sơ từ DB");
                return;
            }

            danhsachldl.Columns.Clear();
            danhsachldl.DataSource = null;

            danhsachldl.AutoGenerateColumns = false;
            danhsachldl.AllowUserToAddRows = false;
            danhsachldl.DataSource = listldl;

            DataGridViewTextBoxColumn clMa = new DataGridViewTextBoxColumn();
            clMa.Name = "maldl";
            clMa.HeaderText = "Mã loại";
            clMa.DataPropertyName = "maldl";
            danhsachldl.Columns.Add(clMa);

            DataGridViewTextBoxColumn clTen = new DataGridViewTextBoxColumn();
            clTen.Name = "loaiDaiLy";
            clTen.HeaderText = "Loại đại lý";
            clTen.DataPropertyName = "loaiDaiLy";
            danhsachldl.Columns.Add(clTen);

            DataGridViewTextBoxColumn clhsd = new DataGridViewTextBoxColumn();
            clhsd.Name = "maxno";
            clhsd.HeaderText = "Số tiền nợ tối đa";
            clhsd.DataPropertyName = "maxno";
            danhsachldl.Columns.Add(clhsd);
          
            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[danhsachldl.DataSource];
            myCurrencyManager.Refresh();
            autosize();
        }
        private void loadData_Vao_GridView(List<LoaiDaiLyDTO> listldl)
        {
            if (listldl == null)
            {
                MessageBox.Show("Có lỗi khi lấy hồ sơ từ DB");
                return;
            }

            danhsachldl.Columns.Clear();
            danhsachldl.DataSource = null;

            danhsachldl.AutoGenerateColumns = false;
            danhsachldl.AllowUserToAddRows = false;
            danhsachldl.DataSource = listldl;

            DataGridViewTextBoxColumn clMa = new DataGridViewTextBoxColumn();
            clMa.Name = "maldl";
            clMa.HeaderText = "Mã loại";
            clMa.DataPropertyName = "maldl";
            danhsachldl.Columns.Add(clMa);

            DataGridViewTextBoxColumn clTen = new DataGridViewTextBoxColumn();
            clTen.Name = "loaiDaiLy";
            clTen.HeaderText = "Loại đại lý";
            clTen.DataPropertyName = "loaiDaiLy";
            danhsachldl.Columns.Add(clTen);

            DataGridViewTextBoxColumn clhsd = new DataGridViewTextBoxColumn();
            clhsd.Name = "maxno";
            clhsd.HeaderText = "Số tiền nợ tối đa";
            clhsd.DataPropertyName = "maxno";
            danhsachldl.Columns.Add(clhsd);

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[danhsachldl.DataSource];
            myCurrencyManager.Refresh();
            autosize();
        }
        //them
        private void Button1_Click(object sender, EventArgs e)
        {
            if (!testtext())
            {
                return;
            }
            LoaiDaiLyDTO ldl = new LoaiDaiLyDTO();
            ldl.maLDL = maldl.Text;
            ldl.loaidaily = int.Parse(ldltxt.Text);
            ldl.MaxNo = int.Parse(stntxt.Text);           
            //2. Kiểm tra data hợp lệ or not
            
            //3. Thêm vào DB
            bool kq = ldlbus.Them(ldl);
            if (kq == false)
                MessageBox.Show("Thêm loại đại lý thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                MessageBox.Show("Thêm loại đại lý thành công");
                clear();
            }
            loadData_Vao_GridView();
        }
        //sua
        private void Button3_Click(object sender, EventArgs e)
        {
            LoaiDaiLyDTO ldl = new LoaiDaiLyDTO();
            ldl.maLDL = maldl.Text;
            ldl.loaidaily = int.Parse(ldltxt.Text);
            ldl.MaxNo = int.Parse(stntxt.Text);
            //2. Kiểm tra data hợp lệ or not

            //3. Thêm vào DB
            bool kq = ldlbus.Sua(ldl);
            if (kq == false)
                MessageBox.Show("Sửa loại đại lý thất bại. Vui lòng kiểm tra lại dữ liệu");
            else
                MessageBox.Show("Sửa loại đại lý thành công");
            loadData_Vao_GridView();
        }
        //xoa
        private void XóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn xóa loại đại lý này không ?", "Xóa thông tin", MessageBoxButtons.YesNo);
            if (dlr == DialogResult.Yes)
            {
                int currentRowIndex = danhsachldl.CurrentCellAddress.Y;// 'current row selected
                if (-1 < currentRowIndex && currentRowIndex < danhsachldl.RowCount)
                {
                    LoaiDaiLyDTO ldl = (LoaiDaiLyDTO)danhsachldl.Rows[currentRowIndex].DataBoundItem;
                    if (ldl != null)
                    {
                        bool kq = ldlbus.Xoa(ldl);
                        if (kq == false)
                            MessageBox.Show("Xóa loại đại lý thất bại. Vui lòng kiểm tra lại dũ liệu");
                        else
                        {
                            MessageBox.Show("Xóa loại đại lý thành công");
                            this.loadData_Vao_GridView();
                        }

                    }
                }

            }
        }
        //tim kiem
        private void Button4_Click(object sender, EventArgs e)
        {
            string sKeyword = txtKeyword.Text.Trim();
            if (sKeyword == null || sKeyword == string.Empty || sKeyword.Length == 0) // tìm tất cả
            {
                List<LoaiDaiLyDTO> listldl = ldlbus.select();
                this.loadData_Vao_GridView(listldl);
            }
            else
            {
                List<LoaiDaiLyDTO> listldl = ldlbus.selectByKeyWord(sKeyword);
                this.loadData_Vao_GridView(listldl);
            }
        }
        bool testtext()//kiểm tra ô dữ liệu trống
        {
            if (string.IsNullOrWhiteSpace(maldl.Text))
            {
                MessageBox.Show(maldl, "Bạn chưa nhập loại đại lý.");
                maldl.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(ldltxt.Text))
            {
                MessageBox.Show(ldltxt, "Bạn chưa nhập loại đại lý.");
                ldltxt.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(stntxt.Text))
            {
                MessageBox.Show(stntxt, "Bạn chưa nhập số tiền nợ đại lý.");
                stntxt.Focus();
                return false;
            }
            return true;//all true then gud to go
        }
        private void clear()
        {
            maldl.Text = "";
            ldltxt.Text = "";
            stntxt.Text = "";
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
        private void autosize()
        {
            for (int i = 0; i < danhsachldl.Columns.Count; i++)
            {
                danhsachldl.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }
        private void Danhsachldl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            maldl.Text = danhsachldl.CurrentRow.Cells[0].Value.ToString();
            ldltxt.Text = danhsachldl.CurrentRow.Cells[0].Value.ToString();
            stntxt.Text = danhsachldl.CurrentRow.Cells[1].Value.ToString();
        }
    }
}
