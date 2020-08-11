using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Extra Libraries needed for code to work.
using System.IO;
using System.Net;

namespace Penguin
{
    public partial class BaseWindow : Form
    {
        public BaseWindow()
        {
            InitializeComponent();
        }

        private void BaseWindow_Load(object sender, EventArgs e)
        {
            // Open a Web Client to grab info from the Penguin API and show said said info in the app.
            using (WebClient webClient = new WebClient())
            {
                using (Stream stream = webClient.OpenRead("http://www.darrelisbae.com/api/v1/penguin/images"))
                {
                    // Set Window Name 
                    this.Text = webClient.ResponseHeaders["Name"].ToString();
                    // Set Image
                    pictureBox.Image = Image.FromStream(stream);
                }
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            // Open a Web Client to grab info from the Penguin API and show said said info in the app.
            using (WebClient webClient = new WebClient())
            {
                using (Stream stream = webClient.OpenRead("http://www.darrelisbae.com/api/v1/penguin/images"))
                {
                    // Set Window Name 
                    this.Text = webClient.ResponseHeaders["Name"].ToString();
                    // Set Image
                    pictureBox.Image = Image.FromStream(stream);
                }
            }
        }
    }
}
