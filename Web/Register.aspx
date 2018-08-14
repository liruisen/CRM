<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Web.Register" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/css.css" rel="stylesheet" />
    <title></title>
    <style>
        img {
            cursor: pointer;
        }
			.search {
				text-align: center;
			}
			
			.search-input {
				display: inline-block;
			}
			body{
				margin-top: 4em;
			}
    </style>
</head>
<body>
    <nav class="navbar navbar-default navbar-fixed-top" role="navigation">
			<div class="container-fluid">
				<div class="navbar-header">
					<a href="#" class="navbar-brand">职工管理系统</a>
				</div>
				<div class="collapse navbar-collapse search ">
					<ul class="nav navbar-nav navbar-left" id=" mytab">
						<li class="active">
							<a href="CustomerList.aspx">首页</a>
						</li>
						<li class=" ">
							<a href="#">新增用户</a>
						</li>
					</ul>
					<form class="navbar-form search-input " role="search">
						<div class="form-group input-group  ">
							<input type="text" class="form-control " placeholder="搜索" />
							<span class="input-group-btn"><button class="btn btn-default">搜索</button></span>
						</div>
					</form>
					<ul class="nav navbar-nav navbar-right" id=" ">
						<li class="">
							<a href="Login.aspx">登录</a>
						</li>
						<li class=" ">
							<a href="Register.aspx">注册</a>
						</li>
						<li class="dropdown">
							<a href="#" class="dropdown-toggle" data-toggle = "dropdown">更多<span class="caret"></span></a>
							<ul class="dropdown-menu" role="menu">
								<li><a href="#">个人中心</a></li>
								<li><a href="#">退出</a></li>

							</ul>
						</li>
					</ul>
				</div>
			</div>
		</nav>
    <form action="Register.aspx" method="post">
        <h2>客户关系管理系统</h2>
        <div>
            <span>工号：</span>
            <input type="text" name="empNo" id="empId" autocomplete="off"  value="<%=this.EmpNo %>""/>
            <span id="empNoWorning" class="sp">6～8个字符，可使用字母数字下划线，需以字母开头</span>
            
        </div>

        <div>
            <span>密码：</span>
            <input type="password" name="empPwd" id="empPwd" autocomplete="off" />
            <span>6～16个字符，需要区分大小写</span>
        </div>
        <div>
            <span>再次输入密码：</span>
            <input type="password" name="empPwds" id="empPwds" autocomplete="off" />
            <span>6～16个字符，需要区分大小写</span>
            <span class="wrong"><%=this.pwdWrong %></span> 
                       
        </div>

        <div>
            <span>验证码：</span>
            <input type="text" name="vCode" value="" />
            <img src="handle/ValidateCodeHandler.ashx?num=1" id="ImgvCode" />
            <span class="wrong"><%=this.codeWrong %></span>
        </div>

        <br />
        <input type="submit" value="提交" />
    </form>

</body>
<script>
    function $(id){return document.getElementById(id)}

    var img = $("ImgvCode");
    img.onclick = function () {
        this.src = this.src + "1";
    }

    $("empId").focus();
    $("empId").onblur = function () {
        var empNo = this.value;
        if (empNo.length<=0||empNo.length>8) {
            $("empNoWorning").style.color = "red"
        } else {
            $("empNoWorning").style.display = "black";
        }
    }
</script>
<script src="js/jquery.min.js"></script>
<script src="js/bootstrap.min.js"></script>
    <script type="text/javascript">
        $("#mytab a").click(function (e) {
            e.preventDefault();
            $(this).tab("show");
        })
	</script>
</html>
