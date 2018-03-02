using System;
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
                        Select_btn.Text = "Deselect All";
                        
                    }
                    else
                    {
                        cb.Checked = false;
                        Select_btn.Text = "Select All";
                    }
                }
            }
        }
    }
}
