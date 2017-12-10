//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using SchoolManager.Models;
using SchoolManager.Common;
using Microsoft.Practices.Unity;
using System.Transactions;
using SchoolManager.DAL;
using SchoolManager.BLL;
using Unity.Attributes;

namespace SchoolManager.BLL
{
	public class Virtual_SysRoleBLL
	{

        public SysRoleRepository m_Rep =new SysRoleRepository(new DbContainer());

		public virtual List<SysRoleModel> GetList( string queryStr)
        {

            IQueryable<tbl_SysRole> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = m_Rep.GetList(
								a=>(a.RoleId!=null && a.RoleId.Contains(queryStr))
								|| (a.RoleName!=null && a.RoleName.Contains(queryStr))
								
								
								);
            }
            else
            {
                queryData = m_Rep.GetList();
            }
            return CreateModelList(ref queryData);
        }

        public virtual List<SysRoleModel> CreateModelList(ref IQueryable<tbl_SysRole> queryData)
        {

            List<SysRoleModel> modelList = (from r in queryData
                                              select new SysRoleModel
                                              {
													RoleId = r.RoleId,
													RoleName = r.RoleName,
													Sort = r.Sort,
													IsShow = r.IsShow,
          
                                              }).ToList();

            return modelList;
        }

        public virtual bool Create(ref ValidationErrors errors, SysRoleModel model)
        {
            try
            {
                tbl_SysRole entity = m_Rep.GetById(model.RoleId);
                if (entity != null)
                {
                    errors.Add(Suggestion.PrimaryRepeat);
                    return false;
                }
                entity = new tbl_SysRole();
               				entity.RoleId = model.RoleId;
				entity.RoleName = model.RoleName;
				entity.Sort = model.Sort;
				entity.IsShow = model.IsShow;
  

                if (m_Rep.Create(entity))
                {
                    return true;
                }
                else
                {
                    errors.Add(Suggestion.InsertFail);
                    return false;
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHandler.WriteException(ex);
                return false;
            }
        }



         public virtual bool Delete(ref ValidationErrors errors, string id)
        {
            try
            {
                if (m_Rep.Delete(id) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHandler.WriteException(ex);
                return false;
            }
        }

        public virtual bool Delete(ref ValidationErrors errors, string[] deleteCollection)
        {
            try
            {
                if (deleteCollection != null)
                {
                    using (TransactionScope transactionScope = new TransactionScope())
                    {
                        if (m_Rep.Delete(deleteCollection) == deleteCollection.Length)
                        {
                            transactionScope.Complete();
                            return true;
                        }
                        else
                        {
                            Transaction.Current.Rollback();
                            return false;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHandler.WriteException(ex);
                return false;
            }
        }

		
       

        public virtual bool Edit(ref ValidationErrors errors, SysRoleModel model)
        {
            try
            {
                tbl_SysRole entity = m_Rep.GetById(model.RoleId);
                if (entity == null)
                {
                    errors.Add(Suggestion.Disable);
                    return false;
                }
                              				entity.RoleId = model.RoleId;
				entity.RoleName = model.RoleName;
				entity.Sort = model.Sort;
				entity.IsShow = model.IsShow;
 


                if (m_Rep.Edit(entity))
                {
                    return true;
                }
                else
                {
                    errors.Add(Suggestion.EditFail);
                    return false;
                }

            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHandler.WriteException(ex);
                return false;
            }
        }

      

        public virtual SysRoleModel GetById(string id)
        {
            if (IsExists(id))
            {
                tbl_SysRole entity = m_Rep.GetById(id);
                SysRoleModel model = new SysRoleModel();
                              				model.RoleId = entity.RoleId;
				model.RoleName = entity.RoleName;
				model.Sort = entity.Sort;
				model.IsShow = entity.IsShow;
 
                return model;
            }
            else
            {
                return null;
            }
        }

        public virtual bool IsExists(string id)
        {
            return m_Rep.IsExist(id);
        }
		  public void Dispose()
        { 
            
        }

	}
}
