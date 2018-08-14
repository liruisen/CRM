<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cropperJS.aspx.cs" Inherits="Demo.cropperJS" %>

<!DOCTYPE html>
<html lang="zh">

<head>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">

	<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
	<meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no, minimal-ui">
	<meta name="apple-mobile-web-app-capable" content="yes">
	<meta name="format-detection" content="telephone=no, email=no">
	<title>支持移动设备触摸手势的jQuery图片裁剪插件</title>
	<link rel="stylesheet" type="text/css" href="./123/default.css">
	<style>
		#clipArea {
			margin: 20px;
			height: 400px;
		}

		/*#file,*/
		#clipBtn {
			margin: 20px;
		}

		#view {
			margin: 0 auto;
			width: 200px;
			height: 200px;
		}
	</style>
	
</head>

<body>
	<article class="htmleaf-container">
		<header class="htmleaf-header">
			<h1>支持移动设备触摸手势的jQuery图片裁剪插件
				<span>A Support gesture image cropping plug-in</span>
			</h1>

		</header>
		<div id="clipArea" style="">
			<div class="photo-clip-view" style="">
				<div class="photo-clip-moveLayer" style="">
					<div class="photo-clip-rotateLayer"></div>
				</div>
			</div>
			<div class="photo-clip-mask" style="">
				<div class="photo-clip-mask-left" style=""></div>
				<div class="photo-clip-mask-right" style=""></div>
				<div class="photo-clip-mask-top" style=""></div>
				<div class="photo-clip-mask-bottom" style=""></div>
				<div class="photo-clip-area" style=""></div>
			</div>
		</div>
		<input type="file" id="file" accept="image/*">
		<button id="clipBtn">截取</button>
		<div id="view" style=""></div>
		<footer class="related">

		</footer>
	</article>

	<script src="./123/jquery.min.js "></script>
	<script src="./123/jquery.min.js(1) "></script>
	<script>
	    window.jQuery || document.write('<script src="js/jquery-2.1.1.min.js"><\/script>')
	</script>
	<script src="./123/iscroll-zoom.js "></script>
	<script src="./123/hammer.js "></script>
	<script src="./123/jquery.photoClip.js "></script>
	<script>
	    $("#clipArea").photoClip({
	        width: 400,
	        height: 400,
	        file: "#file",
	        view: "#view",
	        ok: "#clipBtn",
	        strictSize:true,
	        loadStart: function () {
	            console.log("照片读取中");
	        },
	        loadComplete: function () {
	            console.log("照片读取完成");
	        },
	        clipFinish: function (dataURL) {
	            console.log(dataURL);

	            $.ajax({
	                type: "post",
	                url: "cropperJS.aspx",
	                data: {
	                    name: dataURL,
	                },
	                success: function (datas) {//有错误
	                    if (datas.status == "success") {
	                        window.location = "login.html";//注册成功就跳转到login.html页面
	                    }
	                },
	                error: function () {
	                }
	            });
	        }
	    })
	    
    </script>

</body>

</html>