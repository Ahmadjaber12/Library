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
    public partial class registration : Form
    {
        public registration()
        {
            InitializeComponent();
        }

        private void registration_Load(object sender, EventArgs e)
        {   
            fnametextBox6.Focus();

        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(fnametextBox6.Text))
            {
                MessageBox.Show("first name field is empty", "Empty Field!! ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fnametextBox6.Select();
                return;
            }
            if (string.IsNullOrEmpty(lnametextBox4.Text))
            {
                MessageBox.Show("last name field is empty", "Empty Field!! ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lnametextBox4.Select();
                return;
            }
           
            if (string.IsNullOrEmpty(unametextBox1.Text))
            {
                MessageBox.Show("username field is empty", "Empty Field!! ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                unametextBox1.Select();
                return;
            }
            if (string.IsNullOrEmpty(psstextBox3.Text))
            {
                MessageBox.Show("password field is empty", "Empty Field!! ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                psstextBox3.Select();
                return;
            }
            if (string.IsNullOrEmpty(retextBox2.Text))
            {
                MessageBox.Show("conform field is empty", "Empty Field!! ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                retextBox2.Select();
                return;
            }
            if (retextBox2.Text != psstextBox3.Text)

            {
                MessageBox.Show("The password fields are not the same", "wrong Field!! ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                retextBox2.Select();
                return;
            }
            string sq = string.Empty;
            sq += "SELECT * FROM customer WHERE ID in (SELECT customer.ID where customer.Username='" + unametextBox1.Text + "') AND Pass in(SELECT Pass from customer where customer.Pass='"+psstextBox3.Text+ "') AND FirstName IN(SELECT FirstName FROM customer where customer.FirstName= '" + fnametextBox6.Text+"')";

            DataTable dt = dimentions.serverconnection.serverconnectionn.executeSQL(sq);
            if (dt.Rows.Count > 0)
            {
               DialogResult x= MessageBox.Show("The Username is Already Exists!! Do you want to upddate informations?", "invalid Entry", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (x == DialogResult.Yes)
                {
                    string sql = string.Empty;
                    sql += "UPDATE customer SET FirstName ='" + fnametextBox6.Text + "',";
                    sql += "LastName = '" + lnametextBox4.Text + "'," + "Username='" + unametextBox1.Text +"'"+" ,Pass='"+psstextBox3.Text+ "' " + " WHERE ID = (SELECT customer.ID where customer.Username='"+unametextBox1.Text+"')" ;
                    dimentions.serverconnection.serverconnectionn.executeSQL(sql);
                    string sqll=string.Empty;
                    sqll += "DELETE FROM categoryandcustomer WHERE CustomerID in (select customer.ID from customer where customer.Username='" +  unametextBox1.Text + "')"  ;
                    dimentions.serverconnection.serverconnectionn.executeSQL (sqll);
                    foreach (string D in Form1.list)
                    {
                       // string ss = "UPDATE categoryandcustomer SET CustomerID" + "=(SELECT customer.ID from customer where customer.Username='" + unametextBox1.Text + "'),";
                       // ss += "CategoryID=(SELECT CategoryID FROM Category where Category.CategoryName='" + D + "')";
                       // dimentions.serverconnection.serverconnectionn.executeSQL(ss);
                       //خليها انسيرت بدل ابديت
                       string ss = "INSERT INTO categoryandcustomer  (CustomerID,categoryID) VALUES ((SELECT customer.ID FROM customer WHERE customer.Username='"+unametextBox1.Text+"')"+ ",(SELECT Category.CategoryID FROM Category where Category.CategoryName='" + D + "'))";
                        dimentions.serverconnection.serverconnectionn.executeSQL(ss);
                    }
                    
                    MessageBox.Show("the record has been Updated Seccessfully", "Update Process", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cleartext();
                    this.Hide();
                    Login login = new Login();
                    login.ShowDialog();
                }
            }
            else if (dt.Rows.Count == 0)
            {
                DialogResult dialog;
                dialog = MessageBox.Show("Do you want to save this Data", "Save Data", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialog == DialogResult.Yes)
                {
                    string sql = string.Empty;
                    sql += "INSERT INTO customer (FirstName,LastName,Username,Pass)";
                    sql += "VALUES ('" + fnametextBox6.Text + "','" + lnametextBox4.Text + "','" + unametextBox1.Text + "','" + psstextBox3.Text + "')";
                    dimentions.serverconnection.serverconnectionn.executeSQL(sql);
                    MessageBox.Show("the record has been inserted", "insertion process", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string sql2 = string.Empty;
                    foreach (string str in Form1.list)
                    {
                        sql2 += "INSERT INTO categoryandcustomer (CustomerID,categoryID)";
                        sql2 += "VALUES ((SELECT customer.ID FROM customer where customer.Username='" + unametextBox1.Text + "')" + ",(SELECT Category.CategoryID FROM Category where Category.CategoryName='" + str + "'))";
                        dimentions.serverconnection.serverconnectionn.executeSQL(sql2);
                    }
                    MessageBox.Show("Welcome in our Book Store","insertion new member",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Login login = new Login();
                    login.ShowDialog();
                }
                }

            }
        private void cleartext()
        {
            foreach (TextBox tb in this.Controls.OfType<TextBox>())
                tb.Text = String.Empty;
            fnametextBox6.Select();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (TextBox tb in this.Controls.OfType<TextBox>())
                tb.Text = String.Empty;
            fnametextBox6.Select();
        }

        private void button2_Click(object sender, EventArgs e)
        { Form1.Current.ShowDialog();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fnametextBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }

