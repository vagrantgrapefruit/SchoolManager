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
    /// DeleteUser 的摘要说明
    /// </summary>
    public class DeleteUser : IHttpHandler
    {

        public SysUserBLL moduleBLL = new SysUserBLL();
        public JavaScriptSerializer js = new JavaScriptSerializer();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            SysUserModel moduleModel = new SysUserModel();
            if (context.Request.QueryString["0"] != null)
            {
                moduleModel.UserId = context.Request.QueryString["UserId"];
                moduleModel.UserName = context.Request.QueryString["UserName"];
                moduleModel.PassWord = context.Request.QueryString["PassWord"];
                moduleModel.PhoneNumber = context.Request.QueryString["PhoneNumber"];
                moduleModel.SchoolCard = context.Request.QueryString["SchoolCard"];
                moduleModel.Sex = (context.Request.QueryString["Sex"]);
                moduleModel.DepId = (context.Request.QueryString["DepId"]);
                moduleModel.PosId = (context.Request.QueryString["PosId"]);
                var jsondata = delete(moduleModel);
                context.Response.Clear();
                context.Response.Write(jsondata);
                context.Response.End();
            }
            context.Response.Write("Hello World");
        }

        public string delete(SysUserModel model)
        {
            var a = moduleBLL.Delete(model.UserId);
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