<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="YourProjectName.Product" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>صفحة المنتجات</title>
    <style>
        body { font-family: Arial, sans-serif; text-align: center; margin-top: 50px; }
        .container { display: inline-block; text-align: right; }
        .controls { margin: 10px 0; }
        .button-link { margin-top: 20px; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>اختيار المنتجات</h1>
            
            <div class="controls">
                <asp:Label ID="lblProduct" runat="server" Text="اختر منتج:"></asp:Label>
                <asp:DropDownList ID="ddlProduct" runat="server">
                    <asp:ListItem Text="لابتوب" Value="1500"></asp:ListItem>
                    <asp:ListItem Text="لوحة مفاتيح" Value="50"></asp:ListItem>
                    <asp:ListItem Text="ماوس" Value="25"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="controls">
                <asp:Label ID="lblQuantity" runat="server" Text="الكمية:"></asp:Label>
                <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
            </div>

            <div class="controls">
                <asp:Button ID="btnGoToSummary" runat="server" Text="اذهب إلى السلة" OnClick="btnGoToSummary_Click" />
            </div>

            <div class="button-link">
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            </div>

        </div>
    </form>
</body>
</html>
