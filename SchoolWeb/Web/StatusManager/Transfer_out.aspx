﻿<!DOCTYPE html>
<html>
<head>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1.0">
	<link rel="stylesheet" href="bootstrap/css/bootstrap.min.css">  
	<script src="jQuery/jquery-3.2.1.js"></script>
   	<script src="bootstrap/js/bootstrap.min.js"></script>
    <script src="clist.js"></script>
    <script src="sel_student.js"></script>
	<title>学籍管理系统</title>
</head>
<body id="fbody" style="padding:3px;background-color:#F6F4F0;height:100%">
    <script>
        var obj=document.getElementById("fbody")
        obj.style.height=(window.innerHeight).toString()+"px"
    </script>
    <div class="panel panel-default" style="padding: 0px;margin-bottom:1px">
        <div class="panel-heading" style="padding: 3px;padding-left:5px;padding-right:5px">
            <h5><strong>学籍管理 / 学生转出申请</strong></h5>
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
                                <input type="text" class="form-control" name="model_name" placeholder="姓名或学籍号">
                            </div>
                        </div>
                    </div>

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
                    <button type="button" class="btn btn-primary" data-dismiss="modal" onclick="getStudent('test')">确认选择</button>
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
                        <input id="stdname" type="text" class="form-control" name="stdname" placeholder="名字" disabled>
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">学籍号</label>
                    <div class="col-sm-8">
                        <input id="stdid" type="text" class="form-control" name="stdid" placeholder="学籍号" disabled>
                    </div>
                </div>
                
                <div class="form-group" style="margin-bottom:5px;margin-top:5px">
                    <label class="col-sm-2 control-label">转出学校</label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" name="schoolname" placeholder="学校名">
                    </div>
                </div>
                <div class="form-group" style="margin-bottom:5px">
                    <label class="col-sm-2 control-label">申请理由</label>
                    <div class="col-sm-8">
                        <textarea rows="3" class="form-control" name="rea" placeholder="申请理由"></textarea>
                    </div>
                </div>
                <div style="text-align: center;margin:10px"><button type="submit" class="btn btn-success">提出申请</button></div>
            </form>
        </div>
    </div>	
	
    

	
	
</body>
</html>
 