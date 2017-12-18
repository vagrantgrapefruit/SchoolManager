using SchoolManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.BLL
{
    public partial class SysUserRoleBLL
    {
        public virtual List<SysUserRoleModel> GetByRoleId(string roleId)
        {

            IQueryable<tbl_SysUserRole> queryData = null;
            if (!string.IsNullOrWhiteSpace(roleId))
            {
                queryData = m_Rep.GetList(
                                a => (a.RoleId != null && a.RoleId==roleId)
                                );
            }
            else
            {
                queryData = m_Rep.GetList();
            }
            return CreateModelList(ref queryData);
        }
    }
}
