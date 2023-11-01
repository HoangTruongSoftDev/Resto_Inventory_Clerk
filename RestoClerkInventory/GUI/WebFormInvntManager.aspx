<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormInvntManager.aspx.cs" Inherits="RestoClerkInventory.GUI.WebFormInvntManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">


#LabelTitle {
    font-size: 24px;
    font-weight: bold;
    margin-bottom: 20px;
    text-align: center;
}

table {
    width: 100%;
    border-collapse: collapse;
}

    table td {
        padding: 10px;
    }

input[type="text"], input[type="password"] {
    width: 100%;
    padding: 10px;
    margin-bottom: 10px;
    border: 1px solid #ccc;
    border-radius: 5px;
    font-size: 16px;
}

#LabelUserId,
#LabelPassword,
#LabelPosition {
    font-weight: bold;
}

#DropDownListPosition {
    width: 100%;
    padding: 10px;
    border: 1px solid #ccc;
    border-radius: 3px;
    font-size: 16px;
}

#TextBoxUserId,
#TextBoxPassword {
    width: 100%;
    padding: 10px;
    margin-bottom: 10px;
    border: 1px solid #ccc;
    border-radius: 3px;
    font-size: 16px;
}

#LabelResult {
    font-weight: bold;
    margin-top: 20px;
    display: block;
}



#GridViewEmployee {
    width: 100%;
    border-collapse: collapse;
    margin-top: 20px;
}

    #GridViewEmployee th {
        padding: 10px;
        background-color: #f2f2f2;
        border-bottom: 1px solid #ccc;
        text-align: left;
    }

    #GridViewEmployee td {
        padding: 10px;
        border-bottom: 1px solid #ccc;
    }

        .auto-style1 {
            height: 55px;
        }
        .auto-style2 {
            text-align: center;
        }
        .auto-style3 {
            margin-bottom: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table cellpadding="2">
                <tr>
                    <td colspan="3">
            <asp:Label ID="LabelTitle" runat="server" Text="MANAGER"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LabelEmployeeId" runat="server" Text="Item ID"></asp:Label></td>
                    <td>
                        <asp:TextBox placeholder="6-digit number" ID="TextBoxEmployeeId" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:Button ID="ButtonSave" runat="server" Text="Save" OnClick="ButtonSave_Click" Width="181px" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LabelEmployeeId0" runat="server" Text="Item Name"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TextBoxLastName0" runat="server" placeholder="ex. Pham"></asp:TextBox></td>
                    <td>
                        <asp:Button ID="ButtonClear" runat="server" Text="Clear" OnClick="ButtonClear_Click" Width="186px" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LabelFirstName" runat="server" Text="Quantity"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TextBoxFirstName" runat="server" placeholder="ex. Truong"></asp:TextBox></td>
                    <td>
                        <asp:Button ID="ButtonUpdate" runat="server" Text="Update" OnClick="ButtonUpdate_Click" Enabled="False" Width="189px" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LabelLastName" runat="server" Text="Unit Of Measure" ></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TextBoxLastName" runat="server" placeholder="ex. Pham"></asp:TextBox></td>
                    <td>
                        <asp:Button ID="ButtonDelete" runat="server" Text="Delete" OnClick="ButtonDelete_Click" Enabled="False" Width="193px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="LabelEmail" runat="server" Text="Total Price"></asp:Label></td>
                    <td class="auto-style1">
                        <asp:Label ID="LabelPrice" runat="server" Text="Price In $"></asp:Label></td>
                    <td class="auto-style1">
                        <asp:Button ID="ButtonHistoryTransaction" runat="server" Text="History Transaction" OnClick="ButtonListAll_Click" Width="196px" />
                    </td>
                </tr>

                <tr>
                    <td class="auto-style1">
                        &nbsp;</td>
                    <td class="auto-style1">
                        &nbsp;</td>
                    <td class="auto-style1">
                        <asp:Button ID="ButtonWarnings" runat="server" Text="Warnings!" OnClick="ButtonListAll_Click" CssClass="auto-style3" Width="198px" />
                    </td>
                </tr>

                <tr>
                    <td class="auto-style1">
                        &nbsp;</td>
                    <td class="auto-style1">
                        &nbsp;</td>
                    <td class="auto-style1">
                        <asp:Button ID="ButtonVacationMode" runat="server" Text="Vacation Mode" OnClick="ButtonListAll_Click" CssClass="auto-style3" />
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="LabelEmail0" runat="server" Text="Payment Method"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="DropDownListSearch0" runat="server" OnSelectedIndexChanged="DropDownListSearch_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="LabelEmail1" runat="server" Text="Delivery Address"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="TextBoxLastName1" runat="server" placeholder="ex. Pham"></asp:TextBox></td>
                    <td>
                        &nbsp;</td>
                </tr>

                <tr>
                    <td>
                        &nbsp;</td>
                    <td class="auto-style2">
                        <asp:Button ID="ButtonPlaceOrder" runat="server" Text="Place Order" OnClick="ButtonListAll_Click" CssClass="auto-style3" Height="38px" Width="172px" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <br />
                        <br />
                        <asp:Label ID="LabelMessage" runat="server" Text="Enter the Employee ID"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LabelSearch" runat="server" Text="Search By"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="DropDownListSearch" runat="server" OnSelectedIndexChanged="DropDownListSearch_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxSearch" runat="server" placeholder="6-digit number"></asp:TextBox>

                    </td>
                    <td>
                        <asp:ImageButton ID="ImageButtonSearch" Style="width: 18px; height: 18px" runat="server" ImageUrl="../img/magnifying-glass.jfif" OnClick="ImageButtonSearch_Click" />
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <div class="auto-style2">
            <asp:Label ID="LabelResult" runat="server" Text="Result"></asp:Label>
            
        <asp:GridView ID="GridViewInventory" runat="server" AutoGenerateColumns="False" Width="1235px" OnSelectedIndexChanged="GridViewInventory_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="ItemId" HeaderText="Item ID" ReadOnly="True" />
                <asp:BoundField DataField="Name" HeaderText="Item Name" ReadOnly="True" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" ReadOnly="True" />
                <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" ReadOnly="True" />
                <asp:BoundField DataField="UnitOfMeasure" HeaderText="Unit of Measure" ReadOnly="True" />
                <asp:ButtonField ButtonType="Button" Text="Select" CommandName="Select" />
            </Columns>
        </asp:GridView>
            </div>
            
            
        </div>
    </form>
</body>
</html>
