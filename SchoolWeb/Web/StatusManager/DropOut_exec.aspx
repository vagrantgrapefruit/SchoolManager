﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DropOut_exec.aspx.cs" Inherits="SchoolWeb.Web.StatusManager.DropOut_exec" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta charset="utf-8"/>
	<meta name="viewport" content="width=device-width, initial-scale=1.0"/>
	<link rel="stylesheet" href="../../Content/bootstrap/css/bootstrap.min.css"/>  
	<script src="../../Scripts/jQuery/jquery-3.2.1.min.js"></script>
   	<script src="../../Content/bootstrap/js/bootstrap.min.js"></script>
	<script src="../../Scripts/web/execlist.js"></script>
    <script src="../../Scripts/web/sel_student.js"></script>
	<title>学籍管理系统</title>
</head>
<body id="fbody" style="padding:3px;background-color:#F6F4F0;height:100%">
    <script>
        var obj=document.getElementById("fbody")
        obj.style.height=(window.innerHeight).toString()+"px"

        function detail(value){
            $.ajax({
                url: "/static/detail.json",
                type: "GET",
                dataType: "json",
                success: function(data) {
                    document.getElementById("stdid").value=data.stdId;
                    document.getElementById("name").value=data.name;
                    document.getElementById("detail").value=data.detail;
                    $("#Modal").modal();  
                }
            })

        }
    </script>
    <div class="panel panel-default" style="padding: 0px;margin-bottom:1px">
        <div class="panel-heading" style="padding: 3px;padding-left:5px;padding-right:5px">
            <h5><strong>学籍管理 / 学生退学执行</strong></h5>
        </div>
    </div>	 

    <div class="modal fade" id="Modal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel">申请详情</h4>
                </div>
                <div class="modal-body">
                    <div class="panel panel-default" style="padding: 0px;margin-bottom:1px">
                        <div class="panel-body" style="padding: 3px;padding-left:5px;padding-right:5px">
                            <div >
                                <form class="form-horizontal">
                                <div class="form-group" style="margin-bottom:5px">
                                    <label class="col-sm-3 control-label">学号</label>
                                    <div class="col-sm-8">
                                        <input type="text" class="form-control" id="stdid">
                                    </div>
                                </div>
                                <div class="form-group" style="margin-bottom:5px">
                                    <label class="col-sm-3 control-label">姓名</label>
                                    <div class="col-sm-8">
                                        <input type="text" class="form-control" id="name">
                                    </div>
                                </div>
                                <div class="form-group" style="margin-bottom:5px">
                                    <label class="col-sm-3 control-label">详情</label>
                                    <div class="col-sm-8">
                                        <textarea class="form-control" id="detail"></textarea>
                                    </div>
                                </div>
                                </form>
                            </div>
                        </div>
                    </div>

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
                </div>
            </div><!-- /.modal-content -->
        </div><!-- /.modal -->
    </div>

    <div class="panel panel-default" style="padding: 0px;margin-bottom:1px">
            
        <div class="panel-body" style="padding: 3px;padding-left:5px;padding-right:5px">

            <table id="stutable" class="table table-responsive table-bordered table-hover">
                <script>getlist("stutable","/static/execlist.json")</script>
            </table>
        </div>
    </div>	
	
    

	
	
</body>

</html>
