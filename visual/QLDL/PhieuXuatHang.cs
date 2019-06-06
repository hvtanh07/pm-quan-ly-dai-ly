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
    public partial class PhieuXuatHang : Form
    {
        int tongtien = 0;
        private CMatHangBUS mhBUS;
        private PhieuxuathangBUS pxhBUS;
        private ChitietphieuxuatBUS ctpxBUS;
        private PhieuxuathangDTO pxhDTO;
        public PhieuXuatHang()
        {
            InitializeComponent();
        }            
        public PhieuXuatHang(PhieuxuathangDTO xh)
        {
            pxhBUS = new PhieuxuathangBUS();
            ctpxBUS = new ChitietphieuxuatBUS();            
            mhBUS = new CMatHangBUS();
            pxhDTO = xh;
            InitializeComponent();
        }
        private void PhieuXuatHang_Load(object sender, EventArgs e)
        {
            if (pxhDTO != null)
            {
                maPhieu.Text = pxhDTO.maxh;
                madltxt.Text = pxhDTO.madl;
                thang.Text = pxhDTO.ngaylap.Month.ToString();
                Taodatasource();
            }
            loadData_Vao_GridView();
            capnhattien();
        }
        private void autosize()
        {
            for (int i = 0; i < danhsachmh.Columns.Count; i++)
            {
                danhsachmh.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
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
            if (string.IsNullOrWhiteSpace(soluong.Text))
            {
                MessageBox.Show(soluong, "Bạn chưa nhập số lượng mặt hàng.");
                soluong.Focus();
                return false;
            }
            return true;//all true then gud to go
        }
        
        //lấy datasouce cho comboox
        private void Taodatasource()
        {            
            List<string> mamh = new List<string>();
            mamh = mhBUS.Laymamh();
            mamhtxt.DataSource = mamh;
        }
        private void loadData_Vao_GridView()
        {
            List<ChitietphieuxuatDTO> listctpx = ctpxBUS.select(maPhieu.Text);

            if (listctpx == null)
            {
                MessageBox.Show("Có lỗi khi lấy hồ sơ từ DB");
                return;
            }

            danhsachmh.Columns.Clear();
            danhsachmh.DataSource = null;

            danhsachmh.AutoGenerateColumns = false;
            danhsachmh.AllowUserToAddRows = false;
            danhsachmh.DataSource = listctpx;

            DataGridViewTextBoxColumn clMa = new DataGridViewTextBoxColumn();
            clMa.Name = "mamh";
            clMa.HeaderText = "Mã mặt hàng";
            clMa.DataPropertyName = "mamh";
            danhsachmh.Columns.Add(clMa);

            DataGridViewTextBoxColumn clTen = new DataGridViewTextBoxColumn();
            clTen.Name = "soluong";
            clTen.HeaderText = "Số lượng";
            clTen.DataPropertyName = "soluong";
            danhsachmh.Columns.Add(clTen);

            DataGridViewTextBoxColumn clhsd = new DataGridViewTextBoxColumn();
            clhsd.Name = "tongtien";
            clhsd.HeaderText = "Tổng trị giá lượng hàng";
            clhsd.DataPropertyName = "tongtien";
            danhsachmh.Columns.Add(clhsd);

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[danhsachmh.DataSource];
            myCurrencyManager.Refresh();
            autosize();
        }
        private void loadData_Vao_GridView(List<ChitietphieuxuatDTO> listctpx)
        {
            if (listctpx == null)
            {
                MessageBox.Show("Có lỗi khi lấy hồ sơ từ DB");
                return;
            }

            danhsachmh.Columns.Clear();
            danhsachmh.DataSource = null;

            danhsachmh.AutoGenerateColumns = false;
            danhsachmh.AllowUserToAddRows = false;
            danhsachmh.DataSource = listctpx;

            DataGridViewTextBoxColumn clMa = new DataGridViewTextBoxColumn();
            clMa.Name = "maMatHang";
            clMa.HeaderText = "Mã mặt hàng";
            clMa.DataPropertyName = "maMatHang";
            danhsachmh.Columns.Add(clMa);

            DataGridViewTextBoxColumn clTen = new DataGridViewTextBoxColumn();
            clTen.Name = "soluong";
            clTen.HeaderText = "Số lượng";
            clTen.DataPropertyName = "soluong";
            danhsachmh.Columns.Add(clTen);

            DataGridViewTextBoxColumn clhsd = new DataGridViewTextBoxColumn();
            clhsd.Name = "tongtien";
            clhsd.HeaderText = "Tổng trị giá lượng hàng";
            clhsd.DataPropertyName = "tongtien";
            danhsachmh.Columns.Add(clhsd);

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[danhsachmh.DataSource];
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
            ChitietphieuxuatDTO ctpx = new ChitietphieuxuatDTO();
            ctpx.maxh = maPhieu.Text;
            ctpx.mamh = mamhtxt.Text;
            ctpx.soluong = int.Parse(soluong.Text);
            ctpx.tongtien = int.Parse(soluong.Text) * mhBUS.Laygiatienmh(mamhtxt.Text);
            //2. Kiểm tra data hợp lệ or not

            //3. Thêm vào DB
            bool kq = ctpxBUS.Them(ctpx);
            if (kq == false)
                MessageBox.Show("Thêm mặt hàng thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                MessageBox.Show("Thêm mặt hàng thành công");
            }
            loadData_Vao_GridView();
            capnhattien();
        }
        //sua
        private void Button3_Click(object sender, EventArgs e)
        {
            if (!testtext())
            {
                return;
            }
            ChitietphieuxuatDTO ctpx = new ChitietphieuxuatDTO();
            ctpx.maxh = maPhieu.Text;
            ctpx.mamh = mamhtxt.Text;
            ctpx.soluong = int.Parse(soluong.Text);
            ctpx.tongtien = int.Parse(soluong.Text) * mhBUS.Laygiatienmh(mamhtxt.Text);
            //2. Kiểm tra data hợp lệ or not

            //3. Thêm vào DB
            bool kq = ctpxBUS.Sua(ctpx);
            if (kq == false)
                MessageBox.Show("Sửa mặt hàng thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                MessageBox.Show("Sửa mặt hàng thành công");
            }
            loadData_Vao_GridView();
            capnhattien();
        }
        //xoa
        private void XóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn xóa mặt hàng này không ?", "Xóa thông tin", MessageBoxButtons.YesNo);
            if (dlr == DialogResult.Yes)
            {
                int currentRowIndex = danhsachmh.CurrentCellAddress.Y;
                if (-1 < currentRowIndex && currentRowIndex < danhsachmh.RowCount)
                {
                    ChitietphieuxuatDTO ctpxc = (ChitietphieuxuatDTO)danhsachmh.Rows[currentRowIndex].DataBoundItem;
                    ctpxc.maxh = maPhieu.Text;
                    if (ctpxc != null)
                    {
                        bool kq = ctpxBUS.Xoa(ctpxc);
                        if (kq == false)
                            MessageBox.Show("Xóa mặt hàng thất bại. Vui lòng kiểm tra lại dũ liệu");
                        else
                        {
                            MessageBox.Show("Xóa mặt hàng thành công");
                            this.loadData_Vao_GridView();
                            capnhattien();
                        }

                    }
                }
            }
        }
        //search
        private void Button5_Click(object sender, EventArgs e)
        {
            string sKeyword = txtKeyword.Text.Trim();
            if (sKeyword == null || sKeyword == string.Empty || sKeyword.Length == 0) // tìm tất cả
            {
                List<ChitietphieuxuatDTO> listctpx = ctpxBUS.select(maPhieu.Text);
                this.loadData_Vao_GridView(listctpx);
            }
            else
            {
                List<ChitietphieuxuatDTO> listctpx = ctpxBUS.selectByKeyWord(sKeyword, maPhieu.Text);
                this.loadData_Vao_GridView(listctpx);
            }
        }      
        private void capnhattien()
        {
            tongtien = 0;
            foreach (DataGridViewRow row in danhsachmh.Rows)
            {
                tongtien += int.Parse(row.Cells[2].Value.ToString());
            }
            tongtientxt.Text = tongtien.ToString();
        }
        //hoan tat phieu xuat hang
        private void Button4_Click(object sender, EventArgs e)
        {           
            PhieuxuathangDTO px = new PhieuxuathangDTO();
            px.maxh = maPhieu.Text;
            px.tongtien = tongtien;
            //2. Kiểm tra data hợp lệ or not

            //3. Thêm vào DB
            bool kq = pxhBUS.Sua(px);
            if (kq == false)
                MessageBox.Show("Lưu thông tin phiếu thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                MessageBox.Show("Lưu thông tin phiếu thành công");
                this.Close();
            }
        }
        private void Danhsachmh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            mamhtxt.Text = danhsachmh.CurrentRow.Cells[0].Value.ToString();
            soluong.Text = danhsachmh.CurrentRow.Cells[1].Value.ToString();
        }
    }
}

