using School.Model;
using System;
using System.Windows.Forms;

namespace Schoool
{
    public partial class FrmRegister : Form
    {
        public FrmRegister()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmStudent frm = new FrmStudent();
            //frm.StudentInserted += Frm_StudentInserted; ;
            frm.Show();
        }

        private void Frm_StudentInserted(object sender, EventArgs e)
        {
            var studentDto = sender as StudentDto;
            if (studentDto != null)
            {
                button1.Text = studentDto.FirstName + "ثبت شد";
            }
        }
    }
}
