function getlist(pid,jsonUrl)
{
    
    $.ajax({
        url: jsonUrl,
        type: "GET",
        dataType: "json",
        success: function(data) {
            var obj=document.getElementById(pid);
            var str="<thead><tr>"
            $.each(data.head, function(i, item) {
                str+="<th>"+item+"</th>"
                
            })
            str+="<th>详情</th>"
            str+="<th>执行</th>"
            str+="</tr></thead>"
            str+="<tbody>"
            $.each(data.body, function(i, item) {
                str+="<tr>"
                
                    
                $.each(item, function(j, element) {
                    str+="<td>"+element+"</td>"
                })
                
                str+="<td><button class=\"btn btn-primary\" onclick='detail(this.value)' value='"+data.values[i]+"'>详情</button></td>"
                str+="<td><button class=\"btn btn-danger\" onclick='exec(this.value)' value='"+data.values[i]+"'>执行并下载学籍excel</button></td>"
                    
                
                str+="</tr>"
                
            })
            str+="</tbody>"
            obj.innerHTML=str
            

        }
    })
}