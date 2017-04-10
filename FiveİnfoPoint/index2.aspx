<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index2.aspx.cs" Inherits="index2" %>

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

	<style>

	body {
	
		background-color: #edf0f1;
		
		
		
	}
	
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
		background-image: url("search-icon.png"); 
		
		
	
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
		border-bottom-color: #d8d5d5;
		z-index: 9999;
		padding-top:10px;
		
		
	}
	
	.navbar .nav > li > a {
	
		color: #4d4d4d;
		border-bottom : 3px solid #edf0f1;
		
		padding-bottom: 25px;
		font-family: Segoe UI;
		font-weight:400;
		font-size: 1.15em;
	
	
	}
	
	.navbar .nav > li > a:visited {
	
		color: #4d4d4d;
		border-bottom : 3px solid #edf0f1;
		
		
		font-family: Segoe UI;
		font-weight:400;
		font-size: 1.15em;
	
	}
	
	.navbar .nav > li > a:hover {
	
		color: #4d4d4d;
		border-bottom : 3px solid  #ff9643;
		
	}
	
	.navbar .nav li {
    width: 200px;
    display: inline-block;
    float: none;
}

    .navbar .nav {
    float: right;
    text-align: center;
}
	
    .navbar-inverse .navbar-collapse, .navbar-inverse .navbar-form {
    border-color: #d8d5d5;
}

    .navbar-inverse .navbar-toggle {
    border-color: #edf0f1;
	
}

    .navbar-toggle {

	margin-bottom: 18px;

}

    .navbar-inverse .navbar-toggle .icon-bar {
    
	background-color: #ff9643;
	
}

    .navbar-inverse .navbar-toggle:hover {
    
	background-color: #edf0f1;
	
}

    .navbar-inverse .navbar-toggle:focus {
    
	background-color: #edf0f1;
	
}

    .navbar-brand {

	padding: 11px 15px;

}

    .resultBox {
	
	min-height: 411px;
	padding: 24px;
	float:left;
		
}

    .resultBoxExp {
	
	min-height: 411px;
	padding: 24px;
	float:left;
	
	
		
}

    .boxTitle {

	
	padding-bottom:50px;

}

    .boxIcon{

float: left;

}

    .titleText{
	
	margin-left: 6px;
	font-family: Segoe UI;
	color: #808080;
	font-size: 15pt;
	font-weight: 600;
	float: left;
	
	
}

    .resultShoutKeyword {

	font-family: Segoe UI;
	font-size: 28pt;
	color: #808080;
	font-weight: 600;
	

}

    .resultShout {

	font-family: Segoe UI;
	font-size: 28pt;
	color: #808080;
	font-weight: 200;
	padding-bottom: 32px;
	background-color: #edf0f1;
	
	
	
	

}

    .boxContent {

	line-height:22pt;
	padding-top:20px;
	padding-left:25px;
	padding-right:25px;
    width: 400px;
white-space: nowrap;
overflow: hidden;
text-overflow: ellipsis;
	
	

}
	    .boxContent2 {
	        line-height: 22pt;
	        padding-top: 20px;
	        padding-left: 25px;
	        padding-right: 25px;
	    }


    .boxContent a:hover {
	color: #ff9643;
	underline:none;
}

    .divider {

height: 2px;
margin-top: 10px;
margin-bottom:9px;
background-color:#ff9643;




}

    .containMe
{
	background-color: white;
	border: 1px solid #e6e2e2;
}

    .shodanTitles {

	font-family: Segoe UI;
	font-size: 14pt;
	font-weight: 600;
	color: #ff9643;

}

    .searchBox {

	
	background-color:#ff9643;
	width: 100px;
	height: 100px;
	position: fixed;
	bottom:50px;
	right:50px;
	
	

}

    .searchImg {

		right:0;
		left:0;
		top:0;
		bottom:0;
		margin:auto;
		position: absolute;
		

}

</style>
</head>

<body>
  <a href="index.aspx"><div class="searchBox">

	<img class="searchImg"  src="image/search.png"></img>

