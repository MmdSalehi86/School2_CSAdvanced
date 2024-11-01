using System;
using System.Windows.Forms;
using School.BLL;
using School.Model;

namespace Schoool
{
    public partial class FrmStudents : Form
    {
        public FrmStudents()
        {
            InitializeComponent();
        }

        private void FrmStudents_Load(object sender, EventArgs e)
        {
            FillDGV();
        }

        private void FillDGV()
        {
            StudentBLL st = new StudentBLL();
            var result = st.Select();
            if (result.Success)
            {
                dataGridView1.DataSource = result.Data;
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmStudent frm = new FrmStudent();
            frm.OnStudentInserted = FillDGV;
            frm.ShowDialog();
            FillDGV();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FillDGV();
        }
    }
}
