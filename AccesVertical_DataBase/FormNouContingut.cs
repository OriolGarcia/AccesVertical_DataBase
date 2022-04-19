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
    public partial class FormNouContingut : Form
    {
        private Connexio mysqlconnect;
        public FormNouContingut(Connexio connect)
        {
            mysqlconnect = connect;
            InitializeComponent();
            InitializeComboboxTipusModul();
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
        private void btInserir_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = mysqlconnect.getmysqlconn();
            MySqlDataReader MyReader2;
            try
            {

                string Query = "INSERT INTO Contingut(Titol,Subtitols,`Tipus de modul`) VALUES("
                    + "@Titol,@subtitols,@TipusModul); ";
                MySqlCommand cmd = new MySqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@Titol", txtBTitol.Text);
                cmd.Parameters.AddWithValue("@subtitols", txtBSubtitols.Text);
                cmd.Parameters.AddWithValue("@TipusModul", comboBoxTipusModul.SelectedValue);
                
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

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
