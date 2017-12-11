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
	public class Virtual_SysPermissionBLL
	{

        public SysPermissionRepository m_Rep =new SysPermissionRepository(new DbContainer());

		public virtual List<SysPermissionModel> GetList( string queryStr)
        {

            IQueryable<tbl_SysPermission> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = m_Rep.GetList(
								a=>(a.PermissionId!=null && a.PermissionId.Contains(queryStr))
								|| (a.PermissionName!=null && a.PermissionName.Contains(queryStr))
								
								
								);
            }
            else
            {
                queryData = m_Rep.GetList();
            }
            return CreateModelList(ref queryData);
        }

        public virtual List<SysPermissionModel> CreateModelList(ref IQueryable<tbl_SysPermission> queryData)
        {

            List<SysPermissionModel> modelList = (from r in queryData
                                              select new SysPermissionModel
                                              {
													PermissionId = r.PermissionId,
													PermissionName = r.PermissionName,
													Sort = r.Sort,
													IsShow = r.IsShow,
          
                                              }).ToList();

            return modelList;
        }

        public virtual bool Create(SysPermissionModel model)
        {
            try
            {
                tbl_SysPermission entity = m_Rep.GetById(model.PermissionId);
                if (entity != null)
                {
                    return false;
                }
                entity = new tbl_SysPermission();
               				entity.PermissionId = model.PermissionId;
				entity.PermissionName = model.PermissionName;
				entity.Sort = model.Sort;
				entity.IsShow = model.IsShow;
  

                if (m_Rep.Create(entity))
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

                return false;
            }
        }



         public virtual bool Delete( string id)
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

                return false;
            }
        }

        public virtual bool Delete( string[] deleteCollection)
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

                return false;
            }
        }

		
       

        public virtual bool Edit( SysPermissionModel model)
        {
            try
            {
                tbl_SysPermission entity = m_Rep.GetById(model.PermissionId);
                if (entity == null)
                {
                    return false;
                }
                              				entity.PermissionId = model.PermissionId;
				entity.PermissionName = model.PermissionName;
				entity.Sort = model.Sort;
				entity.IsShow = model.IsShow;
 


                if (m_Rep.Edit(entity))
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

                return false;
            }
        }

      

        public virtual SysPermissionModel GetById(string id)
        {
            if (IsExists(id))
            {
                tbl_SysPermission entity = m_Rep.GetById(id);
                SysPermissionModel model = new SysPermissionModel();
                              				model.PermissionId = entity.PermissionId;
				model.PermissionName = entity.PermissionName;
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
