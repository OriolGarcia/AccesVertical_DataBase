namespace AccesVertical_DataBase
{
    partial class FormCanviInformatEmpreses
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCanviInformatEmpreses));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxInformat = new System.Windows.Forms.ComboBox();
            this.btMarcarCanvi = new System.Windows.Forms.Button();
            this.lbInformacio = new System.Windows.Forms.Label();
            this.btAnular = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxInformat);
            this.groupBox1.Controls.Add(this.btMarcarCanvi);
            this.groupBox1.Controls.Add(this.lbInformacio);
            this.groupBox1.Controls.Add(this.btAnular);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(369, 261);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controls d\'Informació a Empreses";
            // 
            // comboBoxInformat
            // 
            this.comboBoxInformat.FormattingEnabled = true;
            this.comboBoxInformat.Location = new System.Drawing.Point(162, 109);
            this.comboBoxInformat.Name = "comboBoxInformat";
            this.comboBoxInformat.Size = new System.Drawing.Size(121, 21);
            this.comboBoxInformat.TabIndex = 0;
            // 
            // btMarcarCanvi
            // 
            this.btMarcarCanvi.Location = new System.Drawing.Point(65, 177);
            this.btMarcarCanvi.Name = "btMarcarCanvi";
            this.btMarcarCanvi.Size = new System.Drawing.Size(139, 23);
            this.btMarcarCanvi.TabIndex = 2;
            this.btMarcarCanvi.Text = "Marcar canvi";
            this.btMarcarCanvi.UseVisualStyleBackColor = true;
            this.btMarcarCanvi.Click += new System.EventHandler(this.btMarcarCanvi_Click);
            // 
            // lbInformacio
            // 
            this.lbInformacio.AutoSize = true;
            this.lbInformacio.Location = new System.Drawing.Point(159, 56);
            this.lbInformacio.Name = "lbInformacio";
            this.lbInformacio.Size = new System.Drawing.Size(0, 13);
            this.lbInformacio.TabIndex = 4;
            // 
            // btAnular
            // 
            this.btAnular.Location = new System.Drawing.Point(227, 177);
            this.btAnular.Name = "btAnular";
            this.btAnular.Size = new System.Drawing.Size(75, 23);
            this.btAnular.TabIndex = 3;
            this.btAnular.Text = "Anul·lar";
            this.btAnular.UseVisualStyleBackColor = true;
            this.btAnular.Click += new System.EventHandler(this.btAnular_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Marcar com a:";
            // 
            // FormCanviInformatEmpreses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 261);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCanviInformatEmpreses";
            this.Text = "AccésVertical Organizer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxInformat;
        private System.Windows.Forms.Button btMarcarCanvi;
        private System.Windows.Forms.Label lbInformacio;
        private System.Windows.Forms.Button btAnular;
        private System.Windows.Forms.Label label1;
    }
}