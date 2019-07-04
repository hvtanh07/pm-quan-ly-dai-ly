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
    public partial class CapNhatSuaDaiLy : Form
    {
        private CHoSoDaiLyBUS hsBUS;
        public CapNhatSuaDaiLy()
        {
            InitializeComponent();
        }
        private void CapNhatSuaDaiLy_Load(object sender, EventArgs e)
        {
            hsBUS = new CHoSoDaiLyBUS();
            this.loadData_Vao_GridView();
        }
        private void loadData_Vao_GridView()
        {
            List<CHoSoDaiLyDTO> listHoSoDaiLy= hsBUS.select();

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

            DataGridViewTextBoxColumn cldc = new DataGridViewTextBoxColumn();
            cldc.Name = "diachi";
            cldc.HeaderText = "Địa chỉ";
            cldc.DataPropertyName = "diachi";
            dgvBangDanhSach.Columns.Add(cldc);

            DataGridViewTextBoxColumn cldc = new DataGridViewTextBoxColumn();
            cldc.Name = "diachi";
            cldc.HeaderText = "Địa chỉ";
            cldc.DataPropertyName = "diachi";
            dgvBangDanhSach.Columns.Add(cldc);

            DataGridViewTextBoxColumn cldc = new DataGridViewTextBoxColumn();
            cldc.Name = "diachi";
            cldc.HeaderText = "Địa chỉ";
            cldc.DataPropertyName = "diachi";
            dgvBangDanhSach.Columns.Add(cldc);

            DataGridViewTextBoxColumn cldc = new DataGridViewTextBoxColumn();
            cldc.Name = "diachi";
            cldc.HeaderText = "Địa chỉ";
            cldc.DataPropertyName = "diachi";
            dgvBangDanhSach.Columns.Add(cldc);

            DataGridViewTextBoxColumn cldc = new DataGridViewTextBoxColumn();
            cldc.Name = "diachi";
            cldc.HeaderText = "Địa chỉ";
            cldc.DataPropertyName = "diachi";
            dgvBangDanhSach.Columns.Add(cldc);

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dgvBangDanhSach.DataSource];
            myCurrencyManager.Refresh();
            autosize();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (!testtext())
            {
                return;
            }
            CHoSoDaiLyDTO hs = new CHoSoDaiLyDTO();
            hs.madl = int.Parse(matxt.Text);
            hs.quan = quantxt.Text;
            hs.dientich = int.Parse(dt.Text);
            hs.sonhanvien = int.Parse(snv.Text);
            hs.tendaily = tentxt.Text;
            hs.diachi = dc.Text;
            hs.email = mail.Text;
            hs.dienthoai = dttxt.Text;
            if (checkBox1.Checked == true)
            {
                hs.loaidaily = 1;
            }
            else if (checkBox2.Checked == true)
            {
                hs.loaidaily = 2;
            }
            else
            {
                hs.loaidaily = 1;
            }

            //2. Kiểm tra data hợp lệ or not
            //kiểm tra trong quận đã đạt tối đa số đại lý chưa
            
            //3. Thêm vào DB
            bool kq = hsBUS.Sua(hs);
            if (kq == false)
                MessageBox.Show("Cập nhật hồ sơ thất bại. Vui lòng kiểm tra lại dũ liệu");
            else
            {
                MessageBox.Show("Cập nhật hồ sơ thành công");
                clear();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(matxt.Text))
            {
                MessageBox.Show("Xóa hồ sơ thất bại.Chưa nhập mã đại lý cần xóa");
                return;
            }
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn xóa đại lý này không ?", "Xóa thông tin", MessageBoxButtons.YesNo);
            if (dlr == DialogResult.Yes)
            {               
                CHoSoDaiLyDTO hs = new CHoSoDaiLyDTO();
                hs.madl = int.Parse(matxt.Text);
                bool kq = hsBUS.Xoa(hs);
                if (kq == false)
                    MessageBox.Show("Xóa hồ sơ thất bại. Vui lòng kiểm tra lại dũ liệu");
                else
                {
                    MessageBox.Show("Xóa hồ sơ thành công");
                    clear();
                }
            }
        }
        private void autosize()
        {
            for (int i = 0; i < dgvBangDanhSach.Columns.Count; i++)
            {
                dgvBangDanhSach.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }
        private void clear()
        {
            matxt.Text = "";
            quantxt.Text = "";
            dt.Text = "";
            snv.Text = "";
            tentxt.Text = "";
            dc.Text = "";
            mail.Text = "";
            dttxt.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
        }

        //RÀNG BUỘC CỦA DỮ LIỆU NHẬP VÀO
        private void numOnly(object sender, KeyPressEventArgs e)//chỉ cho nhập số
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

            if (string.IsNullOrWhiteSpace(tentxt.Text))
            {
                MessageBox.Show(tentxt, "Bạn chưa nhập tên đại lý.");
                tentxt.Focus();
                return false;
            }//ten
            if (string.IsNullOrWhiteSpace(dc.Text))
            {
                MessageBox.Show(dc, "Bạn chưa nhập địa chỉ.");
                dc.Focus();
                return false;
            }//dia chi
            if (string.IsNullOrWhiteSpace(dt.Text))
            {
                MessageBox.Show(dt, "Bạn chưa nhập diện tích.");
                dt.Focus();
                return false;
            }//dien tich
            if (string.IsNullOrWhiteSpace(snv.Text))
            {
                MessageBox.Show(snv, "Bạn chưa nhập số nhân viên.");
                snv.Focus();
                return false;
            }//so nhan vien
            if (string.IsNullOrWhiteSpace(quantxt.Text))//quan
            {
                MessageBox.Show(quantxt, "Bạn chưa nhập địa chỉ quận.");
                quantxt.Focus();
                return false;
            }//quan      
            if (string.IsNullOrWhiteSpace(dttxt.Text))
            {
                MessageBox.Show(dttxt, "Bạn chưa nhập số điện thoại.");
                dttxt.Focus();
                return false;
            }//dien thoai
            if (string.IsNullOrWhiteSpace(mail.Text))
            {
                MessageBox.Show(mail, "Bạn chưa nhập Email.");
                mail.Focus();
                return false;
            }//mail
            else
            {
                try
                {
                    var eMailValidator = new System.Net.Mail.MailAddress(mail.Text);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(mail, "Email Không hợp lệ");
                    mail.Text = "";
                    mail.Focus();
                    return false;
                }


                //string match = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
                //Regex reg = new Regex(match);
                //if (!reg.IsMatch(mail.Text))
                //{
                //    MessageBox.Show(mail, "Email Không hợp lệ");
                //    mail.Text = "";
                //    mail.Focus();
                //    return false;
                //}
            }//email valid or not

            return true;//all true then gud to go
        }

    }
}
