<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="SchoolWeb.Web.ModuleManager.EditUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>编辑用户信息</title>
    <script src="../../Scripts/jQuery/jquery-3.2.1.min.js"></script>
    <script src="../../Content/bootstrap/js/bootstrap.min.js"></script>
    <link href="../../Content/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <script>     
        var rows = window.parent.getrow();
        var row = rows[0];       
        $.get("../Handler/EditUser.ashx", row, function (data) {
            var resultJson = eval('(' + data + ')');
            $("#UserId").val(resultJson.UserId);
            $("#UserName").val(resultJson.UserName);
            $("#PassWord").val(resultJson.PassWord);
            $("#PhoneNumber").val(resultJson.PhoneNumber);
            $("#SchoolCard").val(resultJson.SchoolCard);
            $("#Sex").val(resultJson.Sex.toString());
            $("#DepId").val(resultJson.DepId.toString());
            $("#PosId").val(resultJson.PosId.toString());
        });
        $(function () {
            $("#Save").click(function () {
                if ($("#UserId").val() == null || $("#UserId").val() == "") {
                    alert("请填写用户名！");
                }
                else if ($("#PassWord").val() == null || $("#PassWord").val() == "") {
                    alert("请填写密码！");
                }
                else {
                    $.get("../Handler/EditUser.ashx", { method: 'EditUser', UserId: $("#UserId").val(), UserName: $("#UserName").val(), PassWord: $("#PassWord").val(), PhoneNumber: $("#PhoneNumber").val(), SchoolCard: $("#SchoolCard").val(), Sex: $("#Sex").val(), DepId: $("#DepId").val(), PosId: $("#PosId").val() }, function (data) {
                        var resultJson = eval('(' + data + ')');
                        if (resultJson.flag)
                        {
                            alert("修改成功！");
                            //window.close();
                            window.parent.location.reload();
                        }
                        else 
                            alert("修改失败！");
                    });
                }
            });
        });
    </script>
</head>
<body>
    <form class="form-horizontal" role="form">
      <div class="form-group">
        <label for="UserId" class="col-sm-2 control-label">用户名</label>
        <div class="col-sm-10">
          <input type="text" class="form-control" id="UserId" placeholder="请输入用户名"/>
        </div>
      </div>
      <div class="form-group">
        <label for="UserName" class="col-sm-2 control-label">真实姓名</label>
        <div class="col-sm-10">
          <input type="text" class="form-control" id="UserName" placeholder="请输入真实姓名"/>
        </div>
      </div>
      <div class="form-group">
        <label for="PassWord" class="col-sm-2 control-label">密码</label>
        <div class="col-sm-10">
            <input type="text" class="form-control" id="PassWord" placeholder="请输入密码"/>
        </div>
      </div>
      <div class="form-group">
        <label for="PhoneNumber" class="col-sm-2 control-label">电话号码</label>
        <div class="col-sm-10">
          <input type="text" class="form-control" id="PhoneNumber" placeholder="请输入电话号码"/>
        </div>
      </div>
        <div class="form-group">
        <label for="SchoolCard" class="col-sm-2 control-label">校园卡号</label>
        <div class="col-sm-10">
          <input type="text" class="form-control" id="SchoolCard" placeholder="请输入校园卡号"/>
        </div>
      </div>
      <div class="form-group">
        <label for="Sex" class="col-sm-2 control-label">性别</label>
        <div class="col-sm-10">
            <select id="Sex" class="form-control" name="Sex">
                <option value="男">男</option>
                <option value="女">女</option>
                <option value="秀吉">秀吉</option>
            </select>
        </div>
      </div>
      <div class="form-group">
        <label for="DepId" class="col-sm-2 control-label">部门名称</label>
        <div class="col-sm-10">
          <input type="text" class="form-control" id="DepId" placeholder="请输入部门名称"/>
        </div>
      </div>
        <div class="form-group">
        <label for="PosId" class="col-sm-2 control-label">职位</label>
        <div class="col-sm-10">
          <input type="text" class="form-control" id="PosId" placeholder="请输入职位"/>
        </div>
      </div>
    </form> 
    <div class="form-group">
        <div class="col-sm-offset-2 col-sm-10">
          <button  id="Save" class="btn btn-default">确认修改</button>
        </div>
      </div>
</body>
</html>
