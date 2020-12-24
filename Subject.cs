using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lecturerss
{
    public partial class Subject : Form
    {
        SqlConnection sqlConnection;
        SqlDataAdapter da;
         DataTable dt;

        public Subject(String con)
        {
            InitializeComponent();
            sqlConnection = new SqlConnection(con);
            sqlConnection.Open();

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            String query = @"INSERT INTO tb1_Subjects values('" +id.Text + "','" +code.Text + "','" + name.Text + "')";
            da = new SqlDataAdapter(query, sqlConnection);
            dt = new DataTable();
            da.Fill(dt);
            MessageBox.Show("Added Successfully...!");
            sqlConnection.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            fr.Show();
            this.Hide();

        }
    }
}
