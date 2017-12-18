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
            //else if(context.Request.QueryString["ModuleId"] != null)
            //{
            //    moduleModel.ModuleId = context.Request.QueryString["ModuleId"];
            //    moduleModel.ModuleName = context.Request.QueryString["ModuleName"];
            //    moduleModel.ModuleName = context.Request.QueryString["ModuleName"];
            //    moduleModel.ModuleName = context.Request.QueryString["ModuleName"];
            //    moduleModel.ModuleName = context.Request.QueryString["ModuleName"];
            //    moduleModel.ModuleName = context.Request.QueryString["ModuleName"];
            //    moduleModel.ModuleName = context.Request.QueryString["ModuleName"];
            //}

        }

        public string NewModule(SysModuleModel model)
        {
           var a= moduleBLL.Create(model);
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