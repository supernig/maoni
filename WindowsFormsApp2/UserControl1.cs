using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Timers;
namespace WindowsFormsApp2
{
    public partial class UserControl1 : UserControl
    {
        MySqlConnection con = new MySqlConnection("server=localhost;database=db;user=root;password=root");

        DataTable grid = new DataTable();
        // int selectedRow;

        public UserControl1()
        {
            InitializeComponent();
            refresh();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
     
        }


      


        public void refresh(string query = "select items.id, items.name, category.description,items.status from items left join category on category.id = items.categoryID")
        {

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, con);
            adapter.Fill(table);
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.Columns.Clear();
            dgv.DataSource = table;
            dgv.Columns[0].Visible = false;
            dgv.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[1].HeaderCell.Value = "Name";
            dgv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[2].HeaderCell.Value = "Category";
            dgv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[3].HeaderCell.Value = "Status";
            dgv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var a = new AddEquip();
            a.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            refresh("select items.id, items.name, category.description,items.status from items left join category on category.id = items.categoryID");
        }
    }
}
