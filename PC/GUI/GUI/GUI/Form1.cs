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



namespace GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            object[] baudrate = new object[] { 300, 1200, 2400, 4800, 9600, 14400, 19200, 28800, 30400, 38400, 57600, 115200};
            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {
                ComBox.Items.Add(s);
            }
            if (ComBox.Items.Count == 0 )
            {
                ComBox.Items.Add("No COM-port Available");
            }

            Baud_box.Items.AddRange(baudrate);
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
                string folderpath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\NixieTubeController";
                string subPath = folderpath; // your code goes here

                bool exists = System.IO.Directory.Exists(subPath);
                if (!exists)
                    System.IO.Directory.CreateDirectory(subPath);



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
                System.IO.File.WriteAllText(@folderpath + "Settings.txt", text);
            }
            else
            {
                MessageBox.Show("No COM Port or Baudrate selected");
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
