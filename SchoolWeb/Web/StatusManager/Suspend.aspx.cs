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
        static YZJ_StatusBLL statusBLL = new YZJ_StatusBLL();
        static YZJ_CheckRecordBLL CheckRecordBLL = new YZJ_CheckRecordBLL();
        JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
      {
            switch (Request.QueryString["action"])
            {
                case "getStudent":
                    getStudent(Request.QueryString["condition"]);
                    break;
                case "suspend":
                    suspend(Request.QueryString["reason"],Request.QueryString["StdRollId"]);
                    break;
            }
        }
        public void getStudent(string condition)
        {
            try
            {
                List<YZJ_StatusModel> InforList = statusBLL.GetList(condition);
                string jsondata;
                jsondata = js.Serialize(new { InforList });
                Response.Clear();
                Response.Write(jsondata);
                Response.End();
            }
            catch
            { }
        }
        public void suspend(string reason,string StdRollId)
        {
            try
            {
                List<YZJ_StatusModel> InforList = statusBLL.GetList(StdRollId);
                InforList[0].StatusState = "休学";
                bool success = statusBLL.Edit(InforList[0]);
                string json = js.Serialize(new { success });


                DateTime dt = new DateTime();
                YZJ_CheckRecordModel model = new YZJ_CheckRecordModel();
                model.id = ResultHelper.NewId;
                model.available = true;
                model.StdId = InforList[0].StdRollId;
                model.StdName = InforList[0].StdName;
                model.ApplicantNo = InforList[0].StdName;
                model.ApplicantName = InforList[0].StdName;
                model.ApplyDate = DateTime.Now;
                model.ApplyReason = reason;
                model.ApplyType = "休学";
                bool flag = CheckRecordBLL.Create(model);

                Response.Clear();
                Response.Write("{'success':'" + success.ToString() + "','saveRecords':'" + flag + "'}");
                Response.End();
            }
            catch
            { }
        }

    }
}