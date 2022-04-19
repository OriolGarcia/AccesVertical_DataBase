namespace AccesVertical_DataBase
{
    partial class FormEditarContingut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditarContingut));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btInserir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxTipusModul = new System.Windows.Forms.ComboBox();
            this.txtBSubtitols = new System.Windows.Forms.TextBox();
            this.txtBTitol = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.btInserir);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBoxTipusModul);
            this.groupBox1.Controls.Add(this.txtBSubtitols);
            this.groupBox1.Controls.Add(this.txtBTitol);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(590, 192);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Editar Contingut per als Monogràfics";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(464, 141);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Anul·lar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btInserir
            // 
            this.btInserir.Location = new System.Drawing.Point(344, 141);
            this.btInserir.Name = "btInserir";
            this.btInserir.Size = new System.Drawing.Size(100, 23);
            this.btInserir.TabIndex = 6;
            this.btInserir.Text = "Editar Contingut";
            this.btInserir.UseVisualStyleBackColor = true;
            this.btInserir.Click += new System.EventHandler(this.btInserir_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(325, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tipus de modul:";
            // 
            // comboBoxTipusModul
            // 
            this.comboBoxTipusModul.FormattingEnabled = true;
            this.comboBoxTipusModul.Location = new System.Drawing.Point(418, 77);
            this.comboBoxTipusModul.Name = "comboBoxTipusModul";
            this.comboBoxTipusModul.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTipusModul.TabIndex = 4;
            // 
            // txtBSubtitols
            // 
            this.txtBSubtitols.Location = new System.Drawing.Point(76, 77);
            this.txtBSubtitols.Multiline = true;
            this.txtBSubtitols.Name = "txtBSubtitols";
            this.txtBSubtitols.Size = new System.Drawing.Size(212, 61);
            this.txtBSubtitols.TabIndex = 3;
            // 
            // txtBTitol
            // 
            this.txtBTitol.Location = new System.Drawing.Point(66, 43);
            this.txtBTitol.Name = "txtBTitol";
            this.txtBTitol.Size = new System.Drawing.Size(222, 20);
            this.txtBTitol.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Subtitols:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Titol:";
            // 
            // FormEditarContingut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 192);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormEditarContingut";
            this.Text = "FormEditarContingut";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btInserir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxTipusModul;
        private System.Windows.Forms.TextBox txtBSubtitols;
        private System.Windows.Forms.TextBox txtBTitol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}