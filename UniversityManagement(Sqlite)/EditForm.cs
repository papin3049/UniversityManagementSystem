using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace UniversityManagementSqlite
{
    public partial class EditForm : Form
    {
        UniversityDBEntities db = new UniversityDBEntities();
        //ViewClass viewClass = new ViewClass();
        public EditForm()
        {
            InitializeComponent();
        }

        private void Edit_Load(object sender, EventArgs e)
        {
            StudentInfo student = new StudentInfo();
            student = db.StudentInfoes.FirstOrDefault(x=>x.StudentId == ViewClass.studentID);
            nameTextBox.Text = student.StudentName;
            departmentTextBox.Text = student.Department;
            yearTextBox.Text = student.Year;
            semesterTextBox.Text = student.Semester;
            contactNoTextBox.Text = student.ContactNo;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            StudentInfo updatedStudentInfo = new StudentInfo();
            updatedStudentInfo = db.StudentInfoes.FirstOrDefault(x => x.StudentId == ViewClass.studentID);
            updatedStudentInfo.StudentName = nameTextBox.Text;
            updatedStudentInfo.Department = departmentTextBox.Text;
            updatedStudentInfo.Year = yearTextBox.Text;
            updatedStudentInfo.Semester = semesterTextBox.Text;
            updatedStudentInfo.ContactNo = contactNoTextBox.Text;
            
            db.SaveChanges();

            this.Close();
            studentEntryForm form = new studentEntryForm();
            form.Show();
        }
    }
}
