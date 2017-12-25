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
        public YZJ_InfoBLL inforBLL = new YZJ_InfoBLL();
        public YZJ_StatusBLL statusBLL = new YZJ_StatusBLL();
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
                    case ("DisAgree"):
                        {
                            var jsondata = DisAgree(id, userId, userName);
                            context.Response.Write(jsondata);
                            break;
                        }
                    case ("AgreeRepeat"):
                        {
                            var jsondata = AgreeRepeat(id,userId,userName);
                            context.Response.Write(jsondata);
                            break;
                        }
                    case ("AgreeDismiss"):
                        {
                            var jsondata = AgreeDismiss(id, userId, userName);
                            context.Response.Write(jsondata);
                            break;
                        }
                    case ("AgreeCheckOut"):
                        {
                            var jsondata = AgreeCheckOut(id, userId, userName);
                            context.Response.Write(jsondata);
                            break;
                        }
                    case ("AgreeSkip"):
                        {
                            var jsondata = AgreeSkip(id, userId, userName);
                            context.Response.Write(jsondata);
                            break;
                        }
                    case ("AgreeSuspend"):
                        {
                            var jsondata = AgreeSuspend(id, userId, userName);
                            context.Response.Write(jsondata);
                            break;
                        }
                    case ("AgreeTransferOut"):
                        {
                            var jsondata = AgreeTransferOut(id, userId, userName);
                            context.Response.Write(jsondata);
                            break;
                        }
                    case ("AgreeTransferClass"):
                        {
                            var jsondata = AgreeTransferClass(id, userId, userName);
                            context.Response.Write(jsondata);
                            break;
                        }
                        




                    default:
                        break;
                }
            }
        }

        public string DisAgree(string id, string userId, string userName)
        {
            YZJ_CheckRecordModel CheckModel = checkBLL.GetById(id);
            CheckModel.AssessDate = DateTime.Now.ToString();
            CheckModel.AssessState = "拒绝申请";
            CheckModel.AssessorId = userId;
            CheckModel.AssessorName = userName;
            var flag = checkBLL.Edit(CheckModel);
            var jsondata = js.Serialize(new { flag = flag });
            return jsondata;
        }
        /// <summary>
        /// 同意留级申请，并更改学生的基本信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public string AgreeRepeat(string id, string userId,string userName)
        {
            YZJ_CheckRecordModel CheckModel = checkBLL.GetById(id);
            //更改基本信息
            YZJ_InfoModel inforModel = inforBLL.GetbyStdRoolId(CheckModel.StdId);
            var a = Convert.ToInt32(inforModel.RepeatNo);
            var s = a + 1;
            inforModel.RepeatNo = s.ToString();
            inforModel.ClassNo = "";
            inforBLL.Edit(inforModel);
            //同意审核
            CheckModel.AssessDate = DateTime.Now.ToString();
            CheckModel.AssessorId = userId;
            CheckModel.AssessorName = userName;
            CheckModel.AssessState = "通过申请";
            var flag = checkBLL.Edit(CheckModel);
            var jsondata = js.Serialize(new { flag = flag });
            return jsondata;
        }
        /// <summary>
        /// 同意开除申请，并更改学生的学籍信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public string AgreeDismiss(string id, string userId, string userName)
        {
            YZJ_CheckRecordModel CheckModel = checkBLL.GetById(id);
            //更改学籍信息
            YZJ_StatusModel StatusModel = statusBLL.GetbyStdRoolId(CheckModel.StdId);
            StatusModel.StatusState = "开除";
            StatusModel.available = false;
            statusBLL.Edit(StatusModel);
            //同意审核
            CheckModel.AssessDate = DateTime.Now.ToString();
            CheckModel.AssessorId = userId;
            CheckModel.AssessorName = userName;
            CheckModel.AssessState = "通过申请";
            var flag = checkBLL.Edit(CheckModel);
            var jsondata = js.Serialize(new { flag = flag });
            return jsondata;
        }

        /// <summary>
        /// 同意退学申请，并更改学生的学籍信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public string AgreeCheckOut(string id, string userId, string userName)
        {
            YZJ_CheckRecordModel CheckModel = checkBLL.GetById(id);
            //更改学籍信息
            YZJ_StatusModel StatusModel = statusBLL.GetbyStdRoolId(CheckModel.StdId);
            StatusModel.StatusState = "退学";
            StatusModel.available = false;
            statusBLL.Edit(StatusModel);
            //同意审核
            CheckModel.AssessDate = DateTime.Now.ToString();
            CheckModel.AssessorId = userId;
            CheckModel.AssessorName = userName;
            CheckModel.AssessState = "通过申请";
            var flag = checkBLL.Edit(CheckModel);
            var jsondata = js.Serialize(new { flag = flag });
            return jsondata;
        }

        /// <summary>
        /// 同意跳级申请，并更改学生的基本信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public string AgreeSkip(string id, string userId, string userName)
        {
            YZJ_CheckRecordModel CheckModel = checkBLL.GetById(id);
            //更改学生基本信息
            YZJ_InfoModel inforModel = inforBLL.GetbyStdRoolId(CheckModel.StdId);
            List<string> infor = CheckModel.ApplyType.Split(';').ToList();
            string SkipGradeNum = infor[1].Remove(1);
            string SkipClass = infor[2];
            inforModel.RepeatNo = (Convert.ToInt32(inforModel.RepeatNo) - Convert.ToInt32(SkipGradeNum)).ToString();
            inforModel.ClassNo = SkipClass;
            inforBLL.Edit(inforModel);
            //同意审核
            CheckModel.AssessDate = DateTime.Now.ToString();
            CheckModel.AssessorId = userId;
            CheckModel.AssessorName = userName;
            CheckModel.AssessState = "通过申请";
            var flag = checkBLL.Edit(CheckModel);
            var jsondata = js.Serialize(new { flag = flag });
            return jsondata;
        }
        /// <summary>
        /// 同意休学申请，并更改学生的学籍信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public string AgreeSuspend(string id, string userId, string userName)
        {
            YZJ_CheckRecordModel CheckModel = checkBLL.GetById(id);
            //更改学籍信息
            YZJ_StatusModel StatusModel = statusBLL.GetbyStdRoolId(CheckModel.StdId);
            StatusModel.StatusState = "休学";
            StatusModel.available = false;
            statusBLL.Edit(StatusModel);
            //同意审核
            CheckModel.AssessDate = DateTime.Now.ToString();
            CheckModel.AssessorId = userId;
            CheckModel.AssessorName = userName;
            CheckModel.AssessState = "通过申请";
            var flag = checkBLL.Edit(CheckModel);
            var jsondata = js.Serialize(new { flag = flag });
            return jsondata;
        }
        /// <summary>
        /// 同意转校申请，并更改学生的学籍信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public string AgreeTransferOut(string id, string userId, string userName)
        {
            YZJ_CheckRecordModel CheckModel = checkBLL.GetById(id);
            //更改学籍信息
            YZJ_StatusModel StatusModel = statusBLL.GetbyStdRoolId(CheckModel.StdId);
            StatusModel.StatusState = "转校";
            StatusModel.available = false;
            statusBLL.Edit(StatusModel);
            //同意审核
            CheckModel.AssessDate = DateTime.Now.ToString();
            CheckModel.AssessorId = userId;
            CheckModel.AssessorName = userName;
            CheckModel.AssessState = "通过申请";
            var flag = checkBLL.Edit(CheckModel);
            var jsondata = js.Serialize(new { flag = flag });
            return jsondata;
        }
        /// <summary>
        /// 同意转班申请，并更改学生的基本信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public string AgreeTransferClass(string id, string userId, string userName)
        {
            YZJ_CheckRecordModel CheckModel = checkBLL.GetById(id);
            //更改学生基本信息
            YZJ_InfoModel inforModel = inforBLL.GetbyStdRoolId(CheckModel.StdId);
            List<string> infor = CheckModel.ApplyType.Split(';').ToList();
            string SkipClass = infor[1];
            inforModel.ClassNo = SkipClass;
            inforBLL.Edit(inforModel);
            //同意审核
            CheckModel.AssessDate = DateTime.Now.ToString();
            CheckModel.AssessorId = userId;
            CheckModel.AssessorName = userName;
            CheckModel.AssessState = "通过申请";
            var flag = checkBLL.Edit(CheckModel);
            var jsondata = js.Serialize(new { flag = flag });
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