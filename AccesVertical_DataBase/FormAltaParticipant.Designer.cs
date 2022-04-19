namespace AccesVertical_DataBase
{
    partial class FormAltaParticipant
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAltaParticipant));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btInserir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxEmpresa = new System.Windows.Forms.ComboBox();
            this.txtBDNI = new System.Windows.Forms.TextBox();
            this.txtBCognoms = new System.Windows.Forms.TextBox();
            this.txtBNom = new System.Windows.Forms.TextBox();
            this.lbCognoms = new System.Windows.Forms.Label();
            this.lbDNI = new System.Windows.Forms.Label();
            this.lbNom = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btCancelar);
            this.groupBox1.Controls.Add(this.btInserir);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxEmpresa);
            this.groupBox1.Controls.Add(this.txtBDNI);
            this.groupBox1.Controls.Add(this.txtBCognoms);
            this.groupBox1.Controls.Add(this.txtBNom);
            this.groupBox1.Controls.Add(this.lbCognoms);
            this.groupBox1.Controls.Add(this.lbDNI);
            this.groupBox1.Controls.Add(this.lbNom);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(401, 344);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controls d\'Alta Participant";
            // 
            // btCancelar
            // 
            this.btCancelar.Location = new System.Drawing.Point(281, 288);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 23);
            this.btCancelar.TabIndex = 22;
            this.btCancelar.Text = "Anul·lar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btInserir
            // 
            this.btInserir.Location = new System.Drawing.Point(79, 285);
            this.btInserir.Name = "btInserir";
            this.btInserir.Size = new System.Drawing.Size(196, 28);
            this.btInserir.TabIndex = 21;
            this.btInserir.Text = "Inserir Participant";
            this.btInserir.UseVisualStyleBackColor = true;
            this.btInserir.Click += new System.EventHandler(this.btInserir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Empresa:";
            // 
            // comboBoxEmpresa
            // 
            this.comboBoxEmpresa.FormattingEnabled = true;
            this.comboBoxEmpresa.Location = new System.Drawing.Point(127, 220);
            this.comboBoxEmpresa.Name = "comboBoxEmpresa";
            this.comboBoxEmpresa.Size = new System.Drawing.Size(200, 21);
            this.comboBoxEmpresa.TabIndex = 19;
            // 
            // txtBDNI
            // 
            this.txtBDNI.Location = new System.Drawing.Point(127, 169);
            this.txtBDNI.MaxLength = 9;
            this.txtBDNI.Name = "txtBDNI";
            this.txtBDNI.Size = new System.Drawing.Size(100, 20);
            this.txtBDNI.TabIndex = 13;
            // 
            // txtBCognoms
            // 
            this.txtBCognoms.Location = new System.Drawing.Point(127, 124);
            this.txtBCognoms.MaxLength = 100;
            this.txtBCognoms.Name = "txtBCognoms";
            this.txtBCognoms.Size = new System.Drawing.Size(231, 20);
            this.txtBCognoms.TabIndex = 12;
            // 
            // txtBNom
            // 
            this.txtBNom.Location = new System.Drawing.Point(128, 75);
            this.txtBNom.MaxLength = 100;
            this.txtBNom.Name = "txtBNom";
            this.txtBNom.Size = new System.Drawing.Size(100, 20);
            this.txtBNom.TabIndex = 11;
            // 
            // lbCognoms
            // 
            this.lbCognoms.AutoSize = true;
            this.lbCognoms.Location = new System.Drawing.Point(55, 127);
            this.lbCognoms.Name = "lbCognoms";
            this.lbCognoms.Size = new System.Drawing.Size(54, 13);
            this.lbCognoms.TabIndex = 2;
            this.lbCognoms.Text = "Cognoms:";
            // 
            // lbDNI
            // 
            this.lbDNI.AutoSize = true;
            this.lbDNI.Location = new System.Drawing.Point(79, 176);
            this.lbDNI.Name = "lbDNI";
            this.lbDNI.Size = new System.Drawing.Size(29, 13);
            this.lbDNI.TabIndex = 1;
            this.lbDNI.Text = "DNI:";
            // 
            // lbNom
            // 
            this.lbNom.AutoSize = true;
            this.lbNom.Location = new System.Drawing.Point(76, 78);
            this.lbNom.Name = "lbNom";
            this.lbNom.Size = new System.Drawing.Size(32, 13);
            this.lbNom.TabIndex = 0;
            this.lbNom.Text = "Nom:";
            // 
            // FormAltaParticipant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 344);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAltaParticipant";
            this.Text = "AccésVertical Organizer.";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btInserir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxEmpresa;
        private System.Windows.Forms.TextBox txtBDNI;
        private System.Windows.Forms.TextBox txtBCognoms;
        private System.Windows.Forms.TextBox txtBNom;
        private System.Windows.Forms.Label lbCognoms;
        private System.Windows.Forms.Label lbDNI;
        private System.Windows.Forms.Label lbNom;
    }
}