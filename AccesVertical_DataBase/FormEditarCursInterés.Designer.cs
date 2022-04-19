namespace AccesVertical_DataBase
{
    partial class FormEditarCursInterés
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditarCursInterés));
            this.btEliminarCursTipus = new System.Windows.Forms.Button();
            this.comboBoxCursTipus = new System.Windows.Forms.ComboBox();
            this.btNouCursInteres = new System.Windows.Forms.Button();
            this.btCanviarTitol = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBNom = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btEliminarCursTipus
            // 
            this.btEliminarCursTipus.Location = new System.Drawing.Point(551, 33);
            this.btEliminarCursTipus.Name = "btEliminarCursTipus";
            this.btEliminarCursTipus.Size = new System.Drawing.Size(181, 23);
            this.btEliminarCursTipus.TabIndex = 34;
            this.btEliminarCursTipus.Text = "Eliminar Curs d\'interès";
            this.btEliminarCursTipus.UseVisualStyleBackColor = true;
            this.btEliminarCursTipus.Click += new System.EventHandler(this.btEliminarCursTipus_Click);
            // 
            // comboBoxCursTipus
            // 
            this.comboBoxCursTipus.FormattingEnabled = true;
            this.comboBoxCursTipus.Location = new System.Drawing.Point(52, 35);
            this.comboBoxCursTipus.Name = "comboBoxCursTipus";
            this.comboBoxCursTipus.Size = new System.Drawing.Size(308, 21);
            this.comboBoxCursTipus.TabIndex = 33;
            this.comboBoxCursTipus.SelectedIndexChanged += new System.EventHandler(this.comboBoxCursTipus_SelectedIndexChanged);
            // 
            // btNouCursInteres
            // 
            this.btNouCursInteres.Location = new System.Drawing.Point(366, 33);
            this.btNouCursInteres.Name = "btNouCursInteres";
            this.btNouCursInteres.Size = new System.Drawing.Size(178, 23);
            this.btNouCursInteres.TabIndex = 32;
            this.btNouCursInteres.Text = "Afegir Nou Curs d\'interès";
            this.btNouCursInteres.UseVisualStyleBackColor = true;
            this.btNouCursInteres.Click += new System.EventHandler(this.btNouCursInteres_Click);
            // 
            // btCanviarTitol
            // 
            this.btCanviarTitol.Location = new System.Drawing.Point(334, 40);
            this.btCanviarTitol.Name = "btCanviarTitol";
            this.btCanviarTitol.Size = new System.Drawing.Size(75, 23);
            this.btCanviarTitol.TabIndex = 37;
            this.btCanviarTitol.Text = "Canviar Titol";
            this.btCanviarTitol.UseVisualStyleBackColor = true;
            this.btCanviarTitol.Click += new System.EventHandler(this.btCanviarTitol_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Titol:";
            // 
            // txtBNom
            // 
            this.txtBNom.Location = new System.Drawing.Point(75, 42);
            this.txtBNom.Name = "txtBNom";
            this.txtBNom.Size = new System.Drawing.Size(238, 20);
            this.txtBNom.TabIndex = 36;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(340, 163);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 38;
            this.button1.Text = "Tancar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtBNom);
            this.groupBox1.Controls.Add(this.btCanviarTitol);
            this.groupBox1.Location = new System.Drawing.Point(52, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(680, 82);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Canviar Titol";
            // 
            // FormEditarCursInterés
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 198);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btEliminarCursTipus);
            this.Controls.Add(this.comboBoxCursTipus);
            this.Controls.Add(this.btNouCursInteres);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormEditarCursInterés";
            this.Text = "AccésVertical Organizer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btEliminarCursTipus;
        private System.Windows.Forms.ComboBox comboBoxCursTipus;
        private System.Windows.Forms.Button btNouCursInteres;
        private System.Windows.Forms.Button btCanviarTitol;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBNom;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}