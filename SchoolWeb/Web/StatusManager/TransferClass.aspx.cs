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
    public partial class TransferClass : System.Web.UI.Page
    {
        static YZJ_InfoBLL InforBLL = new YZJ_InfoBLL();
        static YZJ_CheckRecordBLL CheckRecordBLL = new YZJ_CheckRecordBLL();
        JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Request.QueryString["action"])
            {
                case "getStudent":
                    getStudent(Request.QueryString["condition"]);
                    break;
                case "transfer":
                    transfer(Request.QueryString["newClass"],Request.QueryString["stdid"],Request.QueryString["ApplyReason"]);
                    break;
            }
        }
        public void getStudent(string condition)
        {
            try
            {
                List<YZJ_InfoModel> InforList = InforBLL.GetList(condition);
                string jsondata;
                jsondata = js.Serialize(new { InforList });
                Response.Clear();
                Response.Write(jsondata);
                Response.End();
            }
            catch
            { }
        }
        public void transfer(string newClass,string Stdid,string ApplyReason)
        {
            try
            {
                List<YZJ_InfoModel> InforList = InforBLL.GetList(Stdid);
                InforList[0].ClassNo = newClass;
                bool success = InforBLL.Edit(InforList[0]);
                string json = js.Serialize(new { success });
                

                DateTime dt = new DateTime();
                YZJ_CheckRecordModel model = new YZJ_CheckRecordModel();
                model.id = ResultHelper.NewId;
                model.available = true;
                model.StdId = Stdid;
                model.StdName = InforList[0].StdName;
                model.ApplicantNo = Stdid;
                model.ApplicantName = InforList[0].StdName;
                model.ApplyDate = DateTime.Now;
                model.ApplyReason = ApplyReason;
                model.ApplyType = "转班";
                bool flag = CheckRecordBLL.Create(model);

                Response.Clear();
                Response.Write("{'transfer':'" + success.ToString() + "','saveRecords':'" + flag + "'}");
                Response.End();
                

            }
            catch
            { }

        }


    }
}