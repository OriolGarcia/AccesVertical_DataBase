using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccesVertical_DataBase
{
    public partial class FormModificarAlumne: Form
    {
        string AlumneId;
        private Connexio mysqlconnect;
        public FormModificarAlumne(Connexio connect,string AlumneId)
        {
            mysqlconnect = connect;
            this.AlumneId = AlumneId;
            InitializeComponent();
            InitializeComboboxEmpresa();
           SelectedItems();
        }
        private void InitializeComboboxEmpresa()
        {

            try
            {
                MySqlConnection conn = mysqlconnect.getmysqlconn();

                string query = "SELECT EmpresaID,  `Nom de la empresa` from Empreses ORDER BY `Nom de la empresa` ASC ";

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
        private void SelectedItems()
        {

            MySqlConnection conn = mysqlconnect.getmysqlconn();
            DataTable DtDadesAlumnes = new DataTable();

            MySqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "Select `Alumnes`.`AlumneID`,`Alumnes`.`Nom`,`Alumnes`.`Cognoms`,`Alumnes`.`DNI`,`Alumnes`.`Telèfon`,`Alumnes`.`Correu electrònic`,"
       + "`Alumnes`.`Adreça`,`Alumnes`.`Data d'alta`, `Alumnes`.`EmpresaID`,`Alumnes`.`Telèfon Mòbil`,`Comentaris`,`ID WINDA`, `ANETVA`, `GWO` from Alumnes where `Alumnes`.`AlumneID`= '" + AlumneId + "'";
            conn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            reader.Read();
            try
            {
               
                txtBNom.Text = !reader.IsDBNull(1) ? reader.GetString(1) : null;
                txtBCognoms.Text = !reader.IsDBNull(2) ? reader.GetString(2) : null;
                txtBDNI.Text = !reader.IsDBNull(3) ? reader.GetString(3) : null;
                txtBTelefon.Text = !reader.IsDBNull(4) ? reader.GetString(4) : null;
                txtBEMAIL.Text = !reader.IsDBNull(5) ? reader.GetString(5) : null;
                txtBAdreça.Text = !reader.IsDBNull(6) ? reader.GetString(6) : null;
                dtPDataalta.Value = !reader.IsDBNull(7) ? reader.GetDateTime(7) : new DateTime();
                comboBoxEmpresa.SelectedValue = !reader.IsDBNull(8) ? reader.GetString(8) : null;
                txtBtelefonMobil.Text = !reader.IsDBNull(9) ? reader.GetString(9) : null;
                COMENTARISBOX.Text= !reader.IsDBNull(10) ? reader.GetString(10) : null;
                textBIDWINDA.Text = !reader.IsDBNull(11) ? reader.GetString(11) : null;
                ANETVABOX.Checked = !reader.IsDBNull(12) ? reader.GetBoolean(12) : false;
                GWOBOX.Checked = !reader.IsDBNull(13) ? reader.GetBoolean(13) : false;

                reader.Close();
                
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally {

                reader.Close();
                conn.Close();

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
            conn.Open();
            MySqlDataReader MyReader2;

            try
            {
             
               
                string Query = "UPDATE Alumnes SET  Nom =@param_Nom, Cognoms=@param_Cognoms,`Comentaris`=@param_Comentaris,DNI=@param_DNI"
                    + ",`Correu electrònic`=@param_Email,`Telèfon`=@param_Telefon,`Telèfon Mòbil`=@param_TelefonMobil,Adreça =@param_Adreça, `Data d'alta`=@param_DataAlta" +
                  ", EmpresaID =@param_Empresa,`ID WINDA`=@param_IDWINDA,`ANETVA`=@param_ANETVA,`GWO`=@param_GWO where AlumneID=@param_AlumneId;";
                MySqlCommand cmd = new MySqlCommand(Query, conn);
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
                cmd.Parameters.AddWithValue("@param_AlumneId", AlumneId);

                MyReader2 = cmd.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                MyReader2.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }finally {
             
                    conn.Close(); this.Close(); }
        
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
