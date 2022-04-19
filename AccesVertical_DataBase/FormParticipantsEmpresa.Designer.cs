namespace AccesVertical_DataBase
{
    partial class FormParticipantsEmpresa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormParticipantsEmpresa));
            this.C = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DNIBOX = new System.Windows.Forms.TextBox();
            this.COGNOMSBOX = new System.Windows.Forms.TextBox();
            this.lbCognoms = new System.Windows.Forms.Label();
            this.NOMBOX = new System.Windows.Forms.TextBox();
            this.lbDNI = new System.Windows.Forms.Label();
            this.txtBNOM = new System.Windows.Forms.Label();
            this.btTancar = new System.Windows.Forms.Button();
            this.btCanviarEmpresa = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxEmpresa = new System.Windows.Forms.ComboBox();
            this.dataGridViewTotsElsParticipants = new System.Windows.Forms.DataGridView();
            this.C.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTotsElsParticipants)).BeginInit();
            this.SuspendLayout();
            // 
            // C
            // 
            this.C.Controls.Add(this.groupBox1);
            this.C.Controls.Add(this.btTancar);
            this.C.Controls.Add(this.btCanviarEmpresa);
            this.C.Controls.Add(this.label1);
            this.C.Controls.Add(this.comboBoxEmpresa);
            this.C.Controls.Add(this.dataGridViewTotsElsParticipants);
            this.C.Dock = System.Windows.Forms.DockStyle.Fill;
            this.C.Location = new System.Drawing.Point(0, 0);
            this.C.Name = "C";
            this.C.Size = new System.Drawing.Size(628, 384);
            this.C.TabIndex = 1;
            this.C.TabStop = false;
            this.C.Text = "PARTICIPANTS MONOGRÀFICS I EMPRESES";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DNIBOX);
            this.groupBox1.Controls.Add(this.COGNOMSBOX);
            this.groupBox1.Controls.Add(this.lbCognoms);
            this.groupBox1.Controls.Add(this.NOMBOX);
            this.groupBox1.Controls.Add(this.lbDNI);
            this.groupBox1.Controls.Add(this.txtBNOM);
            this.groupBox1.Location = new System.Drawing.Point(261, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(331, 114);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cerca Avançada";
            // 
            // DNIBOX
            // 
            this.DNIBOX.Location = new System.Drawing.Point(66, 70);
            this.DNIBOX.Name = "DNIBOX";
            this.DNIBOX.Size = new System.Drawing.Size(100, 20);
            this.DNIBOX.TabIndex = 5;
            // 
            // COGNOMSBOX
            // 
            this.COGNOMSBOX.Location = new System.Drawing.Point(213, 35);
            this.COGNOMSBOX.Name = "COGNOMSBOX";
            this.COGNOMSBOX.Size = new System.Drawing.Size(92, 20);
            this.COGNOMSBOX.TabIndex = 4;
            // 
            // lbCognoms
            // 
            this.lbCognoms.AutoSize = true;
            this.lbCognoms.Location = new System.Drawing.Point(157, 38);
            this.lbCognoms.Name = "lbCognoms";
            this.lbCognoms.Size = new System.Drawing.Size(54, 13);
            this.lbCognoms.TabIndex = 3;
            this.lbCognoms.Text = "Cognoms:";
            // 
            // NOMBOX
            // 
            this.NOMBOX.Location = new System.Drawing.Point(66, 35);
            this.NOMBOX.Name = "NOMBOX";
            this.NOMBOX.Size = new System.Drawing.Size(76, 20);
            this.NOMBOX.TabIndex = 2;
            // 
            // lbDNI
            // 
            this.lbDNI.AutoSize = true;
            this.lbDNI.Location = new System.Drawing.Point(28, 73);
            this.lbDNI.Name = "lbDNI";
            this.lbDNI.Size = new System.Drawing.Size(29, 13);
            this.lbDNI.TabIndex = 1;
            this.lbDNI.Text = "DNI:";
            // 
            // txtBNOM
            // 
            this.txtBNOM.AutoSize = true;
            this.txtBNOM.Location = new System.Drawing.Point(25, 38);
            this.txtBNOM.Name = "txtBNOM";
            this.txtBNOM.Size = new System.Drawing.Size(32, 13);
            this.txtBNOM.TabIndex = 0;
            this.txtBNOM.Text = "Nom:";
            // 
            // btTancar
            // 
            this.btTancar.Location = new System.Drawing.Point(433, 324);
            this.btTancar.Name = "btTancar";
            this.btTancar.Size = new System.Drawing.Size(75, 23);
            this.btTancar.TabIndex = 4;
            this.btTancar.Text = "Tancar";
            this.btTancar.UseVisualStyleBackColor = true;
            this.btTancar.Click += new System.EventHandler(this.btTancar_Click);
            // 
            // btCanviarEmpresa
            // 
            this.btCanviarEmpresa.Location = new System.Drawing.Point(310, 226);
            this.btCanviarEmpresa.Name = "btCanviarEmpresa";
            this.btCanviarEmpresa.Size = new System.Drawing.Size(75, 23);
            this.btCanviarEmpresa.TabIndex = 3;
            this.btCanviarEmpresa.Text = "Canviar assignació";
            this.btCanviarEmpresa.UseVisualStyleBackColor = true;
            this.btCanviarEmpresa.Click += new System.EventHandler(this.btCanviarEmpresa_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(258, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Té assignada la Empresa:";
            // 
            // comboBoxEmpresa
            // 
            this.comboBoxEmpresa.FormattingEnabled = true;
            this.comboBoxEmpresa.Location = new System.Drawing.Point(310, 180);
            this.comboBoxEmpresa.Name = "comboBoxEmpresa";
            this.comboBoxEmpresa.Size = new System.Drawing.Size(198, 21);
            this.comboBoxEmpresa.TabIndex = 1;
            // 
            // dataGridViewTotsElsParticipants
            // 
            this.dataGridViewTotsElsParticipants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTotsElsParticipants.Location = new System.Drawing.Point(12, 19);
            this.dataGridViewTotsElsParticipants.Name = "dataGridViewTotsElsParticipants";
            this.dataGridViewTotsElsParticipants.ReadOnly = true;
            this.dataGridViewTotsElsParticipants.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTotsElsParticipants.Size = new System.Drawing.Size(240, 328);
            this.dataGridViewTotsElsParticipants.TabIndex = 0;
            this.dataGridViewTotsElsParticipants.SelectionChanged += new System.EventHandler(this.dataGridViewTotsElsParticipants_SelectionChanged);
            // 
            // FormParticipantsEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 384);
            this.Controls.Add(this.C);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormParticipantsEmpresa";
            this.Text = "AccesVertical Organizer";
            this.C.ResumeLayout(false);
            this.C.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTotsElsParticipants)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox C;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox DNIBOX;
        private System.Windows.Forms.TextBox COGNOMSBOX;
        private System.Windows.Forms.Label lbCognoms;
        private System.Windows.Forms.TextBox NOMBOX;
        private System.Windows.Forms.Label lbDNI;
        private System.Windows.Forms.Label txtBNOM;
        private System.Windows.Forms.Button btTancar;
        private System.Windows.Forms.Button btCanviarEmpresa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxEmpresa;
        private System.Windows.Forms.DataGridView dataGridViewTotsElsParticipants;
    }
}