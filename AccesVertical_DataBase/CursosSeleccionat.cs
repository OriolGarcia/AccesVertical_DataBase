using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccesVertical_DataBase
{
    public partial class CursosSeleccionat : Form
    {
        private string AlumneId;
        private string nom;
        private string cognoms;
        private string CursId="";
        private string Estat;
        private Connexio mysqlconnect;
        public CursosSeleccionat()
        {
            InitializeComponent();
        }
        public CursosSeleccionat(Connexio connect, string AlumneId,string nom, string cognoms)
        {


            this.AlumneId = AlumneId;
             this.nom = nom;
              this.cognoms = cognoms;
          
            mysqlconnect = connect;
            InitializeComponent();
            dataGridViewCursosdelSeleccionat.AllowUserToAddRows = false;
            dataGridViewTotsElsCursos.AllowUserToAddRows = false;
            InitializeDataGridViewTotselsCursos();
            InitializeDataGridViewCursosdelSeleccionat();
            InitializeComboboxEstat();
           lbNomAlumne.Text = "Cursos de " + nom + " " + cognoms;

        }
        private void InitializeDataGridViewTotselsCursos()
        {

         
            try
            {


                MySqlConnection conn = mysqlconnect.getmysqlconn();
                DataTable DtDadesCursos = new DataTable();
                string query = (@"Select Cursos.`CursID`, Cursos.`Codi`, Cursos.`Nom`, Cursos.`Mes`, Cursos.`Data d'inici` from Cursos");

                MySqlCommand cmd = new MySqlCommand(query, conn);

                MySqlDataAdapter mdaDades = new MySqlDataAdapter(cmd);

                mdaDades.Fill(DtDadesCursos);


                dataGridViewTotsElsCursos.AllowUserToAddRows = false;
                // Se asigna el DataTable como origen de datos del DataGridView
                dataGridViewTotsElsCursos.DataSource = DtDadesCursos;
                dataGridViewTotsElsCursos.Columns["CursID"].Visible = false;
                dataGridViewTotsElsCursos.Columns["Codi"].Visible = false;

                dataGridViewTotsElsCursos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewTotsElsCursos.RowHeadersVisible = false;
                // Se cierra la conexión a la base de datos*/
                conn.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }

        }
        private void InitializeDataGridViewCursosdelSeleccionat()
        {

            try
            {
                MySqlConnection conn = mysqlconnect.getmysqlconn();
            // Se crea un DataTable que almacenará los datos desde donde se cargaran los datos al DataGridView
            DataTable DtDadesAlumnes = new DataTable();

            // Se crea un MySqlAdapter para obtener los datos de la base
            MySqlDataAdapter mdaDades =
            new MySqlDataAdapter(@"Select Cursos.`CursID`, Cursos.`Codi`, Cursos.`Nom`,Cursos.`Mes`,Cursos.`Data d'inici`, estatdelcurs.* from Cursos INNER JOIN alumnesmembresdelcurs
        ON Cursos.`CursID` = alumnesmembresdelcurs.`Curs`
        INNER JOIN estatdelcurs
        ON estatdelcurs.EstatID= alumnesmembresdelcurs.Estat
        WHERE alumnesmembresdelcurs.`Alumne`=" + AlumneId + "; ", conn);
         
            // Con la información del adaptador se rellena el DataTable
            mdaDades.Fill(DtDadesAlumnes);
            dataGridViewCursosdelSeleccionat.AllowUserToAddRows = false;
            // Se asigna el DataTable como origen de datos del DataGridView
            dataGridViewCursosdelSeleccionat.DataSource = DtDadesAlumnes;
            dataGridViewCursosdelSeleccionat.Columns["CursID"].Visible = false;
            dataGridViewCursosdelSeleccionat.Columns["Codi"].Visible = false;
            dataGridViewCursosdelSeleccionat.Columns["EstatID"].Visible = false;
            dataGridViewCursosdelSeleccionat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCursosdelSeleccionat.RowHeadersVisible = false;
   
            // Se cierra la conexión a la base de datos
            conn.Close();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }
        }
        private void InitializeComboboxEstat()
        {
            try
            {

                MySqlConnection conn = mysqlconnect.getmysqlconn();
           
            string query = "SELECT EstatID, Estat from EstatdelCurs";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter mdaDades = new MySqlDataAdapter(cmd);
            DataTable DtDadesEstats = new DataTable();


            // Con la información del adaptador se rellena el DataTable
            mdaDades.Fill(DtDadesEstats);
            comboBoxEstat.ValueMember = "EstatID";
            comboBoxEstat.DisplayMember = "Estat";
            comboBoxEstat.DataSource = DtDadesEstats;
            conn.Close();
            Int32 selectedRowCount =  dataGridViewTotsElsCursos.Rows.GetRowCount(DataGridViewElementStates.Selected);
           
            if (selectedRowCount > 0)
            {
                    
                comboBoxEstat.SelectedValue = Estat;
                          }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount =
      dataGridViewTotsElsCursos.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (selectedRowCount > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                for (int i = 0; i < selectedRowCount; i++)
                {
                    MySqlConnection conn = mysqlconnect.getmysqlconn();
                    string CursId = dataGridViewTotsElsCursos.SelectedRows[i].Cells[0].Value.ToString();
                    // Se crea un DataTable que almacenará los datos desde donde se cargaran los datos al DataGridView
                    DataTable DtDadesAlumnes = new DataTable();
                    // Se crea un MySqlAdapter para obtener los datos de la base

                    try
                    {
                      
                        
                        string Query = "INSERT INTO AlumnesMembresDelCurs(Alumne, Curs,Estat) VALUES(\"" + AlumneId + "\",\"" + CursId + "\", \"1\"); ";
                        MySqlCommand cmd = new MySqlCommand(Query, conn);
                        MySqlDataReader MyReader2;
                        conn.Open();
                        MyReader2 = cmd.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                        conn.Close();
                    }
                    catch (MySqlException ex)
                    {

                        if (ex.Number != 1062)
                            MessageBox.Show(ex.Message);
                    }
                    InitializeDataGridViewCursosdelSeleccionat();


                }


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount =
      dataGridViewCursosdelSeleccionat.Rows.GetRowCount(DataGridViewElementStates.Selected);
            
            if (selectedRowCount > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                for (int i = 0; i < selectedRowCount; i++)
                {

                    try
                    {
                        MySqlConnection conn = mysqlconnect.getmysqlconn();
                    string CursId = dataGridViewCursosdelSeleccionat.SelectedRows[0].Cells[0].Value.ToString();
                    // Se crea un DataTable que almacenará los datos desde donde se cargaran los datos al DataGridView
                    DataTable DtDadesAlumnes = new DataTable();
                    // Se crea un MySqlAdapter para obtener los datos de la base

                  

                        string Query = "delete from Alumnesmembresdelcurs where (Alumne, Curs) in (("+AlumneId+","+CursId+"))";
                        MySqlCommand cmd = new MySqlCommand(Query, conn);
                        MySqlDataReader MyReader2;
                        conn.Open();
                        MyReader2 = cmd.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    InitializeDataGridViewCursosdelSeleccionat();


                }


            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridViewTotsElsCursos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewCursosdelSeleccionat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBoxEstat_SelectedIndexChanged(object sender, EventArgs e)
        {
            


            




        }

        private void dataGridViewCursosdelSeleccionat_SelectionChanged(object sender, EventArgs e)
        {
         
            if (dataGridViewCursosdelSeleccionat.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0)
            {
                Estat = dataGridViewCursosdelSeleccionat.SelectedRows[0].Cells[5].Value.ToString();
                InitializeComboboxEstat();
                 CursId = dataGridViewCursosdelSeleccionat.SelectedRows[0].Cells[0].Value.ToString();
               
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {



                if (comboBoxEstat.SelectedIndex >= 0)
                {

                    MySqlConnection conn = mysqlconnect.getmysqlconn();
                    string CursId = dataGridViewCursosdelSeleccionat.SelectedRows[0].Cells[0].Value.ToString();
                    // Se crea un DataTable que almacenará los datos desde donde se cargaran los datos al DataGridView
                    DataTable DtDadesAlumnes = new DataTable();
                    // Se crea un MySqlAdapter para obtener los datos de la base

                    string Estat = comboBoxEstat.SelectedValue.ToString();
                    // MessageBox.Show(comboBoxEstat.SelectedValue.ToString());
                    string Query = " UPDATE alumnesmembresdelcurs SET Estat = " + Estat
                        + " where(Alumne, Curs) in ((" + AlumneId + "," + CursId + "));";
                    MySqlCommand cmd = new MySqlCommand(Query, conn);
                    MySqlDataReader MyReader2;
                    conn.Open();
                    MyReader2 = cmd.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                    conn.Close();

                    InitializeDataGridViewCursosdelSeleccionat();
                    InitializeComboboxEstat();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btFinalitzar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CursosSeleccionat_Load(object sender, EventArgs e)
        {

        }
    }
}
