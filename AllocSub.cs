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
    public partial class AllocSub : Form
    {
        SqlConnection sqlConnection;
        SqlDataAdapter da;
        DataTable dt;

        public AllocSub(String con)
        {
            InitializeComponent();
            sqlConnection = new SqlConnection(con);
            sqlConnection.Open();
            fill();
            fill_grid();
        }
        private void fill()
        {
            da = new SqlDataAdapter("SELECT IdLecturer,LecturerName from tb1_Lecturers", sqlConnection);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                cmbname.DataSource = dt;
                cmbname.DisplayMember = "LecturerName";
                cmbname.ValueMember = "IdLecturer";
            }
        }

        private void btnallot_Click(object sender, EventArgs e)
        {
            string col2 =dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            string col3 =dataGridView1[2, dataGridView1.CurrentCell.RowIndex].Value.ToString();

            string query = @"INSERT INTO tb1_LecturerSubjects(IdSubject,SubjectCode,IdLecturer) values(" + col2 + ",'" + col3 + "',"+ cmbname.SelectedValue + ")";
            da = new SqlDataAdapter(query,sqlConnection);
            dt = new DataTable();
            da.Fill(dt);
            MessageBox.Show("Subject Allocated Successfully...!");
        }
        private void cmbname_SelectedIndexChanged(object sender,EventArgs e)
        {
            
        }

        private void fill_grid()
        {
            da = new SqlDataAdapter("SELECT * FROM tb1_Subjects  WHERE  SubjectCode not in (select SubjectCode from tb1_LecturerSubjects)", sqlConnection);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
                dataGridView1.DataSource = dt;
            else
            {
                dataGridView1.DataSource = null;
                MessageBox.Show("All Subjects are allocated!");
            }
        }
    }
}
