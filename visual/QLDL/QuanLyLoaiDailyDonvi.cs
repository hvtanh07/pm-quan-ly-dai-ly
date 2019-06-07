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
    public partial class QuanLyLoaiDailyDonvi : Form
    {
        public QuanLyLoaiDailyDonvi()
        {
            InitializeComponent();
        }
        private CLoaiDaiLyBUS ldlbus;
        private DanhsachDonviBUS dvbus;
        private CQuyDinhBUS quidinhBUS;
        private void QuanLyLoaiDaily_Load(object sender, EventArgs e)
        {
            ldlbus = new CLoaiDaiLyBUS();
            dvbus = new DanhsachDonviBUS();
            quidinhBUS = new CQuyDinhBUS();
            this.loadData_Vao_GridView();
            this.loadData_Vao_GridViewDV();
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
        //-------------------------------LOAI DAI LY----------------------------------
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
            if (!testtext1())
            {
                return;
            }
            LoaiDaiLyDTO ldl = new LoaiDaiLyDTO();
            ldl.maLDL = maldl.Text;
            ldl.loaidaily = int.Parse(ldltxt.Text);
            ldl.MaxNo = int.Parse(stntxt.Text);
            //2. Kiểm tra data hợp lệ or not
            QuiDinhDTO qd = quidinhBUS.Laydulieu();
            int soldl = ldlbus.Laysoloaidl();
            if (soldl >= qd.Maxloaidl)
            {
                MessageBox.Show("Thêm loại đại lý thất bại. Số loại đại lý đã đạt tối đa theo qui định");
                return;
            }
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
            string sKeyword = txtKeyword1.Text.Trim();
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
        bool testtext1()//kiểm tra ô dữ liệu trống
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
        private void Danhsachldl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            maldl.Text = danhsachldl.CurrentRow.Cells[0].Value.ToString();
            ldltxt.Text = danhsachldl.CurrentRow.Cells[0].Value.ToString();
            stntxt.Text = danhsachldl.CurrentRow.Cells[1].Value.ToString();
        }
        //-------------------------------DON VI-------------------------------------
        //Search
        private void Button4_Click_1(object sender, EventArgs e)
        {
            string sKeyword = txtKeyword2.Text.Trim();
            if (sKeyword == null || sKeyword == string.Empty || sKeyword.Length == 0) // tìm tất cả
            {               
                List<DanhsachDonviDTO> listdv = dvbus.select();
                this.loadData_Vao_GridViewDV(listdv);
            }
            else
            {
                List<DanhsachDonviDTO> listdv = dvbus.selectByKeyWord(sKeyword);
                this.loadData_Vao_GridViewDV(listdv);
            }
        }
        //them
        private void Button5_Click(object sender, EventArgs e)
        {
            if (!testtext2())
            {
                return;
            }
            DanhsachDonviDTO dv = new DanhsachDonviDTO();
            dv.donvitinh = Donvitxt.Text;
            //2. Kiểm tra data hợp lệ or not
            QuiDinhDTO qd = quidinhBUS.Laydulieu();
            int sodv = dvbus.Laysodonvi();
            if (sodv >= qd.soluongDVT)
            {
                MessageBox.Show("Thêm đơn vị thất bại. Số đơn vị đã đạt tối đa theo qui định");
                return;
            }
            //3. Thêm vào DB
            bool kq = dvbus.Them(dv);
            if (kq == false)
                MessageBox.Show("Thêm đơn vị thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                MessageBox.Show("Thêm đơn vị thành công");
                clear();
            }
            loadData_Vao_GridViewDV();
        }
        private void loadData_Vao_GridViewDV()
        {
            List<DanhsachDonviDTO> listdv = dvbus.select();

            if (listdv == null)
            {
                MessageBox.Show("Có lỗi khi lấy hồ sơ từ DB");
                return;
            }

            dsDonvi.Columns.Clear();
            dsDonvi.DataSource = null;

            dsDonvi.AutoGenerateColumns = false;
            dsDonvi.AllowUserToAddRows = false;
            dsDonvi.DataSource = listdv;

            DataGridViewTextBoxColumn clMa = new DataGridViewTextBoxColumn();
            clMa.Name = "DonViTinh";
            clMa.HeaderText = "Đơn vị";
            clMa.DataPropertyName = "DonViTinh";
            dsDonvi.Columns.Add(clMa);
            
            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dsDonvi.DataSource];
            myCurrencyManager.Refresh();
            autosize();
        }
        private void loadData_Vao_GridViewDV(List<DanhsachDonviDTO> listdv)
        {
            if (listdv == null)
            {
                MessageBox.Show("Có lỗi khi lấy hồ sơ từ DB");
                return;
            }

            dsDonvi.Columns.Clear();
            dsDonvi.DataSource = null;

            dsDonvi.AutoGenerateColumns = false;
            dsDonvi.AllowUserToAddRows = false;
            dsDonvi.DataSource = listdv;

            DataGridViewTextBoxColumn clMa = new DataGridViewTextBoxColumn();
            clMa.Name = "DonViTinh";
            clMa.HeaderText = "Đơn vị";
            clMa.DataPropertyName = "DonViTinh";
            dsDonvi.Columns.Add(clMa);

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dsDonvi.DataSource];
            myCurrencyManager.Refresh();
            autosize();
        } 
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Donvitxt.Text = dsDonvi.CurrentRow.Cells[0].Value.ToString();
        }
        bool testtext2()//kiểm tra ô dữ liệu trống
        {
            if (string.IsNullOrWhiteSpace(Donvitxt.Text))
            {
                MessageBox.Show(Donvitxt, "Bạn chưa nhập loại đại lý.");
                Donvitxt.Focus();
                return false;
            }            
            return true;//all true then gud to go
        }
        private void XóaĐơnVịToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn xóa đơn vị này không ?", "Xóa thông tin", MessageBoxButtons.YesNo);
            if (dlr == DialogResult.Yes)
            {
                int currentRowIndex = dsDonvi.CurrentCellAddress.Y;// 'current row selected
                if (-1 < currentRowIndex && currentRowIndex < dsDonvi.RowCount)
                {
                    DanhsachDonviDTO dv = (DanhsachDonviDTO)dsDonvi.Rows[currentRowIndex].DataBoundItem;
                    if (dv != null)
                    {
                        bool kq = dvbus.Xoa(dv);
                        if (kq == false)
                            MessageBox.Show("Xóa đơn vị thất bại. Vui lòng kiểm tra lại dũ liệu");
                        else
                        {
                            MessageBox.Show("Xóa đơn vị thành công");
                            this.loadData_Vao_GridViewDV();
                        }
                    }
                }

            }
        }
    }
}
