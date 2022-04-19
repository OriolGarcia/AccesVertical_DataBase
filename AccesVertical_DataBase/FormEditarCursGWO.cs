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
    public partial class FormEditarCursGWO : Form
    {
        String id;
        private Connexio mysqlconnect;
        public FormEditarCursGWO(Connexio connect,String id)
        {
            mysqlconnect = connect;
            this.id = id;
            InitializeComponent();
            InitializeComboboxEmpreses();
            InitializeComboboxFormadors();
            SelectedItems();
        }

        private void SelectedItems()
        {


            MySqlConnection conn = mysqlconnect.getmysqlconn();

            try
            {
                MySqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "Select * from CursosGWO where CursGWOID= '" + id + "'";
                conn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                reader.Read();

                txtBCodi.Text = !reader.IsDBNull(1) ? reader.GetString(1) : null;
                txtBTitol.Text = !reader.IsDBNull(2) ? reader.GetString(2) : null;
                comboBMes.SelectedItem = !reader.IsDBNull(3) ? reader.GetString(3) : null;
                 dtPickerDataInici.Value = !reader.IsDBNull(4) ? reader.GetDateTime(4) : new DateTime();
                dtPickerDataFi.Value = !reader.IsDBNull(5) ? reader.GetDateTime(5) : new DateTime();
                dateTimePickerDataVenciment.Value = !reader.IsDBNull(6) ? reader.GetDateTime(6) : new DateTime();
                numericUpDownHores.Value = !reader.IsDBNull(7) ? reader.GetInt16(7) : 0;
                txtBHorari.Text = !reader.IsDBNull(8) ? reader.GetString(8) : null;
               comboBoxEmpreses.SelectedValue = !reader.IsDBNull(9) ? reader.GetString(9) : null;
                comboBoxFormadors.SelectedValue = !reader.IsDBNull(10) ? reader.GetString(10) : null;
                textBUbicacio.Text = !reader.IsDBNull(11) ? reader.GetString(11) : null;
                textBPais.Text = !reader.IsDBNull(12) ? reader.GetString(12) : null;
                checkBFinalitzat.Checked = !reader.IsDBNull(13) ? reader.GetBoolean(13) : false;
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











        private void InitializeComboboxFormadors()
        {

            try
            {
                MySqlConnection conn = mysqlconnect.getmysqlconn();

                string query = "SELECT FormadorID, CONCAT(Nom, ' ', Cognoms) as `NomCognoms` from Formadors  ORDER BY Cognoms,Nom ASC";

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

                string query = "SELECT EmpresaID,  `Nom de la empresa` from Empreses  ORDER BY `Nom de la empresa` ASC";

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
        private void dtPickerDataInici_ValueChanged(object sender, EventArgs e)
        {
            DateTime Data = dtPickerDataInici.Value;
            Data = Data.AddDays(5);
            dtPickerDataFi.Value = Data;
            Data = Data.AddYears(2);
            dateTimePickerDataVenciment.Value = Data;
        }

        private void dtPickerDataFi_ValueChanged(object sender, EventArgs e)
        {
            DateTime Data = dtPickerDataFi.Value;
            DateTime Data2 = dtPickerDataInici.Value;
            if (Data2 > Data)
            {
                dtPickerDataInici.Value = Data;
            }
            Data = Data.AddYears(2);
            dateTimePickerDataVenciment.Value = Data;
        }

        private void btAnular_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btEditarCursGWO_Click(object sender, EventArgs e)
        {

            MySqlConnection conn = mysqlconnect.getmysqlconn();
            conn.Open();
            MySqlDataReader MyReader2;

            try
            {


                string Query = "UPDATE CursosGWO SET  `Codi Curs GWO` =@Codi,Titol=@Titol,Mes=@Mes,"
                    + " `Data d'inici`=@Datainici"
                    + ", `Data fi`=@Datafi,`Data de venciment`=@Datavenciment,`Duració en hores`=@DuracioEnHores,Horari=@Horari,"
                    + "Empresa=@Empresa,Formador=@Formador,Ubicació=@Ubicacio,Pais=@Pais,Finalitzat=@Finalitzat where CursGWOID=@CursGWOID;";
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
                cmd.Parameters.AddWithValue("@Ubicacio", textBUbicacio.Text);
                cmd.Parameters.AddWithValue("@Pais", textBPais.Text);
                cmd.Parameters.AddWithValue("@Finalitzat", checkBFinalitzat.Checked);
                cmd.Parameters.AddWithValue("@CursGWOID",id);
                
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
    }
}
