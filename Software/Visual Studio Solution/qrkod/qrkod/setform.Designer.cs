
namespace qrkod
{
    partial class setform
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
            this.CPUTypeBox = new System.Windows.Forms.ComboBox();
            this.IpAdressBox = new System.Windows.Forms.TextBox();
            this.btncon = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btndis = new System.Windows.Forms.Button();
            this.RockBox = new System.Windows.Forms.NumericUpDown();
            this.SlotBox = new System.Windows.Forms.NumericUpDown();
            this.durum = new System.Windows.Forms.Label();
            this.lab = new System.Windows.Forms.Label();
            this.lab1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.RockBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlotBox)).BeginInit();
            this.SuspendLayout();
            // 
            // CPUTypeBox
            // 
            this.CPUTypeBox.FormattingEnabled = true;
            this.CPUTypeBox.Items.AddRange(new object[] {
            "S7200",
            "S7300",
            "S7400",
            "S71200",
            "S71500"});
            this.CPUTypeBox.Location = new System.Drawing.Point(120, 31);
            this.CPUTypeBox.Name = "CPUTypeBox";
            this.CPUTypeBox.Size = new System.Drawing.Size(121, 24);
            this.CPUTypeBox.TabIndex = 0;
            // 
            // IpAdressBox
            // 
            this.IpAdressBox.Location = new System.Drawing.Point(120, 58);
            this.IpAdressBox.Name = "IpAdressBox";
            this.IpAdressBox.Size = new System.Drawing.Size(121, 22);
            this.IpAdressBox.TabIndex = 1;
            // 
            // btncon
            // 
            this.btncon.Location = new System.Drawing.Point(283, 49);
            this.btncon.Name = "btncon";
            this.btncon.Size = new System.Drawing.Size(88, 41);
            this.btncon.TabIndex = 2;
            this.btncon.Text = "Bağlan";
            this.btncon.UseVisualStyleBackColor = true;
            this.btncon.Click += new System.EventHandler(this.btncon_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "CPU Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Rack";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Slot";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "IP Adress";
            // 
            // btndis
            // 
            this.btndis.Location = new System.Drawing.Point(283, 96);
            this.btndis.Name = "btndis";
            this.btndis.Size = new System.Drawing.Size(88, 42);
            this.btndis.TabIndex = 9;
            this.btndis.Text = "Bağlantı Kes";
            this.btndis.UseVisualStyleBackColor = true;
            // 
            // RockBox
            // 
            this.RockBox.Location = new System.Drawing.Point(120, 83);
            this.RockBox.Name = "RockBox";
            this.RockBox.Size = new System.Drawing.Size(120, 22);
            this.RockBox.TabIndex = 10;
            // 
            // SlotBox
            // 
            this.SlotBox.Location = new System.Drawing.Point(120, 108);
            this.SlotBox.Name = "SlotBox";
            this.SlotBox.Size = new System.Drawing.Size(120, 22);
            this.SlotBox.TabIndex = 11;
            // 
            // durum
            // 
            this.durum.AutoSize = true;
            this.durum.ForeColor = System.Drawing.Color.Red;
            this.durum.Location = new System.Drawing.Point(290, 29);
            this.durum.Name = "durum";
            this.durum.Size = new System.Drawing.Size(75, 17);
            this.durum.TabIndex = 12;
            this.durum.Text = "Bağlı Değil";
            // 
            // lab
            // 
            this.lab.AutoSize = true;
            this.lab.Location = new System.Drawing.Point(117, 154);
            this.lab.Name = "lab";
            this.lab.Size = new System.Drawing.Size(31, 17);
            this.lab.TabIndex = 13;
            this.lab.Text = "veri";
            // 
            // lab1
            // 
            this.lab1.AutoSize = true;
            this.lab1.Location = new System.Drawing.Point(183, 154);
            this.lab1.Name = "lab1";
            this.lab1.Size = new System.Drawing.Size(31, 17);
            this.lab1.TabIndex = 14;
            this.lab1.Text = "veri";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 180);
            this.Controls.Add(this.lab1);
            this.Controls.Add(this.lab);
            this.Controls.Add(this.durum);
            this.Controls.Add(this.SlotBox);
            this.Controls.Add(this.RockBox);
            this.Controls.Add(this.btndis);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btncon);
            this.Controls.Add(this.IpAdressBox);
            this.Controls.Add(this.CPUTypeBox);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RockBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlotBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CPUTypeBox;
        private System.Windows.Forms.TextBox IpAdressBox;
        private System.Windows.Forms.Button btncon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btndis;
        private System.Windows.Forms.NumericUpDown RockBox;
        private System.Windows.Forms.NumericUpDown SlotBox;
        private System.Windows.Forms.Label durum;
        private System.Windows.Forms.Label lab;
        private System.Windows.Forms.Label lab1;
    }
}