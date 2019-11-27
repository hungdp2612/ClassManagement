using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3.StudentManagement
{
    public partial class IndexForm : Form
    {
        private LogicLayer Business;
        public IndexForm()
        {
            InitializeComponent();
            this.Business = new LogicLayer();
            this.Load += IndexForm_Load;
            this.btnCreate.Click += btnCreate_Click;
            this.btnDelete.Click += btnDelete_Click;
            this.grdStudent.DoubleClick += grdStudent_DoubleClick;
        }

        void grdStudent_DoubleClick(object sender, EventArgs e)
        {
            if (this.grdStudent.SelectedRows.Count == 1)
            {
                var row = this.grdStudent.SelectedRows[0];
                var studentView = (StudentView)row.DataBoundItem;

                new UpdateForm(studentView.id).ShowDialog();
            }
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void btnCreate_Click(object sender, EventArgs e)
        {
            new CreateForm().ShowDialog();
            this.ShowAllStudents();
        }
        private void ShowAllStudents()
        {
            this.grdStudent.DataSource = this.Business.GetStudents();
            var students = this.Business.GetStudents();
            var studentViews = new StudentView[students.Length];
            for (int i = 0; i < students.Length; i++)
                studentViews[i] = new StudentView(students[i]);
            this.grdStudent.DataSource = studentViews;
        }
        void IndexForm_Load(object sender, EventArgs e)
        {
            this.ShowAllStudents();
        }
    }
}
