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
	public class Virtual_SysUserBLL
	{

        public SysUserRepository m_Rep =new SysUserRepository(new DbContainer());

		public virtual List<SysUserModel> GetList( string queryStr)
        {

            IQueryable<tbl_SysUser> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = m_Rep.GetList(
								a=>(a.UserId!=null && a.UserId.Contains(queryStr))
								|| (a.UserName!=null && a.UserName.Contains(queryStr))
								|| (a.PassWord!=null && a.PassWord.Contains(queryStr))
								|| (a.PhoneNumber!=null && a.PhoneNumber.Contains(queryStr))
								|| (a.SchoolCard!=null && a.SchoolCard.Contains(queryStr))
								|| (a.Sex!=null && a.Sex.Contains(queryStr))
								|| (a.DepId!=null && a.DepId.Contains(queryStr))
								|| (a.PosId!=null && a.PosId.Contains(queryStr))
								);
            }
            else
            {
                queryData = m_Rep.GetList();
            }
            return CreateModelList(ref queryData);
        }

        public virtual List<SysUserModel> CreateModelList(ref IQueryable<tbl_SysUser> queryData)
        {

            List<SysUserModel> modelList = (from r in queryData
                                              select new SysUserModel
                                              {
													UserId = r.UserId,
													UserName = r.UserName,
													PassWord = r.PassWord,
													PhoneNumber = r.PhoneNumber,
													SchoolCard = r.SchoolCard,
													Sex = r.Sex,
													DepId = r.DepId,
													PosId = r.PosId,
          
                                              }).ToList();

            return modelList;
        }

        public virtual bool Create(SysUserModel model)
        {
            try
            {
                tbl_SysUser entity = m_Rep.GetById(model.UserId);
                if (entity != null)
                {
                    return false;
                }
                entity = new tbl_SysUser();
               				entity.UserId = model.UserId;
				entity.UserName = model.UserName;
				entity.PassWord = model.PassWord;
				entity.PhoneNumber = model.PhoneNumber;
				entity.SchoolCard = model.SchoolCard;
				entity.Sex = model.Sex;
				entity.DepId = model.DepId;
				entity.PosId = model.PosId;
  

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

		
       

        public virtual bool Edit( SysUserModel model)
        {
            try
            {
                tbl_SysUser entity = m_Rep.GetById(model.UserId);
                if (entity == null)
                {
                    return false;
                }
                              				entity.UserId = model.UserId;
				entity.UserName = model.UserName;
				entity.PassWord = model.PassWord;
				entity.PhoneNumber = model.PhoneNumber;
				entity.SchoolCard = model.SchoolCard;
				entity.Sex = model.Sex;
				entity.DepId = model.DepId;
				entity.PosId = model.PosId;
 


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

      

        public virtual SysUserModel GetById(string id)
        {
            if (IsExists(id))
            {
                tbl_SysUser entity = m_Rep.GetById(id);
                SysUserModel model = new SysUserModel();
                              				model.UserId = entity.UserId;
				model.UserName = entity.UserName;
				model.PassWord = entity.PassWord;
				model.PhoneNumber = entity.PhoneNumber;
				model.SchoolCard = entity.SchoolCard;
				model.Sex = entity.Sex;
				model.DepId = entity.DepId;
				model.PosId = entity.PosId;
 
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
