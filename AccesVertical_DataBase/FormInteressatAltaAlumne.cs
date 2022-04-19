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
    public partial class FormInteressatAltaAlumne : Form
    {

        string PersonaId;
        private Connexio mysqlconnect;
        public FormInteressatAltaAlumne(Connexio connect, string PersonaId)
        {
            mysqlconnect = connect;
            this.PersonaId = PersonaId;
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

            cmd.CommandText = "Select PersonaID, Nom,Cognoms,`Curs d'interès`,`Correu electrònic`,`Telèfon`,`Telèfon Mòbil`"
                + " from ComercialParticulars where PersonaID= '" + PersonaId + "'";
            conn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            reader.Read();
            try
            {

                txtBNom.Text = !reader.IsDBNull(1) ? reader.GetString(1) : null;
                txtBCognoms.Text = !reader.IsDBNull(2) ? reader.GetString(2) : null;

                txtBEMAIL.Text = !reader.IsDBNull(4) ? reader.GetString(4) : null;
                
                txtBTelefon.Text = !reader.IsDBNull(5) ? reader.GetString(5) : null;
                txtBtelefonMobil.Text = !reader.IsDBNull(6) ? reader.GetString(6) : null;


                comboBoxEmpresa.SelectedValue = "1";

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
        private void btInserir_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = mysqlconnect.getmysqlconn();
            MySqlDataReader MyReader2;
            try
            {

                string Query = "INSERT INTO Alumnes ( Nom, Cognoms,DNI,`Correu electrònic`,Adreça,Telèfon,`Telèfon Mòbil`, `Data d'alta`, EmpresaID) VALUES(@param_Nom" +
                    ",@param_Cognoms,@param_DNI,@param_Email,@param_Adreça,@param_Telefon,@param_TelefonMobil,@param_DataAlta"
                    + ",@param_Empresa)";
                MySqlCommand cmd = new MySqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@param_Nom", txtBNom.Text.ToUpper());
                cmd.Parameters.AddWithValue("@param_Cognoms", txtBCognoms.Text.ToUpper());
                cmd.Parameters.AddWithValue("@param_DNI", txtBDNI.Text.ToUpper());
                cmd.Parameters.AddWithValue("@param_Email", txtBEMAIL.Text);
                cmd.Parameters.AddWithValue("@param_Adreça", txtBAdreça.Text);
                cmd.Parameters.AddWithValue("@param_Telefon", txtBTelefon.Text);
                cmd.Parameters.AddWithValue("@param_TelefonMobil", txtBtelefonMobil.Text);
                cmd.Parameters.AddWithValue("@param_DataAlta", dtPDataalta.Value.Date.ToString("yyyy-MM-dd HH:mm"));
                cmd.Parameters.AddWithValue("@param_Empresa", comboBoxEmpresa.SelectedValue);
                conn.Open();
                MyReader2 = cmd.ExecuteReader();
                MyReader2.Close();
                conn.Close();

                var confirmEliminar = MessageBox.Show("Vols eliminar aquest registre de Comercial Particulars?",
                  "Confirmació d'Eliminació!",
                  MessageBoxButtons.YesNo);
                        if (confirmEliminar == DialogResult.Yes)
                        {
                  Query = "delete from ComercialParticulars where PersonaID=" + PersonaId + ";";
                     cmd = new MySqlCommand(Query, conn);

                    conn.Open();
                    MyReader2 = cmd.ExecuteReader();
                    MyReader2.Close();
                    conn.Close();



                }




                   

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

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
