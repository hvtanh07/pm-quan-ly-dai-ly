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
        public QuanlyMatHangfrm()
        {
            InitializeComponent();
        }
        private CMatHangBUS mhbus;
        private void ThemXoaSuaMatHangfrm_Load(object sender, EventArgs e)
        {
            mhbus = new CMatHangBUS();
            this.loadData_Vao_GridView();
        }
        //THEM
        private void Button1_Click(object sender, EventArgs e)
        {
            if (!testtext())
            {
                return;
            }
            DanhsachmathangDTO mh = new DanhsachmathangDTO();
            mh.Mamh = int.Parse(ma.Text);
            mh.tenmh = tmh.Text;
            mh.khoiluong = int.Parse(kl.Text);
            mh.soluong = int.Parse(sl.Text);
            mh.hansudung = hsd.Value;
            mh.gia = int.Parse(gia.Text);
            mh.donvitinh = dvt.Text;
            //2. Kiểm tra data hợp lệ or not
            
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
            if (string.IsNullOrWhiteSpace(ma.Text))
            {
                MessageBox.Show("Xóa mặt hàng thất bại. Chưa nhập mã mặt hàng cần xóa.");
                ma.Focus();
                return;
            }
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn xóa mặt hàng này không ?", "Xóa thông tin", MessageBoxButtons.YesNo);
            if (dlr == DialogResult.Yes)
            {
                DanhsachmathangDTO mh = new DanhsachmathangDTO();
                mh.Mamh = int.Parse(ma.Text);
                //2. Kiểm tra data hợp lệ or not

                //3. Thêm vào DB
                bool kq = mhbus.Xoa(mh);
                if (kq == false)
                    MessageBox.Show("Xóa mặt hàng thất bại. Vui lòng kiểm tra lại dũ liệu");
                else
                {
                    MessageBox.Show("Xóa mặt hàng thành công");
                    clear();
                }                    
            }
            loadData_Vao_GridView();
        }
        //SUA
        private void Button3_Click(object sender, EventArgs e)
        {
            DanhsachmathangDTO mh = new DanhsachmathangDTO();
            mh.Mamh = int.Parse(ma.Text);
            mh.tenmh = tmh.Text;
            mh.khoiluong = int.Parse(kl.Text);
            mh.soluong = int.Parse(sl.Text);
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
            clMa.Name = "Mamh";
            clMa.HeaderText = "Mã mặt hàng";
            clMa.DataPropertyName = "Mamh";
            dsmathang.Columns.Add(clMa);

            DataGridViewTextBoxColumn clTen = new DataGridViewTextBoxColumn();
            clTen.Name = "tenmh";
            clTen.HeaderText = "Tên mặt hàng";
            clTen.DataPropertyName = "tenmh";
            dsmathang.Columns.Add(clTen);

            DataGridViewTextBoxColumn clsl = new DataGridViewTextBoxColumn();
            clsl.Name = "soluong";
            clsl.HeaderText = "Số lượng";
            clsl.DataPropertyName = "soluong";
            dsmathang.Columns.Add(clsl);

            DataGridViewTextBoxColumn clkl = new DataGridViewTextBoxColumn();
            clkl.Name = "khoiluong";
            clkl.HeaderText = "Khối lượng";
            clkl.DataPropertyName = "khoiluong";
            dsmathang.Columns.Add(clkl);

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
            clMa.Name = "Mamh";
            clMa.HeaderText = "Mã mặt hàng";
            clMa.DataPropertyName = "Mamh";
            dsmathang.Columns.Add(clMa);

            DataGridViewTextBoxColumn clTen = new DataGridViewTextBoxColumn();
            clTen.Name = "tenmh";
            clTen.HeaderText = "Tên mặt hàng";
            clTen.DataPropertyName = "tenmh";
            dsmathang.Columns.Add(clTen);

            DataGridViewTextBoxColumn clsl = new DataGridViewTextBoxColumn();
            clsl.Name = "soluong";
            clsl.HeaderText = "Số lượng";
            clsl.DataPropertyName = "soluong";
            dsmathang.Columns.Add(clsl);

            DataGridViewTextBoxColumn clkl = new DataGridViewTextBoxColumn();
            clkl.Name = "khoiluong";
            clkl.HeaderText = "Khối lượng";
            clkl.DataPropertyName = "khoiluong";
            dsmathang.Columns.Add(clkl);

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

        }

        //XÓA CÁC Ô ĐIỀN DỮ LIỆU
        private void clear()
        {   
            ma.Text="";
            tmh.Text="";
            kl.Text="";
            sl.Text = "";
            hsd.Value = DateTime.Today;
            gia.Text = "";
            dvt.Text = "";
        }
        //RÀNG BUỘC CỦA DỮ LIỆU NHẬP VÀO
        bool testtext()//kiểm tra ô dữ liệu trống
        {

            if (string.IsNullOrWhiteSpace(ma.Text))
            {
                MessageBox.Show(ma, "Bạn chưa nhập mã mặt hàng.");
                ma.Focus();
                return false;
            }//ma
            if (string.IsNullOrWhiteSpace(tmh.Text))
            {
                MessageBox.Show(tmh, "Bạn chưa nhập tên mặt hàng.");
                tmh.Focus();
                return false;
            }//tên
            if (string.IsNullOrWhiteSpace(sl.Text))
            {
                MessageBox.Show(sl, "Bạn chưa nhập số lượng.");
                sl.Focus();
                return false;
            }//số lượng
            if (string.IsNullOrWhiteSpace(kl.Text))
            {
                MessageBox.Show(kl, "Bạn chưa nhập khối lượng.");
                kl.Focus();
                return false;
            }//khối lượng
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
                            bool kq = mhbus.Xoa(dl);
                            if (kq == false)
                                MessageBox.Show("Xóa mặt hàng thất bại. Vui lòng kiểm tra lại dũ liệu");
                            else
                            {
                                MessageBox.Show("Xóa mặt hàng thành công");
                                this.loadData_Vao_GridView();
                            }

                        }
                    }
                    this.loadData_Vao_GridView();
                }
            }
            loadData_Vao_GridView();
        }
        private void SửaMặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ' Get the current cell location.
            int currentRowIndex = dsmathang.CurrentCellAddress.Y;// 'current row selected


            //'Verify that indexing OK
            if (-1 < currentRowIndex && currentRowIndex < dsmathang.RowCount)
            {
                DanhsachmathangDTO mh = (DanhsachmathangDTO)dsmathang.Rows[currentRowIndex].DataBoundItem;
                bool kq = mhbus.Sua(mh);
                if (kq == false)
                    MessageBox.Show("Sửa mặt hàng thất bại. Vui lòng kiểm tra lại dữ liệu");
                else
                    MessageBox.Show("Sửa mặt hàng thành công");
            }
            this.loadData_Vao_GridView();
        }

        private void Dsmathang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ma.Text = dsmathang.CurrentRow.Cells[0].Value.ToString();
            tmh.Text = dsmathang.CurrentRow.Cells[1].Value.ToString();
            sl.Text = dsmathang.CurrentRow.Cells[2].Value.ToString();
            kl.Text = dsmathang.CurrentRow.Cells[3].Value.ToString();
            hsd.Value = Convert.ToDateTime(dsmathang.CurrentRow.Cells[4].Value.ToString());
            gia.Text = dsmathang.CurrentRow.Cells[5].Value.ToString();
            dvt.Text = dsmathang.CurrentRow.Cells[6].Value.ToString();
        }
    }
}
