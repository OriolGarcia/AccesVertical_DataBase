using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
namespace AccesVertical_DataBase
{
   

    public class Connexio
    {

        private String URLServidor;
        private uint Port;
        private String UID;
        private String Password;
        private String Database;
        private bool Guardar;
        MySqlConnection mysqlconn;
        MySqlCommand cmd;
        
        public Connexio(String URLServidor, uint Port,
        String UID, String Password, String Database, bool Guardar)
        {
            
            this.URLServidor = URLServidor;
            this.Port = Port;
            this.UID = UID;
            this.Password = Password;
            this.Database = Database;
            this.Guardar = Guardar;
        }


        public MySqlConnection getmysqlconn() {

            return mysqlconn;

        }

        public bool InicialitzarBD() {
            bool connexiocorrecte = false;
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = URLServidor;
            builder.Port = Port;
            builder.UserID = UID;
            builder.Password = Password;
            builder.Database = Database;

            String ConnString = builder.ToString();
            builder = null;
           
            try
            {
                mysqlconn = new MySqlConnection(ConnString);
                mysqlconn.Open();
                connexiocorrecte = true;
                mysqlconn.Close();
            }
            catch (ArgumentException a_ex)
            {
                MessageBox.Show("Error de paràmetres de connexió, revisi el formulari","Missatge informatiu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (MySqlException ex)
            {
                
                connexiocorrecte = false;
                switch (ex.Number)
                {
                    //http://dev.mysql.com/doc/refman/5.0/en/error-messages-server.html
                    case 1042:
                        MessageBox.Show("Error de connexió, revisi l'adreça del servidor i el port", "Missatge informatiu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        break;
                    case 0: // Access denied (Check DB name,username,password)
                        MessageBox.Show("Accés denegat a la Base de dades: "+Database+".\n Revisi l'usuari, el password i el nom de la base de dades.", "Missatge informatiu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    default:
                        break;
                }
            }
            finally
            {
                if (mysqlconn.State == ConnectionState.Open)
                {
                    mysqlconn.Close();
                }
            }
            return connexiocorrecte;

        }
        public bool Check() {
            mysqlconn.Open();
            
            cmd = new MySqlCommand("SHOW TABLES FROM " + Database + ";", mysqlconn);
            List<string> Taules = new List<string>();
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                
                Taules.Add( (!reader.IsDBNull(0) ? reader.GetString(0) : null).ToLower());
             
            }
            mysqlconn.Close();
            reader.Close();
             if ((!Taules.Contains("estatdelcurs")) || (!Taules.Contains("informat")) || (!Taules.Contains("empreses")) 
              ||(!Taules.Contains("alumnes")) || (!Taules.Contains("cursos")) || (!Taules.Contains("tipuscursos")) 
              ||(!Taules.Contains("comercialparticulars")) || (!Taules.Contains("comercialempreses")) || (!Taules.Contains("comercialgeneral")) || (!Taules.Contains("monograficstipus")) 
              || (!Taules.Contains("monografics"))
               || (!Taules.Contains("participants"))|| (!Taules.Contains("estatdelcurs")) || (!Taules.Contains("alumnesmembresdelcurs")) 
               || (!Taules.Contains("participantsmonografic")) || (!Taules.Contains("tipusmodul")) || (!Taules.Contains("contingut"))
                || (!Taules.Contains("contingutsmonografictipus")) || (!Taules.Contains("formadors")) || (!Taules.Contains("cursosgwo")) || (!Taules.Contains("alumnesmembresdelcursgwo")))
                
                return false;
            
            return true;
        }
        public bool CheckminRow( string taula,int min) {
            mysqlconn.Open();

            cmd = new MySqlCommand("SELECT COUNT(*) FROM " + taula +";", mysqlconn);
            int num = Convert.ToInt32(cmd.ExecuteScalar());
            mysqlconn.Close();
            if (num < min) return false;
            return true;



        }

        public bool CheckContent()
        {
            if (!CheckminRow("TipusCursos", 1) || !CheckminRow("Empreses", 4) || !CheckminRow("EstatdelCurs", 5)
                || !CheckminRow("Informat", 4)||!CheckminRow("TipusModul", 2)||!CheckminRow("MonograficsTipus", 1))
                return false;
            else return true;
        }
        public void esborrarContingutTaula(string Taula)
        {


            try
            {
                mysqlconn.Open();

                cmd = new MySqlCommand("DELETE FROM  " + Taula + ";", mysqlconn);
            MySqlDataReader reader = cmd.ExecuteReader();
             reader.Close();
                cmd = new MySqlCommand("ALTER TABLE "+Taula+" AUTO_INCREMENT = 1;", mysqlconn);
                 reader = cmd.ExecuteReader();
                reader.Close();
                mysqlconn.Close();
           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {

                mysqlconn.Close();
            }

        }
        public void ComandMysql( string query)
        {
            try
            {
                mysqlconn.Open();

                cmd = new MySqlCommand(query, mysqlconn);
                List<string> Taules = new List<string>();
                MySqlDataReader reader = cmd.ExecuteReader();
                mysqlconn.Close();
                reader.Close();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);

            }
            finally
            {

                mysqlconn.Close();
            }

        }
        public void FillTables()
        {
            if (!CheckminRow("TipusCursos", 1)) { esborrarContingutTaula("TipusCursos");
                ComandMysql("INSERT INTO TipusCursos (Nom) VALUES(\"\");");
                ComandMysql("INSERT INTO TipusCursos (Nom) VALUES(\"OF. BÀSIC\");");
                ComandMysql("INSERT INTO TipusCursos (Nom) VALUES(\"OF.II\");");
                ComandMysql("INSERT INTO TipusCursos (Nom) VALUES(\"OF.III\");");
                ComandMysql("INSERT INTO TipusCursos (Nom) VALUES(\"Monògràfic\");");
                ComandMysql("INSERT INTO TipusCursos (Nom) VALUES(\"REC. OF. BÀSIC\");");
                ComandMysql("INSERT INTO TipusCursos (Nom) VALUES(\"REC. OF. II\");");
                ComandMysql("INSERT INTO TipusCursos (Nom) VALUES(\"REC. OF. III\");");
                ComandMysql("INSERT INTO TipusCursos (Nom) VALUES(\"EXAMEN OF. BÀSIC\");");
                ComandMysql("INSERT INTO TipusCursos (Nom) VALUES(\"EXAMEN OF. II\");");
                ComandMysql("INSERT INTO TipusCursos (Nom) VALUES(\"EXAMEN OF. III\");");
                ComandMysql("INSERT INTO TipusCursos (Nom) VALUES(\"Altres\");");
            }
            if (!CheckminRow("Empreses", 4))
            {
               
                esborrarContingutTaula("Empreses");

                ComandMysql("INSERT INTO Empreses(Codi, `Nom de la empresa`, Telèfon) VALUES (\"0\",\"\",\"\");");
                ComandMysql("INSERT INTO Empreses(Codi, `Nom de la empresa`, Telèfon) VALUES(\"1\", \"EN ATUR\", \"\");");
                ComandMysql("INSERT INTO Empreses(Codi, `Nom de la empresa`, Telèfon) VALUES(\"2\", \"AUTÒNOM\", \"\");");
                ComandMysql("INSERT INTO Empreses(Codi, `Nom de la empresa`, Telèfon) VALUES (\"3\",\"NOM DE LA EMPRESA DESCONEGUT\",\"\");");
            }
                if (!CheckminRow("EstatdelCurs", 5)) {
               
                esborrarContingutTaula("EstatdelCurs");

                    ComandMysql("INSERT INTO EstatdelCurs(Estat) VALUES (\"No cursat\");");
                    ComandMysql("INSERT INTO EstatdelCurs(Estat) VALUES (\"Cursant\");");
                    ComandMysql("INSERT INTO EstatdelCurs(Estat) VALUES (\"Aprovat\");");
                    ComandMysql("INSERT INTO EstatdelCurs(Estat) VALUES (\"Suspès\");");
                    ComandMysql("INSERT INTO EstatdelCurs(Estat) VALUES (\"Diplomat\");");
                }
            if (!CheckminRow("Informat", 4))
            {
             
                esborrarContingutTaula("Informat");

                ComandMysql("INSERT INTO Informat(Informat) VALUES (\"\");");
                ComandMysql("INSERT INTO Informat(Informat) VALUES (\"No informat\");");
                ComandMysql("INSERT INTO Informat(Informat) VALUES (\"Informat per correu\");");
                ComandMysql("INSERT INTO Informat(Informat) VALUES (\"Informat per telèfon\");");
                ComandMysql("INSERT INTO Informat(Informat) VALUES (\"Informat per Marc\");");
                ComandMysql("INSERT INTO Informat(Informat) VALUES (\"Informat per Esther\");");
            }
            if(!CheckminRow("TipusModul", 2))
            {

                esborrarContingutTaula("TipusModul");

                ComandMysql("INSERT INTO TipusModul(Titol) VALUES (\"MÓDULO TEÓRICO\");");
                ComandMysql("INSERT INTO TipusModul(Titol) VALUES (\"MÓDULO PRÁCTICO\");");
               
            }
            if (!CheckminRow("MonograficsTipus", 1))
            {

                esborrarContingutTaula("MonograficsTipus");

                ComandMysql("INSERT INTO monograficstipus(Titol,PercentatgeTeoric,PercentatgePràctic) VALUES (\"\",20,80)");
            }
            

            }
        public void CreateTables()
        {
            mysqlconn.Open();
            MySqlDataReader MyReader2;

            try
            {


                string Query = "CREATE TABLE IF NOT EXISTS `EstatdelCurs` ("
                         +" `EstatID` INT UNSIGNED NOT NULL AUTO_INCREMENT,"
                            + "`Estat` VARCHAR(25) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,"
                         + "PRIMARY KEY (`EstatID`)"
                         +") ENGINE = INNODB CHARACTER SET utf8 COLLATE utf8_general_ci ; ";
                MySqlCommand cmd = new MySqlCommand(Query, mysqlconn);
                MyReader2 = cmd.ExecuteReader();
                MyReader2.Close();
                Query = "CREATE TABLE IF NOT EXISTS `Informat` ("
                +" `InformatID` INT UNSIGNED NOT NULL AUTO_INCREMENT,"
                +"`Informat` VARCHAR(25) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,"
                +"PRIMARY KEY (`InformatID`)"
                +") ENGINE = INNODB CHARACTER SET utf8 COLLATE utf8_general_ci; ; ";
                cmd = new MySqlCommand(Query, mysqlconn);
                MyReader2 = cmd.ExecuteReader();
                MyReader2.Close();
                Query = "CREATE TABLE IF NOT EXISTS `Empreses` ("
               +" `EmpresaID` INT UNSIGNED NOT NULL AUTO_INCREMENT,"
                +"`Codi` VARCHAR(10) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,"
                +"`Nom de la empresa` VARCHAR(100) CHARACTER SET utf8 COLLATE utf8_general_ci,"
                +"`CIF` VARCHAR(25) CHARACTER SET utf8 COLLATE utf8_general_ci,"
                +"`Persona de contacte` VARCHAR(100) CHARACTER SET utf8 COLLATE utf8_general_ci,"
                +"`Telèfon` VARCHAR(25) CHARACTER SET utf8 COLLATE utf8_general_ci,"
                + "`Telèfon Mòbil` VARCHAR(25) CHARACTER SET utf8 COLLATE utf8_general_ci,"
                 + "`Correu electrònic` varchar(150) CHARACTER SET utf8 COLLATE utf8_general_ci,"
                +"PRIMARY KEY (`EmpresaID`)"
                  +") ENGINE = INNODB CHARACTER SET utf8 COLLATE utf8_general_ci; ";
                cmd = new MySqlCommand(Query, mysqlconn);
                MyReader2 = cmd.ExecuteReader();
                MyReader2.Close();
                Query = "CREATE TABLE IF NOT EXISTS `Alumnes` ("
                    +"`AlumneID` INT UNSIGNED NOT NULL AUTO_INCREMENT,"
                    +"`Nom` VARCHAR(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,"
                    +"`Cognoms` VARCHAR(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,"
                    + " `Comentaris` VARCHAR(1100) CHARACTER SET utf8 COLLATE utf8_general_ci,"
                    + "`DNI` VARCHAR(25) CHARACTER SET utf8 COLLATE utf8_general_ci,"
	                +"`Adreça` VARCHAR(200) CHARACTER SET utf8 COLLATE utf8_general_ci,"
                    +"`Telèfon` VARCHAR(25) CHARACTER SET utf8 COLLATE utf8_general_ci,"
                    + "`Telèfon Mòbil` VARCHAR(25) CHARACTER SET utf8 COLLATE utf8_general_ci,"
                   + " `Correu electrònic` VARCHAR(150) CHARACTER SET utf8 COLLATE utf8_general_ci,"
                   +"`Data d'alta` DATE ,"
	                +"`EmpresaID` INT unsigned,"
                     +"`ID WINDA` varchar(200),"
                     + "`ANETVA` boolean default true,"
                     + " `GWO` boolean default false,"
                    + "foreign key(`EmpresaID`) references Empreses(`EmpresaID`) on delete cascade,"
                    +"PRIMARY KEY (`AlumneID`)"
                    +") ENGINE = INNODB CHARACTER SET utf8 COLLATE utf8_general_ci; ";
                cmd = new MySqlCommand(Query, mysqlconn);
                MyReader2 = cmd.ExecuteReader();
                MyReader2.Close();
                Query = "CREATE TABLE IF NOT EXISTS `Cursos` ("
                +   "`CursID` INT UNSIGNED NOT NULL AUTO_INCREMENT,"
                    + "`Codi` VARCHAR(25) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,"
                    + "`Nom` VARCHAR(100) NOT NULL,"
                    + "`Mes` VARCHAR(300),"
                    + "`Data d'inici` DATE,"
                    +"`Data fi` DATE,"
                        +"`Data de venciment` DATE,"
                   + "PRIMARY KEY (`CursID`)"
                     +") ENGINE = INNODB CHARACTER SET utf8 COLLATE utf8_general_ci;";
                cmd = new MySqlCommand(Query, mysqlconn);
                MyReader2 = cmd.ExecuteReader();
                MyReader2.Close();
                Query = "CREATE TABLE IF NOT EXISTS `TipusCursos` ("
                 +"`TipusCursID` INT UNSIGNED NOT NULL AUTO_INCREMENT,"
                 +" `Nom` VARCHAR(100) NOT NULL,"
                 +" PRIMARY KEY(`TipusCursID`)"
                 +") ENGINE = INNODB CHARACTER SET utf8 COLLATE utf8_general_ci; ";
                cmd = new MySqlCommand(Query, mysqlconn);
                MyReader2 = cmd.ExecuteReader();
                MyReader2.Close();
                MyReader2.Close();
                Query = "CREATE TABLE IF NOT EXISTS `ComercialParticulars` ("
                    +"`PersonaID` INT UNSIGNED NOT NULL AUTO_INCREMENT,"
                    +"`Nom` VARCHAR(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,"
                    +"`Cognoms` VARCHAR(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,"
                    +"`Curs d'interès` INT UNSIGNED NOT NULL,"
                    + " `Mes` VARCHAR(500) CHARACTER SET utf8 COLLATE utf8_general_ci,"
                    + "`Data de preferència` DATE,"
                    + "`Correu electrònic` VARCHAR(150) CHARACTER SET utf8 COLLATE utf8_general_ci,"
                    +"`Comentaris` VARCHAR(1100) CHARACTER SET utf8 COLLATE utf8_general_ci,"
                    +"`Telèfon` VARCHAR(25) CHARACTER SET utf8 COLLATE utf8_general_ci,"
                    + "`Telèfon Mòbil` VARCHAR(25) CHARACTER SET utf8 COLLATE utf8_general_ci,"
                    + "`Informat` INT UNSIGNED NOT NULL,"
                    +"PRIMARY KEY(`PersonaID`),"
                    +"CONSTRAINT `Constr_ComercialParticulars_Informat_fk`"
                      +"  FOREIGN KEY `Informat_fk` (`Informat`) REFERENCES `Informat` (`InformatID`),"
                    +"CONSTRAINT `Constr_PersonesComercial_CursInteres_fk`"
                      +"  FOREIGN KEY `Curs_fk` (`Curs d'interès`) REFERENCES `TipusCursos` (`TipusCursID`)"
                        +"ON DELETE CASCADE ON UPDATE CASCADE"
                        +") ENGINE = INNODB CHARACTER SET utf8 COLLATE utf8_general_ci; ";
                cmd = new MySqlCommand(Query, mysqlconn);
                MyReader2 = cmd.ExecuteReader();
                MyReader2.Close();
                Query = "CREATE TABLE IF NOT EXISTS `ComercialEmpreses` ("
    +"`EmpresaInteressadaID` INT UNSIGNED NOT NULL AUTO_INCREMENT,"
   +"`Nom de la empresa` VARCHAR(100) CHARACTER SET utf8 COLLATE utf8_general_ci,"
    +"`Curs d'interès` INT UNSIGNED NOT NULL,"
    + "`Mes` VARCHAR(500) CHARACTER SET utf8 COLLATE utf8_general_ci,"
    + "`Informat` INT UNSIGNED NOT NULL,"
    + "`Data de preferència` DATE,"
    + "`Persona de contacte` VARCHAR(150) CHARACTER SET utf8 COLLATE utf8_general_ci,"
    +"`Comentaris` VARCHAR(1100) CHARACTER SET utf8 COLLATE utf8_general_ci,"
    +"`Telèfon` VARCHAR(25) CHARACTER SET utf8 COLLATE utf8_general_ci,"
    + "`Telèfon Mòbil` VARCHAR(25) CHARACTER SET utf8 COLLATE utf8_general_ci,"
    + "`Correu electrònic` varchar(150) CHARACTER SET utf8 COLLATE utf8_general_ci,"
    +"PRIMARY KEY (`EmpresaInteressadaID`),"
    +" CONSTRAINT `Constr_ComercialEmpreses_Informat_fk`"
    +"    FOREIGN KEY `Informat_fk` (`Informat`) REFERENCES `Informat` (`InformatID`),"
    +"CONSTRAINT `Constr_EmpresesComercial_CursInteres_fk`"
    + "    FOREIGN KEY `Curs_fk` (`Curs d'interès`) REFERENCES `TipusCursos` (`TipusCursID`)"
    + "    ON DELETE CASCADE ON UPDATE CASCADE"
        +") ENGINE = INNODB CHARACTER SET utf8 COLLATE utf8_general_ci; ";
                cmd = new MySqlCommand(Query, mysqlconn);
                MyReader2 = cmd.ExecuteReader();
                MyReader2.Close();
                Query = " CREATE TABLE IF NOT EXISTS `ComercialGeneral` ("
                    +" `ComercialID` INT UNSIGNED NOT NULL AUTO_INCREMENT,"
	                +" `Tipus contacte` VARCHAR(100) CHARACTER SET utf8 COLLATE utf8_general_ci,"
                    +" `Nom Empresa` VARCHAR(100) CHARACTER SET utf8 COLLATE utf8_general_ci,"
                    +" `Nom Persona` VARCHAR(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,"
                    +" `Cognoms` VARCHAR(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,"
                    +" `Curs d'interès` INT UNSIGNED NOT NULL,"
                    +" `Mes` VARCHAR(500) CHARACTER SET utf8 COLLATE utf8_general_ci,"
                    +" `Informat` INT UNSIGNED NOT NULL,"
                    +" `Data de preferència` DATE,"
                    +" `Comentaris` VARCHAR(1100) CHARACTER SET utf8 COLLATE utf8_general_ci,"
                    +" `Telèfon` VARCHAR(25) CHARACTER SET utf8 COLLATE utf8_general_ci,"
	                +" `Telèfon Mòbil` VARCHAR(25) CHARACTER SET utf8 COLLATE utf8_general_ci,"
                     +" `Correu electrònic` varchar(150) CHARACTER SET utf8 COLLATE utf8_general_ci,"
                    +" PRIMARY KEY (`ComercialID`),"
                     +" CONSTRAINT `Constr_ComercialGeneral_Informat_fk`"
                        +" FOREIGN KEY `Informat_fk` (`Informat`) REFERENCES `Informat` (`InformatID`),"
                    +" CONSTRAINT `Constr_ComercialGeneral_CursInteres_fk`"
                        +" FOREIGN KEY `Curs_fk` (`Curs d'interès`) REFERENCES `TipusCursos` (`TipusCursID`)"
                        +" ON DELETE CASCADE ON UPDATE CASCADE"
                +" ) ENGINE = INNODB CHARACTER SET utf8 COLLATE utf8_general_ci; ";
                cmd = new MySqlCommand(Query, mysqlconn);
                MyReader2 = cmd.ExecuteReader();
                MyReader2.Close();
                Query = "CREATE TABLE IF NOT EXISTS `MonograficsTipus` ("
		    +" `MonograficTipusID` INT UNSIGNED NOT NULL AUTO_INCREMENT,"
            + " `Titol` VARCHAR(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,"
                +" `PercentatgeTeoric` INT UNSIGNED NOT NULL,"
            + " `PercentatgePràctic` INT UNSIGNED NOT NULL,"
                + " PRIMARY KEY(`MonograficTipusID`)"
            +" ) ENGINE = INNODB CHARACTER SET utf8 COLLATE utf8_general_ci; ";
                cmd = new MySqlCommand(Query, mysqlconn);
                MyReader2 = cmd.ExecuteReader();
                MyReader2.Close();
                Query = "CREATE TABLE IF NOT EXISTS `Monografics` ("
                  +  " `MonograficID` INT UNSIGNED NOT NULL AUTO_INCREMENT,"
                  +  " `Codi` VARCHAR(25) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,"
                  +  " `Titol` VARCHAR(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,"
                   + " `Codi AF` VARCHAR(100) CHARACTER SET utf8 COLLATE utf8_general_ci,"
                  +  " `Grup` VARCHAR(100) CHARACTER SET utf8 COLLATE utf8_general_ci,"
                   + " `Data inici` DATE,"
                   + " `Data fi` DATE,"
	                +" `Duració en hores` INT UNSIGNED NOT NULL,"
                   + " `Horari` VARCHAR(200) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,"
                   + " `Modalitat` VARCHAR(25) CHARACTER SET utf8 COLLATE utf8_general_ci,"
                   + " `MonograficTipus` INT UNSIGNED NOT NULL,"
                   + " `Empresa` INT UNSIGNED NOT NULL,"
                   + "`Ubicació` VARCHAR(100) ,"
                   + "`Finalitzat` boolean default false,"
                   + "`Bonificat` boolean default false,"
                   + " PRIMARY KEY(`MonograficID`),"
                   + " CONSTRAINT `Constr_Monografics_MonograficTipus_fk`"
                      +  " FOREIGN KEY `MonograficTipus_fk` (`MonograficTipus`) REFERENCES `MonograficsTipus` (`MonograficTipusID`),"
	                +" CONSTRAINT `Constr_Monografics_Empresa_fk`"
                      +  " FOREIGN KEY `Empresa_fk` (`Empresa`) REFERENCES `Empreses` (`EmpresaID`)"
                +" ) ENGINE = INNODB CHARACTER SET utf8 COLLATE utf8_general_ci; ";
                cmd = new MySqlCommand(Query, mysqlconn);
                MyReader2 = cmd.ExecuteReader();
                MyReader2.Close();
                Query = "CREATE TABLE IF NOT EXISTS `Participants` ("
              +  " `ParticipantID` INT UNSIGNED NOT NULL AUTO_INCREMENT,"
              +  " `Nom` VARCHAR(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,"
              +  " `Cognoms` VARCHAR(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,"
	          +  " `DNI` VARCHAR(25) CHARACTER SET utf8 COLLATE utf8_general_ci,"
	          +  " `EmpresaID` INT unsigned,"
              +  " foreign key(`EmpresaID`) references Empreses(`EmpresaID`) on delete cascade,"
              +   " PRIMARY KEY (`ParticipantID`)"
          +  " ) ENGINE = INNODB CHARACTER SET utf8 COLLATE utf8_general_ci; ";
                cmd = new MySqlCommand(Query, mysqlconn);
                MyReader2 = cmd.ExecuteReader();
                MyReader2.Close();
                Query = "CREATE TABLE IF NOT EXISTS `EstatdelCurs` ("
                  +"`EstatID` INT UNSIGNED NOT NULL AUTO_INCREMENT,"
                 +"`Estat` VARCHAR(25) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,"
                +"PRIMARY KEY (`EstatID`)"
                +") ENGINE = INNODB CHARACTER SET utf8 COLLATE utf8_general_ci; ";
                cmd = new MySqlCommand(Query, mysqlconn);
                MyReader2 = cmd.ExecuteReader();
                MyReader2.Close();
                Query = "CREATE TABLE IF NOT EXISTS `AlumnesMembresDelCurs` ("
               +" `Alumne` INT UNSIGNED NOT NULL,"
               +" `Curs` INT UNSIGNED NOT NULL,"
               +" `Estat`INT UNSIGNED NOT NULL,"
               +" PRIMARY KEY(`Alumne`, `Curs`),"
                +"CONSTRAINT `Constr_AlumnesMembresDelCurs_Alumne_fk`"
                  +"  FOREIGN KEY `Alumne_fk` (`Alumne`) REFERENCES `Alumnes` (`AlumneID`)"
                   +" ON DELETE CASCADE ON UPDATE CASCADE,"
                +"CONSTRAINT `Constr_AlumnesMembresDelCurs_Course_fk`"
                +"FOREIGN KEY `Curs_fk` (`Curs`) REFERENCES `Cursos` (`CursID`)"
                 +"   ON DELETE CASCADE ON UPDATE CASCADE,"
                 +"CONSTRAINT `Constr_AlumnesMembresDelCurs_Estat_fk`"
                   +" FOREIGN KEY `Estat_fk` (`Estat`) REFERENCES `EstatdelCurs` (`EstatID`)"
                    +"ON DELETE CASCADE ON UPDATE CASCADE"
                +") ENGINE = INNODB CHARACTER SET utf8 COLLATE utf8_general_ci; ";
                cmd = new MySqlCommand(Query, mysqlconn);
                MyReader2 = cmd.ExecuteReader();
                MyReader2.Close();
                Query = "CREATE TABLE IF NOT EXISTS `ParticipantsMonografic` ("
                     + " `Participant` INT UNSIGNED NOT NULL,"
                +" `Monografic` INT UNSIGNED NOT NULL,"
                +" PRIMARY KEY(`PArticipant`, `Monografic`),"
                +" CONSTRAINT `Constr_PsrticipantsMonografic_Alumne_fk`"
                   +" FOREIGN KEY `Participant_fk` (`Participant`) REFERENCES `Participants` (`ParticipantID`)"
                +" ON DELETE CASCADE ON UPDATE CASCADE,"
                +" CONSTRAINT `Constr_ParticipantsMonografic_Monografic_fk`"
                +" FOREIGN KEY `Monografic_fk` (`Monografic`) REFERENCES `Monografics` (`MonograficID`)"
                +" ON DELETE CASCADE ON UPDATE CASCADE"
                +" ) ENGINE = INNODB CHARACTER SET utf8 COLLATE utf8_general_ci; ";
                cmd = new MySqlCommand(Query, mysqlconn);
                MyReader2 = cmd.ExecuteReader();
                MyReader2.Close();
                Query = "CREATE TABLE IF NOT EXISTS `TipusModul` ("
                + " `TipusModulID` INT UNSIGNED NOT NULL AUTO_INCREMENT,"
            + " `Titol` VARCHAR(400) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,"
            +  " PRIMARY KEY (`TipusModulID`)"
            +" ) ENGINE = INNODB CHARACTER SET utf8 COLLATE utf8_general_ci; ";
                cmd = new MySqlCommand(Query, mysqlconn);
                MyReader2 = cmd.ExecuteReader();
                MyReader2.Close();
                                Query = "CREATE TABLE IF NOT EXISTS `Contingut` ("
                   + " `ContingutID` INT UNSIGNED NOT NULL AUTO_INCREMENT,"
                    +" `Titol` VARCHAR(400) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,"
                    +" `Subtitols` VARCHAR(1000) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,"
                    +" `Tipus de modul`INT UNSIGNED NOT NULL,"
                   + " PRIMARY KEY(`ContingutID`),"
                   + " CONSTRAINT `Constr_TipusModult_fk`"
                    +    " FOREIGN KEY `Tipus_fk` (`Tipus de modul`) REFERENCES `TipusModul` (`TipusModulID`)"
                     +    " ON DELETE CASCADE ON UPDATE CASCADE"
                +" ) ENGINE = INNODB CHARACTER SET utf8 COLLATE utf8_general_ci; ";
                cmd = new MySqlCommand(Query, mysqlconn);
                MyReader2 = cmd.ExecuteReader();
                MyReader2.Close();
                    Query = "CREATE TABLE IF NOT EXISTS `ContingutsMonograficTipus` ("
               + " `Contingut` INT UNSIGNED NOT NULL,"
              +  " `MonograficTipus` INT UNSIGNED NOT NULL,"
               + " PRIMARY KEY(`Contingut`, `MonograficTipus`),"
               + " CONSTRAINT `Constr_ContingutMonografic_Contingut_fk`"
                +    " FOREIGN KEY `Contingut_fk` (`Contingut`) REFERENCES `Contingut` (`ContingutID`)"
                +    " ON DELETE CASCADE ON UPDATE CASCADE,"
                +" CONSTRAINT `Constr_ContingutMonografic_Monografic_fk`"
               +     " FOREIGN KEY `Monografic_fk` (`MonograficTipus`) REFERENCES `MonograficsTipus` (`MonograficTipusID`)"
                 +   " ON DELETE CASCADE ON UPDATE CASCADE"
           + " ) ENGINE = INNODB CHARACTER SET utf8 COLLATE utf8_general_ci; ";
                    cmd = new MySqlCommand(Query, mysqlconn);
                    MyReader2 = cmd.ExecuteReader();
                     MyReader2.Close();
                Query = "CREATE TABLE IF NOT EXISTS `Formadors` ("
                    +" `FormadorID` INT UNSIGNED NOT NULL AUTO_INCREMENT,"
	                +"`Nom` VARCHAR(100)  NOT NULL,"
                    +" `Cognoms` VARCHAR(100)  NOT NULL,"
                    +"`Comentaris` VARCHAR(1100),"
	                +"`DNI` VARCHAR(25) ,"
	                +"`Adreça` VARCHAR(200) ,"
                    +" `Telèfon` VARCHAR(25) ,"
	                +"`Telèfon Mòbil` VARCHAR(25) ,"
                    +" PRIMARY KEY(`FormadorID`)"
                     +") ENGINE = INNODB CHARACTER SET utf8 COLLATE utf8_general_ci; ";
                cmd = new MySqlCommand(Query, mysqlconn);
                MyReader2 = cmd.ExecuteReader();
                MyReader2.Close();


                Query = "CREATE TABLE IF NOT EXISTS `CursosGWO` ("
                +" `CursGWOID` INT UNSIGNED NOT NULL AUTO_INCREMENT,"
                   +"`Codi Curs GWO` VARCHAR(25) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,"
                +" `Titol` VARCHAR(100) NOT NULL,"
                +" `Mes` VARCHAR(300),"
                +"`Data d'inici` DATE,"
                +"`Data fi` DATE,"
                +"`Data de venciment` DATE,"
                +"`Duració en hores` INT UNSIGNED NOT NULL,"
                +"`Horari` VARCHAR(200) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,"
                    +" `Empresa` INT UNSIGNED NOT NULL,"
                    +" `Formador` INT UNSIGNED NOT NULL,"
                +"`Ubicació` VARCHAR(100) ,"
              +  " `Pais` VARCHAR(100) ,"
              +  "  `Finalitzat` boolean default false,"
                +"  PRIMARY KEY(`CursGWOID`),"
                +" CONSTRAINT `Constr_CursosGWO_Empresa_fk`"
                +"  FOREIGN KEY `Empresa_fk` (`Empresa`) REFERENCES `Empreses` (`EmpresaID`),"
                +"  CONSTRAINT `Constr_CursosGWO_Formador_fk` "
                +" FOREIGN KEY `Formador_fk` (`Formador`) REFERENCES `Formadors` (`FormadorID`)"
                +") ENGINE = INNODB CHARACTER SET utf8 COLLATE utf8_general_ci; ";
                cmd = new MySqlCommand(Query, mysqlconn);
                MyReader2 = cmd.ExecuteReader();
                MyReader2.Close();

                Query = "CREATE TABLE IF NOT EXISTS `AlumnesMembresDelCursGWO` ("
                    +  "  `Alumne` INT UNSIGNED NOT NULL,"
                +"  `CursGWO` INT UNSIGNED NOT NULL,"
                +"  `Estat`INT UNSIGNED NOT NULL,"
                +"  PRIMARY KEY(`Alumne`, `CursGWO`),"
                +"CONSTRAINT `Constr_AlumnesMembresDelCursGWO_Alumne_fk`"
                +"FOREIGN KEY `Alumne_fk` (`Alumne`) REFERENCES `Alumnes` (`AlumneID`)" 
                +"ON DELETE CASCADE ON UPDATE CASCADE,"
                +" CONSTRAINT `Constr_AlumnesMembresDelCursGWO_Course_fk`"
                +" FOREIGN KEY `Curs_fk` (`CursGWO`) REFERENCES `CursosGWO` (`CursGWOID`)"
                +"  ON DELETE CASCADE ON UPDATE CASCADE,"
                +"   CONSTRAINT `Constr_AlumnesMembresDelCursGWO_Estat_fk`"
                +"FOREIGN KEY `Estat_fk` (`Estat`) REFERENCES `EstatdelCurs` (`EstatID`)"
                +" ON DELETE CASCADE ON UPDATE CASCADE" 
                +") ENGINE = INNODB CHARACTER SET utf8 COLLATE utf8_general_ci; ";
                cmd = new MySqlCommand(Query, mysqlconn);
                MyReader2 = cmd.ExecuteReader();
                MyReader2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {

              mysqlconn.Close();
            }
        }
        public void CreateDataBase(String DB) {
            try
            {
                 mysqlconn.Open();
                cmd = new MySqlCommand("CREATE DATABASE "+DB+";", mysqlconn);
                cmd.ExecuteNonQuery();
                mysqlconn.Close();
            }
            catch (Exception e)
            {

                MessageBox.Show("Hi ha hagut el següent error: " + e.ToString(), "Missatge informatiu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
 }}



    }
}
