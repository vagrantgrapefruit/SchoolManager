using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolManager.Models;
using SchoolManager.BLL;
using System.Web.SessionState;
using System.Web.Script.Serialization;

namespace SchoolWeb.Web.Handler
{
    /// <summary>
    /// ChangeCheckRecord 的摘要说明
    /// </summary>
    public class ChangeCheckRecord : IHttpHandler, IRequiresSessionState
    {
        public YZJ_CheckRecordBLL checkBLL = new YZJ_CheckRecordBLL();
        public JavaScriptSerializer js = new JavaScriptSerializer();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request.QueryString["Param"] != null)
            {
                var id= context.Request.QueryString["id"];
                var userId = context.Session["UserName"].ToString();
                var userName = context.Session["TrueName"].ToString();
                var param = context.Request.QueryString["Param"];
                switch (param)
                {
                    case ("Agree"):
                        {
                            var jsondata = Agree(id,userId,userName);
                            context.Response.Write(jsondata);
                            break;
                        }
                    case ("DisAgree"):
                        {
                            var jsondata = DisAgree(id, userId, userName);
                            context.Response.Write(jsondata);
                            break;
                        }
                    default:
                        break;
                }
            }
        }

        public string Agree(string id, string userId,string userName)
        {
            YZJ_CheckRecordModel CheckModel = checkBLL.GetById(id);
            CheckModel.AssessDate = DateTime.Now.ToString();
            CheckModel.AssessorId = userId;
            CheckModel.AssessorName = userName;
            CheckModel.AssessState = "通过申请";
            var flag = checkBLL.Edit(CheckModel);
            var jsondata = js.Serialize(new { flag = flag });
            return jsondata;
        }

        public string DisAgree(string id, string userId, string userName)
        {
            YZJ_CheckRecordModel CheckModel = checkBLL.GetById(id);
            CheckModel.AssessDate = DateTime.Now.ToString();
            CheckModel.AssessState = "拒绝申请";
            CheckModel.AssessorId = userId;
            CheckModel.AssessorName = userName;
            var flag = checkBLL.Edit(CheckModel);
            var jsondata = js.Serialize(new { flag = flag});
            return jsondata;
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}