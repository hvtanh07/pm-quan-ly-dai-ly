namespace QLDL
{
    partial class PhieuThuTien
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Ngaythu = new System.Windows.Forms.DateTimePicker();
            this.tienthu = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.Dsphieuthu = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.madltxt = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.maptt = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sửaBảnGhiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xóaBảnGhiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dsphieuthu)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(263, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Phiếu thu tiền";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã đại lý";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(213, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ngày thu tiền";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(489, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Số tiền thu";
            // 
            // Ngaythu
            // 
            this.Ngaythu.CustomFormat = "dd/MM/yyyy";
            this.Ngaythu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Ngaythu.Location = new System.Drawing.Point(311, 93);
            this.Ngaythu.Name = "Ngaythu";
            this.Ngaythu.Size = new System.Drawing.Size(172, 22);
            this.Ngaythu.TabIndex = 5;
            // 
            // tienthu
            // 
            this.tienthu.Location = new System.Drawing.Point(571, 95);
            this.tienthu.Name = "tienthu";
            this.tienthu.Size = new System.Drawing.Size(100, 22);
            this.tienthu.TabIndex = 6;
            this.tienthu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numOnly);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtKeyword);
            this.groupBox1.Controls.Add(this.Dsphieuthu);
            this.groupBox1.Location = new System.Drawing.Point(12, 192);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(699, 346);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách phiếu thu tiền";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(427, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 29);
            this.button1.TabIndex = 9;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // txtKeyword
            // 
            this.txtKeyword.Location = new System.Drawing.Point(154, 36);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(253, 22);
            this.txtKeyword.TabIndex = 8;
            // 
            // Dsphieuthu
            // 
            this.Dsphieuthu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dsphieuthu.ContextMenuStrip = this.contextMenuStrip1;
            this.Dsphieuthu.Location = new System.Drawing.Point(6, 79);
            this.Dsphieuthu.Name = "Dsphieuthu";
            this.Dsphieuthu.RowHeadersWidth = 51;
            this.Dsphieuthu.RowTemplate.Height = 24;
            this.Dsphieuthu.Size = new System.Drawing.Size(687, 261);
            this.Dsphieuthu.TabIndex = 0;
            this.Dsphieuthu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dsphieuthu_CellClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(302, 149);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 37);
            this.button2.TabIndex = 10;
            this.button2.Text = "Hoàn tất";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // madltxt
            // 
            this.madltxt.FormattingEnabled = true;
            this.madltxt.Location = new System.Drawing.Point(107, 95);
            this.madltxt.Name = "madltxt";
            this.madltxt.Size = new System.Drawing.Size(100, 24);
            this.madltxt.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Mã phiếu thu";
            // 
            // maptt
            // 
            this.maptt.Location = new System.Drawing.Point(111, 19);
            this.maptt.Name = "maptt";
            this.maptt.Size = new System.Drawing.Size(100, 22);
            this.maptt.TabIndex = 13;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sửaBảnGhiToolStripMenuItem,
            this.xóaBảnGhiToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(159, 52);
            // 
            // sửaBảnGhiToolStripMenuItem
            // 
            this.sửaBảnGhiToolStripMenuItem.Name = "sửaBảnGhiToolStripMenuItem";
            this.sửaBảnGhiToolStripMenuItem.Size = new System.Drawing.Size(158, 24);
            this.sửaBảnGhiToolStripMenuItem.Text = "Sửa bản ghi";
            this.sửaBảnGhiToolStripMenuItem.Click += new System.EventHandler(this.SửaBảnGhiToolStripMenuItem_Click);
            // 
            // xóaBảnGhiToolStripMenuItem
            // 
            this.xóaBảnGhiToolStripMenuItem.Name = "xóaBảnGhiToolStripMenuItem";
            this.xóaBảnGhiToolStripMenuItem.Size = new System.Drawing.Size(158, 24);
            this.xóaBảnGhiToolStripMenuItem.Text = "Xóa bản ghi";
            this.xóaBảnGhiToolStripMenuItem.Click += new System.EventHandler(this.XóaBảnGhiToolStripMenuItem_Click);
            // 
            // PhieuThuTien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 550);
            this.Controls.Add(this.maptt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.madltxt);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tienthu);
            this.Controls.Add(this.Ngaythu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PhieuThuTien";
            this.Text = "PhieuThuTien";
            this.Load += new System.EventHandler(this.PhieuThuTien_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dsphieuthu)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker Ngaythu;
        private System.Windows.Forms.TextBox tienthu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView Dsphieuthu;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox madltxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox maptt;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sửaBảnGhiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xóaBảnGhiToolStripMenuItem;
    }
}