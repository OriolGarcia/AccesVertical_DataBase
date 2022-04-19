namespace AccesVertical_DataBase
{
    partial class FormSeleccionarParticipanst
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSeleccionarParticipanst));
            this.lbTitolMonografic = new System.Windows.Forms.Label();
            this.lbSelempresa = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBoxEmpresa = new System.Windows.Forms.ComboBox();
            this.btTancar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBDNIParticipants = new System.Windows.Forms.TextBox();
            this.txtBNomParticip = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.txtBCognomsParticipants = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitolMonografic
            // 
            this.lbTitolMonografic.AutoSize = true;
            this.lbTitolMonografic.Location = new System.Drawing.Point(32, 26);
            this.lbTitolMonografic.Name = "lbTitolMonografic";
            this.lbTitolMonografic.Size = new System.Drawing.Size(35, 13);
            this.lbTitolMonografic.TabIndex = 0;
            this.lbTitolMonografic.Text = "label1";
            // 
            // lbSelempresa
            // 
            this.lbSelempresa.AutoSize = true;
            this.lbSelempresa.Location = new System.Drawing.Point(32, 54);
            this.lbSelempresa.Name = "lbSelempresa";
            this.lbSelempresa.Size = new System.Drawing.Size(152, 13);
            this.lbSelempresa.TabIndex = 1;
            this.lbSelempresa.Text = "Els Participants de la Empresa:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(72, 87);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(443, 270);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.BindingContextChanged += new System.EventHandler(this.dataGridView1_BindingContextChanged);
            // 
            // comboBoxEmpresa
            // 
            this.comboBoxEmpresa.FormattingEnabled = true;
            this.comboBoxEmpresa.Location = new System.Drawing.Point(190, 51);
            this.comboBoxEmpresa.Name = "comboBoxEmpresa";
            this.comboBoxEmpresa.Size = new System.Drawing.Size(325, 21);
            this.comboBoxEmpresa.TabIndex = 3;
            this.comboBoxEmpresa.SelectedIndexChanged += new System.EventHandler(this.comboBoxEmpresa_SelectedIndexChanged);
            // 
            // btTancar
            // 
            this.btTancar.Location = new System.Drawing.Point(258, 376);
            this.btTancar.Name = "btTancar";
            this.btTancar.Size = new System.Drawing.Size(75, 23);
            this.btTancar.TabIndex = 4;
            this.btTancar.Text = "Tancar";
            this.btTancar.UseVisualStyleBackColor = true;
            this.btTancar.Click += new System.EventHandler(this.btTancar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBDNIParticipants);
            this.groupBox1.Controls.Add(this.txtBNomParticip);
            this.groupBox1.Controls.Add(this.label44);
            this.groupBox1.Controls.Add(this.label46);
            this.groupBox1.Controls.Add(this.txtBCognomsParticipants);
            this.groupBox1.Controls.Add(this.label45);
            this.groupBox1.Location = new System.Drawing.Point(535, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(242, 270);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cerca Avançada";
            // 
            // txtBDNIParticipants
            // 
            this.txtBDNIParticipants.Location = new System.Drawing.Point(64, 110);
            this.txtBDNIParticipants.Name = "txtBDNIParticipants";
            this.txtBDNIParticipants.Size = new System.Drawing.Size(100, 20);
            this.txtBDNIParticipants.TabIndex = 11;
            this.txtBDNIParticipants.TextChanged += new System.EventHandler(this.txtBDNIParticipants_TextChanged);
            // 
            // txtBNomParticip
            // 
            this.txtBNomParticip.Location = new System.Drawing.Point(64, 34);
            this.txtBNomParticip.Name = "txtBNomParticip";
            this.txtBNomParticip.Size = new System.Drawing.Size(100, 20);
            this.txtBNomParticip.TabIndex = 7;
            this.txtBNomParticip.TextChanged += new System.EventHandler(this.txtBNomParticip_TextChanged);
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(32, 113);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(29, 13);
            this.label44.TabIndex = 10;
            this.label44.Text = "DNI:";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(23, 37);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(32, 13);
            this.label46.TabIndex = 6;
            this.label46.Text = "Nom:";
            // 
            // txtBCognomsParticipants
            // 
            this.txtBCognomsParticipants.Location = new System.Drawing.Point(64, 72);
            this.txtBCognomsParticipants.Name = "txtBCognomsParticipants";
            this.txtBCognomsParticipants.Size = new System.Drawing.Size(100, 20);
            this.txtBCognomsParticipants.TabIndex = 9;
            this.txtBCognomsParticipants.TextChanged += new System.EventHandler(this.txtBCognomsParticipants_TextChanged);
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(7, 75);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(54, 13);
            this.label45.TabIndex = 8;
            this.label45.Text = "Cognoms:";
            // 
            // FormSeleccionarParticipanst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 411);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btTancar);
            this.Controls.Add(this.comboBoxEmpresa);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lbSelempresa);
            this.Controls.Add(this.lbTitolMonografic);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSeleccionarParticipanst";
            this.Text = "AccésVertical Organizer";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitolMonografic;
        private System.Windows.Forms.Label lbSelempresa;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBoxEmpresa;
        private System.Windows.Forms.Button btTancar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBDNIParticipants;
        private System.Windows.Forms.TextBox txtBNomParticip;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.TextBox txtBCognomsParticipants;
        private System.Windows.Forms.Label label45;
    }
}