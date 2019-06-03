namespace QLDL
{
    partial class QuanlyMatHangfrm
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
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tmh = new System.Windows.Forms.TextBox();
            this.gia = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dvt = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.hsd = new System.Windows.Forms.DateTimePicker();
            this.dsmathang = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xóaMặtHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sửaMặtHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.mamh = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dsmathang)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(240, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản lý mặt hàng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(344, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên mặt hàng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Hạn sử dụng";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(271, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Giá";
            // 
            // tmh
            // 
            this.tmh.Location = new System.Drawing.Point(446, 87);
            this.tmh.Name = "tmh";
            this.tmh.Size = new System.Drawing.Size(158, 22);
            this.tmh.TabIndex = 2;
            // 
            // gia
            // 
            this.gia.Location = new System.Drawing.Point(307, 152);
            this.gia.Name = "gia";
            this.gia.Size = new System.Drawing.Size(157, 22);
            this.gia.TabIndex = 4;
            this.gia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numOnly);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(472, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 17);
            this.label8.TabIndex = 13;
            this.label8.Text = "Đơn vị tính";
            // 
            // dvt
            // 
            this.dvt.Location = new System.Drawing.Point(553, 152);
            this.dvt.Name = "dvt";
            this.dvt.Size = new System.Drawing.Size(101, 22);
            this.dvt.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(196, 206);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 32);
            this.button1.TabIndex = 15;
            this.button1.Text = "Thêm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // hsd
            // 
            this.hsd.CustomFormat = "dd/MM/yyyy";
            this.hsd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.hsd.Location = new System.Drawing.Point(135, 150);
            this.hsd.Name = "hsd";
            this.hsd.Size = new System.Drawing.Size(133, 22);
            this.hsd.TabIndex = 3;
            // 
            // dsmathang
            // 
            this.dsmathang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dsmathang.ContextMenuStrip = this.contextMenuStrip1;
            this.dsmathang.Location = new System.Drawing.Point(6, 67);
            this.dsmathang.Name = "dsmathang";
            this.dsmathang.RowHeadersWidth = 51;
            this.dsmathang.RowTemplate.Height = 24;
            this.dsmathang.Size = new System.Drawing.Size(664, 275);
            this.dsmathang.TabIndex = 19;
            this.dsmathang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dsmathang_CellClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xóaMặtHàngToolStripMenuItem,
            this.sửaMặtHàngToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(172, 52);
            // 
            // xóaMặtHàngToolStripMenuItem
            // 
            this.xóaMặtHàngToolStripMenuItem.Name = "xóaMặtHàngToolStripMenuItem";
            this.xóaMặtHàngToolStripMenuItem.Size = new System.Drawing.Size(171, 24);
            this.xóaMặtHàngToolStripMenuItem.Text = "Xóa mặt hàng";
            this.xóaMặtHàngToolStripMenuItem.Click += new System.EventHandler(this.XóaMặtHàngToolStripMenuItem_Click);
            // 
            // sửaMặtHàngToolStripMenuItem
            // 
            this.sửaMặtHàngToolStripMenuItem.Name = "sửaMặtHàngToolStripMenuItem";
            this.sửaMặtHàngToolStripMenuItem.Size = new System.Drawing.Size(171, 24);
            this.sửaMặtHàngToolStripMenuItem.Text = "Sửa mặt hàng";
            this.sửaMặtHàngToolStripMenuItem.Click += new System.EventHandler(this.SửaMặtHàngToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.txtKeyword);
            this.groupBox1.Controls.Add(this.dsmathang);
            this.groupBox1.Location = new System.Drawing.Point(12, 244);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(676, 348);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách mặt hàng";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(391, 23);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(87, 30);
            this.button4.TabIndex = 21;
            this.button4.Text = "Search";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // txtKeyword
            // 
            this.txtKeyword.Location = new System.Drawing.Point(50, 27);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(324, 22);
            this.txtKeyword.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(396, 206);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 32);
            this.button2.TabIndex = 16;
            this.button2.Text = "Xóa";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(296, 206);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 32);
            this.button3.TabIndex = 17;
            this.button3.Text = "Sửa";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 17);
            this.label2.TabIndex = 21;
            this.label2.Text = "Mã mặt hàng";
            // 
            // mamh
            // 
            this.mamh.Location = new System.Drawing.Point(180, 87);
            this.mamh.Name = "mamh";
            this.mamh.Size = new System.Drawing.Size(158, 22);
            this.mamh.TabIndex = 1;
            this.mamh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numOnly);
            // 
            // QuanlyMatHangfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 604);
            this.Controls.Add(this.mamh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.hsd);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dvt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.gia);
            this.Controls.Add(this.tmh);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "QuanlyMatHangfrm";
            this.Text = "ThemXoaSuaMatHangfrm";
            this.Load += new System.EventHandler(this.ThemXoaSuaMatHangfrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsmathang)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tmh;
        private System.Windows.Forms.TextBox gia;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox dvt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker hsd;
        private System.Windows.Forms.DataGridView dsmathang;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem xóaMặtHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sửaMặtHàngToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox mamh;
    }
}