namespace QLDL
{
    partial class LapPhieuXuatHang
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
            this.maPhieu = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.madltxt = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dsphieuxh = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xóaBảnGhiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sửaBảnGhiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.thang = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dsphieuxh)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // maPhieu
            // 
            this.maPhieu.Location = new System.Drawing.Point(184, 75);
            this.maPhieu.Name = "maPhieu";
            this.maPhieu.Size = new System.Drawing.Size(162, 22);
            this.maPhieu.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-90, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Mã phiếu";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(430, 114);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(102, 32);
            this.button4.TabIndex = 16;
            this.button4.Text = "Lập phiếu";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(83, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Tháng";
            // 
            // madltxt
            // 
            this.madltxt.FormattingEnabled = true;
            this.madltxt.Location = new System.Drawing.Point(184, 119);
            this.madltxt.Name = "madltxt";
            this.madltxt.Size = new System.Drawing.Size(112, 24);
            this.madltxt.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Mã đại lý";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(211, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 32);
            this.label1.TabIndex = 10;
            this.label1.Text = "Phiếu xuất hàng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(81, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "Mã phiếu";
            // 
            // dsphieuxh
            // 
            this.dsphieuxh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dsphieuxh.ContextMenuStrip = this.contextMenuStrip1;
            this.dsphieuxh.Location = new System.Drawing.Point(6, 21);
            this.dsphieuxh.Name = "dsphieuxh";
            this.dsphieuxh.RowHeadersWidth = 51;
            this.dsphieuxh.RowTemplate.Height = 24;
            this.dsphieuxh.Size = new System.Drawing.Size(618, 204);
            this.dsphieuxh.TabIndex = 18;
            this.dsphieuxh.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dsphieuxh_CellClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xóaBảnGhiToolStripMenuItem,
            this.sửaBảnGhiToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(159, 52);
            // 
            // xóaBảnGhiToolStripMenuItem
            // 
            this.xóaBảnGhiToolStripMenuItem.Name = "xóaBảnGhiToolStripMenuItem";
            this.xóaBảnGhiToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.xóaBảnGhiToolStripMenuItem.Text = "Xóa bản ghi";
            this.xóaBảnGhiToolStripMenuItem.Click += new System.EventHandler(this.XóaBảnGhiToolStripMenuItem_Click);
            // 
            // sửaBảnGhiToolStripMenuItem
            // 
            this.sửaBảnGhiToolStripMenuItem.Name = "sửaBảnGhiToolStripMenuItem";
            this.sửaBảnGhiToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.sửaBảnGhiToolStripMenuItem.Text = "Sửa bản ghi";
            this.sửaBảnGhiToolStripMenuItem.Click += new System.EventHandler(this.SửaBảnGhiToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dsphieuxh);
            this.groupBox1.Location = new System.Drawing.Point(12, 304);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(630, 231);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách phiếu xuất hàng";
            // 
            // txtKeyword
            // 
            this.txtKeyword.Location = new System.Drawing.Point(95, 247);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(283, 22);
            this.txtKeyword.TabIndex = 20;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(404, 242);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 32);
            this.button1.TabIndex = 21;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // thang
            // 
            this.thang.Location = new System.Drawing.Point(184, 168);
            this.thang.Name = "thang";
            this.thang.Size = new System.Drawing.Size(90, 22);
            this.thang.TabIndex = 23;
            // 
            // LapPhieuXuatHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 547);
            this.Controls.Add(this.thang);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtKeyword);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.maPhieu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.madltxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "LapPhieuXuatHang";
            this.Text = "LapPhieuXuatHang";
            this.Load += new System.EventHandler(this.LapPhieuXuatHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsphieuxh)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox maPhieu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox madltxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dsphieuxh;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem xóaBảnGhiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sửaBảnGhiToolStripMenuItem;
        private System.Windows.Forms.TextBox thang;
    }
}