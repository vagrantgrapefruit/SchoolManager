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
                return null;
            }
            return CreateModelList(ref queryData);
        }
        public virtual List<SysUserRoleModel> GetByUserId(string userId)
        {

            IQueryable<tbl_SysUserRole> queryData = null;
            if (!string.IsNullOrWhiteSpace(userId))
            {
                queryData = m_Rep.GetList(
                                a => (a.UserId != null && a.UserId == userId)
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
