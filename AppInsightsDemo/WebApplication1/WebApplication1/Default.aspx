<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">   
    <link rel="stylesheet" type="text/css" href="Assets/bootstrap.css">    
    <link rel="stylesheet" type="text/css" href="Assets/Site.css">
    <title>Default Page</title>

</head>
<body>
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>      
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    <li><a href="Default.aspx">Home</a></li>
                </ul>                
            </div>
        </div>
    </div>
    <div class="container body-content">
            <form id="form1" runat="server">
   <div class="jumbotron">
    <h1>Visual Studio Application Insights</h1>
    <p class="lead">Detect issues, diagnose crashes and track usage in your mobile apps and web apps on Azure, IIS or J2EE</p>
    <p><a href="http://azure.microsoft.com/en-us/services/application-insights/" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
</div>

<div class="row">
    <div class="col-md-4">
        <h2>Features Include</h2>
        <p>
            Monitor usage and performance of live apps<br />
            Get immediate alerts on performance or availability issues<br />
            Get telemetry for existing web apps without redeploying <br />
            Supports a wide range of app types running on devices, servers or desktops!            
        </p>
        <p><a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301865">Learn more &raquo;</a></p>
    </div>
    <div class="col-md-4">
        <h2>Monitoring</h2>
        Monitor ASP.NET or J2EE web apps hosted anywhere: on Azure, or on other cloud services, or your own on-premises servers <br />
        Monitor Android, iOS, OSX and Windows apps, and more
    </div>
    <div class="col-md-4">
        <h2>Telemetry Data</h2>
       Search traces and exception logs for failure diagnosis <br />
        Track events, metrics, page views, users, crashes, dependencies, perf counters, response times
    </div>
</div>
    </form>
        <hr />
        <footer>
            <p>&copy; <%= DateTime.Now.Year %> - Karbyn</p>
        </footer>
    </div>

</body>
 
</html>

