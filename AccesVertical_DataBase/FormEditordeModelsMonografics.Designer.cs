namespace AccesVertical_DataBase
{
    partial class FormEditordeModelsMonografics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditordeModelsMonografics));
            this.btNouContingut = new System.Windows.Forms.Button();
            this.btTreure = new System.Windows.Forms.Button();
            this.btAfegir = new System.Windows.Forms.Button();
            this.dataGridViewTotContingut = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.btEliminar = new System.Windows.Forms.GroupBox();
            this.btEliminarMonograficTipus = new System.Windows.Forms.Button();
            this.comboBoxMonograficTipus = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBCercaTitol = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.btCanviarTitol = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBTitol = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridViewContingutMonografic = new System.Windows.Forms.DataGridView();
            this.btEliminarContingut = new System.Windows.Forms.Button();
            this.btEditarContingut = new System.Windows.Forms.Button();
            this.btNouMonograficModel = new System.Windows.Forms.Button();
            this.btTancarEditor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTotContingut)).BeginInit();
            this.btEliminar.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContingutMonografic)).BeginInit();
            this.SuspendLayout();
            // 
            // btNouContingut
            // 
            this.btNouContingut.Location = new System.Drawing.Point(658, 274);
            this.btNouContingut.Name = "btNouContingut";
            this.btNouContingut.Size = new System.Drawing.Size(75, 36);
            this.btNouContingut.TabIndex = 17;
            this.btNouContingut.Text = "Nou Contingut";
            this.btNouContingut.UseVisualStyleBackColor = true;
            this.btNouContingut.Click += new System.EventHandler(this.btNouContingut_Click);
            // 
            // btTreure
            // 
            this.btTreure.Location = new System.Drawing.Point(659, 245);
            this.btTreure.Name = "btTreure";
            this.btTreure.Size = new System.Drawing.Size(75, 23);
            this.btTreure.TabIndex = 16;
            this.btTreure.Text = "<< Treure";
            this.btTreure.UseVisualStyleBackColor = true;
            this.btTreure.Click += new System.EventHandler(this.btTreure_Click_1);
            // 
            // btAfegir
            // 
            this.btAfegir.Location = new System.Drawing.Point(659, 215);
            this.btAfegir.Name = "btAfegir";
            this.btAfegir.Size = new System.Drawing.Size(75, 23);
            this.btAfegir.TabIndex = 15;
            this.btAfegir.Text = "Afegir >>";
            this.btAfegir.UseVisualStyleBackColor = true;
            this.btAfegir.Click += new System.EventHandler(this.btAfegir_Click_1);
            // 
            // dataGridViewTotContingut
            // 
            this.dataGridViewTotContingut.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTotContingut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTotContingut.Location = new System.Drawing.Point(25, 184);
            this.dataGridViewTotContingut.Name = "dataGridViewTotContingut";
            this.dataGridViewTotContingut.ReadOnly = true;
            this.dataGridViewTotContingut.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTotContingut.Size = new System.Drawing.Size(629, 275);
            this.dataGridViewTotContingut.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Tots els continguts:";
            // 
            // btEliminar
            // 
            this.btEliminar.Controls.Add(this.btEliminarMonograficTipus);
            this.btEliminar.Controls.Add(this.comboBoxMonograficTipus);
            this.btEliminar.Controls.Add(this.groupBox1);
            this.btEliminar.Controls.Add(this.btNouMonograficModel);
            this.btEliminar.Controls.Add(this.btTancarEditor);
            this.btEliminar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btEliminar.Location = new System.Drawing.Point(0, 0);
            this.btEliminar.Name = "btEliminar";
            this.btEliminar.Size = new System.Drawing.Size(1362, 679);
            this.btEliminar.TabIndex = 1;
            this.btEliminar.TabStop = false;
            this.btEliminar.Text = "Controls de Creació de nou Monogràfic";
            // 
            // btEliminarMonograficTipus
            // 
            this.btEliminarMonograficTipus.Location = new System.Drawing.Point(544, 40);
            this.btEliminarMonograficTipus.Name = "btEliminarMonograficTipus";
            this.btEliminarMonograficTipus.Size = new System.Drawing.Size(181, 23);
            this.btEliminarMonograficTipus.TabIndex = 31;
            this.btEliminarMonograficTipus.Text = "Eliminar Monogràfic Tipus";
            this.btEliminarMonograficTipus.UseVisualStyleBackColor = true;
            this.btEliminarMonograficTipus.Click += new System.EventHandler(this.btEliminarMonograficTipus_Click);
            // 
            // comboBoxMonograficTipus
            // 
            this.comboBoxMonograficTipus.FormattingEnabled = true;
            this.comboBoxMonograficTipus.Location = new System.Drawing.Point(45, 42);
            this.comboBoxMonograficTipus.Name = "comboBoxMonograficTipus";
            this.comboBoxMonograficTipus.Size = new System.Drawing.Size(308, 21);
            this.comboBoxMonograficTipus.TabIndex = 30;
            this.comboBoxMonograficTipus.SelectedIndexChanged += new System.EventHandler(this.comboBoxMonograficTipus_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtBCercaTitol);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.trackBar1);
            this.groupBox1.Controls.Add(this.btCanviarTitol);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtBTitol);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.dataGridViewTotContingut);
            this.groupBox1.Controls.Add(this.dataGridViewContingutMonografic);
            this.groupBox1.Controls.Add(this.btAfegir);
            this.groupBox1.Controls.Add(this.btEliminarContingut);
            this.groupBox1.Controls.Add(this.btTreure);
            this.groupBox1.Controls.Add(this.btEditarContingut);
            this.groupBox1.Controls.Add(this.btNouContingut);
            this.groupBox1.Location = new System.Drawing.Point(45, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1305, 520);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Model de monogràfic Seleccionat";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(59, 482);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Cerca per titol:";
            // 
            // txtBCercaTitol
            // 
            this.txtBCercaTitol.Location = new System.Drawing.Point(159, 479);
            this.txtBCercaTitol.Name = "txtBCercaTitol";
            this.txtBCercaTitol.Size = new System.Drawing.Size(100, 20);
            this.txtBCercaTitol.TabIndex = 27;
            this.txtBCercaTitol.TextChanged += new System.EventHandler(this.txtBCercaTitol_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(391, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(365, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Percentatge Pràctic";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Percentatge Teòric";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(135, 83);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(224, 45);
            this.trackBar1.TabIndex = 22;
            this.trackBar1.Value = 20;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // btCanviarTitol
            // 
            this.btCanviarTitol.Location = new System.Drawing.Point(339, 23);
            this.btCanviarTitol.Name = "btCanviarTitol";
            this.btCanviarTitol.Size = new System.Drawing.Size(75, 23);
            this.btCanviarTitol.TabIndex = 21;
            this.btCanviarTitol.Text = "Canviar Titol";
            this.btCanviarTitol.UseVisualStyleBackColor = true;
            this.btCanviarTitol.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Titol:";
            // 
            // txtBTitol
            // 
            this.txtBTitol.Location = new System.Drawing.Point(80, 25);
            this.txtBTitol.Name = "txtBTitol";
            this.txtBTitol.Size = new System.Drawing.Size(238, 20);
            this.txtBTitol.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(523, 156);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(165, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Continguts del Monogràfic Model:";
            // 
            // dataGridViewContingutMonografic
            // 
            this.dataGridViewContingutMonografic.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewContingutMonografic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewContingutMonografic.Location = new System.Drawing.Point(740, 184);
            this.dataGridViewContingutMonografic.Name = "dataGridViewContingutMonografic";
            this.dataGridViewContingutMonografic.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewContingutMonografic.Size = new System.Drawing.Size(523, 275);
            this.dataGridViewContingutMonografic.TabIndex = 20;
            // 
            // btEliminarContingut
            // 
            this.btEliminarContingut.Location = new System.Drawing.Point(660, 346);
            this.btEliminarContingut.Name = "btEliminarContingut";
            this.btEliminarContingut.Size = new System.Drawing.Size(75, 23);
            this.btEliminarContingut.TabIndex = 19;
            this.btEliminarContingut.Text = "Eliminar Contingut";
            this.btEliminarContingut.UseVisualStyleBackColor = true;
            this.btEliminarContingut.Click += new System.EventHandler(this.btEliminarContingut_Click_1);
            // 
            // btEditarContingut
            // 
            this.btEditarContingut.Location = new System.Drawing.Point(659, 317);
            this.btEditarContingut.Name = "btEditarContingut";
            this.btEditarContingut.Size = new System.Drawing.Size(75, 23);
            this.btEditarContingut.TabIndex = 18;
            this.btEditarContingut.Text = "Editar Contingut";
            this.btEditarContingut.UseVisualStyleBackColor = true;
            this.btEditarContingut.Click += new System.EventHandler(this.btEditarContingut_Click_1);
            // 
            // btNouMonograficModel
            // 
            this.btNouMonograficModel.Location = new System.Drawing.Point(359, 40);
            this.btNouMonograficModel.Name = "btNouMonograficModel";
            this.btNouMonograficModel.Size = new System.Drawing.Size(178, 23);
            this.btNouMonograficModel.TabIndex = 24;
            this.btNouMonograficModel.Text = "Crear nou Monogràfic Tipus";
            this.btNouMonograficModel.UseVisualStyleBackColor = true;
            this.btNouMonograficModel.Click += new System.EventHandler(this.btNouMonograficModel_Click);
            // 
            // btTancarEditor
            // 
            this.btTancarEditor.Location = new System.Drawing.Point(613, 614);
            this.btTancarEditor.Name = "btTancarEditor";
            this.btTancarEditor.Size = new System.Drawing.Size(112, 23);
            this.btTancarEditor.TabIndex = 21;
            this.btTancarEditor.Text = "Tancar Editor";
            this.btTancarEditor.UseVisualStyleBackColor = true;
            this.btTancarEditor.Click += new System.EventHandler(this.btTancarEditor_Click);
            // 
            // FormEditordeModelsMonografics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 679);
            this.Controls.Add(this.btEliminar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormEditordeModelsMonografics";
            this.Text = "AccésVertical Organizer";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTotContingut)).EndInit();
            this.btEliminar.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContingutMonografic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btNouContingut;
        private System.Windows.Forms.Button btTreure;
        private System.Windows.Forms.Button btAfegir;
        private System.Windows.Forms.DataGridView dataGridViewTotContingut;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox btEliminar;
        private System.Windows.Forms.Button btTancarEditor;
        private System.Windows.Forms.DataGridView dataGridViewContingutMonografic;
        private System.Windows.Forms.Button btEliminarContingut;
        private System.Windows.Forms.Button btEditarContingut;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBTitol;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btNouMonograficModel;
        private System.Windows.Forms.Button btCanviarTitol;
        private System.Windows.Forms.ComboBox comboBoxMonograficTipus;
        private System.Windows.Forms.Button btEliminarMonograficTipus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBCercaTitol;
    }
}