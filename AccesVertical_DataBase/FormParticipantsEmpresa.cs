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
    public partial class FormParticipantsEmpresa : Form
    {


        private Connexio mysqlconnect;
        public FormParticipantsEmpresa(Connexio connect)
        {


            mysqlconnect = connect;
            InitializeComponent();
            InitializeDataGridViewTotsElsParticipants();
            InitializeComboboxEmpresa();
        }

        public void InitializeDataGridViewTotsElsParticipants()
        {

            try
            {

                MySql.Data.MySqlClient.MySqlConnection conn = mysqlconnect.getmysqlconn();
                DataTable DtDadesParticipantsEmpresa = new DataTable();

                MySqlDataAdapter mdaDades =
                new MySqlDataAdapter("Select ParticipantID, Nom, Cognoms, DNI from Participants WHERE ("
         + "LENGTH('" + NOMBOX.Text + "') <1 or `Participants`.`Nom` like '%" + NOMBOX.Text + "%')" + "AND ("
             + "LENGTH('" + COGNOMSBOX.Text + "') <1 or `Participants`.`Cognoms` like '%" + COGNOMSBOX.Text + "%')" + "AND ("
             + "LENGTH('" + DNIBOX.Text + "') <1 or `Participants`.`DNI` like '%" + DNIBOX.Text + "%' ) ", conn);


                mdaDades.Fill(DtDadesParticipantsEmpresa);

                dataGridViewTotsElsParticipants.DataSource = DtDadesParticipantsEmpresa;

                dataGridViewTotsElsParticipants.Columns["ParticipantID"].Visible = false;
                dataGridViewTotsElsParticipants.RowHeadersVisible = false;
                dataGridViewTotsElsParticipants.AllowUserToAddRows = false;
                conn.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);

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
        private void SelectedItems(string ParticipantId)
        {

            try
            {
                MySqlConnection conn = mysqlconnect.getmysqlconn();
                DataTable DtDadesAlumnes = new DataTable();

                MySqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "Select Participants.`ParticipantID`, Participants.`EmpresaID` from Participants where Participants.`ParticipantID`= '" + ParticipantId + "'";
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

        private void btCanviarEmpresa_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 selectedRowCount =
          dataGridViewTotsElsParticipants.Rows.GetRowCount(DataGridViewElementStates.Selected);

                if (selectedRowCount > 0)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();

                    for (int i = 0; i < selectedRowCount; i++)
                    {
                        MySqlConnection conn = mysqlconnect.getmysqlconn();
                        string ParticipantId = dataGridViewTotsElsParticipants.SelectedRows[i].Cells[0].Value.ToString();
                        // Se crea un DataTable que almacenará los datos desde donde se cargaran los datos al DataGridView
                        DataTable DtDadesAlumnes = new DataTable();
                        // Se crea un MySqlAdapter para obtener los datos de la ba
                        string EmpresaID = comboBoxEmpresa.SelectedValue.ToString();
                        // MessageBox.Show(comboBoxEstat.SelectedValue.ToString());
                        string Query = " UPDATE Participants SET EmpresaID = " + EmpresaID
                            + " where ParticipantId = " + ParticipantId + ";";
                        MySqlCommand cmd = new MySqlCommand(Query, conn);
                        MySqlDataReader MyReader2;
                        conn.Open();
                        MyReader2 = cmd.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                        conn.Close();

                    }
                }

                InitializeDataGridViewTotsElsParticipants();
                InitializeComboboxEmpresa();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btTancar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridViewTotsElsParticipants_SelectionChanged(object sender, EventArgs e)
        {

            if (dataGridViewTotsElsParticipants.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0)
            {


                string AlumneId = dataGridViewTotsElsParticipants.SelectedRows[0].Cells[0].Value.ToString();

                SelectedItems(AlumneId);
            }
        }
    }
}
