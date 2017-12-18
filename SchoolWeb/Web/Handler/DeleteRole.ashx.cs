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
    /// DeleteRole 的摘要说明
    /// </summary>
    public class DeleteRole : IHttpHandler
    {

        public SysRoleBLL roleBLL = new SysRoleBLL();
        public JavaScriptSerializer js = new JavaScriptSerializer();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            SysRoleModel roleModel = new SysRoleModel();
            if (context.Request.QueryString["0"] != null)
            {
                roleModel.Id = context.Request.QueryString["Id"];
                roleModel.RoleId = context.Request.QueryString["RoleId"];
                roleModel.RoleName = context.Request.QueryString["RoleName"];
                roleModel.IsShow = Convert.ToBoolean(context.Request.QueryString["IsShow"]);
                var jsondata = delete(roleModel);
                context.Response.Clear();
                context.Response.Write(jsondata);
                context.Response.End();
            }
            context.Response.Write("Hello World");
        }

        public string delete(SysRoleModel model)
        {
            var a = roleBLL.Delete(model.Id);
            var jsondata = js.Serialize(new { flag = a });
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