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
    <script>
        $(function () {
            var param =<%=Session["UserName"].ToString()%>
                $.get('../Handler/GetStudent.ashx', { "action": "getStudent", "Param": param }, function (resultString) {
                    var studentInfor = eval('(' + resultString + ')');
                    $("#Statusid").val(studentInfor.model.Statusid);
                    $("#StdRollId").val(studentInfor.model.StdRollId);
                    $("#StdName").val(studentInfor.model.StdName);
                    $("#StdSex").val(studentInfor.model.StdSex);
                    $("#native").val(studentInfor.model.native);
                    $("#nation").val(studentInfor.model.nation);
                    $("#Entrance_Year").val(studentInfor.model.Entrance_Year);
                    $("#Household_Registration_Category").val(studentInfor.model.Household_Registration_Category);
                    $("#HouseholdAddress").val(studentInfor.model.HouseholdAddress);
                    $("#CurrentAddress").val(studentInfor.model.CurrentAddress);
                    $("#PhoneNumber").val(studentInfor.model.PhoneNumber);
                    $("#UrgentPhoneNumber").val(studentInfor.model.UrgentPhoneNumber);
                    $("#PaperType").val(studentInfor.model.PaperType);
                    $("#PaperNumber").val(studentInfor.model.PaperNumber);
                    $("#UsedName").val(studentInfor.model.UsedName);
                    $("#email").val(studentInfor.model.email);
                    $("#PostCode").val(studentInfor.model.PostCode);
                    $("#IsLeagueeMember").val(studentInfor.model.IsLeagueeMember);
                    $("#IsYoungPineer").val(studentInfor.model.IsYoungPineer);
                    $("#GuardianNo1").val(studentInfor.model.GuardianNo1);
                    $("#G1PhoneNumber").val(studentInfor.model.G1PhoneNumber);
                    $("#G1Relationship").val(studentInfor.model.G1Relationship);
                    $("#GuardianNo2").val(studentInfor.model.GuardianNo2);
                    $("#G2PhoneNumber").val(studentInfor.model.G2PhoneNumber);
                    $("#G2Relationship").val(studentInfor.model.G2Relationship);
                    $("#AlmaMater").val(studentInfor.model.AlmaMater);
                    $("#StdCategory").val(studentInfor.model.StdCategory);
                    $("#StatusState").val(studentInfor.model.StatusState);
                    $("#INforid").val(studentInfor.model.INforid);
                    $("#StdId").val(studentInfor.model.StdId);
                    $("#RepeatNo").val(studentInfor.model.RepeatNo);
                    $("#ClassNo").val(studentInfor.model.ClassNo);
                    $("#InResidence").val(studentInfor.model.InResidence);
                    $("#DormitoryBuilding").val(studentInfor.model.DormitoryBuilding);
                    $("#DormitoryNo").val(studentInfor.model.DormitoryNo);
                    $("#AddProvince").val(studentInfor.model.AddProvince);
                    $("#AddCity").val(studentInfor.model.AddCity);
                    $("#AddArea").val(studentInfor.model.AddArea);
                    $("#AddStreet").val(studentInfor.model.AddStreet);
                    $("#AddDetail").val(studentInfor.model.AddDetail);
            });
        });
        function submit() {
            debugger;
            $.ajax({
                type:'post',
                url: '../Handler/GetStudent.ashx',
                data: $('#InforForm').serialize(),
                dataType: 'json',
                success: function (data) {
                    debugger;
                    if (data.flag1 == true) {
                        alert("保存成功!");
                    }
                    else {
                        alert("保存失败!");
                    }
                }
            });
        };
    </script>
</head>
        <script type="text/javascript">
            

    </script>

