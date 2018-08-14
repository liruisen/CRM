<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/css.css" rel="stylesheet" />
    <title>登录</title>
    <style type="text/css">
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
    <form action="Login.aspx" method="post">
        <div class="container login-box">
            <div class="col-lg-5 col-lg-offset-4">

                <div class="input-group">
                    <input type="text" name="empNo" value="<%:empNo %>" class="form-control" placeholder="请输入工号" />
                </div>

                <div class="input-group">
                    <input type="password" name="pwd" value="" class="form-control" placeholder="请输入密码" />
                </div>

                <div class="input-group">
                    <input type="text" name="checkCode" value="" class="form-control" placeholder="请输入验证码" />
                    <img src="handle/ValidateCodeHandler.ashx?num=1" id="ImgvCode" />
                </div>
                <input type="submit"  value="提交" class="btn btn-success" />
                <p><%:failedTips %></p>
            </div>
        </div>
    </form>
</body>
<script>
    function $(id) {
        return document.getElementById(id);
    }
    $("ImgvCode").onclick = function () {
        this.src = this.src + 1;
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
