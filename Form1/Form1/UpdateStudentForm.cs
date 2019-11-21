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
    public partial class UpdateStudentForm : Form
    {
        private int StudentId;
        private StudentManagement Business;
        public UpdateStudentForm(int id)
        {
            InitializeComponent();
            this.StudentId = id;
            this.btnSave.Click += btnSave_Click;
            this.btnCancel.Click += btnCancel_Click;
            this.Business = new StudentManagement();
            this.Load += UpdateStudentForm_Load;
        }

        void UpdateStudentForm_Load(object sender, EventArgs e)
        {
            var student = this.Business.GetStudent(this.StudentId);
            this.txtCode.Text = student.Code;
            this.txtName.Text = student.Name;
            this.rtbHomeTown.Text = student.Hometown;
            this.rdbFemale.Checked = student.Gender;
            this.rdbMale.Checked = student.Gender;
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
                gender = false ;
            this.Business.EditStudent(this.StudentId, name, code, hometown, gender);
            MessageBox.Show("thay doi thanh cong");
            this.Close();
        }
    }
}
