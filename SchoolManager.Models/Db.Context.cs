﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchoolManager.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DbContainer : DbContext
    {
        public DbContainer()
            : base("name=DbContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbl_SysException> tbl_SysException { get; set; }
        public virtual DbSet<tbl_SysLog> tbl_SysLog { get; set; }
        public virtual DbSet<tbl_SysModule> tbl_SysModule { get; set; }
        public virtual DbSet<tbl_SysModulePermission> tbl_SysModulePermission { get; set; }
        public virtual DbSet<tbl_SysPermission> tbl_SysPermission { get; set; }
        public virtual DbSet<tbl_SysRole> tbl_SysRole { get; set; }
        public virtual DbSet<tbl_SysRolePermission> tbl_SysRolePermission { get; set; }
        public virtual DbSet<tbl_SysUser> tbl_SysUser { get; set; }
        public virtual DbSet<tbl_SysUserRole> tbl_SysUserRole { get; set; }
    }
}