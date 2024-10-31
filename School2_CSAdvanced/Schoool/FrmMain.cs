using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Schoool
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FrmStudents().Show();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            new FrmRegister().Show();
        }

        private void btnLessons_Click(object sender, EventArgs e)
        {
            new FrmLessons().Show();
        }
    }
}
