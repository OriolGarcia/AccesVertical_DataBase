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
    public partial class FormAltaComercial: Form
    {

        private Connexio mysqlconnect;
        public FormAltaComercial(Connexio connect)
        {
            mysqlconnect = connect;
            InitializeComponent();
            InitializeComboBoxInformat();
            InitializeComboBoxCursos();
        }
        private void InitializeComboBoxCursos()
        {

            try
            {
                MySqlConnection conn = mysqlconnect.getmysqlconn();

                string query = "SELECT TipusCursID,  Nom from TipusCursos Order by Nom";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter mdaDades = new MySqlDataAdapter(cmd);
                DataTable DtDadesInformat = new DataTable();

                mdaDades.Fill(DtDadesInformat);
                comboBoxCursos.ValueMember = "TipusCursID";
                comboBoxCursos.DisplayMember = "Nom";
                comboBoxCursos.DataSource = DtDadesInformat;

                conn.Close();
                
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
                string Query = "SELECT COUNT(*) FROM ComercialGeneral WHERE((`Nom Persona`=@param_Nom)AND (Cognoms=@param_Cognoms)AND LENGTH(?@param_Nom) >1 AND  LENGTH(@param_Cognoms) >1)";
                MySqlCommand cmd = new MySqlCommand(Query, conn);
               cmd.Parameters.AddWithValue("@param_Nom", txtBNom.Text.ToUpper());
                cmd.Parameters.AddWithValue("@param_Cognoms", txtBCognoms.Text.ToUpper());
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                int count = !reader.IsDBNull(0) ? reader.GetInt16(0) : 0;
                reader.Close();
                Query = "SELECT COUNT(*) FROM ComercialGeneral WHERE(`Correu electrònic`=@param_Email AND LENGTH(?@param_Email) >1)";
                cmd = new MySqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@param_Email", txtBEMAIL.Text);
                reader = cmd.ExecuteReader();
                reader.Read();
                int count2 = !reader.IsDBNull(0) ? reader.GetInt16(0) : 0;
                reader.Close();
                var inserir = DialogResult.Yes;
                if (count > 0)
                {
                  inserir=  MessageBox.Show("Ja exiteix un registre amb aquest nom i cognom. Segur que vols inserir de nou el registre?","Confirmació d'insersió", MessageBoxButtons.YesNo);
                }
                if (count2 > 0 && (inserir == DialogResult.Yes))
                {
                    inserir = MessageBox.Show("Ja exiteix un registre amb aquest correu elèctrònic. Segur que vols inserir de nou el registre?", "Confirmació d'insersió", MessageBoxButtons.YesNo);
                }
                if (inserir == DialogResult.Yes)
                {
                    Query = "INSERT INTO ComercialGeneral(`Tipus contacte`,`Nom Empresa`,`Nom Persona`,Cognoms,`Curs d'interès`,Mes,Informat, `Correu electrònic`,Comentaris,Telèfon,`Telèfon Mòbil`,`Data de preferència` ) "
                        + "VALUES(@Tipuscontacte,@NomEmpresa,@param_Nom,@param_Cognoms,@param_Cursos,@param_mes,@param_Informat,@param_Email,@param_Comentaris,@param_Telefon,@param_TelefonMobil,@DataPrefer);";
                    cmd = new MySqlCommand(Query, conn);
                    cmd.Parameters.AddWithValue("@Tipuscontacte", comboBTipusContacte.SelectedItem);
                    cmd.Parameters.AddWithValue("@NomEmpresa", txtBNomEmpresa.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@param_Nom", txtBNom.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@param_Cognoms", txtBCognoms.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@param_Mes", comboBMes.SelectedItem);
                    cmd.Parameters.AddWithValue("@param_Email", txtBEMAIL.Text);
                    cmd.Parameters.AddWithValue("@param_Telefon", txtBTelefon.Text);
                    cmd.Parameters.AddWithValue("@param_TelefonMobil", txtBtelefonMobil.Text);
                    cmd.Parameters.AddWithValue("@param_Cursos", comboBoxCursos.SelectedValue);
                    cmd.Parameters.AddWithValue("@param_Informat", comboBoxInformat.SelectedValue);
                    cmd.Parameters.AddWithValue("@param_Comentaris", COMENTARISBOX.Text);
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

        private void txtBNom_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
