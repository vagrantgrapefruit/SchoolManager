<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SchoolWeb.ModuleManager.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8"/>
	<meta name="viewport" content="width=device-width, initial-scale=1.0"/>
	<link rel="stylesheet" href="../../Content/bootstrap/css/bootstrap.min.css"/>  
	<script src="../../Scripts/jQuery/jquery-3.2.1.min.js"></script>
   	<script src="../../Content/bootstrap/js/bootstrap.min.js"></script>
	<script src="../../Scripts/web/index.js"></script>
	<title>学校管理系统</title>
</head>
<body style="padding-top:52px;background-color:#F6F4F0;">
    <nav class="navbar navbar-default navbar-fixed-top navbar-inverse" role="navigation" style="box-shadow: 0px 0px 5px #666666;">
	    <div class="container-fluid">
	    <div class="navbar-header">
	        <a class="navbar-brand" href="#">学校管理系统</a>
	    </div>
	    <div>
	        <ul class="nav navbar-nav pull-right">
	            <!--<li><a href="#"><span class="glyphicon glyphicon-user" > 用户</span></a></li>-->
			</ul>
	    </div>
	    </div>
	</nav>	
	

	<div id="mframe" style="padding-left:2px;padding-right:2px">
		<script>
			var obj=document.getElementById("mframe")
			obj.style.height=(window.innerHeight-53).toString()+"px"
		</script>
		<div id="lframe" style="float:left;width:200px;height:100%;padding-left:1px;padding-right:1px;box-shadow: 0px 0px 15px #666666;">
			<div class="panel-group" id="accordion" >
				<script>getNav("accordion","./Index.aspx",<%=Session["UserName"].ToString()%>);</script>	
			</div>
		</div>
		
		<div id="rframe" style="float:right;width:calc( 100% - 205px );height:100%; padding-left:2px;padding-right:2px"> 
			<iframe id="iframe" frameborder=0 src="test.html" style=" width:100%;height:100%;"></iframe>
		</div>
	</div>
</body>
</html>
