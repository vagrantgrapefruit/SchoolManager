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
    public partial class Transfer_out : System.Web.UI.Page
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
                case "transferOut":
                    transferOut(Request.QueryString["reason"], Request.QueryString["StdRollId"]);
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
        public void transferOut(string reason, string StdRollId)
        {
            try
            {
                List<YZJ_StatusModel> InforList = statusBLL.GetList(StdRollId);
                InforList[0].StatusState = "转出";
                InforList[0].available = false;
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
                model.ApplyType = "转出学校";
                bool flag = CheckRecordBLL.Create(model);

                Response.Clear();
                Response.Write("{'success':'" + success.ToString() + "','saveRecords':'" + flag + "'}");
                Response.End();
            }
            catch
            {
               
            }
        }
    }
}