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
    public partial class FormEditordeModelsMonografics : Form
    {

        private Connexio mysqlconnect;
        int MonograficTipusID;
        Boolean Esborrar = true;
        public FormEditordeModelsMonografics(Connexio connect)
        {
            mysqlconnect = connect;
            InitializeComponent();
            groupBox1.Hide();
            InitializeComboboxMonograficTipus();
            comboBoxMonograficTipus.SelectedItem = null;
        }
        private void InitializeComboboxMonograficTipus()
        {

            try
            {
                MySqlConnection conn = mysqlconnect.getmysqlconn();

                string query = "SELECT MonograficTipusID,  Titol,PercentatgeTeoric, PercentatgePràctic from MonograficsTipus";

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
                MessageBox.Show(0+err.Message);

            }


        }


        private void btAnular_Click(object sender, EventArgs e)
        {
            Close();
        }





      

        private void btNouMonograficModel_Click(object sender, EventArgs e)
        {
            //INSERT INTO monograficstipus(Titol) VALUES ("");
            MySqlConnection conn = mysqlconnect.getmysqlconn();
            MySqlDataReader reader;
            try
            {

                string Query = "INSERT INTO monograficstipus(Titol,`PercentatgeTeoric`,`PercentatgePràctic`) VALUES (\"Nou Monogràfic Tipus Sense Nom\",20,80)";
                MySqlCommand cmd = new MySqlCommand(Query, conn);
                conn.Open();
                reader = cmd.ExecuteReader();
                reader.Close();
                conn.Close();
                InitializeComboboxMonograficTipus();
                Query = "SELECT MAX(MonograficTipusID) from MonograficsTipus;";
                cmd = new MySqlCommand(Query, conn);
                
                conn.Open();
                reader = cmd.ExecuteReader();
                reader.Read();
                MonograficTipusID = !reader.IsDBNull(0) ? reader.GetInt16(0) : 0;

                    reader.Close();
                comboBoxMonograficTipus.SelectedValue = MonograficTipusID;




               

            }
            catch (Exception ex)
            {
                MessageBox.Show(1 + ex.Message); ;

            }
            finally
            {
                conn.Close();
                
            }
        }

        public void InitializeDataGridViewContingutsMonografic()
        {



            try
            {
                MySqlConnection conn = mysqlconnect.getmysqlconn();
                DataTable DtDadesContingut = new DataTable();
                string query = "Select Contingut.ContingutID,Contingut.Titol, Contingut.Subtitols,TipusModul.Titol From contingut"
                 + " INNER JOIN contingutsmonografictipus ON (contingutsmonografictipus.Contingut = Contingut.ContingutID"
                + " AND contingutsmonografictipus.MonograficTipus = ?MonograficTipusID )"
                + " INNER JOIN tipusmodul ON tipusmodul.TipusModulID = Contingut.`Tipus de modul`; ";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("?MonograficTipusID", MonograficTipusID);

                MySqlDataAdapter mdaDades =
                new MySqlDataAdapter(cmd);


                mdaDades.Fill(DtDadesContingut);

                dataGridViewContingutMonografic.DataSource = DtDadesContingut;

                dataGridViewContingutMonografic.Columns["ContingutID"].Visible = false;
                dataGridViewContingutMonografic.RowHeadersVisible = false;
                dataGridViewContingutMonografic.AllowUserToAddRows = false;
                conn.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(2 + err.Message);

            }

        }

        public void InitializeDataGridViewTotsContingutsMonografics()
        {

  MySqlConnection conn = mysqlconnect.getmysqlconn();

            try
            {
              
                DataTable DtDadesContingut = new DataTable();
                  string query = "Select Contingut.ContingutID,Contingut.Titol, Contingut.Subtitols,TipusModul.Titol From contingut"
             + " INNER JOIN tipusmodul ON tipusmodul.TipusModulID = Contingut.`Tipus de modul`"
                + " HAVING ("
      + "LENGTH(?TITOL) <1 or Contingut.Titol like ?TITOLSEARCH) ORDER BY  Contingut.ContingutID DESC;";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("?MonograficTipusID", MonograficTipusID);
                cmd.Parameters.AddWithValue("?TITOL", txtBCercaTitol.Text);
                cmd.Parameters.AddWithValue("?TITOLSEARCH", "%" + txtBCercaTitol.Text + "%");
                
                MySqlDataAdapter mdaDades =
                new MySqlDataAdapter(cmd);


                mdaDades.Fill(DtDadesContingut);

                dataGridViewTotContingut.DataSource = DtDadesContingut;

                dataGridViewTotContingut.Columns["ContingutID"].Visible = false;
                dataGridViewTotContingut.RowHeadersVisible = false;
                dataGridViewTotContingut.AllowUserToAddRows = false;
                conn.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(3 + err.Message);

            }
            finally
            {
                conn.Close();
            }

        }
        private void btInserirMonografic_Click(object sender, EventArgs e)
        {
            
        }
        private void formNouContingut_FormClosed(object sender, FormClosedEventArgs e)
        {

            InitializeDataGridViewTotsContingutsMonografics();
            InitializeDataGridViewContingutsMonografic();


        }
        private void btNouContingut_Click(object sender, EventArgs e)
        {

            FormNouContingut formNouContingut = new FormNouContingut(mysqlconnect);

            formNouContingut.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formNouContingut_FormClosed);

            formNouContingut.Show();
        }


      


     

        private void btAfegir_Click_1(object sender, EventArgs e)
        {
            Int32 selectedRowCount =
    dataGridViewTotContingut.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (selectedRowCount > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                for (int i = 0; i < selectedRowCount; i++)
                {
                    MySqlConnection conn = mysqlconnect.getmysqlconn();
                    string ContingutId = dataGridViewTotContingut.SelectedRows[i].Cells[0].Value.ToString();
                    // Se crea un DataTable que almacenará los datos desde donde se cargaran los datos al DataGridView
                    DataTable DtDadesContingutMonografic = new DataTable();
                    // Se crea un MySqlAdapter para obtener los datos de la base

                    try
                    {


                        string Query = "INSERT INTO ContingutsMonograficTipus(Contingut, MonograficTipus) VALUES(\"" + ContingutId + "\",\"" + MonograficTipusID + "\"); ";
                        MySqlCommand cmd = new MySqlCommand(Query, conn);
                        MySqlDataReader MyReader2;
                        conn.Open();
                        MyReader2 = cmd.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                        MyReader2.Close();

                        conn.Close();

                    }
                    catch (MySqlException ex)
                    {

                        if (ex.Number != 1062)
                            MessageBox.Show(4+ex.Message);
                    }
                    finally { conn.Close(); }
                    InitializeDataGridViewContingutsMonografic();


                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = mysqlconnect.getmysqlconn();
            conn.Open();
            MySqlDataReader MyReader2;

            try
            {


                string Query = "UPDATE MonograficsTipus SET  `Titol` =@Titol"
                    + " where MonograficTipusID=@MonograficTipusID;";
                MySqlCommand cmd = new MySqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@Titol", txtBTitol.Text);
                cmd.Parameters.AddWithValue("@MonograficTipusID", MonograficTipusID);
                MyReader2 = cmd.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                MyReader2.Close();
                int temp = MonograficTipusID;
                InitializeComboboxMonograficTipus();
                MonograficTipusID = temp;
                comboBoxMonograficTipus.SelectedValue = MonograficTipusID;

            }
            catch (Exception ex)
            {
                MessageBox.Show(5 + ex.Message);

            }
            finally
            {

                conn.Close(); 
            }
        }

        private void btTreure_Click_1(object sender, EventArgs e)
        {

            Int32 selectedRowCount =
  dataGridViewContingutMonografic.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (selectedRowCount > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                for (int i = 0; i < selectedRowCount; i++)
                {

                    try
                    {
                        MySqlConnection conn = mysqlconnect.getmysqlconn();
                        string ContingutId = dataGridViewContingutMonografic.SelectedRows[0].Cells[0].Value.ToString();
                        // Se crea un DataTable que almacenará los datos desde donde se cargaran los datos al DataGridView
                        DataTable DtDadesAlumnes = new DataTable();
                        // Se crea un MySqlAdapter para obtener los datos de la base



                        string Query = "delete from ContingutsMonograficTipus where (Contingut, MonograficTipus) in ((" + ContingutId + "," + MonograficTipusID + "))";
                        MySqlCommand cmd = new MySqlCommand(Query, conn);
                        MySqlDataReader MyReader2;
                        conn.Open();
                        MyReader2 = cmd.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    InitializeDataGridViewContingutsMonografic();


                }


            }
        }

        private void btEliminarContingut_Click_1(object sender, EventArgs e)
        {

            int selectedRowCount = dataGridViewTotContingut.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                var confirmEliminar = MessageBox.Show("Segur que vols eliminar el Coningut seleccionat?",
                    "Confirmació d'Eliminació!",
                    MessageBoxButtons.YesNo);
                if (confirmEliminar == DialogResult.Yes)
                {

                    for (int i = 0; i < selectedRowCount; i++)
                    {

                        try
                        {
                            MySqlConnection conn = mysqlconnect.getmysqlconn();
                            string ContingutId = dataGridViewTotContingut.SelectedRows[0].Cells[0].Value.ToString();
                            string Query = "delete from Contingut where ContingutID=" + ContingutId + ";";
                            MySqlCommand cmd = new MySqlCommand(Query, conn);
                            MySqlDataReader MyReader2;
                            conn.Open();
                            MyReader2 = cmd.ExecuteReader();     // Here our query will be executed and data saved into the database. 
                            MyReader2.Close();
                            conn.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(6+ex.Message);
                        }
                        InitializeDataGridViewTotsContingutsMonografics();
                        InitializeDataGridViewContingutsMonografic();


                    }
                }
            }
        }

        private void btEditarContingut_Click_1(object sender, EventArgs e)
        {

            int selectedRowCount = dataGridViewTotContingut.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {

                for (int i = 0; i < selectedRowCount; i++)
                {

                    try
                    {
                        string ContingutId = dataGridViewTotContingut.SelectedRows[i].Cells[0].Value.ToString();

                        FormEditarContingut formEditarContingut = new FormEditarContingut(mysqlconnect, ContingutId);

                        formEditarContingut.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formNouContingut_FormClosed);

                        formEditarContingut.Show();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(7+ex.Message);
                    }



                }
            }
        }

        private void comboBoxMonograficTipus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMonograficTipus.SelectedItem == null)
            {
                groupBox1.Hide();


            }
            else
            {

                groupBox1.Show();
                txtBTitol.Text = comboBoxMonograficTipus.Text;
                 int.TryParse(comboBoxMonograficTipus.SelectedValue.ToString(), out MonograficTipusID);
                InitializeDataGridViewTotsContingutsMonografics();
                InitializeDataGridViewContingutsMonografic();
                 MySqlConnection conn = mysqlconnect.getmysqlconn();
                try
                {
                   

                    string query = "SELECT PercentatgeTeoric from MonograficsTipus where MonograficTipusID =?MonograficTipusID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("?MonograficTipusID",MonograficTipusID);
                    conn.Open();

                    MySqlDataReader reader = cmd.ExecuteReader();
                    
                    reader.Read();
                    int percentatge = !reader.IsDBNull(0) ? reader.GetInt16(0) : 0;
                  conn.Close();
                    trackBar1.Value = percentatge;
                    label3.Text = trackBar1.Value.ToString();
                    label4.Text = (100 - trackBar1.Value).ToString();
                    //comboBoxMonograficTipus.SelectedValue = 0;
                }
                catch (Exception err)
                {
                    MessageBox.Show(8+err.Message);

                }finally { conn.Close(); }


           }
        }

        private void btEliminarMonograficTipus_Click(object sender, EventArgs e)
        {
           
                var confirmEliminar = MessageBox.Show("Segur que vols eliminar aquest Monogràfic Tipus?",
                    "Confirmació d'Eliminació!",
                    MessageBoxButtons.YesNo);
                if (confirmEliminar == DialogResult.Yes)
                {
                MySqlConnection conn = mysqlconnect.getmysqlconn();
                try
                        {
                           
                            string Query = "delete from MonograficsTipus where MonograficTipusID=" + MonograficTipusID+ ";";
                            MySqlCommand cmd = new MySqlCommand(Query, conn);
                            MySqlDataReader MyReader2;
                            conn.Open();
                            MyReader2 = cmd.ExecuteReader();
                            MyReader2.Close();
                            conn.Close();
                            Query = "delete from ContingutsMonograficTipus where MonograficTipus=" + MonograficTipusID+ ";";
                             cmd = new MySqlCommand(Query, conn);
                                conn.Open();
                                MyReader2 = cmd.ExecuteReader();
                                MyReader2.Close();
                                conn.Close();
                    InitializeComboboxMonograficTipus();
                    comboBoxMonograficTipus.SelectedItem = null;
                    

                }
                catch (MySqlException ex)
                        {
                    if (ex.Number == 1451) { MessageBox.Show("Hi ha monogràfics utilitzant aquest Monografic Tipus. No es pot esborrar"); }
                    else 
                            MessageBox.Show(9+ex.Message);
                        }
                finally { conn.Close(); }
               

            }
        }

        private void btTancarEditor_Click(object sender, EventArgs e)
        {



            Close();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
                   }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label3.Text = trackBar1.Value.ToString();
            label4.Text = (100 - trackBar1.Value).ToString();
            MySqlConnection conn = mysqlconnect.getmysqlconn();
            
            MySqlDataReader MyReader2;

            try
            {

                conn.Open();
                string Query = "UPDATE MonograficsTipus SET  `PercentatgeTeoric` =@PercentTeoric, `PercentatgePràctic`=@PercentatgePractic"
                    + " where MonograficTipusID=@MonograficTipusID;";
                MySqlCommand cmd = new MySqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@PercentTeoric", trackBar1.Value.ToString());
                cmd.Parameters.AddWithValue("@PercentatgePractic", (100 - trackBar1.Value).ToString());
                cmd.Parameters.AddWithValue("@MonograficTipusID", MonograficTipusID);
                MyReader2 = cmd.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                MyReader2.Close();

                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(10+ex.Message);

            }
            finally
            {

                conn.Close();
            }
        }

        private void txtBCercaTitol_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewTotsContingutsMonografics();
        }
    }
}
