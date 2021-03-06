﻿using System;
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

            // Grab icon from API
            using (WebClient webClient = new WebClient())
            {
                // Set Headers
                webClient.Headers.Set("User-Agent", "Penguin");
                webClient.Headers.Set("Referer", string.Format("Computer :: {0} | User :: {1}", Environment.MachineName, Environment.UserName));
                using (Stream stream = webClient.OpenRead("https://www.darrelisbae.com/api/v1/penguin/icon"))
                {
                    // Push data stream into a memory stream array becuase Icon complains with just a datastream :/
                    using (var memoryStream = new MemoryStream())
                    {
                        stream.CopyTo(memoryStream);
                        using (MemoryStream ms = new MemoryStream(memoryStream.ToArray()))
                        {
                            this.Icon = new Icon(ms);
                        }
                    }
                }
            }
        }

        private void BaseWindow_Load(object sender, EventArgs e)
        {
            // Open a Web Client to grab info from the Penguin API and show said said info in the app.
            using (WebClient webClient = new WebClient())
            {
                // Set Headers
                webClient.Headers.Set("User-Agent", "Penguin");
                webClient.Headers.Set("Referer", string.Format("Computer :: {0} | User :: {1}", Environment.MachineName, Environment.UserName));
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
                // Set Headers
                webClient.Headers.Set("User-Agent", "Penguin");
                webClient.Headers.Set("Referer", string.Format("Computer :: {0} | User :: {1}", Environment.MachineName, Environment.UserName));
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
