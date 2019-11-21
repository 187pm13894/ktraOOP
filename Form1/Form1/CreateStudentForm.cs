using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form1
{
    public partial class CreateStudentForm : Form
    {
        private StudentManagement Business;
        public CreateStudentForm()
        {
            InitializeComponent();
            this.Business = new StudentManagement();
            this.btnCancel.Click += btnCancel_Click;
            this.btnSave.Click += btnSave_Click;
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            var name = this.txtName.Text;
            var code = this.txtCode.Text;
            var hometown = this.rtbHomeTown.Text;
            var male = this.rdbMale.Checked;
            var female = this.rdbFemale.Checked;
            bool gender;
            if (this.rdbMale.Checked == true)
                gender = true;
            else
                gender = false;            
            this.Business.AddStudent(name, code, hometown, gender);
            MessageBox.Show("them thanh cong");
            this.Close();
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
