﻿using SchoolManager.BLL;
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
            SysUserModel userModel = new SysUserModel();
            if (context.Request.QueryString["0"] != null)
            {
                userModel.UserId = context.Request.QueryString["UserId"];
                userModel.UserName = context.Request.QueryString["UserName"];
                userModel.PassWord = context.Request.QueryString["PassWord"];
                userModel.PhoneNumber = context.Request.QueryString["PhoneNumber"];
                userModel.SchoolCard = context.Request.QueryString["SchoolCard"];
                userModel.Sex = (context.Request.QueryString["Sex"]);
                userModel.DepId = (context.Request.QueryString["DepId"]);
                userModel.PosId = (context.Request.QueryString["PosId"]);
                var jsondata = delete(userModel);
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