<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormInventoryByManager.aspx.cs" Inherits="RestoClerkInventory.GUI.WebFormInventoryByManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        table {
            width: 100%;
            border-collapse: collapse;
        }

        .auto-style4 {
            text-align: center;
            font-size: x-large;
            color: #6600FF;
        }

        table td {
            padding: 10px;
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
            height: 55px;
            width: 665px;
        }

        .auto-style3 {
            text-align: center;
            font-weight: bold;
            font-size: medium;
            width: 1230px;
        }

        .auto-style8 {
            height: 55px;
            width: 400px;
            text-align: left;
        }

        .auto-style9 {
            width: 314px;
        }

        .auto-style10 {
            height: 55px;
            width: 314px;
        }

        .auto-style11 {
            text-align: center;
            width: 665px;
        }

        .auto-style12 {
            width: 314px;
            height: 70px;
        }

        .auto-style13 {
            height: 70px;
            width: 665px;
        }

        .auto-style14 {
            width: 400px;
            height: 70px;
            text-align: left;
        }

        .auto-style15 {
            width: 665px;
        }

        .auto-style16 {
            width: 100%;
        }

        .auto-style17 {
            width: 386px;
        }

        .auto-style18 {
            width: 386px;
            text-decoration: underline;
        }

        .auto-style19 {
            width: 400px;
            text-align: left;
        }


        body {
            background-color: lightgray;
            font-family: Arial, sans-serif;
        }

        .auto-style4 {
            text-align: center;
            font-size: x-large;
            color: #000; /* Dark black color */
            background-color: lightgray;
        }

        .auto-style3 {
            text-align: center;
            font-weight: bold;
            font-size: medium;
            width: 1230px;
        }

        .auto-style18 {
            width: 386px;
            text-decoration: underline;
        }

        /* You can add more styles as needed for other elements in your HTML */
    </style>
    </head>
    <body>
    <form id="form1" runat="server">
        <table cellpadding="2">
            <tr>
                <td colspan="3" class="auto-style4">
                    <strong>MANAGER WINDOW</strong></td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <asp:Label ID="LabelEmployeeId" runat="server" Text="Item ID"></asp:Label></td>
                <td class="auto-style15">
                    <asp:TextBox ID="TextBoxItemIdManager" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style19">
                    <asp:Button ID="ButtonSaveManager" runat="server" Text="Save" OnClick="ButtonSave_Click" Width="181px" /></td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <asp:Label ID="LabelEmployeeId0" runat="server" Text="Item Name"></asp:Label></td>
                <td class="auto-style15">
                    <asp:TextBox ID="TextBoxItemNameManager" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style19">
                    <asp:Button ID="ButtonClearManager" runat="server" Text="Clear" OnClick="ButtonClear_Click" Width="186px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <asp:Label ID="LabelFirstName" runat="server" Text="Quantity"></asp:Label></td>
                <td class="auto-style15">
                    <asp:TextBox ID="TextBoxQuantityManager" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style19">
                    <asp:Button ID="ButtonUpdateManager" runat="server" Text="Update" OnClick="ButtonUpdate_Click" Enabled="False" Width="189px" /></td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <asp:Label ID="LabelFirstName0" runat="server" Text="Unit Price"></asp:Label></td>
                <td class="auto-style15">
                    <asp:TextBox ID="TextBoxUnitPriceManager" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style19">
                    <asp:Button ID="ButtonDeleteManager" runat="server" Text="Delete" OnClick="ButtonDelete_Click" Enabled="False" Width="193px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style12">
                    <asp:Label ID="LabelLastName" runat="server" Text="Unit Of Measure"></asp:Label></td>
                <td class="auto-style13">
                    <asp:TextBox ID="TextBoxUnitOfMeasureManager" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style14">
                    <asp:Button ID="ButtonListAllItemsManager" runat="server" Text="List All Items" OnClick="ButtonListAll_Click" Width="196px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style10">
                    <asp:Label ID="LabelEmail" runat="server" Text="Total Price"></asp:Label></td>
                <td class="auto-style1">
                    <asp:TextBox ID="TextBoxTotalPriceManager" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style8">&nbsp;</td>
            </tr>

            <tr>
                <td class="auto-style10">
                    <asp:Label ID="LabelEmail0" runat="server" Text="Quantity Consumed"></asp:Label></td>
                <td class="auto-style1">
                    <asp:TextBox ID="TextBoxQuantityConsumedManager" runat="server" OnTextChanged="TextBoxQuantityConsumedManager_TextChanged"></asp:TextBox>
                </td>
                <td class="auto-style8">
                    <asp:Button ID="ButtonConsumedManager" runat="server" Height="26px" OnClick="ButtonConsumedManager_Click" Text="Consume" Width="196px" />
                </td>
            </tr>

            <tr>
                <td class="auto-style10">&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style8">
                    &nbsp;</td>
            </tr>

            <tr>
                <td class="auto-style9">
                    <asp:Label ID="LabelSearch" runat="server" Text="Search By"></asp:Label></td>
                <td class="auto-style11">
                    <asp:DropDownList ID="DropDownListSearchByManager" runat="server" AutoPostBack="True"></asp:DropDownList>
                </td>
                <td class="auto-style19">
                    <asp:TextBox ID="TextBoxSearchByManager" runat="server" OnTextChanged="TextBoxSearchByManager_TextChanged" Width="175px"></asp:TextBox>

                </td>
                <td>
                    <asp:ImageButton ID="ImageButtonSearch" Style="height: 18px" runat="server" ImageUrl="../img/magnifying-glass.jfif" OnClick="ImageButtonSearch_Click" />
                </td>
            </tr>
        </table>
        <table class="auto-style16">
            <tr>
                <td class="auto-style18"><strong>Import from here</strong></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style17">
                    <asp:FileUpload ID="FileUploadControl" runat="server" />
                </td>
                <td>
                    <asp:Button ID="UploadButton" runat="server" OnClick="UploadButton_Click" Text="Upload File" />
                </td>
            </tr>
        </table>
        <br />
        <div class="auto-style3">
            RESULTS
        </div>
        <p>
            &nbsp;
        </p>

        <asp:GridView ID="GridViewInventoryByManager" runat="server" AutoGenerateColumns="False" Width="1235px" OnSelectedIndexChanged="GridViewInventory_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="ItemId" HeaderText="Item ID" ReadOnly="True" />
                <asp:BoundField DataField="Name" HeaderText="Item Name" ReadOnly="True" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" ReadOnly="True" />
                <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" ReadOnly="True" />
                <asp:BoundField DataField="UnitOfMeasure" HeaderText="Unit of Measure" ReadOnly="True" />
                <asp:ButtonField ButtonType="Button" Text="Select" CommandName="Select" />
            </Columns>
        </asp:GridView>
        <p>
            &nbsp;</p>
        <p>
                    <asp:Button ID="ButtonExitManager" runat="server" Height="27px" OnClick="ButtonExitManager_Click" Text="Log Out" Width="195px" />
                </p>
        <p>
            &nbsp;</p>
    </form>
        <p>
            &nbsp;</p>
</body>
</html>
