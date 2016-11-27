using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversityManagementSqlite;

namespace UniversityManagementSqlite
{
    public partial class studentEntryForm : Form
    {
        EditForm editForm = new EditForm();
        UniversityDBEntities db = new UniversityDBEntities();
        
        public studentEntryForm()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            StudentInfo student = new StudentInfo();
            student.StudentName = nameTextBox.Text;
            student.Department = departmentTextBox.Text;
            student.Year = yearTextBox.Text;
            student.Semester = semesterTextBox.Text;
            student.ContactNo = contactNoTextBox.Text;
            db.StudentInfoes.Add(student);
            db.SaveChanges();

            studentDataGridView.DataSource = null;
            studentDataBind();
        }

        private void studentDataBind()
        {
            studentDataGridView.DataSource = db.StudentInfoes.ToList();
            
            
        }

        private void studentEntryForm_Load(object sender, EventArgs e)
        {
            
            studentDataBind();
            
        }

        private void studentDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            StudentInfo singleStudent = new StudentInfo();
            if (e.ColumnIndex == 1)
            {

                int a = Convert.ToInt16(studentDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString());
                singleStudent = db.StudentInfoes.FirstOrDefault(x => x.StudentId == a);
                db.StudentInfoes.Remove(singleStudent);
                db.SaveChanges();
                studentDataBind();
            }
            if (e.ColumnIndex == 0)
            {
                int b = Convert.ToInt16(studentDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString());
                ViewClass.studentID = b;
                editForm.Show();
                this.Hide();
                
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            List<StudentInfo> students = new List<StudentInfo>();
            students = db.StudentInfoes.Where(x => x.StudentName.Contains(textBox1.Text) || x.Department.Contains(textBox1.Text)).ToList();
            studentDataGridView.DataSource = null;
            studentDataGridView.DataSource = students;
        }
    }
}
