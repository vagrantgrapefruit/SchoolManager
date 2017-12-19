using SchoolManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.BLL
{
     public partial class SysModuleBLL
    {
        public virtual List<SysModuleModel> GetByModuleId(string moduleId)
        {

            IQueryable<tbl_SysModule> queryData = null;
            if (!string.IsNullOrWhiteSpace(moduleId))
            {
                queryData = m_Rep.GetList(
                                a => (a.ModuleId != null && a.ModuleId == moduleId)
                                );
            }
            else
            {
                return null;
            }
            return CreateModelList(ref queryData);
        }
    }
}
