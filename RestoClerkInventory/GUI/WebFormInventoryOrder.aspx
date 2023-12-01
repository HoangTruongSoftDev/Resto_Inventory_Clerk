<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormInventoryOrder.aspx.cs" Inherits="RestoClerkInventory.GUI.WebFormInventoryOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">


table {
    width: 100%;
    border-collapse: collapse;
}

    table td {
        padding: 10px;
    }


#LabelTitle {
    font-size: 24px;
    font-weight: bold;
    margin-bottom: 20px;
    text-align: center;
}

input[type=text] {
    width: 100%;
    padding: 10px;
    margin-bottom: 10px;
    border: 1px solid #ccc;
    border-radius: 5px;
    font-size: 16px;
}

        .auto-style1 {
            text-align: center;
            font-size: xx-large;
        }
        .auto-style37 {
            width: 227px;
            text-align: center;
        }
        .auto-style38 {
            width: 458px;
            text-align: center;
        }
        .auto-style30 {
            text-align: center;
            height: 24px;
            width: 227px;
        }
        .auto-style39 {
            text-align: center;
            height: 24px;
            width: 458px;
        }
        

.button-style {
    width: 200px;
    height: 30px;
    border: 1px solid #000;
}


        .auto-style3 {
    color: #000;
    font-family: arial;
    text-align: center;
    font-weight: bold;
    font-size: x-large;
    width: 1230px;
    background-color: lightgray;
    text-decoration: underline;
    padding: 5px;
}

        .auto-style20 {
            text-align: center;
        }
        

        .auto-style40 {
            width: 289px;
            text-align: center;
        }
        .auto-style21 {
            text-align: center;
            width: 873px;
        }
        

.dropdown-style {
    width: 200px;
    padding: 5px;
    font-size: 16px;
    border: 1px solid #000;
    background-color: lightgray;
}
        .auto-style5 {
            width: 251px;
        }
                

        .auto-style41 {
            width: 227px;
            text-align: center;
            height: 70px;
        }
        .auto-style42 {
            width: 458px;
            text-align: center;
            height: 70px;
        }
                

        </style>
</head>
<body>
    <form id="form1" runat="server">
        <p class="auto-style1">
                    <strong>ORDER WINDOW</strong></p>
        <table cellpadding="2" style="border: 1px solid #000;">
            <tr>
                <td class="auto-style37">
                    <asp:Label ID="LabelEmployeeId" runat="server" Text="Item ID"></asp:Label></td>
                <td class="auto-style38">
                    <asp:TextBox ID="TextBoxItemId" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style38">
                    <asp:Button ID="ButtonSave" runat="server" Text="Save"  CssClass="button-style" OnClick="ButtonSave_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style37">
                    <asp:Label ID="LabelEmployeeId0" runat="server" Text="Item Name"></asp:Label></td>
                <td class="auto-style38">
                    <asp:TextBox ID="TextBoxItemName" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style38">
                    <asp:Button ID="ButtonClear" runat="server" Text="Clear"  CssClass="button-style" OnClick="ButtonClear_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style37">
                    <asp:Label ID="LabelFirstName" runat="server" Text="Quantity"></asp:Label></td>
                <td class="auto-style38">
                    <asp:TextBox ID="TextBoxQuantity" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style38">
                    <asp:Button ID="ButtonUpdate" runat="server" Text="Update" Enabled="False" CssClass="button-style" OnClick="ButtonUpdate_Click" /></td>
            </tr>
            <tr>
                <td class="auto-style37">
                    <asp:Label ID="LabelFirstName0" runat="server" Text="Unit Price"></asp:Label></td>
                <td class="auto-style38">
                    <asp:TextBox ID="TextBoxUnitPrice" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style38">
                    <asp:Button ID="ButtonDelete" runat="server" Text="Delete"  Enabled="False" CssClass="button-style" OnClick="ButtonDelete_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style37">
                    <asp:Label ID="LabelLastName" runat="server" Text="Unit Of Measure"></asp:Label></td>
                <td class="auto-style38">
                    <asp:TextBox ID="TextBoxUnitOfMeasure" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style38">
                    <asp:Button ID="ButtonListAllOrderedItem" runat="server" Text="List All Items" CssClass="button-style" OnClick="ButtonListAllOrderedItem_Click"/>
                </td>
            </tr>
            <tr>
                <td class="auto-style37">
                    <asp:Label ID="LabelPrice" runat="server" Text="Total Price"></asp:Label></td>
                <td class="auto-style38">
                    <asp:TextBox ID="TextBoxTotalPrice" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style38">
                    &nbsp;</td>
            </tr>

            <tr>
                <td class="auto-style41">
                    <asp:Label ID="LabelPrice0" runat="server" Text="Order Date &amp; Time"></asp:Label></td>
                <td class="auto-style42">
                    <asp:TextBox ID="TextBoxOrderDateTime" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style42">
                    </td>
            </tr>

            <tr>
                <td class="auto-style30">
                    &nbsp;</td>
                <td class="auto-style39">
                    &nbsp;</td>
                <td class="auto-style39">
                    &nbsp;</td>
            </tr>

        </table>
        <br />
        <table class="auto-style16" style="border: 1px solid #000;">

            <tr>
                <td class="auto-style40">
                    <asp:Label ID="LabelSearch" runat="server" Text="Search By"></asp:Label></td>
                <td class="auto-style21">
                    <asp:DropDownList ID="DropDownListSearchBy" runat="server" AutoPostBack="True" CssClass="dropdown-style"></asp:DropDownList>
                </td>
                <td class="auto-style5">
                    <asp:TextBox ID="TextBoxSearchBy" runat="server" ></asp:TextBox>

                </td>
                <td>
                    <asp:ImageButton ID="ImageButtonSearch" Style="height: 18px" runat="server" ImageUrl="../img/magnifying-glass.jfif" OnClick="ImageButtonSearch_Click" />
                </td>
            </tr>

        </table>
        <br />
        <div class="auto-style3">
            <span class="auto-style20">LIST OF ORDERED ITEMS</span>
        </div>
        <p>
            &nbsp;
        </p>

        <asp:GridView ID="GridViewOrderedItems" runat="server" AutoGenerateColumns="False" Width="1235px" OnRowCommand="GridViewItermOrdered_RowCommand">
            <Columns>
                <asp:BoundField DataField="ItemId" HeaderText="Item ID" ReadOnly="True" />
                <asp:BoundField DataField="Name" HeaderText="Item Name" ReadOnly="True" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" ReadOnly="True" />
                <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" ReadOnly="True" />
                <asp:BoundField DataField="UnitOfMeasure" HeaderText="Unit of Measure" ReadOnly="True" />
                <asp:BoundField DataField="OrderDateTime" HeaderText="Order Date &amp; Time" SortExpression="Databound" />
                <asp:ButtonField ButtonType="Button" Text="Select" CommandName="Select" />
            </Columns>
        </asp:GridView>
        <p>
            &nbsp;</p>
        <p>
            <asp:Button ID="ButtonExit" runat="server" Height="27px" Text="Log Out" CssClass="button-style" OnClick="ButtonExitManager_Click" />
                    </p>
        </form>
</body>
</html>
