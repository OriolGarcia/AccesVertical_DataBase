namespace AccesVertical_DataBase
{
    partial class CursosSeleccionat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CursosSeleccionat));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btFinalitzar = new System.Windows.Forms.Button();
            this.btCanviar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxEstat = new System.Windows.Forms.ComboBox();
            this.dataGridViewCursosdelSeleccionat = new System.Windows.Forms.DataGridView();
            this.dataGridViewTotsElsCursos = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.btAfegir = new System.Windows.Forms.Button();
            this.lbNomAlumne = new System.Windows.Forms.Label();
            this.lbtostelscursos = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCursosdelSeleccionat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTotsElsCursos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.btFinalitzar);
            this.groupBox1.Controls.Add(this.btCanviar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBoxEstat);
            this.groupBox1.Controls.Add(this.dataGridViewCursosdelSeleccionat);
            this.groupBox1.Controls.Add(this.dataGridViewTotsElsCursos);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.btAfegir);
            this.groupBox1.Controls.Add(this.lbNomAlumne);
            this.groupBox1.Controls.Add(this.lbtostelscursos);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1084, 411);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control de Cursos";
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
            this.btCanviar.Click += new System.EventHandler(this.button1_Click_1);
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
            this.comboBoxEstat.SelectedIndexChanged += new System.EventHandler(this.comboBoxEstat_SelectedIndexChanged);
            // 
            // dataGridViewCursosdelSeleccionat
            // 
            this.dataGridViewCursosdelSeleccionat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCursosdelSeleccionat.Location = new System.Drawing.Point(606, 59);
            this.dataGridViewCursosdelSeleccionat.MultiSelect = false;
            this.dataGridViewCursosdelSeleccionat.Name = "dataGridViewCursosdelSeleccionat";
            this.dataGridViewCursosdelSeleccionat.ReadOnly = true;
            this.dataGridViewCursosdelSeleccionat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCursosdelSeleccionat.Size = new System.Drawing.Size(412, 123);
            this.dataGridViewCursosdelSeleccionat.TabIndex = 7;
            this.dataGridViewCursosdelSeleccionat.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCursosdelSeleccionat_CellContentClick);
            this.dataGridViewCursosdelSeleccionat.SelectionChanged += new System.EventHandler(this.dataGridViewCursosdelSeleccionat_SelectionChanged);
            // 
            // dataGridViewTotsElsCursos
            // 
            this.dataGridViewTotsElsCursos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTotsElsCursos.Location = new System.Drawing.Point(33, 59);
            this.dataGridViewTotsElsCursos.Name = "dataGridViewTotsElsCursos";
            this.dataGridViewTotsElsCursos.ReadOnly = true;
            this.dataGridViewTotsElsCursos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTotsElsCursos.Size = new System.Drawing.Size(453, 299);
            this.dataGridViewTotsElsCursos.TabIndex = 6;
            this.dataGridViewTotsElsCursos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTotsElsCursos_CellContentClick);
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
            this.btAfegir.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbNomAlumne
            // 
            this.lbNomAlumne.AutoSize = true;
            this.lbNomAlumne.Location = new System.Drawing.Point(603, 42);
            this.lbNomAlumne.Name = "lbNomAlumne";
            this.lbNomAlumne.Size = new System.Drawing.Size(57, 13);
            this.lbNomAlumne.TabIndex = 3;
            this.lbNomAlumne.Text = "Cursos de ";
            this.lbNomAlumne.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // lbtostelscursos
            // 
            this.lbtostelscursos.AutoSize = true;
            this.lbtostelscursos.Location = new System.Drawing.Point(30, 43);
            this.lbtostelscursos.Name = "lbtostelscursos";
            this.lbtostelscursos.Size = new System.Drawing.Size(78, 13);
            this.lbtostelscursos.TabIndex = 2;
            this.lbtostelscursos.Text = "Tots els cursos";
            this.lbtostelscursos.Click += new System.EventHandler(this.label1_Click);
            // 
            // CursosSeleccionat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 411);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1100, 450);
            this.MinimumSize = new System.Drawing.Size(1100, 450);
            this.Name = "CursosSeleccionat";
            this.Text = "AccésVertical Organizer";
            this.Load += new System.EventHandler(this.CursosSeleccionat_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCursosdelSeleccionat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTotsElsCursos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbtostelscursos;
        private System.Windows.Forms.Label lbNomAlumne;
        private System.Windows.Forms.Button btAfegir;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridViewCursosdelSeleccionat;
        private System.Windows.Forms.DataGridView dataGridViewTotsElsCursos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxEstat;
        private System.Windows.Forms.Button btCanviar;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btFinalitzar;
    }
}