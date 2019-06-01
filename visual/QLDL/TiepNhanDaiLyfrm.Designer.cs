namespace QLDL
{
    partial class TiepNhanDaiLyfrm
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
            this.dc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.mail = new System.Windows.Forms.TextBox();
            this.dttxt = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.tentxt = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.ldl = new System.Windows.Forms.TextBox();
            this.quantxt = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.madl = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tiếp nhận đại lý";
            // 
            // dc
            // 
            this.dc.Location = new System.Drawing.Point(116, 184);
            this.dc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dc.Name = "dc";
            this.dc.Size = new System.Drawing.Size(195, 22);
            this.dc.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Địa chỉ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Email";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 286);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "Quận";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 337);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 17);
            this.label7.TabIndex = 7;
            this.label7.Text = "Điện thoại";
            // 
            // mail
            // 
            this.mail.Location = new System.Drawing.Point(116, 229);
            this.mail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mail.Name = "mail";
            this.mail.Size = new System.Drawing.Size(195, 22);
            this.mail.TabIndex = 4;
            // 
            // dttxt
            // 
            this.dttxt.Location = new System.Drawing.Point(116, 334);
            this.dttxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dttxt.MaxLength = 11;
            this.dttxt.Name = "dttxt";
            this.dttxt.Size = new System.Drawing.Size(195, 22);
            this.dttxt.TabIndex = 6;
            this.dttxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numOnly);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(95, 446);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 36);
            this.button1.TabIndex = 8;
            this.button1.Text = "Thêm đại lý";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 138);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 17);
            this.label9.TabIndex = 19;
            this.label9.Text = "Tên đại lý";
            // 
            // tentxt
            // 
            this.tentxt.Location = new System.Drawing.Point(116, 135);
            this.tentxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tentxt.Name = "tentxt";
            this.tentxt.Size = new System.Drawing.Size(195, 22);
            this.tentxt.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 395);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 17);
            this.label10.TabIndex = 21;
            this.label10.Text = "Loại đại lý";
            // 
            // ldl
            // 
            this.ldl.Location = new System.Drawing.Point(116, 392);
            this.ldl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ldl.MaxLength = 11;
            this.ldl.Name = "ldl";
            this.ldl.Size = new System.Drawing.Size(195, 22);
            this.ldl.TabIndex = 7;
            // 
            // quantxt
            // 
            this.quantxt.FormattingEnabled = true;
            this.quantxt.Items.AddRange(new object[] {
            "Quận 1",
            "Quận 12",
            "Quận Thủ Đức",
            "Quận 9",
            "Quận Gò Vấp",
            "Quận Bình Thạnh",
            "Quận Tân Bình",
            "Quận Tân Phú",
            "Quận Phú Nhuận",
            "\tQuận 2",
            "Quận 3",
            "Quận 10",
            "Quận 11",
            "Quận 4",
            "Quận 5",
            "Quận 6",
            "Quận 8",
            "Quận Bình Tân",
            "Quận 7"});
            this.quantxt.Location = new System.Drawing.Point(116, 283);
            this.quantxt.Name = "quantxt";
            this.quantxt.Size = new System.Drawing.Size(195, 24);
            this.quantxt.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 82);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 22;
            this.label3.Text = "Mã đại lý";
            // 
            // madl
            // 
            this.madl.Location = new System.Drawing.Point(116, 79);
            this.madl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.madl.MaxLength = 11;
            this.madl.Name = "madl";
            this.madl.Size = new System.Drawing.Size(195, 22);
            this.madl.TabIndex = 1;
            this.madl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numOnly);
            // 
            // TiepNhanDaiLyfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 497);
            this.Controls.Add(this.madl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.quantxt);
            this.Controls.Add(this.ldl);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tentxt);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dttxt);
            this.Controls.Add(this.mail);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dc);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "TiepNhanDaiLyfrm";
            this.Text = "TiepNhanDaiLyfrm";
            this.Load += new System.EventHandler(this.TiepNhanDaiLyfrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox dc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox mail;
        private System.Windows.Forms.TextBox dttxt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tentxt;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox ldl;
        private System.Windows.Forms.ComboBox quantxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox madl;
    }
}