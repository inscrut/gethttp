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

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            URL = textBox1.Text;
            textBox2.Text = textBox2.Text + URL + "\r\n";
            textBox2.Text = textBox2.Text + req(URL) +"\r\n\r\n";
        }

        public string req(string url)
        {
            HttpWebRequest myHttpWebRequest = (HttpWebRequest) WebRequest.Create(url);
            myHttpWebRequest.UserAgent = "C# Client";

            HttpWebResponse myHttpResp = (HttpWebResponse)myHttpWebRequest.GetResponse();

            Stream streamResp = myHttpResp.GetResponseStream();
            StreamReader strRead = new StreamReader(streamResp);

            string responseFromServer = strRead.ReadToEnd();

            strRead.Close();
            streamResp.Close();
            myHttpResp.Close();

            return responseFromServer;
        }
    }
}
