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
    public partial class AltaAlumne : Form
    {

        private Connexio mysqlconnect;
        public AltaAlumne(Connexio connect,bool ANETVA,bool GWO)
        {
            mysqlconnect = connect;

            InitializeComponent();
            InitializeComboboxEmpresa();
            ANETVABOX.Checked = ANETVA;
            GWOBOX.Checked = GWO;
        }
        private void InitializeComboboxEmpresa()
        {

            try
            {
                MySqlConnection conn = mysqlconnect.getmysqlconn();

                string query = "SELECT EmpresaID,  `Nom de la empresa` from Empreses ORDER BY  `Nom de la empresa` ASC";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter mdaDades = new MySqlDataAdapter(cmd);
                DataTable DtDadesEmpresa = new DataTable();

                mdaDades.Fill(DtDadesEmpresa);
                comboBoxEmpresa.ValueMember = "EmpresaID";
                comboBoxEmpresa.DisplayMember = "Nom de la empresa";
                comboBoxEmpresa.DataSource = DtDadesEmpresa;

                conn.Close();
                //comboBoxEmpresa.SelectedValue = "";
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }


        }
        private void AltaAlumne_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btInserir_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = mysqlconnect.getmysqlconn();
            MySqlDataReader MyReader2;
            try
            {

                conn.Open();
                string Query = "SELECT COUNT(*) FROM Alumnes WHERE((Nom=@param_Nom)AND (Cognoms=@param_Cognoms)AND LENGTH(?@param_Nom) >1 AND  LENGTH(@param_Cognoms) >1)";
                MySqlCommand cmd = new MySqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@param_Nom", txtBNom.Text.ToUpper());
                cmd.Parameters.AddWithValue("@param_Cognoms", txtBCognoms.Text.ToUpper());
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                int count = !reader.IsDBNull(0) ? reader.GetInt16(0) : 0;
                reader.Close();
                Query = "SELECT COUNT(*) FROM Alumnes WHERE(`Correu electrònic`=@param_Email AND LENGTH(?@param_Email) >1)";
                cmd = new MySqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@param_Email", txtBEMAIL.Text);
                reader = cmd.ExecuteReader();
                reader.Read();
                int count2 = !reader.IsDBNull(0) ? reader.GetInt16(0) : 0;
                reader.Close();
                Query = "SELECT COUNT(*) FROM Alumnes WHERE(`ID WINDA`=@param_IDWINDA AND LENGTH(?@param_IDWINDA) >1)";
                cmd = new MySqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@param_IDWINDA", textBIDWINDA.Text);
                reader = cmd.ExecuteReader();
                reader.Read();
                int count3 = !reader.IsDBNull(0) ? reader.GetInt16(0) : 0;
                reader.Close();
                var inserir = DialogResult.Yes;
                if (count > 0)
                {
                    inserir = MessageBox.Show("Ja exiteix un registre amb aquest nom i cognom. Segur que vols inserir de nou el registre?", "Confirmació d'insersió", MessageBoxButtons.YesNo);
                }
                if (count2 > 0 && (inserir == DialogResult.Yes))
                {
                    inserir = MessageBox.Show("Ja exiteix un registre amb aquest correu elèctrònic. Segur que vols inserir de nou el registre?", "Confirmació d'insersió", MessageBoxButtons.YesNo);
                }
                if (count3 > 0 && (inserir == DialogResult.Yes))
                {
                    inserir = MessageBox.Show("Ja exiteix un registre amb aquest ID WINDA. Segur que vols inserir de nou el registre?", "Confirmació d'insersió", MessageBoxButtons.YesNo);
                }
                if (inserir == DialogResult.Yes)
                {
                  Query = "INSERT INTO Alumnes ( Nom, Cognoms,`Comentaris`,DNI,`Correu electrònic`,Adreça,Telèfon, `Telèfon Mòbil`,`Data d'alta`, EmpresaID,`ID WINDA`,`ANETVA`,`GWO`) VALUES(@param_Nom,"
                    + "@param_Cognoms,@param_Comentaris ,@param_DNI,@param_Email,@param_Adreça,@param_Telefon,@param_TelefonMobil,@param_DataAlta"
                    + ",@param_Empresa,@param_IDWINDA, @param_ANETVA,@param_GWO)";
                    cmd = new MySqlCommand(Query, conn);
                    cmd.Parameters.AddWithValue("@param_Nom", txtBNom.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@param_Cognoms", txtBCognoms.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@param_Comentaris", COMENTARISBOX.Text);
                    cmd.Parameters.AddWithValue("@param_DNI", txtBDNI.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@param_Email", txtBEMAIL.Text);
                    cmd.Parameters.AddWithValue("@param_Adreça", txtBAdreça.Text);
                    cmd.Parameters.AddWithValue("@param_Telefon", txtBTelefon.Text);
                    cmd.Parameters.AddWithValue("@param_TelefonMobil", txtBtelefonMobil.Text);
                    cmd.Parameters.AddWithValue("@param_DataAlta", dtPDataalta.Value.Date.ToString("yyyy-MM-dd HH:mm"));
                    cmd.Parameters.AddWithValue("@param_Empresa", comboBoxEmpresa.SelectedValue);
                    cmd.Parameters.AddWithValue("@param_IDWINDA", textBIDWINDA.Text);
                    cmd.Parameters.AddWithValue("@param_ANETVA", ANETVABOX.Checked);
                    cmd.Parameters.AddWithValue("@param_GWO", GWOBOX.Checked);

                    MyReader2 = cmd.ExecuteReader();
                    MyReader2.Close();

                    conn.Close();

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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
