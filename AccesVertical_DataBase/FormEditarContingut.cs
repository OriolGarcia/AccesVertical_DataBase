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
    public partial class FormEditarContingut : Form
    {
        private Connexio mysqlconnect;
        private string ContingutId;
        public FormEditarContingut(Connexio connect, String ContingutId)
        {

            mysqlconnect = connect;
            this.ContingutId = ContingutId;
            InitializeComponent();
            InitializeComboboxTipusModul();
            SelectedItems();
        }
        private void InitializeComboboxTipusModul()
        {

            try
            {
                MySqlConnection conn = mysqlconnect.getmysqlconn();

                string query = "SELECT TipusModulID,  Titol from TipusModul";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter mdaDades = new MySqlDataAdapter(cmd);
                DataTable DtDadesContingut = new DataTable();

                mdaDades.Fill(DtDadesContingut);
                comboBoxTipusModul.ValueMember = "TipusModulID";
                comboBoxTipusModul.DisplayMember = "Titol";
                comboBoxTipusModul.DataSource = DtDadesContingut;

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

            cmd.CommandText = "Select * from Contingut where `Contingut`.`ContingutID`= '" + ContingutId + "'";
            conn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            reader.Read();
            try
            {
                txtBTitol.Text = !reader.IsDBNull(1) ? reader.GetString(1) : null;

                txtBSubtitols.Text = !reader.IsDBNull(2) ? reader.GetString(2) : null;
                comboBoxTipusModul.SelectedValue = !reader.IsDBNull(3) ? reader.GetString(3) : null;


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
            conn.Open();
            MySqlDataReader MyReader2;

            try
            {


                string Query = "UPDATE Contingut SET  Titol =@Titol,Subtitols=@Subtitols"
                    + ", `Tipus de modul`=@tipusModul"
                    + " where ContingutID=@contingutID;";
                MySqlCommand cmd = new MySqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@Titol", txtBTitol.Text);
                cmd.Parameters.AddWithValue("@Subtitols", txtBSubtitols.Text);
                cmd.Parameters.AddWithValue("@tipusModul", comboBoxTipusModul.SelectedValue);
                cmd.Parameters.AddWithValue("@contingutID", ContingutId);
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

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
