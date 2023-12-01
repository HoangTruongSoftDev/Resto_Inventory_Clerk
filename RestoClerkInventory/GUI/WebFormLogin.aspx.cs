using RestoClerkInventory.BLL;
using RestoClerkInventory.DAL;
using RestoClerkInventory.ENUM;
using RestoClerkInventory.SERVICE;
using RestoClerkInventory.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;


namespace RestoClerkInventory.GUI
{
    public partial class WebFormLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownListPosition.Items.Add(Position.Admin.ToString());
                DropDownListPosition.Items.Add(Position.Manager.ToString());
                DropDownListPosition.Items.Add(Position.Staff.ToString());
                TextBoxUserId.Attributes.Add("placeholder", "4-digit number");
            }
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (TextBoxUserId.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Missing User ID", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TextBoxUserId.Focus();
                Service.ClearAllTextBoxes(this);
                return;
            }
            if (!Validator.IsValidUserId(TextBoxUserId.Text.Trim(), DropDownListPosition.SelectedValue.Trim()))
            {
                MessageBox.Show("Invalid User ID", "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextBoxUserId.Focus();
                Service.ClearAllTextBoxes(this);
                return;
            }
            if (TextBoxPassword.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Missing Password", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TextBoxPassword.Focus();
                return;
            }

            User user = new User();
            List<User> listAllUsers = user.GetAllUsers();
            user = user.GetUserById(Convert.ToInt32(TextBoxUserId.Text.Trim()));

            if (!listAllUsers.Contains(user))
            {
                MessageBox.Show("This account is invalid", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (DropDownListPosition.SelectedItem.Text != user.Position.ToString())
            {
                MessageBox.Show("This account position is invalid", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (SecurityService.VerifyPassword(TextBoxPassword.Text, user.HashedPassword))
            {
                MessageBox.Show("Login Successfully", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (user.Position.ToString() == Position.Admin.ToString())
                    Response.Redirect("WebFormAdmin.aspx");
                if (user.Position.ToString() == Position.Manager.ToString())
                {
                    Session["Manager"] = UserDB.SelectById(Convert.ToInt32(TextBoxUserId.Text.ToString()));
                    Response.Redirect("WebFormInventoryByManager.aspx");
                }
                    
                if (user.Position.ToString() == Position.Staff.ToString())
                    Response.Redirect("WebFormInventoryStaff.aspx");
            }
            else
            {
                MessageBox.Show("Your Password is incorrect", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        protected void DropDownListPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxUserId.Attributes["placeholder"] = (DropDownListPosition.SelectedValue == Position.Admin.ToString()) ? "4-digit number" : "6-digit number";
        }

        protected void ButtonImage_Click(object sender, EventArgs e)
        {
            string imagePassword = (TextBoxPassword.Attributes["type"] == "password") ? "../img/hide-password.png" : "../img/show-password.png";
            string typePassword = (TextBoxPassword.Attributes["type"] == "password") ? "text" : "password";
            ImageButtonPassword.ImageUrl = imagePassword;
            TextBoxPassword.Attributes["type"] = typePassword;
        }
    }
}