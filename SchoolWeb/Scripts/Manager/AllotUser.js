$(function () {
    //1.初始化Table
    var oTable = new TableInit();
    oTable.Init();

    //2.初始化Button的点击事件
    var oButtonInit = new ButtonInit();
    $("#btn_add").click(function () {
        oButtonInit.Add();
    });

    var rows = window.parent.getrow();
    var row = rows[0];

    $.get("../Handler/GetUserRole.ashx", { method: 'getUser', Id: row.RoleId }, function (data) {
        var resultJson = eval('(' + data + ')');
        var datarow = $('#tb_departments').bootstrapTable('getData');
        $.each(datarow,function (i, item) {
            $.each(resultJson, function (index, element) {
                if (datarow[i].UserId == element.UserId) {
                    var a = datarow[i];
                    $('#tb_departments').bootstrapTable('updateRow', {
                        index: i,
                        row: {
                            0: true,
                        }
                    });
                    //item.0= true;
                }
            });
        });

    });

    //按钮点击事件
});


var TableInit = function () {
    var oTableInit = new Object();
    //初始化Table
    oTableInit.Init = function () {
        $('#tb_departments').bootstrapTable({
            url: '../Handler/GetUserModel.ashx',         //请求后台的URL（*）
            method: 'get',                      //请求方式（*）
            toolbar: '#toolbar',                //工具按钮用哪个容器
            striped: true,                      //是否显示行间隔色
            cache: false,                       //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
            pagination: true,                   //是否显示分页（*）
            sortable: true,                     //是否启用排序
            sortName: "Sort",
            sortOrder: "asc",                   //排序方式
            queryParams: oTableInit.queryParams,//传递参数（*）
            sidePagination: "server",           //分页方式：client客户端分页，server服务端分页（*）
            pageNumber: 1,                       //初始化加载第一页，默认第一页
            pageSize: 500,                       //每页的记录行数（*）
            pageList: [10, 25, 50, 100],        //可供选择的每页的行数（*）
            //search: true,                       //是否显示表格搜索，此搜索是客户端搜索，不会进服务端，所以，个人感觉意义不大
            strictSearch: true,
            showColumns: true,                  //是否显示所有的列
            showRefresh: true,                  //是否显示刷新按钮
            minimumCountColumns: 2,             //最少允许的列数
            clickToSelect: true,                //是否启用点击选中行
            //height: 500,                        //行高，如果没有设置height属性，表格自动根据记录条数觉得表格高度
            uniqueId: "UserId",                     //每一行的唯一标识，一般为主键列
            showToggle: true,                    //是否显示详细视图和列表视图的切换按钮
            cardView: false,                    //是否显示详细视图
            detailView: false,                   //是否显示父子表
            columns: [{
                checkbox: true
            }, {
                field: 'UserId',
                title: '用户名',
            }, {
                field: 'UserName',
                title: '真实姓名'
            }, {
                field: 'PassWord',
                title: '密码'
            }, {
                field: 'PhoneNumber',
                title: '电话'
            }, {
                field: 'SchoolCard',
                title: '校园卡号'
            }, {
                field: 'Sex',
                title: '性别'
            }, {
                field: 'DepId',
                title: '所属部门名称'
            }, {
                field: 'PosId',
                title: '所属职位名称'
            },]
        });
    };

    //得到查询的参数
    oTableInit.queryParams = function (params) {
        var temp = {   //这里的键的名字和控制器的变量名必须一直，这边改动，控制器也需要改成一样的
            limit: params.limit,   //页面大小
            offset: params.offset,  //页码
            departmentname: $("#txt_search_departmentname").val(),
            statu: $("#txt_search_statu").val()
        };
        return temp;
    };
    return oTableInit;
};

function getrow() {
    var row = $('#tb_departments').bootstrapTable('getSelections');
    return row;
}
function ObjUserId(userId) //声明对象
{
    this.UserId = userId;
}

var ButtonInit = function () {
    var oInit = new Object();
    var postdata = {};

    oInit.Init = function () {
        //初始化页面上面的按钮事件
    };
    oInit.Add = function () {
        var rows = window.parent.getrow();
        var row = rows[0];
        var userRows = $('#tb_departments').bootstrapTable('getSelections');
        var len = userRows.length;
        var UserId = new Array()
        $.each(userRows, function (i, item) {
            UserId.push(new ObjUserId(item.UserId));
        });
        $.get("../Handler/GetUserRole.ashx", { method: 'EditUserRole', RoleId: row.RoleId, length: len, rows: UserId }, function (data) {
            var resultJson = eval('(' + data + ')');
            if (resultJson.flag) {
                alert("分配成功！");
                //window.close();
                window.parent.location.reload();
            }
            else
                alert("分配失败！");

        });
    };

    return oInit;
};