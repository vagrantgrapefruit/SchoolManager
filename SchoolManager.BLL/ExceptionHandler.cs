using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManager.DAL;
using System.Web;
using System.IO;
using SchoolManager.Models;
using SchoolManager.Common;


namespace SchoolManager.BLL
{
    public static class ExceptionHandler
    {
        public static void WriteException(Exception ex)
        {
            try
            {
                using (DbContainer db = new DbContainer())
                {
                    tbl_SysException entity = new tbl_SysException()
                    {
                        Id = ResultHelper.NewId,
                        HelpLink = ex.HelpLink,
                        Message = ex.Message,
                        Source = ex.Source,
                        StackTrace = ex.StackTrace,
                        TargetSite = ex.TargetSite.ToString(),
                        Data = ex.Data.ToString(),
                        CreateTime = ResultHelper.NowTime
                    };
                    db.Set<tbl_SysException>().Add(entity);
                    db.SaveChanges();
                }
            }
            catch
            {
                try
                {

                    //将异常失败写入txt
                    //string path = "~/exceptionLog.txt";
                    //string txtPath = System.Web.HttpContext.Current.Server.MapPath(path);
                    //using (StreamWriter sw = new StreamWriter(txtPath, true, Encoding.Default))
                    //{
                    //    sw.WriteLine((ex.Message + "|" + ex.StackTrace + "|" + ep.Message + "|" + DateTime.Now.ToString()).ToString());
                    //    sw.Dispose();
                    //    sw.Close();
                    //}
                }
                catch
                {
                    return;
                }
            }
        }
    }
}
