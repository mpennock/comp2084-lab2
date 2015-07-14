using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using comp2084_lesson9.Models;

namespace comp2084_lesson9
{
    public partial class student_details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // if loading for the first time (not posting back), check for a url
            if (!IsPostBack)
            {
                // if we have an id in the url, look up the selected record
                if (!String.IsNullOrEmpty(Request.QueryString["StudentID"]))
                {
                    GetStudent();
                }
            }
        }

        protected void GetStudent()
        {
            // look up the selected student and fill the form
            using (DefaultConnection db = new DefaultConnection())
            {
                // store the id from the url in a variable
                Int32 StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);

                //look up the department
                Student stu = (from s in db.Students
                                  where s.StudentID == StudentID
                                  select s).FirstOrDefault();

                // pre populate the form fields
                txtFirstName.Text = stu.FirstMidName;
                txtLastName.Text = stu.LastName;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // connect
            using (DefaultConnection db = new DefaultConnection())
            {
                // create a new student in memory
                Student stu = new Student();

                Int32 StudentID = 0;

                // check for a url
                if (!String.IsNullOrEmpty(Request.QueryString["StudentID"]))
                {
                    //get the id from the url
                    StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);

                    //look up the student
                    stu = (from s in db.Students
                           where s.StudentID == StudentID
                           select s).FirstOrDefault();
                }
                // fill the properties of the new student
                stu.FirstMidName = txtFirstName.Text;
                stu.LastName = txtLastName.Text;

                // save the new student
                //add student if we have no id in the url
                if (StudentID == 0)
                {
                    db.Students.Add(stu);
                }

                //execute save
                db.SaveChanges();

                //redirect to students list page
                Response.Redirect("students.aspx");
            }
        }
    }
}