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
    public partial class FormModificarFormador : Form
    {
        string formadorId;
        private Connexio mysqlconnect;
        public FormModificarFormador(Connexio connect, string formadorId)
        {
            mysqlconnect = connect;
            this.formadorId = formadorId;
            InitializeComponent();
            SelectedItems();
        }
        private void SelectedItems()
        {

            MySqlConnection conn = mysqlconnect.getmysqlconn();
            DataTable DtDadesAlumnes = new DataTable();

            MySqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "Select FormadorID,Nom,Cognoms,Comentaris,DNI,Adreça,Telèfon,"
       + "`Telèfon Mòbil` from Formadors where FormadorID= '" +formadorId + "'";
            conn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            reader.Read();
            try
            {

                txtBNom.Text = !reader.IsDBNull(1) ? reader.GetString(1) : null;
                txtBCognoms.Text = !reader.IsDBNull(2) ? reader.GetString(2) : null;
                COMENTARISBOX.Text = !reader.IsDBNull(3) ? reader.GetString(3) : null;
                txtBDNI.Text = !reader.IsDBNull(4) ? reader.GetString(4) : null;
                txtBAdreça.Text = !reader.IsDBNull(5) ? reader.GetString(5) : null;
                txtBTelefon.Text = !reader.IsDBNull(6) ? reader.GetString(6) : null;
               txtBtelefonMobil.Text = !reader.IsDBNull(7) ? reader.GetString(7) : null;
               
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
        private void AltaAlumne_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

   
        private void btModificar_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = mysqlconnect.getmysqlconn();
            conn.Open();
            MySqlDataReader MyReader2;

            try
            {


                string Query = "UPDATE Formadors SET  Nom =@param_Nom, Cognoms=@param_Cognoms,`Comentaris`=@param_Comentaris,DNI=@param_DNI"
                    + ",`Telèfon`=@param_Telefon,`Telèfon Mòbil`=@param_TelefonMobil,Adreça =@param_Adreça" +
                  " where FormadorID=@param_FormadorId;";
                MySqlCommand cmd = new MySqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@param_Nom", txtBNom.Text.ToUpper());
                cmd.Parameters.AddWithValue("@param_Cognoms", txtBCognoms.Text.ToUpper());
                cmd.Parameters.AddWithValue("@param_Comentaris", COMENTARISBOX.Text);
                cmd.Parameters.AddWithValue("@param_DNI", txtBDNI.Text.ToUpper());
                cmd.Parameters.AddWithValue("@param_Adreça", txtBAdreça.Text);
                cmd.Parameters.AddWithValue("@param_Telefon", txtBTelefon.Text);
                cmd.Parameters.AddWithValue("@param_TelefonMobil", txtBtelefonMobil.Text);
                  cmd.Parameters.AddWithValue("@param_FormadorId", formadorId);

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

        private void btCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
