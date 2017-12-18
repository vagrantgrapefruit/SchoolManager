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
    /// EditModel 的摘要说明
    /// </summary>
    public class EditModel : IHttpHandler
    {
        public SysModuleBLL moduleBLL = new SysModuleBLL();
        public JavaScriptSerializer js = new JavaScriptSerializer();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            SysModuleModel moduleModel = new SysModuleModel();
            if(context.Request.QueryString["method"] == "SaveModel")
            {
                moduleModel.Id = ResultHelper.NewId;
                moduleModel.ModuleId = context.Request.QueryString["ModuleId"];
                moduleModel.ModuleName = context.Request.QueryString["ModuleName"];
                moduleModel.ModuleURL = context.Request.QueryString["ModuleURL"];
                moduleModel.ParentId = context.Request.QueryString["ParentId"];
                moduleModel.IsLast = Convert.ToBoolean(context.Request.QueryString["IsLast"]);
                moduleModel.IsShow = Convert.ToBoolean(context.Request.QueryString["IsShow"]);
                var jsondata = NewModule(moduleModel);
                context.Response.Clear();
                context.Response.Write(jsondata);
                context.Response.End();
            }
            else if (context.Request.QueryString["0"] != null)
            {
                moduleModel.Id= context.Request.QueryString["Id"];
                moduleModel.ModuleId = context.Request.QueryString["ModuleId"];
                moduleModel.ModuleName = context.Request.QueryString["ModuleName"];
                moduleModel.ParentId = context.Request.QueryString["ParentId"];
                moduleModel.ModuleURL = context.Request.QueryString["ModuleURL"];
                moduleModel.IsShow = Convert.ToBoolean(context.Request.QueryString["IsShow"]);
                moduleModel.IsLast = Convert.ToBoolean(context.Request.QueryString["IsLast"]);
                var jsondata = returnjson(moduleModel);
                context.Response.Clear();
                context.Response.Write(jsondata);
                context.Response.End();
            }
            else if (context.Request.QueryString["method"] == "EditModel")
            {
                moduleModel.Id = context.Request.QueryString["Id"];
                moduleModel.ModuleId = context.Request.QueryString["ModuleId"];
                moduleModel.ModuleName = context.Request.QueryString["ModuleName"];
                moduleModel.ParentId = context.Request.QueryString["ParentId"];
                moduleModel.ModuleURL = context.Request.QueryString["ModuleURL"];
                moduleModel.IsShow = Convert.ToBoolean(context.Request.QueryString["IsShow"]);
                moduleModel.IsLast = Convert.ToBoolean(context.Request.QueryString["IsLast"]);
                var jsondata = EditModule(moduleModel);
                context.Response.Clear();
                context.Response.Write(jsondata);
                context.Response.End();
            }

        }

        public string NewModule(SysModuleModel model)
        {
           var a= moduleBLL.Create(model);
           var jsondata = js.Serialize(new { flag = a });
           return jsondata;

        }

        public string returnjson(SysModuleModel model)
        {
            var jsondata = js.Serialize(model);
            return jsondata;
        }

        public string EditModule(SysModuleModel model)
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