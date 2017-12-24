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
        /// <summary>
        /// 获取学生信息
        /// </summary>
        /// <param name="condition">传入参数</param>
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
        /// <summary>
        ///创建申请记录
        /// </summary>
        /// <param name="reason"></param>
        /// <param name="StdRollId"></param>
        public void suspend(string reason,string StdRollId)
        {
            try
            {
                List<YZJ_StatusModel> InforList = statusBLL.GetList(StdRollId);
                //InforList[0].StatusState = "转出";
                //InforList[0].available = false;
                //bool success = statusBLL.Edit(InforList[0]);
                //string json = js.Serialize(new { success });
                YZJ_CheckRecordModel model = new YZJ_CheckRecordModel();
                model.id = ResultHelper.NewId;
                model.available = true;
                model.StdId = InforList[0].StdRollId;
                model.StdName = InforList[0].StdName;
                model.ApplicantNo = Session["UserName"].ToString();
                model.ApplicantName = Session["TrueName"].ToString();
                model.ApplyDate = DateTime.Now.ToString();
                model.ApplyReason = reason;
                model.AssessState = "待审核";
                model.ApplyType = "休学";
                bool flag = CheckRecordBLL.Create(model);

                Response.Clear();
                Response.Write("{'saveRecords':'" + flag + "'}");
                Response.End();
            }
            catch
            { }
        }

    }
}