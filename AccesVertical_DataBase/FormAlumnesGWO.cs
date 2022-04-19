﻿using MySql.Data.MySqlClient;
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
    public partial class FormAlumnesGWO : Form
    {
        private Connexio mysqlconnect;
        private string CursGWOID;
        private string AlumneId = "";
        public FormAlumnesGWO(Connexio connect, string CursGWOID)
        {

            mysqlconnect = connect;
            this.CursGWOID = CursGWOID;
            InitializeComponent();
            dTPinici.Value = new DateTime(2000, 1, 1, 0, 0, 0);
            InitializeDataGridView();
            InitialitzeDataGridViewAlumnesCursGWO();
            InitializeComboboxEstat();
        }


        public void InitializeDataGridView()
        {



            try
            {
                MySqlConnection conn = mysqlconnect.getmysqlconn();




                DataTable DtDadesAlumnes = new DataTable();

                MySqlDataAdapter mdaDades =
                new MySqlDataAdapter("Select `Alumnes`.`AlumneID`,`Alumnes`.`GWO`,`Alumnes`.`Nom`,`Alumnes`.`Cognoms`,"
             + "`Alumnes`.`DNI`,`Alumnes`.`Data d'alta`," + " Empreses.`Nom de la empresa`"
            + "from Alumnes "
            + " LEFT JOIN empreses ON alumnes.`EmpresaID`= empreses.`EmpresaID` "

            + " WHERE ("
            + "LENGTH('" + NOMBOX.Text + "') <1 or `Alumnes`.`Nom` like '%" + NOMBOX.Text + "%')" + "AND ("
             + "LENGTH('" + COGNOMSBOX.Text + "') <1 or `Alumnes`.`Cognoms` like '%" + COGNOMSBOX.Text + "%')" + "AND ("
               + "LENGTH('" + DNIBOX.Text + "') <1 or `Alumnes`.`DNI` like '%" + DNIBOX.Text + "%')" + "AND ("
              + "LENGTH('" + dTPinici.Value.Date.ToString("yyyy-MM-dd HH:mm") + "') <1 or `Alumnes`.`Data d'alta` > '" + dTPinici.Value.Date.ToString("yyyy-MM-dd HH:mm") + "')"
             + "  AND Alumnes.GWO = true ORDER BY `Alumnes`.`Data d'alta` DESC;", conn);
                //+ dTPinici.Value.Date.ToString("yyyy-MM-dd HH:mm") +

                mdaDades.Fill(DtDadesAlumnes);

                dataGridViewTotsElsAlumnes.DataSource = DtDadesAlumnes;
                dataGridViewTotsElsAlumnes.Columns["AlumneID"].Visible = false;
                dataGridViewTotsElsAlumnes.Columns["GWO"].Visible = false;
                dataGridViewTotsElsAlumnes.RowHeadersVisible = false;
                dataGridViewTotsElsAlumnes.AllowUserToAddRows = false;
                conn.Close();


                //FormatDataGridViewAlumnes();



            }

            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }

        }
        public void InitialitzeDataGridViewAlumnesCursGWO()
        {

            try
            {
                MySqlConnection conn = mysqlconnect.getmysqlconn();
                DataTable DtDadesAlumnesCursGWO = new DataTable();

                MySqlDataAdapter mdaDades =
                new MySqlDataAdapter("Select  Alumnes.AlumneID, Alumnes.Nom, Alumnes.Cognoms,  EstatdelCurs.EstatID, EstatdelCurs.Estat, Alumnes.DNI from alumnes INNER JOIN alumnesmembresdelCursGWO"
                                + "   ON Alumnes.`AlumneID` = alumnesmembresdelCursGWO.`Alumne` "
                                + "INNER JOIN EstatdelCurs "
                                   + "ON EstatdelCurs.EstatID = alumnesmembresdelCursGWO.Estat "
                                    + "WHERE alumnesmembresdelCursGWO.`CursGWO`=" + CursGWOID + " ; ", conn);


                mdaDades.Fill(DtDadesAlumnesCursGWO);

                dataGridViewAlumnesSeleccionat.DataSource = DtDadesAlumnesCursGWO;

                dataGridViewAlumnesSeleccionat.Columns["AlumneID"].Visible = false;
                dataGridViewAlumnesSeleccionat.Columns["EstatID"].Visible = false;
                dataGridViewAlumnesSeleccionat.RowHeadersVisible = false;
                dataGridViewAlumnesSeleccionat.AllowUserToAddRows = false;
                conn.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }


        }
        private void InitializeComboboxEstat()
        {

            MySqlConnection conn = mysqlconnect.getmysqlconn();

            string query = "SELECT EstatID, Estat from EstatdelCurs";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter mdaDades = new MySqlDataAdapter(cmd);
            DataTable DtDadesEstats = new DataTable();


            // Con la información del adaptador se rellena el DataTable
            mdaDades.Fill(DtDadesEstats);
            comboBoxEstat.ValueMember = "EstatID";
            comboBoxEstat.DisplayMember = "Estat";
            comboBoxEstat.DataSource = DtDadesEstats;
            conn.Close();
            Int32 selectedRowCount = dataGridViewAlumnesSeleccionat.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (selectedRowCount > 0)
            {
                string Estat = dataGridViewAlumnesSeleccionat.SelectedRows[0].Cells[3].Value.ToString();

                comboBoxEstat.SelectedValue = Estat;
            }


        }
        private void btFinalitzar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NOMBOX_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridView();
        }

        private void COGNOMSBOX_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridView();
        }

        private void DNIBOX_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridView();
        }

        private void dTPinici_ValueChanged(object sender, EventArgs e)
        {
            InitializeDataGridView();
        }

        private void Control_Enter(object sender, EventArgs e)
        {

        }

        private void btAfegir_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount =
      dataGridViewTotsElsAlumnes.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (selectedRowCount > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                for (int i = 0; i < selectedRowCount; i++)
                {
                    MySqlConnection conn = mysqlconnect.getmysqlconn();
                    string AlumneId = dataGridViewTotsElsAlumnes.SelectedRows[i].Cells[0].Value.ToString();
                    // Se crea un DataTable que almacenará los datos desde donde se cargaran los datos al DataGridView
                    DataTable DtDadesAlumnes = new DataTable();
                    // Se crea un MySqlAdapter para obtener los datos de la base

                    try
                    {


                        string Query = "INSERT INTO AlumnesMembresDelCursGWO(Alumne, CursGWO,Estat) VALUES(\"" + AlumneId + "\",\"" + CursGWOID + "\", \"1\"); ";
                        MySqlCommand cmd = new MySqlCommand(Query, conn);
                        MySqlDataReader MyReader2;
                        conn.Open();
                        MyReader2 = cmd.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                        conn.Close();
                    }
                    catch (MySqlException ex)
                    {

                        if (ex.Number != 1062)
                            MessageBox.Show(ex.Message);
                    }
                    InitialitzeDataGridViewAlumnesCursGWO();


                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount =
  dataGridViewAlumnesSeleccionat.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (selectedRowCount > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                for (int i = 0; i < selectedRowCount; i++)
                {

                    try
                    {
                        MySqlConnection conn = mysqlconnect.getmysqlconn();
                        string AlumneId = dataGridViewAlumnesSeleccionat.SelectedRows[0].Cells[0].Value.ToString();
                        // Se crea un DataTable que almacenará los datos desde donde se cargaran los datos al DataGridView
                        DataTable DtDadesAlumnes = new DataTable();
                        // Se crea un MySqlAdapter para obtener los datos de la base



                        string Query = "delete from AlumnesmembresdelCursGWO where (Alumne, CursGWO) in ((" + AlumneId + "," + CursGWOID + "))";
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
                    InitialitzeDataGridViewAlumnesCursGWO();


                }


            }
        }

        private void btCanviar_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 selectedRowCount =
          dataGridViewAlumnesSeleccionat.Rows.GetRowCount(DataGridViewElementStates.Selected);

                if (selectedRowCount > 0)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();

                    for (int i = 0; i < selectedRowCount; i++)
                    {
                        MySqlConnection conn = mysqlconnect.getmysqlconn();
                        string AlumneId = dataGridViewAlumnesSeleccionat.SelectedRows[i].Cells[0].Value.ToString();
                        // Se crea un DataTable que almacenará los datos desde donde se cargaran los datos al DataGridView
                        DataTable DtDadesAlumnes = new DataTable();
                        // Se crea un MySqlAdapter para obtener los datos de la base

                        string Estat = comboBoxEstat.SelectedValue.ToString();
                        // MessageBox.Show(comboBoxEstat.SelectedValue.ToString());
                        string Query = " UPDATE alumnesmembresdelCursGWO SET Estat = " + Estat
                            + " where(Alumne, CursGWO) in ((" + AlumneId + "," + CursGWOID + "));";
                        MySqlCommand cmd = new MySqlCommand(Query, conn);
                        MySqlDataReader MyReader2;
                        conn.Open();
                        MyReader2 = cmd.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                        conn.Close();

                    }
                }

                InitialitzeDataGridViewAlumnesCursGWO();
                InitializeComboboxEstat();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewAlumnesSeleccionat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewAlumnesSeleccionat_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewAlumnesSeleccionat.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0)
            {
                string Estat = dataGridViewAlumnesSeleccionat.SelectedRows[0].Cells[4].Value.ToString();
                InitializeComboboxEstat();
                AlumneId = dataGridViewAlumnesSeleccionat.SelectedRows[0].Cells[0].Value.ToString();

            }
        }

        private void Control_Enter_1(object sender, EventArgs e)
        {

        }
    }
}
