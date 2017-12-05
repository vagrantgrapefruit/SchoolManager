<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddModule.aspx.cs" Inherits="SchoolWeb.Web.ModuleManager.AddModule" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>新增模块</title>
    <script src="../../Scripts/jQuery/jquery-3.2.1.min.js"></script>
    <script src="../../Content/bootstrap/js/bootstrap.min.js"></script>
    <link href="../../Content/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form class="form-horizontal" role="form">
      <div class="form-group">
        <label for="ModuleId" class="col-sm-2 control-label">模块Id</label>
        <div class="col-sm-10">
          <input type="text" class="form-control" id="ModuleId" placeholder="请输入模块Id"/>
        </div>
      </div>
      <div class="form-group">
        <label for="ModuleName" class="col-sm-2 control-label">模块名称</label>
        <div class="col-sm-10">
          <input type="text" class="form-control" id="ModuleName" placeholder="请输入模块名称"/>
        </div>
      </div>
      <div class="form-group">
        <label for="ParentId" class="col-sm-2 control-label">上级节点</label>
        <div class="col-sm-10">
          <input type="text" class="form-control" id="ParentId" placeholder="请选择上级节点"/>
        </div>
      </div>
      <div class="form-group">
        <label for="ModuleURL" class="col-sm-2 control-label">链接地址</label>
        <div class="col-sm-10">
          <input type="text" class="form-control" id="ModuleURL" placeholder="请输入链接地址"/>
        </div>
      </div>
      <div class="form-group">
        <label for="IsShow" class="col-sm-2 control-label">是否展示</label>
        <div class="col-sm-10">
          <input type="text" class="form-control" id="IsShow" placeholder="请输入姓"/>
        </div>
      </div>
      <div class="form-group">
        <div class="col-sm-offset-2 col-sm-10">
          <button type="submit" class="btn btn-default">登录</button>
        </div>
      </div>
    </form>
</body>
</html>
