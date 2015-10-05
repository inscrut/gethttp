using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;

namespace GET_HTTP
{
    public partial class Form1 : Form
    {
        public string URL = "http://vk.com/";
        public string ans = "";
        public string responseFromServer = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            URL = textBox1.Text;
            textBox2.Text = textBox2.Text + URL + "\r\n";

            req();

            textBox2.Text = textBox2.Text + responseFromServer + "\r\n\r\n";
        }

        public void req()
        {
            WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(URL);

            Stream objStream;
            objStream = wrGETURL.GetResponse().GetResponseStream();

            StreamReader objReader = new StreamReader(objStream);
            responseFromServer = objReader.ReadToEnd();

            objReader.Close();
        }
    }
}
