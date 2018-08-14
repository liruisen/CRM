<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VCode.aspx.cs" Inherits="Web.VCode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        img {
            cursor: pointer;
        }
    </style>
</head>
<body>
    <form action="VCode.aspx" method="post">
        <input type="text" name="txtVCode" value="" />
        <img src="ValidateCodeHandler.ashx?num=1" id="vCodeImg" />

        <input type="submit" value="提交" />
    </form>

</body>
<script>
    var img = document.getElementById("vCodeImg");
    img.onclick = function () {
        this.src = this.src + "1";
    }
</script>
</html>
