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
	public class Virtual_YZJ_CheckTypeBLL
	{

        public YZJ_CheckTypeRepository m_Rep =new YZJ_CheckTypeRepository(new DbContainer());

		public virtual List<YZJ_CheckTypeModel> GetList( string queryStr)
        {

            IQueryable<YZJ_CheckType> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = m_Rep.GetList(
								
								a=>(a.Name!=null && a.Name.Contains(queryStr))
								);
            }
            else
            {
                queryData = m_Rep.GetList();
            }
            return CreateModelList(ref queryData);
        }

        public virtual List<YZJ_CheckTypeModel> CreateModelList(ref IQueryable<YZJ_CheckType> queryData)
        {

            List<YZJ_CheckTypeModel> modelList = (from r in queryData
                                              select new YZJ_CheckTypeModel
                                              {
													ID = r.ID,
													Name = r.Name,
          
                                              }).ToList();

            return modelList;
        }

        public virtual bool Create(ref ValidationErrors errors, YZJ_CheckTypeModel model)
        {
            try
            {
                YZJ_CheckType entity = m_Rep.GetById(model.ID);
                if (entity != null)
                {
                    errors.Add(Suggestion.PrimaryRepeat);
                    return false;
                }
                entity = new YZJ_CheckType();
               				entity.ID = model.ID;
				entity.Name = model.Name;
  

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

		
       

        public virtual bool Edit(ref ValidationErrors errors, YZJ_CheckTypeModel model)
        {
            try
            {
                YZJ_CheckType entity = m_Rep.GetById(model.ID);
                if (entity == null)
                {
                    errors.Add(Suggestion.Disable);
                    return false;
                }
                              				entity.ID = model.ID;
				entity.Name = model.Name;
 


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

      

        public virtual YZJ_CheckTypeModel GetById(string id)
        {
            if (IsExists(id))
            {
                YZJ_CheckType entity = m_Rep.GetById(id);
                YZJ_CheckTypeModel model = new YZJ_CheckTypeModel();
                              				model.ID = entity.ID;
				model.Name = entity.Name;
 
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