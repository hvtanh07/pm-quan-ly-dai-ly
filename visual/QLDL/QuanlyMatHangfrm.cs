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
    public partial class QuanlyMatHangfrm : Form
    {
        private CQuyDinhBUS qdBUS;
        private CMatHangBUS mhbus;
        private DanhsachDonviBUS dvBUS;
        private ChitietphieuxuatBUS ctpxBUS;
        public QuanlyMatHangfrm()
        {
            InitializeComponent();
        }
        
        private void ThemXoaSuaMatHangfrm_Load(object sender, EventArgs e)
        {
            ctpxBUS = new ChitietphieuxuatBUS();
            dvBUS = new DanhsachDonviBUS();
            qdBUS = new CQuyDinhBUS();
            mhbus = new CMatHangBUS();
            this.loadData_Vao_GridView();
            Taodatasource();
        }
        private void Taodatasource()
        {
            List<string> madv = new List<string>();
            madv = dvBUS.Laydonvi();
            dvt.DataSource = madv;
        }
        //THEM ---- Kiểm tra qui định thì thêm ở đây này
        private void Button1_Click(object sender, EventArgs e)
        {
            if (!testtext())
            {
                return;
            }
            DanhsachmathangDTO mh = new DanhsachmathangDTO();
            mh.mamh = mamh.Text;
            mh.tenmh = tmh.Text;
            mh.hansudung = hsd.Value;
            mh.gia = int.Parse(gia.Text);
            mh.donvitinh = dvt.Text;
            //2. Kiểm tra data hợp lệ or not
            QuiDinhDTO qd = qdBUS.Laydulieu();
            int somh = mhbus.Laysomathang();
            if (somh >= qd.soluongDVT)
            {
                MessageBox.Show("Thêm mặt hàng thất bại. Số mặt hàng đã đạt tối đa theo qui định");
                return;
            }
            //3. Thêm vào DB
            bool kq = mhbus.Them(mh);
            if (kq == false)
                MessageBox.Show("Thêm mặt hàng thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                MessageBox.Show("Thêm mặt hàng thành công");
                clear();                
            }
            loadData_Vao_GridView();
        }     
        //XOA
        private void Button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tmh.Text))
            {
                MessageBox.Show("Xóa mặt hàng thất bại. Chưa nhập mã mặt hàng cần xóa.");
                tmh.Focus();
                return;
            }
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn xóa mặt hàng này không ?", "Xóa thông tin", MessageBoxButtons.YesNo);
            if (dlr == DialogResult.Yes)
            {
                DanhsachmathangDTO mh = new DanhsachmathangDTO();
                mh.mamh = mamh.Text;
                //2. Kiểm tra data hợp lệ or not
                //3. Thêm vào DB
                bool kq1 = ctpxBUS.XoatheoMH(mh.mamh);
                bool kq2 = mhbus.Xoa(mh);
                if (kq2 == false || kq1 == false)
                    MessageBox.Show("Xóa mặt hàng thất bại. Vui lòng kiểm tra lại dũ liệu");
                else
                {
                    MessageBox.Show("Xóa mặt hàng thành công");
                    clear();
                }                    
            }
            loadData_Vao_GridView();
        }
        private void XóaMặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn xóa mặt hàng này không ?", "Xóa thông tin", MessageBoxButtons.YesNo);
            if (dlr == DialogResult.Yes)
            {
                {
                    // ' Get the current cell location.
                    int currentRowIndex = dsmathang.CurrentCellAddress.Y;// 'current row selected
                    //'Verify that indexing OK
                    if (-1 < currentRowIndex && currentRowIndex < dsmathang.RowCount)
                    {
                        DanhsachmathangDTO dl = (DanhsachmathangDTO)dsmathang.Rows[currentRowIndex].DataBoundItem;
                        if (dl != null)
                        {
                            bool kq1 = ctpxBUS.XoatheoMH(dl.mamh);
                            bool kq2 = mhbus.Xoa(dl);
                            if (kq1 == false || kq2 == false)
                                MessageBox.Show("Xóa mặt hàng thất bại. Vui lòng kiểm tra lại dũ liệu");
                            else
                            {
                                MessageBox.Show("Xóa mặt hàng thành công");
                                this.loadData_Vao_GridView();
                            }
                        }
                    } 
                }
            }
            loadData_Vao_GridView();
        }
        //SUA
        private void Button3_Click(object sender, EventArgs e)
        {
            if (!testtext())
            {
                return;
            }
            DanhsachmathangDTO mh = new DanhsachmathangDTO();
            mh.mamh = mamh.Text;
            mh.tenmh = tmh.Text;
            mh.hansudung = hsd.Value;
            mh.gia = int.Parse(gia.Text);
            mh.donvitinh = dvt.Text;
            //2. Kiểm tra data hợp lệ or not            
            //3. Thêm vào DB
            bool kq = mhbus.Sua(mh);
            if (kq == false)
                MessageBox.Show("Sửa mặt hàng thất bại. Vui lòng kiểm tra lại dữ liệu");
            else
                MessageBox.Show("Sửa mặt hàng thành công");
            loadData_Vao_GridView();
        }
        private void SửaMặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ' Get the current cell location.
            int currentRowIndex = dsmathang.CurrentCellAddress.Y;// 'current row selected
            if (!testtext())
            {
                return;
            }
            //'Verify that indexing OK
            if (-1 < currentRowIndex && currentRowIndex < dsmathang.RowCount)
            {
                DanhsachmathangDTO mh = new DanhsachmathangDTO();
                mh.mamh = mamh.Text;
                mh.tenmh = tmh.Text;
                mh.hansudung = hsd.Value;
                mh.gia = int.Parse(gia.Text);
                mh.donvitinh = dvt.Text;
                bool kq = mhbus.Sua(mh);
                if (kq == false)
                    MessageBox.Show("Sửa mặt hàng thất bại. Vui lòng kiểm tra lại dữ liệu");
                else
                    MessageBox.Show("Sửa mặt hàng thành công");
            }
            this.loadData_Vao_GridView();
        }
        //TIM KIEM
        private void Button4_Click(object sender, EventArgs e)
        {
            string sKeyword = txtKeyword.Text.Trim();
            if (sKeyword == null || sKeyword == string.Empty || sKeyword.Length == 0) // tìm tất cả
            {
                List<DanhsachmathangDTO> listMatHang = mhbus.select();
                this.loadData_Vao_GridView(listMatHang);
            }
            else
            {
                List<DanhsachmathangDTO> listMatHang = mhbus.selectByKeyWord(sKeyword);
                this.loadData_Vao_GridView(listMatHang);
            }
        }             
        //Lấy dữ liệu nhập vào khung 
        private void Dsmathang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            mamh.Text = dsmathang.CurrentRow.Cells[0].Value.ToString();
            tmh.Text = dsmathang.CurrentRow.Cells[1].Value.ToString();
            hsd.Value = Convert.ToDateTime(dsmathang.CurrentRow.Cells[2].Value.ToString());
            gia.Text = dsmathang.CurrentRow.Cells[3].Value.ToString();
            dvt.Text = dsmathang.CurrentRow.Cells[4].Value.ToString();
        }
        private void loadData_Vao_GridView()
        {
            List<DanhsachmathangDTO> listMatHang = mhbus.select();

            if (listMatHang == null)
            {
                MessageBox.Show("Có lỗi khi lấy hồ sơ từ DB");
                return;
            }

            dsmathang.Columns.Clear();
            dsmathang.DataSource = null;

            dsmathang.AutoGenerateColumns = false;
            dsmathang.AllowUserToAddRows = false;
            dsmathang.DataSource = listMatHang;

            DataGridViewTextBoxColumn clMa = new DataGridViewTextBoxColumn();
            clMa.Name = "MaMH";
            clMa.HeaderText = "Mã mặt hàng";
            clMa.DataPropertyName = "MaMH";
            dsmathang.Columns.Add(clMa);

            DataGridViewTextBoxColumn clTen = new DataGridViewTextBoxColumn();
            clTen.Name = "tenmh";
            clTen.HeaderText = "Tên mặt hàng";
            clTen.DataPropertyName = "tenmh";
            dsmathang.Columns.Add(clTen);

            DataGridViewTextBoxColumn clhsd = new DataGridViewTextBoxColumn();
            clhsd.Name = "hanSuDung";
            clhsd.HeaderText = "Hạn sử dụng";
            clhsd.DataPropertyName = "hanSuDung";
            dsmathang.Columns.Add(clhsd);

            DataGridViewTextBoxColumn clgia = new DataGridViewTextBoxColumn();
            clgia.Name = "gia";
            clgia.HeaderText = "Giá";
            clgia.DataPropertyName = "gia";
            dsmathang.Columns.Add(clgia);

            DataGridViewTextBoxColumn cldvt = new DataGridViewTextBoxColumn();
            cldvt.Name = "donViTinh";
            cldvt.HeaderText = "Đơn vị tính";
            cldvt.DataPropertyName = "donViTinh";
            dsmathang.Columns.Add(cldvt);
       
            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dsmathang.DataSource];
            myCurrencyManager.Refresh();
            autosize();
        }
        private void loadData_Vao_GridView(List<DanhsachmathangDTO> listMatHang)
        {
            if (listMatHang == null)
            {
                MessageBox.Show("Có lỗi khi lấy hồ sơ từ DB");
                return;
            }

            dsmathang.Columns.Clear();
            dsmathang.DataSource = null;

            dsmathang.AutoGenerateColumns = false;
            dsmathang.AllowUserToAddRows = false;
            dsmathang.DataSource = listMatHang;

            DataGridViewTextBoxColumn clMa = new DataGridViewTextBoxColumn();
            clMa.Name = "MaMH";
            clMa.HeaderText = "Mã mặt hàng";
            clMa.DataPropertyName = "MaMH";
            dsmathang.Columns.Add(clMa);

            DataGridViewTextBoxColumn clTen = new DataGridViewTextBoxColumn();
            clTen.Name = "tenmh";
            clTen.HeaderText = "Tên mặt hàng";
            clTen.DataPropertyName = "tenmh";
            dsmathang.Columns.Add(clTen);

            DataGridViewTextBoxColumn clhsd = new DataGridViewTextBoxColumn();
            clhsd.Name = "hanSuDung";
            clhsd.HeaderText = "Hạn sử dụng";
            clhsd.DataPropertyName = "hanSuDung";
            dsmathang.Columns.Add(clhsd);

            DataGridViewTextBoxColumn clgia = new DataGridViewTextBoxColumn();
            clgia.Name = "gia";
            clgia.HeaderText = "Giá";
            clgia.DataPropertyName = "gia";
            dsmathang.Columns.Add(clgia);

            DataGridViewTextBoxColumn cldvt = new DataGridViewTextBoxColumn();
            cldvt.Name = "donViTinh";
            cldvt.HeaderText = "Đơn vị tính";
            cldvt.DataPropertyName = "donViTinh";
            dsmathang.Columns.Add(cldvt);

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dsmathang.DataSource];
            myCurrencyManager.Refresh();
            autosize();
        }
        //XÓA CÁC Ô ĐIỀN DỮ LIỆU
        private void clear()
        {
            mamh.Text = "";
            tmh.Text="";
            hsd.Value = DateTime.Today;
            gia.Text = "";
            dvt.Text = "";
        }
        //RÀNG BUỘC CỦA DỮ LIỆU NHẬP VÀO
        bool testtext()//kiểm tra ô dữ liệu trống
        {
            if (string.IsNullOrWhiteSpace(mamh.Text))
            {
                MessageBox.Show(mamh, "Bạn chưa nhập mã mặt hàng.");
                mamh.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(tmh.Text))
            {
                MessageBox.Show(tmh, "Bạn chưa nhập tên mặt hàng.");
                tmh.Focus();
                return false;
            }
            if (DateTime.Compare(hsd.Value, DateTime.Today) < 0)
            {
                MessageBox.Show("Mặt hàng đã hết hạn sử dụng hoặc hạn sử dụng không đúng, vui lòng thử lại");
                return false;
            }//check hạn sử dụng
            if (string.IsNullOrWhiteSpace(gia.Text))
            {
                MessageBox.Show(gia, "Bạn chưa nhập giá.");
                gia.Focus();
                return false;
            }//gia 
            if (string.IsNullOrWhiteSpace(dvt.Text))//quan
            {
                MessageBox.Show(dvt, "Bạn chưa nhập đơn vị tính.");
                dvt.Focus();
                return false;
            }//don vi tinh      
            
            return true;//all true then gud to go
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
            for (int i = 0; i < dsmathang.Columns.Count; i++)
            {
                dsmathang.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }
    }
}
