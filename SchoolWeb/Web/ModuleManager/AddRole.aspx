<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="SchoolWeb.Web.ModuleManager.AddUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>新增角色</title>
    <script src="../../Scripts/jQuery/jquery-3.2.1.min.js"></script>
    <script src="../../Content/bootstrap/js/bootstrap.min.js"></script>
    <link href="../../Content/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <script>       
        $(function () {
            $("#Save").click(function () {
                if ($("#RoleId").val() == null || $("#RoleId").val() == "") {
                    alert("请填写角色Id！");
                }
                else if ($("#RoleName").val() == null || $("#RoleName").val() == "") {
                    alert("请填写角色名称！");
                }
                else {
                    $.get("../Handler/EditRole.ashx", { method: 'SaveRole', RoleId: $("#RoleId").val(), RoleName: $("#RoleName").val(), IsShow: $("#IsShow").val()}, function (data) {
                        var resultJson = eval('(' + data + ')');
                        if (resultJson.flag)
                        {
                            alert("创建成功！");
                            //window.close();
                            window.parent.location.reload();
                        }
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
      <div class="form-group" style ="display:none">
        <label for="Id" class="col-sm-2 control-label">Id</label>
        <div class="col-sm-10">
          <input type="text" class="form-control" id="Id" placeholder="Id"/>
        </div>
      </div>
      <div class="form-group">
        <label for="RoleId" class="col-sm-2 control-label">角色Id</label>
        <div class="col-sm-10">
          <input type="text" class="form-control" id="RoleId" placeholder="请输入角色ID"/>
        </div>
      </div>
      <div class="form-group">
        <label for="RoleName" class="col-sm-2 control-label">角色名称</label>
        <div class="col-sm-10">
            <input type="text" class="form-control" id="RoleName" placeholder="请输入角色名称"/>
        </div>
      </div>
      <div class="form-group">
        <label for="IsShow" class="col-sm-2 control-label">IsShow</label>
        <div class="col-sm-10">
            <select id="IsShow" class="form-control" name="IsShow">
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
