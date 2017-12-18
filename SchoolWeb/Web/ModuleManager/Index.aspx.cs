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
                        GetTreeList();
                        break;
                    default:
                        break;
                }
            }
        }

        public void GetTreeList()
        {
            SysModuleBLL moduleBLL = new SysModuleBLL();
            List<SysModuleModel> model = moduleBLL.GetList(null);
            List<SysModuleModel> rootModel = (from r in model where r.ParentId == "0" select r).ToList();
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