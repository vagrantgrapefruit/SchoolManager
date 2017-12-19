using SchoolManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.BLL
{
   public partial class SysPermissionBLL
    {

        public virtual List<SysPermissionModel> GetByRoleId(string roleId)
        {

            IQueryable<tbl_SysPermission> queryData = null;
            if (!string.IsNullOrWhiteSpace(roleId))
            {
                queryData = m_Rep.GetList(
                                a => (a.RoleId != null && a.RoleId == roleId)
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
