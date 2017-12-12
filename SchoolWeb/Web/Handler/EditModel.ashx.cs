using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolManager.Models;

namespace SchoolWeb.Web.Handler
{
    /// <summary>
    /// EditModel 的摘要说明
    /// </summary>
    public class EditModel : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            SysModuleModel moduleModel = new SysModuleModel();
            if(context.Request.QueryString["ModuleId"] != null)
            {
                moduleModel.ModuleId = context.Request.QueryString["ModuleId"].ToString();
                moduleModel.ModuleName= context.Request.QueryString["ModuleName"].ToString();
                moduleModel.ModuleName = context.Request.QueryString["ModuleName"].ToString();
                moduleModel.ModuleName = context.Request.QueryString["ModuleName"].ToString();
                moduleModel.ModuleName = context.Request.QueryString["ModuleName"].ToString();
                moduleModel.ModuleName = context.Request.QueryString["ModuleName"].ToString();
                moduleModel.ModuleName = context.Request.QueryString["ModuleName"].ToString();
            }
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