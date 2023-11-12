<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormInventoryStaff.aspx.cs" Inherits="RestoClerkInventory.GUI.WebFormInventoryStaff" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   <link rel="stylesheet" type="text/css" href="css/styleStaff.css"/>
    <style type="text/css">
        .auto-style13 {
            border-radius: 5px;
            font-size: 16px;
            text-align: center;
            border: 1px solid #ccc;
            margin-bottom: 10px;
            padding: 10px;
        }
        .auto-style14 {
            text-align: center;
        }
        .auto-style15 {
            font-size: large;
        }
        .auto-style16 {
            font-size: xx-large;
        }
        .auto-style18 {
            border-radius: 5px;
            font-size: 16px;
            height: 18px;
            border: 1px solid #ccc;
            margin-bottom: 10px;
            padding: 10px;
        }
        .auto-style19 {
            height: 18px;
        }
        .auto-style20 {
            border-radius: 5px;
            font-size: 16px;
            height: 15px;
            border: 1px solid #ccc;
            margin-bottom: 10px;
            padding: 10px;
        }
        .auto-style21 {
            height: 15px;
        }
        .auto-style22 {
            width: 88%;
            height: 594px;
        }
        .auto-style23 {
            width: 404px;
            border-radius: 5px;
            font-size: 17px;
            height: 53px;
            border: 1px solid #ccc;
            margin-bottom: 10px;
            padding: 10px;
        }
        .auto-style24 {
            width: 286px;
            border-radius: 5px;
            font-size: 17px;
            height: 53px;
            border: 1px solid #ccc;
            margin-bottom: 10px;
            padding: 10px;
        }
        .auto-style25 {
            width: 342px;
            border-radius: 5px;
            font-size: 17px;
            height: 53px;
            border: 1px solid #ccc;
            margin-bottom: 10px;
            padding: 10px;
        }
        .auto-style26 {
            height: 53px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style22">
                <tr>
                    <td colspan="4" class="auto-style14">
                        <strong>
                        <asp:Label ID="LabelTitleStaff" runat="server" Text="Inventory Management For Staff" CssClass="auto-style16"></asp:Label>
                        </strong>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style23">
                        <asp:Label ID="LabelItemId" runat="server" Text="Item ID"></asp:Label>
                    </td>
                    <td class="auto-style24">
                        <asp:TextBox ID="TextBoxItemId" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td class="auto-style25"></td>
                    <td class="auto-style26"></td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="LabelName" runat="server" Text="Name"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:TextBox ID="TextBoxName" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="LabelQuantity" runat="server" Text="Quantity"></asp:Label>
                    </td>
                    <td class="auto-style6">
                        <asp:TextBox ID="TextBoxQuantity" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td class="auto-style8"></td>
                    <td class="auto-style2"></td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="LabelUnitPrice" runat="server" Text="Unit Price"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:TextBox ID="TextBoxUnitPrice" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="LabelMeasure" runat="server" Text="Unit Of Measure"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:TextBox ID="TextBoxMeasure" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="LabelTotalPrice" runat="server" Text="Total Price"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:TextBox ID="TextBoxTotalPrice" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style20" colspan="3"></td>
                    <td class="auto-style21"></td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="LabelConsume" runat="server" Text="Quantity Consumed"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:TextBox ID="TextBoxConsume" runat="server"  OnTextChanged="TextBoxConsume_TextChanged" AutoPostBack="True"></asp:TextBox>
                    </td>
                    <td class="auto-style7">
                        <asp:Button ID="ButtonConsume" runat="server" Text="Consume" OnClick="ButtonConsume_Click" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style18">&nbsp;</td>
                    <td class="auto-style18">&nbsp;</td>
                    <td class="auto-style18">
                        <asp:Button ID="ButtonExit" runat="server" Text="Exit" OnClick="ButtonExit_Click" Width="67px" />
                    </td>
                    <td class="auto-style19"></td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="LabelSearch" runat="server" Text="Search By"></asp:Label></td>
                    <td class="auto-style5">
                        <asp:DropDownList ID="DropDownListSearch" runat="server" AutoPostBack="True"></asp:DropDownList>
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="TextBoxSearch" runat="server" AutoPostBack="True" OnTextChanged="TextBoxSearch_TextChanged"></asp:TextBox>

                    </td>
                    <td>
                        <asp:ImageButton ID="ImageButtonSearch" Style="height: 18px" runat="server" ImageUrl="../img/magnifying-glass.jfif" OnClick="ImageButtonSearch_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9"></td>
                    <td class="auto-style10"></td>
                    <td class="auto-style11"></td>
                    <td class="auto-style12"></td>
                </tr>
                <tr>
                    <td class="auto-style13" colspan="3">
                        <strong>
                        <asp:Label ID="LabelResult" runat="server" Text="Result" CssClass="auto-style15"></asp:Label></strong></td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
        <asp:GridView ID="GridViewInventory" runat="server" AutoGenerateColumns="False" Width="1158px" EnableSelection="true" OnRowCommand="GridViewInventory_RowCommand">
            <Columns>
                <asp:BoundField DataField="ItemId" HeaderText="Item ID" ReadOnly="True" />
                <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" ReadOnly="True" />
                <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" ReadOnly="True" />
                <asp:BoundField DataField="UnitOfMeasure" HeaderText="Unit of Measure" ReadOnly="True" />
                <asp:ButtonField ButtonType="Button" Text="Select" CommandName="Select" />
                <asp:ButtonField ButtonType="Button" CommandName="Show" Text="Show History" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:GridView ID="GridViewInventoryHistory" runat="server" Width="881px">
        </asp:GridView>
    </form>
</body>
</html>
