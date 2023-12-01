<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormAdvancedManagement.aspx.cs" Inherits="RestoClerkInventory.GUI.WebFormAdvancedManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f5f5f5;
        }

        .container {
            width: 80%;
            margin: 20px auto;
        }

        .header {
            text-align: center;
            font-size: x-large;
            background-color: #FFFFFF;
            padding: 10px;
            border-bottom: 1px solid #ccc;
        }

        .form-section {
            margin-top: 20px;
            background-color: #fff;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        .toggle-label {
            font-weight: bold;
        }

        #settingsPanel {
            display: none;
            margin-top: 10px;
        }

        .input-group {
            margin-bottom: 10px;
        }

        .input-group label {
            display: block;
            margin-bottom: 5px;
        }

        .input-group input[type="number"],
        .input-group input[type="text"] {
            width: 100%;
            padding: 8px;
            box-sizing: border-box;
            border: 1px solid #ccc;
            border-radius: 4px;
        }

        .commit-button {
            padding: 10px;
            background-color: #4CAF50;
            color: #fff;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }

        .commit-button:hover {
            background-color: #45a049;
        }

        .auto-style6 {
            height: 24px;
        }
    </style>
    <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#toggleSettings').change(function () {
                if ($(this).is(':checked')) {
                    $('#settingsPanel').show();
                } else {
                    $('#settingsPanel').hide();
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="header">
                <strong>Advanced management</strong>
            </div>
            <div class="form-section">
                <div class="input-group">
                    <asp:CheckBox ID="toggleSettings" runat="server" Text="Vacation Mode" CssClass="toggle-label" OnCheckedChanged="toggleSettings_CheckedChanged" />
                </div>
                <div id="settingsPanel">
                    <div class="input-group">
                        <label for="TextBoxThresholdForOrder">Set threshold for automatically placing an order:</label>
                        <asp:TextBox ID="TextBoxThresholdForOrder" runat="server"></asp:TextBox>
               
                    </div>
                    <button type="button" class="commit-button" onclick="commitSettings()">Commit</button>
                </div>
            </div>
            <div class="auto-style6"></div>
            <div class="form-section">
                <div class="input-group">
                    <label for="TextBoxThresholdForAlarm">Set threshold for Alarm:</label>
                    <asp:TextBox ID="TextBoxThresholdForAlarm" runat="server"></asp:TextBox>
                </div>
                <asp:Button ID="ButtonThresholdAlarm" runat="server" Text="Commit" CssClass="commit-button" OnClick="ButtonThresholdAlarm_Click" />
            </div>
        </div>
    </form>
</body>
</html>