</div></a>
	<div style="padding-top:120px;" class="container">
	
	<section>
	
		<div class="resultShout">
			<span class="resultShoutKeyword" id="id_ShoutKeyword" runat="server"></span>&nbspiçin sonuçlar</div>
		
	
	</section>
	
	<section>
	<div class="container containMe">
	
	<div class="row ">
		<div class="col-sm-12 col-md-12 col-xs-12  col-lg-6 resultBox">
			<div class="boxTitle">
				<img class="boxIcon" src="image/fb.png"></img>
				<div class="titleText">Facebook</div>
				</div>
			<div class="boxContent" id="facebookContent" runat="server"></div>
		</div>
		
	
		<div class="col-sm-12 col-md-12 col-xs-12  col-lg-6 resultBox">
			<div class="boxTitle">
				<img class="boxIcon" src="image/tw.png"></img>
				<div class="titleText"  runat="server">Twitter</div>
				</div>
			<div class="boxContent" id="twitterContent" runat="server"></div>
		</div>
		
		<div class="col-sm-12 col-md-12 col-xs-12  col-lg-6 resultBox">
			<div class="boxTitle">
				<img class="boxIcon" src="image/reddit.png"></img>
				<div class="titleText">Reddit</div>
				</div>
			<div class="boxContent" id="redditContent" runat="server"></div>
		</div>
		
		<div class="col-sm-12 col-md-12 col-xs-12  col-lg-6 resultBox">
			<div class="boxTitle">
				<img class="boxIcon" src="image/googleplus.png"></img>
				<div class="titleText">Google Plus</div>
				</div>
			<div class="boxContent" id="googleplusContent" runat="server"></div>
		</div>
		
		<div class="col-sm-12 col-md-12 col-xs-12  col-lg-6 resultBox">
			<div class="boxTitle">
				<img class="boxIcon" src="image/in.png"></img>
				<div class="titleText">LinkedIn</div>
				</div>
			<div class="boxContent" id="linkedinContent" runat="server"></div>
		</div>
		
		<div class="col-sm-12 col-md-12 col-xs-12  col-lg-6 resultBox">
			<div class="boxTitle">
				<img class="boxIcon" src="image/gnews.png"></img>
				<div class="titleText">Google News</div>
				</div>
			<div class="boxContent" id="googlenewsContent" runat="server"></div>
		</div>
		
		<div class="col-sm-12 col-lg-12 col-md-12 col-xs-12 divider">
		</div>
		
		<div class="col-sm-12 col-md-12 col-xs-12  col-lg-12 resultBoxExp">
			<div class="boxTitle">
				<img class="boxIcon" src="image/whois.png"></img>
				<div class="titleText">Who Is?</div>
				</div>
			<div class="boxContent2" id="whoisContent" runat="server"></div>
		</div>
		
		<div class="col-sm-12 col-lg-12 col-md-12 col-xs-12 divider">
		</div>
		
		<div class="col-sm-12 col-md-12 col-xs-12  col-lg-12 resultBoxExp">
			<div class="boxTitle">
				<img class="boxIcon" src="image/wiki.png"></img>
				<div class="titleText">Wikipedia?</div>
				</div>
			<div class="boxContent2" id="wikipediaContent"  runat="server"></div>
		</div>
		
		<div class="col-sm-12 col-lg-12 col-md-12 col-xs-12 divider">
		</div>
		
		
		<div class="col-sm-12 col-md-12 col-xs-12  col-lg-12 resultBoxExp">
			<div class="boxTitle">
				<img class="boxIcon" src="image/geo.png"></img>
				<div class="titleText">Geocode</div>
				</div>
			<div class="boxContent" id="GeocodeContent" runat="server"></div>
		</div>
		
		
		<div class="col-sm-12 col-lg-12 col-md-12 col-xs-12 divider">
		</div>
		
		
		<div class="col-sm-12 col-md-12 col-xs-12  col-lg-12 resultBoxExp">
			<div class="boxTitle">
				<img class="boxIcon" src="image/shodan.png"></img>
				<div class="titleText">Shodan</div>
				</div>
			<div class="boxContent" id="ShodanContent" runat="server">
				
				<div class="col-sm-12 col-md-12 col-xs-12  col-lg-6 resultBoxExp">
						<div class="shodanTitles">
						
							ORG
						</div>
						
					<div id="orgContent" runat="server">
						
							</div>
							
						<div class="shodanTitles">
						
							ISP
						</div>
						
					<div id="ispContent" runat="server">
						
							</div>
							
						<div class="shodanTitles">
						
							COUNTRY
						</div>
						
					<div id="countryContent" runat="server">
						
							</div>
							
						<div class="shodanTitles">
						
							IPSTR
						</div>
						
					<div id="ipstrContent" runat="server">
						
							</div>
							
						<div class="shodanTitles">
						
							PORT
						</div>
						
					<div id="portContent"  runat="server">
						
							</div>
							
						
                    <div class="shodanTitles">
						
							ASN
						</div>
						
					<div id="asnContent"  runat="server">
						
							</div>
				</div>
				
				<div class="col-sm-12 col-md-12 col-xs-12  col-lg-6 resultBoxExp">
				<div class="shodanTitles" runat="server">
						
							LAST UPDATE
						</div>
						
					<div id="lastupContent" runat="server">
						
							</div>
					
				</div>
						
				</div>
		</div>
		
		
		
	</div>
	</div>
	
	
	</section>
	
	
		<!--NavBar-->
		<nav class="navbar navbar-inverse navbar-fixed-top" id="navbar-custom">
			
			<div class="container">
				<!--Navbar Header start-->
				<div class="navbar-header"> 
				
					
					<button type="button" class="navbar-toggle navbar-toggle-custom" data-toggle="collapse" data-target="#navbar-collapse">
						<span class="icon-bar"></span>
						<span class="icon-bar"></span>
						<span class="icon-bar"></span>
						<span class="icon-bar"></span>
					</button>
					<a href="#"  class="navbar-brand"><img  src="image/bottom-logo.png"></img></a>
					
				</div>
				<!--Navbar Header End-->
				<div   class="collapse navbar-collapse navbar-collapse-custom" id="navbar-collapse">
				
				
					<ul   class="nav navbar-nav">
						<li><a href="About.aspx">Proje Hakkinda</a>
						<li><a href="index.aspx">Five Information Point</a>
					</ul>
				</div>
			</div>
			
		</nav> 
	</div>

</body>

</html>

