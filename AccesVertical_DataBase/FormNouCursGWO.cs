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
    public partial class FormNouCursGWO : Form
    {
        private Connexio mysqlconnect;
        public FormNouCursGWO(Connexio connect)
        {
            mysqlconnect = connect;
            InitializeComponent();
            InitializeComboboxEmpreses();
            InitializeComboboxFormadors();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void InitializeComboboxFormadors()
        {

            try
            {
                MySqlConnection conn = mysqlconnect.getmysqlconn();

                string query = "SELECT FormadorID, CONCAT(Nom, ' ', Cognoms) as `NomCognoms` from Formadors ORDER BY Cognoms,Nom ASC";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter mdaDades = new MySqlDataAdapter(cmd);
                DataTable DtDadesEmpresa = new DataTable();

                mdaDades.Fill(DtDadesEmpresa);
                comboBoxFormadors.ValueMember = "FormadorID";
                comboBoxFormadors.DisplayMember = "NomCognoms";
                comboBoxFormadors.DataSource = DtDadesEmpresa;

                conn.Close();
                //comboBoxEmpresa.SelectedValue = "";
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }


        }
        private void InitializeComboboxEmpreses()
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
        private void btAnular_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btInserirCursGWO_Click(object sender, EventArgs e)
        {

            MySqlConnection conn = mysqlconnect.getmysqlconn();
            try
            {

                string Query = "INSERT INTO CursosGWO (`Codi Curs GWO`,Titol,Mes,`Data d'inici`,`Data fi`,`Data de venciment`,`Duració en hores`,"
                    + "Horari,Empresa,Formador,Ubicació,Pais,Finalitzat) VALUES(@Codi,@Titol,@Mes,@Datainici,@Datafi,@Datavenciment"
                    + ",@DuracioEnHores,@Horari,@Empresa,@Formador,@Ubicació,@Pais,@Finalitzat);";
                MySqlCommand cmd = new MySqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@Codi", txtBCodi.Text);
                cmd.Parameters.AddWithValue("@Titol", txtBTitol.Text);
                cmd.Parameters.AddWithValue("@Mes", comboBMes.SelectedItem);
                cmd.Parameters.AddWithValue("@Datainici", dtPickerDataInici.Value.Date.ToString("yyyy-MM-dd HH:mm"));
                cmd.Parameters.AddWithValue("@Datafi", dtPickerDataFi.Value.Date.ToString("yyyy-MM-dd HH:mm"));
                cmd.Parameters.AddWithValue("@Datavenciment", dateTimePickerDataVenciment.Value.Date.ToString("yyyy-MM-dd HH:mm"));
                cmd.Parameters.AddWithValue("@DuracioEnHores", numericUpDownHores.Value);
                cmd.Parameters.AddWithValue("@Horari", txtBHorari.Text);
                cmd.Parameters.AddWithValue("@Empresa", comboBoxEmpreses.SelectedValue);
                cmd.Parameters.AddWithValue("@Formador", comboBoxFormadors.SelectedValue);
                cmd.Parameters.AddWithValue("@Ubicació", textBUbicacio.Text);
                cmd.Parameters.AddWithValue("@Pais", textBPais.Text);
                cmd.Parameters.AddWithValue("@Finalitzat", checkBFinalitzat.Checked);
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

        private void dtPickerDataInici_ValueChanged(object sender, EventArgs e)
        {

            DateTime Data = dtPickerDataInici.Value;
            Data = Data.AddDays(2);
            dtPickerDataFi.Value = Data;
            Data = Data.AddYears(2);
            dateTimePickerDataVenciment.Value = Data;
        }

        private void dtPickerDataFi_ValueChanged(object sender, EventArgs e)
        {
            DateTime Data = dtPickerDataFi.Value;
            DateTime Data2 = dtPickerDataInici.Value;
            if (Data2 > Data){ dtPickerDataInici.Value = Data;
        }
            Data = Data.AddYears(2);
            dateTimePickerDataVenciment.Value = Data;
        }

        private void textBPais_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
