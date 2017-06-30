<%@ Page Async="true" Language="c#" Debug="true" MaintainScrollPositionOnPostback="true" %>

<%@ Import Namespace="FileFinder.Lib" %>
<%@ Import Namespace=" FileFinder.Lib.FileEvaluation" %>


<!DOCTYPE html>
<html lang="en">
<head>
    <title runat="server">File Finder</title>
    <link rel="stylesheet" href="/Content/bootstrap.css" />
    <style>
        .row {
            margin-top: 10px;
            margin-bottom: 15px;
        }

        .read-only {
            background-color: cornsilk;
        }

        .radio-with-caption {
            display: block;
        }

            .radio-with-caption input {
                margin-right: 5px;
            }

        input[type="radio"] + label {
            font-weight: normal;
        }
    </style>
</head>

<body>
    <div class="container">
        <h1 class="text-center">File Finder v.1</h1>
        <form id="Form1" runat="server">
            <div class="row">
                <label>Source folder</label>
                <asp:TextBox ID="startFolder" runat="server"
                    Text="C:\inetpub\wwwroot\sitecore01\Website\App_Config"
                    Width="100%" />
            </div>
            <div class="row">
                <label>Input patterns (delimit with newline or comma)</label>
                <asp:TextBox ID="inputPatterns" runat="server" Rows="4" TextMode="MultiLine" Width="100%" />
            </div>
            <div class="row">
                <label>Strategy</label>
                <div>
                    <asp:RadioButton ID="optFileContainsSubstring" runat="server"
                        CssClass="radio-with-caption"
                        GroupName="Strategy" Text="Filename contains substring"
                        Checked="true" />
                    <asp:RadioButton ID="optFileHasConfigExtension" runat="server"
                        CssClass="radio-with-caption"
                        GroupName="Strategy" Text="Filename contains substring and has .config extension" />
                    <asp:RadioButton ID="optFileDoesNotHaveConfigExtension" runat="server"
                        CssClass="radio-with-caption"
                        GroupName="Strategy" Text="Filename contains substring and DOES NOT HAVE .config extension" />
                </div>
            </div>

            <br />
            <div class="row">
                <asp:Button ID="ProcessJob" CssClass="btn btn-primary" Text="Find" OnClick="FindFiles" runat="server" Width="100%" />
            </div>
            <div class="row">
                <asp:Label ID="status" runat="server" />
            </div>
            <div class="row">
                <label>Output</label>
                <asp:TextBox ID="resultsTextbox" runat="server" Rows="20" TextMode="MultiLine" Width="100%" ReadOnly="true" CssClass="read-only" />
            </div>

        </form>
    </div>
    <script src="/Scripts/jquery-1.10.2.js"></script>
    <script src="/Scripts/bootstrap.js"></script>
</body>
</html>

<script runat="server">

    protected override void OnLoad(EventArgs e)
    {
        if (!Page.IsPostBack)
        {
        }
        base.OnLoad(e);
        Server.ScriptTimeout = int.MaxValue;
    }

    private async void FindFiles(object sender, EventArgs e)
    {
        var searchKeys = inputPatterns.Text
                           .Split(new string[] { Environment.NewLine, "," }, StringSplitOptions.RemoveEmptyEntries)
                           .Where(s => !string.IsNullOrWhiteSpace(s))
                           .ToArray();
        var output = new StringBuilder();

        IFileEvaluator fileEvaluator = null;
        if (optFileContainsSubstring.Checked)
        {
            fileEvaluator = new FilenameSubstringEvaluator();
        }
        else if (optFileHasConfigExtension.Checked)
        {
            fileEvaluator = new FilenameSubstringWithConfigExtensionEvaluator();
        }
        else if (optFileDoesNotHaveConfigExtension.Checked)
        {
            fileEvaluator = new FilenameSubstringWithoutConfigExtensionEvaluator();
        }

        var fileFinder = new Finder(
            new FindOptions
            {
                StartFolder = startFolder.Text,
                SearchKeys = searchKeys,
                FileEvaluator = fileEvaluator,
                Progress = new Progress<FindProgress>(progress =>
                {
                    if (progress.Phase == FindProgressPhase.Finding)
                    {
                        //statusLabel.Text = string.Format("{0} of {1}", progress.AllIndex, progress.AllTotal);
                        //Console.Out.WriteLine(string.Format("{0} of {1}", progress.AllIndex, progress.AllTotal));
                    }
                })
            }
        );

        var findResult = await fileFinder.Start();
        if (findResult.HadErrors)
        {
            Response.Write("Error occurred: " + findResult.Error.Message);
        }
        else
        {
            foreach (var result in findResult.Results)
            {
                output.AppendLine(result.FullFilename);
            }
            resultsTextbox.Text = output.ToString();
            status.Text = string.Format("Matches found: {0}", findResult.Results.Count);
        }
    }
</script>
