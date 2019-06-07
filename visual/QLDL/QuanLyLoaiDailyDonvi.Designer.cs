namespace QLDL
{
    partial class QuanLyLoaiDailyDonvi
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
            this.danhsachldl = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtKeyword1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ldltxt = new System.Windows.Forms.TextBox();
            this.stntxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.maldl = new System.Windows.Forms.TextBox();
            this.dsDonvi = new System.Windows.Forms.DataGridView();
            this.txtKeyword2 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.Donvitxt = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xóaĐơnVịToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.danhsachldl)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsDonvi)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // danhsachldl
            // 
            this.danhsachldl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.danhsachldl.ContextMenuStrip = this.contextMenuStrip1;
            this.danhsachldl.Location = new System.Drawing.Point(11, 57);
            this.danhsachldl.Name = "danhsachldl";
            this.danhsachldl.RowHeadersVisible = false;
            this.danhsachldl.RowHeadersWidth = 51;
            this.danhsachldl.RowTemplate.Height = 24;
            this.danhsachldl.Size = new System.Drawing.Size(265, 150);
            this.danhsachldl.TabIndex = 0;
            this.danhsachldl.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Danhsachldl_CellClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xóaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(174, 28);
            // 
            // xóaToolStripMenuItem
            // 
            this.xóaToolStripMenuItem.Name = "xóaToolStripMenuItem";
            this.xóaToolStripMenuItem.Size = new System.Drawing.Size(173, 24);
            this.xóaToolStripMenuItem.Text = "Xóa loại đại lý";
            this.xóaToolStripMenuItem.Click += new System.EventHandler(this.XóaToolStripMenuItem_Click);
            // 
            // txtKeyword1
            // 
            this.txtKeyword1.Location = new System.Drawing.Point(11, 29);
            this.txtKeyword1.Name = "txtKeyword1";
            this.txtKeyword1.Size = new System.Drawing.Size(184, 22);
            this.txtKeyword1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(201, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(86, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(411, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Quản lý các loại đại lý và đơn vị";
            // 
            // ldltxt
            // 
            this.ldltxt.Location = new System.Drawing.Point(410, 101);
            this.ldltxt.Name = "ldltxt";
            this.ldltxt.Size = new System.Drawing.Size(118, 22);
            this.ldltxt.TabIndex = 2;
            this.ldltxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numOnly);
            // 
            // stntxt
            // 
            this.stntxt.Location = new System.Drawing.Point(410, 129);
            this.stntxt.Name = "stntxt";
            this.stntxt.Size = new System.Drawing.Size(118, 22);
            this.stntxt.TabIndex = 3;
            this.stntxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numOnly);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(291, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Loại đại lý";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(291, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Số tiền nợ tối đa";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(322, 173);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Thêm";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(419, 173);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "Sửa";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(291, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Mã loại đại lý";
            // 
            // maldl
            // 
            this.maldl.Location = new System.Drawing.Point(410, 74);
            this.maldl.Name = "maldl";
            this.maldl.Size = new System.Drawing.Size(118, 22);
            this.maldl.TabIndex = 1;
            // 
            // dsDonvi
            // 
            this.dsDonvi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dsDonvi.ContextMenuStrip = this.contextMenuStrip2;
            this.dsDonvi.Location = new System.Drawing.Point(11, 54);
            this.dsDonvi.Name = "dsDonvi";
            this.dsDonvi.RowHeadersVisible = false;
            this.dsDonvi.RowHeadersWidth = 51;
            this.dsDonvi.RowTemplate.Height = 24;
            this.dsDonvi.Size = new System.Drawing.Size(265, 150);
            this.dsDonvi.TabIndex = 12;
            this.dsDonvi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellClick);
            // 
            // txtKeyword2
            // 
            this.txtKeyword2.Location = new System.Drawing.Point(11, 26);
            this.txtKeyword2.Name = "txtKeyword2";
            this.txtKeyword2.Size = new System.Drawing.Size(184, 22);
            this.txtKeyword2.TabIndex = 13;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(201, 20);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 28);
            this.button4.TabIndex = 14;
            this.button4.Text = "search";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(333, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Đơn vị";
            // 
            // Donvitxt
            // 
            this.Donvitxt.Location = new System.Drawing.Point(410, 100);
            this.Donvitxt.Name = "Donvitxt";
            this.Donvitxt.Size = new System.Drawing.Size(118, 22);
            this.Donvitxt.TabIndex = 16;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(373, 160);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 17;
            this.button5.Text = "Thêm";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xóaĐơnVịToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(150, 28);
            // 
            // xóaĐơnVịToolStripMenuItem
            // 
            this.xóaĐơnVịToolStripMenuItem.Name = "xóaĐơnVịToolStripMenuItem";
            this.xóaĐơnVịToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.xóaĐơnVịToolStripMenuItem.Text = "Xóa đơn vị";
            this.xóaĐơnVịToolStripMenuItem.Click += new System.EventHandler(this.XóaĐơnVịToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.danhsachldl);
            this.groupBox1.Controls.Add(this.txtKeyword1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.ldltxt);
            this.groupBox1.Controls.Add(this.stntxt);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.maldl);
            this.groupBox1.Location = new System.Drawing.Point(22, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(544, 219);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Loại đại lý";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dsDonvi);
            this.groupBox2.Controls.Add(this.txtKeyword2);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.Donvitxt);
            this.groupBox2.Location = new System.Drawing.Point(22, 295);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(544, 210);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Đơn vị";
            // 
            // QuanLyLoaiDailyDonvi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 530);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "QuanLyLoaiDailyDonvi";
            this.Text = "QuanLyLoaiDaily";
            this.Load += new System.EventHandler(this.QuanLyLoaiDaily_Load);
            ((System.ComponentModel.ISupportInitialize)(this.danhsachldl)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dsDonvi)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView danhsachldl;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem xóaToolStripMenuItem;
        private System.Windows.Forms.TextBox txtKeyword1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ldltxt;
        private System.Windows.Forms.TextBox stntxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox maldl;
        private System.Windows.Forms.DataGridView dsDonvi;
        private System.Windows.Forms.TextBox txtKeyword2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Donvitxt;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem xóaĐơnVịToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}