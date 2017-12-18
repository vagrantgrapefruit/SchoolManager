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
            SysUserModel userModel = new SysUserModel();
            if (context.Request.QueryString["method"] == "SaveUser")
            {
                userModel.UserId = context.Request.QueryString["UserId"];
                userModel.UserName = context.Request.QueryString["UserName"];
                userModel.PassWord = context.Request.QueryString["PassWord"];
                userModel.PhoneNumber = context.Request.QueryString["PhoneNumber"];
                userModel.SchoolCard = context.Request.QueryString["SchoolCard"];
                userModel.Sex = (context.Request.QueryString["Sex"]);
                userModel.DepId = (context.Request.QueryString["DepId"]);
                userModel.PosId = (context.Request.QueryString["PosId"]);
                var jsondata = NewModule(userModel);
                context.Response.Clear();
                context.Response.Write(jsondata);
                context.Response.End();
            }
            else if (context.Request.QueryString["method"] == "EditUser")
            {
                userModel.UserId = context.Request.QueryString["UserId"];
                userModel.UserName = context.Request.QueryString["UserName"];
                userModel.PassWord = context.Request.QueryString["PassWord"];
                userModel.PhoneNumber = context.Request.QueryString["PhoneNumber"];
                userModel.SchoolCard = context.Request.QueryString["SchoolCard"];
                userModel.Sex = (context.Request.QueryString["Sex"]);
                userModel.DepId = (context.Request.QueryString["DepId"]);
                userModel.PosId = (context.Request.QueryString["PosId"]);
                var jsondata = EditModule(userModel);
                context.Response.Clear();
                context.Response.Write(jsondata);
                context.Response.End();
            }
            else if (context.Request.QueryString["0"] != null)
            {
                userModel.UserId = context.Request.QueryString["UserId"];
                userModel.UserName = context.Request.QueryString["UserName"];
                userModel.PassWord = context.Request.QueryString["PassWord"];
                userModel.PhoneNumber = context.Request.QueryString["PhoneNumber"];
                userModel.SchoolCard = context.Request.QueryString["SchoolCard"];
                userModel.Sex = (context.Request.QueryString["Sex"]);
                userModel.DepId = (context.Request.QueryString["DepId"]);
                userModel.PosId = (context.Request.QueryString["PosId"]);
                var jsondata = returnjson(userModel);
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