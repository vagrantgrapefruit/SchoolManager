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
    /// EditUser 的摘要说明
    /// </summary>
    public class EditUser : IHttpHandler
    {

        public SysUserBLL moduleBLL = new SysUserBLL();
        public JavaScriptSerializer js = new JavaScriptSerializer();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            SysUserModel moduleModel = new SysUserModel();
            if (context.Request.QueryString["method"] == "SaveUser")
            {
                moduleModel.UserId = context.Request.QueryString["UserId"];
                moduleModel.UserName = context.Request.QueryString["UserName"];
                moduleModel.PassWord = context.Request.QueryString["PassWord"];
                moduleModel.PhoneNumber = context.Request.QueryString["PhoneNumber"];
                moduleModel.SchoolCard = context.Request.QueryString["SchoolCard"];
                moduleModel.Sex = (context.Request.QueryString["Sex"]);
                moduleModel.DepId = (context.Request.QueryString["DepId"]);
                moduleModel.PosId = (context.Request.QueryString["PosId"]);
                var jsondata = NewModule(moduleModel);
                context.Response.Clear();
                context.Response.Write(jsondata);
                context.Response.End();
            }
            else if (context.Request.QueryString["method"] == "EditUser")
            {
                moduleModel.UserId = context.Request.QueryString["UserId"];
                moduleModel.UserName = context.Request.QueryString["UserName"];
                moduleModel.PassWord = context.Request.QueryString["PassWord"];
                moduleModel.PhoneNumber = context.Request.QueryString["PhoneNumber"];
                moduleModel.SchoolCard = context.Request.QueryString["SchoolCard"];
                moduleModel.Sex = (context.Request.QueryString["Sex"]);
                moduleModel.DepId = (context.Request.QueryString["DepId"]);
                moduleModel.PosId = (context.Request.QueryString["PosId"]);
                var jsondata = EditModule(moduleModel);
                context.Response.Clear();
                context.Response.Write(jsondata);
                context.Response.End();
            }
            else if (context.Request.QueryString["0"] != null)
            {
                moduleModel.UserId = context.Request.QueryString["UserId"];
                moduleModel.UserName = context.Request.QueryString["UserName"];
                moduleModel.PassWord = context.Request.QueryString["PassWord"];
                moduleModel.PhoneNumber = context.Request.QueryString["PhoneNumber"];
                moduleModel.SchoolCard = context.Request.QueryString["SchoolCard"];
                moduleModel.Sex = (context.Request.QueryString["Sex"]);
                moduleModel.DepId = (context.Request.QueryString["DepId"]);
                moduleModel.PosId = (context.Request.QueryString["PosId"]);
                var jsondata = returnjson(moduleModel);
                context.Response.Clear();
                context.Response.Write(jsondata);
                context.Response.End();
            }


        }

        public string NewModule(SysUserModel model)
        {
            var a = moduleBLL.Create(model);
            var jsondata = js.Serialize(new { flag = a });
            return jsondata;

        }

        public string returnjson(SysUserModel model)
        {
            var jsondata = js.Serialize(model);
            return jsondata;
        }

        public string EditModule(SysUserModel model)
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