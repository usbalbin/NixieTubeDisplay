using System;
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



namespace GUI
{
    public partial class Form1 : Form
    {
        string folderpath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\NixieTubeController\\";
        string ConfigText;
        public Form1()
        {
            InitializeComponent();
            string[] baudrate = new string[] { "300", "1200", "2400", "4800", "9600", "14400", "19200", "28800", "30400", "38400", "57600", "115200"};
            Baud_box.Items.AddRange(baudrate);
            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {
                ComBox.Items.Add(s);
            }
            if (ComBox.Items.Count == 0)
            {
                ComBox.Items.Add("No COM-port Available");
            }

            bool exists = System.IO.File.Exists(folderpath + "settings.conf");
            if (exists)
            {
                ConfigText = System.IO.File.ReadAllText(folderpath + "settings.conf");
            }
            string pattern = @"\n";
            string[] config = Regex.Split(ConfigText, pattern);
            foreach (var element in config)
                Console.WriteLine(element);
            string[] COM = config[0].Split(new char[0]); //Split on space com_name || COM1
            string[] baud = config[1].Split(new char[0]);//Split on space Baud_rate || 300
            string[] enabledData = config[2].Split(new char[0]);
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

            Console.WriteLine(config[2]);

        }

        private void Ext_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Select_btn_Click(object sender, EventArgs e)
        {
            foreach(Control c in Controls)
            {
                if(c is CheckBox)
                {
                    CheckBox cb = (CheckBox)c;
                    if(cb.Checked == false)
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

            if(ComBox.SelectedItem != null && ComBox.SelectedText != "No COM-port Available" && Baud_box.SelectedItem != null)
            {
                bool exists = System.IO.Directory.Exists(folderpath);
                if (!exists)
                    System.IO.Directory.CreateDirectory(folderpath);

                string text = "com_name " + ComBox.SelectedItem.ToString() + "\n" +
                    "com_baud " + Baud_box.SelectedItem.ToString() + "\n";
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
            }
            else
            {
                MessageBox.Show("No COM Port or Baudrate selected");
            }
            
        }


    }
}
