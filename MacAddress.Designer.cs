namespace FYP
{
    partial class MacAddress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MacAddress));
            this.btnChangeM = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKMac = new System.Windows.Forms.TextBox();
            this.cbDevices = new System.Windows.Forms.ComboBox();
            this.lbKpass = new System.Windows.Forms.Label();
            this.txtKpass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnChangeM
            // 
            this.btnChangeM.Enabled = false;
            this.btnChangeM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnChangeM.Location = new System.Drawing.Point(243, 227);
            this.btnChangeM.Name = "btnChangeM";
            this.btnChangeM.Size = new System.Drawing.Size(156, 27);
            this.btnChangeM.TabIndex = 14;
            this.btnChangeM.Text = "Change";
            this.btnChangeM.UseVisualStyleBackColor = true;
            this.btnChangeM.Click += new System.EventHandler(this.btnChangeM_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnSearch.Location = new System.Drawing.Point(30, 227);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(161, 27);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "Check for Devices";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtKMac);
            this.groupBox1.Controls.Add(this.cbDevices);
            this.groupBox1.Controls.Add(this.lbKpass);
            this.groupBox1.Controls.Add(this.txtKpass);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox1.Location = new System.Drawing.Point(30, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(369, 213);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Change MAC";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "New MAC";
            // 
            // txtKMac
            // 
            this.txtKMac.Enabled = false;
            this.txtKMac.Location = new System.Drawing.Point(141, 77);
            this.txtKMac.Name = "txtKMac";
            this.txtKMac.Size = new System.Drawing.Size(125, 22);
            this.txtKMac.TabIndex = 9;
            // 
            // cbDevices
            // 
            this.cbDevices.FormattingEnabled = true;
            this.cbDevices.Location = new System.Drawing.Point(141, 31);
            this.cbDevices.Name = "cbDevices";
            this.cbDevices.Size = new System.Drawing.Size(122, 24);
            this.cbDevices.TabIndex = 0;
            this.cbDevices.SelectedIndexChanged += new System.EventHandler(this.cbDevices_SelectedIndexChanged);
            // 
            // lbKpass
            // 
            this.lbKpass.AutoSize = true;
            this.lbKpass.Location = new System.Drawing.Point(30, 125);
            this.lbKpass.Name = "lbKpass";
            this.lbKpass.Size = new System.Drawing.Size(89, 16);
            this.lbKpass.TabIndex = 6;
            this.lbKpass.Text = "Enter Old Key";
            // 
            // txtKpass
            // 
            this.txtKpass.Location = new System.Drawing.Point(141, 119);
            this.txtKpass.Name = "txtKpass";
            this.txtKpass.Size = new System.Drawing.Size(125, 22);
            this.txtKpass.TabIndex = 5;
            this.txtKpass.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Select Device";
            // 
            // MacAddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FYP.Properties.Resources.bluetooth_02;
            this.ClientSize = new System.Drawing.Size(448, 269);
            this.Controls.Add(this.btnChangeM);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MacAddress";
            this.Text = "Mac Address";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnChangeM;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtKMac;
        private System.Windows.Forms.ComboBox cbDevices;
        private System.Windows.Forms.Label lbKpass;
        private System.Windows.Forms.TextBox txtKpass;
        private System.Windows.Forms.Label label1;
    }
}