<body id="fbody" style="padding:3px;background-color:#F6F4F0;height:100%">
  
    <div class="panel panel-default" style="padding: 0px;margin-bottom:1px">
        <div class="panel-heading" style="padding: 3px;padding-left:5px;padding-right:5px">
            <h5><strong>新生入学 / 填写详细信息</strong></h5>
        </div>
    </div>	 

    <div class="panel panel-default" style="padding: 0px;margin-bottom:0px">
        <div class="panel-heading" style="padding: 3px;padding-left:5px;padding-right:5px">
            <h5>学生信息表单</h5>
        </div>
        
        <div class="panel-body" style="padding: 10px;padding-left:5px;padding-right:5px;height:100%">
            <form id="InforForm" class="form-horizontal" role="form" method="get">
                <input type="hidden" id="Statusid" class="form-control" name="Statusid" />
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">学籍号</label>
                    <div class="col-sm-8">
                        <input type="text" id="StdRollId" class="form-control" name="StdRollId" placeholder="学籍号" readonly="readonly" />
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">名字</label>
                    <div class="col-sm-8">
                        <input type="text" id="StdName" class="form-control" name="StdName" placeholder="名字" readonly="readonly"/>
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">性别</label>
                    <div class="col-sm-8">
                        <input type="text" id="StdSex" class="form-control" name="StdSex" placeholder="性别" readonly="readonly"/>
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
                        <input type="text" id="nation" class="form-control" name="nation" placeholder="民族"readonly="readonly"/>
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">入学年份</label>
                    <div class="col-sm-8">
                        <input type="text" id="Entrance_Year" class="form-control" name="Entrance_Year" placeholder="入学年份"readonly="readonly"/>
                    </div>
                </div>

                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">户籍住址</label>
                    <div class="col-sm-8">
                        <input type="text" id="HouseholdAddress" class="form-control" name="HouseHoldAddress" placeholder="户籍住址"/>
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">户籍类别</label>
                    <div class="col-sm-8">
                        <input type="text" id="Household_Registration_Category" class="form-control" name="Household_Registration_Category" placeholder="户籍类别"/>
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
                        <input type="text" id="PhoneNumber" class="form-control" name="PhoneNumber" placeholder="联系方式"/>
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">紧急联系方式</label>
                    <div class="col-sm-8">
                        <input type="text" id="UrgentPhoneNumber" class="form-control" name="UrgentPhoneNumber" placeholder="紧急联系方式"/>
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">证件类别</label>
                    <div class="col-sm-8">
                        <input type="text" id="PaperType" class="form-control" name="PaperType" placeholder="证件类别"/>
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">证件号码</label>
                    <div class="col-sm-8">
                        <input type="text" id="PaperNumber" class="form-control" name="PaperNumber" placeholder="证件号码"/>
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">曾用名</label>
                    <div class="col-sm-8">
                        <input type="text" id="UsedName" class="form-control" name="UsedName" placeholder="曾用名"/>
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
                        <select class="form-control" id="IsLeagueeMember" name="IsLeagueeMember">
                            <option value="1" >是</option>
                            <option value="0">否</option>
                        </select>
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">是否少先队员</label>
                    <div class="col-sm-8">
                        <select class="form-control" id="IsYoungPineer" name="IsYoungPineer">
                            <option value="1"> 是</option>
                            <option value="0"> 否</option>
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
                        <input type="hidden" class="form-control" id="StdCategory" name="StdCategory" />
                        <input type="hidden" class="form-control" id="INforid" name="INforid" />
                        <input type="hidden" class="form-control" id="StdId" name="StdId" />
                        <input type="hidden" class="form-control" id="RepeatNo" name="RepeatNo" />
                        <input type="hidden" class="form-control" id="ClassNo" name="ClassNo" />
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">是否住校</label>
                    <div class="col-sm-8">
                        <select class="form-control" id="InResidence" name="InResidence">
                            <option value="True">是</option>
                            <option value="False">否</option>
                        </select>
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">学籍状态</label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" id="StatusState" name="StatusState" placeholder="学籍状态"/>
                    </div>
                </div>
               
                 

       </form>
            <button class="btn btn-success" onclick="submit();">保存</button>
        </div>
   
    </div>
</body>
</html>

