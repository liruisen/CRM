<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerList.aspx.cs" Inherits="Web.CustomerList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <title></title>
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
		
    <div class="container">
        <table class="table table-hover">
            <thead>
                <tr>
                    <th>序号</th>
                    <th>姓名</th>
                    <th>性别</th>
                    <th>住址</th>
                    <th>所在单位</th>
                    <th>联系电话</th>
                    <th>更多</th>
                </tr>
            </thead>
            <tbody>
                <%=this.ctmTrs %>
            </tbody>
        </table>
    </div>

    <%--<nav>
			<ul class="pager">
                <li class="disabled">
					<a href="#">首页</a>
				</li>
				<li>
					<a href="#">上一页</a>
				</li>
				<li>
					<a href="#">1</a>
				</li>
				<li>
					<a href="#">下一页</a>
				</li>
                <li>
					<a href="#">尾页</a>
				</li>
			</ul>
		</nav>--%>

    <%=pageLink %>
</body>

    <script src="js/jquery.min.js" type="text/javascript" charset="utf-8"></script>
	<script src="js/bootstrap.min.js" type="text/javascript" charset="utf-8"></script>
	<script type="text/javascript">
	    $("#mytab a").click(function (e) {
	        e.preventDefault();
	        $(this).tab("show");
	    })
	</script>
</html>
