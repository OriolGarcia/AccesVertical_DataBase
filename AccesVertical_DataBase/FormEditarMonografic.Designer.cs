namespace AccesVertical_DataBase
{
    partial class FormEditarMonografic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditarMonografic));
            this.btEliminar = new System.Windows.Forms.GroupBox();
            this.checkBFinalitzat = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBHorari = new System.Windows.Forms.TextBox();
            this.comboBoxUbicació = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBGrup = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtBCodiAF = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btEditorMonograficsTipus = new System.Windows.Forms.Button();
            this.comboBoxMonograficTipus = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxEmpreses = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDownHores = new System.Windows.Forms.NumericUpDown();
            this.btAnular = new System.Windows.Forms.Button();
            this.btEditarMonografic = new System.Windows.Forms.Button();
            this.txtBModalitat = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtPickerDataFi = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtPickerDataInici = new System.Windows.Forms.DateTimePicker();
            this.txtBCodi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBTitol = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxBonificat = new System.Windows.Forms.CheckBox();
            this.btEliminar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHores)).BeginInit();
            this.SuspendLayout();
            // 
            // btEliminar
            // 
            this.btEliminar.Controls.Add(this.checkBoxBonificat);
            this.btEliminar.Controls.Add(this.checkBFinalitzat);
            this.btEliminar.Controls.Add(this.label8);
            this.btEliminar.Controls.Add(this.txtBHorari);
            this.btEliminar.Controls.Add(this.comboBoxUbicació);
            this.btEliminar.Controls.Add(this.label12);
            this.btEliminar.Controls.Add(this.txtBGrup);
            this.btEliminar.Controls.Add(this.label11);
            this.btEliminar.Controls.Add(this.txtBCodiAF);
            this.btEliminar.Controls.Add(this.label10);
            this.btEliminar.Controls.Add(this.btEditorMonograficsTipus);
            this.btEliminar.Controls.Add(this.comboBoxMonograficTipus);
            this.btEliminar.Controls.Add(this.label9);
            this.btEliminar.Controls.Add(this.comboBoxEmpreses);
            this.btEliminar.Controls.Add(this.label7);
            this.btEliminar.Controls.Add(this.numericUpDownHores);
            this.btEliminar.Controls.Add(this.btAnular);
            this.btEliminar.Controls.Add(this.btEditarMonografic);
            this.btEliminar.Controls.Add(this.txtBModalitat);
            this.btEliminar.Controls.Add(this.label6);
            this.btEliminar.Controls.Add(this.dtPickerDataFi);
            this.btEliminar.Controls.Add(this.label5);
            this.btEliminar.Controls.Add(this.label4);
            this.btEliminar.Controls.Add(this.dtPickerDataInici);
            this.btEliminar.Controls.Add(this.txtBCodi);
            this.btEliminar.Controls.Add(this.label3);
            this.btEliminar.Controls.Add(this.label2);
            this.btEliminar.Controls.Add(this.txtBTitol);
            this.btEliminar.Controls.Add(this.label1);
            this.btEliminar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btEliminar.Location = new System.Drawing.Point(0, 0);
            this.btEliminar.Name = "btEliminar";
            this.btEliminar.Size = new System.Drawing.Size(672, 396);
            this.btEliminar.TabIndex = 1;
            this.btEliminar.TabStop = false;
            this.btEliminar.Text = "Controls de Creació de nou Monogràfic";
            this.btEliminar.Enter += new System.EventHandler(this.btEliminar_Enter);
            // 
            // checkBFinalitzat
            // 
            this.checkBFinalitzat.AutoSize = true;
            this.checkBFinalitzat.Location = new System.Drawing.Point(439, 327);
            this.checkBFinalitzat.Name = "checkBFinalitzat";
            this.checkBFinalitzat.Size = new System.Drawing.Size(120, 17);
            this.checkBFinalitzat.TabIndex = 15;
            this.checkBFinalitzat.Text = "Monografic finalitzat";
            this.checkBFinalitzat.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(348, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 40;
            this.label8.Text = "Ubicació:";
            // 
            // txtBHorari
            // 
            this.txtBHorari.Location = new System.Drawing.Point(143, 293);
            this.txtBHorari.Name = "txtBHorari";
            this.txtBHorari.Size = new System.Drawing.Size(177, 20);
            this.txtBHorari.TabIndex = 12;
            // 
            // comboBoxUbicació
            // 
            this.comboBoxUbicació.FormattingEnabled = true;
            this.comboBoxUbicació.Items.AddRange(new object[] {
            "ACCÉS FORMACIÓ",
            "CASA CLIENT"});
            this.comboBoxUbicació.Location = new System.Drawing.Point(407, 101);
            this.comboBoxUbicació.Name = "comboBoxUbicació";
            this.comboBoxUbicació.Size = new System.Drawing.Size(121, 21);
            this.comboBoxUbicació.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(60, 300);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 35;
            this.label12.Text = "Horari:";
            // 
            // txtBGrup
            // 
            this.txtBGrup.Location = new System.Drawing.Point(359, 195);
            this.txtBGrup.Name = "txtBGrup";
            this.txtBGrup.Size = new System.Drawing.Size(100, 20);
            this.txtBGrup.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(270, 198);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 33;
            this.label11.Text = "/       Grup: ";
            // 
            // txtBCodiAF
            // 
            this.txtBCodiAF.Location = new System.Drawing.Point(143, 195);
            this.txtBCodiAF.Name = "txtBCodiAF";
            this.txtBCodiAF.Size = new System.Drawing.Size(100, 20);
            this.txtBCodiAF.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(74, 198);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 31;
            this.label10.Text = "Codi AF:";
            // 
            // btEditorMonograficsTipus
            // 
            this.btEditorMonograficsTipus.Location = new System.Drawing.Point(359, 145);
            this.btEditorMonograficsTipus.Name = "btEditorMonograficsTipus";
            this.btEditorMonograficsTipus.Size = new System.Drawing.Size(211, 23);
            this.btEditorMonograficsTipus.TabIndex = 7;
            this.btEditorMonograficsTipus.Text = "Editor de Monogràfics Tipus";
            this.btEditorMonograficsTipus.UseVisualStyleBackColor = true;
            this.btEditorMonograficsTipus.Click += new System.EventHandler(this.btEditorMonograficsTipus_Click);
            // 
            // comboBoxMonograficTipus
            // 
            this.comboBoxMonograficTipus.FormattingEnabled = true;
            this.comboBoxMonograficTipus.Location = new System.Drawing.Point(143, 147);
            this.comboBoxMonograficTipus.Name = "comboBoxMonograficTipus";
            this.comboBoxMonograficTipus.Size = new System.Drawing.Size(181, 21);
            this.comboBoxMonograficTipus.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(45, 150);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "Monogràfic Tipus:";
            // 
            // comboBoxEmpreses
            // 
            this.comboBoxEmpreses.FormattingEnabled = true;
            this.comboBoxEmpreses.Location = new System.Drawing.Point(143, 101);
            this.comboBoxEmpreses.Name = "comboBoxEmpreses";
            this.comboBoxEmpreses.Size = new System.Drawing.Size(168, 21);
            this.comboBoxEmpreses.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(71, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Empresa:";
            // 
            // numericUpDownHores
            // 
            this.numericUpDownHores.Location = new System.Drawing.Point(519, 49);
            this.numericUpDownHores.Name = "numericUpDownHores";
            this.numericUpDownHores.Size = new System.Drawing.Size(50, 20);
            this.numericUpDownHores.TabIndex = 3;
            // 
            // btAnular
            // 
            this.btAnular.Location = new System.Drawing.Point(548, 350);
            this.btAnular.Name = "btAnular";
            this.btAnular.Size = new System.Drawing.Size(75, 23);
            this.btAnular.TabIndex = 17;
            this.btAnular.Text = "Anul·lar";
            this.btAnular.UseVisualStyleBackColor = true;
            this.btAnular.Click += new System.EventHandler(this.btAnular_Click_1);
            // 
            // btEditarMonografic
            // 
            this.btEditarMonografic.Location = new System.Drawing.Point(372, 350);
            this.btEditarMonografic.Name = "btEditarMonografic";
            this.btEditarMonografic.Size = new System.Drawing.Size(112, 23);
            this.btEditarMonografic.TabIndex = 16;
            this.btEditarMonografic.Text = "Editar Monogràfic";
            this.btEditarMonografic.UseVisualStyleBackColor = true;
            this.btEditarMonografic.Click += new System.EventHandler(this.btEditarMonografic_Click);
            // 
            // txtBModalitat
            // 
            this.txtBModalitat.Location = new System.Drawing.Point(428, 293);
            this.txtBModalitat.Name = "txtBModalitat";
            this.txtBModalitat.Size = new System.Drawing.Size(100, 20);
            this.txtBModalitat.TabIndex = 13;
            this.txtBModalitat.Text = "Presencial";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(369, 296);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Modalitat:";
            // 
            // dtPickerDataFi
            // 
            this.dtPickerDataFi.Location = new System.Drawing.Point(385, 242);
            this.dtPickerDataFi.Name = "dtPickerDataFi";
            this.dtPickerDataFi.Size = new System.Drawing.Size(200, 20);
            this.dtPickerDataFi.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(358, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "al :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 248);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Durant els dies:";
            // 
            // dtPickerDataInici
            // 
            this.dtPickerDataInici.Location = new System.Drawing.Point(143, 242);
            this.dtPickerDataInici.Name = "dtPickerDataInici";
            this.dtPickerDataInici.Size = new System.Drawing.Size(200, 20);
            this.dtPickerDataInici.TabIndex = 10;
            // 
            // txtBCodi
            // 
            this.txtBCodi.Location = new System.Drawing.Point(300, 49);
            this.txtBCodi.Name = "txtBCodi";
            this.txtBCodi.Size = new System.Drawing.Size(100, 20);
            this.txtBCodi.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(425, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Total d\'hores:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(250, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Codi:";
            // 
            // txtBTitol
            // 
            this.txtBTitol.Location = new System.Drawing.Point(74, 49);
            this.txtBTitol.Name = "txtBTitol";
            this.txtBTitol.Size = new System.Drawing.Size(170, 20);
            this.txtBTitol.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Titol:";
            // 
            // checkBoxBonificat
            // 
            this.checkBoxBonificat.AutoSize = true;
            this.checkBoxBonificat.Location = new System.Drawing.Point(311, 327);
            this.checkBoxBonificat.Name = "checkBoxBonificat";
            this.checkBoxBonificat.Size = new System.Drawing.Size(122, 17);
            this.checkBoxBonificat.TabIndex = 14;
            this.checkBoxBonificat.Text = "Monogràfic bonificat";
            this.checkBoxBonificat.UseVisualStyleBackColor = true;
            // 
            // FormEditarMonografic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 396);
            this.Controls.Add(this.btEliminar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormEditarMonografic";
            this.Text = "AccésVertical Organizer";
            this.btEliminar.ResumeLayout(false);
            this.btEliminar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox btEliminar;
        private System.Windows.Forms.TextBox txtBHorari;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtBGrup;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtBCodiAF;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btEditorMonograficsTipus;
        private System.Windows.Forms.ComboBox comboBoxMonograficTipus;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxEmpreses;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDownHores;
        private System.Windows.Forms.Button btAnular;
        private System.Windows.Forms.Button btEditarMonografic;
        private System.Windows.Forms.TextBox txtBModalitat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtPickerDataFi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtPickerDataInici;
        private System.Windows.Forms.TextBox txtBCodi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBTitol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxUbicació;
        private System.Windows.Forms.CheckBox checkBFinalitzat;
        private System.Windows.Forms.CheckBox checkBoxBonificat;
    }
}