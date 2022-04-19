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
    public partial class FormNouCurs : Form
    {


        private Connexio mysqlconnect;
        public FormNouCurs(Connexio connect)
        {
            mysqlconnect = connect;
            InitializeComponent();
            InitializeDATA();
        }

        private void FormNouCurs_Load(object sender, EventArgs e)
        {

        }
        private void InitializeDATA() {

            DateTime Data = dtPdataInici.Value;
           Data= Data.AddYears(2);
            dtPdataVenciment.Value = Data;



        }
        private void btCrearCurs_Click(object sender, EventArgs e)
        {

            MySqlConnection conn = mysqlconnect.getmysqlconn();
            try
            {
                
                string Query = "INSERT INTO Cursos (Codi, Nom,Mes,`Data d'inici`,`Data fi`,`Data de venciment`) VALUES(@Codi"
                    + ",@NomCurs,@Mes,@dataInici,@dataFi,@dataVenciment);";
                MySqlCommand cmd = new MySqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@Codi", txtBCodi.Text);
                cmd.Parameters.AddWithValue("@NomCurs", txtBNomCurs.Text);
                cmd.Parameters.AddWithValue("@Mes", comboBMes.SelectedItem);
                cmd.Parameters.AddWithValue("@dataInici", dtPdataInici.Value.Date.ToString("yyyy-MM-dd HH:mm"));
                cmd.Parameters.AddWithValue("@dataFi", dtPdataFi.Value.Date.ToString("yyyy-MM-dd HH:mm"));
                cmd.Parameters.AddWithValue("@dataVenciment", dtPdataVenciment.Value.Date.ToString("yyyy-MM-dd HH:mm"));
                MySqlDataReader MyReader2;
                conn.Open();
                MyReader2 = cmd.ExecuteReader();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally {
                conn.Close();
                this.Close();
            }
        }

        private void btAnular_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtPdataVenciment_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dtPdataInici_ValueChanged(object sender, EventArgs e)
        {
            DateTime Data = dtPdataInici.Value;
            Data = Data.AddDays(5);
            dtPdataFi.Value = Data;
           Data=Data.AddYears(2);
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
