using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Services;
using System.Web.UI.WebControls;
using SchoolManager.Models;
using SchoolManager.BLL;

namespace SchoolWeb
{
    public partial class Login : System.Web.UI.Page
    {
       static SysUserBLL userBLL = new SysUserBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["method"]!=null)
            {
                if (Request.QueryString["method"]=="login")
                {
                    if(login(Request.QueryString["UserName"], Request.QueryString["Password"]))
                    {
                        Response.Clear();
                        Response.Write("{\"flag\":\"1\" }");
                        Response.End();
                    }
                    else
                    {
                        Response.Clear();
                        Response.Write("{\"flag\":\"0\" }");
                        Response.End();
                    }

                }
            }

        }

 /// <summary>
 /// 登陆验证
 /// </summary>
 /// <param name="UserName"></param>
 /// <param name="Password"></param>
        public bool login(string UserName ,string Password)
        {

            try
            {
                SysUserModel model = userBLL.GetById(UserName);
                if (model.PassWord == Password)
                {
                    Session["UserName"] = UserName;
                    Session["SchoolCard"] = model.SchoolCard;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }


    }
}