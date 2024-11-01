using System;
using System.Drawing;
using System.Windows.Forms;
using School.BLL;
using School.Model;

namespace Schoool
{
    public partial class FrmStudent : Form
    {
        public Action OnStudentInserted;
        public FrmStudent()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            StudentBLL st = new StudentBLL();
            var data = new StudentDto
            {
                FirstName = txtName.Text,
                Mobile = txtMobile.Text,
                LastName = txtLastName.Text
            };
            var result = st.Insert(data);
            if (result.Success)
            {
                OnStudentInserted?.Invoke();
            }
            ShowToast(result.Message, result.Success);
        }


        private void ShowToast(string message, bool success)
        {
            lblToast.Text = message;
            if (success)
                lblToast.ForeColor = Color.Green;
            else
                lblToast.ForeColor = Color.Red;
        }
    }
}
