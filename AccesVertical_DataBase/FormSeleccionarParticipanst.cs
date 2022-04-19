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
    public partial class FormSeleccionarParticipanst : Form
    {
        Boolean isupdating = false;
        string MonograficID;
        string EmpresaID;
        private Connexio mysqlconnect;
        public FormSeleccionarParticipanst(Connexio connect,string MonograficID,string TitolMonografic,string EmpresaID)
        {
            this.MonograficID = MonograficID;
            
          mysqlconnect = connect;
            InitializeComponent();
            lbTitolMonografic.Text = TitolMonografic.ToUpper();
            InitializeComboboxEmpresa();
                InsertCheckBoxColumn();
            comboBoxEmpresa.SelectedValue = EmpresaID;
         
        }
        private void InsertCheckBoxColumn() {
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "";
            checkBoxColumn.Width = 30;
            checkBoxColumn.Name = "?";
            dataGridView1.Columns.Insert(1, checkBoxColumn);
        }

        private void SelectedItems()
        {
         

            try
            {
                MySqlConnection conn = mysqlconnect.getmysqlconn();
                DataTable DtDades = new DataTable();
                string query = "Select * from ParticipantsMonografic";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Close();
                MySqlDataAdapter mdaDades = new MySqlDataAdapter(cmd);
                mdaDades.Fill(DtDades);
                for (int i = 0; i < dataGridView1.Rows.Count; i++) {
                   string ParticipantID = dataGridView1.Rows[i].Cells["ParticipantID"].Value.ToString();
                   int n= DtDades.Select("Participant="+ParticipantID+" AND Monografic =" +MonograficID ).Length;
                   
                    if (n > 0) dataGridView1.Rows[i].Cells["?"].Value = true;
                    else dataGridView1.Rows[i].Cells["?"].Value = false;
                 
                }
                
                }

            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }



        }


    private void InizilizeDataGriView()
        {

                try
            {
                MySqlConnection conn = mysqlconnect.getmysqlconn();
  DataTable DtDadesAlumnes = new DataTable();



                string query = "Select Participants.`ParticipantID`,Participants.`Nom`,Participants.`Cognoms`,"
                + "Participants.`DNI`,"
           + " Empreses.`Nom de la empresa`, Empreses.`CIF`,Empreses.`Persona de contacte`,Empreses.`Telèfon`, Empreses.`Correu electrònic` "
            + " FROM Participants "
            + " LEFT JOIN empreses ON Participants.`EmpresaID`= empreses.`EmpresaID` "
             + " WHERE ("
         + "LENGTH(?NOM) <1 or Participants.`Nom` like ?NOMSEARCH)" + "AND ("
             + "LENGTH(?COGNOMS) <1 or Participants.`Cognoms` like ?COGNOMSSEARCH)" + "AND ("
             + " LENGTH(?DNI) <1 or Participants.`DNI` like ?DNISEARCH)"
             + "AND ( Empreses.EmpresaID =?EMPRESAID);";


                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("?NOM", txtBNomParticip.Text);
                cmd.Parameters.AddWithValue("?NOMSEARCH", "%" + txtBNomParticip.Text + "%");
                cmd.Parameters.AddWithValue("?COGNOMS", txtBCognomsParticipants.Text);
                cmd.Parameters.AddWithValue("?COGNOMSSEARCH", "%" + txtBCognomsParticipants.Text + "%");
                cmd.Parameters.AddWithValue("?DNI", txtBDNIParticipants.Text);
                cmd.Parameters.AddWithValue("?DNISEARCH", "%" + txtBDNIParticipants.Text + "%");
                cmd.Parameters.AddWithValue("?EMPRESAID", EmpresaID);



                MySqlDataAdapter mdaDades =
                new MySqlDataAdapter(cmd);
                //+ dTPinici.Value.Date.ToString("yyyy-MM-dd HH:mm") +

                mdaDades.Fill(DtDadesAlumnes);
             
                dataGridView1.DataSource = DtDadesAlumnes;
                dataGridView1.Columns["ParticipantID"].Visible = false;

                dataGridView1.RowHeadersVisible = false;
                dataGridView1.AllowUserToAddRows = false;
                conn.Close();
                isupdating = true;
                SelectedItems();
                isupdating = false;
            }

            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }

        




    }

        private void InitializeComboboxEmpresa()
        {

            try
            {
                MySqlConnection conn = mysqlconnect.getmysqlconn();

                string query = "SELECT EmpresaID,  `Nom de la empresa` from Empreses";
                conn.Open();
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
        private void btTancar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBoxEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmpresaID = comboBoxEmpresa.SelectedValue.ToString();
            InizilizeDataGriView();
        }

        private void txtBNomParticip_TextChanged(object sender, EventArgs e)
        {
            InizilizeDataGriView();
        }

        private void txtBCognomsParticipants_TextChanged(object sender, EventArgs e)
        {
            InizilizeDataGriView();
        }

        private void txtBDNIParticipants_TextChanged(object sender, EventArgs e)
        {
            InizilizeDataGriView();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0&&!isupdating)
            {
                Point cur = new Point(e.ColumnIndex, e.RowIndex);

    
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                if ((bool)(row.Cells["?"].Value) == true)
                {
                    MySqlConnection conn = mysqlconnect.getmysqlconn();
                    string ParticipantId = row.Cells["ParticipantID"].Value.ToString();
                    try
                    {


                        string Query = "INSERT INTO ParticipantsMonografic(Participant, Monografic) VALUES(" + ParticipantId + "," + MonograficID + "); ";
                        MySqlCommand cmd = new MySqlCommand(Query, conn);

                        conn.Open();
                        cmd.ExecuteReader();     
                        conn.Close();
                    }
                    catch (Exception err)
                    {

                        MessageBox.Show(err.Message);


                    }
                }
                else
                {
                    MySqlConnection conn = mysqlconnect.getmysqlconn();
                    string ParticipantId = row.Cells["ParticipantID"].Value.ToString();
                    try
                    {


                        string Query = "delete from ParticipantsMonografic where (Participant, Monografic) in ((" + ParticipantId + "," + MonograficID + "));";
                        MySqlCommand cmd = new MySqlCommand(Query, conn);

                        conn.Open();
                        cmd.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                        conn.Close();
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);


                    }
                }
            }

        
        }

        private void dataGridView1_BindingContextChanged(object sender, EventArgs e)
        {
            isupdating = true;
            SelectedItems();
            isupdating = false;
        }
    }
}
