﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ConstructionInBoston.Projects.Default" %>


<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="/favicon.ico">

    <title>Construction in Boston</title>

    <!-- Bootstrap core CSS -->
    <link href="/css/bootstrap.min.css" rel="stylesheet">

    <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
    <link href="/css/ie10-viewport-bug-workaround.css" rel="stylesheet">

    <!-- Custom styles for this template -->
    <link href="/css/offcanvas.css" rel="stylesheet">

    <!-- Just for debugging purposes. Don't actually copy these 2 lines! -->
    <!--[if lt IE 9]><script src="../../assets/js/ie8-responsive-file-warning.js"></script><![endif]-->
    <script src="/scripts/ie-emulation-modes-warning.js"></script>

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>

<body>
    <nav class="navbar navbar-fixed-top navbar-inverse">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="/">ConstructionInBoston</a>
            </div>
            <div id="navbar" class="collapse navbar-collapse">
                <ul class="nav navbar-nav">
                    <li><a href="/">Home</a></li>
                    <li class="active"><a href="/Projects/">Projects</a></li>
                    <li><a href="/Contractors/">Contractors</a></li>
                    <li><a href="/Developers/">Developers</a></li>
                    <li><a href="/Architects/">Architects</a></li>
                </ul>
            </div>
            <!-- /.nav-collapse -->
        </div>
        <!-- /.container -->
    </nav>
    <!-- /.navbar -->

    <div class="container">

        <div class="row row-offcanvas row-offcanvas-right">

            <div class="col-xs-12 col-sm-9">
                <div class="jumbotron">
                    <h1>Projects</h1>
                    <p></p>
                    <p><a href="./AddProject.aspx" class="btn btn-default">Add a new project</a></></p>
                </div>
                <div class="row">
                    <asp:Repeater runat="server" ID="ProjectList" OnItemDataBound="ProjectList_OnItemDataBound">
                        <ItemTemplate>
                            <div class="col-xs-12 col-lg-4">
                                <h2>
                                    <asp:Literal runat="server" ID="ProjectHeader" /></h2>
                                <asp:Image runat="server" ID="ProjectImage" CssClass="img-thumbnail" />
                                <div class="panel">
                                    <p>
                                        <asp:Literal runat="server" ID="ProjectDescription" /></p>
                                    <p>
                                        <asp:HyperLink runat="server" ID="ProjectLink" CssClass="btn btn-default" role="button">View details &raquo;</asp:HyperLink></p>
                                </div>
                            </div>
                            <!--/.col-xs-6.col-lg-4-->
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <!--/row-->
            </div>
            <!--/.col-xs-12.col-sm-9-->
        </div>
        <!--/row-->

        <hr>

        <footer>
            <p>&copy; 2015 Matt Schroer</p>
        </footer>

    </div>
    <!--/.container-->


    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script>window.jQuery || document.write('<script src="/jquery.min.js"><\/script>')</script>
    <script src="/Scripts/bootstrap.min.js"></script>
    <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
    <script src="/scripts/ie10-viewport-bug-workaround.js"></script>
    <script src="/scripts/offcanvas.js"></script>
</body>
</html>

