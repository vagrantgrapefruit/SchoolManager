//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

using System;

namespace SchoolManager.Models
{
	public partial class SysPermissionModel : Virtual_SysPermissionModel
	{

	}
	public class Virtual_SysPermissionModel
	{
		public virtual string PermissionId { get; set;}
		public virtual string PermissionName { get; set;}
		public virtual Nullable<int> Sort { get; set;}
		public virtual Nullable<bool> IsShow { get; set;}
	}
}
