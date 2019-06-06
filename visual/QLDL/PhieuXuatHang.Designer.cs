namespace QLDL
{
    partial class PhieuXuatHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.thang = new System.Windows.Forms.Label();
            this.mamhtxt = new System.Windows.Forms.ComboBox();
            this.soluong = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.danhsachmh = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.maPhieu = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.madltxt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tongtientxt = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.danhsachmh)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(290, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Phiếu xuất hàng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(420, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tháng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã đại lý";
            // 
            // thang
            // 
            this.thang.AutoSize = true;
            this.thang.Location = new System.Drawing.Point(491, 60);
            this.thang.Name = "thang";
            this.thang.Size = new System.Drawing.Size(46, 17);
            this.thang.TabIndex = 3;
            this.thang.Text = "label4";
            // 
            // mamhtxt
            // 
            this.mamhtxt.FormattingEnabled = true;
            this.mamhtxt.Location = new System.Drawing.Point(166, 40);
            this.mamhtxt.Name = "mamhtxt";
            this.mamhtxt.Size = new System.Drawing.Size(188, 24);
            this.mamhtxt.TabIndex = 3;
            // 
            // soluong
            // 
            this.soluong.Location = new System.Drawing.Point(166, 79);
            this.soluong.Name = "soluong";
            this.soluong.Size = new System.Drawing.Size(188, 22);
            this.soluong.TabIndex = 4;
            this.soluong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numOnly);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(455, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 32);
            this.button1.TabIndex = 5;
            this.button1.Text = "Thêm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(603, 55);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(108, 32);
            this.button3.TabIndex = 7;
            this.button3.Text = "Sửa";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // danhsachmh
            // 
            this.danhsachmh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.danhsachmh.ContextMenuStrip = this.contextMenuStrip1;
            this.danhsachmh.Location = new System.Drawing.Point(6, 80);
            this.danhsachmh.Name = "danhsachmh";
            this.danhsachmh.RowHeadersWidth = 51;
            this.danhsachmh.RowTemplate.Height = 24;
            this.danhsachmh.Size = new System.Drawing.Size(764, 282);
            this.danhsachmh.TabIndex = 4;
            this.danhsachmh.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Danhsachmh_CellClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xóaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(105, 28);
            // 
            // xóaToolStripMenuItem
            // 
            this.xóaToolStripMenuItem.Name = "xóaToolStripMenuItem";
            this.xóaToolStripMenuItem.Size = new System.Drawing.Size(104, 24);
            this.xóaToolStripMenuItem.Text = "Xóa";
            this.xóaToolStripMenuItem.Click += new System.EventHandler(this.XóaToolStripMenuItem_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Mã mặt hàng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Số lượng";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.mamhtxt);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.soluong);
            this.groupBox1.Location = new System.Drawing.Point(13, 139);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(778, 128);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Quản lý các mặt hàng trong phiếu xuất";
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(635, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(158, 67);
            this.button4.TabIndex = 8;
            this.button4.Text = "Lưu phiếu";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(79, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Mã phiếu";
            // 
            // maPhieu
            // 
            this.maPhieu.Location = new System.Drawing.Point(167, 57);
            this.maPhieu.Name = "maPhieu";
            this.maPhieu.ReadOnly = true;
            this.maPhieu.Size = new System.Drawing.Size(120, 22);
            this.maPhieu.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.txtKeyword);
            this.groupBox2.Controls.Add(this.danhsachmh);
            this.groupBox2.Location = new System.Drawing.Point(15, 273);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 368);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách các mặt hàng trong phiếu xuất";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(468, 33);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(107, 32);
            this.button5.TabIndex = 8;
            this.button5.Text = "Search";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // txtKeyword
            // 
            this.txtKeyword.Location = new System.Drawing.Point(164, 38);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(290, 22);
            this.txtKeyword.TabIndex = 9;
            // 
            // madltxt
            // 
            this.madltxt.Location = new System.Drawing.Point(167, 98);
            this.madltxt.Name = "madltxt";
            this.madltxt.ReadOnly = true;
            this.madltxt.Size = new System.Drawing.Size(120, 22);
            this.madltxt.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(420, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "Tổng giá trị phiếu";
            // 
            // tongtientxt
            // 
            this.tongtientxt.AutoSize = true;
            this.tongtientxt.Location = new System.Drawing.Point(545, 101);
            this.tongtientxt.Name = "tongtientxt";
            this.tongtientxt.Size = new System.Drawing.Size(16, 17);
            this.tongtientxt.TabIndex = 11;
            this.tongtientxt.Text = "0";
            // 
            // PhieuXuatHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 653);
            this.Controls.Add(this.tongtientxt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.madltxt);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.maPhieu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.thang);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PhieuXuatHang";
            this.Text = "PhieuThuTien";
            this.Load += new System.EventHandler(this.PhieuXuatHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.danhsachmh)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox mamhtxt;
        private System.Windows.Forms.TextBox soluong;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView danhsachmh;
        private System.Windows.Forms.Label thang;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox maPhieu;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem xóaToolStripMenuItem;
        private System.Windows.Forms.TextBox madltxt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label tongtientxt;
    }
}