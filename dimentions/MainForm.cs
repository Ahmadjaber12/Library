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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            loaduserdata();

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.customerTableAdapter.FillBy(this.booksStoreClientsDataSet.customer);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void loaduserdata()
        {
            DataTable userdata = dimentions.serverconnection.serverconnectionn.executeSQL("SELECT DISTINCT Category.CategoryName  from customer JOIN categoryandcustomer ON customer.ID = categoryandcustomer.CustomerID JOIN Category ON Category.CategoryID = categoryandcustomer.categoryID where Username = '" + Login.text + "'");
            dataGridView1.DataSource = userdata;
            dataGridView1.Columns[0].Name = "Your Categories";
            dataGridView1.Columns[0].Width = 234;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            DataTable userdata1 = dimentions.serverconnection.serverconnectionn.executeSQL("select TOP(5)  Category.CategoryName from Category join((SELECT CategoryID FROM  Category)EXCEPT(select categoryandcustomer.categoryID from categoryandcustomer where (select customer.ID from customer where customer.Username = '" + Login.text + "'" + ") = categoryandcustomer.CustomerID))as x on x.CategoryID = Category.CategoryID");
            dataGridView2.DataSource = userdata1;
            dataGridView2.Columns[0].HeaderText = "Suggested Categories ";
            dataGridView2.Columns[0].Width = 234;
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DisplayedRowCount(false);

            int x = (int)dataGridView2.Rows.Count;
            if (x != 0)
            {

                string r = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                DataTable userd = dimentions.serverconnection.serverconnectionn.executeSQL("INSERT INTO categoryandcustomer VALUES((select customer.ID from customer where customer.Username='" + Login.text + "'" + "),(SELECT Category.CategoryID FROM Category WHERE Category.CategoryName='" + r + "'))");
                loaduserdata();
            }
            else
            MessageBox.Show("No rows to Add", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);




        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x = (int)dataGridView1.Rows.Count;
            if (x > 0)
            {
                string R = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                DataTable ud = dimentions.serverconnection.serverconnectionn.executeSQL("DELETE FROM categoryandcustomer WHERE CustomerID in (select customer.ID from customer where customer.Username='" + Login.text + "'" + ") AND CategoryID in(  SELECT Category.CategoryID FROM Category WHERE Category.CategoryName='" + R + "' )");

                loaduserdata();
            }

            else
            MessageBox.Show("No rows to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

