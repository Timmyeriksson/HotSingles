

function addPost() {
    var TextContent = $('#TextContent').val();
    var SenderID = 'test';
    var RecieverID = 'test';
    var newPost = { SenderID: SenderID, RecieverID: RecieverID, TextContent: TextContent };
    //$.ajax({
    //    type: 'POST',
    //    url: '@Url.Action("insertPost", "Post", new { httproute = "" })',
    //    data: JSON.stringify(newPost),
    //    contentType: 'application/json',
    //    datatype: 'json',
    //    success: function (data) {
    //        $('#TextContent').val('');
    //        //Refreshar sidan efter lyckat inlägg.
    //        location.reload();
    //    }
    //});


    $.ajax({
        type: 'POST',
        url: 'http:/localhost:55016/api/Post/insertPost',
        data: JSON.stringify(newPost),
        contentType: 'application/json',
        datatype: 'json',
        success: function (data) {
            alert("hej");
        },
        error: function (xhr, ajaxOptions, thrownError) {
            //some errror, some show err msg to user and log the error  
            alert("hejdå");

        }
    });
}