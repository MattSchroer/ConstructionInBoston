<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProject.aspx.cs" Inherits="ConstructionInBoston.Projects.AddProject" %>

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
                    <h1>Add a new project</h1>
                </div>
                <div class="row">
                    <form runat="server">
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="NameBox">Name</asp:Label>
                            <asp:TextBox runat="server" class="form-control" ID="NameBox" placeholder="Name"/>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="AddressBox">Address</asp:Label>
                            <asp:TextBox runat="server" class="form-control" ID="AddressBox" placeholder="Address" />
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="PermitBox">Permit Number</asp:Label>
                            <asp:TextBox runat="server" class="form-control" ID="PermitBox" placeholder="Permit Number" />
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="FloorBox">Floor Count</asp:Label>
                            <asp:TextBox runat="server" class="form-control" ID="FloorBox" placeholder="Floor count" />
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="FootageBox">Square Footage</asp:Label>
                            <asp:TextBox runat="server" class="form-control" ID="FootageBox" placeholder="Square footage" />
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="NeighborhoodBox">Neighborhood</asp:Label>
                            <asp:TextBox runat="server" class="form-control" ID="NeighborhoodBox" placeholder="Neighborhood" />
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="DeveloperCombo">Developer</asp:Label>
                            <asp:DropDownList runat="server" class="form-control" ID="DeveloperCombo" />
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="ContractorCombo">Contractor</asp:Label>
                            <asp:DropDownList runat="server" class="form-control" ID="ContractorCombo" />
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="ArchitectCombo">Architect</asp:Label>
                            <asp:DropDownList runat="server" class="form-control" ID="ArchitectCombo" />
                        </div>
                        <%--<div class="form-group">
                            <label for="exampleInputFile">File input</label>
                            <input type="file" id="exampleInputFile">
                            <p class="help-block">Example block-level help text here.</p>
                        </div>--%>
                        <asp:Button ID="CancelButton" CausesValidation="False" OnClick="CancelButton_OnClick" CssClass="btn btn-danger" runat="server" Text="Cancel" />
                        <asp:Button ID="SubmitButton" OnClick="SubmitButton_OnClick" type="submit" CssClass="btn btn-success" runat="server" Text="Submit" />
                        <p class="error">
                            <asp:Literal runat="server" ID="ErrorMessage"/>
                        </p>
                    </form>
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
