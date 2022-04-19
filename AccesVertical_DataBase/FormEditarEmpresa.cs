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
    public partial class FormEditarEmpresa : Form
    {

        private Connexio mysqlconnect;
        private string EmpresaId;
        public FormEditarEmpresa(Connexio connect, String EmpresaId)
        {

            
        mysqlconnect = connect;
            this.EmpresaId = EmpresaId;
            InitializeComponent();
            SelectedItems();
        }
        private void SelectedItems()
        {

            MySqlConnection conn = mysqlconnect.getmysqlconn();
            DataTable DtDadesAlumnes = new DataTable();

            MySqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "Select EmpresaID,Codi,`Nom de la empresa`,`CIF`, `Persona de contacte`, `Telèfon`,`Telèfon Mòbil`,`Correu electrònic` from Empreses where `Empreses`.`EmpresaID`= '" + EmpresaId + "'";
            conn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            reader.Read();
            try
            {
                txtBCodi.Text = !reader.IsDBNull(1) ? reader.GetString(1) : null;

                txtBNomEmpresa.Text = !reader.IsDBNull(2) ? reader.GetString(2) : null;

                txtBCIF.Text = !reader.IsDBNull(3) ? reader.GetString(3) : null;
                txtBPersonaContacte.Text = !reader.IsDBNull(4) ? reader.GetString(4) : null;
                txtBTelèfon.Text = !reader.IsDBNull(5) ? reader.GetString(5) : null;
                txtBTelefonMobil.Text = !reader.IsDBNull(6) ? reader.GetString(6) : null;
                txtBCorreuelectronic.Text = !reader.IsDBNull(7) ? reader.GetString(7) : null;


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
            conn.Open();
            MySqlDataReader MyReader2;

            try
            {


                string Query = "UPDATE Empreses SET  `Codi` =@Codi,`Nom de la empresa`=@NomEmpresa"
                    + ", `CIF`=@CIF,`Persona de contacte`=@PersonaContacte, `Telèfon`=@Telefon,`Telèfon Mòbil`=@TelefonMobil"
                    + ", `Correu electrònic`=@Email"
                    + " where EmpresaID=@EmpresaID;";
                MySqlCommand cmd = new MySqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@Codi", txtBCodi.Text);
                cmd.Parameters.AddWithValue("@NomEmpresa", txtBNomEmpresa.Text);
                cmd.Parameters.AddWithValue("@CIF", txtBCIF.Text);
                cmd.Parameters.AddWithValue("@PersonaContacte", txtBPersonaContacte.Text);
                cmd.Parameters.AddWithValue("@Telefon", txtBTelèfon.Text);
                cmd.Parameters.AddWithValue("@TelefonMobil", txtBTelefonMobil.Text);
                cmd.Parameters.AddWithValue("@Email", txtBCorreuelectronic.Text);
                cmd.Parameters.AddWithValue("@EmpresaID", EmpresaId);
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

        private void btAnular_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
