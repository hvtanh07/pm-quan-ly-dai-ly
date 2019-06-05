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
    public partial class QuanlyDaily : Form
    {
        private CHoSoDaiLyBUS hsBUS;
        public QuanlyDaily()
        {
            InitializeComponent();
        }

        private void QuanlyDaily_Load(object sender, EventArgs e)
        {
            hsBUS = new CHoSoDaiLyBUS();
            this.loadData_Vao_GridView();           
        }
        
        private void autosize()
        {
            for (int i = 0; i < dgvBangDanhSach.Columns.Count; i++)
            {
                dgvBangDanhSach.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }
        //SỬA
        private void SửaĐạiLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ' Get the current cell location.
            int currentRowIndex = dgvBangDanhSach.CurrentCellAddress.Y;// 'current row selected


            //'Verify that indexing OK
            if (-1 < currentRowIndex && currentRowIndex < dgvBangDanhSach.RowCount)
            {
                CHoSoDaiLyDTO hs = (CHoSoDaiLyDTO)dgvBangDanhSach.Rows[currentRowIndex].DataBoundItem;
                if (hs != null)
                {
                    SuaDaiLy frm = new SuaDaiLy(hs);
                    frm.ShowDialog();
                }
            }
            this.loadData_Vao_GridView();
        }
        //XÓA
        private void XóaĐạiLýToolStripMenuItem_Click(object sender, EventArgs e)
        {          
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn xóa đại lý này không ?", "Xóa thông tin", MessageBoxButtons.YesNo);
            if (dlr == DialogResult.Yes)
            {
                // ' Get the current cell location.
                int currentRowIndex = dgvBangDanhSach.CurrentCellAddress.Y;// 'current row selected


                //'Verify that indexing OK
                if (-1 < currentRowIndex && currentRowIndex < dgvBangDanhSach.RowCount)
                {
                    CHoSoDaiLyDTO dl = (CHoSoDaiLyDTO)dgvBangDanhSach.Rows[currentRowIndex].DataBoundItem;
                    if (dl != null)
                    {
                        bool kq = hsBUS.Xoa(dl);
                        if (kq == false)
                            MessageBox.Show("Xóa đại lý thất bại. Vui lòng kiểm tra lại dũ liệu");
                        else
                        {
                            MessageBox.Show("Xóa đại lý thành công");
                            this.loadData_Vao_GridView();
                        }

                    }
                }
                this.loadData_Vao_GridView();
            }
        }
        //SEARCH
        private void Button1_Click(object sender, EventArgs e)
        {
            string sKeyword = txtKeyword.Text.Trim();
            if (sKeyword == null || sKeyword == string.Empty || sKeyword.Length == 0) // tìm tất cả
            {
                List<CHoSoDaiLyDTO> listHoSoDaiLy = hsBUS.select();
                this.loadData_Vao_GridView(listHoSoDaiLy);
            }
            else
            {
                List<CHoSoDaiLyDTO> listHoSoDaiLy = hsBUS.selectByKeyWord(sKeyword);
                this.loadData_Vao_GridView(listHoSoDaiLy);
            }
        }
        //LOAD DATA VAO GRIDVIEW
        private void loadData_Vao_GridView(List<CHoSoDaiLyDTO> listHoSoDaiLy)
        {
            if (listHoSoDaiLy == null)
            {
                MessageBox.Show("Có lỗi khi lấy hồ sơ từ DB");
                return;
            }

            dgvBangDanhSach.Columns.Clear();
            dgvBangDanhSach.DataSource = null;

            dgvBangDanhSach.AutoGenerateColumns = false;
            dgvBangDanhSach.AllowUserToAddRows = false;
            dgvBangDanhSach.DataSource = listHoSoDaiLy;

            DataGridViewTextBoxColumn clMa = new DataGridViewTextBoxColumn();
            clMa.Name = "maDL";
            clMa.HeaderText = "Mã đại lý";
            clMa.DataPropertyName = "maDL";
            dgvBangDanhSach.Columns.Add(clMa);

            DataGridViewTextBoxColumn clTen = new DataGridViewTextBoxColumn();
            clTen.Name = "tenDaiLy";
            clTen.HeaderText = "Tên đại lý";
            clTen.DataPropertyName = "tenDaiLy";
            dgvBangDanhSach.Columns.Add(clTen);

            DataGridViewTextBoxColumn cldiachi = new DataGridViewTextBoxColumn();
            cldiachi.Name = "diachi";
            cldiachi.HeaderText = "Địa chỉ";
            cldiachi.DataPropertyName = "diachi";
            dgvBangDanhSach.Columns.Add(cldiachi);

            DataGridViewTextBoxColumn clmail = new DataGridViewTextBoxColumn();
            clmail.Name = "email";
            clmail.HeaderText = "Email";
            clmail.DataPropertyName = "email";
            dgvBangDanhSach.Columns.Add(clmail);

            DataGridViewTextBoxColumn clloaidl = new DataGridViewTextBoxColumn();
            clloaidl.Name = "loaiDaiLy";
            clloaidl.HeaderText = "Loại đại lý";
            clloaidl.DataPropertyName = "loaiDaiLy";
            dgvBangDanhSach.Columns.Add(clloaidl);

            DataGridViewTextBoxColumn clntn = new DataGridViewTextBoxColumn();
            clntn.Name = "ngayTiepNhan";
            clntn.HeaderText = "Ngày tiếp nhận";
            clntn.DataPropertyName = "ngayTiepNhan";
            dgvBangDanhSach.Columns.Add(clntn);

            DataGridViewTextBoxColumn clquan = new DataGridViewTextBoxColumn();
            clquan.Name = "quan";
            clquan.HeaderText = "Quận";
            clquan.DataPropertyName = "quan";
            dgvBangDanhSach.Columns.Add(clquan);

            DataGridViewTextBoxColumn clphone = new DataGridViewTextBoxColumn();
            clphone.Name = "dienthoai";
            clphone.HeaderText = "Điện thoại";
            clphone.DataPropertyName = "dienthoai";
            dgvBangDanhSach.Columns.Add(clphone);

            DataGridViewTextBoxColumn clnht = new DataGridViewTextBoxColumn();
            clnht.Name = "nohientai";
            clnht.HeaderText = "Nợ hiện tại";
            clnht.DataPropertyName = "nohientai";
            dgvBangDanhSach.Columns.Add(clnht);

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dgvBangDanhSach.DataSource];
            myCurrencyManager.Refresh();
            autosize();
        }
        private void loadData_Vao_GridView()
        {
            List<CHoSoDaiLyDTO> listHoSoDaiLy = hsBUS.select();

            if (listHoSoDaiLy == null)
            {
                MessageBox.Show("Có lỗi khi lấy hồ sơ từ DB");
                return;
            }

            dgvBangDanhSach.Columns.Clear();
            dgvBangDanhSach.DataSource = null;

            dgvBangDanhSach.AutoGenerateColumns = false;
            dgvBangDanhSach.AllowUserToAddRows = false;
            dgvBangDanhSach.DataSource = listHoSoDaiLy;

            DataGridViewTextBoxColumn clMa = new DataGridViewTextBoxColumn();
            clMa.Name = "maDL";
            clMa.HeaderText = "Mã đại lý";
            clMa.DataPropertyName = "maDL";
            dgvBangDanhSach.Columns.Add(clMa);

            DataGridViewTextBoxColumn clTen = new DataGridViewTextBoxColumn();
            clTen.Name = "tenDaiLy";
            clTen.HeaderText = "Tên đại lý";
            clTen.DataPropertyName = "tenDaiLy";
            dgvBangDanhSach.Columns.Add(clTen);

            DataGridViewTextBoxColumn cldiachi = new DataGridViewTextBoxColumn();
            cldiachi.Name = "diachi";
            cldiachi.HeaderText = "Địa chỉ";
            cldiachi.DataPropertyName = "diachi";
            dgvBangDanhSach.Columns.Add(cldiachi);

            DataGridViewTextBoxColumn clmail = new DataGridViewTextBoxColumn();
            clmail.Name = "email";
            clmail.HeaderText = "Email";
            clmail.DataPropertyName = "email";
            dgvBangDanhSach.Columns.Add(clmail);

            DataGridViewTextBoxColumn clloaidl = new DataGridViewTextBoxColumn();
            clloaidl.Name = "loaiDaiLy";
            clloaidl.HeaderText = "Loại đại lý";
            clloaidl.DataPropertyName = "loaiDaiLy";
            dgvBangDanhSach.Columns.Add(clloaidl);

            DataGridViewTextBoxColumn clntn = new DataGridViewTextBoxColumn();
            clntn.Name = "ngayTiepNhan";
            clntn.HeaderText = "Ngày tiếp nhận";
            clntn.DataPropertyName = "ngayTiepNhan";
            dgvBangDanhSach.Columns.Add(clntn);

            DataGridViewTextBoxColumn clquan = new DataGridViewTextBoxColumn();
            clquan.Name = "quan";
            clquan.HeaderText = "Quận";
            clquan.DataPropertyName = "quan";
            dgvBangDanhSach.Columns.Add(clquan);

            DataGridViewTextBoxColumn clphone = new DataGridViewTextBoxColumn();
            clphone.Name = "dienthoai";
            clphone.HeaderText = "Điện thoại";
            clphone.DataPropertyName = "dienthoai";
            dgvBangDanhSach.Columns.Add(clphone);

            DataGridViewTextBoxColumn clnht = new DataGridViewTextBoxColumn();
            clnht.Name = "nohientai";
            clnht.HeaderText = "Nợ hiện tại";
            clnht.DataPropertyName = "nohientai";
            dgvBangDanhSach.Columns.Add(clnht);

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dgvBangDanhSach.DataSource];
            myCurrencyManager.Refresh();
            autosize();
        }
    }
}
