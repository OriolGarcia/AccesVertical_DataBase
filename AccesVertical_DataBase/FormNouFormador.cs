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
    public partial class FormNouFormador : Form
    {
        private Connexio mysqlconnect;
        public FormNouFormador(Connexio connect)
        {
            mysqlconnect = connect;
                InitializeComponent();
        }

        private void btInserir_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = mysqlconnect.getmysqlconn();
            MySqlDataReader MyReader2;
            try
            {

                conn.Open();
               string Query = "INSERT INTO Formadors ( Nom, Cognoms,Comentaris,DNI,Adreça,Telèfon, `Telèfon Mòbil`) VALUES(@param_Nom,"
                      + "@param_Cognoms,@param_Comentaris,@param_DNI,@param_Adreça,@param_Telefon,@param_TelefonMobil)";
                MySqlCommand cmd = new MySqlCommand(Query, conn);
                    cmd.Parameters.AddWithValue("@param_Nom", txtBNom.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@param_Cognoms", txtBCognoms.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@param_Comentaris", COMENTARISBOX.Text);
                    cmd.Parameters.AddWithValue("@param_DNI", txtBDNI.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@param_Adreça", txtBAdreça.Text);
                    cmd.Parameters.AddWithValue("@param_Telefon", txtBTelefon.Text);
                    cmd.Parameters.AddWithValue("@param_TelefonMobil", txtBtelefonMobil.Text);
                   


                    MyReader2 = cmd.ExecuteReader();
                    MyReader2.Close();

                    conn.Close();

                    this.Close();

               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conn.Close();


            }

        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
