using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManager.BLL;
using SchoolManager.Models;
using System.Web.Script.Serialization;

namespace SchoolWeb.ModuleManager
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //var method = Request.QueryString["method"];
            if (Request.QueryString["method"] != null) 
            {
                switch (Request.QueryString["method"])
                {
                    case "GetTreeList":
                        {
                            var userName = Request.QueryString["userName"];
                            GetTreeList(userName);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public void GetTreeList(string userName)
        {
            SysUserRoleBLL sysUserRoleBLL = new SysUserRoleBLL();
            SysPermissionBLL sysPermissionBLL = new SysPermissionBLL();
            List<SysUserRoleModel> userRoleModelList = sysUserRoleBLL.GetByUserId(userName);
            List<SysPermissionModel> permissionList = new List<SysPermissionModel>();
            foreach (var a in userRoleModelList)
            {
                permissionList.AddRange(sysPermissionBLL.GetByRoleId(a.RoleId));
            }
            GetTree(permissionList);
        }
        public void GetTree(List<SysPermissionModel> permissionList)
        {             
            SysModuleBLL moduleBLL = new SysModuleBLL();
            List<SysModuleModel> model = new List<SysModuleModel>();
            foreach (var a in permissionList)
            {
                model.AddRange(moduleBLL.GetByModuleId(a.ModuleId)); 
            }
            List<SysModuleModel> rootModel = (from r in model where r.ParentId == "0" select r).ToList();
            rootModel = rootModel
                .GroupBy(a => new SysModuleModel())
                .Select(b => b.First())
                .ToList();
            var json = new
            {
                head = (from r in rootModel
                        orderby r.Id ascending
                        select new ShowModel
                        {
                            IsShow = r.IsShow,
                            content = (from n in (from m in model where m.ParentId == r.ModuleId select m)
                                       select new Show
                                       {
                                           title = n.ModuleName,
                                           url = n.ModuleURL,
                                           count = "0",
                                           IsShow = n.IsShow,
                                       }).ToList(),
                            count = "0",
                            title = r.ModuleName,
                        }
                        )
            };
            JavaScriptSerializer js = new JavaScriptSerializer();
            var jsondata = js.Serialize(json);
            Response.Clear();
            Response.Write(jsondata);
            Response.End();
        }
    }
}