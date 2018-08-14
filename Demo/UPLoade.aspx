<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UPLoade.aspx.cs" Inherits="Demo.UPLoade" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="js/jquery1.7.2.js"></script>
    <script src="js/uploadPreview.js"></script>
    <title></title>
    <style>
        body {
            margin: 20px 200px;
        }
    </style>
    <script>
        function xxx() {
            $("#up").uploadPreview({
                Img: "ImgPr",
                Width: 683,
                Height: 384,
                ImgType: ["gif", "jpeg", "jpg", "bmp", "png"],
                Callback: function () { }
            });
        }
        

    </script>
</head>
<body>
    <form method="post" action="UPLoade.aspx" enctype="multipart/form-data">
       

        <div>
            <img id="ImgPr" width="683" height="384" />
        </div>
        <input type="file" id="up" onclick="xxx()" name="loagFile" />
        <input type="submit" value="上传" />


    </form>
</body>
</html>
