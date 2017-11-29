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
            str+="<th>审核通过</th>"
            str+="<th>审核不通过</th>"
            str+="</tr></thead>"
            str+="<tbody>"
            $.each(data.body, function(i, item) {
                str+="<tr>"
                
                    
                $.each(item, function(j, element) {
                    str+="<td>"+element+"</td>"
                })
                
                str+="<td><button class=\"btn btn-primary\" onclick='detail(this.value)' value='"+data.values[i]+"'>详情</button></td>"
                if(data.status[i]=="none"){
                    str+="<td><button class=\"btn btn-success\" onclick='pass(this.value)' value='"+data.values[i]+"'>审核通过</button></td>"
                    str+="<td><button class=\"btn btn-danger\" onclick='reject(this.value)' value='"+data.values[i]+"'>审核不通过</button></td>"
                }
                else if(data.status[i]=="pass"){
                    str+="<td>已通过</td>"
                    str+="<td>已通过</td>"
                }
                else{
                    str+="<td>已驳回</td>"
                    str+="<td>已驳回</td>"
                }
                    
                
                str+="</tr>"
                
            })
            str+="</tbody>"
            obj.innerHTML=str
            

        }
    })
}