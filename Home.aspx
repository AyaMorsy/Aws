<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="AprioriWebApp2.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: left">
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           Hello to Apriori Algothim Test 
           
            <br />
            <br />
           
            <asp:Button ID="LoadFile" runat="server" Text="Load File" OnClick="LoadFile_Click" />
            <asp:Button ID="RefreshButton" runat="server" Text="Refresh" OnClick="RefreshButton_Click" />
            &nbsp;<br />
            
            </div>
        <%--<asp:Panel ID="flowLayoutPanel1" runat="server" Direction="LeftToRight">--%>
          <%--</asp:Panel>--%>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="ItemSetLabel" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        &nbsp;</td>
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="flowLayoutPanel1" runat="server">
                        </asp:Panel>
                    </td>
                    <td>
                        <asp:Panel ID="flowLayoutPanel2" runat="server">
                        </asp:Panel>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1"></td>
                    <td class="auto-style1"></td>
                    <td class="auto-style1"></td>
                </tr>
            </table>
      
        
        
    </form>
    </body>
</html>
