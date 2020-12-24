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
    public partial class Allocdetcs : Form
    {
        SqlConnection sqlConnection;
        SqlDataAdapter da;
        DataTable dt;


        public Allocdetcs(String con)
        {
            InitializeComponent();
            sqlConnection = new SqlConnection(con);
            sqlConnection.Open();
            fill();

        }
        private void fill()
        {
            da = new SqlDataAdapter("SELECT IdLecturer,Lecturername from tb1_Lecturers", sqlConnection);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                cmbname.DataSource = dt;
                cmbname.DisplayMember = "Lecturername";
                cmbname.ValueMember = "IdLecturer";
            }
        }
        private void btnshow_Click(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("SELECT s.SubjectCode,s.SubjectName FROM tb1_Subjects s, tb1_LecturerSubjects ls WHERE ls.Subjectcode = s.SubjectCode and ls.IdLecturer = " + cmbname.SelectedValue, sqlConnection);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
                dataGridView1.DataSource = dt;
            else
            {
                dataGridView1.DataSource = null;
            MessageBox.Show("No subjects alloted to the subject...!");
            }
        }
    }
}
