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
    public partial class FormModificarInteressat : Form
    {

        string PersonaId;
        private Connexio mysqlconnect;
        public FormModificarInteressat(Connexio mysqlconnect, string PersonaId)
        {
            this.PersonaId = PersonaId;
            this.mysqlconnect = mysqlconnect;
            InitializeComponent();
            InitializeComboBoxCursos();
            InitializeComboBoxInformat();
            SelectedItems();
        }

        private void InitializeComboBoxCursos()
        {

            try
            {
                MySqlConnection conn = mysqlconnect.getmysqlconn();

                string query = "SELECT TipusCursID,  Nom from TipusCursos";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter mdaDades = new MySqlDataAdapter(cmd);
                DataTable DtDadesInformat = new DataTable();

                mdaDades.Fill(DtDadesInformat);
                comboBoxCursos.ValueMember = "TipusCursID";
                comboBoxCursos.DisplayMember = "Nom";
                comboBoxCursos.DataSource = DtDadesInformat;

                conn.Close();
                //comboBoxEmpresa.SelectedValue = "";
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }

        }

        private void InitializeComboBoxInformat()
        {

            try
            {
                MySqlConnection conn = mysqlconnect.getmysqlconn();

                string query = "SELECT    InformatID,  Informat from Informat";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter mdaDades = new MySqlDataAdapter(cmd);
                DataTable DtDadesInformat = new DataTable();

                mdaDades.Fill(DtDadesInformat);
                comboBoxInformat.ValueMember = "InformatID";
                comboBoxInformat.DisplayMember = "Informat";
                comboBoxInformat.DataSource = DtDadesInformat;

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

            cmd.CommandText = "Select PersonaID, Nom,Cognoms,`Curs d'interès`,`Correu electrònic`,`Telèfon`,`Informat`, Comentaris,`Data de preferència`,Mes,`Telèfon Mòbil`"
                + " from ComercialParticulars where PersonaID= '" + PersonaId + "'";
            conn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            reader.Read();
            try
            {

                txtBNom.Text = !reader.IsDBNull(1) ? reader.GetString(1) : null;
                txtBCognoms.Text = !reader.IsDBNull(2) ? reader.GetString(2) : null;
                comboBoxCursos.SelectedValue = !reader.IsDBNull(3) ? reader.GetString(3) : null;
                txtBEMAIL.Text = !reader.IsDBNull(4) ? reader.GetString(4) : null;
                txtBTelefon.Text = !reader.IsDBNull(5) ? reader.GetString(5) : null;
                comboBoxInformat.SelectedValue = !reader.IsDBNull(6) ? reader.GetString(6) : null;
                COMENTARISBOX.Text = !reader.IsDBNull(7) ? reader.GetString(7) : null;
                DTPDataPrefer.Value = !reader.IsDBNull(8) ? reader.GetDateTime(8) : new DateTime();
                comboBMes.SelectedItem = !reader.IsDBNull(9) ? reader.GetString(9) : null;
                txtBtelefonMobil.Text = !reader.IsDBNull(10) ? reader.GetString(10) : null;
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


                string Query = "UPDATE ComercialParticulars SET  Nom =@param_Nom, Cognoms=@param_Cognoms,Mes=@param_Mes, `Curs d'interès`=@param_Cursos"
                    + ",`Correu electrònic`=@param_Email,`Telèfon`=@param_Telefon,`Telèfon Mòbil`=@param_TelefonMobil,Comentaris=@param_Comentaris"
                    + ",Informat=@param_Informat,`Data de preferència`=@DataPrefer"
                   + " where PersonaID=@param_PersonaId;";
                MySqlCommand cmd = new MySqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@param_Nom", txtBNom.Text.ToUpper());
                cmd.Parameters.AddWithValue("@param_Cognoms", txtBCognoms.Text.ToUpper());
                cmd.Parameters.AddWithValue("@param_Mes", comboBMes.SelectedItem);
                cmd.Parameters.AddWithValue("@param_Email", txtBEMAIL.Text);
                cmd.Parameters.AddWithValue("@param_Telefon", txtBTelefon.Text);
                cmd.Parameters.AddWithValue("@param_TelefonMobil", txtBtelefonMobil.Text);
                cmd.Parameters.AddWithValue("@param_Cursos", comboBoxCursos.SelectedValue);
                cmd.Parameters.AddWithValue("@param_Informat", comboBoxInformat.SelectedValue);
                cmd.Parameters.AddWithValue("@param_Comentaris", COMENTARISBOX.Text);
                cmd.Parameters.AddWithValue("@param_PersonaId", PersonaId);
                cmd.Parameters.AddWithValue("@DataPrefer", DTPDataPrefer.Value.Date.ToString("yyyy-MM-dd HH:mm"));
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

        private void comboBoxInformat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

      

        private void formEditarCursInteres_FormClosed(object sender, FormClosedEventArgs e)
        {

            InitializeComboBoxCursos();
        }
        private void btEditarCursInteres_Click(object sender, EventArgs e)
        {

            FormEditarCursInterés formEditarCursInteres = new FormEditarCursInterés(mysqlconnect);

            formEditarCursInteres.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formEditarCursInteres_FormClosed);

            formEditarCursInteres.Show();
        }
    }
}
