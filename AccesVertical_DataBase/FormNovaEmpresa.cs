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
    public partial class FormNovaEmpresa : Form
    {

        private Connexio mysqlconnect;
        public FormNovaEmpresa(Connexio connect)
        {

            mysqlconnect = connect;
            InitializeComponent();
        }

        private void FormNovaEmpresa_Load(object sender, EventArgs e)
        {

        }

        private void btInserirEmpresa_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = mysqlconnect.getmysqlconn();
            MySqlDataReader MyReader2;
            try
            {
                conn.Open();
                string Query = "SELECT COUNT(*) FROM Empreses WHERE(`Nom de la empresa`=@param_NomEmpresa)";
                MySqlCommand cmd = new MySqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@param_NomEmpresa", txtBNomEmpresa.Text);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                int count = !reader.IsDBNull(0) ? reader.GetInt16(0) : 0;
                reader.Close();
                var inserir = DialogResult.Yes;
                if (count > 0)
                {
                    inserir = MessageBox.Show("Ja exiteix un registre amb nom d'empresa. Segur que vols inserir de nou el registre?", "Confirmació d'insersió", MessageBoxButtons.YesNo);
                }
                if (inserir == DialogResult.Yes && (inserir == DialogResult.Yes))
                {
                     Query = "INSERT INTO empreses(Codi, `Nom de la empresa`, CIF, `Persona de contacte`, telèfon,`Telèfon Mòbil`, `Correu electrònic`) VALUES("
                    + "@Codi,@NomEmpresa,@CIF,@PersonaContacte,@Telefon,@TelefonMobil,@Email); ";
                    cmd = new MySqlCommand(Query, conn);
                    cmd.Parameters.AddWithValue("@Codi", txtBCodi.Text);
                    cmd.Parameters.AddWithValue("@NomEmpresa", txtBNomEmpresa.Text);
                    cmd.Parameters.AddWithValue("@CIF", txtBCIF.Text);
                    cmd.Parameters.AddWithValue("@PersonaContacte", txtBPersonaContacte.Text);
                    cmd.Parameters.AddWithValue("@Telefon", txtBTelèfon.Text);
                    cmd.Parameters.AddWithValue("@TelefonMobil", txtBTelefonMobil.Text);
                    cmd.Parameters.AddWithValue("@Email", txtBCorreuelectronic.Text);
                   
                    MyReader2 = cmd.ExecuteReader();
                    MyReader2.Close();
                        conn.Close();
                        this.Close();
                }
                conn.Close();

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

        private void btAnular_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
