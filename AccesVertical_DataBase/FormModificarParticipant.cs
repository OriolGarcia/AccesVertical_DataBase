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
    public partial class FormModificarParticipant : Form
    {

        string ParticipantId;
        private Connexio mysqlconnect;
        public FormModificarParticipant(Connexio connect, string ParticipantId)
        {
            mysqlconnect = connect;
            this.ParticipantId = ParticipantId;
            InitializeComponent();
            InitializeComboboxEmpresa();
            SelectedItems();
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
        private void SelectedItems()
        {

            MySqlConnection conn = mysqlconnect.getmysqlconn();
            DataTable DtDadesAlumnes = new DataTable();

            MySqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "Select Participants.`ParticipantID`,Participants.`Nom`,Participants.`Cognoms`,Participants.`DNI`,"
       + "Participants.`EmpresaID` from Participants where `Participants`.`ParticipantID`= '" + ParticipantId + "'";
            conn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            reader.Read();
            try
            {

                txtBNom.Text = !reader.IsDBNull(1) ? reader.GetString(1) : null;
                txtBCognoms.Text = !reader.IsDBNull(2) ? reader.GetString(2) : null;
                txtBDNI.Text = !reader.IsDBNull(3) ? reader.GetString(3) : null;
                comboBoxEmpresa.SelectedValue = !reader.IsDBNull(4) ? reader.GetString(4) : null;

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
        private void btModificar_Click(object sender, EventArgs e)
        {

            MySqlConnection conn = mysqlconnect.getmysqlconn();
            conn.Open();
            MySqlDataReader MyReader2;

            try
            {


                string Query = "UPDATE Participants SET  Nom =@param_Nom, Cognoms=@param_Cognoms,DNI=@param_DNI"
                +  ", EmpresaID =@param_Empresa where ParticipantID=@param_ParticipantId;";
                MySqlCommand cmd = new MySqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@param_Nom", txtBNom.Text.ToUpper());
                cmd.Parameters.AddWithValue("@param_Cognoms", txtBCognoms.Text.ToUpper());
                cmd.Parameters.AddWithValue("@param_DNI", txtBDNI.Text);
                cmd.Parameters.AddWithValue("@param_Empresa", comboBoxEmpresa.SelectedValue);
                cmd.Parameters.AddWithValue("@param_ParticipantId", ParticipantId);
                MyReader2 = cmd.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                MyReader2.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {

                conn.Close(); this.Close();
            }
        }
    }
}
