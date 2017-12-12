<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModuleManage.aspx.cs" Inherits="SchoolWeb.Web.ModuleManager.ModuleManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../../Scripts/jQuery/jquery-3.2.1.min.js"></script>
    <script src="../../Content/bootstrap/js/bootstrap.min.js"></script>
    <link href="../../Content/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <!--引入bootstrap-table包-->
    <script src="../../Content/bootstrap-table/bootstrap-table.js"></script>
    <link href="../../Content/bootstrap-table/bootstrap-table.css" rel="stylesheet" />
    <script src="../../Content/bootstrap-table/locale/bootstrap-table-zh-CN.js"></script>
    <script src="../../Scripts/Manager/ModuleManage.js"></script>
    <script>
    </script>
</head>
<body>
<%--    <div class="panel-body" style="padding-bottom:0px;">
        <div class="panel panel-default">
            <div class="panel-heading">查询条件</div>
            <div class="panel-body">
                <form id="formSearch" class="form-horizontal">
                    <div class="form-group" style="margin-top:15px">
                        <label class="control-label col-sm-1" for="txt_search_departmentname">部门名称</label>
                        <div class="col-sm-3">
                            <input type="text" class="form-control" id="txt_search_departmentname">
                        </div>
                        <label class="control-label col-sm-1" for="txt_search_statu">状态</label>
                        <div class="col-sm-3">
                            <input type="text" class="form-control" id="txt_search_statu">
                        </div>
                        <div class="col-sm-4" style="text-align:left;">
                            <button type="button" style="margin-left:50px" id="btn_query" class="btn btn-primary">查询</button>
                        </div>
                    </div>
                </form>
            </div>
        </div>   --%>    

        <div id="toolbar" class="btn-group">
            <button id="btn_add" type="button" class="btn btn-default">
                <span class="glyphicon glyphicon-plus" aria-hidden="true"></span>新增
            </button>
            <button id="btn_edit" type="button" class="btn btn-default">
                <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>修改
            </button>
            <button id="btn_delete" type="button" class="btn btn-default">
                <span class="glyphicon glyphicon-remove" aria-hidden="true"></span>删除
            </button>
        </div>
        <table id="tb_departments"></table>
<%--    </div>--%>
    <div class="modal fade" id="ModuleModal">
    <div class="modal-dialog"style="width:800px" >
        <div class="modal-content">
            <div class="modal-header">
                 <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
<%--                <button type="button" class="close" onclick="window.history.go(-1);">×</button>--%>
                <h4 class="modal-title" id="NoPermissionModalLabel"></h4>
            </div>
            <div class="modal-body">
                <iframe id="Moduleiframe" width="100%" height="50%" frameborder="0"style="height:400px;overflow:auto; "></iframe>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default " data-dismiss="modal">    关  闭    </button>
<%--                <button class="btn btn-default"  type="button" onclick="window.history.go(-1);" >    关  闭    </button>--%>
            </div>
        </div>
    </div>
</div>
</body>
</html>
