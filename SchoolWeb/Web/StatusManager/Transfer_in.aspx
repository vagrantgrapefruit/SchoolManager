﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Transfer_in.aspx.cs" Inherits="SchoolWeb.Web.StatusManager.Transfer_in" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta charset="utf-8"/>
	<meta name="viewport" content="width=device-width, initial-scale=1.0"/>
	<link rel="stylesheet" href="../../Content/bootstrap/css/bootstrap.min.css"/>  
	<script src="../../Scripts/jQuery/jquery-3.2.1.min.js"></script>
   	<script src="../../Content/bootstrap/js/bootstrap.min.js"></script>
	<script src="../../Scripts/web/clist.js"></script>
	<title>学籍管理系统</title>
</head>
<body id="fbody" style="padding:3px;background-color:#F6F4F0;height:100%">
    <script>
        var obj = document.getElementById("fbody")
        obj.style.height = (window.innerHeight).toString() + "px"
    </script>
    <div class="panel panel-default" style="padding: 0px;margin-bottom:1px">
        <div class="panel-heading" style="padding: 3px;padding-left:5px;padding-right:5px">
            <h5><strong>学籍管理 / 学生转入</strong></h5>
        </div>
    </div>	 
    <div class="panel panel-default" style="padding: 0px;margin-bottom:1px">
        <div class="panel-body" style="padding: 3px;padding-left:5px;padding-right:5px">
            <form class="form-horizontal" role="form" method="get">
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">转入前学校</label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" name="schoolname" placeholder="学校名">
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">学籍号</label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" name="stdid" placeholder="学籍号">
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">名字</label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" name="stdname" placeholder="名字">
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">性别</label>
                    <div class="col-sm-8">
                        <select class="form-control" name="stdsex">
                            <option>男</option>
                            <option>女</option>
                            <option>秀吉</option>
                        </select>
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">籍贯</label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" name="native" placeholder="籍贯">
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">民族</label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" name="nation" placeholder="民族">
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">户籍住址</label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" name="HouseHoldAddress" placeholder="户籍住址">
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">居住省</label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" name="AddProvince" placeholder="居住省">
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">居住市</label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" name="AddCity" placeholder="居住市">
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">居住区</label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" name="AddArea" placeholder="居住区">
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">居住街道</label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" name="AddStreet" placeholder="居住街道">
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">详细地址</label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" name="AddDetail" placeholder="详细地址">
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">照片</label>
                    <div class="col-sm-8">
                        <input class="btn btn-default btn-block" type="file" id="inputfile" name="photo">
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">联系方式</label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" name="Connection" placeholder="联系方式">
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">身份证号</label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" name="IdCard" placeholder="身份证号">
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">曾用名</label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" name="StdUsedName" placeholder="曾用名">
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">电子邮箱</label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" name="email" placeholder="电子邮箱">
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">邮编</label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" name="PostCode" placeholder="邮编">
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">是否团员</label>
                    <div class="col-sm-8">
                        <select class="form-control" name="IsIEagueeMember">
                            <option>是</option>
                            <option>否</option>
                        </select>
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">是否少先队员</label>
                    <div class="col-sm-8">
                        <select class="form-control" name="IsYoungPineer">
                            <option>是</option>
                            <option>否</option>
                        </select>
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">监护人1</label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" name="GuardianNO1" placeholder="监护人1">
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">监护人1联系方式</label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" name="G1PhoneNumber" placeholder="监护人1联系方式">
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">监护人1与其关系</label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" name="G1Relationship" placeholder="监护人1与其关系">
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">监护人2</label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" name="GuardianNO2" placeholder="监护人2">
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">监护人2联系方式</label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" name="G2PhoneNumber" placeholder="监护人2联系方式">
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">监护人2与其关系</label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" name="G2Relationship" placeholder="监护人2与其关系">
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">原毕业学校</label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" name="AlmaMater" placeholder="原毕业学校">
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">学生类别</label>
                    <div class="col-sm-8">
                        <select class="form-control" name="StudentCategory">
                            <option>普通学生</option>
                            <option>残疾学生</option>
                            <option>贫困学生</option>
                        </select>
                    </div>
                </div>
                <div style="text-align: center;margin:10px"><button type="submit" class="btn btn-success">转入</button></div>

            </form>
        </div>
    </div>	
	
    

	
	
</body>
</html>
 