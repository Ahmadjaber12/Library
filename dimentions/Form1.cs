using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dimentions
{
    public partial class Form1 : Form
    {
        public static Form1 Current;
        public Form1()
        {
            InitializeComponent();
            Current = this;
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {

        }

      public static List<string> list = new List<string>();
         
        private void button1_Click(object sender, EventArgs e)
        {

            foreach (Control cb in this.Controls)
            {
                if (cb is CheckBox)
                    if (((CheckBox)cb).Checked)
                    { list.Add(cb.Text); }
            }
            if (list.Count > 0)
            {
                this.Hide();
                registration registration = new registration();
                registration.ShowDialog();
            }
            
            else 
                MessageBox.Show("You Didn't Select Any Category!","Invalid Command",MessageBoxButtons.OK,MessageBoxIcon.Error);



        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
           
            Login login = new Login();
            login.ShowDialog();

        }
    }
}
