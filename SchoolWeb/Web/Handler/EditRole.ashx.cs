using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolManager.Models;
using SchoolManager.BLL;
using System.Web.Script.Serialization;
using SchoolManager.Common;

namespace SchoolWeb.Web.Handler
{
    /// <summary>
    /// EditRole 的摘要说明
    /// </summary>
    public class EditRole : IHttpHandler
    {

        public SysRoleBLL moduleBLL = new SysRoleBLL();
        public JavaScriptSerializer js = new JavaScriptSerializer();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            SysRoleModel roleModel = new SysRoleModel();
            if (context.Request.QueryString["method"] == "SaveRole")
            {
                roleModel.Id = ResultHelper.NewId;
                roleModel.RoleId = context.Request.QueryString["RoleId"];
                roleModel.RoleName = context.Request.QueryString["RoleName"];
                roleModel.IsShow = Convert.ToBoolean(context.Request.QueryString["IsShow"]);
                var jsondata = NewModule(roleModel);
                context.Response.Clear();
                context.Response.Write(jsondata);
                context.Response.End();
            }
            else if (context.Request.QueryString["method"] == "EditUser")
            {
                roleModel.Id = context.Request.QueryString["Id"];
                roleModel.RoleId = context.Request.QueryString["RoleId"];
                roleModel.RoleName = context.Request.QueryString["RoleName"];
                roleModel.IsShow = Convert.ToBoolean(context.Request.QueryString["IsShow"]);
                var jsondata = EditModule(roleModel);
                context.Response.Clear();
                context.Response.Write(jsondata);
                context.Response.End();
            }
            else if (context.Request.QueryString["0"] != null)
            {
                roleModel.Id = context.Request.QueryString["Id"];
                roleModel.RoleId = context.Request.QueryString["RoleId"];
                roleModel.RoleName = context.Request.QueryString["RoleName"];
                roleModel.IsShow = Convert.ToBoolean(context.Request.QueryString["IsShow"]);
                var jsondata = returnjson(roleModel);
                context.Response.Clear();
                context.Response.Write(jsondata);
                context.Response.End();
            }


        }

        public string NewModule(SysRoleModel model)
        {
            var a = moduleBLL.Create(model);
            var jsondata = js.Serialize(new { flag = a });
            return jsondata;

        }

        public string returnjson(SysRoleModel model)
        {
            var jsondata = js.Serialize(model);
            return jsondata;
        }

        public string EditModule(SysRoleModel model)
        {
            var a = moduleBLL.Edit(model);
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