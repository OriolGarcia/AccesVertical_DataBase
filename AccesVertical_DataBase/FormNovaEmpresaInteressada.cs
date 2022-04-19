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
    public partial class FormNovaEmpresaInteressada : Form
    {

        private Connexio mysqlconnect;
        public FormNovaEmpresaInteressada(Connexio connect)
        {

            mysqlconnect = connect;
            InitializeComponent();
            InitializeComboBoxCursos();
            InitializeComboBoxInformat();
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
        private void btInserir_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = mysqlconnect.getmysqlconn();
            MySqlDataReader MyReader2;
            try
            {
                conn.Open();
                string Query = "SELECT COUNT(*) FROM ComercialEmpreses WHERE(`Nom de la empresa`=@param_NomEmpresa)";
                MySqlCommand cmd = new MySqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@param_NomEmpresa", txtBNomEmpresa.Text);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                int count = !reader.IsDBNull(0) ? reader.GetInt16(0) : 0;
                reader.Close();
                Query = "SELECT COUNT(*) FROM ComercialEmpreses WHERE(`Persona de contacte`=@param_contacte)";
                cmd = new MySqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@param_contacte", txtBContacte.Text);
                reader = cmd.ExecuteReader();
                reader.Read();
                int count2 = !reader.IsDBNull(0) ? reader.GetInt16(0) : 0;
                reader.Close();
                var inserir = DialogResult.Yes;
                if (count > 0)
                {
                    inserir = MessageBox.Show("´Ja exiteix un registre amb aquest nom d'empresa. Segur que vols inserir de nou el registre?", "Confirmació d'insersió", MessageBoxButtons.YesNo);
                }
                if (count2 > 0&&(inserir == DialogResult.Yes))
                {
                    inserir = MessageBox.Show("Ja exiteix un registre amb aquesta  persona de contacte. Segur que vols inserir de nou el registre?", "Confirmació d'insersió", MessageBoxButtons.YesNo);
                }
                if (inserir == DialogResult.Yes)
                {
                    Query = "INSERT INTO comercialempreses(`Nom de la empresa`,`Curs d'interès`,Mes,Informat,`Persona de contacte`,Comentaris,"
                    + "Telèfon,`Telèfon Mòbil`,`Correu electrònic`,`Data de preferència`) VALUES(@NomEmpresa,@CursInteres,@Mes,@Informat,@Contacte,@Comentaris,@Telefon,@TelefonMobil,@Email,@DataPrefer); ";
                    cmd = new MySqlCommand(Query, conn);
                    cmd.Parameters.AddWithValue("@NomEmpresa", txtBNomEmpresa.Text);
                    cmd.Parameters.AddWithValue("@CursInteres", comboBoxCursos.SelectedValue);
                    cmd.Parameters.AddWithValue("@Mes", comboBMes.SelectedItem);
                    cmd.Parameters.AddWithValue("@Informat", comboBoxInformat.SelectedValue);
                    cmd.Parameters.AddWithValue("@Contacte", txtBContacte.Text);
                    cmd.Parameters.AddWithValue("@Comentaris", COMENTARISBOX.Text);
                    cmd.Parameters.AddWithValue("@Telefon", txtBTelefon.Text);
                    cmd.Parameters.AddWithValue("@TelefonMobil", txtBtelefonMobil.Text);
                    cmd.Parameters.AddWithValue("@Email", txtBEMAIL.Text);
                    cmd.Parameters.AddWithValue("@DataPrefer", DTPDataPrefer.Value.Date.ToString("yyyy-MM-dd HH:mm"));




                    MyReader2 = cmd.ExecuteReader();
                    MyReader2.Close();
                    this.Close();
                }

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
            this.Close();
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
    }
}
