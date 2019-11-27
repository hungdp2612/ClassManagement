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
    public partial class UpdateForm : Form
    {
        private int StudentId;
        private LogicLayer Business;

        public UpdateForm(int id)
        {
            this.StudentId = id;
            this.Business = new LogicLayer();
            InitializeComponent();
            this.Load += UpdateForm_Load;
        }

        void UpdateForm_Load(object sender, EventArgs e)
        {
            var student = this.Business.GetStudents(this.StudentId);
            this.cboClass.DataSource = this.Business.GetClasses();
            this.cboClass.DisplayMember = "Name";
            this.cboClass.ValueMember = "id";
            this.cboClass.SelectedValue = student.Class_id;
        }
    }
}
