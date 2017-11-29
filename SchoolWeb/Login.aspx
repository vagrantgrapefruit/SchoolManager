<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SchoolWeb.Login" %>

<!DOCTYPE html>
<html lang="en" class="no-js">
<head runat="server">
<meta charset="UTF-8" />
<meta http-equiv="X-UA-Compatible" content="text/html; charset=utf-8"> 
<meta name="viewport" content="width=device-width, initial-scale=1"> 
<title>login</title>
<link rel="stylesheet" type="text/css" href="Content/normalize.css" />
<link rel="stylesheet" type="text/css" href="Content/demo.css" />
<!--必要样式-->
<link rel="stylesheet" type="text/css" href="Content/component.css" />
<!--<script src="Scripts/html5.js"></script>-->
<script src="Scripts/jquery-1.10.2.min.js"></script>
<!--<script src="Scripts/Account.js"></script>-->
<script>
    $(function () {
        $("#LoginSys").click(function () {
            LoginSys();
        });
        $("#UserName").keydown(function (e) {
            var curkey = e.which;
            if (curkey == 13) {
                LoginSys();
                return false;
            }
        });
        $("#Password").keydown(function (e) {
            var curkey = e.which;
            if (curkey == 13) {
                LoginSys();
                return false;
            }
        });
        /*$("#ValidateCode").keydown(function (e) {
            var curkey = e.which;
            if (curkey == 13) {
                LoginSys();
                return false;
            }
        });*/


    });
function LoginSys() {
    $("#mes").html(""); 
            $("#UserName").removeClass("input-validation-error");
            $("#Password").removeClass("input-validation-error");
            $("#ValidateCode").removeClass("input-validation-error");
            if ($.trim($("#UserName").val()) == "") {
                $("#UserName").addClass("input-validation-error").focus();
                $("#mes").html("用户名不能为空！");
                return;
            }
            if ($.trim($("#Password").val()) == "") {
                $("#Password").addClass("input-validation-error").focus();
                $("#mes").html("密码不能为空！");
                
                return;
            }

            $.get("/Login.aspx", { method: 'login', UserName: $("#UserName").val(), Password: $("#Password").val() }, function (data) {
                debugger;
                var resultJson = eval('(' + data + ')');
                if (resultJson.flag == "1") {
                    window.location.href = "Web/ModuleManager/Index"; 
                }
                else {
                    $("#mes").html("用户名或密码错误！");
                }

            });
            //$.ajax({               
            //    async: false,
            //    type: "get",
            //    url: "Login.aspx",
            //    data: { method: 'Login', UserName: $("#UserName").val(), Password: $("#Password").val() },             
            //    success: function (data) {
            //        debugger;
            //        var resultJson = eval('(' + data + ')');
            //        if (resultJson.type == "1")
            //        {
            //            window.location.href = "ModuleManager/Index"; 
            //        }
            //        else {
            //            alert("用户名或密码错误!");
            //        }
            //    }, 
            //});
            return false;  
        };
</script>
</head>
<body>
		<div class="container demo-1">
			<div class="content">
				<div id="large-header" class="large-header">
					<canvas id="demo-canvas"></canvas>
					<div class="logo_box">
						<h3>欢迎你</h3>
						<form action="#" name="f" method="post" runat="server">
							<div class="input_outer">
								<span  class="u_user"></span>
								<input id="UserName" name="UserName" class="text" style="color: #FFFFFF !important" type="text" >
							</div>
							<div class="input_outer">
								<span  class="us_uer"></span>
								<input id="Password" name="Password" class="text" style="color: #FFFFFF !important; position:absolute; z-index:100;"value="" type="password" >
							</div>
							<div class="mb2">
                                <span id="mes" ></span>
                                <a id="LoginSys" name="LoginSys" class="act-but submit" href="javascript:;" style="color: #FFFFFF">登录</a></div>
						</form>
					</div>
				</div>
			</div>
		</div><!-- /container -->
		<script src="Scripts/TweenLite.min.js"></script>
		<script src="Scripts/EasePack.min.js"></script>
		<script src="Scripts/rAF.js"></script>
		<script src="Scripts/demo-1.js"></script>
	</body>
</html>
