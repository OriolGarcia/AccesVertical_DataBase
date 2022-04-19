namespace AccesVertical_DataBase
{
    partial class FormAlumnesCurs
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
            this.Control = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewTotsElsAlumnes = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dTPinici = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.DNIBOX = new System.Windows.Forms.TextBox();
            this.COGNOMSBOX = new System.Windows.Forms.TextBox();
            this.NOMBOX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btAfegir = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridViewAlumnesSeleccionat = new System.Windows.Forms.DataGridView();
            this.lbtostelsalumnes = new System.Windows.Forms.Label();
            this.lbNomAlumne = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBoxEstat = new System.Windows.Forms.ComboBox();
            this.btFinalitzar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btCanviar = new System.Windows.Forms.Button();
            this.Control.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTotsElsAlumnes)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAlumnesSeleccionat)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Control
            // 
            this.Control.AutoSize = true;
            this.Control.Controls.Add(this.tableLayoutPanel1);
            this.Control.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Control.Location = new System.Drawing.Point(0, 0);
            this.Control.Name = "Control";
            this.Control.Size = new System.Drawing.Size(971, 461);
            this.Control.TabIndex = 3;
            this.Control.TabStop = false;
            this.Control.Text = "Control de Alumnes del Curs";
            this.Control.Enter += new System.EventHandler(this.Control_Enter);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewTotsElsAlumnes, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewAlumnesSeleccionat, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbtostelsalumnes, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbNomAlumne, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.60465F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.39535F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 157F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(965, 442);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // dataGridViewTotsElsAlumnes
            // 
            this.dataGridViewTotsElsAlumnes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTotsElsAlumnes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTotsElsAlumnes.Location = new System.Drawing.Point(3, 56);
            this.dataGridViewTotsElsAlumnes.Name = "dataGridViewTotsElsAlumnes";
            this.dataGridViewTotsElsAlumnes.ReadOnly = true;
            this.dataGridViewTotsElsAlumnes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTotsElsAlumnes.Size = new System.Drawing.Size(346, 225);
            this.dataGridViewTotsElsAlumnes.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dTPinici);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.DNIBOX);
            this.groupBox2.Controls.Add(this.COGNOMSBOX);
            this.groupBox2.Controls.Add(this.NOMBOX);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 287);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(346, 152);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cerca Avançada";
            // 
            // dTPinici
            // 
            this.dTPinici.Location = new System.Drawing.Point(126, 109);
            this.dTPinici.Name = "dTPinici";
            this.dTPinici.Size = new System.Drawing.Size(200, 20);
            this.dTPinici.TabIndex = 7;
            this.dTPinici.ValueChanged += new System.EventHandler(this.dTPinici_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "A partir de: (data d\'alta)";
            // 
            // DNIBOX
            // 
            this.DNIBOX.Location = new System.Drawing.Point(72, 65);
            this.DNIBOX.Name = "DNIBOX";
            this.DNIBOX.Size = new System.Drawing.Size(100, 20);
            this.DNIBOX.TabIndex = 5;
            this.DNIBOX.TextChanged += new System.EventHandler(this.DNIBOX_TextChanged);
            // 
            // COGNOMSBOX
            // 
            this.COGNOMSBOX.Location = new System.Drawing.Point(243, 27);
            this.COGNOMSBOX.Name = "COGNOMSBOX";
            this.COGNOMSBOX.Size = new System.Drawing.Size(100, 20);
            this.COGNOMSBOX.TabIndex = 4;
            this.COGNOMSBOX.TextChanged += new System.EventHandler(this.COGNOMSBOX_TextChanged);
            // 
            // NOMBOX
            // 
            this.NOMBOX.Location = new System.Drawing.Point(72, 27);
            this.NOMBOX.Name = "NOMBOX";
            this.NOMBOX.Size = new System.Drawing.Size(90, 20);
            this.NOMBOX.TabIndex = 3;
            this.NOMBOX.TextChanged += new System.EventHandler(this.NOMBOX_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Per DNI:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(168, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Per Cognoms";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Per nom:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btAfegir);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(355, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(79, 225);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // btAfegir
            // 
            this.btAfegir.Location = new System.Drawing.Point(3, 96);
            this.btAfegir.Name = "btAfegir";
            this.btAfegir.Size = new System.Drawing.Size(75, 23);
            this.btAfegir.TabIndex = 4;
            this.btAfegir.Text = "Afegir >>";
            this.btAfegir.UseVisualStyleBackColor = true;
            this.btAfegir.Click += new System.EventHandler(this.btAfegir_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 125);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Eliminar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridViewAlumnesSeleccionat
            // 
            this.dataGridViewAlumnesSeleccionat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAlumnesSeleccionat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewAlumnesSeleccionat.Location = new System.Drawing.Point(440, 56);
            this.dataGridViewAlumnesSeleccionat.Name = "dataGridViewAlumnesSeleccionat";
            this.dataGridViewAlumnesSeleccionat.ReadOnly = true;
            this.dataGridViewAlumnesSeleccionat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAlumnesSeleccionat.Size = new System.Drawing.Size(522, 225);
            this.dataGridViewAlumnesSeleccionat.TabIndex = 7;
            this.dataGridViewAlumnesSeleccionat.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAlumnesSeleccionat_CellContentClick);
            this.dataGridViewAlumnesSeleccionat.SelectionChanged += new System.EventHandler(this.dataGridViewAlumnesSeleccionat_SelectionChanged);
            // 
            // lbtostelsalumnes
            // 
            this.lbtostelsalumnes.AutoSize = true;
            this.lbtostelsalumnes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbtostelsalumnes.Location = new System.Drawing.Point(3, 40);
            this.lbtostelsalumnes.Name = "lbtostelsalumnes";
            this.lbtostelsalumnes.Size = new System.Drawing.Size(346, 13);
            this.lbtostelsalumnes.TabIndex = 2;
            this.lbtostelsalumnes.Text = "Tots els Alumnes";
            // 
            // lbNomAlumne
            // 
            this.lbNomAlumne.AutoSize = true;
            this.lbNomAlumne.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbNomAlumne.Location = new System.Drawing.Point(440, 40);
            this.lbNomAlumne.Name = "lbNomAlumne";
            this.lbNomAlumne.Size = new System.Drawing.Size(522, 13);
            this.lbNomAlumne.TabIndex = 3;
            this.lbNomAlumne.Text = "Alumnes del Curs";
            // 
            // groupBox3
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox3, 2);
            this.groupBox3.Controls.Add(this.comboBoxEstat);
            this.groupBox3.Controls.Add(this.btFinalitzar);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.btCanviar);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(355, 287);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(607, 152);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            // 
            // comboBoxEstat
            // 
            this.comboBoxEstat.FormattingEnabled = true;
            this.comboBoxEstat.Location = new System.Drawing.Point(134, 44);
            this.comboBoxEstat.Name = "comboBoxEstat";
            this.comboBoxEstat.Size = new System.Drawing.Size(121, 21);
            this.comboBoxEstat.TabIndex = 8;
            // 
            // btFinalitzar
            // 
            this.btFinalitzar.Location = new System.Drawing.Point(286, 96);
            this.btFinalitzar.Name = "btFinalitzar";
            this.btFinalitzar.Size = new System.Drawing.Size(75, 23);
            this.btFinalitzar.TabIndex = 11;
            this.btFinalitzar.Text = "Finalitzar";
            this.btFinalitzar.UseVisualStyleBackColor = true;
            this.btFinalitzar.Click += new System.EventHandler(this.btFinalitzar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Estat del Curs";
            // 
            // btCanviar
            // 
            this.btCanviar.Location = new System.Drawing.Point(286, 42);
            this.btCanviar.Name = "btCanviar";
            this.btCanviar.Size = new System.Drawing.Size(75, 23);
            this.btCanviar.TabIndex = 10;
            this.btCanviar.Text = "Canviar";
            this.btCanviar.UseVisualStyleBackColor = true;
            this.btCanviar.Click += new System.EventHandler(this.btCanviar_Click);
            // 
            // FormAlumnesCurs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 461);
            this.Controls.Add(this.Control);
            this.MinimumSize = new System.Drawing.Size(987, 500);
            this.Name = "FormAlumnesCurs";
            this.Text = "AccésVertical Organizer";
            this.Control.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTotsElsAlumnes)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAlumnesSeleccionat)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox Control;
        private System.Windows.Forms.Button btFinalitzar;
        private System.Windows.Forms.Button btCanviar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxEstat;
        private System.Windows.Forms.DataGridView dataGridViewAlumnesSeleccionat;
        private System.Windows.Forms.DataGridView dataGridViewTotsElsAlumnes;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btAfegir;
        private System.Windows.Forms.Label lbNomAlumne;
        private System.Windows.Forms.Label lbtostelsalumnes;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox DNIBOX;
        private System.Windows.Forms.TextBox COGNOMSBOX;
        private System.Windows.Forms.TextBox NOMBOX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dTPinici;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}