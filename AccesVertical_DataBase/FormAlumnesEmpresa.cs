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
    public partial class FormAlumnesEmpresa : Form
    {

        private Connexio mysqlconnect;
        public FormAlumnesEmpresa(Connexio connect)
        {
           

            mysqlconnect = connect;
            InitializeComponent();
            InitializeDataGridViewTotsElsAlumnes();
            InitializeComboboxEmpresa();
        }

        public void InitializeDataGridViewTotsElsAlumnes()
        {

            try
            {

                MySql.Data.MySqlClient.MySqlConnection conn = mysqlconnect.getmysqlconn();
                DataTable DtDadesAlumnesEmpresa = new DataTable();

                MySqlDataAdapter mdaDades =
                new MySqlDataAdapter("Select AlumneID, Nom, Cognoms, DNI from Alumnes WHERE ("
         + "LENGTH('" + NOMBOX.Text + "') <1 or `Alumnes`.`Nom` like '%" + NOMBOX.Text + "%')" + "AND ("
             + "LENGTH('" + COGNOMSBOX.Text + "') <1 or `Alumnes`.`Cognoms` like '%" + COGNOMSBOX.Text + "%')" + "AND ("
             + "LENGTH('" + DNIBOX.Text + "') <1 or `Alumnes`.`DNI` like '%" + DNIBOX.Text + "%' ) "    , conn);


                mdaDades.Fill(DtDadesAlumnesEmpresa);

                dataGridViewTotsElsAlumnes.DataSource = DtDadesAlumnesEmpresa;

                dataGridViewTotsElsAlumnes.Columns["AlumneID"].Visible = false;
                dataGridViewTotsElsAlumnes.RowHeadersVisible = false;
                dataGridViewTotsElsAlumnes.AllowUserToAddRows = false;
                conn.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }


        }

        private void SelectedItems(string AlumneId)
        {

            try
            {
               

                MySqlConnection conn = mysqlconnect.getmysqlconn();
                DataTable DtDadesAlumnes = new DataTable();

                MySqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "Select `Alumnes`.`AlumneID`, `Alumnes`.`EmpresaID` from Alumnes where `Alumnes`.`AlumneID`= '" + AlumneId + "'";
                conn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                reader.Read();
                try
                {


                    comboBoxEmpresa.SelectedValue = !reader.IsDBNull(1) ? reader.GetString(1) : null;

                    reader.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {

                    reader.Close();
                    conn.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btTancar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btCanviarEmpresa_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 selectedRowCount =
          dataGridViewTotsElsAlumnes.Rows.GetRowCount(DataGridViewElementStates.Selected);

                if (selectedRowCount > 0)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();

                    for (int i = 0; i < selectedRowCount; i++)
                    {
                        MySqlConnection conn = mysqlconnect.getmysqlconn();
                        string AlumneId = dataGridViewTotsElsAlumnes.SelectedRows[i].Cells[0].Value.ToString();
                        // Se crea un DataTable que almacenará los datos desde donde se cargaran los datos al DataGridView
                        DataTable DtDadesAlumnes = new DataTable();
                        // Se crea un MySqlAdapter para obtener los datos de la ba
                        string EmpresaID=comboBoxEmpresa.SelectedValue.ToString();
                        // MessageBox.Show(comboBoxEstat.SelectedValue.ToString());
                        string Query = " UPDATE Alumnes SET EmpresaID = " + EmpresaID
                            + " where AlumneId = " + AlumneId +";";
                        MySqlCommand cmd = new MySqlCommand(Query, conn);
                        MySqlDataReader MyReader2;
                        conn.Open();
                        MyReader2 = cmd.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                        conn.Close();

                    }
                }

                InitializeDataGridViewTotsElsAlumnes();
                InitializeComboboxEmpresa();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewTotsElsAlumnes_SelectionChanged(object sender, EventArgs e)
        {
            

            if (dataGridViewTotsElsAlumnes.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0)
            {
                

                string AlumneId = dataGridViewTotsElsAlumnes.SelectedRows[0].Cells[0].Value.ToString();

                SelectedItems(AlumneId);
            }

        }
        private void InitializeComboboxEmpresa()
        {

            try
            {
                MySqlConnection conn = mysqlconnect.getmysqlconn();

                string query = "SELECT EmpresaID,  `Nom de la empresa` from Empreses";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter mdaDades = new MySqlDataAdapter(cmd);
                DataTable DtDadesEmpresa = new DataTable();

                mdaDades.Fill(DtDadesEmpresa);
                comboBoxEmpresa.ValueMember = "EmpresaID";
                comboBoxEmpresa.DisplayMember = "Nom de la empresa";
                comboBoxEmpresa.DataSource = DtDadesEmpresa;

                conn.Close();
                //comboBoxEmpresa.SelectedValue = "";
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }


        }

        private void COGNOMSBOX_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewTotsElsAlumnes();
        }

        private void NOMBOX_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewTotsElsAlumnes();
        }

        private void DNIBOX_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewTotsElsAlumnes();
        }
    }
}
