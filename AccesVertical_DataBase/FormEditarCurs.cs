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
    public partial class FormEditarCurs : Form
    {

        private Connexio mysqlconnect;
        private string CursId;
        public FormEditarCurs(Connexio connect, String CursId)
        {
            mysqlconnect = connect;
            this.CursId = CursId;
            InitializeComponent();
            SelectedItems();
        }

        private void SelectedItems()
        {

            MySqlConnection conn = mysqlconnect.getmysqlconn();
            DataTable DtDadesAlumnes = new DataTable();

            MySqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "Select `CursID`,`Codi`,`Nom`,`Mes`,`Data d'inici`,`Data fi`, `Data de venciment`"
                +"from Cursos where `Cursos`.`CursID`= '" + CursId + "'";
            conn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            reader.Read();
            try
            {
                 txtBCodi.Text = !reader.IsDBNull(1) ? reader.GetString(1) : null;

                txtBNomCurs.Text = !reader.IsDBNull(2) ? reader.GetString(2) : null;
                comboBMes.SelectedItem = !reader.IsDBNull(3) ? reader.GetString(3) : null;
                dtPdataInici.Value = !reader.IsDBNull(4) ? reader.GetDateTime(4) : new DateTime();
                dtPdataFi.Value = !reader.IsDBNull(5) ? reader.GetDateTime(5) : new DateTime();
                dtPdataVenciment.Value = !reader.IsDBNull(6) ? reader.GetDateTime(6) : new DateTime();


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

        private void btEditarCurs_Click(object sender, EventArgs e)
        {

            MySqlConnection conn = mysqlconnect.getmysqlconn();
            conn.Open();
            MySqlDataReader MyReader2;

            try
            {


                string Query = "UPDATE Cursos SET  Codi =@Codi,Nom =@NomCurs,Mes=@Mes"
                    + ", `Data d'inici`=@dataInici"
                      + ", `Data fi`=@dataFi"
                    + ", `Data de venciment`=@dataVenciment"
                    + " where CursID=@cursID;";
                MySqlCommand cmd = new MySqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@Codi", txtBCodi.Text);
                cmd.Parameters.AddWithValue("@NomCurs", txtBNomCurs.Text);
                cmd.Parameters.AddWithValue("@Mes", comboBMes.SelectedItem);
                cmd.Parameters.AddWithValue("@dataInici", dtPdataInici.Value.Date.ToString("yyyy-MM-dd HH:mm"));
                cmd.Parameters.AddWithValue("@dataFi", dtPdataFi.Value.Date.ToString("yyyy-MM-dd HH:mm"));
                cmd.Parameters.AddWithValue("@dataVenciment", dtPdataVenciment.Value.Date.ToString("yyyy-MM-dd HH:mm"));
                cmd.Parameters.AddWithValue("@cursID", CursId);
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
            Close();
        }

        private void dtPdataInici_ValueChanged(object sender, EventArgs e)
        {
            DateTime Data = dtPdataInici.Value;
            Data = Data.AddDays(5);
            dtPdataFi.Value = Data;
            Data = Data.AddYears(2);
            dtPdataVenciment.Value = Data;
        }

        private void dtPdataFi_ValueChanged(object sender, EventArgs e)
        {
            DateTime Data = dtPdataFi.Value;
            Data = Data.AddYears(2);
            dtPdataVenciment.Value = Data;
        }
    }
}
