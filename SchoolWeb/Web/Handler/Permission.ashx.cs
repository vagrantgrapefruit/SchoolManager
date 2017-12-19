using SchoolManager.BLL;
using SchoolManager.Common;
using SchoolManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace SchoolWeb.Web.Handler
{
    /// <summary>
    /// Permission 的摘要说明
    /// </summary>
    public class Permission : IHttpHandler
    {

        public SysPermissionBLL sysPermissionBLL = new SysPermissionBLL();
        public JavaScriptSerializer js = new JavaScriptSerializer();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request.QueryString["method"] == "getModule")
            {
                var roleId = context.Request.QueryString["RoleId"];
                var jsondata = GetModuleId(roleId);
                context.Response.Write(jsondata);
            }
            else if (context.Request.QueryString["method"] == "EditPermission")
            {
                int len = Convert.ToInt32(context.Request.QueryString["length"]);
                var roleId = context.Request.QueryString["roleId"];
                List<SysModuleModel> moduleList = new List<SysModuleModel>();
                for (int i = 0; i < len; i++)
                {
                    moduleList.Add(new SysModuleModel());
                }
                for (int i = 0; i < len; i++)
                {
                    moduleList[i].ModuleId = context.Request.QueryString["rows[" + i + "][UserId]"];
                    //;
                }
                List<SysPermissionModel> list = sysPermissionBLL.GetByRoleId(roleId);
                if (len == 0)
                {
                    var jsondata = DeleteUserRole(list);
                    context.Response.Write(jsondata);
                }
                else
                {
                    var jsondata = CreateUserRole(moduleList, roleId, len);
                    context.Response.Write(jsondata);
                }
            }
            else
            {
                context.Response.Write("Hello World!");
            }

        }

        public string GetModuleId(string roleId)
        {
            List<SysPermissionModel> list = sysPermissionBLL.GetByRoleId(roleId);
            List<SysModuleModel> moduleList = new List<SysModuleModel>();
            foreach (var a in list)
            {
                moduleList.Add(new SysModuleModel { ModuleId = a.ModuleId });
            }
            var jsondata = js.Serialize(moduleList);
            return jsondata;
        }

        /// <summary>
        /// 新增或更改角色的用户
        /// </summary>
        /// <param name="userList"></param>
        /// <param name="roleId"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public string CreateUserRole(List<SysModuleModel> moduleList, string roleId, int len)
        {
            List<SysPermissionModel> list = sysPermissionBLL.GetByRoleId(roleId);
            //去除已有的不需更改的记录
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    if (moduleList[i].ModuleId == list[j].ModuleId)
                    {
                        moduleList.Remove(moduleList[i]);
                        list.Remove(list[j]);
                        i--;
                        len--;
                        break;
                    }
                }
                if (moduleList.Count == 0)
                    break;
            }
            if (list.Count != 0)
            {
                foreach (var a in list)
                {
                    if (!sysPermissionBLL.Delete(a.Id))
                    {
                        var json = js.Serialize(new { flag = false });
                        return json;
                    }
                }
            }
            if (moduleList.Count != 0)
            {
                foreach (var a in moduleList)
                {
                    SysPermissionModel permissionModel = new SysPermissionModel();
                    permissionModel.Id = ResultHelper.NewId;
                    permissionModel.ModuleId = a.ModuleId;
                    permissionModel.RoleId = roleId;
                    permissionModel.IsShow = true;
                    if (!sysPermissionBLL.Create(permissionModel))
                    {
                        var json = js.Serialize(new { flag = false });
                        return json;
                    }
                }
                var jsondata = js.Serialize(new { flag = true });
                return jsondata;
            }
            else if (list.Count == 0)
            {
                var jsondata = js.Serialize(new { flag = false });
                return jsondata;
            }
            else
            {
                var jsondata = js.Serialize(new { flag = true });
                return jsondata;
            }

        }

        /// <summary>
        /// 删除所有对应角色的用户
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public string DeleteUserRole(List<SysPermissionModel> list)
        {
            foreach (var a in list)
            {
                if (!sysPermissionBLL.Delete(a.Id))
                {
                    var json = js.Serialize(new { flag = false });
                    return json;
                }
            }
            var jsondata = js.Serialize(new { flag = true });
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