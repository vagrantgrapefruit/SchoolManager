<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StuInfo_pl.aspx.cs" Inherits="SchoolWeb.Web.StatusManager.StuInfo_pl" %>

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
        var obj = document.getElementById("fbody");
        obj.style.height = (window.innerHeight).toString() + "px";
    </script>
    <div class="panel panel-default" style="padding: 0px;margin-bottom:1px">
        <div class="panel-heading" style="padding: 3px;padding-left:5px;padding-right:5px">
            <h5><strong>新生入学 / 学籍批量导入</strong></h5>
        </div>
    </div>	 
	<div class="panel panel-default" style="padding: 0px;margin-bottom:0px">
        <div class="panel-heading" style="padding: 3px;padding-left:5px;padding-right:5px">
            <h5>上传本地excel:</h5>
        </div>
        <div class="panel-body" style="padding: 3px;padding-left:5px;padding-right:5px">
            <form role="form" class="form-inline">
                <div class="form-group">
                    <input class="btn btn-default" type="file" id="inputfile" />
                </div>
                <div class="form-group">
                    <button type="submit" class="btn btn-default">预览</button>
                </div>
            </form>
        </div>
    </div>
    <div class="panel panel-default" style="padding: 0px;height:calc( 100% - 135px );margin-bottom:0px">
        <div class="panel-heading" style="padding: 3px;padding-left:5px;padding-right:5px">
            <h5>上传预览</h5>
        </div>
        
        <div class="panel-body" style="padding: 3px;padding-left:5px;padding-right:5px;height:100%">
            <div style="overflow:scroll;max-height:calc( 100% - 100px )">  
                <table id="stutable" class="table table-responsive table-bordered table-hover">
                    <script>getlist("stutable","/static/list.json")</script>
                </table>
            </div>
            <div style="text-align: center;margin:10px">
                <button type="button" class="btn btn-success" style="margin-right:10px">提交</button>
                <button type="button" class="btn btn-warning">删除更改</button>
            </div>
        </div>
    </div>
    

	
	
</body>
</html>
