using System;
using System.Data;
using System.Windows.Forms;
using dimentions.serverconnection;
namespace dimentions
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public static string text;
     
        
            private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(usernameTextBox.Text) && !string.IsNullOrEmpty(passwordTextBox2.Text))
            {
                string mysql = string.Empty;
                mysql += "SELECT * FROM customer ";
                mysql += "Where Username ='" + usernameTextBox.Text + "'";
                mysql += "AND Pass ='" + passwordTextBox2.Text + "'";
                DataTable userdata = serverconnectionn.executeSQL(mysql);

                if (userdata.Rows.Count > 0)
                {
                    text = usernameTextBox.Text;

                    usernameTextBox.Clear();
                    passwordTextBox2.Clear();
                    show.Checked = false;
                    this.Hide();
                    MainForm mainForm = new MainForm();
                    mainForm.ShowDialog();
                    mainForm = null;
                    this.Show();
                    this.usernameTextBox.Select();

                }
                else
                {
                    MessageBox.Show("Incorrect Username or Password , Make sure to write them correctly", "C# LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    usernameTextBox.Focus();
                    usernameTextBox.SelectAll();

                }
            }
            else
            {
                MessageBox.Show("Please enter a Username & Password ", "C# LOGIN ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                usernameTextBox.Select();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(show.Checked)
            
                {
                    passwordTextBox2.UseSystemPasswordChar = false;

                }
            else
                {
                    passwordTextBox2.UseSystemPasswordChar = true;
                }
            
        }

        private void Login_Load(object sender, EventArgs e)
        {
            usernameTextBox.Select();
        }
    }
}
