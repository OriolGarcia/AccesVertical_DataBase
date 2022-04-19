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
    public partial class CursosGWOSeleccionat : Form
    {

        private string AlumneId;
        private string nom;
        private string cognoms;
        private string CursGWOID = "";
        private string Estat;
        private Connexio mysqlconnect;
        public CursosGWOSeleccionat(Connexio connect, string AlumneId, string nom, string cognoms)
        {


            this.AlumneId = AlumneId;
            this.nom = nom;
            this.cognoms = cognoms;

            mysqlconnect = connect;
            InitializeComponent();
            dataGridViewCursosGWOdelSeleccionat.AllowUserToAddRows = false;
            dataGridViewTotsElsCursosGWO.AllowUserToAddRows = false;
            InitializeDataGridViewTotselsCursosGWO();
            InitializeDataGridViewCursosGWOdelSeleccionat();
            InitializeComboboxEstat();
            lbNomAlumne.Text = "Cursos GWO de " + nom + " " + cognoms;

        }
        private void InitializeDataGridViewTotselsCursosGWO()
        {


            try
            {


                MySqlConnection conn = mysqlconnect.getmysqlconn();
                DataTable DtDadesCursosGWO = new DataTable();
                string query = (@"Select CursosGWO.`CursGWOID`, CursosGWO.`Codi Curs GWO`, CursosGWO.`Titol`, CursosGWO.`Mes`, CursosGWO.`Data d'inici` from CursosGWO");

                MySqlCommand cmd = new MySqlCommand(query, conn);

                MySqlDataAdapter mdaDades = new MySqlDataAdapter(cmd);

                mdaDades.Fill(DtDadesCursosGWO);


                dataGridViewTotsElsCursosGWO.AllowUserToAddRows = false;
                // Se asigna el DataTable como origen de datos del DataGridView
                dataGridViewTotsElsCursosGWO.DataSource = DtDadesCursosGWO;
                dataGridViewTotsElsCursosGWO.Columns["CursGWOID"].Visible = false;
                dataGridViewTotsElsCursosGWO.Columns["Codi Curs GWO"].Visible = false;

                dataGridViewTotsElsCursosGWO.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewTotsElsCursosGWO.RowHeadersVisible = false;
                // Se cierra la conexión a la base de datos*/
                conn.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }

        }
        private void InitializeDataGridViewCursosGWOdelSeleccionat()
        {

            try
            {
                MySqlConnection conn = mysqlconnect.getmysqlconn();
                // Se crea un DataTable que almacenará los datos desde donde se cargaran los datos al DataGridView
                DataTable DtDadesAlumnes = new DataTable();

                // Se crea un MySqlAdapter para obtener los datos de la base
                MySqlDataAdapter mdaDades =
                new MySqlDataAdapter(@"Select CursosGWO.`CursGWOID`, CursosGWO.`Codi Curs GWO`, CursosGWO.`Titol`,CursosGWO.`Mes`,CursosGWO.`Data d'inici`, estatdelcurs.* from CursosGWO INNER JOIN AlumnesMembresDelCursGWO
        ON CursosGWO.`CursGWOID` = AlumnesMembresDelCursGWO.`CursGWO`
        INNER JOIN estatdelcurs
        ON estatdelcurs.EstatID= AlumnesMembresDelCursGWO.Estat
        WHERE AlumnesMembresDelCursGWO.`Alumne`=" + AlumneId + "; ", conn);

                // Con la información del adaptador se rellena el DataTable
                mdaDades.Fill(DtDadesAlumnes);
                dataGridViewCursosGWOdelSeleccionat.AllowUserToAddRows = false;
                // Se asigna el DataTable como origen de datos del DataGridView
                dataGridViewCursosGWOdelSeleccionat.DataSource = DtDadesAlumnes;
                dataGridViewCursosGWOdelSeleccionat.Columns["CursGWOID"].Visible = false;
                dataGridViewCursosGWOdelSeleccionat.Columns["Codi Curs GWO"].Visible = false;
                dataGridViewCursosGWOdelSeleccionat.Columns["EstatID"].Visible = false;
                dataGridViewCursosGWOdelSeleccionat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewCursosGWOdelSeleccionat.RowHeadersVisible = false;

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
                Int32 selectedRowCount = dataGridViewTotsElsCursosGWO.Rows.GetRowCount(DataGridViewElementStates.Selected);

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

        private void btAfegir_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount =
      dataGridViewTotsElsCursosGWO.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (selectedRowCount > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                for (int i = 0; i < selectedRowCount; i++)
                {
                    MySqlConnection conn = mysqlconnect.getmysqlconn();
                    string CursGWOID = dataGridViewTotsElsCursosGWO.SelectedRows[i].Cells[0].Value.ToString();
                    // Se crea un DataTable que almacenará los datos desde donde se cargaran los datos al DataGridView
                    DataTable DtDadesAlumnes = new DataTable();
                    // Se crea un MySqlAdapter para obtener los datos de la base

                    try
                    {


                        string Query = "INSERT INTO AlumnesMembresDelCursGWO(Alumne, CursGWO,Estat) VALUES(\"" + AlumneId + "\",\"" + CursGWOID + "\", \"1\"); ";
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
                    InitializeDataGridViewCursosGWOdelSeleccionat();


                }


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount =
      dataGridViewCursosGWOdelSeleccionat.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (selectedRowCount > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                for (int i = 0; i < selectedRowCount; i++)
                {

                    try
                    {
                        MySqlConnection conn = mysqlconnect.getmysqlconn();
                        string CursGWOID = dataGridViewCursosGWOdelSeleccionat.SelectedRows[0].Cells[0].Value.ToString();
                        // Se crea un DataTable que almacenará los datos desde donde se cargaran los datos al DataGridView
                        DataTable DtDadesAlumnes = new DataTable();
                        // Se crea un MySqlAdapter para obtener los datos de la base



                        string Query = "delete from AlumnesMembresDelCursGWO where (Alumne, CursGWO) in ((" + AlumneId + "," + CursGWOID + "))";
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
                    InitializeDataGridViewCursosGWOdelSeleccionat();


                }


            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridViewTotsElsCursosGWO_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewCursosGWOdelSeleccionat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBoxEstat_SelectedIndexChanged(object sender, EventArgs e)
        {








        }

        private void btFinalitzar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btCanviar_Click(object sender, EventArgs e)
        {
            try
            {



                if (comboBoxEstat.SelectedIndex >= 0)
                {

                    MySqlConnection conn = mysqlconnect.getmysqlconn();
                    string CursGWOId = dataGridViewCursosGWOdelSeleccionat.SelectedRows[0].Cells[0].Value.ToString();
                    // Se crea un DataTable que almacenará los datos desde donde se cargaran los datos al DataGridView
                    DataTable DtDadesAlumnes = new DataTable();
                    // Se crea un MySqlAdapter para obtener los datos de la base


                    Estat = comboBoxEstat.SelectedValue.ToString();
                    // MessageBox.Show(comboBoxEstat.SelectedValue.ToString());
                    string Query = " UPDATE alumnesmembresdelcursGWO SET Estat = " + Estat
                        + " where(Alumne, CursGWO) in ((" + AlumneId + "," + CursGWOId + "));";
                    MySqlCommand cmd = new MySqlCommand(Query, conn);
                    MySqlDataReader MyReader2;
                    conn.Open();
                    MyReader2 = cmd.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                    conn.Close();
                    InitializeDataGridViewCursosGWOdelSeleccionat();
                    InitializeComboboxEstat();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewCursosGWOdelSeleccionat_SelectionChanged_1(object sender, EventArgs e)
        {

            if (dataGridViewCursosGWOdelSeleccionat.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0)
            {
                Estat = dataGridViewCursosGWOdelSeleccionat.SelectedRows[0].Cells[5].Value.ToString();
                InitializeComboboxEstat();
                CursGWOID = dataGridViewCursosGWOdelSeleccionat.SelectedRows[0].Cells[0].Value.ToString();

            }
        }
    }
}
