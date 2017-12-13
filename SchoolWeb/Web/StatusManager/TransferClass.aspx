﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransferClass.aspx.cs" Inherits="SchoolWeb.Web.StatusManager.TransferClass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta charset="utf-8"/>
	<meta name="viewport" content="width=device-width, initial-scale=1.0"/>
	<link rel="stylesheet" href="../../Content/bootstrap/css/bootstrap.min.css"/>  
	<script src="../../Scripts/jQuery/jquery-3.2.1.min.js"></script>
   	<script src="../../Content/bootstrap/js/bootstrap.min.js"></script>
	<script src="../../Scripts/web/clist.js"></script>
    <script src="../../Scripts/web/sel_student.js"></script>
	<title>学籍管理系统</title>
    <script type="text/javascript">
        function getStudent() {
            //输入学籍号
            
            $.get("./TransferClass.aspx", { "action": "getStudent", "condition": $("#condition").val() }, function (resultString) {

                var studentInfor = eval('(' + resultString + ')');
                var studentInforArray = studentInfor.InforList;
                $(studentInforArray).each(function (index, Infor) {
                    $("#stdname").val(Infor.StdName);
                    $("#stdid").val(Infor.StdId);
                    $("#stdclass").val(Infor.ClassNo);
                });
                
            });

        }
        function submit()
        {
            $("#mes").html("");
            $("#reason").removeClass("input-validation-error");
            if ($.trim($("#reason").val()) == "") {
                $("#reason").addClass("input-validation-error").focus();
                $("#mes").html("申请理由不为空！");
                console.log("add")
                return;
            }
            if ($.trim($("#stdname").val()) == "") {
                $("#stdname").addClass("input-validation-error").focus();
                $("#mes").html("未选择有效学生！");
                console.log("add")
                return;
            }
            newClass = ($("#stdclass").val()).substring(0, 2) + $("#cclass").val();
            $.get("./TransferClass.aspx", { "action": "transfer", "newClass": newClass, "stdid": $("#stdid").val(), "ApplyReason": $("#reason").val() }, function (resultString) {
                if (resultString != null)
                {
                    alert("修改好啦！")
                }
   
            });
         
        }
    </script>
</head>
<body id="fbody" style="padding:3px;background-color:#F6F4F0;height:100%">
    <script>
        var obj=document.getElementById("fbody")
        obj.style.height=(window.innerHeight).toString()+"px"
    </script>
    <div class="panel panel-default" style="padding: 0px;margin-bottom:1px">
        <div class="panel-heading" style="padding: 3px;padding-left:5px;padding-right:5px">
            <h5><strong>学籍管理 / 学生转班申请</strong></h5>
        </div>
    </div>	 

    <div class="modal fade" id="SelStuModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel">选择学生</h4>
                </div>
                <div class="modal-body">
                    <div class="panel panel-default" style="padding: 0px;margin-bottom:1px">
                        <div class="panel-body" style="padding: 3px;padding-left:5px;padding-right:5px">
                            <div >
       <!--                         <input type="text" class="form-control" name="model_name" placeholder="姓名或学籍号"/>  -->
                                <input type="text" class="form-control" id="condition" name="model_name" placeholder="姓名或学号"/>
                            </div>
                        </div>
                    </div>

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
        <!--            <button type="button" class="btn btn-primary" data-dismiss="modal" onclick="getStudent('test')">确认选择</button>
         -->           <button type="button" class="btn btn-primary" data-dismiss="modal" onclick="getStudent();">确认选择</button>

                </div>
            </div><!-- /.modal-content -->
        </div><!-- /.modal -->
    </div>

    <div class="panel panel-default" style="padding: 0px;margin-bottom:1px">
            
        <div class="panel-body" style="padding: 3px;padding-left:5px;padding-right:5px">
            <div style="margin-bottom:5px;text-align:center">
                <button class="btn btn-primary" data-toggle="modal" data-target="#SelStuModal">
                    选择学生
                </button>
            </div> 
            <form class="form-horizontal" role="form" method="get">
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">学生名字</label>
                    <div class="col-sm-8">
                        <input id="stdname" type="text" class="form-control" name="stdname" placeholder="名字" disabled />
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">学号</label>
                    <div class="col-sm-8">
                        <input id="stdid" type="text" class="form-control" name="stdid" placeholder="学号" disabled/>
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">当前班级</label>
                    <div class="col-sm-8">
                        <input id="stdclass" type="text" class="form-control" name="stdclass" placeholder="当前班级" disabled/>
                    </div>
                </div>
                
                <div class="form-group" style="margin-bottom:5px;margin-top:5px">
                    <label class="col-sm-2 control-label">转入</label>
                    <div class="col-sm-8">
                        <select class="form-control" id="cclass" name="cclass">
                            <option value="01">一班</option>
                            <option value="02">二班</option>
                            <option value="03">三班</option>
                            <option value="04">四班</option>
                            <option value="05">五班</option>
                        </select>
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">申请理由</label>
                    <div class="col-sm-8">
                        <textarea rows="3" id="reason" class="form-control" name="rea" placeholder="申请理由"></textarea>
                    </div>
                </div>
                <div style="text-align: center;margin:10px">
                    <span id="mes"></span>
                    <a class="btn btn-success" onclick="submit();">提出申请</a> 
                </div>
               
            </form>
        </div>
    </div>	
	
    

	
	
</body>
</html>
 