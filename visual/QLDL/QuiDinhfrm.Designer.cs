namespace QLDL
{
    partial class QuiDinhfrm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.maxloaidl = new System.Windows.Forms.TextBox();
            this.soluongmh = new System.Windows.Forms.TextBox();
            this.soluongdvt = new System.Windows.Forms.TextBox();
            this.maxsodl = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(138, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Qui Định";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số lượng các loại đại lý tối đa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số lượng mặt hàng tối đa";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Số lượng đơn vị tính";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 227);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(225, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Số lượng đại lý tối đa trong 1 quận";
            // 
            // maxloaidl
            // 
            this.maxloaidl.Location = new System.Drawing.Point(264, 84);
            this.maxloaidl.Name = "maxloaidl";
            this.maxloaidl.Size = new System.Drawing.Size(100, 22);
            this.maxloaidl.TabIndex = 5;
            // 
            // soluongmh
            // 
            this.soluongmh.Location = new System.Drawing.Point(264, 127);
            this.soluongmh.Name = "soluongmh";
            this.soluongmh.Size = new System.Drawing.Size(100, 22);
            this.soluongmh.TabIndex = 6;
            // 
            // soluongdvt
            // 
            this.soluongdvt.Location = new System.Drawing.Point(264, 173);
            this.soluongdvt.Name = "soluongdvt";
            this.soluongdvt.Size = new System.Drawing.Size(100, 22);
            this.soluongdvt.TabIndex = 7;
            // 
            // maxsodl
            // 
            this.maxsodl.Location = new System.Drawing.Point(264, 224);
            this.maxsodl.Name = "maxsodl";
            this.maxsodl.Size = new System.Drawing.Size(100, 22);
            this.maxsodl.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(144, 271);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 34);
            this.button1.TabIndex = 9;
            this.button1.Text = "Thay đổi";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // QuiDinhfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 317);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.maxsodl);
            this.Controls.Add(this.soluongdvt);
            this.Controls.Add(this.soluongmh);
            this.Controls.Add(this.maxloaidl);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "QuiDinhfrm";
            this.Text = "QuiDinhfrm";
            this.Load += new System.EventHandler(this.QuiDinhfrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox maxloaidl;
        private System.Windows.Forms.TextBox soluongmh;
        private System.Windows.Forms.TextBox soluongdvt;
        private System.Windows.Forms.TextBox maxsodl;
        private System.Windows.Forms.Button button1;
    }
}