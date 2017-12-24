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
    /// GetStatus 的摘要说明
    /// </summary>
    public class GetStatus : IHttpHandler
    {
        public YZJ_StatusBLL StatusBLL = new YZJ_StatusBLL();
        public JavaScriptSerializer js = new JavaScriptSerializer();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            
            if(context.Request.QueryString["search"] != null)
            {
                var limit = int.Parse(context.Request.QueryString["limit"]);
                var offset = int.Parse(context.Request.QueryString["offset"]);
                var departmentname = context.Request.QueryString["departmentname"];
                var statu = context.Request.QueryString["statu"];
                var search= context.Request.QueryString["search"];
                var jsondata = GetStatusBySearch(limit, offset, departmentname, statu, search);
                context.Response.Write(jsondata);

            }
            else if (context.Request.QueryString["limit"] != null)
            {
                var limit = int.Parse(context.Request.QueryString["limit"]);
                var offset = int.Parse(context.Request.QueryString["offset"]);
                var departmentname = context.Request.QueryString["departmentname"];
                var statu = context.Request.QueryString["statu"];
                var jsondata = GetStatusInfor(limit, offset, departmentname, statu);
                context.Response.Write(jsondata);
            }
            else if (context.Request.QueryString["method"] == "Getinfor")
            {
                var id = context.Request.QueryString["id"];
                var jsondata = GetStatusById(id);
                context.Response.Write(jsondata);
            }
        }

        public string GetStatusInfor(int limit, int offset, string departmentname, string statu)
        {

            List<YZJ_StatusModel> modelList = StatusBLL.GetList("");

            var total = modelList.Count;
            var rows = modelList.Skip(offset).Take(limit).ToList();


            var jsondata = js.Serialize(new { total = total, rows = rows });
            return jsondata;
        }
        public string GetStatusBySearch(int limit, int offset, string departmentname, string statu,string search)
        {

            List<YZJ_StatusModel> modelList = StatusBLL.GetList(search);

            var total = modelList.Count;
            var rows = modelList.Skip(offset).Take(limit).ToList();


            var jsondata = js.Serialize(new { total = total, rows = rows });
            return jsondata;
        }
        public string GetStatusById(string id)
        {
            YZJ_StatusModel modelList = StatusBLL.GetById(id);
            var jsondata = js.Serialize(modelList);
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