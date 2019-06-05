namespace QLDL
{
    partial class QuanlyDaily
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
            this.dgvBangDanhSach = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sửaĐạiLýToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xóaĐạiLýToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangDanhSach)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvBangDanhSach
            // 
            this.dgvBangDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBangDanhSach.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvBangDanhSach.Location = new System.Drawing.Point(6, 21);
            this.dgvBangDanhSach.Name = "dgvBangDanhSach";
            this.dgvBangDanhSach.RowHeadersVisible = false;
            this.dgvBangDanhSach.RowHeadersWidth = 51;
            this.dgvBangDanhSach.RowTemplate.Height = 24;
            this.dgvBangDanhSach.Size = new System.Drawing.Size(855, 390);
            this.dgvBangDanhSach.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sửaĐạiLýToolStripMenuItem,
            this.xóaĐạiLýToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(145, 52);
            // 
            // sửaĐạiLýToolStripMenuItem
            // 
            this.sửaĐạiLýToolStripMenuItem.Name = "sửaĐạiLýToolStripMenuItem";
            this.sửaĐạiLýToolStripMenuItem.Size = new System.Drawing.Size(144, 24);
            this.sửaĐạiLýToolStripMenuItem.Text = "Sửa đại lý";
            this.sửaĐạiLýToolStripMenuItem.Click += new System.EventHandler(this.SửaĐạiLýToolStripMenuItem_Click);
            // 
            // xóaĐạiLýToolStripMenuItem
            // 
            this.xóaĐạiLýToolStripMenuItem.Name = "xóaĐạiLýToolStripMenuItem";
            this.xóaĐạiLýToolStripMenuItem.Size = new System.Drawing.Size(144, 24);
            this.xóaĐạiLýToolStripMenuItem.Text = "Xóa đại lý";
            this.xóaĐạiLýToolStripMenuItem.Click += new System.EventHandler(this.XóaĐạiLýToolStripMenuItem_Click);
            // 
            // txtKeyword
            // 
            this.txtKeyword.Location = new System.Drawing.Point(221, 25);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(296, 22);
            this.txtKeyword.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(523, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 30);
            this.button1.TabIndex = 2;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvBangDanhSach);
            this.groupBox1.Location = new System.Drawing.Point(12, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(867, 417);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách các đại lý";
            // 
            // QuanlyDaily
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 486);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtKeyword);
            this.Name = "QuanlyDaily";
            this.Text = "QuanlyDaily";
            this.Load += new System.EventHandler(this.QuanlyDaily_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangDanhSach)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBangDanhSach;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sửaĐạiLýToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xóaĐạiLýToolStripMenuItem;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}