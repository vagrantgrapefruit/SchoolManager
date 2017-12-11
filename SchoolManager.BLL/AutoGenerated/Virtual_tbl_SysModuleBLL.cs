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
	public class Virtual_SysModuleBLL
	{

        public SysModuleRepository m_Rep =new SysModuleRepository(new DbContainer());

		public virtual List<SysModuleModel> GetList( string queryStr)
        {

            IQueryable<tbl_SysModule> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = m_Rep.GetList(
								a=>(a.ModuleId!=null && a.ModuleId.Contains(queryStr))
								|| (a.ModuleName!=null && a.ModuleName.Contains(queryStr))
								|| (a.ParentId!=null && a.ParentId.Contains(queryStr))
								|| (a.ModuleURL!=null && a.ModuleURL.Contains(queryStr))
								
								
								);
            }
            else
            {
                queryData = m_Rep.GetList();
            }
            return CreateModelList(ref queryData);
        }

        public virtual List<SysModuleModel> CreateModelList(ref IQueryable<tbl_SysModule> queryData)
        {

            List<SysModuleModel> modelList = (from r in queryData
                                              select new SysModuleModel
                                              {
													ModuleId = r.ModuleId,
													ModuleName = r.ModuleName,
													ParentId = r.ParentId,
													ModuleURL = r.ModuleURL,
													Sort = r.Sort,
													IsShow = r.IsShow,
          
                                              }).ToList();

            return modelList;
        }

        public virtual bool Create(SysModuleModel model)
        {
            try
            {
                tbl_SysModule entity = m_Rep.GetById(model.ModuleId);
                if (entity != null)
                {
                    return false;
                }
                entity = new tbl_SysModule();
               				entity.ModuleId = model.ModuleId;
				entity.ModuleName = model.ModuleName;
				entity.ParentId = model.ParentId;
				entity.ModuleURL = model.ModuleURL;
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

		
       

        public virtual bool Edit( SysModuleModel model)
        {
            try
            {
                tbl_SysModule entity = m_Rep.GetById(model.ModuleId);
                if (entity == null)
                {
                    return false;
                }
                              				entity.ModuleId = model.ModuleId;
				entity.ModuleName = model.ModuleName;
				entity.ParentId = model.ParentId;
				entity.ModuleURL = model.ModuleURL;
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

      

        public virtual SysModuleModel GetById(string id)
        {
            if (IsExists(id))
            {
                tbl_SysModule entity = m_Rep.GetById(id);
                SysModuleModel model = new SysModuleModel();
                              				model.ModuleId = entity.ModuleId;
				model.ModuleName = entity.ModuleName;
				model.ParentId = entity.ParentId;
				model.ModuleURL = entity.ModuleURL;
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
