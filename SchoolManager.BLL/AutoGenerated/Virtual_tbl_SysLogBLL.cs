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
	public class Virtual_SysLogBLL
	{

        public SysLogRepository m_Rep =new SysLogRepository(new DbContainer());

		public virtual List<SysLogModel> GetList( string queryStr)
        {

            IQueryable<tbl_SysLog> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = m_Rep.GetList(
								a=>(a.Id!=null && a.Id.Contains(queryStr))
								|| (a.Operator!=null && a.Operator.Contains(queryStr))
								|| (a.Message!=null && a.Message.Contains(queryStr))
								|| (a.Result!=null && a.Result.Contains(queryStr))
								|| (a.Type!=null && a.Type.Contains(queryStr))
								|| (a.Module!=null && a.Module.Contains(queryStr))
								
								);
            }
            else
            {
                queryData = m_Rep.GetList();
            }
            return CreateModelList(ref queryData);
        }

        public virtual List<SysLogModel> CreateModelList(ref IQueryable<tbl_SysLog> queryData)
        {

            List<SysLogModel> modelList = (from r in queryData
                                              select new SysLogModel
                                              {
													Id = r.Id,
													Operator = r.Operator,
													Message = r.Message,
													Result = r.Result,
													Type = r.Type,
													Module = r.Module,
													CreateTime = r.CreateTime,
          
                                              }).ToList();

            return modelList;
        }

        public virtual bool Create(ref ValidationErrors errors, SysLogModel model)
        {
            try
            {
                tbl_SysLog entity = m_Rep.GetById(model.Id);
                if (entity != null)
                {
                    errors.Add(Suggestion.PrimaryRepeat);
                    return false;
                }
                entity = new tbl_SysLog();
               				entity.Id = model.Id;
				entity.Operator = model.Operator;
				entity.Message = model.Message;
				entity.Result = model.Result;
				entity.Type = model.Type;
				entity.Module = model.Module;
				entity.CreateTime = model.CreateTime;
  

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

		
       

        public virtual bool Edit(ref ValidationErrors errors, SysLogModel model)
        {
            try
            {
                tbl_SysLog entity = m_Rep.GetById(model.Id);
                if (entity == null)
                {
                    errors.Add(Suggestion.Disable);
                    return false;
                }
                              				entity.Id = model.Id;
				entity.Operator = model.Operator;
				entity.Message = model.Message;
				entity.Result = model.Result;
				entity.Type = model.Type;
				entity.Module = model.Module;
				entity.CreateTime = model.CreateTime;
 


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

      

        public virtual SysLogModel GetById(string id)
        {
            if (IsExists(id))
            {
                tbl_SysLog entity = m_Rep.GetById(id);
                SysLogModel model = new SysLogModel();
                              				model.Id = entity.Id;
				model.Operator = entity.Operator;
				model.Message = entity.Message;
				model.Result = entity.Result;
				model.Type = entity.Type;
				model.Module = entity.Module;
				model.CreateTime = entity.CreateTime;
 
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