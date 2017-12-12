using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolManager.Models;
using SchoolManager.BLL;
using System.Web.Script.Serialization;

namespace SchoolWeb.Web.ModuleManager
{
    /// <summary>
    /// GetModel 的摘要说明
    /// </summary>
    public class GetModel : IHttpHandler
    {
        public SysModuleBLL moduleBLL = new SysModuleBLL();
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
                var jsondata = GetDepartment(limit, offset, departmentname, statu);
                context.Response.Write(jsondata);
            }
            else if (context.Request.QueryString["method"] =="getParent")
            {
                var jsondata = GetParentId();
                context.Response.Write(jsondata);
            }
            else
            {
                context.Response.Write("Hello World!");
            }
            
        }

        public string GetDepartment(int limit, int offset, string departmentname, string statu)
        {
            
            List<SysModuleModel> modelList = (from m in moduleBLL.GetList("") orderby m.Sort ascending select m).ToList();

            var total = modelList.Count;
            var rows = modelList.Skip(offset).Take(limit).ToList();


            var jsondata = js.Serialize(new { total = total, rows = rows });
            return jsondata;
        }

        public string GetParentId()
        {
            List<SysModuleModel> modelList = (from m in moduleBLL.GetList("") where m.IsLast==false select m).ToList();
            List<string> parentList = new List<string>();
            foreach(var a in modelList)
            {
                parentList.Add(a.ModuleId);
            }
            var jsondata = js.Serialize(new { list = parentList });
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