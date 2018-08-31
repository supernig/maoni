using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace WindowsFormsApp2
{
    public partial class AddEquip : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;database=db;user=root;password=root");
        MySqlCommand cmd;
        public AddEquip()
        {
            InitializeComponent();
        }

        private void AddEquip_Load(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = 1;
            comboBox1.SelectedIndex = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var a = 1 + comboBox1.SelectedIndex;
            if (textBox1.Text != "" && textBox2.Text !="")
            {
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    DialogResult dg = MessageBox.Show("Are you sure?", "Alert!", MessageBoxButtons.YesNo);
                    if (dg == DialogResult.Yes)
                    {
                        string insertQuery = "INSERT INTO items(name, categoryID, tagID, description,status) VALUES ('" + textBox1.Text + "','" + a + "','1','" + textBox2.Text + "','"+comboBox2.SelectedText+"')";
                        executeMyQuery(insertQuery);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Dispose();
                       
                    }

                }
                else
                {
                    MessageBox.Show("Something went wrong", "Error. ",
   MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Something went wrong", "Error. ",
   MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void openConnection()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public void closeConnection()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }


        public void executeMyQuery(string query)
        {
            try
            {
                openConnection();
                cmd = new MySqlCommand(query, con);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    //MessageBox.Show("Executed");
                    MessageBox.Show("Item added Successfully");
          
                }

                else
                {
                    MessageBox.Show("Not Executed");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                closeConnection();
            }
        }


    }
}
