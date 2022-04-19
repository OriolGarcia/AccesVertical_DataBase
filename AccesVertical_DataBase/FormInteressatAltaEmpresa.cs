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
    public partial class FormInteressatAltaEmpresa : Form
    {

        string EmpresaId;
        private Connexio mysqlconnect;
        public FormInteressatAltaEmpresa(Connexio connect, string EmpresaId)
        {
            mysqlconnect = connect;
            this.EmpresaId = EmpresaId;
            InitializeComponent();
            SelectedItems();
        }

        private void SelectedItems()
        {

            MySqlConnection conn = mysqlconnect.getmysqlconn();
            DataTable DtDadesEmpreses= new DataTable();

            MySqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "Select EmpresaInteressadaID, `Nom de la empresa`,`Persona de contacte`,`Correu electrònic`,`Telèfon`,`Telèfon Mòbil`"
                + " from ComercialEmpreses where EmpresaInteressadaID= '" + EmpresaId + "'";
            conn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            reader.Read();
            try
            {

                txtBNomEmpresa.Text = !reader.IsDBNull(1) ? reader.GetString(1) : null;
                txtBPersonaContacte.Text = !reader.IsDBNull(2) ? reader.GetString(2) : null;
                txtBCorreuelectronic.Text = !reader.IsDBNull(3) ? reader.GetString(3) : null;
                txtBTelèfon.Text = !reader.IsDBNull(4) ? reader.GetString(4) : null;
                txtBtelefonMobil.Text = !reader.IsDBNull(5) ? reader.GetString(5) : null;
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
        private void btEditarEmpresa_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = mysqlconnect.getmysqlconn();
            MySqlDataReader MyReader2;
            try
            {

                string Query = "INSERT INTO empreses(Codi, `Nom de la empresa`, CIF, `Persona de contacte`, telèfon,`Telèfon Mòbil`, `Correu electrònic`) VALUES(@Codi,"
                  + "@NomEmpresa,@CIF,@PersonaContacte,@Telefon,@TelefonMobil,@Email); ";
                MySqlCommand cmd = new MySqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@Codi", txtBCodi.Text);
                cmd.Parameters.AddWithValue("@NomEmpresa", txtBNomEmpresa.Text.ToUpper());
                cmd.Parameters.AddWithValue("@CIF", txtBCIF.Text);
                cmd.Parameters.AddWithValue("@PersonaContacte", txtBPersonaContacte.Text);
                cmd.Parameters.AddWithValue("@Telefon", txtBTelèfon.Text);
                cmd.Parameters.AddWithValue("@TelefonMobil", txtBtelefonMobil.Text);
                cmd.Parameters.AddWithValue("@Email", txtBCorreuelectronic.Text);
                conn.Open();
                MyReader2 = cmd.ExecuteReader();
                MyReader2.Close();
                conn.Close();

                var confirmEliminar = MessageBox.Show("Vols eliminar aquest registre de Comercial Empreses?",
                  "Confirmació d'Eliminació!",
                  MessageBoxButtons.YesNo);
                if (confirmEliminar == DialogResult.Yes)
                {
                    Query = "delete from ComercialEmpreses where EmpresaInteressadaID=" + EmpresaId + ";";
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

        private void btAnular_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
