namespace AccesVertical_DataBase
{
    partial class FormEditarCurs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditarCurs));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtPdataFi = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtPdataInici = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtPdataVenciment = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBCodi = new System.Windows.Forms.TextBox();
            this.txtBNomCurs = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btAnular = new System.Windows.Forms.Button();
            this.btEditarCurs = new System.Windows.Forms.Button();
            this.comboBMes = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBMes);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtPdataFi);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtPdataInici);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtPdataVenciment);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtBCodi);
            this.groupBox1.Controls.Add(this.txtBNomCurs);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btAnular);
            this.groupBox1.Controls.Add(this.btEditarCurs);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(516, 274);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controls d\'Edició";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(193, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Mes:";
            // 
            // dtPdataFi
            // 
            this.dtPdataFi.Location = new System.Drawing.Point(266, 137);
            this.dtPdataFi.Name = "dtPdataFi";
            this.dtPdataFi.Size = new System.Drawing.Size(215, 20);
            this.dtPdataFi.TabIndex = 31;
            this.dtPdataFi.ValueChanged += new System.EventHandler(this.dtPdataFi_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(110, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Data fi";
            // 
            // dtPdataInici
            // 
            this.dtPdataInici.Location = new System.Drawing.Point(266, 104);
            this.dtPdataInici.Name = "dtPdataInici";
            this.dtPdataInici.Size = new System.Drawing.Size(215, 20);
            this.dtPdataInici.TabIndex = 26;
            this.dtPdataInici.ValueChanged += new System.EventHandler(this.dtPdataInici_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(110, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Data d\'inici";
            // 
            // dtPdataVenciment
            // 
            this.dtPdataVenciment.Location = new System.Drawing.Point(266, 167);
            this.dtPdataVenciment.Name = "dtPdataVenciment";
            this.dtPdataVenciment.Size = new System.Drawing.Size(215, 20);
            this.dtPdataVenciment.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(110, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Data de venciment:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(328, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Codi del Curs:";
            // 
            // txtBCodi
            // 
            this.txtBCodi.Location = new System.Drawing.Point(406, 48);
            this.txtBCodi.MaxLength = 25;
            this.txtBCodi.Name = "txtBCodi";
            this.txtBCodi.Size = new System.Drawing.Size(100, 20);
            this.txtBCodi.TabIndex = 25;
            // 
            // txtBNomCurs
            // 
            this.txtBNomCurs.Location = new System.Drawing.Point(87, 48);
            this.txtBNomCurs.MaxLength = 100;
            this.txtBNomCurs.Name = "txtBNomCurs";
            this.txtBNomCurs.Size = new System.Drawing.Size(100, 20);
            this.txtBNomCurs.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Nom del Curs:";
            // 
            // btAnular
            // 
            this.btAnular.Location = new System.Drawing.Point(415, 215);
            this.btAnular.Name = "btAnular";
            this.btAnular.Size = new System.Drawing.Size(75, 23);
            this.btAnular.TabIndex = 20;
            this.btAnular.Text = "Anul·lar";
            this.btAnular.UseVisualStyleBackColor = true;
            this.btAnular.Click += new System.EventHandler(this.btAnular_Click);
            // 
            // btEditarCurs
            // 
            this.btEditarCurs.Location = new System.Drawing.Point(275, 205);
            this.btEditarCurs.Name = "btEditarCurs";
            this.btEditarCurs.Size = new System.Drawing.Size(110, 33);
            this.btEditarCurs.TabIndex = 19;
            this.btEditarCurs.Text = "Editar Curs";
            this.btEditarCurs.UseVisualStyleBackColor = true;
            this.btEditarCurs.Click += new System.EventHandler(this.btEditarCurs_Click);
            // 
            // comboBMes
            // 
            this.comboBMes.FormattingEnabled = true;
            this.comboBMes.Items.AddRange(new object[] {
            "GENER",
            "FEBRER",
            "MARÇ",
            "ABRIL",
            "MAIG",
            "JUNY",
            "JULIOL",
            "AGOST",
            "SETEMBRE",
            "OCTUBRE",
            "NOVEMBRE",
            "DESEMBRE"});
            this.comboBMes.Location = new System.Drawing.Point(227, 48);
            this.comboBMes.Name = "comboBMes";
            this.comboBMes.Size = new System.Drawing.Size(95, 21);
            this.comboBMes.TabIndex = 44;
            // 
            // FormEditarCurs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 274);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormEditarCurs";
            this.Text = "AccésVertical Organizer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btAnular;
        private System.Windows.Forms.Button btEditarCurs;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtPdataFi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtPdataInici;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtPdataVenciment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBCodi;
        private System.Windows.Forms.TextBox txtBNomCurs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBMes;
    }
}