using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace XMLintoTxt
{
    

    public partial class Form1 : Form
    {
        private XmlDocument doc;
        private XmlElement root;
        public string PATH = @"C:\temp\Person.xml";


        public Form1()
        {
            InitializeComponent();
        }

        private void btnWritetoXML_Click(object sender, EventArgs e)
        {
            XmlWriter xmlWriter = XmlWriter.Create(PATH);

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Person");

            xmlWriter.WriteStartElement("Name");
            xmlWriter.WriteString(name.Text);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Age");
            xmlWriter.WriteString(age.Text);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Address");
            xmlWriter.WriteString(address.Text);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteEndDocument();

            xmlWriter.Close();
        }

        private void loadXML_Click(object sender, EventArgs e)
        {
            doc = new XmlDocument();
            doc.Load(PATH);
            root = doc.DocumentElement;
            name.Text = root.GetElementsByTagName("Name")[0].InnerText;
            age.Text = root.GetElementsByTagName("Age")[0].InnerText;
            address.Text = root.GetElementsByTagName("Address")[0].InnerText;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.LoadFile(PATH, RichTextBoxStreamType.PlainText);
        }
    }
}
