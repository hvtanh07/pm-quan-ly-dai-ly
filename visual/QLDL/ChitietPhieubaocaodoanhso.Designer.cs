namespace QLDL
{
    partial class ChitietPhieubaocaodoanhso
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
            this.dsDL = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.thang = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Matxt = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tongtientxt = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dsDL)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dsDL
            // 
            this.dsDL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dsDL.Location = new System.Drawing.Point(6, 80);
            this.dsDL.Name = "dsDL";
            this.dsDL.RowHeadersWidth = 51;
            this.dsDL.RowTemplate.Height = 24;
            this.dsDL.Size = new System.Drawing.Size(492, 216);
            this.dsDL.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.txtKeyword);
            this.groupBox1.Controls.Add(this.dsDL);
            this.groupBox1.Location = new System.Drawing.Point(12, 150);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(504, 302);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách đại lý";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(361, 38);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 28);
            this.button2.TabIndex = 2;
            this.button2.Text = "Search";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // txtKeyword
            // 
            this.txtKeyword.Location = new System.Drawing.Point(42, 38);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(304, 22);
            this.txtKeyword.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(200, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tháng:";
            // 
            // thang
            // 
            this.thang.AutoSize = true;
            this.thang.Location = new System.Drawing.Point(262, 74);
            this.thang.Name = "thang";
            this.thang.Size = new System.Drawing.Size(49, 17);
            this.thang.TabIndex = 3;
            this.thang.Text = "Tháng";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(334, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 43);
            this.button1.TabIndex = 4;
            this.button1.Text = "Xác nhận thông tin phiếu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mã phiếu báo cáo doanh số:";
            // 
            // Matxt
            // 
            this.Matxt.AutoSize = true;
            this.Matxt.Location = new System.Drawing.Point(262, 48);
            this.Matxt.Name = "Matxt";
            this.Matxt.Size = new System.Drawing.Size(49, 17);
            this.Matxt.TabIndex = 6;
            this.Matxt.Text = "Tháng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(140, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tổng doanh thu:";
            // 
            // tongtientxt
            // 
            this.tongtientxt.AutoSize = true;
            this.tongtientxt.Location = new System.Drawing.Point(262, 101);
            this.tongtientxt.Name = "tongtientxt";
            this.tongtientxt.Size = new System.Drawing.Size(49, 17);
            this.tongtientxt.TabIndex = 8;
            this.tongtientxt.Text = "Tháng";
            // 
            // ChitietPhieubaocaodoanhso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 462);
            this.Controls.Add(this.tongtientxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Matxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.thang);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "ChitietPhieubaocaodoanhso";
            this.Text = "ChitietPhieubaocaodoanhso";
            this.Load += new System.EventHandler(this.ChitietPhieubaocaodoanhso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsDL)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dsDL;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label thang;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Matxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label tongtientxt;
    }
}