using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using comp2084_lesson9.Models;

namespace comp2084_lesson9
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getStudents();
            }
            
        }

        protected void getStudents()
        {
            // connect and get list of students
            using (DefaultConnection db = new DefaultConnection())
            {
                var students = from s in db.Students select s;

                // bind the students query result to the grid
                grdStudents.DataSource = students.ToList();
                grdStudents.DataBind();
            }
        }

        protected void grdStudents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            // find the row to be deleted
            Int32 StudentID = Convert.ToInt32(grdStudents.DataKeys[e.RowIndex].Values["StudentID"]);

            // connect to the database
            using (DefaultConnection db = new DefaultConnection())
            {

                Student stu = (from s in db.Students
                               where s.StudentID == StudentID
                               select s).FirstOrDefault();
                //delete
                db.Students.Remove(stu);
                db.SaveChanges();

                //refresh the grid
                getStudents();
            }
        }

        protected void grdStudents_Sorting(object sender, GridViewSortEventArgs e)
        {

        }
    }
}