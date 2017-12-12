<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddModule.aspx.cs" Inherits="SchoolWeb.Web.ModuleManager.AddModule" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>新增模块</title>
    <script src="../../Scripts/jQuery/jquery-3.2.1.min.js"></script>
    <script src="../../Content/bootstrap/js/bootstrap.min.js"></script>
    <link href="../../Content/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <script>       
        $.get("../Handler/GetModel.ashx", { method :'getParent'}, function (data) {
            var resultJson = eval('(' + data + ')');
            resultJson.rows.forEach(function (val, index) {

                $("#ParentId").append('<option value="' + val.ModuleId + '">' + val.ModuleName + '</option>')
            });
        });
        $(function () {
            $("#Save").click(function () {
                if ($("#ModuleId").val() == null || $("#ModuleId").val() == "") {
                    alert("请填写模块ID！");
                }
                else if ($("#ModuleName").val() == null || $("#ModuleName").val() == "") {
                    alert("请填写模块名称！");
                }
                else {
                    $.get("../Handler/EditModel.ashx", { method: 'SaveModel', ModuleID: $("#ModuleId").val(), ModuleName: $("#ModuleName").val(), ParentId: $("#ParentId").val(), ModuleURL: $("#ModuleURL").val(), IsLast: $("#IsLast").val(), IsShow: $("#IsShow").val() }, function (data) {
                        var resultJson = eval('(' + data + ')');
                        if (resultJson.flag)
                            alert("创建成功！");
                        else 
                            alert("创建失败！");
                    });
                }
            });
        });
    </script>
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
            <select id="ParentId" class="form-control" name="ParentId"></select>
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
            <select id="IsShow" class="form-control" name="IsShow">
                <option value="true">是</option>
                <option value="false">否</option>
            </select>
        </div>
      </div>
        <div class="form-group">
        <label for="IsShow" class="col-sm-2 control-label">是否最终节点</label>
        <div class="col-sm-10">
            <select id="IsLast" class="form-control" name="IsLast">
                <option value="true">是</option>
                <option value="false">否</option>
            </select>
        </div>
      </div>       
    </form> 
    <div class="form-group">
        <div class="col-sm-offset-2 col-sm-10">
          <button  id="Save" class="btn btn-default">确认新增</button>
        </div>
      </div>
</body>
</html>
