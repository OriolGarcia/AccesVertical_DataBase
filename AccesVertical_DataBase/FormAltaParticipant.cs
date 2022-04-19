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
    public partial class FormAltaParticipant : Form
    {

        private Connexio mysqlconnect;
        public FormAltaParticipant(Connexio connect)
        {
            mysqlconnect = connect;

            InitializeComponent();
            InitializeComboboxEmpresa();
        }
        private void InitializeComboboxEmpresa()
        {

            try
            {
                MySqlConnection conn = mysqlconnect.getmysqlconn();

                string query = "SELECT EmpresaID,  `Nom de la empresa` from Empreses ORDER BY `Nom de la empresa` ASC";

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
        private void btCancelar_Click(object sender, EventArgs e)
        {

        }

        private void btInserir_Click(object sender, EventArgs e)
        {

            MySqlConnection conn = mysqlconnect.getmysqlconn();
            MySqlDataReader MyReader2;
            try
            {

                string Query = "INSERT INTO Participants ( Nom, Cognoms,DNI,EmpresaID) VALUES(@param_Nom,"
                    + "@param_Cognoms,@param_DNI"
                    + ",@param_Empresa)";
                MySqlCommand cmd = new MySqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@param_Nom", txtBNom.Text.ToUpper());
                cmd.Parameters.AddWithValue("@param_Cognoms", txtBCognoms.Text.ToUpper());
                cmd.Parameters.AddWithValue("@param_DNI", txtBDNI.Text.ToUpper());
                cmd.Parameters.AddWithValue("@param_Empresa", comboBoxEmpresa.SelectedValue);

                conn.Open();
                MyReader2 = cmd.ExecuteReader();
                MyReader2.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conn.Close();

                this.Close();
            }

        }
    }
}
