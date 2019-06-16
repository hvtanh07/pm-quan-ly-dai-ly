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
    public partial class CTPhieuBaoCaoCongNo : Form
    {
        ChitietphieubcnoBUS ctbcnoBUS;
        PhieubaocaonoBUS bcnoBUS;
        PhieubaocaonoDTO bcnoDTO;
        NoThangtruocBUS nottBUS;
        bool xemornot;
        public CTPhieuBaoCaoCongNo()
        {
            InitializeComponent();
        }
        public CTPhieuBaoCaoCongNo(PhieubaocaonoDTO dt, bool xem)
        {
            ctbcnoBUS = new ChitietphieubcnoBUS();
            bcnoBUS = new PhieubaocaonoBUS();
            nottBUS = new NoThangtruocBUS();
            bcnoDTO = dt;
            xemornot = xem;
            InitializeComponent();
        }

        private void CTPhieuBaoCaoCongNo_Load(object sender, EventArgs e)
        {
            if (bcnoDTO != null)
            {
                Matxt.Text = bcnoDTO.mano;
                thang.Text = bcnoDTO.ngaylap.Month.ToString();
            }
            if (xemornot)
            {
                loadData_Vao_GridViewXem();
                button1.Enabled = false;
            }
            else
            {
                loadData_Vao_GridView();
                button2.Enabled = false;
            }
        }
        private void loadData_Vao_GridView()
        {
            List<ChitietphieubcnoDTO> listctpx = ctbcnoBUS.layno();

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
            clTen.Name = "nodau";
            clTen.HeaderText = "Nợ đầu kỳ";
            clTen.DataPropertyName = "nodau";
            dsDL.Columns.Add(clTen);

            DataGridViewTextBoxColumn clhsd = new DataGridViewTextBoxColumn();
            clhsd.Name = "nocuoi";
            clhsd.HeaderText = "Nợ cuối kỳ";
            clhsd.DataPropertyName = "nocuoi";
            dsDL.Columns.Add(clhsd);

            DataGridViewTextBoxColumn tyle = new DataGridViewTextBoxColumn();
            tyle.Name = "Phatsinh";
            tyle.HeaderText = "Phát sinh";
            tyle.DataPropertyName = "Phatsinh";
            dsDL.Columns.Add(tyle);

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dsDL.DataSource];
            myCurrencyManager.Refresh();

        }
        private void loadData_Vao_GridViewXem()
        {
            List<ChitietphieubcnoDTO> listctpx = ctbcnoBUS.select(Matxt.Text);

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
            clTen.Name = "nodau";
            clTen.HeaderText = "Nợ đầu kỳ";
            clTen.DataPropertyName = "nodau";
            dsDL.Columns.Add(clTen);

            DataGridViewTextBoxColumn clhsd = new DataGridViewTextBoxColumn();
            clhsd.Name = "nocuoi";
            clhsd.HeaderText = "Nợ cuối kỳ";
            clhsd.DataPropertyName = "nocuoi";
            dsDL.Columns.Add(clhsd);

            DataGridViewTextBoxColumn tyle = new DataGridViewTextBoxColumn();
            tyle.Name = "Phatsinh";
            tyle.HeaderText = "Phát sinh";
            tyle.DataPropertyName = "Phatsinh";
            dsDL.Columns.Add(tyle);

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dsDL.DataSource];
            myCurrencyManager.Refresh();
        }
        private void loadData_Vao_GridView(List<ChitietphieubcnoDTO> listctpx)
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
            clTen.Name = "nodau";
            clTen.HeaderText = "Nợ đầu kỳ";
            clTen.DataPropertyName = "nodau";
            dsDL.Columns.Add(clTen);

            DataGridViewTextBoxColumn clhsd = new DataGridViewTextBoxColumn();
            clhsd.Name = "nocuoi";
            clhsd.HeaderText = "Nợ cuối kỳ";
            clhsd.DataPropertyName = "nocuoi";
            dsDL.Columns.Add(clhsd);

            DataGridViewTextBoxColumn tyle = new DataGridViewTextBoxColumn();
            tyle.Name = "Phatsinh";
            tyle.HeaderText = "Phát sinh";
            tyle.DataPropertyName = "Phatsinh";
            dsDL.Columns.Add(tyle);

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dsDL.DataSource];
            myCurrencyManager.Refresh();
        }
        //xac nhan
        private void Button1_Click(object sender, EventArgs e)
        {
            bool check = true;
            foreach (DataGridViewRow row in dsDL.Rows)
            {
                ChitietphieubcnoDTO bcdt = new ChitietphieubcnoDTO();
                bcdt.mano = Matxt.Text;
                bcdt.madl = row.Cells[0].Value.ToString();
                bcdt.nodau = int.Parse(row.Cells[1].Value.ToString());
                bcdt.nocuoi = int.Parse(row.Cells[2].Value.ToString());
                bcdt.phatsinh = int.Parse(row.Cells[3].Value.ToString());
                check = ctbcnoBUS.Them(bcdt);                
            }
            if (check == false)
                MessageBox.Show("Lưu thông tin phiếu thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                MessageBox.Show("Lưu thông tin phiếu thành công, Thông tin nợ kỳ trước đã được cập nhật");
                this.Close();
                foreach (DataGridViewRow row in dsDL.Rows)
                {
                    NoThangtruocDTO ntt = new NoThangtruocDTO();
                    ntt.madl = row.Cells[0].Value.ToString();
                    ntt.nothangtruoc = int.Parse(row.Cells[2].Value.ToString());
                    nottBUS.Sua(ntt);
                }
            }
        }
        //search
        private void Button2_Click(object sender, EventArgs e)
        {
            string sKeyword = txtKeyword.Text.Trim();
            if (sKeyword == null || sKeyword == string.Empty || sKeyword.Length == 0) // tìm tất cả
            {
                List<ChitietphieubcnoDTO> listctpx = ctbcnoBUS.select(Matxt.Text);
                this.loadData_Vao_GridView(listctpx);
            }
            else
            {
                List<ChitietphieubcnoDTO> listctpx = ctbcnoBUS.selectByKeyWord(sKeyword, Matxt.Text);
                this.loadData_Vao_GridView(listctpx);
            }
        }

      
    }
}
