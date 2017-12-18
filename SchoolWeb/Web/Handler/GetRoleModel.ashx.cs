using SchoolManager.BLL;
using SchoolManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace SchoolWeb.Web.Handler
{
    /// <summary>
    /// GetRoleModel 的摘要说明
    /// </summary>
    public class GetRoleModel : IHttpHandler
    {

        public SysRoleBLL userBLL = new SysRoleBLL();
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
            else
            {
                context.Response.Write("Hello World!");
            }

        }

        public string GetDepartment(int limit, int offset, string departmentname, string statu)
        {

            List<SysRoleModel> modelList = userBLL.GetList("");

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