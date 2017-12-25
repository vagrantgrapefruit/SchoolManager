using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolManager.Models;
using SchoolManager.BLL;
using System.Web.Script.Serialization;

namespace SchoolWeb.Web.Handler
{
    /// <summary>
    /// GetCheckRecord 的摘要说明
    /// </summary>
    public class GetCheckRecord : IHttpHandler
    {
        public YZJ_CheckRecordBLL checkBLL = new YZJ_CheckRecordBLL();
        public JavaScriptSerializer js = new JavaScriptSerializer();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request.QueryString["limit"] != null)
            {
                var limit = int.Parse(context.Request.QueryString["limit"]);
                var offset = int.Parse(context.Request.QueryString["offset"]);
                var departmentname = context.Request.QueryString["departmentname"];
                var statu = context.Request.QueryString["statu"];
                var param = context.Request.QueryString["Param"];
                switch(param)
                {
                    case ("Dismiss"):
                        {
                            var jsondata = getCheckRecord(limit, offset, departmentname, statu, "开除");
                            context.Response.Write(jsondata);
                            break;
                        }
                    case ("DropOut"):
                        {
                            var jsondata = getCheckRecord(limit, offset, departmentname, statu, "退学");
                            context.Response.Write(jsondata);
                            break;
                        }
                    case ("RepeatGrade"):
                        {
                            var jsondata = getCheckRecord(limit, offset, departmentname, statu, "留级");
                            context.Response.Write(jsondata);
                            break;
                        }
                    case ("Skip"):
                        {
                            var jsondata = getCheckRecord(limit, offset, departmentname, statu, "跳级");
                            context.Response.Write(jsondata);
                            break;
                        }
                    case ("Suspend"):
                        {
                            var jsondata = getCheckRecord(limit, offset, departmentname, statu, "休学");
                            context.Response.Write(jsondata);
                            break;
                        }
                    case ("TransferOut"):
                        {
                            var jsondata = getCheckRecord(limit, offset, departmentname, statu, "转校");
                            context.Response.Write(jsondata);
                            break;
                        }
                    case ("TransferClass"):
                        {
                            var jsondata = getCheckRecord(limit, offset, departmentname, statu, "转班");
                            context.Response.Write(jsondata);
                            break;
                        }
                        


                    default:
                        break;
                }
            }
        }
        /// <summary>
        /// 获取申请记录
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="departmentname"></param>
        /// <param name="statu"></param>
        /// <param name="param">申请类别</param>
        /// <returns></returns>
        public string getCheckRecord(int limit, int offset, string departmentname, string statu ,string param)
        {
            List<YZJ_CheckRecordModel> modelList = checkBLL.GetList(param);

            var total = modelList.Count;
            var rows = modelList.Skip(offset).Take(limit).ToList();
            var jsondata = js.Serialize(new { total = total, rows = rows });
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