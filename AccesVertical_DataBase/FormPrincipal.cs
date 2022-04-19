using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace AccesVertical_DataBase
{

    public partial class FormPrincipal : Form
    {
        private Connexio mysqlconnect;
        private DataGridView dataGridView;
        private Color alumneSuspes = Color.FromArgb(251, 149, 149);
        private Color alumneNoCursat= Color.FromArgb(251, 224, 149);
        private Color verd = Color.FromArgb(162,255, 171);
        private Color taronja = Color.FromArgb(255, 224, 119);
        DateTimePickerFormat defaultDateTimePickerFormat = DateTimePickerFormat.Long;
        private string Dirpath;
        public FormPrincipal()
        {
            InitializeComponent();
        }
        public FormPrincipal(Connexio connect)
        {
            mysqlconnect = connect;
            InitializeComponent();
            dtPCGdataInici.Value = new DateTime(2000, 1, 1, 0, 0, 0);
           
            dTPinici.Value = new DateTime(2000, 1, 1, 0, 0, 0);
            dateTimePicker1AGWO.Value = new DateTime(2000, 1, 1, 0, 0, 0);
            dTPPreferenciainici.Value = new DateTime(2000, 1, 1, 0, 0, 0);
            dTPPreferenciainiciEmpresa.Value = new DateTime(2000, 1, 1, 0, 0, 0);
            dtpDataCurs1.Value = new DateTime(2000, 1, 1, 0, 0, 0);
            dtPCGdatafi.CustomFormat = " ";
            dtPCGdatafi.Format = DateTimePickerFormat.Custom;
           
            dTPfinal.CustomFormat = " ";
            dTPfinal.Format = DateTimePickerFormat.Custom;
            dateTimePicker2AGWO.CustomFormat = " ";
            dateTimePicker2AGWO.Format = DateTimePickerFormat.Custom;
            dTPPreferenciafinal.CustomFormat = " ";
            dTPPreferenciafinal.Format = DateTimePickerFormat.Custom;
            dTPPreferenciafinalEmpresa.CustomFormat = " ";
            dTPPreferenciafinalEmpresa.Format = DateTimePickerFormat.Custom;
            dtpDataCurs2.CustomFormat = " ";
            dtpDataCurs2.Format = DateTimePickerFormat.Custom;
            InitializeDataGridViewAlumnes0();
            InitializeDataGridViewParticipantsSelectorCursos();
            InitializeDataGridView();
            InitializeDataGridViewAlumnesGWO();
            InitializeDataGridViewParticipants();
            InitializeDataGridViewEmpreses(dataGridViewEmpreses, EMPRESABOX, CONTACTEBOX);
            InitializeDataGridViewEmpreses(dataGridViewEmpreses2, EMPRESABOX2, CONTACTEBOX2);
            InitializeComboboxEmpresa();
            InitializeDataGridViewTotsElsCursos();
            InitializeDataGridViewPersonesComercial();
            InitializeDataGridViewEmpresesComercial();
            InitializeDataGridViewTotsElsMonografics();
            InitializeComboboxTipusCursos();
            InitializeComboboxInformat();
            InitializeComboboxInformatEmpresa();
            InitializeDataGridViewParticipantsMonografic();
            InitializeComboboxMonogràfics();
            InitializeDataGridViewComercialGeneral();
            InitializeDataGridViewParticipantsMonograficDiplomes();
            InitializeDataGridViewFormadors();
            InitializeDataGridViewCursosGWO();
            this.WindowState = FormWindowState.Maximized;
          TABCONTROL.TabPages.Remove(tabComercialParticular);
            TABCONTROL.TabPages.Remove(tabComercialEmpreses);
            if (Directory.Exists("\\\\SERVERACCES\\Empresa\\05 FORMACIÓ\\00 - R - FP5 - REGISTRES\\CONTROL ASSISTENCIA")) {

                txtBDirAssist.Text = "\\\\SERVERACCES\\Empresa\\05 FORMACIÓ\\00 - R - FP5 - REGISTRES\\CONTROL ASSISTENCIA";

            }
        }


        public void InitializeDataGridViewComercialGeneral()
        {



            try
            {
                MySqlConnection conn = mysqlconnect.getmysqlconn();




                DataTable DtDades = new DataTable();
                string query = "Select ComercialGeneral.ComercialID,ComercialGeneral.`Tipus contacte`, ComercialGeneral.`Nom Empresa`,  ComercialGeneral.`Nom Persona`,"
                  + "  ComercialGeneral.Cognoms,tipuscursos.Nom as `Curs d'interès`, "
                        + "ComercialGeneral.`Mes`,ComercialGeneral.`Correu electrònic`, ComercialGeneral.Telèfon,ComercialGeneral.`Telèfon Mòbil`, "
                        + "ComercialGeneral.`Comentaris`, Informat.Informat,  ComercialGeneral.`Data de preferència` from ComercialGeneral "
                         + "LEFT JOIN Informat ON "
                         + "Informat.InformatID = ComercialGeneral.Informat LEFT JOIN TipusCursos ON "
                + "ComercialGeneral.`Curs d'interès`=TipusCursos.`TipusCursID` "
            + " HAVING ( "
            + "LENGTH(?NOMEMPRESA) <1 or `ComercialGeneral`.`Nom Empresa` like ?NOMEMPRESASEARCH)" + "AND ("
         + "LENGTH(?NOM) <1 or `ComercialGeneral`.`Nom Persona` like ?NOMSEARCH)" + "AND ("
             + "LENGTH(?COGNOMS) <1 or `ComercialGeneral`.`Cognoms` like ?COGNOMSSEARCH)" + "AND ("
              + "LENGTH(?TELEFON) <1 or `ComercialGeneral`.`Telèfon` like ?TELEFONSEARCH)" + "AND ("
                  + "LENGTH(?EMAIL) <1 or `ComercialGeneral`.`Correu electrònic` like ?EMAILSEARCH)"
                    + "AND (" + "LENGTH(?TIPUSCONTACTE) <1 or `ComercialGeneral`.`Tipus contacte` =?TIPUSCONTACTE)"
                     + "AND (" + "LENGTH(?INFORMAT) <1 or Informat.Informat =?INFORMAT)"
                       + "AND (" + "LENGTH(?TCURSOS) <1 or TipusCursos.Nom =?TCURSOS)"
                        + "AND (" + "LENGTH(?DATAINICI) <1 or ComercialGeneral.`Data de preferència` >= ?DATAINICI)" + "AND ("
           + "(?DATAFINALFORMAT) !=?FORMATDATA  or ComercialGeneral.`Data de preferència` <= ?DATAFINAL) ORDER BY ComercialGeneral.ComercialID DESC ";

                MySqlCommand cmd = new MySqlCommand(query, conn);
               
                cmd.Parameters.AddWithValue("?NOMEMPRESA", txtBCGNomEmpresa.Text);
                cmd.Parameters.AddWithValue("?NOMEMPRESASEARCH", "%" + txtBCGNomEmpresa.Text + "%");
                cmd.Parameters.AddWithValue("?NOM", txtBCGNom.Text);
                cmd.Parameters.AddWithValue("?NOMSEARCH", "%" + txtBCGNom.Text + "%");
                cmd.Parameters.AddWithValue("?COGNOMS", txtBCGCognoms.Text);
                cmd.Parameters.AddWithValue("?COGNOMSSEARCH", "%" + txtBCGCognoms.Text + "%");
                cmd.Parameters.AddWithValue("?TELEFON", txtBCGTelefon.Text);
                cmd.Parameters.AddWithValue("?TELEFONSEARCH", "%" + txtBCGTelefon.Text + "%");
                cmd.Parameters.AddWithValue("?EMAIL", txtBCGEmail.Text);
                cmd.Parameters.AddWithValue("?EMAILSEARCH", "%" +txtBCGEmail.Text + "%");
                cmd.Parameters.AddWithValue("?TIPUSCONTACTE", comboBCGTipusContacte.Text);
                cmd.Parameters.AddWithValue("?INFORMAT", comboBCGInformat.Text);
                cmd.Parameters.AddWithValue("?TCURSOS", comboBCGCursInteres.Text);
                cmd.Parameters.AddWithValue("?DATAINICI", dtPCGdataInici.Value.Date.ToString("yyyy-MM-dd HH:mm"));
                cmd.Parameters.AddWithValue("?FORMATDATA", defaultDateTimePickerFormat);
                cmd.Parameters.AddWithValue("?DATAFINALFORMAT", dtPCGdatafi.Format);
                cmd.Parameters.AddWithValue("?DATAFINAL", dtPCGdatafi.Value.Date.ToString("yyyy-MM-dd HH:mm"));
                MySqlDataAdapter mdaDades =
                new MySqlDataAdapter(cmd);


                mdaDades.Fill(DtDades);

                dataGridViewComercialGeneral.DataSource = DtDades;
                dataGridViewComercialGeneral.Columns["ComercialID"].Visible = false;

                dataGridViewComercialGeneral.RowHeadersVisible = false;
                dataGridViewComercialGeneral.AllowUserToAddRows = false;
                conn.Close();






            }

            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }

        }


        public void InitializeDataGridViewPersonesComercial()
        {



            try
            {
                MySqlConnection conn = mysqlconnect.getmysqlconn();




                DataTable DtDadesAlumnes = new DataTable();
                string query = "Select comercialparticulars.PersonaID, comercialparticulars.Nom, comercialparticulars.Cognoms,tipuscursos.Nom as `Curs d'interès`, "
                        + "comercialparticulars.`Mes`,comercialparticulars.`Correu electrònic`, comercialparticulars.Telèfon,comercialparticulars.`Telèfon Mòbil`, "
                        + "comercialparticulars.`Comentaris`, Informat.Informat,  comercialparticulars.`Data de preferència` from comercialparticulars "
                         + "LEFT JOIN Informat ON "
                         + "Informat.InformatID = comercialparticulars.Informat LEFT JOIN TipusCursos ON "
                + "comercialparticulars.`Curs d'interès`=TipusCursos.`TipusCursID` "
            + " HAVING ( "
         + "LENGTH(?NOM) <1 or `comercialparticulars`.`Nom` like ?NOMSEARCH)" + "AND ("
             + "LENGTH(?COGNOMS) <1 or `comercialparticulars`.`Cognoms` like ?COGNOMSSEARCH)" + "AND ("
              + "LENGTH(?TELEFON) <1 or `comercialparticulars`.`Telèfon` like ?TELEFONSEARCH)" + "AND ("
                  + "LENGTH(?EMAIL) <1 or `comercialparticulars`.`Correu electrònic` like ?EMAILSEARCH)"
                     + "AND (" + "LENGTH(?INFORMAT) <1 or Informat.Informat =?INFORMAT)"
                       + "AND (" + "LENGTH(?TCURSOS) <1 or TipusCursos.Nom =?TCURSOS)"
                        + "AND (" + "LENGTH(?DATAINICI) <1 or comercialparticulars.`Data de preferència` >= ?DATAINICI)" + "AND ("
           + "(?DATAFINALFORMAT) !=?FORMATDATA  or comercialparticulars.`Data de preferència` <= ?DATAFINAL) ORDER BY comercialparticulars.PersonaID DESC ";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("?NOM", NOM2BOX.Text);
                cmd.Parameters.AddWithValue("?NOMSEARCH", "%" + NOM2BOX.Text + "%");
                cmd.Parameters.AddWithValue("?COGNOMS", COGNOMS2BOX.Text);
                cmd.Parameters.AddWithValue("?COGNOMSSEARCH", "%" + COGNOMS2BOX.Text + "%");
                cmd.Parameters.AddWithValue("?TELEFON", TELEFON2BOX.Text);
                cmd.Parameters.AddWithValue("?TELEFONSEARCH", "%" + TELEFON2BOX.Text + "%");
                cmd.Parameters.AddWithValue("?EMAIL", CORREUBOX.Text);
                cmd.Parameters.AddWithValue("?EMAILSEARCH", "%" + CORREU2BOX.Text + "%");
                cmd.Parameters.AddWithValue("?INFORMAT", ComboBoxInformat.Text);
                cmd.Parameters.AddWithValue("?TCURSOS", comboBoxCursos.Text);
                cmd.Parameters.AddWithValue("?DATAINICI", dTPPreferenciainici.Value.Date.ToString("yyyy-MM-dd HH:mm"));
                cmd.Parameters.AddWithValue("?FORMATDATA", defaultDateTimePickerFormat);
                cmd.Parameters.AddWithValue("?DATAFINALFORMAT", dTPPreferenciafinal.Format);
                cmd.Parameters.AddWithValue("?DATAFINAL", dTPPreferenciafinal.Value.Date.ToString("yyyy-MM-dd HH:mm"));
                MySqlDataAdapter mdaDades =
                new MySqlDataAdapter(cmd);


                mdaDades.Fill(DtDadesAlumnes);

                dataGridViewPersonesComercial.DataSource = DtDadesAlumnes;
                dataGridViewPersonesComercial.Columns["PersonaID"].Visible = false;

                dataGridViewPersonesComercial.RowHeadersVisible = false;
                dataGridViewPersonesComercial.AllowUserToAddRows = false;
                conn.Close();






            }

            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }

        }

        public void InitializeDataGridViewEmpresesComercial()
        {



            try
            {
                MySqlConnection conn = mysqlconnect.getmysqlconn();




                DataTable DtDadesAlumnes = new DataTable();



                string query = "Select comercialempreses.EmpresaInteressadaID, comercialempreses.`Nom de la empresa`, tipuscursos.Nom as `Curs d'interès`, "
                    + "comercialempreses.`Mes`,Informat.Informat, comercialempreses.`Data de preferència`,comercialempreses.`Persona de contacte`, comercialempreses.comentaris, "
                    + "comercialempreses.`Telèfon`,comercialempreses.`Telèfon Mòbil`, comercialempreses.`Correu electrònic` "
                   + "from comercialempreses "
                   + "LEFT JOIN Informat ON "
                   + "Informat.InformatID = comercialempreses.Informat "
                    + "LEFT JOIN TipusCursos ON "
                    + "comercialempreses.`Curs d'interès`=TipusCursos.`TipusCursID`"
            + " HAVING ("
         + "LENGTH(?NOMEMPRESA) <1 or `comercialempreses`.`Nom de la empresa` like ?NOMEMPRESASEARCH)" + "AND ("
             + "LENGTH(?CONTACTE) <1 or `comercialempreses`.`Persona de contacte` like ?CONTACTESEARCH)" + "AND ("
              + "LENGTH(?TELEFON) <1 or `comercialempreses`.`Telèfon` like ?TELEFONSEARCH)" + "AND ("
                  + "LENGTH(?EMAIL) <1 or `comercialempreses`.`Correu electrònic` like ?EMAILSEARCH)"
                     + "AND (" + "LENGTH(?INFORMAT) <1 or Informat.Informat = ?INFORMAT)"
                     + "AND (" + "LENGTH(?DATAINICI) <1 or comercialempreses.`Data de preferència` >= ?DATAINICI)" + "AND ("
           + "(?DATAFINALFORMAT) !=?FORMATDATA  or comercialempreses.`Data de preferència` <= ?DATAFINAL) ORDER BY comercialempreses.`Nom de la empresa` DESC;";
                ;

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("?NOMEMPRESA", NOMEMPRESABOX.Text);
                cmd.Parameters.AddWithValue("?NOMEMPRESASEARCH", "%" + NOMEMPRESABOX.Text + "%");
                cmd.Parameters.AddWithValue("?CONTACTE", CONTACTE3BOX.Text);
                cmd.Parameters.AddWithValue("?CONTACTESEARCH", "%" + CONTACTE3BOX.Text + "%");
                cmd.Parameters.AddWithValue("?TELEFON", TELEFON3BOX.Text);
                cmd.Parameters.AddWithValue("?TELEFONSEARCH", "%" + TELEFON3BOX.Text + "%");
                cmd.Parameters.AddWithValue("?EMAIL", CORREU3BOX.Text);
                cmd.Parameters.AddWithValue("?EMAILSEARCH", "%" + CORREU3BOX.Text + "%");
                cmd.Parameters.AddWithValue("?INFORMAT", comboBoxInformatEmpresa.Text);
                cmd.Parameters.AddWithValue("?DATAINICI", dTPPreferenciainiciEmpresa.Value.Date.ToString("yyyy-MM-dd HH:mm"));
                cmd.Parameters.AddWithValue("?FORMATDATA", defaultDateTimePickerFormat);
                cmd.Parameters.AddWithValue("?DATAFINALFORMAT", dTPPreferenciafinalEmpresa.Format);
                cmd.Parameters.AddWithValue("?DATAFINAL", dTPPreferenciafinalEmpresa.Value.Date.ToString("yyyy-MM-dd HH:mm"));
                MySqlDataAdapter mdaDades =
                new MySqlDataAdapter(cmd);


                mdaDades.Fill(DtDadesAlumnes);

                dataGridViewComercialEmpreses.DataSource = DtDadesAlumnes;
                dataGridViewComercialEmpreses.Columns["EmpresaInteressadaID"].Visible = false;

                dataGridViewComercialEmpreses.RowHeadersVisible = false;
                dataGridViewComercialEmpreses.AllowUserToAddRows = false;
                conn.Close();






            }

            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }

        }
        public void InitializeDataGridViewAlumnes0()
        {



            try
            {
                MySqlConnection conn = mysqlconnect.getmysqlconn();




                DataTable DtDadesAlumnes = new DataTable();



                string query = "Select `Alumnes`.`AlumneID`,`Alumnes`.`Nom`,`Alumnes`.`Cognoms`,`Alumnes`.`ID WINDA`,`Alumnes`.`Comentaris`,`Alumnes`.`Data d'alta`,"
               
                + "`Alumnes`.`DNI`,`Alumnes`.`Telèfon`,Alumnes.`Telèfon Mòbil`,`Alumnes`.`Correu electrònic`, "
           + "`Alumnes`.`Adreça`, Empreses.`Nom de la empresa`, Empreses.`CIF`,Empreses.`Persona de contacte`,Empreses.`Telèfon`, Empreses.`Correu electrònic` "
            +" from Alumnes"
            + " LEFT JOIN empreses ON alumnes.`EmpresaID`= empreses.`EmpresaID` "
            + " HAVING ("
         + "LENGTH(?NOM) <1 or `Alumnes`.`Nom` like ?NOMSEARCH)" + "AND ("
             + "LENGTH(?COGNOMS) <1 or `Alumnes`.`Cognoms` like ?COGNOMSSEARCH)" + "AND ("
              + "LENGTH(?TELEFON) <1 or `Alumnes`.`Telèfon` like ?TELEFONSEARCH or `Alumnes`.`Telèfon Mòbil` like ?TELEFONSEARCH)" + "AND ("
               + "LENGTH(?DNI) <1 or `Alumnes`.`DNI` like ?DNISEARCH)" + "AND ("
                  + "LENGTH(?EMAIL) <1 or `Alumnes`.`Correu electrònic` like ?EMAILSEARCH)" 
             + "AND (" + "LENGTH(?EMPRESA) <1 or Empreses.`Nom de la empresa` =?EMPRESA)"
            + " ORDER BY `Alumnes`.`AlumneID` DESC;";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("?NOM", NOMBOX0.Text);
                cmd.Parameters.AddWithValue("?NOMSEARCH", "%" + NOMBOX0.Text + "%");
                cmd.Parameters.AddWithValue("?COGNOMS", COGNOMSBOX0.Text);
                cmd.Parameters.AddWithValue("?COGNOMSSEARCH", "%" + COGNOMSBOX0.Text + "%");
                cmd.Parameters.AddWithValue("?TELEFON", TELEFONBOX0.Text);
                cmd.Parameters.AddWithValue("?TELEFONSEARCH", "%" + TELEFONBOX0.Text + "%");
                cmd.Parameters.AddWithValue("?DNI", DNIBOX0.Text);
                cmd.Parameters.AddWithValue("?DNISEARCH", "%" + DNIBOX0.Text + "%");
                cmd.Parameters.AddWithValue("?EMAIL", CORREUBOX0.Text);
                cmd.Parameters.AddWithValue("?EMAILSEARCH", "%" + CORREUBOX0.Text + "%");
                       cmd.Parameters.AddWithValue("?EMPRESA", comboBoxEmpresa0.Text);



                MySqlDataAdapter mdaDades =
                new MySqlDataAdapter(cmd);
                //+ dTPinici.Value.Date.ToString("yyyy-MM-dd HH:mm") +

                mdaDades.Fill(DtDadesAlumnes);

                dataGridViewAlumnes0.DataSource = DtDadesAlumnes;
                dataGridViewAlumnes0.Columns["AlumneID"].Visible = false;

                dataGridViewAlumnes0.RowHeadersVisible = false;
                dataGridViewAlumnes0.AllowUserToAddRows = false;
                conn.Close();




            }

            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }

        }

        public void InitializeDataGridViewParticipantsSelectorCursos()
        {



            try
            {
                MySqlConnection conn = mysqlconnect.getmysqlconn();




                DataTable DtDadesAlumnes = new DataTable();



                string query = "Select `Alumnes`.`AlumneID`,`Alumnes`.`Nom`,`Alumnes`.`Cognoms`,"

                + "`Alumnes`.`DNI`,`Alumnes`.`Telèfon`,Alumnes.`Telèfon Mòbil`,`Alumnes`.`Correu electrònic` "
            + " from Alumnes"
            + " HAVING ("
         + "LENGTH(?NOM) <1 or `Alumnes`.`Nom` like ?NOMSEARCH)" + "AND ("
             + "LENGTH(?COGNOMS) <1 or `Alumnes`.`Cognoms` like ?COGNOMSSEARCH)" + "AND ("
              + "LENGTH(?TELEFON) <1 or `Alumnes`.`Telèfon` like ?TELEFONSEARCH or `Alumnes`.`Telèfon Mòbil` like ?TELEFONSEARCH)" + "AND ("
               + "LENGTH(?DNI) <1 or `Alumnes`.`DNI` like ?DNISEARCH)" + "AND ("
                  + "LENGTH(?EMAIL) <1 or `Alumnes`.`Correu electrònic` like ?EMAILSEARCH)"
           
            + " ORDER BY `Alumnes`.`AlumneID` DESC;";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("?NOM", NOMBOX2.Text);
                cmd.Parameters.AddWithValue("?NOMSEARCH", "%" + NOMBOX2.Text + "%");
                cmd.Parameters.AddWithValue("?COGNOMS", COGNOMSBOX2.Text);
                cmd.Parameters.AddWithValue("?COGNOMSSEARCH", "%" + COGNOMSBOX2.Text + "%");
                cmd.Parameters.AddWithValue("?TELEFON", TELEFONBOX2.Text);
                cmd.Parameters.AddWithValue("?TELEFONSEARCH", "%" + TELEFONBOX2.Text + "%");
                cmd.Parameters.AddWithValue("?DNI", DNIBOX2.Text);
                cmd.Parameters.AddWithValue("?DNISEARCH", "%" + DNIBOX2.Text + "%");
                cmd.Parameters.AddWithValue("?EMAIL", CORREUBOX2.Text);
                cmd.Parameters.AddWithValue("?EMAILSEARCH", "%" + CORREUBOX2.Text + "%");



                MySqlDataAdapter mdaDades =
                new MySqlDataAdapter(cmd);
                //+ dTPinici.Value.Date.ToString("yyyy-MM-dd HH:mm") +

                mdaDades.Fill(DtDadesAlumnes);

                dataGridViewParticipantsSelectorCursos.DataSource = DtDadesAlumnes;
                dataGridViewParticipantsSelectorCursos.Columns["AlumneID"].Visible = false;

                dataGridViewParticipantsSelectorCursos.RowHeadersVisible = false;
                dataGridViewParticipantsSelectorCursos.AllowUserToAddRows = false;
                conn.Close();




            }

            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }

        }

        public void InitializeDataGridViewCursosGeneralAlumneSeleccionat()
        {
            
            if (dataGridViewParticipantsSelectorCursos.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0)
            {
              
                string AlumneID = dataGridViewParticipantsSelectorCursos.SelectedRows[0].Cells[0].Value.ToString();



                try
                {
                  MySqlConnection conn = mysqlconnect.getmysqlconn();
                    DataTable DtDades = new DataTable();
                    String query = "Select Cursos.`CursID`,'ANETVA' as `Tipus de Curs`, Cursos.`Codi`, Cursos.`Nom`,Cursos.`Mes`,Cursos.`Data d'inici`,Cursos.`Data de venciment`, estatdelcurs.* from Cursos INNER JOIN alumnesmembresdelcurs "
                            + " ON Cursos.`CursID` = alumnesmembresdelcurs.`Curs` "
                                + " INNER JOIN estatdelcurs "
                             + " ON estatdelcurs.EstatID = alumnesmembresdelcurs.Estat " 
                             + " WHERE alumnesmembresdelcurs.`Alumne`= @IDALUMNE"
                             +" UNION "
                             + " Select CursosGWO.`CursGWOID`, 'GWO' as `Tipus de Curs`,CursosGWO.`Codi Curs GWO`, CursosGWO.`Titol`,CursosGWO.`Mes`,CursosGWO.`Data d'inici`,CursosGWO.`Data de venciment`, estatdelcurs.* from CursosGWO INNER JOIN AlumnesMembresDelCursGWO "
                                + " ON CursosGWO.`CursGWOID` = AlumnesMembresDelCursGWO.`CursGWO` "
                            +"  INNER JOIN estatdelcurs "
                                +" ON estatdelcurs.EstatID = AlumnesMembresDelCursGWO.Estat "
                                + " WHERE AlumnesMembresDelCursGWO.`Alumne`= @IDALUMNE " ;
          
                     MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("?IDALUMNE", AlumneID);
                    MySqlDataAdapter mdaDades = new MySqlDataAdapter(cmd);
                    //+ dTPinici.Value.Date.ToString("yyyy-MM-dd HH:mm") +

                    mdaDades.Fill(DtDades);

                    dataGridViewCursosGeneral.DataSource = DtDades;

                    dataGridViewCursosGeneral.Columns["CursID"].Visible = false;
                    dataGridViewCursosGeneral.Columns["EstatID"].Visible = false;
                    dataGridViewCursosGeneral.RowHeadersVisible = false;
                    dataGridViewCursosGeneral.AllowUserToAddRows = false;
                    conn.Close();
                   

                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);

                }
            }
        }

        public void InitializeDataGridView()
        {



            try
            {
                MySqlConnection conn = mysqlconnect.getmysqlconn();




                DataTable DtDadesAlumnes = new DataTable();



                string query = "Select `Alumnes`.`AlumneID`,`Alumnes`.`ANETVA`,`Alumnes`.`Nom`,`Alumnes`.`Cognoms`,`Alumnes`.`ID WINDA`,`Alumnes`.`Comentaris`,`Alumnes`.`Data d'alta`,`Cursos`.`Nom` as `Nom del Curs`,"
                    + "`Cursos`.`Data d'inici` ,`Cursos`.`Data fi`,`Cursos`.`Data de venciment`as 'Venciment vigent',estatdelcurs.Estat as 'Estat del venciment',"
                + "`Alumnes`.`DNI`,`Alumnes`.`Telèfon`,Alumnes.`Telèfon Mòbil`,`Alumnes`.`Correu electrònic`, "
           + "`Alumnes`.`Adreça`, Empreses.`Nom de la empresa`, Empreses.`CIF`,Empreses.`Persona de contacte`,Empreses.`Telèfon`, Empreses.`Correu electrònic` "
            + "from Alumnes LEFT JOIN alumnesmembresdelcurs ON Alumnes.`AlumneID` = AlumnesMembresDelCurs.`Alumne` "
            + " LEFT JOIN empreses ON alumnes.`EmpresaID`= empreses.`EmpresaID` "
            + "LEFT JOIN Cursos ON AlumnesMembresDelCurs.`Curs`= Cursos.`CursID` LEFT OUTER JOIN ( SELECT `CursID`, max(`Data de venciment`) max_date FROM cursos group by `CursID` order by `Data de venciment` DESC) "
     + "x ON Cursos.`CursID`= x.`CursID` AND AlumnesMembresDelCurs.`Curs`= x.`CursID` AND Cursos.`Data de venciment`= x.max_date"
        + " LEFT JOIN estatdelcurs ON estatdelcurs.EstatID= alumnesmembresdelcurs.Estat GROUP BY  Alumnes.`AlumneID`"
            + " HAVING ("
         + "LENGTH(?NOM) <1 or `Alumnes`.`Nom` like ?NOMSEARCH)" + "AND ("
             + "LENGTH(?COGNOMS) <1 or `Alumnes`.`Cognoms` like ?COGNOMSSEARCH)" + "AND ("
              + "LENGTH(?TELEFON) <1 or `Alumnes`.`Telèfon` like ?TELEFONSEARCH or `Alumnes`.`Telèfon Mòbil` like ?TELEFONSEARCH)" + "AND ("
               + "LENGTH(?DNI) <1 or `Alumnes`.`DNI` like ?DNISEARCH)" + "AND ("
                  + "LENGTH(?EMAIL) <1 or `Alumnes`.`Correu electrònic` like ?EMAILSEARCH)" + "AND ( ( "
              + " ( LENGTH(?DATAINICI) <1 or `Cursos`.`Data de venciment` >= ?DATAINICI )" + " AND "
           + " ( (?DATAFINALFORMAT) !=?FORMATDATA  or `Cursos`.`Data de venciment` <= ?DATAFINAL )) "
           + " OR (`Cursos`.`Data de venciment` IS NULL ))"
             + "AND (" + "LENGTH(?EMPRESA) <1 or Empreses.`Nom de la empresa` =?EMPRESA)"
                + "AND (Alumnes.ANETVA=true)"
            + " ORDER BY `Alumnes`.`AlumneID` DESC;";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("?NOM", NOMBOX.Text);
                cmd.Parameters.AddWithValue("?NOMSEARCH", "%" + NOMBOX.Text + "%");
                cmd.Parameters.AddWithValue("?COGNOMS", COGNOMSBOX.Text);
                cmd.Parameters.AddWithValue("?COGNOMSSEARCH", "%" + COGNOMSBOX.Text + "%");
                cmd.Parameters.AddWithValue("?TELEFON", TELEFONBOX.Text);
                cmd.Parameters.AddWithValue("?TELEFONSEARCH", "%" + TELEFONBOX.Text + "%");
                cmd.Parameters.AddWithValue("?DNI", DNIBOX.Text);
                cmd.Parameters.AddWithValue("?DNISEARCH", "%" + DNIBOX.Text + "%");
                cmd.Parameters.AddWithValue("?EMAIL", CORREUBOX.Text);
                cmd.Parameters.AddWithValue("?EMAILSEARCH", "%" + CORREUBOX.Text + "%");
                cmd.Parameters.AddWithValue("?DATAINICI", dTPinici.Value.Date.ToString("yyyy-MM-dd HH:mm"));
                cmd.Parameters.AddWithValue("?FORMATDATA", defaultDateTimePickerFormat);
                cmd.Parameters.AddWithValue("?DATAFINALFORMAT", dTPfinal.Format);
                cmd.Parameters.AddWithValue("?DATAFINAL", dTPfinal.Value.Date.ToString("yyyy-MM-dd HH:mm"));
                cmd.Parameters.AddWithValue("?EMPRESA", comboBoxEmpresa.Text);



                MySqlDataAdapter mdaDades =
                new MySqlDataAdapter(cmd);
                //+ dTPinici.Value.Date.ToString("yyyy-MM-dd HH:mm") +

                mdaDades.Fill(DtDadesAlumnes);

                dataGridViewAlumnes.DataSource = DtDadesAlumnes;
                dataGridViewAlumnes.Columns["AlumneID"].Visible = false;
                dataGridViewAlumnes.Columns["ANETVA"].Visible = false;
                dataGridViewAlumnes.RowHeadersVisible = false;
                dataGridViewAlumnes.AllowUserToAddRows = false;
                conn.Close();


                FormatDataGridViewAlumnes();



            }

            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }

        }
        public void InitializeDataGridViewAlumnesGWO()
        {



            try
            {
                MySqlConnection conn = mysqlconnect.getmysqlconn();


 DataTable DtDadesAlumnes = new DataTable();

                string query = "SELECT * FROM ( Select `Alumnes`.`AlumneID`,`Alumnes`.`GWO`,`Alumnes`.`Nom`,`Alumnes`.`Cognoms`,`Alumnes`.`ID WINDA`,`Alumnes`.`Comentaris`,`Alumnes`.`Data d'alta`,"
                    + "`CursosGWO`.`Titol` as `Titol del Curs GWO`,`CursosGWO`.`Data d'inici` ,`CursosGWO`.`Data fi`,`CursosGWO`.`Data de venciment`as 'Venciment vigent',estatdelcurs.Estat as 'Estat del venciment',"
                 + "`Alumnes`.`DNI`,`Alumnes`.`Telèfon`,Alumnes.`Telèfon Mòbil`,`Alumnes`.`Correu electrònic`, "
           + "`Alumnes`.`Adreça`, Empreses.`Nom de la empresa`, Empreses.`CIF`,Empreses.`Persona de contacte`,Empreses.`Telèfon` as `Telefon empresa`, Empreses.`Correu electrònic` as `Email Empresa` "
           + "from Alumnes"
            + " LEFT JOIN alumnesmembresdelcursGWO ON Alumnes.`AlumneID` = AlumnesMembresDelCursGWO.`Alumne` "
           + "LEFT JOIN CursosGWO ON AlumnesMembresDelCursGWO.`CursGWO`= CursosGWO.`CursGWOID` "
            //   + " LEFT OUTER JOIN ( SELECT `CursGWOID`, max(`Data de venciment`) max_date FROM cursosGWO group by `CursGWOID` order by `Data de venciment` DESC) "
            // + "x ON CursosGWO.`CursGWOID`= x.`CursGWOID` AND AlumnesMembresDelCursGWO.`CursGWO`= x.`CursGWOID` AND CursosGWO.`Data de venciment`= x.max_date"
            + " LEFT JOIN empreses ON alumnes.`EmpresaID`= empreses.`EmpresaID` "
            + " LEFT JOIN estatdelcurs ON estatdelcurs.EstatID= alumnesmembresdelcursGWO.Estat "
            + "UNION "
            + "Select `Alumnes`.`AlumneID`,`Alumnes`.`GWO`,`Alumnes`.`Nom`,`Alumnes`.`Cognoms`,`Alumnes`.`ID WINDA`,`Alumnes`.`Comentaris`,`Alumnes`.`Data d'alta`,"
                    + "`CursosGWO`.`Titol` as `Titol del Curs GWO`,`CursosGWO`.`Data d'inici` ,`CursosGWO`.`Data fi`,`CursosGWO`.`Data de venciment`as 'Venciment vigent',estatdelcurs.Estat as 'Estat del venciment',"
                 + "`Alumnes`.`DNI`,`Alumnes`.`Telèfon`,Alumnes.`Telèfon Mòbil`,`Alumnes`.`Correu electrònic`, "
           + "`Alumnes`.`Adreça`, Empreses.`Nom de la empresa`, Empreses.`CIF`,Empreses.`Persona de contacte`,Empreses.`Telèfon` as `Telefon empresa`, Empreses.`Correu electrònic`  as `Email Empresa` "
           + "from Alumnes"
            + " LEFT JOIN alumnesmembresdelcursGWO ON Alumnes.`AlumneID` = AlumnesMembresDelCursGWO.`Alumne` "
           + " RIGHT JOIN CursosGWO ON AlumnesMembresDelCursGWO.`CursGWO`= CursosGWO.`CursGWOID` "
            //   + " LEFT OUTER JOIN ( SELECT `CursGWOID`, max(`Data de venciment`) max_date FROM cursosGWO group by `CursGWOID` order by `Data de venciment` DESC) "
            // + "x ON CursosGWO.`CursGWOID`= x.`CursGWOID` AND AlumnesMembresDelCursGWO.`CursGWO`= x.`CursGWOID` AND CursosGWO.`Data de venciment`= x.max_date"
            + " LEFT JOIN empreses ON alumnes.`EmpresaID`= empreses.`EmpresaID` "
            + " LEFT JOIN estatdelcurs ON estatdelcurs.EstatID= alumnesmembresdelcursGWO.Estat"

            + ")Alumnes WHERE ("
                
         + "LENGTH(?NOM) <1 or `Alumnes`.`Nom` like ?NOMSEARCH)" + "AND ("
             + "LENGTH(?COGNOMS) <1 or `Alumnes`.`Cognoms` like ?COGNOMSSEARCH)" + "AND ("
              + "LENGTH(?TELEFON) <1 or `Alumnes`.`Telèfon` like ?TELEFONSEARCH or `Alumnes`.`Telèfon Mòbil` like ?TELEFONSEARCH)" + "AND ("
               + "LENGTH(?DNI) <1 or `Alumnes`.`DNI` like ?DNISEARCH)" + "AND ("
                  + "LENGTH(?EMAIL) <1 or `Alumnes`.`Correu electrònic` like ?EMAILSEARCH)" + "AND ( ( "
              + " ( LENGTH(?DATAINICI) <1 or `Venciment vigent` >= ?DATAINICI )" + " AND "
           + " ( (?DATAFINALFORMAT) !=?FORMATDATA  or `Venciment vigent` <= ?DATAFINAL )) "
           + " OR (`Venciment vigent` IS NULL ))"
             + "AND (" + "LENGTH(?EMPRESA) <1 or `Nom de la empresa` =?EMPRESA)"
             + "AND (Alumnes.GWO=true)"
           + " ORDER BY `Alumnes`.`AlumneID` DESC;";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("?NOM", AGWONOM.Text);
                cmd.Parameters.AddWithValue("?NOMSEARCH", "%" +AGWONOM.Text + "%");
                cmd.Parameters.AddWithValue("?COGNOMS",AGWOCOGNOMS.Text);
                cmd.Parameters.AddWithValue("?COGNOMSSEARCH", "%" + AGWOCOGNOMS.Text + "%");
                cmd.Parameters.AddWithValue("?TELEFON", AGWOTELEFON.Text);
                cmd.Parameters.AddWithValue("?TELEFONSEARCH", "%" + AGWOTELEFON.Text + "%");
                cmd.Parameters.AddWithValue("?DNI", AGWODNI.Text);
                cmd.Parameters.AddWithValue("?DNISEARCH", "%" + AGWODNI.Text + "%");
                cmd.Parameters.AddWithValue("?EMAIL", AGWOEMAIL.Text);
                cmd.Parameters.AddWithValue("?EMAILSEARCH", "%" +AGWOEMAIL.Text + "%");
                cmd.Parameters.AddWithValue("?DATAINICI", dateTimePicker1AGWO.Value.Date.ToString("yyyy-MM-dd HH:mm"));
               cmd.Parameters.AddWithValue("?FORMATDATA", defaultDateTimePickerFormat);
               cmd.Parameters.AddWithValue("?DATAFINALFORMAT", dateTimePicker2AGWO.Format);
               cmd.Parameters.AddWithValue("?DATAFINAL", dateTimePicker2AGWO.Value.Date.ToString("yyyy-MM-dd HH:mm"));
                cmd.Parameters.AddWithValue("?EMPRESA", AGWOEMPRESA.Text);



                MySqlDataAdapter mdaDades =
                new MySqlDataAdapter(cmd);
                //+ dTPinici.Value.Date.ToString("yyyy-MM-dd HH:mm") +

                mdaDades.Fill(DtDadesAlumnes);

                dataGridViewAlumnesGWO.DataSource = DtDadesAlumnes;
                dataGridViewAlumnesGWO.Columns["AlumneID"].Visible = false;
                dataGridViewAlumnesGWO.Columns["GWO"].Visible = false;
                dataGridViewAlumnesGWO.RowHeadersVisible = false;
                dataGridViewAlumnesGWO.AllowUserToAddRows = false;
                conn.Close();

                
               FormatDataGridViewAlumnesGWO();



            }

            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }

        }
        private void InitializeDataGridViewCursosGWO() {

            try
            {
                MySqlConnection conn = mysqlconnect.getmysqlconn();
                DataTable DtDadesCursos = new DataTable();
                string query = "Select CursosGWO.CursGWOID, CursosGWO.`Codi Curs GWO`, CursosGWO.Titol,CursosGWO.`Data d'inici`,CursosGWO.`Data fi`,"
                    + "CursosGWO.`Data de venciment`, CursosGWO.Empresa,Empreses.`Nom de la empresa`,CursosGWO.`Formador`AS `IdFormador`,CONCAT(Formadors.Nom,' ',Formadors.Cognoms) AS `Formador`,CursosGWO.Ubicació,CursosGWO.Finalitzat from CursosGWO "
                  + "INNER JOIN Formadors ON Formadors.FormadorID= CursosGWO.`Formador` "
                  + "INNER JOIN Empreses ON Empreses.EmpresaID= CursosGWO.Empresa WHERE " +
                "(LENGTH(?TITOL) < 1 or CursosGWO.`Titol` like ?TITOLSEARCH)  ORDER BY CursosGWO.CursGWOID DESC ;";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("?TITOL", textBoxTitolCursGWO.Text);
                cmd.Parameters.AddWithValue("?TITOLSEARCH", "%" + textBoxTitolCursGWO.Text + "%");
                MySqlDataAdapter mdaDades =
                new MySqlDataAdapter(cmd);


                mdaDades.Fill(DtDadesCursos);

                dataGridViewCursosGWO.DataSource = DtDadesCursos;

                dataGridViewCursosGWO.Columns["CursGWOID"].Visible = false;
                dataGridViewCursosGWO.Columns["Empresa"].Visible = false;
                dataGridViewCursosGWO.Columns["Finalitzat"].Visible = false;
                dataGridViewCursosGWO.Columns["IdFormador"].Visible = false;
                dataGridViewCursosGWO.RowHeadersVisible = false;
                dataGridViewCursosGWO.AllowUserToAddRows = false;

                conn.Close();
         

                FormatDataGridViewCursosGWO();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }






        }
        public void InitializeDataGridViewParticipants()
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
            +" ORDER BY Participants.`ParticipantID` DESC;";


                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("?NOM", txtBNomParticip.Text);
                cmd.Parameters.AddWithValue("?NOMSEARCH", "%" + txtBNomParticip.Text + "%");
                cmd.Parameters.AddWithValue("?COGNOMS", txtBCognomsParticipants.Text);
                cmd.Parameters.AddWithValue("?COGNOMSSEARCH", "%" + txtBCognomsParticipants.Text + "%");
                cmd.Parameters.AddWithValue("?DNI", txtBDNIParticipants.Text);
                cmd.Parameters.AddWithValue("?DNISEARCH", "%" + txtBDNIParticipants.Text + "%");
                



                MySqlDataAdapter mdaDades =
                new MySqlDataAdapter(cmd);
                //+ dTPinici.Value.Date.ToString("yyyy-MM-dd HH:mm") +

                mdaDades.Fill(DtDadesAlumnes);

                dataGridViewParticipants.DataSource = DtDadesAlumnes;
                dataGridViewParticipants.Columns["ParticipantID"].Visible = false;

                dataGridViewParticipants.RowHeadersVisible = false;
                dataGridViewParticipants.AllowUserToAddRows = false;
                conn.Close();
            }

            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }

        }

        private void InsertColumnsMonograficsDiplomes()
        {
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "?";
            checkBoxColumn.Width = 30;
            checkBoxColumn.Name = "?";
            
            int columnIndex = 0;
            if (dataGridViewDiplomesParticipants.Columns["?"] == null)
            {

                dataGridViewDiplomesParticipants.Columns.Insert(columnIndex, checkBoxColumn);
            }
            DataGridViewButtonColumn botoDiploma = new DataGridViewButtonColumn();
            botoDiploma.Name = "GenerarDiplomes";
            botoDiploma.Text = "Generar Diploma";
            botoDiploma.UseColumnTextForButtonValue = true;
             columnIndex =6;

            if (dataGridViewDiplomesParticipants.Columns["GenerarDiplomes"] == null&&dataGridViewDiplomesParticipants.Columns.Count>=5)
            {

                dataGridViewDiplomesParticipants.Columns.Insert(columnIndex, botoDiploma);
            }
        }
        public void InitializeDataGridViewParticipantsMonograficDiplomes()
        {
            if (comboBoxMonografics.Items.Count > 0)
            {

                string MonograficID = comboBoxMonografics.SelectedValue.ToString();
                if (MonograficID != null)
                {

                    try
                    {
                        MySqlConnection conn = mysqlconnect.getmysqlconn();
                        DataTable DtDadesCursos = new DataTable();
                        string query = "Select ParticipantID, Nom, Cognoms,DNI,Empreses.`Nom de la empresa` from Participants "
                        + " LEFT JOIN empreses ON Participants.`EmpresaID`= empreses.`EmpresaID` "
                        + "INNER JOIN ParticipantsMonografic ON ParticipantsMonografic.Participant=Participants.ParticipantID "
                        + "WHERE ParticipantsMonografic.`Monografic`=" + MonograficID + " ORDER BY ParticipantID DESC ; ";

                        MySqlCommand cmd = new MySqlCommand(query, conn);

                        MySqlDataAdapter mdaDades = new MySqlDataAdapter(cmd);


                        mdaDades.Fill(DtDadesCursos);

                        dataGridViewDiplomesParticipants.DataSource = DtDadesCursos;

                        dataGridViewDiplomesParticipants.Columns["ParticipantID"].Visible = false;
                        dataGridViewDiplomesParticipants.RowHeadersVisible = false;
                        dataGridViewDiplomesParticipants.AllowUserToAddRows = false;

                        conn.Close();
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);

                    }
                }
                InsertColumnsMonograficsDiplomes();
                try { 
                    foreach (DataGridViewRow row in dataGridViewDiplomesParticipants.Rows)
                    {
                       // 
                        row.Cells["?"].Value = true;
                           
                        }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);

                }
            }
        }
        public void InitializeDataGridViewParticipantsMonografic()
        {

            if (dataGridViewMonografics.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0)
            {

                string MonograficID = dataGridViewMonografics.SelectedRows[0].Cells[0].Value.ToString();


                try
                {
                    MySqlConnection conn = mysqlconnect.getmysqlconn();
                    DataTable DtDadesCursos = new DataTable();
                    string query = "Select ParticipantID, Nom, Cognoms,DNI,Empreses.`Nom de la empresa` from Participants "
                    + " LEFT JOIN empreses ON Participants.`EmpresaID`= empreses.`EmpresaID` "
                    + "INNER JOIN ParticipantsMonografic ON ParticipantsMonografic.Participant=Participants.ParticipantID "
                    + "WHERE ParticipantsMonografic.`Monografic`=" + MonograficID + "  ORDER BY ParticipantID DESC ; ; ";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    MySqlDataAdapter mdaDades = new MySqlDataAdapter(cmd);


                    mdaDades.Fill(DtDadesCursos);

                    dataGridViewParticipantsMonografics.DataSource = DtDadesCursos;

                    dataGridViewParticipantsMonografics.Columns["ParticipantID"].Visible = false;
                    dataGridViewParticipantsMonografics.RowHeadersVisible = false;
                    dataGridViewParticipantsMonografics.AllowUserToAddRows = false;

                    conn.Close();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);

                }
            }
        }
        public void InitializeDataGridViewTotsElsMonografics()
        {



            try
            {
                MySqlConnection conn = mysqlconnect.getmysqlconn();
                DataTable DtDadesCursos = new DataTable();
                string query = "Select Monografics.MonograficID, Monografics.Codi, Monografics.Titol,Monografics.`Data inici`,Monografics.`Data fi`,"
                    + " Monografics.Empresa,Empreses.`Nom de la empresa`,Monografics.Ubicació,Monografics.Finalitzat,Monografics.Bonificat from Monografics "
                  + "INNER JOIN Empreses ON Empreses.EmpresaID= Monografics.Empresa WHERE " +
                "(LENGTH(?TITOLMONGRAFIC) < 1 or `Monografics`.`Titol` like ?TITOLMONGRAFICSEARCH)  ORDER BY MonograficID DESC ;";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("?TITOLMONGRAFIC", txtBNomMonografic.Text);
                cmd.Parameters.AddWithValue("?TITOLMONGRAFICSEARCH", "%" + txtBNomMonografic.Text + "%");
                MySqlDataAdapter mdaDades =
                new MySqlDataAdapter(cmd);


                mdaDades.Fill(DtDadesCursos);

                dataGridViewMonografics.DataSource = DtDadesCursos;

                dataGridViewMonografics.Columns["MonograficID"].Visible = false;
                dataGridViewMonografics.Columns["Empresa"].Visible = false;
                dataGridViewMonografics.Columns["Finalitzat"].Visible = false;
                dataGridViewMonografics.Columns["Bonificat"].Visible = false;
                dataGridViewMonografics.RowHeadersVisible = false;
                dataGridViewMonografics.AllowUserToAddRows = false;

                conn.Close();

                dataGridViewMonografics.Columns["Codi"].FillWeight = 10;
                dataGridViewMonografics.Columns["Titol"].FillWeight = 20;
                dataGridViewMonografics.Columns["Data inici"].FillWeight = 15;
                dataGridViewMonografics.Columns["Data fi"].FillWeight = 15;
                dataGridViewMonografics.Columns["Nom de la empresa"].FillWeight = 20;
                dataGridViewMonografics.Columns["Ubicació"].FillWeight = 20;


                FormatDataGridViewMonografics();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }

        }

        public void InitializeDataGridViewTotsElsCursos()
        {



            try
            {
                MySqlConnection conn = mysqlconnect.getmysqlconn();
                DataTable DtDadesCursos = new DataTable();
                string query = "Select CursID,Codi,Nom,Mes,`Data d'inici`,`Data fi`,`Data de venciment` from Cursos WHERE" +
                "(LENGTH(?NOMCURS) < 1 or `Nom` like ?NOMCURSSEARCH) AND"
                + "(LENGTH(?MESCURS) < 1 or `Mes` like ?MESCURSSEARCH) AND"
                + "( `Data d'inici` >= ?DATA1)" + "AND ("
                 + "(?DATA2FORMAT) !=?FORMATDATA  or `Data d'inici` <= ?DATA2)"
                + "ORDER BY CursID DESC ;;";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("?NOMCURS", txtBNomCurs.Text);
                cmd.Parameters.AddWithValue("?NOMCURSSEARCH", "%" + txtBNomCurs.Text + "%");
                cmd.Parameters.AddWithValue("?MESCURS", txtBMesCurs.Text);
                cmd.Parameters.AddWithValue("?MESCURSSEARCH", "%" + txtBMesCurs.Text + "%");
                cmd.Parameters.AddWithValue("?DATA1",dtpDataCurs1.Value.Date.ToString("yyyy-MM-dd HH:mm"));
                cmd.Parameters.AddWithValue("?DATA2",  dtpDataCurs2.Value.Date.ToString("yyyy-MM-dd HH:mm"));
                cmd.Parameters.AddWithValue("?FORMATDATA", defaultDateTimePickerFormat);
                cmd.Parameters.AddWithValue("?DATA2FORMAT", dtpDataCurs2.Format);
                MySqlDataAdapter mdaDades =
                new MySqlDataAdapter(cmd);


                mdaDades.Fill(DtDadesCursos);

                dataGridViewTotselsCursos.DataSource = DtDadesCursos;

                dataGridViewTotselsCursos.Columns["CursID"].Visible = false;
                dataGridViewTotselsCursos.RowHeadersVisible = false;
                dataGridViewTotselsCursos.AllowUserToAddRows = false;
                dataGridViewTotselsCursos.Columns["Codi"].FillWeight = 10;
                dataGridViewTotselsCursos.Columns["Nom"].FillWeight = 20;
                dataGridViewTotselsCursos.Columns["Mes"].FillWeight = 20;
                dataGridViewTotselsCursos.Columns["Data d'inici"].FillWeight = 16;
                dataGridViewTotselsCursos.Columns["Data fi"].FillWeight =17;
                dataGridViewTotselsCursos.Columns["Data de venciment"].FillWeight = 17;
                conn.Close();
                FormatDataGridViewCursos();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }

        }

       





        public void InitializeDataGridViewAlumnesdelCurs()
        {
            if (dataGridViewTotselsCursos.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0)
            {

                string CursID = dataGridViewTotselsCursos.SelectedRows[0].Cells[0].Value.ToString();



                try
                {
                    MySqlConnection conn = mysqlconnect.getmysqlconn();
                    DataTable DtDadesAlumnesCurs = new DataTable();

                    MySqlDataAdapter mdaDades =
                    new MySqlDataAdapter("Select  Alumnes.AlumneID, Alumnes.Nom, Alumnes.Cognoms, estatdelcurs.Estat, Alumnes.`Telèfon`,Alumnes.`Telèfon Mòbil` from alumnes INNER JOIN alumnesmembresdelcurs"
                                    + "   ON Alumnes.`AlumneID` = alumnesmembresdelcurs.`Alumne` "
                                    + "INNER JOIN estatdelcurs "
                                       + "ON estatdelcurs.EstatID = alumnesmembresdelcurs.Estat "
                                        + "WHERE alumnesmembresdelcurs.`Curs`=" + CursID + "  ORDER BY AlumneID DESC ;; ", conn);


                    mdaDades.Fill(DtDadesAlumnesCurs);

                    dataGridViewAlumnesdelCurs.DataSource = DtDadesAlumnesCurs;

                    dataGridViewAlumnesdelCurs.Columns["AlumneID"].Visible = false;
                    dataGridViewAlumnesdelCurs.RowHeadersVisible = false;
                    dataGridViewAlumnesdelCurs.AllowUserToAddRows = false;
                    conn.Close();
                    
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);

                }
            }
        }
        public void InitializeDataGridViewAlumnesdelCursGWO()
        {
            if (dataGridViewCursosGWO.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0)
            {

                string CursGWOID = dataGridViewCursosGWO.SelectedRows[0].Cells[0].Value.ToString();



                try
                {
                    MySqlConnection conn = mysqlconnect.getmysqlconn();
                    DataTable DtDadesAlumnesCursGWO = new DataTable();

                    MySqlDataAdapter mdaDades =
                    new MySqlDataAdapter("Select  Alumnes.AlumneID, Alumnes.Nom, Alumnes.Cognoms, estatdelcurs.Estat, Alumnes.`Telèfon`,Alumnes.`Telèfon Mòbil` from alumnes INNER JOIN alumnesmembresdelcursGWO"
                                    + "   ON Alumnes.`AlumneID` = alumnesmembresdelcursGWO.`Alumne` "
                                    + "INNER JOIN estatdelcurs "
                                       + "ON estatdelcurs.EstatID = alumnesmembresdelcursGWO.Estat "
                                        + "WHERE alumnesmembresdelcursGWO.`CursGWO`=" + CursGWOID + "  ORDER BY AlumneID DESC ;; ", conn);


                    mdaDades.Fill(DtDadesAlumnesCursGWO);

                    dataGridViewAlumnesCursosGWO.DataSource = DtDadesAlumnesCursGWO;

                    dataGridViewAlumnesCursosGWO.Columns["AlumneID"].Visible = false;
                    dataGridViewAlumnesCursosGWO.RowHeadersVisible = false;
                    dataGridViewAlumnesCursosGWO.AllowUserToAddRows = false;
                    conn.Close();

                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);

                }
            }
        }
        public void InitializeDataGridViewEmpreses(DataGridView DGVEmpreses, TextBox NomEmpresaBox, TextBox ContacteBox)
        {



            try
            {
                MySqlConnection conn = mysqlconnect.getmysqlconn();




                DataTable DtDadesEmpreses = new DataTable();


                string query = "Select  * from Empreses Where"
                 + "(LENGTH(?EMPRESA) <1 or `Empreses`.`Nom de la empresa` like ?EMPRESASEARCH)" + "AND (" +
                "LENGTH(?CONTACTE) <1 or `Empreses`.`Persona de contacte` like ?CONTACTESEARCH)"
                + " ORDER BY `Nom de la empresa` ASC ";


                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("?EMPRESA", NomEmpresaBox.Text);
                cmd.Parameters.AddWithValue("?EMPRESASEARCH", "%" + NomEmpresaBox.Text + "%");
                cmd.Parameters.AddWithValue("?CONTACTE", ContacteBox.Text);
                cmd.Parameters.AddWithValue("?CONTACTESEARCH", "%" + ContacteBox.Text + "%");

                MySqlDataAdapter mdaDades =
                new MySqlDataAdapter(cmd);
                //+ dTPinici.Value.Date.ToString("yyyy-MM-dd HH:mm") +

                mdaDades.Fill(DtDadesEmpreses);

                DGVEmpreses.DataSource = DtDadesEmpreses;
                DGVEmpreses.Columns["EmpresaID"].Visible = false;
                DGVEmpreses.Columns["Codi"].Visible = false;
                DGVEmpreses.RowHeadersVisible = false;
                DGVEmpreses.AllowUserToAddRows = false;
                conn.Close();




            }

            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }

        }
        private void InitializeDataGridViewAlumnesdeldelaEmpresa(string EmpresaID)
        {

            try
            {

                MySqlConnection conn = mysqlconnect.getmysqlconn();
                DataTable DtDadesAlumnesCurs = new DataTable();

                MySqlDataAdapter mdaDades =
                new MySqlDataAdapter("Select `Alumnes`.AlumneID,`Alumnes`.Nom,`Alumnes`.Cognoms,`Alumnes`.DNI, Cursos.`Data de venciment` "
                + ",estatdelcurs.Estat from alumnes LEFT JOIN alumnesmembresdelcurs ON Alumnes.`AlumneID` = AlumnesMembresDelCurs.`Alumne` "
                + "  LEFT JOIN empreses ON  alumnes.`EmpresaID`= empreses.`EmpresaID` LEFT join Cursos  ON AlumnesMembresDelCurs.`Curs`= Cursos.`CursID` "
                + "  LEFT JOIN(SELECT `CursID`, max(`Data de venciment`)  max_date FROM cursos  group by `CursID` order by `Data de venciment` DESC) "
                + " x ON Cursos.`CursID`= x.`CursID` AND AlumnesMembresDelCurs.`Curs`= x.`CursID`" + " AND Cursos.`Data de venciment`= x.max_date "
                + "LEFT JOIN estatdelcurs ON estatdelcurs.EstatID = alumnesmembresdelcurs.Estat"
                + " WHERE Empreses.`EmpresaID`=" + EmpresaID + " GROUP BY  Alumnes.`AlumneID` ORDER BY AlumneID DESC ; ", conn);


                mdaDades.Fill(DtDadesAlumnesCurs);

                dataGridViewAlumnesEmpresa.DataSource = DtDadesAlumnesCurs;

                dataGridViewAlumnesEmpresa.Columns["AlumneID"].Visible = false;
                dataGridViewAlumnesEmpresa.RowHeadersVisible = false;
                dataGridViewAlumnesEmpresa.AllowUserToAddRows = false;
                conn.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }
        }
        private void InitializeDataGridViewParticipantsdeldelaEmpresa(string EmpresaID)
        {

            try
            {

                MySqlConnection conn = mysqlconnect.getmysqlconn();
                DataTable DtDadesParticipantsEmpresa = new DataTable();

                MySqlDataAdapter mdaDades =
                new MySqlDataAdapter("Select Participants.ParticipantID,Participants.Nom,Participants.Cognoms,Participants.DNI"
                + " from Participants"
                + "  LEFT JOIN empreses ON  Participants.`EmpresaID`= Empreses.`EmpresaID`"
                + " WHERE Empreses.`EmpresaID`=" + EmpresaID+ " ORDER BY ParticipantID DESC ;", conn);


                mdaDades.Fill(DtDadesParticipantsEmpresa);

                btParticipantsEmpresa.DataSource = DtDadesParticipantsEmpresa;

                btParticipantsEmpresa.Columns["ParticipantID"].Visible = false;
                btParticipantsEmpresa.RowHeadersVisible = false;
                btParticipantsEmpresa.AllowUserToAddRows = false;
                conn.Close();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }
        }

        private void InitializeDataGridViewFormadors() {


            try
            {
                MySqlConnection conn = mysqlconnect.getmysqlconn();




                DataTable DtDadesFormadors = new DataTable();



                string query = "Select FormadorID,Nom,       Cognoms, Comentaris,DNI,  Adreça, Telèfon,`Telèfon Mòbil` "
                    + "from Formadors"
                  + " HAVING ("
         + "LENGTH(?NOM) <1 or `Formadors`.`Nom` like ?NOMSEARCH)" + "AND ("
             + "LENGTH(?COGNOMS) <1 or `Formadors`.`Cognoms` like ?COGNOMSSEARCH)" + "AND ("
              + "LENGTH(?TELEFON) <1 or `Formadors`.`Telèfon` like ?TELEFONSEARCH or `Formadors`.`Telèfon Mòbil` like ?TELEFONSEARCH)"
             + " ORDER BY `Formadors`.`FormadorID` DESC;";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("?NOM", FormadorNom.Text);
                cmd.Parameters.AddWithValue("?NOMSEARCH", "%" + FormadorNom.Text + "%");
                cmd.Parameters.AddWithValue("?COGNOMS", FormadorCognom.Text);
                cmd.Parameters.AddWithValue("?COGNOMSSEARCH", "%" + FormadorCognom.Text + "%");
                cmd.Parameters.AddWithValue("?TELEFON",FormadorTelefon.Text);
                cmd.Parameters.AddWithValue("?TELEFONSEARCH", "%" + FormadorTelefon.Text + "%");
                             // cmd.Parameters.AddWithValue("?DATAINICI", dTPinici.Value.Date.ToString("yyyy-MM-dd HH:mm"));
                //  cmd.Parameters.AddWithValue("?FORMATDATA", defaultDateTimePickerFormat);
                // cmd.Parameters.AddWithValue("?DATAFINALFORMAT", dTPfinal.Format);
                //   cmd.Parameters.AddWithValue("?DATAFINAL", dTPfinal.Value.Date.ToString("yyyy-MM-dd HH:mm"));
                



                MySqlDataAdapter mdaDades =
                new MySqlDataAdapter(cmd);
                //+ dTPinici.Value.Date.ToString("yyyy-MM-dd HH:mm") +

                mdaDades.Fill(DtDadesFormadors);

                dataGridViewFormadors.DataSource = DtDadesFormadors;
                dataGridViewFormadors.Columns["FormadorID"].Visible = false;

                dataGridViewFormadors.RowHeadersVisible = false;
                dataGridViewFormadors.AllowUserToAddRows = false;
                conn.Close();


              

            }

            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }




        }
        private void InitializeComboboxTipusCursos()
        {

            try
            {
                MySqlConnection conn = mysqlconnect.getmysqlconn();

                string query = "SELECT TipusCursID,  Nom from TipusCursos  ORDER BY Nom ASC";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter mdaDades = new MySqlDataAdapter(cmd);
                DataTable DtDadesInformat = new DataTable();

                mdaDades.Fill(DtDadesInformat);
                comboBoxCursos.ValueMember = "Nom";
                comboBoxCursos.DisplayMember = "Nom";
                comboBoxCursos.DataSource = DtDadesInformat;
                comboBCGCursInteres.ValueMember = "Nom";
                comboBCGCursInteres.DisplayMember = "Nom";
                comboBCGCursInteres.DataSource = DtDadesInformat;

                conn.Close();
                //comboBoxEmpresa.SelectedValue = "";
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }


        }
        
        private void InitializeComboboxInformat()
        {

            try
            {
                MySqlConnection conn = mysqlconnect.getmysqlconn();

                string query = "SELECT InformatID,  Informat from Informat";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter mdaDades = new MySqlDataAdapter(cmd);
                DataTable DtDadesInformat = new DataTable();

                mdaDades.Fill(DtDadesInformat);
                ComboBoxInformat.ValueMember = "Informat";
                ComboBoxInformat.DisplayMember = "Informat";
                ComboBoxInformat.DataSource = DtDadesInformat;
                comboBCGInformat.ValueMember = "Informat";
                comboBCGInformat.DisplayMember = "Informat";
                comboBCGInformat.DataSource = DtDadesInformat;

                conn.Close();
                //comboBoxEmpresa.SelectedValue = "";
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }


        }
        private void InitializeComboboxInformatEmpresa()
        {

            try
            {
                MySqlConnection conn = mysqlconnect.getmysqlconn();

                string query = "SELECT InformatID,  Informat from Informat";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter mdaDades = new MySqlDataAdapter(cmd);
                DataTable DtDadesInformat = new DataTable();

                mdaDades.Fill(DtDadesInformat);
                comboBoxInformatEmpresa.ValueMember = "Informat";
                comboBoxInformatEmpresa.DisplayMember = "Informat";
                comboBoxInformatEmpresa.DataSource = DtDadesInformat;

                conn.Close();
                //comboBoxEmpresa.SelectedValue = "";
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

                string query = "SELECT EmpresaID,  `Nom de la empresa` from Empreses ORDER BY `Nom de la empresa` ASC";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter mdaDades = new MySqlDataAdapter(cmd);
                DataTable DtDadesEmpresa = new DataTable();

                mdaDades.Fill(DtDadesEmpresa);
                comboBoxEmpresa.ValueMember = "Nom de la empresa";
                comboBoxEmpresa.DisplayMember = "Nom de la empresa";
                comboBoxEmpresa.DataSource = DtDadesEmpresa;
                comboBoxEmpresa0.ValueMember = "Nom de la empresa";
                comboBoxEmpresa0.DisplayMember = "Nom de la empresa";
                comboBoxEmpresa0.DataSource = DtDadesEmpresa;
                AGWOEMPRESA.ValueMember = "Nom de la empresa";
                AGWOEMPRESA.DisplayMember = "Nom de la empresa";
                AGWOEMPRESA.DataSource = DtDadesEmpresa;
                conn.Close();
                //comboBoxEmpresa.SelectedValue = "";
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }


        }
        private void InitializeComboboxMonogràfics()
        {

            try
            {
                MySqlConnection conn = mysqlconnect.getmysqlconn();

                string query = "SELECT MonograficID,  Titol from Monografics";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter mdaDades = new MySqlDataAdapter(cmd);
                DataTable DtDadesMonografic = new DataTable();

                mdaDades.Fill(DtDadesMonografic);
                comboBoxMonografics.ValueMember = "MonograficID";
                comboBoxMonografics.DisplayMember = "Titol";
                comboBoxMonografics.DataSource = DtDadesMonografic;

                conn.Close();
                //comboBoxEmpresa.SelectedValue = "";
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }


        }

        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {

            Application.Exit();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
          

        }
        private void button5_Click(object sender, EventArgs e)
        {
            AltaAlumne formAlta = new AltaAlumne(mysqlconnect,true,false);

            formAlta.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formAlumnes_FormClosed);

            formAlta.Show();
        }

        private void DesselectRow0(DataGridView DtgView)
        {

            if (DtgView.Rows.Count > 0)
                DtgView.Rows[0].Selected = false;


        }
        private int[] PreselectedIndex(DataGridView DtgView)
        {
            
              int  saveRow =DtgView.FirstDisplayedScrollingRowIndex;

            int selectedRowCount = DtgView.Rows.GetRowCount(DataGridViewElementStates.Selected);
            int[] infoRowsSelScroll = new int[selectedRowCount+1];
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {

                  
                    infoRowsSelScroll[i] = DtgView.SelectedRows[i].Index;

                }
            }
            infoRowsSelScroll[selectedRowCount] = saveRow;
            return infoRowsSelScroll;

        }
        private static void PostselectedIndexOnlyOneRow(DataGridView DtgView, int[] infoRowsSelScroll)
        {
            try
            {
                if (infoRowsSelScroll.Length > 1)
                {
                    {
                        if (DtgView.Rows.Count > 1)
                            DtgView.Rows[infoRowsSelScroll[0]].Selected = true;
                    }
                }
                int saveRow = infoRowsSelScroll[infoRowsSelScroll.Length - 1];
                if (saveRow >= 0 && saveRow < DtgView.Rows.Count)
                    DtgView.FirstDisplayedScrollingRowIndex = saveRow;
            }
            catch (Exception err) { MessageBox.Show(err.Message); }
        }

      private void PostselectedIndex(DataGridView DtgView, int[] infoRowsSelScroll)
        {
            Boolean row0 = false;
            for (int i = 0; i < infoRowsSelScroll.Length-1; i++)
            {
                
                if (i < DtgView.Rows.GetRowCount(DataGridViewElementStates.Displayed))
                {
                    

                    if (infoRowsSelScroll[i] == 0) row0 = true;
                    DtgView.Rows[infoRowsSelScroll[i]].Selected = true;

                }
            }
            if (infoRowsSelScroll.Length > 1)
                DtgView.Rows[0].Selected = row0;
            int saveRow = infoRowsSelScroll[infoRowsSelScroll.Length - 1];
            if (saveRow >= 0 && saveRow < DtgView.Rows.Count)
                DtgView.FirstDisplayedScrollingRowIndex = saveRow;
        }


        private void formAlumnes_FormClosed(object sender, FormClosedEventArgs e)
        {
            int[] SelectedIndexs0 = PreselectedIndex(dataGridViewAlumnes0);
            int[] SelectedIndexs = PreselectedIndex(dataGridViewAlumnes);
            int[] SelectedIndexs2 = PreselectedIndex(dataGridViewTotselsCursos);
            int[] SelectedIndexs3 = PreselectedIndex(dataGridViewCursosGWO);
            int[] SelectedIndexs4 = PreselectedIndex(dataGridViewParticipantsSelectorCursos);
            InitializeDataGridViewAlumnes0();
            InitializeDataGridView();
            InitializeDataGridViewParticipantsSelectorCursos();
            InitializeDataGridViewAlumnesGWO();
            InitializeDataGridViewTotsElsCursos();
            InitializeDataGridViewCursosGWO();
            PostselectedIndex(dataGridViewAlumnes0, SelectedIndexs0);
            PostselectedIndex(dataGridViewAlumnes, SelectedIndexs);
            PostselectedIndex(dataGridViewTotselsCursos, SelectedIndexs2);
            PostselectedIndex(dataGridViewCursosGWO, SelectedIndexs3);
            PostselectedIndexOnlyOneRow(dataGridViewParticipantsSelectorCursos, SelectedIndexs4);
        }

        private void formAltaParticipant_FormClosed(object sender, FormClosedEventArgs e)
        {
            int[] SelectedIndexs = PreselectedIndex(dataGridViewParticipants);
            InitializeDataGridViewParticipants();
            InitializeDataGridViewTotsElsMonografics();
            InitializeComboboxMonogràfics();
            PostselectedIndex(dataGridViewParticipants, SelectedIndexs);


        }

        







        //formSeleccionarParticipant_FormClosed
        private void formSeleccionarParticipant_FormClosed(object sender, FormClosedEventArgs e)
        {
            int[] SelectedIndexs = PreselectedIndex(dataGridViewParticipantsMonografics);
            InitializeDataGridViewParticipantsMonografic();
            InitializeComboboxMonogràfics();
            PostselectedIndex(dataGridViewParticipantsMonografics, SelectedIndexs);


        }


        private void formModificarParticipant_FormClosed(object sender, FormClosedEventArgs e)
        {
            int[] SelectedIndexs = PreselectedIndex(dataGridViewParticipants);
            int[] SelectedIndexs2 = PreselectedIndex(dataGridViewParticipantsMonografics);
            InitializeDataGridViewParticipants();
            InitializeDataGridViewParticipantsMonografic();
            //  InitializeDataGridViewTotsElsMonografics();
            //InitializeComboboxMonogràfics();
            PostselectedIndex(dataGridViewParticipants, SelectedIndexs);
            PostselectedIndex(dataGridViewParticipantsMonografics, SelectedIndexs2);

        }
        private void formMonografic_FormClosed(object sender, FormClosedEventArgs e)
        {
            try { 
            int[] SelectedIndexs = PreselectedIndex(dataGridViewMonografics);
            int[] SelectedIndexs2 = PreselectedIndex(dataGridViewParticipantsMonografics);
            InitializeDataGridViewTotsElsMonografics();
            InitializeComboboxMonogràfics();
            InitializeDataGridViewParticipantsMonografic();
            PostselectedIndexOnlyOneRow(dataGridViewMonografics, SelectedIndexs);
            PostselectedIndex(dataGridViewParticipantsMonografics, SelectedIndexs2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void formCursos_FormClosed(object sender, FormClosedEventArgs e)
        {

            int[] SelectedIndexs1 = PreselectedIndex(dataGridViewAlumnes);
            int[] SelectedIndexs2 = PreselectedIndex(dataGridViewTotselsCursos);
            InitializeDataGridView();
          
           
            InitializeDataGridViewTotsElsCursos();
            PostselectedIndex(dataGridViewAlumnes, SelectedIndexs1);
             PostselectedIndexOnlyOneRow(dataGridViewTotselsCursos, SelectedIndexs2);
        }
  
            private void formCursGWO_FormClosed(object sender, FormClosedEventArgs e)
        {

           
            int[] SelectedIndexs2 = PreselectedIndex(dataGridViewCursosGWO);
             InitializeDataGridViewCursosGWO();
            
               PostselectedIndexOnlyOneRow(dataGridViewCursosGWO, SelectedIndexs2);
        }
        //
        private void formComercialAltaAlumne_FormClosed(object sender, FormClosedEventArgs e)
        {


           
            InitializeDataGridViewComercialGeneral();
            InitializeDataGridViewAlumnes0();
            InitializeDataGridViewParticipantsSelectorCursos();
            InitializeDataGridView();
            InitializeDataGridViewAlumnesGWO();



        }
        private void formInteressatAltaAlumne_FormClosed(object sender, FormClosedEventArgs e)
        {

            int[] SelectedIndexs0 = PreselectedIndex(dataGridViewAlumnes0);
            int[] SelectedIndexs1 = PreselectedIndex(dataGridViewAlumnes);
            int[] SelectedIndexs2 = PreselectedIndex(dataGridViewPersonesComercial);
             int[] SelectedIndexs3 = PreselectedIndex(dataGridViewAlumnesGWO);
            InitializeDataGridViewPersonesComercial();
            InitializeDataGridViewAlumnes0();
            InitializeDataGridViewParticipantsSelectorCursos();
            InitializeDataGridView();
            InitializeDataGridViewAlumnesGWO();
            PostselectedIndex(dataGridViewAlumnes0, SelectedIndexs0);
            PostselectedIndex(dataGridViewAlumnes, SelectedIndexs1);
            PostselectedIndex(dataGridViewPersonesComercial, SelectedIndexs2);
            PostselectedIndex(dataGridViewAlumnesGWO, SelectedIndexs3);

        }
        private void formInteressat_FormClosed(object sender, FormClosedEventArgs e)
        {



            int[] SelectedIndexs2 = PreselectedIndex(dataGridViewPersonesComercial);
            InitializeDataGridViewPersonesComercial();
            PostselectedIndex(dataGridViewPersonesComercial, SelectedIndexs2);
        }

        private void formComercial_FormClosed(object sender, FormClosedEventArgs e)
        {



            int[] SelectedIndexs2 = PreselectedIndex(dataGridViewComercialGeneral);
            InitializeDataGridViewComercialGeneral();
            PostselectedIndex(dataGridViewComercialGeneral, SelectedIndexs2);
        }
        private void formEmpresaaComercial_FormClosed(object sender, FormClosedEventArgs e)
        {



          
            int[] SelectedIndexs1 = PreselectedIndex(dataGridViewEmpreses);
            int[] SelectedIndexs2 = PreselectedIndex(dataGridViewEmpreses2);
            InitializeDataGridViewComercialGeneral();
            InitializeDataGridViewEmpreses(dataGridViewEmpreses, EMPRESABOX, CONTACTEBOX);
            InitializeDataGridViewEmpreses(dataGridViewEmpreses2, EMPRESABOX2, CONTACTEBOX2);
           
            PostselectedIndex(dataGridViewEmpreses, SelectedIndexs1);
            PostselectedIndex(dataGridViewEmpreses2, SelectedIndexs2);
        }
        private void formEmpresaaInteressada_FormClosed(object sender, FormClosedEventArgs e)
        {



            int[] SelectedIndexs = PreselectedIndex(dataGridViewComercialEmpreses);
            int[] SelectedIndexs1 = PreselectedIndex(dataGridViewEmpreses);
            int[] SelectedIndexs2 = PreselectedIndex(dataGridViewEmpreses2);
            InitializeDataGridViewEmpresesComercial();
            InitializeDataGridViewEmpreses(dataGridViewEmpreses, EMPRESABOX, CONTACTEBOX);
            InitializeDataGridViewEmpreses(dataGridViewEmpreses2, EMPRESABOX2, CONTACTEBOX2);
            InitializeComboboxEmpresa();
            PostselectedIndex(dataGridViewComercialEmpreses, SelectedIndexs);
            PostselectedIndex(dataGridViewEmpreses, SelectedIndexs1);
            PostselectedIndex(dataGridViewEmpreses2, SelectedIndexs2);
        }
        private void formNovaEmpresa_FormClosed(object sender, FormClosedEventArgs e)
        {

            int[] SelectedIndexs0 = PreselectedIndex(dataGridViewAlumnes0);
            int[] SelectedIndexs = PreselectedIndex(dataGridViewAlumnes);
            
            int[] SelectedIndexs1 = PreselectedIndex(dataGridViewEmpreses);
            int[] SelectedIndexs2 = PreselectedIndex(dataGridViewEmpreses2);
            int[] SelectedIndexs3 = PreselectedIndex(dataGridViewTotselsCursos);
            int[] SelectedIndexs4 = PreselectedIndex(dataGridViewAlumnesGWO);
            InitializeDataGridViewAlumnes0();
            InitializeDataGridView();
            InitializeDataGridViewParticipantsSelectorCursos();
            InitializeDataGridViewAlumnesGWO();
            InitializeDataGridViewTotsElsCursos();
            InitializeDataGridViewEmpreses(dataGridViewEmpreses, EMPRESABOX, CONTACTEBOX);
            InitializeDataGridViewEmpreses(dataGridViewEmpreses2, EMPRESABOX2, CONTACTEBOX2);
            InitializeComboboxEmpresa();
            PostselectedIndex(dataGridViewAlumnes0, SelectedIndexs0);
            PostselectedIndex(dataGridViewAlumnes, SelectedIndexs);
            PostselectedIndex(dataGridViewAlumnesGWO, SelectedIndexs4);
            PostselectedIndex(dataGridViewEmpreses, SelectedIndexs1);
            PostselectedIndex(dataGridViewEmpreses2, SelectedIndexs2);
            PostselectedIndex(dataGridViewTotselsCursos, SelectedIndexs3);
        }
        //formFormador_FormClosed
        private void formFormador_FormClosed(object sender, FormClosedEventArgs e)
        {
            InitializeDataGridViewFormadors();
        }

            private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

    


        private void button3_Click(object sender, EventArgs e)
        {


            Int32 selectedRowCount =
        dataGridViewAlumnes.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (selectedRowCount > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                for (int i = 0; i < selectedRowCount; i++)
                {
                    string id = dataGridViewAlumnes.SelectedRows[i].Cells[0].Value.ToString();
                    string nom = dataGridViewAlumnes.SelectedRows[i].Cells[1].Value.ToString();
                    string Cognoms = dataGridViewAlumnes.SelectedRows[i].Cells[2].Value.ToString();
                    CursosSeleccionat formCursos = new CursosSeleccionat(mysqlconnect, id, nom, Cognoms);
                    formCursos.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formCursos_FormClosed);
                    formCursos.Show();

                }


            }

        }

        private void button2_Click(object sender, EventArgs e)
        {       /// Boto Modificar


            int selectedRowCount = dataGridViewAlumnes.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {

                    try
                    {
                        MySqlConnection conn = mysqlconnect.getmysqlconn();
                        string AlumneId = dataGridViewAlumnes.SelectedRows[i].Cells[0].Value.ToString();

                        FormModificarAlumne formModificar = new FormModificarAlumne(mysqlconnect, AlumneId);

                        formModificar.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formAlumnes_FormClosed);

                        formModificar.Show();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                }
            }

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridView();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridView();
        }

        private void tabs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            InitializeDataGridView();
        }

        private void dTPfinal_ValueChanged(object sender, EventArgs e)
        {
            dTPfinal.Format = DateTimePickerFormat.Long;
            InitializeDataGridView();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void TELEFONBOX_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridView();
        }

        private void comboBoxEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitializeDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {




            int selectedRowCount = dataGridViewAlumnes.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                var confirmEliminar = MessageBox.Show("Segur que vols eliminar les files seleccionades?",
                    "Confirmació d'Eliminació!",
                    MessageBoxButtons.YesNo);
                if (confirmEliminar == DialogResult.Yes)
                {





                    System.Text.StringBuilder sb = new System.Text.StringBuilder();

                    for (int i = 0; i < selectedRowCount; i++)
                    {

                        try
                        {
                            MySqlConnection conn = mysqlconnect.getmysqlconn();
                            string AlumneId = dataGridViewAlumnes.SelectedRows[0].Cells[0].Value.ToString();
                            // Se crea un DataTable que almacenará los datos desde donde se cargaran los datos al DataGridView
                            DataTable DtDadesAlumnes = new DataTable();
                            // Se crea un MySqlAdapter para obtener los datos de la base



                            string Query = "delete from Alumnes where AlumneID=" + AlumneId + ";";
                            MySqlCommand cmd = new MySqlCommand(Query, conn);
                            MySqlDataReader MyReader2;
                            conn.Open();
                            MyReader2 = cmd.ExecuteReader();     // Here our query will be executed and data saved into the database. 
                            MyReader2.Close();
                            conn.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        InitializeDataGridViewAlumnes0();
                        InitializeDataGridViewParticipantsSelectorCursos();
                        InitializeDataGridView();
                        InitializeDataGridViewAlumnesGWO();
                        

                    }
                }

            }
        }

        private void dataGridViewTotselsCursos_SelectionChanged(object sender, EventArgs e)
        {


            InitializeDataGridViewAlumnesdelCurs();


        }

        private void btAfegirAlumnesalCurs_Click(object sender, EventArgs e)
        {
            int selectedRowCount = dataGridViewTotselsCursos.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {

                    try
                    {
                        MySqlConnection conn = mysqlconnect.getmysqlconn();
                        string CursId = dataGridViewTotselsCursos.SelectedRows[i].Cells[0].Value.ToString();

                        FormAlumnesCurs formAlumnesCurs = new FormAlumnesCurs(mysqlconnect, CursId);

                        formAlumnesCurs.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formCursos_FormClosed);

                        formAlumnesCurs.Show();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                }
            }
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtBNomCurs_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewTotsElsCursos();
        }

        private void btNouCurs_Click(object sender, EventArgs e)
        {

            FormNouCurs formNouCurs = new FormNouCurs(mysqlconnect);

            formNouCurs.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formCursos_FormClosed);

            formNouCurs.Show();
        }

        private void btEliminarCurs_Click(object sender, EventArgs e)
        {
            int selectedRowCount = dataGridViewTotselsCursos.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                var confirmEliminar = MessageBox.Show("Segur que vols eliminar el curs seleccionat?",
                    "Confirmació d'Eliminació!",
                    MessageBoxButtons.YesNo);
                if (confirmEliminar == DialogResult.Yes)
                {

                    for (int i = 0; i < selectedRowCount; i++)
                    {

                        try
                        {
                            MySqlConnection conn = mysqlconnect.getmysqlconn();
                            string CursId = dataGridViewTotselsCursos.SelectedRows[0].Cells[0].Value.ToString();
                            string Query = "delete from Cursos where CursID=" + CursId + ";";
                            MySqlCommand cmd = new MySqlCommand(Query, conn);
                            MySqlDataReader MyReader2;
                            conn.Open();
                            MyReader2 = cmd.ExecuteReader();     // Here our query will be executed and data saved into the database. 
                            MyReader2.Close();
                            conn.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        InitializeDataGridViewTotsElsCursos();


                    }
                }
            }

        }

        private void btEditarCurs_Click(object sender, EventArgs e)
        {

            int selectedRowCount = dataGridViewTotselsCursos.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {

                    try
                    {
                        MySqlConnection conn = mysqlconnect.getmysqlconn();
                        string CursId = dataGridViewTotselsCursos.SelectedRows[i].Cells[0].Value.ToString();

                        FormEditarCurs formEditarCurs = new FormEditarCurs(mysqlconnect, CursId);

                        formEditarCurs.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formCursos_FormClosed);

                        formEditarCurs.Show();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                }
            }

        }

        private void dataGridViewAlumnes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void dataGridViewAlumnes_BindingContextChanged(object sender, EventArgs e)
        {
            FormatDataGridViewAlumnes();
        }


        private void FormatDataGridViewAlumnes()
        {

            if (dataGridViewAlumnes.Rows.Count > 0)
            {
                for (int row = 0; row < dataGridViewAlumnes.Rows.Count; row++)
                {
                    if (!dataGridViewAlumnes.Rows[row].IsNewRow)
                    {
                        ;
                        string Estat = dataGridViewAlumnes.Rows[row].Cells["Estat del venciment"].Value.ToString();

                        if (Estat.Equals("Aprovat")) { dataGridViewAlumnes.Rows[row].DefaultCellStyle.BackColor = verd; }
                        
                        DateTime date = DateTime.Now;
                        string dtstring = dataGridViewAlumnes.Rows[row].Cells["Venciment vigent"].Value.ToString();

                        DateTime dtvenciment;
                        DateTime.TryParseExact(dtstring, "dd/MM/yyyy H:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dtvenciment);
                       


                        if (DateTime.Compare(dtvenciment, date) < 0) { dataGridViewAlumnes.Rows[row].DefaultCellStyle.BackColor = alumneSuspes; }
                        if (Estat.Equals("Suspès")) { dataGridViewAlumnes.Rows[row].DefaultCellStyle.BackColor = alumneSuspes; }
                    }
                }
            }
        }
        private void FormatDataGridViewAlumnesGWO()
        {
         
            if (dataGridViewAlumnesGWO.Rows.Count > 0)
            {
                for (int row = 0; row < dataGridViewAlumnesGWO.Rows.Count; row++)
                {
                    if (!dataGridViewAlumnesGWO.Rows[row].IsNewRow)
                    {
                        ;
                        string Estat = dataGridViewAlumnesGWO.Rows[row].Cells["Estat del venciment"].Value.ToString();

                        if (Estat.Equals("Aprovat")) { dataGridViewAlumnesGWO.Rows[row].DefaultCellStyle.BackColor = verd; }

                        DateTime date = DateTime.Now;
                        string dtstring = dataGridViewAlumnesGWO.Rows[row].Cells["Venciment vigent"].Value.ToString();

                        DateTime dtvenciment;
                        DateTime.TryParseExact(dtstring, "dd/MM/yyyy H:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dtvenciment);



                        if (DateTime.Compare(dtvenciment, date) < 0) { dataGridViewAlumnesGWO.Rows[row].DefaultCellStyle.BackColor = alumneSuspes; }
                        if (Estat.Equals("Suspès")) { dataGridViewAlumnesGWO.Rows[row].DefaultCellStyle.BackColor = alumneSuspes; }
                    }
                }
            }
        }

        private void btAlumnesvinculats_Click(object sender, EventArgs e)
        {

        }

        private void lbEliminarEmpresa_Click(object sender, EventArgs e)
        {
            int selectedRowCount = dataGridViewEmpreses.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                var confirmEliminar = MessageBox.Show("Segur que vols eliminar la Empresa seleccionada?",
                    "Confirmació d'Eliminació!",
                    MessageBoxButtons.YesNo);
                if (confirmEliminar == DialogResult.Yes)
                {

                    for (int i = 0; i < selectedRowCount; i++)
                    {

                        try
                        {
                            MySqlConnection conn = mysqlconnect.getmysqlconn();
                            int EmpresaId = int.Parse(dataGridViewEmpreses.SelectedRows[0].Cells[0].Value.ToString());
                            if (EmpresaId > 4)
                            {
                                string Query = "delete from Empreses where EmpresaID=" + EmpresaId + ";";
                                MySqlCommand cmd = new MySqlCommand(Query, conn);
                                MySqlDataReader MyReader2;
                                conn.Open();
                                MyReader2 = cmd.ExecuteReader();     // Here our query will be executed and data saved into the database. 
                                MyReader2.Close();
                                conn.Close();
                            }
                            else { MessageBox.Show("Aquest registre no es pot eliminar per seguretat."); }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        InitializeDataGridViewEmpreses(dataGridViewEmpreses, EMPRESABOX, CONTACTEBOX);
                        InitializeDataGridViewEmpreses(dataGridViewEmpreses2, EMPRESABOX2, CONTACTEBOX2);
                        InitializeComboboxEmpresa();

                    }
                }
            }
        }

        private void lbNovaEmpresa_Click(object sender, EventArgs e)
        {
            FormNovaEmpresa formNovaEmpresa = new FormNovaEmpresa(mysqlconnect);

            formNovaEmpresa.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formNovaEmpresa_FormClosed);

            formNovaEmpresa.Show();
        }

        private void lbEditarEmpresa_Click(object sender, EventArgs e)
        {

            int selectedRowCount = dataGridViewEmpreses.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {

                    try
                    {
                        MySqlConnection conn = mysqlconnect.getmysqlconn();
                        string EmpresaId = dataGridViewEmpreses.SelectedRows[i].Cells[0].Value.ToString();
                        if (EmpresaId != "1")
                        {
                            FormEditarEmpresa formEditarEmpresa = new FormEditarEmpresa(mysqlconnect, EmpresaId);

                            formEditarEmpresa.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formNovaEmpresa_FormClosed);

                            formEditarEmpresa.Show();
                        }
                        else { MessageBox.Show("Aquest registre no es pot editar per seguretat."); }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                }
            }
        }

        private void btEditarAlumnesEmpresa_Click(object sender, EventArgs e)
        {

            FormAlumnesEmpresa formAlumnesEmpresa = new FormAlumnesEmpresa(mysqlconnect);

            formAlumnesEmpresa.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formNovaEmpresa_FormClosed);

            formAlumnesEmpresa.Show();
        }

        private void dataGridViewEmpreses_SelectionChanged(object sender, EventArgs e)
        {


            if (dataGridViewEmpreses.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0)
            {

                string EmpresaId = dataGridViewEmpreses.SelectedRows[0].Cells[0].Value.ToString();

                InitializeDataGridViewAlumnesdeldelaEmpresa(EmpresaId);
            }
        }

        private void CONTACTEBOX_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewEmpreses(dataGridViewEmpreses, EMPRESABOX, CONTACTEBOX);

        }

        private void EMPRESABOX_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewEmpreses(dataGridViewEmpreses, EMPRESABOX, CONTACTEBOX);
        }

        private void NOM2BOX_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewPersonesComercial();
        }

        private void COGNOMS2BOX_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewPersonesComercial();
        }

        private void TELEFON2BOX_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewPersonesComercial();
        }

        private void CORREU2BOX_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewPersonesComercial();
        }

        private void DNI2BOX_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewPersonesComercial();
        }

        private void ComboBoxInformat_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewPersonesComercial();
        }

        private void btNouInteressat_Click(object sender, EventArgs e)
        {

            FormNouInteressat formNouInteressat = new FormNouInteressat(mysqlconnect);

            formNouInteressat.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formInteressat_FormClosed);

            formNouInteressat.Show();
        }

        private void btEliminarComercial_Click(object sender, EventArgs e)
        {
            int selectedRowCount = dataGridViewPersonesComercial.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                var confirmEliminar = MessageBox.Show("Segur que vols eliminar les files seleccionades?",
                    "Confirmació d'Eliminació!",
                    MessageBoxButtons.YesNo);
                if (confirmEliminar == DialogResult.Yes)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();

                    for (int i = 0; i < selectedRowCount; i++)
                    {

                        try
                        {
                            MySqlConnection conn = mysqlconnect.getmysqlconn();
                            string ParticularId = dataGridViewPersonesComercial.SelectedRows[0].Cells[0].Value.ToString();
                            // Se crea un DataTable que almacenará los datos desde donde se cargaran los datos al DataGridView
                            DataTable DtDadesPersonesComercial = new DataTable();
                            // Se crea un MySqlAdapter para obtener los datos de la base



                            string Query = "delete from ComercialParticulars where PersonaID=" + ParticularId + ";";
                            MySqlCommand cmd = new MySqlCommand(Query, conn);
                            MySqlDataReader MyReader2;
                            conn.Open();
                            MyReader2 = cmd.ExecuteReader();     // Here our query will be executed and data saved into the database. 
                            MyReader2.Close();
                            conn.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        InitializeDataGridViewPersonesComercial();


                    }
                }

            }
        }

        private void btModificarComercial_Click(object sender, EventArgs e)
        {

            int selectedRowCount = dataGridViewPersonesComercial.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {

                    try
                    {
                        MySqlConnection conn = mysqlconnect.getmysqlconn();
                        string PersonaId = dataGridViewPersonesComercial.SelectedRows[i].Cells[0].Value.ToString();

                        FormModificarInteressat formModificarParticular = new FormModificarInteressat(mysqlconnect, PersonaId);

                        formModificarParticular.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formInteressat_FormClosed);

                        formModificarParticular.Show();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                }
            }

        }

        private void btAltaComAlumne_Click(object sender, EventArgs e)
        {

            int selectedRowCount = dataGridViewPersonesComercial.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {

                    try
                    {
                        MySqlConnection conn = mysqlconnect.getmysqlconn();
                        string PersonaId = dataGridViewPersonesComercial.SelectedRows[i].Cells[0].Value.ToString();

                        FormInteressatAltaAlumne formInteressaAltatAlumne = new FormInteressatAltaAlumne(mysqlconnect, PersonaId);

                        formInteressaAltatAlumne.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formInteressatAltaAlumne_FormClosed);

                        formInteressaAltatAlumne.Show();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                }
            }

        }

        private void btInformats_Click(object sender, EventArgs e)
        {
            int selectedRowCount = dataGridViewPersonesComercial.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                List<string> PersonesID = new List<string>();
                for (int i = 0; i < selectedRowCount; i++)
                {
                    string PersonaId = dataGridViewPersonesComercial.SelectedRows[i].Cells[0].Value.ToString();
                    PersonesID.Add(PersonaId);
                }
                FormCanviInformat formCanviInformat = new FormCanviInformat(mysqlconnect, PersonesID, "ComercialParticulars","PersonaID");

                formCanviInformat.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formInteressat_FormClosed);

                formCanviInformat.Show();


            }

        }

        private void dataGridViewAlumnes_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FormatDataGridViewAlumnes();
        }

        private void NOMEMPRESABOX_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewEmpresesComercial();
        }

        private void CONTACTE3BOX_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewEmpresesComercial();
        }

        private void TELEFON3BOX_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewEmpresesComercial();
        }

        private void CORREU3BOX_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewEmpresesComercial();
        }

        private void comboBoxInformatEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewEmpresesComercial();
        }

        private void btEliminarComercialEmpresa_Click(object sender, EventArgs e)
        {
            int selectedRowCount = dataGridViewComercialEmpreses.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                var confirmEliminar = MessageBox.Show("Segur que vols eliminar les files seleccionades?",
                    "Confirmació d'Eliminació!",
                    MessageBoxButtons.YesNo);
                if (confirmEliminar == DialogResult.Yes)
                {





                    System.Text.StringBuilder sb = new System.Text.StringBuilder();

                    for (int i = 0; i < selectedRowCount; i++)
                    {

                        try
                        {
                            MySqlConnection conn = mysqlconnect.getmysqlconn();
                            string EmpresaInteressadaId = dataGridViewComercialEmpreses.SelectedRows[0].Cells[0].Value.ToString();
                            // Se crea un DataTable que almacenará los datos desde donde se cargaran los datos al DataGridView
                            DataTable DtDadesPersonesComercial = new DataTable();
                            // Se crea un MySqlAdapter para obtener los datos de la base



                            string Query = "delete from ComercialEmpreses where EmpresaInteressadaID=" + EmpresaInteressadaId + ";";
                            MySqlCommand cmd = new MySqlCommand(Query, conn);
                            MySqlDataReader MyReader2;
                            conn.Open();
                            MyReader2 = cmd.ExecuteReader();     // Here our query will be executed and data saved into the database. 
                            MyReader2.Close();
                            conn.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        InitializeDataGridViewEmpresesComercial();


                    }
                }

            }
        }

        private void btNovaEmpresaInteressada_Click(object sender, EventArgs e)
        {
            FormNovaEmpresaInteressada formNovaEmpresaInteressada = new FormNovaEmpresaInteressada(mysqlconnect);

            formNovaEmpresaInteressada.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formEmpresaaInteressada_FormClosed);

            formNovaEmpresaInteressada.Show();
        }

        private void btModificarComercialEmpresa_Click(object sender, EventArgs e)
        {

            int selectedRowCount = dataGridViewComercialEmpreses.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {

                    try
                    {
                        MySqlConnection conn = mysqlconnect.getmysqlconn();
                        string EmpresaId = dataGridViewComercialEmpreses.SelectedRows[i].Cells[0].Value.ToString();

                        FormModificarEmpresaInteressada formModificarEmpresaInteressada = new FormModificarEmpresaInteressada(mysqlconnect, EmpresaId);

                        formModificarEmpresaInteressada.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formEmpresaaInteressada_FormClosed);

                        formModificarEmpresaInteressada.Show();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                }
            }
        }

        private void btInformatComercialEmpresa_Click(object sender, EventArgs e)
        {
            int selectedRowCount = dataGridViewComercialEmpreses.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                List<string> EmpresesID = new List<string>();
                for (int i = 0; i < selectedRowCount; i++)
                {
                    string EmpresaId = dataGridViewComercialEmpreses.SelectedRows[i].Cells[0].Value.ToString();
                    EmpresesID.Add(EmpresaId);
                }
                FormCanviInformatEmpreses formCanviInformatEmpreses = new FormCanviInformatEmpreses(mysqlconnect, EmpresesID);

                formCanviInformatEmpreses.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formEmpresaaInteressada_FormClosed);

                formCanviInformatEmpreses.Show();


            }
        }

        private void btAltaComEmpresa_Click(object sender, EventArgs e)
        {

            int selectedRowCount = dataGridViewComercialEmpreses.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {

                    try
                    {
                        MySqlConnection conn = mysqlconnect.getmysqlconn();
                        string EmpresaId = dataGridViewComercialEmpreses.SelectedRows[i].Cells[0].Value.ToString();

                        FormInteressatAltaEmpresa formInteressatAltatEmpresa = new FormInteressatAltaEmpresa(mysqlconnect, EmpresaId);

                        formInteressatAltatEmpresa.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formEmpresaaInteressada_FormClosed);

                        formInteressatAltatEmpresa.Show();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                }
            }
        }

        private void comboBoxCursos_SelectedIndexChanged(object sender, EventArgs e)
        {

            InitializeDataGridViewPersonesComercial();
        }

        private void dTPPreferenciafinal_ValueChanged(object sender, EventArgs e)
        {
            dTPPreferenciafinal.Format = DateTimePickerFormat.Long;
            InitializeDataGridViewPersonesComercial();
        }

        private void dTPPreferenciainici_ValueChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewPersonesComercial();
        }

        private void dTPPreferenciafinalEmpresa_ValueChanged(object sender, EventArgs e)
        {
            dTPPreferenciafinalEmpresa.Format = DateTimePickerFormat.Long;
            InitializeDataGridViewEmpresesComercial();
        }

        private void dTPPreferenciainiciEmpresa_ValueChanged(object sender, EventArgs e)
        {

            InitializeDataGridViewEmpresesComercial();
        }

        private void dataGridViewComercialEmpreses_RowDividerDoubleClick(object sender, DataGridViewRowDividerDoubleClickEventArgs e)
        {
            int selectedRowCount = dataGridViewComercialEmpreses.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {

                    try
                    {
                        MySqlConnection conn = mysqlconnect.getmysqlconn();
                        string EmpresaId = dataGridViewComercialEmpreses.SelectedRows[i].Cells[0].Value.ToString();

                        FormModificarEmpresaInteressada formModificarEmpresaInteressada = new FormModificarEmpresaInteressada(mysqlconnect, EmpresaId);

                        formModificarEmpresaInteressada.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formEmpresaaInteressada_FormClosed);

                        formModificarEmpresaInteressada.Show();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                }
            }
        }

        private void dataGridViewPersonesComercial_RowDividerDoubleClick(object sender, DataGridViewRowDividerDoubleClickEventArgs e)
        {

        }

        private void dataGridViewPersonesComercial_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {


            int selectedRowCount = dataGridViewPersonesComercial.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {

                    try
                    {
                        MySqlConnection conn = mysqlconnect.getmysqlconn();
                        string PersonaId = dataGridViewPersonesComercial.SelectedRows[i].Cells[0].Value.ToString();

                        FormModificarInteressat formModificarParticular = new FormModificarInteressat(mysqlconnect, PersonaId);

                        formModificarParticular.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formInteressat_FormClosed);

                        formModificarParticular.Show();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }




                }
            }
        }

        private void dataGridViewComercialEmpreses_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRowCount = dataGridViewComercialEmpreses.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {

                    try
                    {
                        MySqlConnection conn = mysqlconnect.getmysqlconn();
                        string EmpresaId = dataGridViewComercialEmpreses.SelectedRows[i].Cells[0].Value.ToString();

                        FormModificarEmpresaInteressada formModificarEmpresaInteressada = new FormModificarEmpresaInteressada(mysqlconnect, EmpresaId);

                        formModificarEmpresaInteressada.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formEmpresaaInteressada_FormClosed);

                        formModificarEmpresaInteressada.Show();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                }

            }
        }

       
        private void dataGridViewTotselsCursos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


            int selectedRowCount = dataGridViewTotselsCursos.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {

                    try
                    {
                        MySqlConnection conn = mysqlconnect.getmysqlconn();
                        string CursId = dataGridViewTotselsCursos.SelectedRows[i].Cells[0].Value.ToString();

                        FormEditarCurs formEditarCurs = new FormEditarCurs(mysqlconnect, CursId);

                        formEditarCurs.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formCursos_FormClosed);

                        formEditarCurs.Show();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                }
            }
        }

        private void dataGridViewEmpreses_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


            int selectedRowCount = dataGridViewEmpreses.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {

                    try
                    {
                        MySqlConnection conn = mysqlconnect.getmysqlconn();
                        string EmpresaId = dataGridViewEmpreses.SelectedRows[i].Cells[0].Value.ToString();
                        if (EmpresaId != "1")
                        {
                            FormEditarEmpresa formEditarEmpresa = new FormEditarEmpresa(mysqlconnect, EmpresaId);

                            formEditarEmpresa.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formNovaEmpresa_FormClosed);

                            formEditarEmpresa.Show();
                        }
                        else { MessageBox.Show("Aquest registre no es pot editar per seguretat."); }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                }
            }

        }

        private void btNouMonografic_Click(object sender, EventArgs e)
        {

            FormNouMonogràfic formNouMonografic = new FormNouMonogràfic(mysqlconnect);

            formNouMonografic.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formMonografic_FormClosed);

            formNouMonografic.Show();
        }

        private void btEditarMonografic_Click(object sender, EventArgs e)
        {
            int selectedRowCount = dataGridViewMonografics.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {

                    try
                    {
                        MySqlConnection conn = mysqlconnect.getmysqlconn();
                        string MonograficId = dataGridViewMonografics.SelectedRows[i].Cells[0].Value.ToString();

                        FormEditarMonografic editarMonografic = new FormEditarMonografic(mysqlconnect, MonograficId);

                        editarMonografic.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formMonografic_FormClosed);

                        editarMonografic.Show();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                }
            }

        }

        private void btEliminarMonogràfic_Click(object sender, EventArgs e)
        {
            int selectedRowCount = dataGridViewMonografics.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                var confirmEliminar = MessageBox.Show("Segur que vols eliminar les files seleccionades?",
                    "Confirmació d'Eliminació!",
                    MessageBoxButtons.YesNo);
                if (confirmEliminar == DialogResult.Yes)
                {





                    System.Text.StringBuilder sb = new System.Text.StringBuilder();

                    for (int i = 0; i < selectedRowCount; i++)
                    {

                        try
                        {
                            MySqlConnection conn = mysqlconnect.getmysqlconn();
                            string MonograficId = dataGridViewMonografics.SelectedRows[0].Cells[0].Value.ToString();
                            string Query = "delete from Monografics where MonograficID=" + MonograficId + ";";
                            MySqlCommand cmd = new MySqlCommand(Query, conn);
                            conn.Open();
                            cmd.ExecuteReader();     // Here our query will be executed and data saved into the database. 
                            conn.Close();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        InitializeDataGridViewTotsElsMonografics();


                    }
                }

            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            FormNovaEmpresa formNovaEmpresa = new FormNovaEmpresa(mysqlconnect);

            formNovaEmpresa.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formNovaEmpresa_FormClosed);

            formNovaEmpresa.Show();
        }

        private void btEliminarEmpresa2_Click(object sender, EventArgs e)
        {

            int selectedRowCount = dataGridViewEmpreses2.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                var confirmEliminar = MessageBox.Show("Segur que vols eliminar la Empresa seleccionada?",
                    "Confirmació d'Eliminació!",
                    MessageBoxButtons.YesNo);
                if (confirmEliminar == DialogResult.Yes)
                {

                    for (int i = 0; i < selectedRowCount; i++)
                    {

                        try
                        {
                            MySqlConnection conn = mysqlconnect.getmysqlconn();
                            int EmpresaId = int.Parse(dataGridViewEmpreses2.SelectedRows[0].Cells[0].Value.ToString());
                            if (EmpresaId > 4)
                            {
                                string Query = "delete from Empreses where EmpresaID=" + EmpresaId + ";";
                                MySqlCommand cmd = new MySqlCommand(Query, conn);
                                MySqlDataReader MyReader2;
                                conn.Open();
                                MyReader2 = cmd.ExecuteReader();     // Here our query will be executed and data saved into the database. 
                                MyReader2.Close();
                                conn.Close();
                            }
                            else { MessageBox.Show("Aquest registre no es pot eliminar per seguretat."); }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        InitializeDataGridViewEmpreses(dataGridViewEmpreses, EMPRESABOX, CONTACTEBOX);
                        InitializeDataGridViewEmpreses(dataGridViewEmpreses2, EMPRESABOX2, CONTACTEBOX2);


                    }
                }
            }
        }

        private void btEditarEmpresa2_Click(object sender, EventArgs e)
        {


            int selectedRowCount = dataGridViewEmpreses2.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {

                    try
                    {
                        MySqlConnection conn = mysqlconnect.getmysqlconn();
                        string EmpresaId = dataGridViewEmpreses2.SelectedRows[i].Cells[0].Value.ToString();
                        if (EmpresaId != "1")
                        {
                            FormEditarEmpresa formEditarEmpresa = new FormEditarEmpresa(mysqlconnect, EmpresaId);

                            formEditarEmpresa.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formNovaEmpresa_FormClosed);

                            formEditarEmpresa.Show();
                        }
                        else { MessageBox.Show("Aquest registre no es pot editar per seguretat."); }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                }
            }
        }

        private void dataGridViewEmpreses2_SelectionChanged(object sender, EventArgs e)
        {

            if (dataGridViewEmpreses2.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0)
            {

                string EmpresaId = dataGridViewEmpreses2.SelectedRows[0].Cells[0].Value.ToString();

                InitializeDataGridViewParticipantsdeldelaEmpresa(EmpresaId);
            }
        }

        private void btAltaParticipant_Click(object sender, EventArgs e)
        {
            FormAltaParticipant formAlta = new FormAltaParticipant(mysqlconnect);

            formAlta.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formAltaParticipant_FormClosed);

            formAlta.Show();
        }

        private void btEliminarParticipants_Click(object sender, EventArgs e)
        {




            int selectedRowCount = dataGridViewParticipants.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                var confirmEliminar = MessageBox.Show("Segur que vols eliminar les files seleccionades?",
                    "Confirmació d'Eliminació!",
                    MessageBoxButtons.YesNo);
                if (confirmEliminar == DialogResult.Yes)
                {





                    System.Text.StringBuilder sb = new System.Text.StringBuilder();

                    for (int i = 0; i < selectedRowCount; i++)
                    {

                        try
                        {
                            MySqlConnection conn = mysqlconnect.getmysqlconn();
                            string ParticipantId = dataGridViewParticipants.SelectedRows[0].Cells[0].Value.ToString();
                            // Se crea un DataTable que almacenará los datos desde donde se cargaran los datos al DataGridView
                            DataTable DtDadesAlumnes = new DataTable();
                            // Se crea un MySqlAdapter para obtener los datos de la base



                            string Query = "delete from Participants where ParticipantID=" + ParticipantId + ";";
                            MySqlCommand cmd = new MySqlCommand(Query, conn);
                            MySqlDataReader MyReader2;
                            conn.Open();
                            MyReader2 = cmd.ExecuteReader();     // Here our query will be executed and data saved into the database. 
                            MyReader2.Close();
                            conn.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        InitializeDataGridViewParticipants();


                    }
                }

            }
        }

        private void btModificarParticipants_Click(object sender, EventArgs e)
        {

            int selectedRowCount = dataGridViewParticipants.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {

                    try
                    {
                        MySqlConnection conn = mysqlconnect.getmysqlconn();
                        string ParticipantId = dataGridViewParticipants.SelectedRows[i].Cells[0].Value.ToString();

                        FormModificarParticipant formModificar = new FormModificarParticipant(mysqlconnect, ParticipantId);

                        formModificar.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formModificarParticipant_FormClosed);

                        formModificar.Show();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FormParticipantsEmpresa formParticipantsEmpresa = new FormParticipantsEmpresa(mysqlconnect);

            formParticipantsEmpresa.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formModificarParticipant_FormClosed);

            formParticipantsEmpresa.Show();
        }

        private void btSeleccionarParticipants_Click(object sender, EventArgs e)
        {
            int selectedRowCount = dataGridViewMonografics.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {

                    try
                    {
                        MySqlConnection conn = mysqlconnect.getmysqlconn();
                        string ParticipantId = dataGridViewMonografics.SelectedRows[i].Cells["MonograficID"].Value.ToString();
                        string Titol = dataGridViewMonografics.SelectedRows[i].Cells["Titol"].Value.ToString();
                        string EmpresaID = dataGridViewMonografics.SelectedRows[i].Cells["Empresa"].Value.ToString();
                        FormSeleccionarParticipanst formSeleccionarParticipants = new FormSeleccionarParticipanst(mysqlconnect, ParticipantId, Titol, EmpresaID);

                        formSeleccionarParticipants.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formSeleccionarParticipant_FormClosed);

                        formSeleccionarParticipants.Show();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                }
            }
        }

        private void dataGridViewMonografics_SelectionChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewParticipantsMonografic();

        }

        private void btExaminar_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtBDirectori.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }

        }

        private void comboBoxMonografics_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewParticipantsMonograficDiplomes();
        }

        private void btSeleccionar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewDiplomesParticipants.Rows.Count; i++)
            {
                dataGridViewDiplomesParticipants.Rows[i].Cells["?"].Value = true;


            }

        }

        private void btDeseleccionar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewDiplomesParticipants.Rows.Count; i++)
            {
                dataGridViewDiplomesParticipants.Rows[i].Cells["?"].Value = false;


            }

        }

        private void btGenerarDiplomesSel_Click(object sender, EventArgs e)
        {
            if (dataGridViewDiplomesParticipants.Rows.Count > 0)
            {
                bool obrirdirectori = false;
                for (int i = 0; i < dataGridViewDiplomesParticipants.Rows.Count; i++)
                {
                    try
                    {
                        DataGridViewRow row = dataGridViewDiplomesParticipants.Rows[i];
                      
                        if ((bool)(row.Cells["?"].Value) == true)
                        {
                            GenerarDiploma(comboBoxMonografics.SelectedValue.ToString(), row.Cells["ParticipantID"].Value.ToString());
                            obrirdirectori = true;
                        }
                    }

                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);

                    }

                }
               if (obrirdirectori) { Process.Start("explorer.exe", Dirpath); }
            }
        }

        private void GenerarDiploma(string MonograficID, string ParticipantID)
        {   //Participant

            string Nomparticipant = "", Cognoms = "", DNI = "", NomEmpresa = "", CIF = "", PersonaContacte = "", TelefonEmpresa = "", correuempresa = "";
            //Monografic
            string Codi = "", Titol = "", CodiAF = "", Grup = "", hores = "", horari = "", modalitat = "", MonograficTipusID = "";
            DateTime datainici = new DateTime(), datafi = new DateTime();
            int PercentatgeTeoric=0, PercentatgePractic = 0;
            string TitolTipusMonografic = "";
            List<ContingutMonografic> Continguts = new List<ContingutMonografic>();
                        MySqlConnection conn = mysqlconnect.getmysqlconn();
                        try
                        {
                
                            DataTable DtDadesParticipants = new DataTable();
                            string query = "Select Participants.`ParticipantID`,Participants.`Nom`,Participants.`Cognoms`,"
                           + "Participants.`DNI`,"
                      + " Empreses.`Nom de la empresa`, Empreses.`CIF`,Empreses.`Persona de contacte`,Empreses.`Telèfon`, Empreses.`Correu electrònic` "
                       + " FROM Participants "
                       + " LEFT JOIN empreses ON Participants.`EmpresaID`= empreses.`EmpresaID` "
                        + " WHERE ("
                    + "Participants.ParticipantID=?ParticipantID );";
                            MySqlCommand cmd = new MySqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("?ParticipantID", ParticipantID);
                            conn.Open();

                            MySqlDataReader reader = cmd.ExecuteReader();

                            reader.Read();

                            Nomparticipant = !reader.IsDBNull(1) ? reader.GetString(1) : "";
                            Cognoms = !reader.IsDBNull(2) ? reader.GetString(2) : ""; 
                            DNI = !reader.IsDBNull(3) ? reader.GetString(3) : ""; 
                            NomEmpresa = !reader.IsDBNull(4) ? reader.GetString(4) : "";
                            CIF = !reader.IsDBNull(5) ? reader.GetString(5) : "";
                            PersonaContacte = !reader.IsDBNull(6) ? reader.GetString(6) : ""; 
                            TelefonEmpresa = !reader.IsDBNull(7) ? reader.GetString(7) : ""; 
                            correuempresa = !reader.IsDBNull(8) ? reader.GetString(8) : ""; 
               
                            reader.Close();
              
                cmd = conn.CreateCommand();

                            cmd.CommandText = "Select * from Monografics where MonograficID= '" + MonograficID + "'";
              

                            reader = cmd.ExecuteReader();

                            reader.Read();

                            Codi = !reader.IsDBNull(1) ? reader.GetString(1) : "";
                              Titol = !reader.IsDBNull(2) ? reader.GetString(2) : "";
                                CodiAF = !reader.IsDBNull(3) ? reader.GetString(3) : "";
                            Grup = !reader.IsDBNull(4) ? reader.GetString(4) : "";
                            datainici = !reader.IsDBNull(5) ? reader.GetDateTime(5) : new DateTime();
                            datafi = !reader.IsDBNull(6) ? reader.GetDateTime(6) : new DateTime();
                           hores = !reader.IsDBNull(7) ? reader.GetString(7) : "";
                            horari = !reader.IsDBNull(8) ? reader.GetString(8) : "";
                            modalitat = !reader.IsDBNull(9) ? reader.GetString(9) : "";
                            MonograficTipusID = !reader.IsDBNull(10) ? reader.GetString(10) : "";
                           reader.Close();


                /////

                cmd = conn.CreateCommand();

                cmd.CommandText = "Select * from MonograficSTipus where MonograficTipusID= '" + MonograficTipusID + "'";


                reader = cmd.ExecuteReader();

                reader.Read();

                TitolTipusMonografic= !reader.IsDBNull(1) ? reader.GetString(1) : "";
                PercentatgeTeoric = !reader.IsDBNull(2) ? reader.GetInt16(2) :0;
                PercentatgePractic = !reader.IsDBNull(3) ? reader.GetInt16(3) : 0;
                reader.Close();
                ////

                

                DataTable DtDadesContingut = new DataTable();
                         query = "Select Contingut.ContingutID,Contingut.Titol, Contingut.Subtitols,TipusModul.Titol  From contingut"
                             + " INNER JOIN contingutsmonografictipus ON (contingutsmonografictipus.Contingut = Contingut.ContingutID"
                            + " AND contingutsmonografictipus.MonograficTipus = ?MonograficTipusID )"
                            + " INNER JOIN tipusmodul ON tipusmodul.TipusModulID = Contingut.`Tipus de modul`; ";

                             cmd = new MySqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("?MonograficTipusID", MonograficTipusID);
                            reader = cmd.ExecuteReader();

                            reader.Read();
                            if (reader.HasRows)
                                    { 
                                        while (reader.Read())
                                        {
 
                        Continguts.Add(new ContingutMonografic(!reader.IsDBNull(0) ? reader.GetString(0) : "", !reader.IsDBNull(1) ? reader.GetString(1) : "",
                                             !reader.IsDBNull(2) ? reader.GetString(2) : "", !reader.IsDBNull(3) ? reader.GetString(3) : ""));
                                    
                                        }
                }
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




            if (!Directory.Exists(txtBDirectori.Text)){ txtBDirectori.Text= Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); }
             Dirpath = txtBDirectori.Text;
            string congomssenseespai = Cognoms.Replace(" ", "");
            string nomArxiu = Codi + congomssenseespai + "_" + Nomparticipant + "_AccesVertical_" + TitolTipusMonografic;
         if(nomArxiu.Length>140) nomArxiu=  nomArxiu.Substring(0, 140);
            string pathString = System.IO.Path.Combine(Dirpath,nomArxiu+ ".pdf");

            FileStream fs = new FileStream(pathString, FileMode.Create, FileAccess.Write, FileShare.None);
            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.AddTitle(TitolTipusMonografic);
            doc.AddCreator("Acces Vertical S.L");
            doc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
            doc.Open();
            // step 4: we grab the ContentByte and do some stuff with it
            PdfContentByte cb = writer.DirectContent;
            // we tell the ContentByte we're ready to draw text
            cb.BeginText();
            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.EMBEDDED);
            cb.SetFontAndSize(bf, 17);
            iTextSharp.text.Image backImg = iTextSharp.text.Image.GetInstance("CERTIFICADO-PORTADA.png");
            backImg.SetAbsolutePosition(0, 25);
            backImg.ScaleToFit(770, 3000);
            backImg.Alignment = iTextSharp.text.Image.UNDERLYING;
            doc.Add(backImg);


            cb.SetTextMatrix(170, 415);
            cb.ShowText(Cognoms.ToUpper() + ", " + Nomparticipant.ToUpper());
            cb.SetTextMatrix(590, 415);
            cb.ShowText(DNI.ToUpper());

        

           
                       
                    cb.SetTextMatrix(200, 280);
                    cb.ShowText(String.Format("{0:dd/MM/yyyy}", datainici));
                    cb.SetTextMatrix(320, 280);
                    cb.ShowText(String.Format("{0:dd/MM/yyyy}", datafi));
                    cb.SetTextMatrix(575, 280);
                    cb.ShowText(hores);
                    cb.SetTextMatrix(285, 260);
                    cb.ShowText(modalitat);
            cb.SetTextMatrix(335, 150);
            cb.ShowText(String.Format("{0:dd/MM/yyyy}", datafi));
           BaseFont bf2 = BaseFont.CreateFont("Montserrat-Bold.otf", BaseFont.CP1252, BaseFont.EMBEDDED);
            Color  groc =Color.FromArgb(254, 188, 73);
            BaseColor grocbf = new BaseColor(groc);
            cb.SetColorFill(grocbf);
            cb.SetFontAndSize(bf2, 35);
            cb.SetTextMatrix(120, 330);
            StringBuilder titolMono = new StringBuilder();
           string pattern = " ";
            int anterior = 0;
            int n = 1;
            foreach (Match match in Regex.Matches(TitolTipusMonografic, pattern))
            {
                Console.WriteLine("Found '{0}' at position {1}, divisio = {2}",
                                  match.Value, match.Index, match.Index / 15);
                titolMono.Append(TitolTipusMonografic.Substring(anterior, match.Index-anterior));
                anterior = match.Index;
                if (match.Index / 25 >=n) {
                    cb.SetTextMatrix(340 - titolMono.Length * 8, 380-35*n);
                    cb.ShowText(titolMono.ToString()); n++;
                    titolMono = new StringBuilder();
                }
            }
            titolMono.Append(TitolTipusMonografic.Substring(anterior, TitolTipusMonografic.Length - anterior));
            cb.SetTextMatrix(340- titolMono.Length*8, 380 - 35 * n);
          cb.ShowText(titolMono.ToString()); n++;
            titolMono.Clear();
            titolMono.Append(TitolTipusMonografic.Substring(anterior, TitolTipusMonografic.Length-anterior -1));
           
           // cb.ShowText(titolMono.ToString());
            cb.SetFontAndSize(bf2, 78);
            cb.SetTextMatrix(70, 470);
            cb.ShowText(datainici.Year.ToString());

            cb.EndText();
            doc.NewPage();
            backImg = iTextSharp.text.Image.GetInstance("CERTIFICADO-CONTRA.png");
            backImg.SetAbsolutePosition(40, 25);
            backImg.ScaleToFit(770, 3000);
            backImg.Alignment = iTextSharp.text.Image.UNDERLYING;
            doc.Add(backImg);
            iTextSharp.text.Font contentFont1 = FontFactory.GetFont(BaseFont.HELVETICA_BOLD, 13);
            iTextSharp.text.Font contentFont2 = FontFactory.GetFont(BaseFont.HELVETICA_BOLD, 11);
            doc.Add(new Paragraph(" ", contentFont1));
            doc.Add(new Paragraph("     MÓDULO TEÓRICO "+PercentatgeTeoric.ToString()+ "%:", contentFont1));
           foreach (ContingutMonografic ContMon in Continguts)
            {
                
                if (ContMon.TipusModul== "MÓDULO TEÓRICO")
                {
                    doc.Add(new Paragraph("          " + ContMon.titol, contentFont2));
                    string[] subtitols=ContMon.subtitols.Split('\n');
                    foreach(string subtitol in subtitols)
                    { if(subtitol!="") doc.Add(new Paragraph("               " + "- " + subtitol, contentFont2)); }
 
                }
            }
            doc.Add(new Paragraph("  "));
            doc.Add(new Paragraph("     MÓDULO PRÀCTICO " + PercentatgePractic.ToString() + "%:",contentFont1));
            foreach (ContingutMonografic ContMon in Continguts)
            {
                if (ContMon.TipusModul == "MÓDULO PRÁCTICO")
                {
                    doc.Add(new Paragraph("          " + ContMon.titol, contentFont2));
                    string[] subtitols = ContMon.subtitols.Split('\n');
                    foreach (string subtitol in subtitols) 
                    { if (subtitol != "") doc.Add(new Paragraph("               " + "- " + subtitol, contentFont2)); }
                }
            }
            //*/
           

           
           
            doc.Close();

        }

        private void dataGridViewDiplomesParticipants_BindingContextChanged(object sender, EventArgs e)
        {
            try
            {
                
                foreach (DataGridViewRow row in dataGridViewDiplomesParticipants.Rows)
                {
                    // 
                    row.Cells["?"].Value = true;

                }
               
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }
        }

        private void dataGridViewDiplomesParticipants_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewDiplomesParticipants.Columns["GenerarDiplomes"].Index)
            {
                GenerarDiploma(comboBoxMonografics.SelectedValue.ToString(), dataGridViewDiplomesParticipants.Rows[e.RowIndex].Cells["ParticipantID"].Value.ToString());
                Process.Start("explorer.exe", Dirpath);
            }
        }

        private void btObrirCarpeta_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtBDirectori.Text)) { txtBDirectori.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); }
            Dirpath = txtBDirectori.Text;
            Process.Start("explorer.exe", Dirpath);
        }

        private void dataGridViewParticipants_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            int selectedRowCount = dataGridViewParticipants.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {

                    try
                    {
                        MySqlConnection conn = mysqlconnect.getmysqlconn();
                        string ParticipantId = dataGridViewParticipants.SelectedRows[i].Cells[0].Value.ToString();

                        FormModificarParticipant formModificar = new FormModificarParticipant(mysqlconnect, ParticipantId);

                        formModificar.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formModificarParticipant_FormClosed);

                        formModificar.Show();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                }
            }
        }

        private void dataGridViewMonografics_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRowCount = dataGridViewMonografics.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {

                    try
                    {
                        MySqlConnection conn = mysqlconnect.getmysqlconn();
                        string MonograficId = dataGridViewMonografics.SelectedRows[i].Cells[0].Value.ToString();

                        FormEditarMonografic editarMonografic = new FormEditarMonografic(mysqlconnect, MonograficId);

                        editarMonografic.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formMonografic_FormClosed);

                        editarMonografic.Show();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                }
            }

        }

        private void dataGridViewParticipantsMonografics_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRowCount = dataGridViewMonografics.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {

                    try
                    {
                        MySqlConnection conn = mysqlconnect.getmysqlconn();
                        string ParticipantId = dataGridViewMonografics.SelectedRows[i].Cells["MonograficID"].Value.ToString();
                        string Titol = dataGridViewMonografics.SelectedRows[i].Cells["Titol"].Value.ToString();
                        string EmpresaID = dataGridViewMonografics.SelectedRows[i].Cells["Empresa"].Value.ToString();
                        FormSeleccionarParticipanst formSeleccionarParticipants = new FormSeleccionarParticipanst(mysqlconnect, ParticipantId, Titol, EmpresaID);

                        formSeleccionarParticipants.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formSeleccionarParticipant_FormClosed);

                        formSeleccionarParticipants.Show();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                }
            }
        }

        private void dataGridViewEmpreses2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


            int selectedRowCount = dataGridViewEmpreses2.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {

                    try
                    {
                        MySqlConnection conn = mysqlconnect.getmysqlconn();
                        string EmpresaId = dataGridViewEmpreses2.SelectedRows[i].Cells[0].Value.ToString();
                        if (EmpresaId != "1")
                        {
                            FormEditarEmpresa formEditarEmpresa = new FormEditarEmpresa(mysqlconnect, EmpresaId);

                            formEditarEmpresa.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formNovaEmpresa_FormClosed);

                            formEditarEmpresa.Show();
                        }
                        else { MessageBox.Show("Aquest registre no es pot editar per seguretat."); }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                }
            }
        }

        private void btParticipantsEmpresa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            FormParticipantsEmpresa formParticipantsEmpresa = new FormParticipantsEmpresa(mysqlconnect);

            formParticipantsEmpresa.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formModificarParticipant_FormClosed);

            formParticipantsEmpresa.Show();
        }

        private void dataGridViewAlumnesEmpresa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btEditorMonograficsTipus_Click(object sender, EventArgs e)
        {

            FormEditordeModelsMonografics formEditorMonografics = new FormEditordeModelsMonografics(mysqlconnect);

           
            formEditorMonografics.Show();
        }

        private void btResetComercialParticulars_Click(object sender, EventArgs e)
        {
            dTPPreferenciainici.Value = new DateTime(2000, 1, 1, 0, 0, 0);
            dTPPreferenciafinal.CustomFormat = " ";
            dTPPreferenciafinal.Format = DateTimePickerFormat.Custom;
            InitializeDataGridViewPersonesComercial();
        }

        private void BtResetComercialEmpreses_Click(object sender, EventArgs e)
        {
            dTPPreferenciainiciEmpresa.Value = new DateTime(2000, 1, 1, 0, 0, 0);
            dTPPreferenciafinalEmpresa.CustomFormat = " ";
            dTPPreferenciafinalEmpresa.Format = DateTimePickerFormat.Custom;
            InitializeDataGridViewEmpresesComercial();
        }

        private void btResetAlumnes_Click(object sender, EventArgs e)
        {
            dTPinici.Value = new DateTime(2000, 1, 1, 0, 0, 0);
            dTPfinal.CustomFormat = " ";
            dTPfinal.Format = DateTimePickerFormat.Custom;
              NOMBOX.Text= "";
           COGNOMSBOX.Text = "";
            TELEFONBOX.Text = "";
           DNIBOX.Text = "";
           CORREUBOX.Text = "";
           comboBoxEmpresa.Text = "";
            InitializeDataGridView();
        }

        private void btResetCursos_Click(object sender, EventArgs e)
        {
           dtpDataCurs1.Value = new DateTime(2000, 1, 1, 0, 0, 0);
            dtpDataCurs2.CustomFormat = " ";
            dtpDataCurs2.Format = DateTimePickerFormat.Custom;
            InitializeDataGridViewTotsElsCursos(); ;
        }

        private void txtBMesCurs_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewTotsElsCursos();
        }

        private void dtpDataCurs1_ValueChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewTotsElsCursos();
        }

        private void dtpDataCurs2_ValueChanged(object sender, EventArgs e)
        {
            dtpDataCurs2.Format = DateTimePickerFormat.Long;
            InitializeDataGridViewTotsElsCursos();
        }

        private void txtBNomMonografic_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewTotsElsMonografics();

        }

        private void btCGNouContacte_Click(object sender, EventArgs e)
        {
            FormAltaComercial form = new FormAltaComercial(mysqlconnect);

            form.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formComercial_FormClosed);

            form.Show();
        }

        private void txtBCGNomEmpresa_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewComercialGeneral();
        }

        private void txtBCGNom_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewComercialGeneral();
        }

        private void txtBCGCognoms_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewComercialGeneral();
        }

        private void txtBCGTelefon_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewComercialGeneral();
        }

        private void txtBCGEmail_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewComercialGeneral();
        }

        private void txtBCGDNI_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewComercialGeneral();
        }

        private void comboBCGTipusContacte_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewComercialGeneral();
        }

        private void comboBCGInformat_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewComercialGeneral();
        }

        private void comboBCGCursInteres_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewComercialGeneral();
        }

        private void dtPCGdataInici_ValueChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewComercialGeneral();
        }

        private void dtPCGdatafi_ValueChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewComercialGeneral();
        }

        private void btCGReset_Click(object sender, EventArgs e)
        {
            dtPCGdatafi.Value = new DateTime(2000, 1, 1, 0, 0, 0);
            dtPCGdataInici.CustomFormat = " ";
            dTPPreferenciainici.Format = DateTimePickerFormat.Custom;
            txtBCGNomEmpresa.Text = "";
            txtBCGNom.Text = "";
            txtBCGCognoms.Text = "";
            txtBCGTelefon.Text = "";
            txtBCGEmail.Text = "";
             comboBCGTipusContacte.Text = "";
            comboBCGInformat.Text = "";
             comboBCGCursInteres.Text = "";
            InitializeDataGridViewPersonesComercial();
        }

        private void btCGEliminarSel_Click(object sender, EventArgs e)
        {
            int selectedRowCount = dataGridViewComercialGeneral.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                var confirmEliminar = MessageBox.Show("Segur que vols eliminar les files seleccionades?",
                    "Confirmació d'Eliminació!",
                    MessageBoxButtons.YesNo);
                if (confirmEliminar == DialogResult.Yes)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();

                    for (int i = 0; i < selectedRowCount; i++)
                    {

                        try
                        {
                            MySqlConnection conn = mysqlconnect.getmysqlconn();
                            string Id = dataGridViewComercialGeneral.SelectedRows[0].Cells[0].Value.ToString();
                            // Se crea un DataTable que almacenará los datos desde donde se cargaran los datos al DataGridView
                            DataTable DtDadesPersonesComercial = new DataTable();
                            // Se crea un MySqlAdapter para obtener los datos de la base



                            string Query = "delete from ComercialGeneral where ComercialID=" + Id + ";";
                            MySqlCommand cmd = new MySqlCommand(Query, conn);
                            MySqlDataReader MyReader2;
                            conn.Open();
                            MyReader2 = cmd.ExecuteReader();     // Here our query will be executed and data saved into the database. 
                            MyReader2.Close();
                            conn.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        InitializeDataGridViewComercialGeneral();


                    }
                }

            }
        }

        private void btCGModSel_Click(object sender, EventArgs e)
        {
            int selectedRowCount = dataGridViewComercialGeneral.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {

                    try
                    {
                        MySqlConnection conn = mysqlconnect.getmysqlconn();
                        string Id = dataGridViewComercialGeneral.SelectedRows[i].Cells[0].Value.ToString();

                        FormModificarComercial formModificar = new FormModificarComercial(mysqlconnect, Id);

                        formModificar.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formComercial_FormClosed);

                        formModificar.Show();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                }
            }
        }

        private void btCGMarcarInformats_Click(object sender, EventArgs e)
        {

            int selectedRowCount = dataGridViewComercialGeneral.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                List<string> ContactesID = new List<string>();
                for (int i = 0; i < selectedRowCount; i++)
                {
                    string Id = dataGridViewComercialGeneral.SelectedRows[i].Cells[0].Value.ToString();
                    ContactesID.Add(Id);
                }
                FormCanviInformat formCanviInformat = new FormCanviInformat(mysqlconnect, ContactesID, "ComercialGeneral", "ComercialID");

                formCanviInformat.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formComercial_FormClosed);

                formCanviInformat.Show();


            }

        }

        private void btCGAltaAlumne_Click(object sender, EventArgs e)
        {
            int selectedRowCount = dataGridViewComercialGeneral.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {

                    try
                    {
                        MySqlConnection conn = mysqlconnect.getmysqlconn();
                        string Id = dataGridViewComercialGeneral.SelectedRows[i].Cells[0].Value.ToString();
                        string Tipus = dataGridViewComercialGeneral.SelectedRows[i].Cells["Tipus contacte"].Value.ToString();
                        var confirm = DialogResult.Yes;
                        if (Tipus!="Particular")
                         confirm = MessageBox.Show("Aquest registre no és un particular.Vols passar-lo com alumne?",
                    "Confirmació",
                    MessageBoxButtons.YesNo);
                        if (confirm == DialogResult.Yes)
                        {
                            FormComercialAltaAlumne form = new FormComercialAltaAlumne(mysqlconnect, Id);

                            form.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formComercialAltaAlumne_FormClosed);

                            form.Show();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                }
            }

        }

        private void btCGAltaEmpresa_Click(object sender, EventArgs e)
        {
            int selectedRowCount = dataGridViewComercialGeneral.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {

                    try
                    {
                        MySqlConnection conn = mysqlconnect.getmysqlconn();
                        string Id = dataGridViewComercialGeneral.SelectedRows[i].Cells[0].Value.ToString();
                        string Tipus = dataGridViewComercialGeneral.SelectedRows[i].Cells["Tipus contacte"].Value.ToString();
                        var confirm = DialogResult.Yes;
                        if (Tipus != "Contacte Empresa")
                            confirm = MessageBox.Show("Aquest registre no és cap representatn d'Empresa.Vols passarIn-lo com Empresa?",
                       "Confirmació",
                       MessageBoxButtons.YesNo);
                        if (confirm == DialogResult.Yes)
                        {
                            FormComercialAltaEmpresa form = new FormComercialAltaEmpresa(mysqlconnect, Id);

                            form.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formEmpresaaComercial_FormClosed);

                            form.Show();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                }
            }
        }

        private void btPassarGeneralParticular_Click(object sender, EventArgs e)
        {

            int selectedRowCount = dataGridViewPersonesComercial.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {

                   
                        MySqlConnection conn = mysqlconnect.getmysqlconn();
                   
                        MySqlCommand cmd = conn.CreateCommand();
                              string PersonaId = dataGridViewPersonesComercial.SelectedRows[i].Cells[0].Value.ToString();
                        cmd.CommandText = "Select PersonaID, Nom,Cognoms,`Curs d'interès`,`Correu electrònic`,`Telèfon`,`Informat`, Comentaris,`Data de preferència`,Mes,`Telèfon Mòbil`"
                            + " from ComercialParticulars where PersonaID= '" + PersonaId + "'";
                        conn.Open();

                        MySqlDataReader reader = cmd.ExecuteReader();
                       
                    string Nom, Cognoms, Cursos, Email, Telefon, Informat, comentaris, mes, mobil;
                    DateTime data;
                            try
                            {
                                reader.Read();
                                    Nom= !reader.IsDBNull(1) ? reader.GetString(1) : null;
                                    Cognoms= !reader.IsDBNull(2) ? reader.GetString(2) : null;
                                    Cursos = !reader.IsDBNull(3) ? reader.GetString(3) : null;
                                    Email = !reader.IsDBNull(4) ? reader.GetString(4) : null;
                                    Telefon= !reader.IsDBNull(5) ? reader.GetString(5) : null;
                                   Informat = !reader.IsDBNull(6) ? reader.GetString(6) : null;
                                    comentaris = !reader.IsDBNull(7) ? reader.GetString(7) : null;
                                   data = !reader.IsDBNull(8) ? reader.GetDateTime(8) : new DateTime();
                                    mes = !reader.IsDBNull(9) ? reader.GetString(9) : null;
                                    mobil = !reader.IsDBNull(10) ? reader.GetString(10) : null;
                                    reader.Close();

                                          string   Query = "INSERT INTO ComercialGeneral(`Tipus contacte`,`Nom Empresa`,`Nom Persona`,Cognoms,`Curs d'interès`,Mes,Informat, `Correu electrònic`,Comentaris,Telèfon,`Telèfon Mòbil`,`Data de preferència` ) "
                              + "VALUES(@Tipuscontacte,@NomEmpresa,@param_Nom,@param_Cognoms,@param_Cursos,@param_mes,@param_Informat,@param_Email,@param_Comentaris,@param_Telefon,@param_TelefonMobil,@DataPrefer);";
                                            cmd = new MySqlCommand(Query, conn);
                                            cmd.Parameters.AddWithValue("@Tipuscontacte", "Particular");
                                            cmd.Parameters.AddWithValue("@NomEmpresa", "");
                                            cmd.Parameters.AddWithValue("@param_Nom", Nom);
                                            cmd.Parameters.AddWithValue("@param_Cognoms", Cognoms);
                                            cmd.Parameters.AddWithValue("@param_Mes", mes);
                                            cmd.Parameters.AddWithValue("@param_Email",Email);
                                            cmd.Parameters.AddWithValue("@param_Telefon", Telefon);
                                            cmd.Parameters.AddWithValue("@param_TelefonMobil",mobil);
                                            cmd.Parameters.AddWithValue("@param_Cursos", Cursos);
                                            cmd.Parameters.AddWithValue("@param_Informat", Informat);
                                            cmd.Parameters.AddWithValue("@param_Comentaris", comentaris);
                                            cmd.Parameters.AddWithValue("@DataPrefer", data);
                     reader = cmd.ExecuteReader(); reader.Close();
                        InitializeDataGridViewComercialGeneral();

                    }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                                finally
                                {

                                    reader.Close();
                                    conn.Close();

                                }


                          



                }
            }
        }

        private void btPassaraGeneralEmpreses_Click(object sender, EventArgs e)
        {
            int selectedRowCount = dataGridViewComercialEmpreses.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {


                    MySqlConnection conn = mysqlconnect.getmysqlconn();

                    MySqlCommand cmd = conn.CreateCommand();
                    string EmpresaId = dataGridViewComercialEmpreses.SelectedRows[i].Cells[0].Value.ToString();
                    cmd.CommandText = "Select EmpresaInteressadaID, `Nom de la empresa`,`Persona de contacte`,`Curs d'interès`,`Correu electrònic`,`Telèfon`,`Informat`, Comentaris,`Data de preferència`,"
                + "`Telèfon Mòbil`,Mes"
                + " from ComercialEmpreses where EmpresaInteressadaID= '" + EmpresaId + "'";
                    conn.Open();

                    MySqlDataReader reader = cmd.ExecuteReader();
                    string NomEmpresa,Nom, Cognoms, Cursos, Email, Telefon, Informat, comentaris, mes, mobil;
                    DateTime data;
                  
                                     
                    try
                    {
                        reader.Read();
                        NomEmpresa = !reader.IsDBNull(1) ? reader.GetString(1) : null;
                        Nom = !reader.IsDBNull(2) ? reader.GetString(2) : null;
                        Cognoms = "";
                        Cursos = !reader.IsDBNull(3) ? reader.GetString(3) : null;
                        Email = !reader.IsDBNull(4) ? reader.GetString(4) : null;
                        Telefon = !reader.IsDBNull(5) ? reader.GetString(5) : null;
                        Informat = !reader.IsDBNull(6) ? reader.GetString(6) : null;
                        comentaris = !reader.IsDBNull(7) ? reader.GetString(7) : null;
                        data = !reader.IsDBNull(8) ? reader.GetDateTime(8) : new DateTime();
                        mobil = !reader.IsDBNull(9) ? reader.GetString(9) : null;
                        mes = !reader.IsDBNull(10) ? reader.GetString(10) : null;
                        
                        reader.Close();

                        string Query = "INSERT INTO ComercialGeneral(`Tipus contacte`,`Nom Empresa`,`Nom Persona`,Cognoms,`Curs d'interès`,Mes,Informat, `Correu electrònic`,Comentaris,Telèfon,`Telèfon Mòbil`,`Data de preferència` ) "
            + "VALUES(@Tipuscontacte,@NomEmpresa,@param_Nom,@param_Cognoms,@param_Cursos,@param_mes,@param_Informat,@param_Email,@param_Comentaris,@param_Telefon,@param_TelefonMobil,@DataPrefer);";
                        cmd = new MySqlCommand(Query, conn);
                        cmd.Parameters.AddWithValue("@Tipuscontacte", "Contacte Empresa");
                        cmd.Parameters.AddWithValue("@NomEmpresa",NomEmpresa);
                        cmd.Parameters.AddWithValue("@param_Nom", Nom);
                        cmd.Parameters.AddWithValue("@param_Cognoms", Cognoms);
                        cmd.Parameters.AddWithValue("@param_Mes", mes);
                        cmd.Parameters.AddWithValue("@param_Email", Email);
                        cmd.Parameters.AddWithValue("@param_Telefon", Telefon);
                        cmd.Parameters.AddWithValue("@param_TelefonMobil", mobil);
                        cmd.Parameters.AddWithValue("@param_Cursos", Cursos);
                        cmd.Parameters.AddWithValue("@param_Informat", Informat);
                        cmd.Parameters.AddWithValue("@param_Comentaris", comentaris);
                        cmd.Parameters.AddWithValue("@DataPrefer", data);

                        reader = cmd.ExecuteReader(); reader.Close();
                        InitializeDataGridViewComercialGeneral();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {

                        reader.Close();
                        conn.Close();

                    }






                }
            }

        }

        private void dataGridViewComercialGeneral_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            int selectedRowCount = dataGridViewComercialGeneral.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {

                    try
                    {
                        MySqlConnection conn = mysqlconnect.getmysqlconn();
                        string Id = dataGridViewComercialGeneral.SelectedRows[i].Cells[0].Value.ToString();

                        FormModificarComercial formModificar = new FormModificarComercial(mysqlconnect, Id);

                        formModificar.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formComercial_FormClosed);

                        formModificar.Show();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int selectedRowCount = dataGridViewParticipantsMonografics.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {

                    try
                    {
                        MySqlConnection conn = mysqlconnect.getmysqlconn();
                        string ParticipantId = dataGridViewParticipantsMonografics.SelectedRows[i].Cells[0].Value.ToString();

                        FormModificarParticipant formModificar = new FormModificarParticipant(mysqlconnect, ParticipantId);

                        formModificar.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formModificarParticipant_FormClosed);

                        formModificar.Show();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                }
            }
        }

        private void EMPRESABOX2_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewEmpreses(dataGridViewEmpreses2, EMPRESABOX2, CONTACTEBOX2);
        }

        private void CONTACTEBOX2_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewEmpreses(dataGridViewEmpreses2, EMPRESABOX2, CONTACTEBOX2);
        }

        private void dataGridViewMonografics_BindingContextChanged(object sender, EventArgs e)
        {
            FormatDataGridViewMonografics();
        }

        private void dataGridViewMonografics_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FormatDataGridViewMonografics();
        }

        private void FormatDataGridViewMonografics()
        {

            if (dataGridViewMonografics.Rows.Count > 0)
            {
                for (int row = 0; row < dataGridViewMonografics.Rows.Count; row++)
                {
                    if (!dataGridViewMonografics.Rows[row].IsNewRow)
                    {/*
                        DateTime date = DateTime.Now;
                        string dtstring = dataGridViewMonografics.Rows[row].Cells[4].Value.ToString();

                        DateTime dtfinalitzacio;
                        DateTime.TryParseExact(dtstring, "dd/MM/yyyy H:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dtfinalitzacio);
                                */

                        bool finalitzat =(bool) dataGridViewMonografics.Rows[row].Cells["Finalitzat"].Value;
                        if (finalitzat) { dataGridViewMonografics.Rows[row].DefaultCellStyle.BackColor = verd; }
                        bool bonificat = (bool)dataGridViewMonografics.Rows[row].Cells["Bonificat"].Value;
                        if (bonificat) { dataGridViewMonografics.Rows[row].Cells["Codi"].Style.BackColor = taronja; }
                       
                    }
                }
            }
        }
        private void FormatDataGridViewCursosGWO()
        {

            if (dataGridViewCursosGWO.Rows.Count > 0)
            {
                for (int row = 0; row < dataGridViewCursosGWO.Rows.Count; row++)
                {
                    if (!dataGridViewCursosGWO.Rows[row].IsNewRow)
                    {
                        bool finalitzat = (bool)dataGridViewCursosGWO.Rows[row].Cells["Finalitzat"].Value;
                        if (finalitzat) { dataGridViewCursosGWO.Rows[row].DefaultCellStyle.BackColor = verd; }

                    }
                }
            }
        }
        private void FormatDataGridViewCursos()
        {

            if (dataGridViewTotselsCursos.Rows.Count > 0)
            {
                for (int row = 0; row < dataGridViewTotselsCursos.Rows.Count; row++)
                {
                    if (!dataGridViewTotselsCursos.Rows[row].IsNewRow)
                    {
                        DateTime date = DateTime.Now;
                        string dtstring = dataGridViewTotselsCursos.Rows[row].Cells[5].Value.ToString();

                        DateTime dtfinalitzacio;
                        DateTime.TryParseExact(dtstring, "dd/MM/yyyy H:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dtfinalitzacio);



                        if (DateTime.Compare(dtfinalitzacio, date) < 0) { dataGridViewTotselsCursos.Rows[row].DefaultCellStyle.BackColor = verd; }

                    }
                }
            }
        }

        private void dataGridViewTotselsCursos_BindingContextChanged(object sender, EventArgs e)
        {
            FormatDataGridViewCursos();
        }

        private void dataGridViewTotselsCursos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FormatDataGridViewCursos();
        }

        private void txtBNomParticip_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewParticipants();
        }

        private void txtBCognomsParticipants_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewParticipants();
        }

        private void txtBDNIParticipants_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewParticipants();
        }

           


        private void btEliminarAlumneGWO_Click(object sender, EventArgs e)
        {




            int selectedRowCount = dataGridViewAlumnesGWO.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                var confirmEliminar = MessageBox.Show("Segur que vols eliminar les files seleccionades?",
                    "Confirmació d'Eliminació!",
                    MessageBoxButtons.YesNo);
                if (confirmEliminar == DialogResult.Yes)
                {





                    System.Text.StringBuilder sb = new System.Text.StringBuilder();

                    for (int i = 0; i < selectedRowCount; i++)
                    {

                        try
                        {
                            MySqlConnection conn = mysqlconnect.getmysqlconn();
                            string AlumneId = dataGridViewAlumnesGWO.SelectedRows[0].Cells[0].Value.ToString();
                            // Se crea un DataTable que almacenará los datos desde donde se cargaran los datos al DataGridView
                            DataTable DtDadesAlumnes = new DataTable();
                            // Se crea un MySqlAdapter para obtener los datos de la base



                            string Query = "delete from Alumnes where AlumneID=" + AlumneId + ";";
                            MySqlCommand cmd = new MySqlCommand(Query, conn);
                            MySqlDataReader MyReader2;
                            conn.Open();
                            MyReader2 = cmd.ExecuteReader();     // Here our query will be executed and data saved into the database. 
                            MyReader2.Close();
                            conn.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        InitializeDataGridViewAlumnes0();
                        InitializeDataGridViewParticipantsSelectorCursos();
                        InitializeDataGridView();
                        InitializeDataGridViewAlumnesGWO();

                    }
                }

            }
        }

        private void btModificarAlumneGWO_Click(object sender, EventArgs e)
        {


            int selectedRowCount = dataGridViewAlumnesGWO.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {

                    try
                    {
                        MySqlConnection conn = mysqlconnect.getmysqlconn();
                        string AlumneId = dataGridViewAlumnesGWO.SelectedRows[i].Cells[0].Value.ToString();

                        FormModificarAlumne formModificar = new FormModificarAlumne(mysqlconnect, AlumneId);

                        formModificar.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formAlumnes_FormClosed);

                        formModificar.Show();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                }
            }

        }

        private void AltaAlumneAGWO_Click(object sender, EventArgs e)
        {

            AltaAlumne formAlta = new AltaAlumne(mysqlconnect,false,true);

            formAlta.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formAlumnes_FormClosed);

            formAlta.Show();
        }

        private void AGWONOM_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewAlumnesGWO();
        }

        private void AGWOCOGNOMS_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewAlumnesGWO();
        }

        private void AGWOTELEFON_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewAlumnesGWO();
        }

        private void AGWOEMAIL_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewAlumnesGWO();
        }

        private void AGWODNI_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewAlumnesGWO();
        }

        private void AGWOEMPRESA_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewAlumnesGWO();
        }

        private void btResetAGWO_Click(object sender, EventArgs e)
        {
           dateTimePicker1AGWO.Value = new DateTime(2000, 1, 1, 0, 0, 0);
            dateTimePicker2AGWO.CustomFormat = " ";
            dateTimePicker2AGWO.Format = DateTimePickerFormat.Custom;
            AGWONOM.Text = "";
            AGWOCOGNOMS.Text = "";
            AGWOTELEFON.Text = "";
            AGWODNI.Text = "";
            AGWOEMAIL.Text = "";
            AGWOEMPRESA.Text = "";
            InitializeDataGridViewAlumnesGWO();
        }

        private void btNouFormador_Click(object sender, EventArgs e)
        {
            FormNouFormador formNouFormador = new FormNouFormador(mysqlconnect);

            formNouFormador.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formFormador_FormClosed);

            formNouFormador.Show();
        }

        private void FormadorNom_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewFormadors();
        }

        private void FormadorCognoms_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewFormadors();
        }

        private void FormadorTelefon_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewFormadors();
        }

        private void btEliminarFormadors_Click(object sender, EventArgs e)
        {


            int selectedRowCount = dataGridViewFormadors.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                var confirmEliminar = MessageBox.Show("Segur que vols eliminar les files seleccionades?",
                    "Confirmació d'Eliminació!",
                    MessageBoxButtons.YesNo);
                if (confirmEliminar == DialogResult.Yes)
                {





                    System.Text.StringBuilder sb = new System.Text.StringBuilder();

                    for (int i = 0; i < selectedRowCount; i++)
                    {

                        try
                        {
                            MySqlConnection conn = mysqlconnect.getmysqlconn();
                            string FormadorId = dataGridViewFormadors.SelectedRows[0].Cells[0].Value.ToString();
                            // Se crea un DataTable que almacenará los datos desde donde se cargaran los datos al DataGridView
                            string Query = "delete from Formadors where FormadorID=" + FormadorId + ";";
                            MySqlCommand cmd = new MySqlCommand(Query, conn);
                            MySqlDataReader MyReader2;
                            conn.Open();
                            MyReader2 = cmd.ExecuteReader();     // Here our query will be executed and data saved into the database. 
                            MyReader2.Close();
                            conn.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        InitializeDataGridViewFormadors();
                        }
                }

            }
        }

        private void btModificarFormador_Click(object sender, EventArgs e)
        {

            int selectedRowCount = dataGridViewFormadors.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {

                    try
                    {
                        MySqlConnection conn = mysqlconnect.getmysqlconn();
                        string formadorId = dataGridViewFormadors.SelectedRows[i].Cells[0].Value.ToString();

                        FormModificarFormador formModificar = new FormModificarFormador(mysqlconnect, formadorId);

                        formModificar.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formFormador_FormClosed);

                        formModificar.Show();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                }
            }
        }

        private void btNouCursGWO_Click(object sender, EventArgs e)
        {
            FormNouCursGWO formNouCursGWO= new FormNouCursGWO(mysqlconnect);

            formNouCursGWO.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formCursGWO_FormClosed);

            formNouCursGWO.Show();
        }

        private void EliminarCursGWO_Click(object sender, EventArgs e)
        {
            int selectedRowCount = dataGridViewCursosGWO.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                var confirmEliminar = MessageBox.Show("Segur que vols eliminar les files seleccionades?",
                    "Confirmació d'Eliminació!",
                    MessageBoxButtons.YesNo);
                if (confirmEliminar == DialogResult.Yes)
                {





                    System.Text.StringBuilder sb = new System.Text.StringBuilder();

                    for (int i = 0; i < selectedRowCount; i++)
                    {

                        try
                        {
                            MySqlConnection conn = mysqlconnect.getmysqlconn();
                            string Id = dataGridViewCursosGWO.SelectedRows[0].Cells[0].Value.ToString();
                            // Se crea un DataTable que almacenará los datos desde donde se cargaran los datos al DataGridView
                            DataTable DtDades = new DataTable();
                            // Se crea un MySqlAdapter para obtener los datos de la base



                            string Query = "delete from CursosGWO where CursGWOID=" + Id + ";";
                            MySqlCommand cmd = new MySqlCommand(Query, conn);
                            MySqlDataReader MyReader2;
                            conn.Open();
                            MyReader2 = cmd.ExecuteReader();     // Here our query will be executed and data saved into the database. 
                            MyReader2.Close();
                            conn.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        InitializeDataGridViewCursosGWO();
                        InitializeDataGridViewAlumnesGWO();

                    }
                }

            }
        }

        private void btEditarCursGWO_Click(object sender, EventArgs e)
        {
            int selectedRowCount = dataGridViewCursosGWO.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {

                    try
                    {
                        MySqlConnection conn = mysqlconnect.getmysqlconn();
                        string Id = dataGridViewCursosGWO.SelectedRows[i].Cells[0].Value.ToString();

                        FormEditarCursGWO formModificar = new FormEditarCursGWO(mysqlconnect, Id);

                        formModificar.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formCursGWO_FormClosed);

                        formModificar.Show();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                }
            }
        }

        private void dataGridViewCursosGWO_BindingContextChanged(object sender, EventArgs e)
        {
            FormatDataGridViewCursosGWO();
        }

        private void dataGridViewCursosGWO_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FormatDataGridViewCursosGWO();
        }

        private void btSeleccionarAlumnesGWO_Click(object sender, EventArgs e)
        {
            int selectedRowCount = dataGridViewCursosGWO.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {

                    try
                    {
                        MySqlConnection conn = mysqlconnect.getmysqlconn();
                        string CursId = dataGridViewCursosGWO.SelectedRows[i].Cells[0].Value.ToString();

                        FormAlumnesGWO formAlumnesGWO = new FormAlumnesGWO(mysqlconnect, CursId);

                        formAlumnesGWO.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formCursGWO_FormClosed);

                        formAlumnesGWO.Show();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                }
            }
        }

        private void dataGridViewCursosGWO_SelectionChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewAlumnesdelCursGWO();
        }

        private void btModificarSeleccionatGWO_Click(object sender, EventArgs e)
        {
            int selectedRowCount = dataGridViewAlumnesCursosGWO.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {

                    try
                    {
                        MySqlConnection conn = mysqlconnect.getmysqlconn();
                        string ParticipantId = dataGridViewAlumnesCursosGWO.SelectedRows[i].Cells[0].Value.ToString();

                        FormModificarAlumne formModificar = new FormModificarAlumne(mysqlconnect, ParticipantId);

                        formModificar.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formAlumnes_FormClosed);

                        formModificar.Show();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                }
            }
        }

        private void textBoxTitolCursGWO_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewCursosGWO();
        }

        private void dataGridViewAlumnesGWO_BindingContextChanged(object sender, EventArgs e)
        {
            FormatDataGridViewAlumnesGWO();
        }

        private void dataGridViewAlumnesGWO_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FormatDataGridViewAlumnesGWO();
        }

        private void dateTimePicker1AGWO_ValueChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewAlumnesGWO();
        }

        private void dateTimePicker2AGWO_ValueChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewAlumnesGWO();
        }

        private void btCursosGWOAlumneSel_Click(object sender, EventArgs e)
        {



            Int32 selectedRowCount =
        dataGridViewAlumnesGWO.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (selectedRowCount > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                for (int i = 0; i < selectedRowCount; i++)
                {
                    string id = dataGridViewAlumnesGWO.SelectedRows[i].Cells[0].Value.ToString();
                    string nom = dataGridViewAlumnesGWO.SelectedRows[i].Cells[1].Value.ToString();
                    string Cognoms = dataGridViewAlumnesGWO.SelectedRows[i].Cells[2].Value.ToString();
                    CursosGWOSeleccionat formCursos = new CursosGWOSeleccionat(mysqlconnect, id, nom, Cognoms);
                    formCursos.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formCursGWO_FormClosed);
                    formCursos.Show();

                }


            }
        }

        private void btEliminarAlumnes0_Click(object sender, EventArgs e)
        {




            int selectedRowCount = dataGridViewAlumnes0.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                var confirmEliminar = MessageBox.Show("Segur que vols eliminar les files seleccionades?",
                    "Confirmació d'Eliminació!",
                    MessageBoxButtons.YesNo);
                if (confirmEliminar == DialogResult.Yes)
                {





                    System.Text.StringBuilder sb = new System.Text.StringBuilder();

                    for (int i = 0; i < selectedRowCount; i++)
                    {

                        try
                        {
                            MySqlConnection conn = mysqlconnect.getmysqlconn();
                            string AlumneId = dataGridViewAlumnes0.SelectedRows[0].Cells[0].Value.ToString();
                            // Se crea un DataTable que almacenará los datos desde donde se cargaran los datos al DataGridView
                            DataTable DtDadesAlumnes = new DataTable();
                            // Se crea un MySqlAdapter para obtener los datos de la base



                            string Query = "delete from Alumnes where AlumneID=" + AlumneId + ";";
                            MySqlCommand cmd = new MySqlCommand(Query, conn);
                            MySqlDataReader MyReader2;
                            conn.Open();
                            MyReader2 = cmd.ExecuteReader();     // Here our query will be executed and data saved into the database. 
                            MyReader2.Close();
                            conn.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        InitializeDataGridViewAlumnes0();
                        InitializeDataGridView();
                        InitializeDataGridViewAlumnesGWO();

                    }
                }

            }
        }

  

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewAlumnes0();
        }

        private void COGNOMSBOX0_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewAlumnes0();
        }

        private void TELEFONBOX0_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewAlumnes0();
        }

        private void comboBoxEmpresa0_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewAlumnes0();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewAlumnes0();
        }

        private void CORREUBOX0_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewAlumnes0();
        }

     

        private void dTPinici0_ValueChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewAlumnes0();
        }

        private void dTPfinal0_ValueChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewAlumnes0();
        }

        private void AltaAlumne0_Click(object sender, EventArgs e)
        {

            AltaAlumne formAlta = new AltaAlumne(mysqlconnect,false,false);

            formAlta.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formAlumnes_FormClosed);

            formAlta.Show();
        }

        private void btModificarAlumnes0_Click(object sender, EventArgs e)
        {

            int selectedRowCount = dataGridViewAlumnes0.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {

                    try
                    {
                        MySqlConnection conn = mysqlconnect.getmysqlconn();
                        string AlumneId = dataGridViewAlumnes0.SelectedRows[i].Cells[0].Value.ToString();

                        FormModificarAlumne formModificar = new FormModificarAlumne(mysqlconnect, AlumneId);

                        formModificar.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formAlumnes_FormClosed);

                        formModificar.Show();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                }
            }

        }

        private void dataGridViewAlumnes0_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btModificarAlumnes0_Click(new object(), new EventArgs());

        }

        private void dataGridViewAlumnesGWO_DoubleClick(object sender, EventArgs e)
        {
            btModificarAlumneGWO_Click(new object(), new EventArgs());
        }

        private void dataGridViewCursosGWO_DoubleClick(object sender, EventArgs e)
        {
            btEditarCursGWO_Click(new object(), new EventArgs());
        }

        private void dataGridViewFormadors_DoubleClick(object sender, EventArgs e)
        {
            btModificarFormador_Click(new object(), new EventArgs());
        }

        private void flowLayoutPanel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btDuplicar_Click(object sender, EventArgs e)
        {
            int selectedRowCount = dataGridViewMonografics.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {

                    try
                    {
                        MySqlConnection conn = mysqlconnect.getmysqlconn();
                        string MonograficId = dataGridViewMonografics.SelectedRows[i].Cells[0].Value.ToString();

                        FormDuplicarMonografic editarMonografic = new FormDuplicarMonografic(mysqlconnect, MonograficId);

                        editarMonografic.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formMonografic_FormClosed);

                        editarMonografic.Show();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                }
            }
        }

        private void dataGridViewAlumnesCursosGWO_DoubleClick(object sender, EventArgs e)
        {
            btModificarSeleccionatGWO_Click(new Object(), new EventArgs());
        }

        private void dataGridViewAlumnesdelCurs_DoubleClick(object sender, EventArgs e)
        {


            int selectedRowCount = dataGridViewAlumnesdelCurs.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {

                    try
                    {
                        MySqlConnection conn = mysqlconnect.getmysqlconn();
                        string AlumneId = dataGridViewAlumnesdelCurs.SelectedRows[i].Cells[0].Value.ToString();

                        FormModificarAlumne formModificar = new FormModificarAlumne(mysqlconnect, AlumneId);

                        formModificar.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formAlumnes_FormClosed);

                        formModificar.Show();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                }
            }

        }

        private void dataGridViewAlumnes_DoubleClick(object sender, EventArgs e)
        {

            int selectedRowCount = dataGridViewAlumnes.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {

                    try
                    {
                        MySqlConnection conn = mysqlconnect.getmysqlconn();
                        string AlumneId = dataGridViewAlumnes.SelectedRows[i].Cells[0].Value.ToString();

                        FormModificarAlumne formModificar = new FormModificarAlumne(mysqlconnect, AlumneId);

                        formModificar.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formAlumnes_FormClosed);

                        formModificar.Show();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                }
            }
        }


        private void btReset0_Click_1(object sender, EventArgs e)
        {

            
            NOMBOX0.Text = "";
            COGNOMSBOX0.Text = "";
            TELEFONBOX0.Text = "";
            DNIBOX0.Text = "";
            CORREUBOX0.Text = "";
            comboBoxEmpresa0.Text = "";
            InitializeDataGridViewAlumnes0();
        }

        private void dTPinici0_ValueChanged_1(object sender, EventArgs e)
        {
            InitializeDataGridViewAlumnes0();
        }

        private void NOMBOX0_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewAlumnes0();
        }

        private void COGNOMSBOX0_TextChanged_1(object sender, EventArgs e)
        {
            InitializeDataGridViewAlumnes0();
        }

        private void TELEFONBOX0_TextChanged_1(object sender, EventArgs e)
        {
            InitializeDataGridViewAlumnes0();
        }

        private void CORREUBOX0_TextChanged_1(object sender, EventArgs e)
        {
            InitializeDataGridViewAlumnes0();
        }

        private void DNIBOX0_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewAlumnes0();
        }

        private void comboBoxEmpresa0_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            InitializeDataGridViewAlumnes0();
        }

        private void NOMBOX2_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewParticipantsSelectorCursos();
        }

        private void COGNOMSBOX2_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewParticipantsSelectorCursos();
        }

        private void CORREUBOX2_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewParticipantsSelectorCursos();
        }

        private void DNIBOX2_TextChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewParticipantsSelectorCursos();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            InitializeDataGridViewParticipantsSelectorCursos();
        }

        private void dataGridViewParticipantsSelectorCursos_SelectionChanged(object sender, EventArgs e)
        {
            InitializeDataGridViewCursosGeneralAlumneSeleccionat();
        }

        private void label87_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewParticipantsSelectorCursos_DoubleClick(object sender, EventArgs e)
        {

            int selectedRowCount = dataGridViewParticipantsSelectorCursos.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {

                    try
                    {
                        MySqlConnection conn = mysqlconnect.getmysqlconn();
                        string AlumneId = dataGridViewParticipantsSelectorCursos.SelectedRows[i].Cells[0].Value.ToString();

                        FormModificarAlumne formModificar = new FormModificarAlumne(mysqlconnect, AlumneId);

                        formModificar.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formAlumnes_FormClosed);

                        formModificar.Show();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                }
            }

        }

        private void dataGridViewCursosGeneral_DoubleClick(object sender, EventArgs e)
        {
            int selectedRowCount = dataGridViewCursosGeneral.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {
                    string Tipus = dataGridViewCursosGeneral.SelectedRows[i].Cells[1].Value.ToString();
                    if (Tipus == "ANETVA")
                    {
                        try
                        {
                            MySqlConnection conn = mysqlconnect.getmysqlconn();
                            string CursId = dataGridViewCursosGeneral.SelectedRows[i].Cells[0].Value.ToString();

                            FormEditarCurs formEditarCurs = new FormEditarCurs(mysqlconnect, CursId);

                            formEditarCurs.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formCursos_FormClosed);

                            formEditarCurs.Show();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }else if (Tipus == "GWO")
                    {
                        try
                        {
                            MySqlConnection conn = mysqlconnect.getmysqlconn();
                            string Id = dataGridViewCursosGeneral.SelectedRows[i].Cells[0].Value.ToString();

                            FormEditarCursGWO formModificar = new FormEditarCursGWO(mysqlconnect, Id);

                            formModificar.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formCursGWO_FormClosed);

                            formModificar.Show();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }



                    }


                }
            }
        }

        private void dataGridViewAlumnes0_DoubleClick(object sender, EventArgs e)
        {
            btModificarAlumnes0_Click(new object(), new EventArgs());
        }

        private void btGenerarContAssit_Click(object sender, EventArgs e)
        {





            string MonograficID = dataGridViewMonografics.SelectedRows[0].Cells[0].Value.ToString();
            List<String[]> llistaparticipants = new List<string[]>();
            String Codi, Titol, Ubicació;
            DateTime datainici, datafi;
            Codi = ""; Titol = ""; Ubicació = "";datainici = new DateTime();datafi = new DateTime();
            MySqlConnection conn = mysqlconnect.getmysqlconn();
            try
                
            {
                DataTable DtDadesCursos = new DataTable();
                string query = "Select Participants.Nom, Participants.Cognoms,Participants.DNI from Participants "
                + "INNER JOIN ParticipantsMonografic ON ParticipantsMonografic.Participant=Participants.ParticipantID "
                + "WHERE ParticipantsMonografic.`Monografic`=?MonograficID  ORDER BY ParticipantID DESC ; ; ";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("?MonograficID", MonograficID);
                conn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();
                
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        String[] participant = { !reader.IsDBNull(0) ? reader.GetString(0) : "", !reader.IsDBNull(1) ? reader.GetString(1) : "", !reader.IsDBNull(2) ? reader.GetString(2) : "" };
                        llistaparticipants.Add(participant);
                    }
                }
                   
 //Monografic
            
                reader.Close();
                cmd = conn.CreateCommand();
                cmd.CommandText = "Select Codi, Titol, Monografics.`Data inici`,Monografics.`Data fi` , Ubicació from Monografics where MonograficID= '" + MonograficID + "'";


                reader = cmd.ExecuteReader();

                reader.Read();

                Codi = !reader.IsDBNull(0) ? reader.GetString(0) : "";
                Titol = !reader.IsDBNull(1) ? reader.GetString(1) : "";
                datainici = !reader.IsDBNull(2) ? reader.GetDateTime(2) : new DateTime();
                datafi = !reader.IsDBNull(3) ? reader.GetDateTime(3) : new DateTime();
                Ubicació = !reader.IsDBNull(4) ? reader.GetString(4) : "";
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

            
            string FitxerModel = "MODEL_CONTROL_ASSISTENCIA.png";
            if (!File.Exists(FitxerModel)) {
                MessageBox.Show("No s'ha trobat el fitxer \"MODEL_CONTROL_ASSISTENCIA.png\" en la carperta d'Acces Vertical Organizer");


            }
            else {
                            try {
                         if (!Directory.Exists(txtBDirAssist.Text)) { txtBDirAssist.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); }
                          String  Dirpath = txtBDirAssist.Text;
                         
                          string nomArxiu = Codi + "_CONTROL_D_ASSISTÈNCIA_AccesVertical_" + Titol;
                            if (nomArxiu.Length > 140) nomArxiu = nomArxiu.Substring(0, 140);
                            string pathString = System.IO.Path.Combine(Dirpath, nomArxiu + ".pdf");

                            FileStream fs = new FileStream(pathString, FileMode.Create, FileAccess.Write, FileShare.None);
                            Document doc = new Document();
                            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                            doc.AddTitle(nomArxiu);
                            doc.AddCreator("Acces Vertical S.L");
                            //doc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
                            doc.Open();
                            // step 4: we grab the ContentByte and do some stuff with it
                            PdfContentByte cb = writer.DirectContent;
                            // we tell the ContentByte we're ready to draw text
                            cb.BeginText();
                            //BaseFont bf = BaseFont.CreateFont(BaseFont., BaseFont.CP1252, BaseFont.EMBEDDED);
                            //cb.SetFontAndSize(bf, 11);
                            BaseFont bf2 = BaseFont.CreateFont("Montserrat-Bold.otf", BaseFont.CP1252, BaseFont.EMBEDDED);
                            cb.SetFontAndSize(bf2, 11);
                            iTextSharp.text.Image backImg = iTextSharp.text.Image.GetInstance(FitxerModel);
                            float pageWidth = doc.PageSize.Width;
                            float pageHeight = doc.PageSize.Height;
                            backImg.SetAbsolutePosition(0, 0);
                            backImg.ScaleToFit(pageWidth, pageHeight);
                            backImg.Alignment = iTextSharp.text.Image.UNDERLYING;
                    TimeSpan ts = datafi - datainici;
                    // Difference in days.
                    int differenceInDays = ts.Days;

                    for (int n = 0; n < ts.Days + 1; n++)
                    {


                        if (n > 0)
                        {
                            cb.EndText();
                            doc.NewPage();
                            cb.BeginText();
                            cb.SetFontAndSize(bf2, 11);
                        }
                        doc.Add(backImg);

                        cb.SetTextMatrix(165, 682);
                        cb.ShowText(Titol.ToUpper());
                        cb.SetTextMatrix(96, 653);
                        DateTime dt = datainici.AddDays(n);
                        cb.ShowText(datainici.ToString("dd/MM/yyyy") + " - " + datafi.ToString("dd/MM/yyyy")+ " ["+dt.ToString("dd/MM/yyyy")+"]");
                        cb.SetTextMatrix(195, 613);
                        cb.ShowText(Ubicació);
                       
                        int[] altures = { 530, 485, 440, 395, 350, 305, 260, 215, 167, 120 };
                        int[] amplades = { 42, 177, 344 };
                        for (int i = 0; i < llistaparticipants.Count; i++)
                        {
                            if (i % 10 == 0 && i != 0)
                            {

                                cb.EndText();
                                doc.NewPage();
                                doc.Add(backImg);
                                cb.BeginText();
                                cb.SetFontAndSize(bf2, 11);

                                cb.SetTextMatrix(165, 682);
                                cb.ShowText(Titol.ToUpper());
                                cb.SetTextMatrix(96, 653);
                                cb.ShowText(datainici.ToString("dd/MM/yyyy") + " - " + datafi.ToString("dd/MM/yyyy") + " [" + dt.ToString("dd/MM/yyyy") + "]");
                                cb.SetTextMatrix(195, 613);
                                cb.ShowText(Ubicació);

                            }
                            cb.SetTextMatrix(amplades[0], altures[i % 10]);
                            cb.ShowText(llistaparticipants[i][0]);
                            cb.SetTextMatrix(amplades[1], altures[i % 10]);
                            cb.ShowText(llistaparticipants[i][1]);
                            cb.SetTextMatrix(amplades[2], altures[i % 10]);
                            cb.ShowText(llistaparticipants[i][2]);
                        }
                    }
                    cb.EndText();
                            doc.Close();
                    MessageBox.Show("S'ha creat el fitxer : \"" + pathString + "\"");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                  //  document.Close();
                    
                }
                         }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtBDirAssist.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtBDirAssist.Text)) { txtBDirAssist.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); }
            Dirpath = txtBDirAssist.Text;
            Process.Start("explorer.exe", Dirpath);
        }

        
    }

}

