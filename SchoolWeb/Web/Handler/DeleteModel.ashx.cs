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
    /// DeleteModel 的摘要说明
    /// </summary>
    public class DeleteModel : IHttpHandler
    {
        public SysModuleBLL moduleBLL = new SysModuleBLL();
        public JavaScriptSerializer js = new JavaScriptSerializer();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            SysModuleModel moduleModel = new SysModuleModel();
            if (context.Request.QueryString["0"] != null)
            {
                moduleModel.Id = context.Request.QueryString["Id"];
                moduleModel.ModuleId = context.Request.QueryString["ModuleId"];
                moduleModel.ModuleName = context.Request.QueryString["ModuleName"];
                moduleModel.ParentId = context.Request.QueryString["ParentId"];
                moduleModel.ModuleURL = context.Request.QueryString["ModuleURL"];
                moduleModel.IsShow = Convert.ToBoolean(context.Request.QueryString["IsShow"]);
                moduleModel.IsLast = Convert.ToBoolean(context.Request.QueryString["IsLast"]);
                var jsondata = delete(moduleModel);
                context.Response.Clear();
                context.Response.Write(jsondata);
                context.Response.End();
            }
            context.Response.Write("Hello World");
        }

        public string delete(SysModuleModel model)
        {
            var a = moduleBLL.Delete(model.Id);
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