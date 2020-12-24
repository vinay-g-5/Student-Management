using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lecturerss
{
    public partial class Form1 : Form
    {
        private String con = "Data Source=LAPTOP-S8FKPDUB\\SQLEXPRESS;Initial Catalog=db_LSA;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Allocdetcs alldet = new Allocdetcs(con);
            alldet.Show();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Subject sub = new Subject(con);
            sub.Show();
        }

        private void addLecturersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lecturer lect = new Lecturer(con);
            lect.Show();

        }

        private void subjectAlloctionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllocSub allsub = new AllocSub(con);
            allsub.Show();
        }
    }
}
