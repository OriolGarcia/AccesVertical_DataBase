using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace AccesVertical_DataBase
{
    public partial class FormConnexio : Form
    {

       

        public FormConnexio()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Width = 452;
            this.Height = 247;
            this.StartPosition = FormStartPosition.CenterScreen;

            XmlDocument xmlDoc = new XmlDocument();
            if (File.Exists("AccesVerticalBD_info.xml"))
            {
                xmlDoc.Load("AccesVerticalBD_info.xml");
                XmlNodeList propitetats = xmlDoc.GetElementsByTagName("PropietatsdeConexió");
                XmlElement URL = (XmlElement)((XmlElement)propitetats[0]).GetElementsByTagName("URL")[0];
                XmlElement port = (XmlElement)((XmlElement)propitetats[0]).GetElementsByTagName("port")[0];
                XmlElement usuari = (XmlElement)((XmlElement)propitetats[0]).GetElementsByTagName("usuari")[0];
                XmlElement BasedeDades = (XmlElement)((XmlElement)propitetats[0]).GetElementsByTagName("BasedeDades")[0];
                txtBURL.Text = URL.InnerText;
                txtport.Text = port.InnerText;
                txtUser.Text = usuari.InnerText;
                txtBD.Text = BasedeDades.InnerText;
                XmlNode root = xmlDoc.FirstChild;



            }


            

        }
       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

     

        private void btAcceptar_Click(object sender, EventArgs e)
        {
            // this.Close();
            uint port;
            if (uint.TryParse(txtport.Text, out port)&& !string.IsNullOrEmpty(txtBD.Text)) { 
                
            Connexio connect = new Connexio(txtBURL.Text,port,txtUser.Text,txtPassword.Text,txtBD.Text, ChkBGuardar.Checked);
                if (connect.InicialitzarBD())
                {
                    
                    if (ChkBGuardar.Checked)
                    {
                        try
                        {
                            XmlWriter xmlWriter = XmlWriter.Create("AccesVerticalBD_info.xml");
                            xmlWriter.WriteStartDocument();
                            xmlWriter.WriteStartElement("PropietatsdeConexió");
                            xmlWriter.WriteStartElement("URL");
                            xmlWriter.WriteString(txtBURL.Text);
                            xmlWriter.WriteEndElement();

                            xmlWriter.WriteStartElement("port");
                            xmlWriter.WriteString(txtport.Text);
                            xmlWriter.WriteEndElement();


                            xmlWriter.WriteStartElement("usuari");
                            xmlWriter.WriteString(txtUser.Text);
                            xmlWriter.WriteEndElement();

                            xmlWriter.WriteStartElement("BasedeDades");
                            xmlWriter.WriteString(txtBD.Text);
                            xmlWriter.WriteEndDocument();

                            xmlWriter.Close();
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.Message);

                        }

                    }

                    if (!connect.Check()) {
                        var confirmCrearTaules = MessageBox.Show("No s'han trobat  totes les taules necessàries. Vols crear-les ara?",
                             "Taules no verificades!",
                              MessageBoxButtons.YesNo);
                        if (confirmCrearTaules == DialogResult.Yes)
                            connect.CreateTables();

                        }

                    if (connect.Check()&&!connect.CheckContent())
                    {
                        var confirmOmplirTaules = MessageBox.Show("No s'han trobat contingut necessari dins d'algunes taules. Vols omplir-les ara?",
                             "Taules no verificades!",
                              MessageBoxButtons.YesNo);
                        if (confirmOmplirTaules == DialogResult.Yes)
                            connect.FillTables();

                    }





                    FormPrincipal f1 = new FormPrincipal(connect);
                    f1.Show();
                  
                        
                


                    Visible = false;
                }
            }else {if (string.IsNullOrEmpty(txtBD.Text))
                {

                    MessageBox.Show("El paràmetre de la base de dades està buit", "Missatge informatiu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("El paràmetre del port no és vàlid. Escriu un port vàlid", "Missatge informatiu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }  }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ChkBGuardar_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
