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
    public partial class FormDuplicarMonografic : Form
    {
        private Connexio mysqlconnect;
        string MonograficID;
        public FormDuplicarMonografic(Connexio connect, string MonograficID)
        {
            mysqlconnect = connect;
            this.MonograficID = MonograficID;
            InitializeComponent();
            InitializeComboboxEmpresa();
            InitializeComboboxMonograficTipus();
            SelectedItems();
        }



        private void InitializeComboboxEmpresa()
        {

            try
            {
                MySqlConnection conn = mysqlconnect.getmysqlconn();

                string query = "SELECT EmpresaID,  `Nom de la empresa` from Empreses ORDER BY `Nom de la empresa` ASC";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter mdaDades = new MySqlDataAdapter(cmd);
                DataTable DtDadesEmpresa = new DataTable();

                mdaDades.Fill(DtDadesEmpresa);
                comboBoxEmpreses.ValueMember = "EmpresaID";
                comboBoxEmpreses.DisplayMember = "Nom de la empresa";
                comboBoxEmpreses.DataSource = DtDadesEmpresa;

                conn.Close();
                //comboBoxEmpresa.SelectedValue = "";
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }


        }
        private void InitializeComboboxMonograficTipus()
        {

            try
            {
                MySqlConnection conn = mysqlconnect.getmysqlconn();

                string query = "SELECT MonograficTipusID,  Titol from MonograficsTipus   ORDER BY Titol ASC";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter mdaDades = new MySqlDataAdapter(cmd);
                DataTable DtDadesMonografic = new DataTable();

                mdaDades.Fill(DtDadesMonografic);
                comboBoxMonograficTipus.ValueMember = "MonograficTipusID";
                comboBoxMonograficTipus.DisplayMember = "Titol";
                comboBoxMonograficTipus.DataSource = DtDadesMonografic;

                conn.Close();

                //comboBoxMonograficTipus.SelectedValue = 0;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }


        }

        private void SelectedItems()
        {


            MySqlConnection conn = mysqlconnect.getmysqlconn();

            try
            {
                MySqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "Select * from Monografics where MonograficID= '" + MonograficID + "'";
                conn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                reader.Read();

                txtBCodi.Text = !reader.IsDBNull(1) ? reader.GetString(1) : null;
                txtBTitol.Text = !reader.IsDBNull(2) ? reader.GetString(2) : null;
                txtBCodiAF.Text = !reader.IsDBNull(3) ? reader.GetString(3) : null;
                txtBGrup.Text = !reader.IsDBNull(4) ? reader.GetString(4) : null;
                dtPickerDataInici.Value = !reader.IsDBNull(5) ? reader.GetDateTime(5) : new DateTime();
                dtPickerDataFi.Value = !reader.IsDBNull(6) ? reader.GetDateTime(6) : new DateTime();
                numericUpDownHores.Value = !reader.IsDBNull(7) ? reader.GetInt16(7) : 0;
                txtBHorari.Text = !reader.IsDBNull(8) ? reader.GetString(8) : null;
                txtBModalitat.Text = !reader.IsDBNull(9) ? reader.GetString(9) : null;
                comboBoxMonograficTipus.SelectedValue = !reader.IsDBNull(10) ? reader.GetString(10) : null;
                comboBoxEmpreses.SelectedValue = !reader.IsDBNull(11) ? reader.GetString(11) : null;
                comboBoxUbicació.SelectedItem = !reader.IsDBNull(12) ? reader.GetString(12) : null;
                checkBFinalitzat.Checked = !reader.IsDBNull(13) ? reader.GetBoolean(13) : false;
                checkBoxBonificat.Checked = !reader.IsDBNull(14) ? reader.GetBoolean(14) : false;
                reader.Close();


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
        private void FormDuplicarMonografic_Load(object sender, EventArgs e)
        {

        }
        private void formEditorMonografics_FormClosed(object sender, FormClosedEventArgs e)
        {

            InitializeComboboxMonograficTipus();

        }

        private void btEditorMonograficsTipus_Click(object sender, EventArgs e)
        {

            FormEditordeModelsMonografics formEditorMonografics = new FormEditordeModelsMonografics(mysqlconnect);

            formEditorMonografics.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formEditorMonografics_FormClosed);

            formEditorMonografics.Show();
        }

        private void btDuplicarMonografic_Click(object sender, EventArgs e)
        {

            MySqlConnection conn = mysqlconnect.getmysqlconn();
            try
            {

                string Query = "INSERT INTO Monografics (Codi,Titol,`Codi AF`,Grup,`Data inici`,`Data fi`,"
                    + "`Duració en hores`,Horari,Modalitat,MonograficTipus,Empresa,Ubicació,Finalitzat,Bonificat) VALUES(@Codi,@Titol,@CodiAF,@Grup,@Datainici,@Datafi"
                    + ",@DuracioEnHores,@Horari,@Modalitat,@MonograficTipus,@Empresa,@Ubicació,@Finalitzat, @Bonificat);";
                MySqlCommand cmd = new MySqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@Codi", txtBCodi.Text);
                cmd.Parameters.AddWithValue("@Titol", txtBTitol.Text);
                cmd.Parameters.AddWithValue("@CodiAF", txtBCodiAF.Text);
                cmd.Parameters.AddWithValue("@Grup", txtBGrup.Text);
                cmd.Parameters.AddWithValue("@Datainici", dtPickerDataInici.Value.Date.ToString("yyyy-MM-dd HH:mm"));
                cmd.Parameters.AddWithValue("@Datafi", dtPickerDataFi.Value.Date.ToString("yyyy-MM-dd HH:mm"));
                cmd.Parameters.AddWithValue("@DuracioEnHores", numericUpDownHores.Value);
                cmd.Parameters.AddWithValue("@Horari", txtBHorari.Text);
                cmd.Parameters.AddWithValue("@Modalitat", txtBModalitat.Text);
                cmd.Parameters.AddWithValue("@MonograficTipus", comboBoxMonograficTipus.SelectedValue);
                cmd.Parameters.AddWithValue("@Empresa", comboBoxEmpreses.SelectedValue);
                cmd.Parameters.AddWithValue("@Ubicació", comboBoxUbicació.SelectedItem);
                cmd.Parameters.AddWithValue("@Finalitzat", checkBFinalitzat.Checked);
                cmd.Parameters.AddWithValue("@Bonificat", checkBoxBonificat.Checked);
                MySqlDataReader MyReader2;
                conn.Open();
                MyReader2 = cmd.ExecuteReader();

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
    }
}
