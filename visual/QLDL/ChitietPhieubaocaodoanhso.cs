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
    public partial class ChitietPhieubaocaodoanhso : Form
    {
        ChitietphieubcdtBUS ctbcdtBUS;
        PhieubaocaodtBUS bcdtBUS;
        PhieubaocaodtDTO bcdtDTO;
        bool xemornot;
        int tongtien;
        public ChitietPhieubaocaodoanhso()
        {
            InitializeComponent();
        }
        public ChitietPhieubaocaodoanhso(PhieubaocaodtDTO dt, bool xem)
        {
            ctbcdtBUS = new ChitietphieubcdtBUS();
            bcdtBUS = new PhieubaocaodtBUS();
            bcdtDTO = dt;
            xemornot = xem;
            InitializeComponent();
        }        
        private void ChitietPhieubaocaodoanhso_Load(object sender, EventArgs e)
        {
            if (bcdtDTO != null)
            {
                Matxt.Text = bcdtDTO.madt;
                thang.Text = bcdtDTO.ngaylap.Month.ToString();
            }
            if (xemornot)
            {
                tongtientxt.Text = bcdtDTO.tongdt.ToString();
                loadData_Vao_GridViewXem();
                button1.Enabled = false;
            }
            else
            {
                loadData_Vao_GridView();
                capnhattien();
                laptyle();
                button2.Enabled = false;
            }            
        }
        private void loadData_Vao_GridView()
        {
            List<ChitietphieubcdtDTO> listctpx = ctbcdtBUS.laydoanhthu(thang.Text);

            if (listctpx == null)
            {
                MessageBox.Show("Có lỗi khi lấy hồ sơ từ DB");
                return;
            }

            dsDL.Columns.Clear();
            dsDL.DataSource = null;

            dsDL.AutoGenerateColumns = false;
            dsDL.AllowUserToAddRows = false;
            dsDL.DataSource = listctpx;

            DataGridViewTextBoxColumn clMa = new DataGridViewTextBoxColumn();
            clMa.Name = "MaDL";
            clMa.HeaderText = "Mã đại lý";
            clMa.DataPropertyName = "MaDL";
            dsDL.Columns.Add(clMa);

            DataGridViewTextBoxColumn clTen = new DataGridViewTextBoxColumn();
            clTen.Name = "TongDT";
            clTen.HeaderText = "Tổng daonh thu";
            clTen.DataPropertyName = "TongDT";
            dsDL.Columns.Add(clTen);

            DataGridViewTextBoxColumn clhsd = new DataGridViewTextBoxColumn();
            clhsd.Name = "sophieuxuat";
            clhsd.HeaderText = "Số phiếu xuất";
            clhsd.DataPropertyName = "sophieuxuat";
            dsDL.Columns.Add(clhsd);

            DataGridViewTextBoxColumn tyle = new DataGridViewTextBoxColumn();
            tyle.Name = "Tyle";
            tyle.HeaderText = "Tỷ lệ";
            tyle.DataPropertyName = "Tyle";
            dsDL.Columns.Add(tyle);

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dsDL.DataSource];
            myCurrencyManager.Refresh();
            
        }
        private void laptyle()
        {
            foreach (DataGridViewRow row in dsDL.Rows)
            {
                row.Cells[3].Value = (float.Parse(row.Cells[1].Value.ToString()) / tongtien) * 100;
            }
        }
        private void loadData_Vao_GridViewXem()
        {
            List<ChitietphieubcdtDTO> listctpx = ctbcdtBUS.select(Matxt.Text);

            if (listctpx == null)
            {
                MessageBox.Show("Có lỗi khi lấy hồ sơ từ DB");
                return;
            }

            dsDL.Columns.Clear();
            dsDL.DataSource = null;

            dsDL.AutoGenerateColumns = false;
            dsDL.AllowUserToAddRows = false;
            dsDL.DataSource = listctpx;

            DataGridViewTextBoxColumn clMa = new DataGridViewTextBoxColumn();
            clMa.Name = "MaDL";
            clMa.HeaderText = "Mã đại lý";
            clMa.DataPropertyName = "MaDL";
            dsDL.Columns.Add(clMa);

            DataGridViewTextBoxColumn clTen = new DataGridViewTextBoxColumn();
            clTen.Name = "TongDT";
            clTen.HeaderText = "Tổng daonh thu";
            clTen.DataPropertyName = "TongDT";
            dsDL.Columns.Add(clTen);

            DataGridViewTextBoxColumn clhsd = new DataGridViewTextBoxColumn();
            clhsd.Name = "sophieuxuat";
            clhsd.HeaderText = "Số phiếu xuất";
            clhsd.DataPropertyName = "sophieuxuat";
            dsDL.Columns.Add(clhsd);

            DataGridViewTextBoxColumn tyle = new DataGridViewTextBoxColumn();
            tyle.Name = "Tyle";
            tyle.HeaderText = "Tỷ lệ";
            tyle.DataPropertyName = "Tyle";
            dsDL.Columns.Add(tyle);

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dsDL.DataSource];
            myCurrencyManager.Refresh();
        }
        private void loadData_Vao_GridView(List<ChitietphieubcdtDTO> listctpx)
        {
            if (listctpx == null)
            {
                MessageBox.Show("Có lỗi khi lấy hồ sơ từ DB");
                return;
            }

            dsDL.Columns.Clear();
            dsDL.DataSource = null;

            dsDL.AutoGenerateColumns = false;
            dsDL.AllowUserToAddRows = false;
            dsDL.DataSource = listctpx;

            DataGridViewTextBoxColumn clMa = new DataGridViewTextBoxColumn();
            clMa.Name = "MaDL";
            clMa.HeaderText = "Mã đại lý";
            clMa.DataPropertyName = "MaDL";
            dsDL.Columns.Add(clMa);

            DataGridViewTextBoxColumn clTen = new DataGridViewTextBoxColumn();
            clTen.Name = "TongDT";
            clTen.HeaderText = "Tổng daonh thu";
            clTen.DataPropertyName = "TongDT";
            dsDL.Columns.Add(clTen);

            DataGridViewTextBoxColumn clhsd = new DataGridViewTextBoxColumn();
            clhsd.Name = "sophieuxuat";
            clhsd.HeaderText = "Số phiếu xuất";
            clhsd.DataPropertyName = "sophieuxuat";
            dsDL.Columns.Add(clhsd);

            DataGridViewTextBoxColumn tyle = new DataGridViewTextBoxColumn();
            tyle.Name = "Tyle";
            tyle.HeaderText = "Tỷ lệ";
            tyle.DataPropertyName = "Tyle";
            dsDL.Columns.Add(tyle);

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dsDL.DataSource];
            myCurrencyManager.Refresh();           
        }
        private void capnhattien()
        {
            tongtien = 0;
            foreach (DataGridViewRow row in dsDL.Rows)
            {
                tongtien += int.Parse(row.Cells[1].Value.ToString());
            }
            tongtientxt.Text = tongtien.ToString();
        }
        //xac nhan phieu
        private void Button1_Click(object sender, EventArgs e)
        {            
            foreach (DataGridViewRow row in dsDL.Rows)
            {
                ChitietphieubcdtDTO bcdt = new ChitietphieubcdtDTO();
                bcdt.madt = Matxt.Text;
                bcdt.madl = row.Cells[0].Value.ToString();
                bcdt.sophieuxuat = int.Parse(row.Cells[2].Value.ToString());
                bcdt.tongdt = int.Parse(row.Cells[1].Value.ToString());
                bcdt.tyle = float.Parse(row.Cells[3].Value.ToString());
                ctbcdtBUS.Them(bcdt);
            }
            PhieubaocaodtDTO bcds = new PhieubaocaodtDTO();
            bcds.madt = bcdtDTO.madt;
            bcds.tongdt = tongtien;
            bool kq = bcdtBUS.Sua(bcds);
            if (kq == false)
                MessageBox.Show("Lưu thông tin phiếu thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                MessageBox.Show("Lưu thông tin phiếu thành công");
                this.Close();
            }
        }
        //search
        private void Button2_Click(object sender, EventArgs e)
        {
            string sKeyword = txtKeyword.Text.Trim();
            if (sKeyword == null || sKeyword == string.Empty || sKeyword.Length == 0) // tìm tất cả
            {
                List<ChitietphieubcdtDTO> listctpx = ctbcdtBUS.select(Matxt.Text);
                this.loadData_Vao_GridView(listctpx);
            }
            else
            {
                List<ChitietphieubcdtDTO> listctpx = ctbcdtBUS.selectByKeyWord(sKeyword, Matxt.Text);
                this.loadData_Vao_GridView(listctpx);
            }
        }
    }
}
