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
    public partial class FormCanviInformatEmpreses : Form
    {

        List<string> EmpresesId;
        private Connexio mysqlconnect;
        public FormCanviInformatEmpreses(Connexio mysqlconnect, List<string> EmpresesId)
        {

            this.mysqlconnect = mysqlconnect;
            this.EmpresesId = EmpresesId;
            InitializeComponent();
            InitializeComboBoxInformat();
            lbInformacio.Text = "Hi ha " + EmpresesId.Count() + " registres seleccionats.";
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
                comboBoxInformat.SelectedValue = "1";
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }

        }

        private void btMarcarCanvi_Click(object sender, EventArgs e)
        {

            foreach (string EmpresaId in EmpresesId)
            {
                MySqlConnection conn = mysqlconnect.getmysqlconn();
                conn.Open();
                MySqlDataReader MyReader2;
                try
                {


                    string Query = "UPDATE ComercialEmpreses SET Informat = '" + comboBoxInformat.SelectedValue
                       + "' where EmpresaInteressadaID=" + EmpresaId + ";"; ;
                    MySqlCommand cmd = new MySqlCommand(Query, conn);

                    MyReader2 = cmd.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                    MyReader2.Close();

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
            this.Close();
        }

        private void btAnular_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
