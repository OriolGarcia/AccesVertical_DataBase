namespace AccesVertical_DataBase
{
    partial class FormConnexio     {

           
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConnexio));
            this.lbURL = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ChkBGuardar = new System.Windows.Forms.CheckBox();
            this.btAcceptar = new System.Windows.Forms.Button();
            this.txtBD = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lbSchema = new System.Windows.Forms.Label();
            this.lbPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lbUser = new System.Windows.Forms.Label();
            this.txtport = new System.Windows.Forms.TextBox();
            this.lbPort = new System.Windows.Forms.Label();
            this.txtBURL = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbURL
            // 
            this.lbURL.AutoSize = true;
            this.lbURL.Location = new System.Drawing.Point(23, 30);
            this.lbURL.Name = "lbURL";
            this.lbURL.Size = new System.Drawing.Size(89, 13);
            this.lbURL.TabIndex = 0;
            this.lbURL.Text = "URL del servidor:";
            this.lbURL.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ChkBGuardar);
            this.groupBox1.Controls.Add(this.btAcceptar);
            this.groupBox1.Controls.Add(this.txtBD);
            this.groupBox1.Controls.Add(this.txtUser);
            this.groupBox1.Controls.Add(this.lbSchema);
            this.groupBox1.Controls.Add(this.lbPassword);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.lbUser);
            this.groupBox1.Controls.Add(this.txtport);
            this.groupBox1.Controls.Add(this.lbPort);
            this.groupBox1.Controls.Add(this.txtBURL);
            this.groupBox1.Controls.Add(this.lbURL);
            this.groupBox1.Location = new System.Drawing.Point(3, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(435, 194);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dades de connexió";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // ChkBGuardar
            // 
            this.ChkBGuardar.AutoSize = true;
            this.ChkBGuardar.Checked = true;
            this.ChkBGuardar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkBGuardar.Location = new System.Drawing.Point(91, 148);
            this.ChkBGuardar.Name = "ChkBGuardar";
            this.ChkBGuardar.Size = new System.Drawing.Size(80, 17);
            this.ChkBGuardar.TabIndex = 12;
            this.ChkBGuardar.Text = "Enrecorda\'t";
            this.ChkBGuardar.UseVisualStyleBackColor = true;
            this.ChkBGuardar.CheckedChanged += new System.EventHandler(this.ChkBGuardar_CheckedChanged);
            // 
            // btAcceptar
            // 
            this.btAcceptar.Location = new System.Drawing.Point(331, 144);
            this.btAcceptar.Name = "btAcceptar";
            this.btAcceptar.Size = new System.Drawing.Size(75, 23);
            this.btAcceptar.TabIndex = 11;
            this.btAcceptar.Text = "Acceptar";
            this.btAcceptar.UseVisualStyleBackColor = true;
            this.btAcceptar.Click += new System.EventHandler(this.btAcceptar_Click);
            // 
            // txtBD
            // 
            this.txtBD.Location = new System.Drawing.Point(167, 105);
            this.txtBD.Name = "txtBD";
            this.txtBD.Size = new System.Drawing.Size(100, 20);
            this.txtBD.TabIndex = 10;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(118, 65);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(100, 20);
            this.txtUser.TabIndex = 5;
            // 
            // lbSchema
            // 
            this.lbSchema.AutoSize = true;
            this.lbSchema.Location = new System.Drawing.Point(81, 108);
            this.lbSchema.Name = "lbSchema";
            this.lbSchema.Size = new System.Drawing.Size(83, 13);
            this.lbSchema.TabIndex = 8;
            this.lbSchema.Text = "Base de Dades:";
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(254, 68);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(56, 13);
            this.lbPassword.TabIndex = 7;
            this.lbPassword.Text = "Password:";
            this.lbPassword.Click += new System.EventHandler(this.label4_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(316, 65);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(90, 20);
            this.txtPassword.TabIndex = 9;
            // 
            // lbUser
            // 
            this.lbUser.AutoSize = true;
            this.lbUser.Location = new System.Drawing.Point(41, 68);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(71, 13);
            this.lbUser.TabIndex = 4;
            this.lbUser.Text = "Nom d\'usuari:";
            this.lbUser.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtport
            // 
            this.txtport.Location = new System.Drawing.Point(339, 27);
            this.txtport.Name = "txtport";
            this.txtport.Size = new System.Drawing.Size(67, 20);
            this.txtport.TabIndex = 3;
            // 
            // lbPort
            // 
            this.lbPort.AutoSize = true;
            this.lbPort.Location = new System.Drawing.Point(304, 30);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(29, 13);
            this.lbPort.TabIndex = 2;
            this.lbPort.Text = "Port:";
            this.lbPort.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtBURL
            // 
            this.txtBURL.Location = new System.Drawing.Point(118, 27);
            this.txtBURL.Name = "txtBURL";
            this.txtBURL.Size = new System.Drawing.Size(149, 20);
            this.txtBURL.TabIndex = 1;
            this.txtBURL.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // FormConnexio
            // 
            this.AcceptButton = this.btAcceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 208);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormConnexio";
            this.Text = "AccésVertical Organizer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbURL;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBURL;
        private System.Windows.Forms.Label lbPort;
        private System.Windows.Forms.Label lbUser;
        private System.Windows.Forms.TextBox txtport;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lbSchema;
        private System.Windows.Forms.Button btAcceptar;
        private System.Windows.Forms.TextBox txtBD;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.CheckBox ChkBGuardar;
    }
    
}

