using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManager.Models;
using SchoolManager.BLL;
using System.Web.Script.Serialization;
using SchoolManager.Common;


namespace SchoolWeb.Web.StatusManager
{
    public partial class Suspend : System.Web.UI.Page
    {
        static YZJ_StatusBLL status = new YZJ_StatusBLL();
     //   static YZJ_InfoBLL InforBLL = new YZJ_InfoBLL();
        static YZJ_CheckRecordBLL CheckRecordBLL = new YZJ_CheckRecordBLL();
        JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
      {
            switch (Request.QueryString["action"])
            {
                case "getStudent":
                    getStudent(Request.QueryString["condition"]);
                    break;
               
            }
        }
        public void getStudent(string condition)
        {
            try
            {
                List<YZJ_StatusModel> InforList = status.GetList(condition);
                string jsondata;
                jsondata = js.Serialize(new { InforList });
                Response.Clear();
                Response.Write(jsondata);
                Response.End();
            }
            catch
            { }
        }
    }
}