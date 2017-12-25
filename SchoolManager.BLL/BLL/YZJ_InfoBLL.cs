using SchoolManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.BLL
{
    public partial class YZJ_InfoBLL
    {
        public  YZJ_InfoModel GetbyStdRoolId(string id)
        {
            IQueryable<YZJ_Info> queryData = null;
            if (!string.IsNullOrWhiteSpace(id))
            {
                queryData = m_Rep.GetList(
                                a => (a.StdRollId != null && a.StdRollId==id)
                                );
            }
            else
            {
                queryData = m_Rep.GetList();
            }
            List<YZJ_InfoModel> list= CreateModelList(ref queryData);
            return list[0];
        }
        public YZJ_InfoModel GetbyStdId(string id)
        {
            IQueryable<YZJ_Info> queryData = null;
            if (!string.IsNullOrWhiteSpace(id))
            {
                queryData = m_Rep.GetList(
                                a => (a.StdId != null && a.StdId == id)
                                );
            }
            else
            {
                queryData = m_Rep.GetList();
            }
            List<YZJ_InfoModel> list = CreateModelList(ref queryData);
            return list[0];
        }
    }
}
