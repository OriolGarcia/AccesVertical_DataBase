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
    public partial class FormModificarEmpresaInteressada : Form
    {


        string EmpresaId;
        private Connexio mysqlconnect;
        public FormModificarEmpresaInteressada(Connexio mysqlconnect, string EmpresaId)
        {
            this.EmpresaId = EmpresaId;
            this.mysqlconnect = mysqlconnect;
            InitializeComponent();
            InitializeComboBoxCursos();
            InitializeComboBoxInformat();
            SelectedItems();
        }

        private void InitializeComboBoxCursos()
        {

            try
            {
                MySqlConnection conn = mysqlconnect.getmysqlconn();

                string query = "SELECT TipusCursID,  Nom from TipusCursos";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter mdaDades = new MySqlDataAdapter(cmd);
                DataTable DtDadesInformat = new DataTable();

                mdaDades.Fill(DtDadesInformat);
                comboBoxCursos.ValueMember = "TipusCursID";
                comboBoxCursos.DisplayMember = "Nom";
                comboBoxCursos.DataSource = DtDadesInformat;

                conn.Close();
                //comboBoxEmpresa.SelectedValue = "";
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }

        }

        private void InitializeComboBoxInformat()
        {

            try
            {
                MySqlConnection conn = mysqlconnect.getmysqlconn();

                string query = "SELECT    InformatID,  Informat from Informat";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter mdaDades = new MySqlDataAdapter(cmd);
                DataTable DtDadesInformat = new DataTable();

                mdaDades.Fill(DtDadesInformat);
                comboBoxInformat.ValueMember = "InformatID";
                comboBoxInformat.DisplayMember = "Informat";
                comboBoxInformat.DataSource = DtDadesInformat;

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

            cmd.CommandText = "Select EmpresaInteressadaID, `Nom de la empresa`,`Curs d'interès`,`Persona de contacte`,`Correu electrònic`,`Telèfon`,`Informat`, Comentaris,`Data de preferència`,"
                + "`Telèfon Mòbil`,Mes"
                + " from ComercialEmpreses where EmpresaInteressadaID= '" + EmpresaId + "'";
            conn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            reader.Read();
            try
            {

                txtBNomEmpresa.Text = !reader.IsDBNull(1) ? reader.GetString(1) : null;
                comboBoxCursos.SelectedValue = !reader.IsDBNull(2) ? reader.GetString(2) : null;
                txtBContacte.Text = !reader.IsDBNull(3) ? reader.GetString(3) : null;
                txtBEMAIL.Text = !reader.IsDBNull(4) ? reader.GetString(4) : null;
                txtBTelefon.Text = !reader.IsDBNull(5) ? reader.GetString(5) : null;
                comboBoxInformat.SelectedValue = !reader.IsDBNull(6) ? reader.GetString(6) : null;
                COMENTARISBOX.Text = !reader.IsDBNull(7) ? reader.GetString(7) : null;
                DTPDataPrefer.Value = !reader.IsDBNull(8) ? reader.GetDateTime(8) : new DateTime();
                txtBtelefonMobil.Text = !reader.IsDBNull(9) ? reader.GetString(9) : null;
                comboBMes.SelectedItem = !reader.IsDBNull(10) ? reader.GetString(10) : null;
                reader.Close();

//
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

        private void btModificar_Click(object sender, EventArgs e)
        {

            MySqlConnection conn = mysqlconnect.getmysqlconn();
            conn.Open();
            MySqlDataReader MyReader2;

            try
            {


                string Query = "UPDATE ComercialEmpreses SET  `Nom de la empresa`=@NomEmpresa, `Curs d'interès`=@CursInteres,Mes=@Mes"
                 + ",`Persona de contacte`=@Contacte,`Correu electrònic`=@Email,`Telèfon`=@Telefon,`Telèfon Mòbil`=@TelefonMobil,Comentaris=@Comentaris"
                 + ",Informat=@Informat,`Data de preferència`=@DataPrefer"
                   + " where EmpresaInteressadaID=@EmpresaID;";
                MySqlCommand cmd = new MySqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@NomEmpresa", txtBNomEmpresa.Text.ToUpper());
                cmd.Parameters.AddWithValue("@CursInteres", comboBoxCursos.SelectedValue);
                cmd.Parameters.AddWithValue("@Mes", comboBMes.SelectedItem);
                cmd.Parameters.AddWithValue("@Informat", comboBoxInformat.SelectedValue);
                cmd.Parameters.AddWithValue("@Contacte", txtBContacte.Text);
                cmd.Parameters.AddWithValue("@Comentaris", COMENTARISBOX.Text);
                cmd.Parameters.AddWithValue("@Telefon", txtBTelefon.Text);
                cmd.Parameters.AddWithValue("@TelefonMobil", txtBtelefonMobil.Text);
                cmd.Parameters.AddWithValue("@Email", txtBEMAIL.Text);
                cmd.Parameters.AddWithValue("@EmpresaID",EmpresaId);
                cmd.Parameters.AddWithValue("@DataPrefer", DTPDataPrefer.Value.Date.ToString("yyyy-MM-dd HH:mm"));
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

        private void formEditarCursInteres_FormClosed(object sender, FormClosedEventArgs e)
        {

            InitializeComboBoxCursos();
        }
        private void btEditarCursInteres_Click(object sender, EventArgs e)
        {

            FormEditarCursInterés formEditarCursInteres = new FormEditarCursInterés(mysqlconnect);

            formEditarCursInteres.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formEditarCursInteres_FormClosed);

            formEditarCursInteres.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBoxInformat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
