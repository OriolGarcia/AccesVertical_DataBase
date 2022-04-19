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
    public partial class FormEditarCursInterés : Form
    {

        private Connexio mysqlconnect;
        int CursTipusID;
        public FormEditarCursInterés(Connexio connect)
        {
            mysqlconnect = connect;
            InitializeComponent();
            InitializeComboboxCursTipus();
        }
        private void InitializeComboboxCursTipus()
        {

            try
            {
                MySqlConnection conn = mysqlconnect.getmysqlconn();

                string query = "SELECT TipusCursID,  Nom from TipusCursos ORDER BY Nom ASC";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter mdaDades = new MySqlDataAdapter(cmd);
                DataTable DtDadesMonografic = new DataTable();

                mdaDades.Fill(DtDadesMonografic);
                comboBoxCursTipus.ValueMember = "TipusCursID";
                comboBoxCursTipus.DisplayMember = "Nom";
                comboBoxCursTipus.DataSource = DtDadesMonografic;

                conn.Close();

                //comboBoxMonograficTipus.SelectedValue = 0;
            }
            catch (Exception err)
            {
                MessageBox.Show(0 + err.Message);

            }


        }

        private void btNouCursInteres_Click(object sender, EventArgs e)
        {
            //INSERT INTO monograficstipus(Titol) VALUES ("");
            MySqlConnection conn = mysqlconnect.getmysqlconn();
            MySqlDataReader reader;
            try
            {

                string Query = "INSERT INTO TipusCursos(Nom) VALUES (\"Nou Curs d'interès Sense Nom\")";
                MySqlCommand cmd = new MySqlCommand(Query, conn);
                conn.Open();
                reader = cmd.ExecuteReader();
                reader.Close();
                conn.Close();
                InitializeComboboxCursTipus();
                Query = "SELECT MAX(TipusCursID) from TipusCursos;";
                cmd = new MySqlCommand(Query, conn);

                conn.Open();
                reader = cmd.ExecuteReader();
                reader.Read();
                CursTipusID = !reader.IsDBNull(0) ? reader.GetInt16(0) : 0;

                reader.Close();
                comboBoxCursTipus.SelectedValue = CursTipusID;






            }
            catch (Exception ex)
            {
                MessageBox.Show(1 + ex.Message); ;

            }
            finally
            {
                conn.Close();

            }
        }

        private void btCanviarTitol_Click(object sender, EventArgs e)
        {

            MySqlConnection conn = mysqlconnect.getmysqlconn();
            conn.Open();
            MySqlDataReader MyReader2;
            if (CursTipusID > 1)
            {
                try
                {


                    string Query = "UPDATE TipusCursos SET  `Nom` =@Nom"
                        + " where TipusCursID=@TipusCursID;";
                    MySqlCommand cmd = new MySqlCommand(Query, conn);
                    cmd.Parameters.AddWithValue("@Nom", txtBNom.Text);
                    cmd.Parameters.AddWithValue("@TipusCursID", CursTipusID);
                    MyReader2 = cmd.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                    MyReader2.Close();
                    int temp = CursTipusID;
                    InitializeComboboxCursTipus();
                    CursTipusID = temp;
                    comboBoxCursTipus.SelectedValue = CursTipusID;

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
            else { MessageBox.Show("Aquest camp no és editable"); }
        }

        private void btEliminarCursTipus_Click(object sender, EventArgs e)
        {
            if (CursTipusID > 1)
            {

                var confirmEliminar = MessageBox.Show("Segur que vols eliminar aquest el Curs d'interès?",
                "Confirmació d'Eliminació!",
                MessageBoxButtons.YesNo);
                if (confirmEliminar == DialogResult.Yes)
                {
                    MySqlConnection conn = mysqlconnect.getmysqlconn();
                    try
                    {

                        string Query = "delete from TipusCursos where TipusCursID=" + CursTipusID + ";";
                        MySqlCommand cmd = new MySqlCommand(Query, conn);
                        MySqlDataReader MyReader2;
                        conn.Open();
                        MyReader2 = cmd.ExecuteReader();
                        MyReader2.Close();
                        conn.Close();
                        InitializeComboboxCursTipus();
                        comboBoxCursTipus.SelectedItem = null;


                    }
                    catch (MySqlException ex)
                    {
                        if (ex.Number == 1451) { MessageBox.Show("Hi ha monogràfics utilitzant aquest Monografic Tipus. No es pot esborrar"); }
                        else
                            MessageBox.Show(9 + ex.Message);
                    }
                    finally { conn.Close(); }


                }
            }
            else { MessageBox.Show("Aquest camp no és eliminable"); }
            }

        private void comboBoxCursTipus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCursTipus.SelectedItem == null)
            {
                groupBox1.Hide();


            }
            else
            {

                groupBox1.Show();
                txtBNom.Text = comboBoxCursTipus.Text;
                int.TryParse(comboBoxCursTipus.SelectedValue.ToString(), out CursTipusID);
              

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
