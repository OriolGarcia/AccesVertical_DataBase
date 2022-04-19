namespace AccesVertical_DataBase
{
    partial class FormNovaEmpresa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNovaEmpresa));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btAnular = new System.Windows.Forms.Button();
            this.btInserirEmpresa = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBCorreuelectronic = new System.Windows.Forms.TextBox();
            this.txtBTelèfon = new System.Windows.Forms.TextBox();
            this.txtBPersonaContacte = new System.Windows.Forms.TextBox();
            this.lbPersonadeContacte = new System.Windows.Forms.Label();
            this.txtBCIF = new System.Windows.Forms.TextBox();
            this.lbNIF = new System.Windows.Forms.Label();
            this.lbNomEmpresa = new System.Windows.Forms.Label();
            this.txtBNomEmpresa = new System.Windows.Forms.TextBox();
            this.txtBCodi = new System.Windows.Forms.TextBox();
            this.lbCodi = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBTelefonMobil = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtBTelefonMobil);
            this.groupBox1.Controls.Add(this.btAnular);
            this.groupBox1.Controls.Add(this.btInserirEmpresa);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtBCorreuelectronic);
            this.groupBox1.Controls.Add(this.txtBTelèfon);
            this.groupBox1.Controls.Add(this.txtBPersonaContacte);
            this.groupBox1.Controls.Add(this.lbPersonadeContacte);
            this.groupBox1.Controls.Add(this.txtBCIF);
            this.groupBox1.Controls.Add(this.lbNIF);
            this.groupBox1.Controls.Add(this.lbNomEmpresa);
            this.groupBox1.Controls.Add(this.txtBNomEmpresa);
            this.groupBox1.Controls.Add(this.txtBCodi);
            this.groupBox1.Controls.Add(this.lbCodi);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(515, 311);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controls d\'insersió Empresa";
            // 
            // btAnular
            // 
            this.btAnular.Location = new System.Drawing.Point(367, 255);
            this.btAnular.Name = "btAnular";
            this.btAnular.Size = new System.Drawing.Size(75, 23);
            this.btAnular.TabIndex = 13;
            this.btAnular.Text = "Anul·lar";
            this.btAnular.UseVisualStyleBackColor = true;
            this.btAnular.Click += new System.EventHandler(this.btAnular_Click);
            // 
            // btInserirEmpresa
            // 
            this.btInserirEmpresa.Location = new System.Drawing.Point(217, 248);
            this.btInserirEmpresa.Name = "btInserirEmpresa";
            this.btInserirEmpresa.Size = new System.Drawing.Size(133, 30);
            this.btInserirEmpresa.TabIndex = 12;
            this.btInserirEmpresa.Text = "Inserir Empresa";
            this.btInserirEmpresa.UseVisualStyleBackColor = true;
            this.btInserirEmpresa.Click += new System.EventHandler(this.btInserirEmpresa_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(214, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Correu electrònic:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Telèfon:";
            // 
            // txtBCorreuelectronic
            // 
            this.txtBCorreuelectronic.Location = new System.Drawing.Point(310, 155);
            this.txtBCorreuelectronic.MaxLength = 150;
            this.txtBCorreuelectronic.Name = "txtBCorreuelectronic";
            this.txtBCorreuelectronic.Size = new System.Drawing.Size(100, 20);
            this.txtBCorreuelectronic.TabIndex = 9;
            // 
            // txtBTelèfon
            // 
            this.txtBTelèfon.Location = new System.Drawing.Point(92, 155);
            this.txtBTelèfon.MaxLength = 12;
            this.txtBTelèfon.Name = "txtBTelèfon";
            this.txtBTelèfon.Size = new System.Drawing.Size(100, 20);
            this.txtBTelèfon.TabIndex = 8;
            // 
            // txtBPersonaContacte
            // 
            this.txtBPersonaContacte.Location = new System.Drawing.Point(310, 105);
            this.txtBPersonaContacte.MaxLength = 100;
            this.txtBPersonaContacte.Name = "txtBPersonaContacte";
            this.txtBPersonaContacte.Size = new System.Drawing.Size(144, 20);
            this.txtBPersonaContacte.TabIndex = 7;
            // 
            // lbPersonadeContacte
            // 
            this.lbPersonadeContacte.AutoSize = true;
            this.lbPersonadeContacte.Location = new System.Drawing.Point(194, 108);
            this.lbPersonadeContacte.Name = "lbPersonadeContacte";
            this.lbPersonadeContacte.Size = new System.Drawing.Size(109, 13);
            this.lbPersonadeContacte.TabIndex = 6;
            this.lbPersonadeContacte.Text = "Persona de contacte:";
            // 
            // txtBCIF
            // 
            this.txtBCIF.Location = new System.Drawing.Point(92, 105);
            this.txtBCIF.MaxLength = 25;
            this.txtBCIF.Name = "txtBCIF";
            this.txtBCIF.Size = new System.Drawing.Size(86, 20);
            this.txtBCIF.TabIndex = 5;
            // 
            // lbNIF
            // 
            this.lbNIF.AutoSize = true;
            this.lbNIF.Location = new System.Drawing.Point(59, 108);
            this.lbNIF.Name = "lbNIF";
            this.lbNIF.Size = new System.Drawing.Size(26, 13);
            this.lbNIF.TabIndex = 4;
            this.lbNIF.Text = "CIF:";
            // 
            // lbNomEmpresa
            // 
            this.lbNomEmpresa.AutoSize = true;
            this.lbNomEmpresa.Location = new System.Drawing.Point(194, 61);
            this.lbNomEmpresa.Name = "lbNomEmpresa";
            this.lbNomEmpresa.Size = new System.Drawing.Size(102, 13);
            this.lbNomEmpresa.TabIndex = 3;
            this.lbNomEmpresa.Text = "Nom de la Empresa:";
            // 
            // txtBNomEmpresa
            // 
            this.txtBNomEmpresa.Location = new System.Drawing.Point(299, 58);
            this.txtBNomEmpresa.MaxLength = 100;
            this.txtBNomEmpresa.Name = "txtBNomEmpresa";
            this.txtBNomEmpresa.Size = new System.Drawing.Size(155, 20);
            this.txtBNomEmpresa.TabIndex = 2;
            // 
            // txtBCodi
            // 
            this.txtBCodi.Location = new System.Drawing.Point(92, 58);
            this.txtBCodi.MaxLength = 10;
            this.txtBCodi.Name = "txtBCodi";
            this.txtBCodi.Size = new System.Drawing.Size(86, 20);
            this.txtBCodi.TabIndex = 1;
            // 
            // lbCodi
            // 
            this.lbCodi.AutoSize = true;
            this.lbCodi.Location = new System.Drawing.Point(55, 61);
            this.lbCodi.Name = "lbCodi";
            this.lbCodi.Size = new System.Drawing.Size(31, 13);
            this.lbCodi.TabIndex = 0;
            this.lbCodi.Text = "Codi:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Telèfon Mòbil:";
            // 
            // txtBTelefonMobil
            // 
            this.txtBTelefonMobil.Location = new System.Drawing.Point(120, 196);
            this.txtBTelefonMobil.MaxLength = 12;
            this.txtBTelefonMobil.Name = "txtBTelefonMobil";
            this.txtBTelefonMobil.Size = new System.Drawing.Size(100, 20);
            this.txtBTelefonMobil.TabIndex = 14;
            // 
            // FormNovaEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 311);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(531, 350);
            this.MinimumSize = new System.Drawing.Size(531, 350);
            this.Name = "FormNovaEmpresa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AccésVertical Organizer";
            this.Load += new System.EventHandler(this.FormNovaEmpresa_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBPersonaContacte;
        private System.Windows.Forms.Label lbPersonadeContacte;
        private System.Windows.Forms.TextBox txtBCIF;
        private System.Windows.Forms.Label lbNIF;
        private System.Windows.Forms.Label lbNomEmpresa;
        private System.Windows.Forms.TextBox txtBNomEmpresa;
        private System.Windows.Forms.TextBox txtBCodi;
        private System.Windows.Forms.Label lbCodi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBCorreuelectronic;
        private System.Windows.Forms.TextBox txtBTelèfon;
        private System.Windows.Forms.Button btAnular;
        private System.Windows.Forms.Button btInserirEmpresa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBTelefonMobil;
    }
}