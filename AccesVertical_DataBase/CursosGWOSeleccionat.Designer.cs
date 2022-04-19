namespace AccesVertical_DataBase
{
    partial class CursosGWOSeleccionat
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btFinalitzar = new System.Windows.Forms.Button();
            this.btCanviar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxEstat = new System.Windows.Forms.ComboBox();
            this.dataGridViewCursosGWOdelSeleccionat = new System.Windows.Forms.DataGridView();
            this.dataGridViewTotsElsCursosGWO = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.btAfegir = new System.Windows.Forms.Button();
            this.lbNomAlumne = new System.Windows.Forms.Label();
            this.lbtostelscursos = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCursosGWOdelSeleccionat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTotsElsCursosGWO)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.btFinalitzar);
            this.groupBox1.Controls.Add(this.btCanviar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBoxEstat);
            this.groupBox1.Controls.Add(this.dataGridViewCursosGWOdelSeleccionat);
            this.groupBox1.Controls.Add(this.dataGridViewTotsElsCursosGWO);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.btAfegir);
            this.groupBox1.Controls.Add(this.lbNomAlumne);
            this.groupBox1.Controls.Add(this.lbtostelscursos);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1075, 368);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control de Cursos GWO";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btFinalitzar
            // 
            this.btFinalitzar.Location = new System.Drawing.Point(606, 269);
            this.btFinalitzar.Name = "btFinalitzar";
            this.btFinalitzar.Size = new System.Drawing.Size(75, 23);
            this.btFinalitzar.TabIndex = 11;
            this.btFinalitzar.Text = "Finalitzar";
            this.btFinalitzar.UseVisualStyleBackColor = true;
            this.btFinalitzar.Click += new System.EventHandler(this.btFinalitzar_Click);
            // 
            // btCanviar
            // 
            this.btCanviar.Location = new System.Drawing.Point(759, 212);
            this.btCanviar.Name = "btCanviar";
            this.btCanviar.Size = new System.Drawing.Size(75, 23);
            this.btCanviar.TabIndex = 10;
            this.btCanviar.Text = "Canviar";
            this.btCanviar.UseVisualStyleBackColor = true;
            this.btCanviar.Click += new System.EventHandler(this.btCanviar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(515, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Estat del Curs";
            // 
            // comboBoxEstat
            // 
            this.comboBoxEstat.FormattingEnabled = true;
            this.comboBoxEstat.Location = new System.Drawing.Point(606, 214);
            this.comboBoxEstat.Name = "comboBoxEstat";
            this.comboBoxEstat.Size = new System.Drawing.Size(121, 21);
            this.comboBoxEstat.TabIndex = 8;
            // 
            // dataGridViewCursosGWOdelSeleccionat
            // 
            this.dataGridViewCursosGWOdelSeleccionat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCursosGWOdelSeleccionat.Location = new System.Drawing.Point(606, 59);
            this.dataGridViewCursosGWOdelSeleccionat.MultiSelect = false;
            this.dataGridViewCursosGWOdelSeleccionat.Name = "dataGridViewCursosGWOdelSeleccionat";
            this.dataGridViewCursosGWOdelSeleccionat.ReadOnly = true;
            this.dataGridViewCursosGWOdelSeleccionat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCursosGWOdelSeleccionat.Size = new System.Drawing.Size(412, 123);
            this.dataGridViewCursosGWOdelSeleccionat.TabIndex = 7;
            this.dataGridViewCursosGWOdelSeleccionat.SelectionChanged += new System.EventHandler(this.dataGridViewCursosGWOdelSeleccionat_SelectionChanged_1);
            // 
            // dataGridViewTotsElsCursosGWO
            // 
            this.dataGridViewTotsElsCursosGWO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTotsElsCursosGWO.Location = new System.Drawing.Point(33, 59);
            this.dataGridViewTotsElsCursosGWO.Name = "dataGridViewTotsElsCursosGWO";
            this.dataGridViewTotsElsCursosGWO.ReadOnly = true;
            this.dataGridViewTotsElsCursosGWO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTotsElsCursosGWO.Size = new System.Drawing.Size(453, 299);
            this.dataGridViewTotsElsCursosGWO.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(492, 159);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Eliminar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btAfegir
            // 
            this.btAfegir.Location = new System.Drawing.Point(492, 119);
            this.btAfegir.Name = "btAfegir";
            this.btAfegir.Size = new System.Drawing.Size(75, 23);
            this.btAfegir.TabIndex = 4;
            this.btAfegir.Text = "Afegir >>";
            this.btAfegir.UseVisualStyleBackColor = true;
            this.btAfegir.Click += new System.EventHandler(this.btAfegir_Click);
            // 
            // lbNomAlumne
            // 
            this.lbNomAlumne.AutoSize = true;
            this.lbNomAlumne.Location = new System.Drawing.Point(603, 42);
            this.lbNomAlumne.Name = "lbNomAlumne";
            this.lbNomAlumne.Size = new System.Drawing.Size(87, 13);
            this.lbNomAlumne.TabIndex = 3;
            this.lbNomAlumne.Text = "Cursos GWO de ";
            // 
            // lbtostelscursos
            // 
            this.lbtostelscursos.AutoSize = true;
            this.lbtostelscursos.Location = new System.Drawing.Point(30, 43);
            this.lbtostelscursos.Name = "lbtostelscursos";
            this.lbtostelscursos.Size = new System.Drawing.Size(78, 13);
            this.lbtostelscursos.TabIndex = 2;
            this.lbtostelscursos.Text = "Tots els cursos";
            // 
            // CursosGWOSeleccionat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 368);
            this.Controls.Add(this.groupBox1);
            this.Name = "CursosGWOSeleccionat";
            this.Text = "CursosGWOSeleccionat";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCursosGWOdelSeleccionat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTotsElsCursosGWO)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btFinalitzar;
        private System.Windows.Forms.Button btCanviar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxEstat;
        private System.Windows.Forms.DataGridView dataGridViewCursosGWOdelSeleccionat;
        private System.Windows.Forms.DataGridView dataGridViewTotsElsCursosGWO;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btAfegir;
        private System.Windows.Forms.Label lbNomAlumne;
        private System.Windows.Forms.Label lbtostelscursos;
    }
}