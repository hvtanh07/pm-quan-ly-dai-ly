namespace QLDL
{
    partial class SuaDaiLy
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mail = new System.Windows.Forms.TextBox();
            this.dc = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tentxt = new System.Windows.Forms.TextBox();
            this.dttxt = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.notxt = new System.Windows.Forms.TextBox();
            this.notxtw = new System.Windows.Forms.Label();
            this.quantxt = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.madl = new System.Windows.Forms.TextBox();
            this.ldl = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(146, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cập nhật đại lý";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(187, 243);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 42);
            this.button1.TabIndex = 11;
            this.button1.Text = "Cập nhật";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(251, 147);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 17);
            this.label9.TabIndex = 13;
            this.label9.Text = "Điện thoại";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(251, 62);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên đại lý";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 101);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Địa chỉ";
            // 
            // mail
            // 
            this.mail.Location = new System.Drawing.Point(331, 98);
            this.mail.Margin = new System.Windows.Forms.Padding(4);
            this.mail.Name = "mail";
            this.mail.Size = new System.Drawing.Size(127, 22);
            this.mail.TabIndex = 3;
            // 
            // dc
            // 
            this.dc.Location = new System.Drawing.Point(91, 98);
            this.dc.Margin = new System.Windows.Forms.Padding(4);
            this.dc.Name = "dc";
            this.dc.Size = new System.Drawing.Size(133, 22);
            this.dc.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 147);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Quận";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(251, 101);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Email";
            // 
            // tentxt
            // 
            this.tentxt.Location = new System.Drawing.Point(331, 59);
            this.tentxt.Margin = new System.Windows.Forms.Padding(4);
            this.tentxt.Name = "tentxt";
            this.tentxt.Size = new System.Drawing.Size(127, 22);
            this.tentxt.TabIndex = 1;
            // 
            // dttxt
            // 
            this.dttxt.Location = new System.Drawing.Point(331, 144);
            this.dttxt.Margin = new System.Windows.Forms.Padding(4);
            this.dttxt.MaxLength = 11;
            this.dttxt.Name = "dttxt";
            this.dttxt.Size = new System.Drawing.Size(127, 22);
            this.dttxt.TabIndex = 5;
            this.dttxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numOnly);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(251, 194);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 17);
            this.label10.TabIndex = 24;
            this.label10.Text = "Loại đại lý";
            // 
            // notxt
            // 
            this.notxt.Location = new System.Drawing.Point(91, 191);
            this.notxt.Margin = new System.Windows.Forms.Padding(4);
            this.notxt.MaxLength = 11;
            this.notxt.Name = "notxt";
            this.notxt.Size = new System.Drawing.Size(133, 22);
            this.notxt.TabIndex = 6;
            this.notxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numOnly);
            // 
            // notxtw
            // 
            this.notxtw.AutoSize = true;
            this.notxtw.Location = new System.Drawing.Point(13, 194);
            this.notxtw.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.notxtw.Name = "notxtw";
            this.notxtw.Size = new System.Drawing.Size(76, 17);
            this.notxtw.TabIndex = 25;
            this.notxtw.Text = "Nợ hiện tại";
            // 
            // quantxt
            // 
            this.quantxt.FormattingEnabled = true;
            this.quantxt.Items.AddRange(new object[] {
            "Quận 1",
            "\tQuận 12",
            "\tQuận Thủ Đức",
            "Quận 9",
            "Quận Gò Vấp",
            "Quận Bình Thạnh",
            "Quận Tân Bình",
            "Quận Tân Phú",
            "Quận Phú Nhuận",
            "Quận 2",
            "Quận 3",
            "Quận 10",
            "Quận 11",
            "Quận 4",
            "Quận 5",
            "Quận 6",
            "Quận 8",
            "Quận Bình Tân",
            "Quận 7"});
            this.quantxt.Location = new System.Drawing.Point(91, 144);
            this.quantxt.Name = "quantxt";
            this.quantxt.Size = new System.Drawing.Size(133, 24);
            this.quantxt.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 62);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 17);
            this.label4.TabIndex = 26;
            this.label4.Text = "Mẫ đại lý";
            // 
            // madl
            // 
            this.madl.Location = new System.Drawing.Point(91, 59);
            this.madl.Margin = new System.Windows.Forms.Padding(4);
            this.madl.Name = "madl";
            this.madl.ReadOnly = true;
            this.madl.Size = new System.Drawing.Size(133, 22);
            this.madl.TabIndex = 27;
            // 
            // ldl
            // 
            this.ldl.FormattingEnabled = true;
            this.ldl.Location = new System.Drawing.Point(331, 191);
            this.ldl.Name = "ldl";
            this.ldl.Size = new System.Drawing.Size(127, 24);
            this.ldl.TabIndex = 28;
            // 
            // SuaDaiLy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 311);
            this.Controls.Add(this.ldl);
            this.Controls.Add(this.madl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.quantxt);
            this.Controls.Add(this.notxtw);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.mail);
            this.Controls.Add(this.notxt);
            this.Controls.Add(this.dttxt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dc);
            this.Controls.Add(this.tentxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "SuaDaiLy";
            this.Text = "CapNhatSuaDaiLy";
            this.Load += new System.EventHandler(this.CapNhatSuaDaiLy_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox mail;
        private System.Windows.Forms.TextBox dc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tentxt;
        private System.Windows.Forms.TextBox dttxt;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label notxtw;
        private System.Windows.Forms.TextBox notxt;
        private System.Windows.Forms.ComboBox quantxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox madl;
        private System.Windows.Forms.ComboBox ldl;
    }
}