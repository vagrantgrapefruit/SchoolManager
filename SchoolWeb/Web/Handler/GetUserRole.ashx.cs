using SchoolManager.BLL;
using SchoolManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using SchoolManager.Common;


namespace SchoolWeb.Web.Handler
{
    /// <summary>
    /// GetUserRole 的摘要说明
    /// </summary>
    public class GetUserRole : IHttpHandler
    {

        public SysUserRoleBLL userRoleBLL = new SysUserRoleBLL();
        public JavaScriptSerializer js = new JavaScriptSerializer();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request.QueryString["method"] == "getUser")
            {
                var roleId = context.Request.QueryString["Id"];
                var jsondata = GetUserId(roleId);
                context.Response.Write(jsondata);
            }
            else if(context.Request.QueryString["method"] == "EditUserRole")
            {
                int len = Convert.ToInt32( context.Request.QueryString["length"]);
                var roleId = context.Request.QueryString["RoleId"];
                List<SysUserModel> userList = new List<SysUserModel>();
                for (int i = 0; i < len; i++)
                {
                    userList.Add(new SysUserModel());
                }
                for (int i = 0; i < len; i++)
                {
                    userList[i].UserId = context.Request.QueryString["rows["+i+"]"+"[UserId]"];
                }
                var jsondata = CreateUserRole(userList, roleId,len);
                context.Response.Write(jsondata);
            }
            else
            {
                context.Response.Write("Hello World!");
            }

        }

        public string GetUserId(string roleId)
        {
            List<SysUserRoleModel> list = userRoleBLL.GetByRoleId(roleId);
            List<UserListModel> userList = new List<UserListModel>();
            foreach (var a in list)
            {
                userList.Add(new UserListModel { UserId = a.UserId });     
            }
            var jsondata = js.Serialize(userList);
            return jsondata;
        }

        public string CreateUserRole(List<SysUserModel> userList,string roleId,int len)
        {
            List<SysUserRoleModel> list = userRoleBLL.GetByRoleId(roleId);
            for(int i=0;i<len;i++)
            {
                foreach(var b in list)
                {
                    if (userList[i].UserId == b.UserId)
                    {
                        userList.Remove(userList[i]);
                        i--;
                        len--;
                        break;
                    }
                }
                if (userList.Count == 0)
                    break;
            }
            if (userList.Count != 0)
            {
                foreach (var a in userList)
                {
                    SysUserRoleModel userRoleModel = new SysUserRoleModel();
                    userRoleModel.Id = ResultHelper.NewId;
                    userRoleModel.UserId = a.UserId;
                    userRoleModel.RoleId = roleId;
                    if (!userRoleBLL.Create(userRoleModel))
                    {
                        var json = js.Serialize(new { flag = false });
                        return json;
                    }
                }
                var jsondata = js.Serialize(new { flag = true });
                return jsondata;
            }
            else
            {
                var jsondata = js.Serialize(new { flag = false });
                return jsondata;
            }
                
        }
        //public string GetDepartment(int limit, int offset, string departmentname, string statu)
        //{

        //    List<SysRoleModel> modelList = userBLL.GetList("");

        //    var total = modelList.Count;
        //    var rows = modelList.Skip(offset).Take(limit).ToList();


        //    var jsondata = js.Serialize(new { total = total, rows = rows });
        //    return jsondata;
        //}
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}