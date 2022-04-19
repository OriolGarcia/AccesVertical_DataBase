namespace AccesVertical_DataBase
{
    partial class FormNouCurs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNouCurs));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtPdataFi = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtPdataInici = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btAnular = new System.Windows.Forms.Button();
            this.btCrearCurs = new System.Windows.Forms.Button();
            this.dtPdataVenciment = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBCodi = new System.Windows.Forms.TextBox();
            this.txtBNomCurs = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.groupBox1.Controls.Add(this.btAnular);
            this.groupBox1.Controls.Add(this.btCrearCurs);
            this.groupBox1.Controls.Add(this.dtPdataVenciment);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtBCodi);
            this.groupBox1.Controls.Add(this.txtBNomCurs);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(585, 278);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controls d\'alta nou Curs";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(214, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Mes:";
            // 
            // dtPdataFi
            // 
            this.dtPdataFi.Location = new System.Drawing.Point(287, 147);
            this.dtPdataFi.Name = "dtPdataFi";
            this.dtPdataFi.Size = new System.Drawing.Size(215, 20);
            this.dtPdataFi.TabIndex = 19;
            this.dtPdataFi.ValueChanged += new System.EventHandler(this.dtPdataFi_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(131, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Data fi";
            // 
            // dtPdataInici
            // 
            this.dtPdataInici.Location = new System.Drawing.Point(287, 108);
            this.dtPdataInici.Name = "dtPdataInici";
            this.dtPdataInici.Size = new System.Drawing.Size(215, 20);
            this.dtPdataInici.TabIndex = 3;
            this.dtPdataInici.ValueChanged += new System.EventHandler(this.dtPdataInici_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(131, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Data d\'inici";
            // 
            // btAnular
            // 
            this.btAnular.Location = new System.Drawing.Point(427, 230);
            this.btAnular.Name = "btAnular";
            this.btAnular.Size = new System.Drawing.Size(75, 23);
            this.btAnular.TabIndex = 7;
            this.btAnular.Text = "Anul·lar";
            this.btAnular.UseVisualStyleBackColor = true;
            this.btAnular.Click += new System.EventHandler(this.btAnular_Click);
            // 
            // btCrearCurs
            // 
            this.btCrearCurs.Location = new System.Drawing.Point(287, 220);
            this.btCrearCurs.Name = "btCrearCurs";
            this.btCrearCurs.Size = new System.Drawing.Size(110, 33);
            this.btCrearCurs.TabIndex = 6;
            this.btCrearCurs.Text = "Crear Curs";
            this.btCrearCurs.UseVisualStyleBackColor = true;
            this.btCrearCurs.Click += new System.EventHandler(this.btCrearCurs_Click);
            // 
            // dtPdataVenciment
            // 
            this.dtPdataVenciment.Location = new System.Drawing.Point(287, 177);
            this.dtPdataVenciment.Name = "dtPdataVenciment";
            this.dtPdataVenciment.Size = new System.Drawing.Size(215, 20);
            this.dtPdataVenciment.TabIndex = 5;
            this.dtPdataVenciment.ValueChanged += new System.EventHandler(this.dtPdataVenciment_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(131, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Data de venciment:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(349, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Codi del Curs:";
            // 
            // txtBCodi
            // 
            this.txtBCodi.Location = new System.Drawing.Point(427, 58);
            this.txtBCodi.MaxLength = 25;
            this.txtBCodi.Name = "txtBCodi";
            this.txtBCodi.Size = new System.Drawing.Size(100, 20);
            this.txtBCodi.TabIndex = 2;
            // 
            // txtBNomCurs
            // 
            this.txtBNomCurs.Location = new System.Drawing.Point(108, 58);
            this.txtBNomCurs.MaxLength = 100;
            this.txtBNomCurs.Name = "txtBNomCurs";
            this.txtBNomCurs.Size = new System.Drawing.Size(100, 20);
            this.txtBNomCurs.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nom del Curs:";
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
            this.comboBMes.Location = new System.Drawing.Point(248, 58);
            this.comboBMes.Name = "comboBMes";
            this.comboBMes.Size = new System.Drawing.Size(95, 21);
            this.comboBMes.TabIndex = 44;
            // 
            // FormNouCurs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 278);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormNouCurs";
            this.Text = "AccésVertical Organizer";
            this.Load += new System.EventHandler(this.FormNouCurs_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btAnular;
        private System.Windows.Forms.Button btCrearCurs;
        private System.Windows.Forms.DateTimePicker dtPdataVenciment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBCodi;
        private System.Windows.Forms.TextBox txtBNomCurs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtPdataInici;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtPdataFi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBMes;
    }
}