namespace QLDL
{
    partial class PhieuBaocaoDS
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
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.dsphieu = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xemThôngTinPhiếuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xóaPhiếuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Matxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsphieu)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(83, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Báo cáo doanh số";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(263, 91);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "Lập phiếu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.txtKeyword);
            this.groupBox1.Controls.Add(this.dsphieu);
            this.groupBox1.Location = new System.Drawing.Point(12, 168);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(407, 311);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách phiếu báo cáo";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(311, 31);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 32);
            this.button2.TabIndex = 2;
            this.button2.Text = "Search";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // txtKeyword
            // 
            this.txtKeyword.Location = new System.Drawing.Point(6, 36);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(299, 22);
            this.txtKeyword.TabIndex = 1;
            // 
            // dsphieu
            // 
            this.dsphieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dsphieu.ContextMenuStrip = this.contextMenuStrip1;
            this.dsphieu.Location = new System.Drawing.Point(6, 81);
            this.dsphieu.Name = "dsphieu";
            this.dsphieu.RowHeadersVisible = false;
            this.dsphieu.RowHeadersWidth = 51;
            this.dsphieu.RowTemplate.Height = 24;
            this.dsphieu.Size = new System.Drawing.Size(395, 224);
            this.dsphieu.TabIndex = 0;
            this.dsphieu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dsphieu_CellClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xemThôngTinPhiếuToolStripMenuItem,
            this.xóaPhiếuToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(214, 52);
            // 
            // xemThôngTinPhiếuToolStripMenuItem
            // 
            this.xemThôngTinPhiếuToolStripMenuItem.Name = "xemThôngTinPhiếuToolStripMenuItem";
            this.xemThôngTinPhiếuToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
            this.xemThôngTinPhiếuToolStripMenuItem.Text = "Xem thông tin phiếu";
            this.xemThôngTinPhiếuToolStripMenuItem.Click += new System.EventHandler(this.XemThôngTinPhiếuToolStripMenuItem_Click);
            // 
            // xóaPhiếuToolStripMenuItem
            // 
            this.xóaPhiếuToolStripMenuItem.Name = "xóaPhiếuToolStripMenuItem";
            this.xóaPhiếuToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
            this.xóaPhiếuToolStripMenuItem.Text = "Xóa phiếu";
            this.xóaPhiếuToolStripMenuItem.Click += new System.EventHandler(this.XóaPhiếuToolStripMenuItem_Click);
            // 
            // Matxt
            // 
            this.Matxt.Location = new System.Drawing.Point(140, 95);
            this.Matxt.Name = "Matxt";
            this.Matxt.Size = new System.Drawing.Size(117, 22);
            this.Matxt.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mã phiếu";
            // 
            // PhieuBaocaoDS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 491);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Matxt);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "PhieuBaocaoDS";
            this.Text = "PhieuBaocaoDT";
            this.Load += new System.EventHandler(this.PhieuBaocaoDS_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsphieu)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.DataGridView dsphieu;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem xemThôngTinPhiếuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xóaPhiếuToolStripMenuItem;
        private System.Windows.Forms.TextBox Matxt;
        private System.Windows.Forms.Label label2;
    }
}