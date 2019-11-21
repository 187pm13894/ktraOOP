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
    public partial class IndexStudentForm : Form
    {
        private StudentManagement Business;
        public IndexStudentForm()
        {
            InitializeComponent();
            this.btnCreate.Click += btnCreate_Click;
            this.btnDelete.Click += btnDelete_Click;
            this.grdStudent.DoubleClick += grdStudent_DoubleClick;
            this.Load += IndexStudentForm_Load;
            this.Business = new StudentManagement();
        }

        void IndexStudentForm_Load(object sender, EventArgs e)
        {
            this.LoadAllStudents();
        }

        void grdStudent_DoubleClick(object sender, EventArgs e)
        {
            var student = (PM13894)this.grdStudent.SelectedRows[0].DataBoundItem;
            var updateForm = new UpdateStudentForm(student.id);
            updateForm.ShowDialog();
            this.LoadAllStudents();
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.grdStudent.SelectedRows.Count == 1)
            {
                if(MessageBox.Show("ban co muon xoa thong tin nay?", "xac nhan",
                    MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    var student = (PM13894)this.grdStudent.SelectedRows[0].DataBoundItem;
                    this.Business.DeleteStudent(student.id);
                    MessageBox.Show("xoa thanh cong");
                    this.LoadAllStudents();
                }
            }
        }

        void btnCreate_Click(object sender, EventArgs e)
        {
            var createStudent = new CreateStudentForm();
            createStudent.ShowDialog();
            this.LoadAllStudents();
        }

        private void LoadAllStudents()
        {
            var students = this.Business.GetStudents();
            this.grdStudent.DataSource = students;
        }
    }
}
