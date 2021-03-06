﻿using System;
using System.IO;
using System.IO.Ports;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Sockets;

namespace GUI
{
    public partial class Form1 : Form
    {
        string folderpath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\NixieTubeController\\";
        string ConfigText;
        string[] COM;
        string[] baud;
        string[] enabledData;
        Int32 reloadConfig = 0;
        Dictionary<string, Label> kamel;

        public Form1()
        {
            InitializeComponent();
            

            kamel = new Dictionary<string, Label>();
            foreach (Control c in Controls)
            {
                if (c is Label)
                {
                    kamel.Add(c.Name, (Label)c);
                }
            }

            string[] baudrate = new string[] { "300", "1200", "2400", "4800", "9600", "14400", "19200", "28800", "30400", "38400", "57600", "115200" };
            Baud_box.Items.AddRange(baudrate);
            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {
                ComBox.Items.Add(s);
            }
            ComBox.Items.Add("DebugPort");

            bool exists = System.IO.File.Exists(folderpath + "settings.conf");
            if (exists)
            {
                ConfigText = System.IO.File.ReadAllText(folderpath + "settings.conf");
                string pattern = @"\n";
                string[] config = Regex.Split(ConfigText, pattern);
                COM = config[0].Split(new char[0]); //Split on space com_name || COM1
                baud = config[1].Split(new char[0]);//Split on space Baud_rate || 300
                enabledData = config[2].Split(new char[0]);
                foreach (Control c in Controls)
                {
                    if (c is CheckBox)
                    {
                        CheckBox cb = (CheckBox)c;
                        cb.Checked = enabledData.Contains(cb.Text);
                    }
                }

                //LOAD INFO FROM FILE TO PROGRAM
                ComBox.SelectedItem = COM[1]; //
                Baud_box.SelectedItem = baud[1];
            }

            new System.Threading.Thread(() => {
                System.Threading.Thread.CurrentThread.IsBackground = true;
                this.HandleNetwork();
            }).Start();
        }

        private void Ext_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Select_btn_Click(object sender, EventArgs e)
        {
            foreach (Control c in Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox cb = (CheckBox)c;
                    if (cb.Checked == false)
                    {
                        cb.Checked = true;
                    }
                    else
                    {
                        cb.Checked = false;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Control c in Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox cb = (CheckBox)c;
                    cb.Checked = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ComBox.SelectedItem != null && Baud_box.SelectedItem != null)
            {
                bool exists = System.IO.Directory.Exists(folderpath);
                if (!exists)
                    System.IO.Directory.CreateDirectory(folderpath);

                string text = "com_name " + ComBox.SelectedItem.ToString() + "\n" +
                    "com_baud " + Baud_box.SelectedItem.ToString() + "\n" + "properties ";
                foreach (Control c in Controls)
                {
                    if (c is CheckBox)
                    {
                        CheckBox cb = (CheckBox)c;
                        if (cb.Checked == true)
                        {
                            text += cb.Text.ToString() + " ";
                        }
                    }
                }
                System.IO.File.WriteAllText(@folderpath + "settings.conf", text);
                reloadConfig = 1;
            }
            else
            {
                MessageBox.Show("No COM Port or Baudrate selected");
            }

        }

        public void DisplayData(string incommingData)
        {

            string pattern = @"\n";
            string[] results = Regex.Split(incommingData, pattern);

            foreach (var elem in results)
            {
                string[] result = elem.Split(new char[0]);
                string name = result[0];
                if (name.Length == 0)
                    continue;
                name += "_result";
                if (!kamel.ContainsKey(name))
                    throw new System.ArgumentException("felaktig label");
                string value = result[1];
                kamel[name].Invoke((MethodInvoker)delegate{
                    kamel[name].Text = value;
                });

            }

        }

        void HandleNetwork()
        {
            const int PORT = 12345;

            byte[] buffer = new byte[1024];

            while (true)
            {
                try
                {
                    var ip = IPAddress.Loopback;
                    Socket socket = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    IPEndPoint server = new IPEndPoint(ip, PORT);

                    try
                    {
                        socket.Connect(server);

                        Console.WriteLine("Connected to deamon");

                        while (true)
                        {
                            bool reload_config = System.Threading.Interlocked.CompareExchange(ref this.reloadConfig, 0, 1) == 1;//TODO: Check me!!!
                            while (socket.Send(new byte[1] { reload_config ? (byte)1 : (byte)0 }) != 1)
                            {
                                Console.WriteLine("Failed to send to server");
                            };

                            int bytes_recieved = socket.Receive(buffer);

                            string recieved_result = Encoding.ASCII.GetString(buffer, 0, bytes_recieved);
                            DisplayData(recieved_result);
                        }

                    }
                    catch (SocketException e)
                    {
                        var try_again = MessageBox.Show("Failed to connecto to server with error:" + e.ToString() + "\n Retry?", "Failed to connecto to server!", MessageBoxButtons.YesNo);
                        if (try_again != DialogResult.Yes)
                            return;
                    }

                }
                catch (SocketException e)
                {
                    var try_again = MessageBox.Show("Failed to connecto to server with error:" + e.ToString() + "\n Retry?", "Failed to connecto to server!", MessageBoxButtons.YesNo);
                    if (try_again != DialogResult.Yes)
                        return;
                }
            }
        }

    }
}
