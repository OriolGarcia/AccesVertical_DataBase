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
    public partial class FormNouMonogràfic : Form
    {

        private Connexio mysqlconnect;
        string MonograficID;
       
        public FormNouMonogràfic(Connexio connect)
        {   
            mysqlconnect = connect;
            
            InitializeComponent();
            InitializeComboboxEmpresa();
            InitializeComboboxMonograficTipus();
            comboBoxEmpreses.SelectedValue = 1;

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

                string query = "SELECT MonograficTipusID,  Titol from MonograficsTipus  ORDER BY Titol ASC";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter mdaDades = new MySqlDataAdapter(cmd);
                DataTable DtDadesMonografic = new DataTable();

                mdaDades.Fill(DtDadesMonografic);
                comboBoxMonograficTipus.ValueMember = "MonograficTipusID";
                comboBoxMonograficTipus.DisplayMember = "Titol";
                comboBoxMonograficTipus.DataSource = DtDadesMonografic ;

                conn.Close();

                //comboBoxMonograficTipus.SelectedValue = 0;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }


        }


        private void btAnular_Click(object sender, EventArgs e)
        {
            Close();
        }

       

       

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtBModalitat_TextChanged(object sender, EventArgs e)
        {

        }

        private void btInserirMonografic_Click(object sender, EventArgs e)
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
                cmd.Parameters.AddWithValue("@Ubicació",comboBoxUbicació.SelectedItem);
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
        private void formEditorMonografics_FormClosed(object sender, FormClosedEventArgs e)
        {

            InitializeComboboxMonograficTipus();

        }

        //
        private void btEditorMonograficsTipus_Click(object sender, EventArgs e)
        {

          FormEditordeModelsMonografics formEditorMonografics = new FormEditordeModelsMonografics(mysqlconnect);

            formEditorMonografics.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formEditorMonografics_FormClosed);

            formEditorMonografics.Show();
        }
    }
}
