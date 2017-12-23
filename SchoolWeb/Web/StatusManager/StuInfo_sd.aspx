<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StuInfo_sd.aspx.cs" Inherits="SchoolWeb.Web.StatusManager.StuInfo_sd" %>

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
    <script type="text/javascript">
        var obj=document.getElementById("fbody")
        obj.style.height = (window.innerHeight).toString() + "px"
        function submit()
        {
            CurrAddress = $("#AddProvince").val() + $("#AddCity").val() + $("#AddCity").val() + $("#AddArea").val() + $("#AddStreet").val() + $("#AddDetail").val();
            //alert(CurrAddress)
            $.get("./StuInfo_sd.aspx", {
                "action": "stuInfor_sd",
                "StdRollId": $("#stdRollId").val(),
                "StdName": $("#stdname").val(),
                "stdsex": $("#stdsex").val(),
                "native": $("#native").val(),
                "nation": $("#nation").val(),
                "HouseholdAddress": $("#HouseholdAddress").val(),
                //现住址
                "CurrAddress": CurrAddress,
                "PhoneNumber": $("#PhoneNumber").val(),
                "PaperNumber": $("#PaperNumber").val(),
                "UsedName": $("#UsedName").val(),
                "StudentCategory": $("#StudentCategory").val(),
                "email": $("#email").val(),
                "PostCode": $("#PostCode").val(),
                "IsLeagueeMember": $("#IsLeagueeMember").val(),
                "IsYoungPineer": $("#IsYoungPineer").val(),
                "GuardianNO1": $("#GuardianNO1").val(),
                "G1PhoneNumber": $("#G1PhoneNumber").val(),
                "G1Relationship": $("#G1Relationship").val(),
                "GuardianNO2": $("#GuardianNO2").val(),
                "G2PhoneNumber": $("#G2PhoneNumber").val(),
                "G2Relationship": $("#G2Relationship").val(),
                "AlmaMater": $("#AlmaMater").val(),
                "StatusState": $("#StatusState").val()

            },
                function (resultString) {

                    if (resultString != null) {
                        alert("学生已转入")
                    }

                });
        };
        
    </script>
    <div class="panel panel-default" style="padding: 0px;margin-bottom:1px">
        <div class="panel-heading" style="padding: 3px;padding-left:5px;padding-right:5px">
            <h5><strong>新生入学 / 学籍手动导入</strong></h5>
        </div>
    </div>	 

    <div class="panel panel-default" style="padding: 0px;margin-bottom:0px">
        <div class="panel-heading" style="padding: 3px;padding-left:5px;padding-right:5px">
            <h5>学生信息表单</h5>
        </div>
        
        <div class="panel-body" style="padding: 10px;padding-left:5px;padding-right:5px;height:100%">
            <form class="form-horizontal" role="form" method="get">
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">学籍号</label>
                    <div class="col-sm-8">
                        <input type="text" id="stdRollId" class="form-control" name="stdid" placeholder="学籍号"/>
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">名字</label>
                    <div class="col-sm-8">
                        <input type="text" id="stdname" class="form-control" name="stdname" placeholder="名字"/>
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">性别</label>
                    <div class="col-sm-8">
                        <select class="form-control" id="stdsex" name="stdsex">
                            <option>男</option>
                            <option>女</option>
                            <option>秀吉</option>
                        </select>
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">籍贯</label>
                    <div class="col-sm-8">
                        <input type="text" id="native" class="form-control" name="native" placeholder="籍贯"/>
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">民族</label>
                    <div class="col-sm-8">
                        <input type="text" id="nation" class="form-control" name="nation" placeholder="民族"/>
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">户籍住址</label>
                    <div class="col-sm-8">
                        <input type="text" id="HouseholdAddress" class="form-control" name="HouseHoldAddress" placeholder="户籍住址"/>
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">居住省</label>
                    <div class="col-sm-8">
                        <input type="text" id="AddProvince" class="form-control" name="AddProvince" placeholder="居住省"/>
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">居住市</label>
                    <div class="col-sm-8">
                        <input type="text" id="AddCity" class="form-control" name="AddCity" placeholder="居住市"/>
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">居住区</label>
                    <div class="col-sm-8">
                        <input type="text" id="AddArea" class="form-control" name="AddArea" placeholder="居住区"/>
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">居住街道</label>
                    <div class="col-sm-8">
                        <input type="text" id="AddStreet" class="form-control" name="AddStreet" placeholder="居住街道"/>
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">详细地址</label>
                    <div class="col-sm-8">
                        <input type="text" id="AddDetail" class="form-control" name="AddDetail" placeholder="详细地址"/>
                    </div>
                </div>
             <!--
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">照片</label>
                    <div class="col-sm-8">
                        <input class="btn btn-default btn-block" type="file" id="inputfile" name="photo"/>
                    </div>
                </div>
                -->
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">联系方式</label>
                    <div class="col-sm-8">
                        <input type="text" id="PhoneNumber" class="form-control" name="Connection" placeholder="联系方式"/>
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">身份证号</label>
                    <div class="col-sm-8">
                        <input type="text" id="PaperNumber" class="form-control" name="IdCard" placeholder="身份证号"/>
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">曾用名</label>
                    <div class="col-sm-8">
                        <input type="text" id="UsedName" class="form-control" name="StdUsedName" placeholder="曾用名"/>
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">电子邮箱</label>
                    <div class="col-sm-8">
                        <input type="text" id="email" class="form-control" name="email" placeholder="电子邮箱"/>
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">邮编</label>
                    <div class="col-sm-8">
                        <input type="text" id="PostCode" class="form-control" name="PostCode" placeholder="邮编"/>
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">是否团员</label>
                    <div class="col-sm-8">
                        <select class="form-control" id="IsLeagueeMember" name="IsIEagueeMember">
                            <option>是</option>
                            <option>否</option>
                        </select>
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">是否少先队员</label>
                    <div class="col-sm-8">
                        <select class="form-control" id="IsYoungPineer" name="IsYoungPineer">
                            <option>是</option>
                            <option>否</option>
                        </select>
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">监护人1</label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" id="GuardianNO1" name="GuardianNO1" placeholder="监护人1"/>
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">监护人1联系方式</label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" id="G1PhoneNumber" name="G1PhoneNumber" placeholder="监护人1联系方式"/>
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">监护人1与其关系</label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" id="G1Relationship" name="G1Relationship" placeholder="监护人1与其关系"/>
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">监护人2</label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" id="GuardianNO2" name="GuardianNO2" placeholder="监护人2"/>
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">监护人2联系方式</label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" id="G2PhoneNumber" name="G2PhoneNumber" placeholder="监护人2联系方式"/>
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">监护人2与其关系</label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" id="G2Relationship" name="G2Relationship" placeholder="监护人2与其关系"/>
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">原毕业学校</label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" id="AlmaMater" name="AlmaMater" placeholder="原毕业学校"/>
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">学生类别</label>
                    <div class="col-sm-8">
                        <select class="form-control" id="StudentCategory" name="StudentCategory">
                            <option>普通学生</option>
                            <option>残疾学生</option>
                            <option>贫困学生</option>
                        </select>
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">学籍状态</label>
                    <div class="col-sm-8">
                        <select class="form-control" id="StatusState">
                            <option>就读</option>
                            <option>休学</option>
                        </select>
                    </div>
                </div>
               <button class="btn btn-success" onclick="submit();">提交</button>
                 

       </form>
        </div>
   
    </div>
    

    
	
    

	
	
</body>
</html>
 
