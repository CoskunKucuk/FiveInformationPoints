<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
	<meta charset="utf-8">
	<title>Five Information Point </title>
	<meta name="description" content="Five Information Poin - Your Best Search Engine">
	<!-- Latest compiled and minified CSS -->
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" integrity="sha384-1q8mTJOASx8j1Au+a5WDVnPi2lkFfwwEAa8hDDdjZlpLegxhjVME1fgjWPGmkzs7" crossorigin="anonymous">
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
<script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>

</head>

<style>
	body {background-color: #edf0f1;}
	.searchBar {
		height:50px;
		border: 1px solid;
		border-color: #cecccc;
		width: 100%;
		font-family: Segoe UI;
		font-size:22px ;
		font-style: regular;
		color:#808080;
		padding:10px;
		outline:none;
	}
	.searchIcon {
		position: absolute;
		z-index: 9998;
		right: 16px;
		top: 1px;
		width:56px;
		height:48px;
		background-image: url("image/search-icon.png"); 
		}
    .searchBar:focus {
		border-color:#ffc136;
		box-shadow: 0px 0px 4px #ffc136;
		outline:none;
	}
	.slogan{
		font-family: Segoe UI;
		font-weight:200;
		font-size: 1.80em;
		color: #808080;
		text-align:center;
		padding-top:20px;
	}
	#navbar-custom {
		background-color: #edf0f1;
		border-top-color: #d8d5d5;
		z-index: 9999;
	}
	.navbar .nav > li > a {
		color: #4d4d4d;
		border-top : 3px solid #edf0f1;
		padding-top: 20px;
		padding-bottom: 40px;
		font-family: Segoe UI;
		font-weight:400;
		font-size: 1.15em;
    }
	.navbar .nav > li > a:hover {
		color: #4d4d4d;
		border-top : 3px solid  #ff9643;
	}
	.navbar .nav li {
    width: 200px;
    display: inline-block;
    float: none;
    }
    .navbar .nav {
    float: none;
    text-align: center;
    }
	</style>
    
<body>
    
	<form id="form1" runat="server">
    
	<div style="padding-top:12%;" class="container ">
		<section>
			<div class="row">
				<div class="col-sm-12">
					<img style="margin: 0 auto;" src="image/logo.png" class="img-responsive text-center"></img>
				</div>
			   
			</div>
			<div style="padding-top:36px;" class="row ">
				<div   class="col-sm-8  col-sm-offset-2">
					<a runat="server" id="SearchButton"><div class="searchIcon"></div></a>
					<input  type="text" class="searchBar"  id="SearchBar_txt" runat="server"></input>
                   
				</div>
				
				<div class="container">
				<div  class="row">
					<div class="col-sm-8 col-sm-offset-2">
						<div class="slogan">
							<span style="font-weight:bold;">One</span> word for <span style="font-weight:bold;">five</span> different knowledge!
						</div>
					</div>
				</div>
				</div>
			</div>
		</section>
		
		
		
		<section>
			<div style="padding-top:36px;" class="row">
				<div  class="col-sm-12">
					<img style="margin: 0 auto;" src="image/bottom-logo.png" class="img-responsive text-center"></img>
				</div>
			</div>
		</section>
		
		<nav class="navbar navbar-inverse navbar-fixed-bottom" id="navbar-custom">
			
			<div class="container">
				<!--Navbar Header start-->
				<div class="navbar-header">
					<button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#navbar-collapse">
						<span class="icon-bar"></span>
						<span class="icon-bar"></span>
						<span class="icon-bar"></span>
						<span class="icon-bar"></span>
					</button>
					
					
				</div>
				<!--Navbar Header End-->
				<div   class="collapse navbar-collapse " id="navbar-collapse">
				
				
					<ul   class="nav navbar-nav">
						<li><a href="#about">Proje Hakkinda</a>
						<li><a href="#fip">Five Information Point</a>
					</ul>
				</div>
			</div>
			<!--Container End-->
		</nav> 
	</div>













    </form>













</body>
</html>
