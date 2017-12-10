using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManager.Models;
using SchoolManager.BLL;
using System.Web.Script.Serialization;

namespace SchoolWeb.Web.StatusManager
{
    public partial class TransferClass : System.Web.UI.Page
    {
        static wyqstudentBLL studentBLL = new wyqstudentBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Request.QueryString["action"])
            {
                case "getStudent":
                    getStudent(Request.QueryString["condition"]);
                    break;
                case "transfer":
                    transfer(Request.QueryString["newClass"],Request.QueryString["Sno"]);
                    break;
            }
        }
        public void getStudent(string condition)
        {
            try
            {
                List<wyqstudentModel> studentList = studentBLL.GetList(condition);
                JavaScriptSerializer js = new JavaScriptSerializer();
                string jsondata;
                //var jsondata = js.Serialize(new { total = total, rows = rows });
                jsondata = js.Serialize(new { studentList });
                Response.Clear();
                Response.Write(jsondata);
                Response.End();
            }
            catch
            { }
        }
        public void transfer(string newClass,string Sno)
        {
            try
            {
                List<wyqstudentModel> studentList = studentBLL.GetList(Sno);
                studentList[0].Classno = newClass;
                //List<wyqstudentModel> studentList2 = studentBLL.Edit(s)
                
            }
            catch
            { }

        }


    }
}