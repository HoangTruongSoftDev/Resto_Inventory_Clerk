<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormInventoryByManager.aspx.cs" Inherits="RestoClerkInventory.GUI.WebFormInventoryByManager" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="css/StyleManager.css" />
    <style type="text/css">
        .auto-style5 {
            width: 251px;
        }
        .auto-style20 {
            text-align: center;
        }
        .auto-style21 {
            text-align: center;
            width: 873px;
        }
        .auto-style22 {
            width: 873px;
        }
        .auto-style24 {
            width: 289px;
            text-decoration: underline;
            text-align: center;
        }
        .auto-style28 {
            width: 251px;
            height: 24px;
        }
        .auto-style30 {
            text-align: center;
            height: 24px;
            width: 227px;
        }
        .auto-style33 {
            width: 458px;
        }
        .auto-style37 {
            width: 227px;
            text-align: center;
        }
        .auto-style38 {
            width: 458px;
            text-align: center;
        }
        .auto-style39 {
            text-align: center;
            height: 24px;
            width: 458px;
        }
        .auto-style40 {
            width: 289px;
            text-align: center;
        }
        .auto-style41 {
            width: 100%;
        }
        .auto-style42 {
            width: 581px;
        }
        .auto-style43 {
            border: 1px solid #000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table cellpadding="2" style="border: 1px solid #000;">
            <tr>
                <td colspan="3" class="auto-style4">
                    <strong>MANAGER WINDOW</strong></td>
            </tr>
            <tr>
                <td class="auto-style37">
                    <asp:Label ID="LabelEmployeeId" runat="server" Text="Item ID"></asp:Label></td>
                <td class="auto-style38">
                    <asp:TextBox ID="TextBoxItemIdManager" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style5">
                    <asp:Button ID="ButtonSaveManager" runat="server" Text="Save" OnClick="ButtonSave_Click" CssClass="button-style" /></td>
            </tr>
            <tr>
                <td class="auto-style37">
                    <asp:Label ID="LabelEmployeeId0" runat="server" Text="Item Name"></asp:Label></td>
                <td class="auto-style38">
                    <asp:TextBox ID="TextBoxItemNameManager" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style5">
                    <asp:Button ID="ButtonClearManager" runat="server" Text="Clear" OnClick="ButtonClear_Click" CssClass="button-style" />
                </td>
            </tr>
            <tr>
                <td class="auto-style37">
                    <asp:Label ID="LabelFirstName" runat="server" Text="Quantity"></asp:Label></td>
                <td class="auto-style38">
                    <asp:TextBox ID="TextBoxQuantityManager" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style5">
                    <asp:Button ID="ButtonUpdateManager" runat="server" Text="Update" OnClick="ButtonUpdate_Click" Enabled="False" CssClass="button-style" /></td>
            </tr>
            <tr>
                <td class="auto-style37">
                    <asp:Label ID="LabelFirstName0" runat="server" Text="Unit Price"></asp:Label></td>
                <td class="auto-style38">
                    <asp:TextBox ID="TextBoxUnitPriceManager" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style5">
                    <asp:Button ID="ButtonDeleteManager" runat="server" Text="Delete" OnClick="ButtonDelete_Click" Enabled="False" CssClass="button-style" />
                </td>
            </tr>
            <tr>
                <td class="auto-style37">
                    <asp:Label ID="LabelLastName" runat="server" Text="Unit Of Measure"></asp:Label></td>
                <td class="auto-style38">
                    <asp:TextBox ID="TextBoxUnitOfMeasureManager" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style5">
                    <asp:Button ID="ButtonListAllItemsManager" runat="server" Text="List All Items" OnClick="ButtonListAll_Click" CssClass="button-style"/>
                </td>
            </tr>
            <tr>
                <td class="auto-style37">
                    <asp:Label ID="LabelEmail" runat="server" Text="Total Price"></asp:Label></td>
                <td class="auto-style38">
                    <asp:TextBox ID="TextBoxTotalPriceManager" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style5">&nbsp;</td>
            </tr>

            <tr>
                <td class="auto-style30">
                    <asp:Label ID="LabelEmail0" runat="server" Text="Quantity Consumed"></asp:Label></td>
                <td class="auto-style39">
                    <asp:TextBox ID="TextBoxQuantityConsumedManager" runat="server" OnTextChanged="TextBoxQuantityConsumedManager_TextChanged"></asp:TextBox>
                </td>
                <td class="auto-style28">
                    <asp:Button ID="ButtonConsumedManager" runat="server" Height="26px" OnClick="ButtonConsumedManager_Click" Text="Consume" CssClass="button-style" />
                </td>
            </tr>

            <tr>
                <td class="auto-style37">&nbsp;</td>
                <td class="auto-style33">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
            </tr>

        </table>
        <br />
        <table class="auto-style16" style="border: 1px solid #000;">

            <tr>
                <td class="auto-style40">
                    <asp:Label ID="LabelSearch" runat="server" Text="Search By"></asp:Label></td>
                <td class="auto-style21">
                    <asp:DropDownList ID="DropDownListSearchByManager" runat="server" AutoPostBack="True" CssClass="dropdown-style"></asp:DropDownList>
                </td>
                <td class="auto-style5">
                    <asp:TextBox ID="TextBoxSearchByManager" runat="server" OnTextChanged="TextBoxSearchByManager_TextChanged"></asp:TextBox>

                </td>
                <td>
                    <asp:ImageButton ID="ImageButtonSearch" Style="height: 18px" runat="server" ImageUrl="../img/magnifying-glass.jfif" OnClick="ImageButtonSearch_Click" />
                </td>
            </tr>

            <tr>
                <td class="auto-style24"><strong>Import from here</strong></td>
                <td class="auto-style22">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style40">
                    <asp:FileUpload ID="FileUploadControl" runat="server" />
                </td>
                <td class="auto-style21">
                    <asp:Button ID="UploadButton" runat="server" OnClick="UploadButton_Click" Text="Upload File"  CssClass="button-style"/>
                </td>
            </tr>
        </table>
        <br />
        <div class="auto-style3">
            <span class="auto-style20">LIST OF ITEMS</span>
        </div>
        <p>
            &nbsp;
        </p>

        <asp:GridView ID="GridViewInventoryByManager" runat="server" AutoGenerateColumns="False" Width="1235px" OnRowCommand="GridViewInventory_RowCommand">
            <Columns>
                <asp:BoundField DataField="ItemId" HeaderText="Item ID" ReadOnly="True" />
                <asp:BoundField DataField="Name" HeaderText="Item Name" ReadOnly="True" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" ReadOnly="True" />
                <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" ReadOnly="True" />
                <asp:BoundField DataField="UnitOfMeasure" HeaderText="Unit of Measure" ReadOnly="True" />
                <asp:ButtonField ButtonType="Button" Text="Select" CommandName="Select" />
                <asp:ButtonField ButtonType="Button" CommandName="Show" Text="Show History" />
            </Columns>
        </asp:GridView>
        <p>
            &nbsp;
            <asp:GridView ID="GridViewInventoryHistory" runat="server" Width="1016px">
            </asp:GridView>
        </p>
        <p>
            <table class="auto-style41">
                <tr>
                    <td class="auto-style42">
            <asp:Button ID="ButtonExitManager" runat="server" Height="27px" OnClick="ButtonExitManager_Click" Text="Log Out" CssClass="button-style" />
                    </td>
                    <td class="auto-style42">
            <asp:Button ID="btnPlaceOrder" runat="server" Height="27px" Text="Place Order" CssClass="button-style" OnClick="btnPlaceOrder_Click" />
                    </td>
                    <td>
            <asp:Button ID="ButtonAdvancedManagement" runat="server" Height="33px" OnClick="ButtonAdvancedManagement_Click" Text="Advanced Management" CssClass="auto-style43" BackColor="#66FF66" Font-Bold="True" Font-Size="Medium" ForeColor="Black" Width="255px" />
                    </td>
                </tr>
            </table>
        </p>
        <p>
            &nbsp;
        </p>
    </form>
    <p>
        &nbsp;
    </p>
</body>
</html>
