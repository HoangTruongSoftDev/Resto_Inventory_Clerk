using RestoClerkInventory.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using RestoClerkInventory.SERVICE;
using RestoClerkInventory.Validation;



namespace RestoClerkInventory.GUI
{
    public partial class WebFormInventoryOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                DropDownListSearchBy.Items.Add("Item ID");
                DropDownListSearchBy.Items.Add("Item Name");
            }
            TextBoxTotalPrice.Enabled = false;
            TextBoxOrderDateTime.Enabled = false;


        }

        public bool AreAllValidFieldsForSave()
        {

            Order order = new Order();


            string input = "";
            input = TextBoxItemId.Text.Trim();

            // ID should be Numeric
            if (!ValidatorManager.IsValidNumeric(input))
            {
                MessageBox.Show("Id must be numeric!", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //TextBoxItemId.Text = string.Empty;
                TextBoxItemId.Focus();
                return false;
            }

            // ID should not be Duplicate
            input = TextBoxItemId.Text.Trim();
            if (order.getDuplicateItemId(Convert.ToInt32(input)))
            {
                MessageBox.Show("This Item Id already exist!", "Duplicate Id", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //TextBoxItemId.Text = string.Empty;
                TextBoxItemId.Focus();
                return false;
            }


            // Item Name should be not be Empty and should be String
            input = TextBoxItemName.Text.Trim();
            if (!ValidatorManager.IsValidName(input))
            {
                MessageBox.Show("Item name should only consist alphabets!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //TextBoxItemName.Text = string.Empty;
                TextBoxItemName.Focus();
                return false;
            }


            // Quantity should be Numeric
            input = TextBoxQuantity.Text.Trim();
            if (!ValidatorManager.IsValidNumeric(input))
            {
                MessageBox.Show("Quantity should be numeric!", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //TextBoxQuantity.Text = string.Empty;
                TextBoxQuantity.Focus();
                return false;
            }

            // Unit Price should be Numeric
            input = TextBoxUnitPrice.Text.Trim();
            if (!ValidatorManager.IsValidNumeric(input))
            {
                MessageBox.Show("Unit Price should be numeric!", "Invalid Unit Price", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //TextBoxUnitPrice.Text = string.Empty;
                TextBoxUnitPrice.Focus();
                return false;
            }

            // Unit of Measure should not be empty and should be String
            input = TextBoxUnitOfMeasure.Text.Trim();
            if (!ValidatorManager.IsValidName(input))
            {
                MessageBox.Show("Unit of measure should only consist alphabets!", "Invalid Unit Measure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //TextBoxUnitOfMeasure.Text = string.Empty;
                TextBoxUnitOfMeasure.Focus();
                return false;
            }

            return true;

        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            TextBoxOrderDateTime.Enabled = false;

            Order order = new Order();

            if (!AreAllValidFieldsForSave())
            {
                return;
            }

            order.ItemID = Convert.ToInt32(TextBoxItemId.Text.Trim());
            order.Name = TextBoxItemName.Text.Trim();
            order.Quantity = Convert.ToInt32(TextBoxQuantity.Text.Trim());
            order.UnitPrice = Convert.ToDecimal(TextBoxUnitPrice.Text.Trim());
            order.UnitOfMeasure = TextBoxUnitOfMeasure.Text.Trim();

            order.OrderDateTime = DateTime.Now;



            order.SaveOrder(order);
            Service.ClearAllTextBoxes(this);
            MessageBox.Show("Order for " + order.Name + " has been saved successfully!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        protected void ButtonClear_Click(object sender, EventArgs e)
        {
            Service.ClearAllTextBoxes(this);
            GridViewOrderedItems.DataSource = null;
            GridViewOrderedItems.DataBind();
            TextBoxItemId.ReadOnly = false;
            ButtonDelete.Enabled = false;
            ButtonUpdate.Enabled = false;

        }

        protected void ButtonListAllOrderedItem_Click(object sender, EventArgs e)
        {
            Order odr = new Order();
            GridViewOrderedItems.DataSource = odr.GetAllItemRecords();
            GridViewOrderedItems.DataBind();

            //TextBoxQuantityConsumedManager.Text = "";
        }

        protected void GridViewItermOrdered_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                GridViewRow selectedRow = GridViewOrderedItems.Rows[rowIndex];

                TextBoxItemId.Text = selectedRow.Cells[0].Text;
                TextBoxItemName.Text = selectedRow.Cells[1].Text;
                TextBoxQuantity.Text = selectedRow.Cells[2].Text;
                TextBoxUnitPrice.Text = selectedRow.Cells[3].Text;
                TextBoxUnitOfMeasure.Text = selectedRow.Cells[4].Text;
                TextBoxOrderDateTime.Text = selectedRow.Cells[5].Text;

                int quantity = int.Parse(selectedRow.Cells[2].Text);
                decimal unitPrice = decimal.Parse(selectedRow.Cells[3].Text);
                decimal totalPrice = quantity * unitPrice;
                TextBoxTotalPrice.Text = totalPrice.ToString();

                GridViewOrderedItems.DataSource = null;
                GridViewOrderedItems.DataBind();

                TextBoxItemId.ReadOnly = true;
                TextBoxTotalPrice.ReadOnly = true;
                ButtonUpdate.Enabled = true;
                ButtonDelete.Enabled = true;
            }
        }



        protected void ButtonExitManager_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit?",
              "Confirm",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                Response.Redirect("WebFormLogin.aspx");
        }

        public bool IsValidSeach()
        {
            TextBoxSearchBy.Enabled = true;
            string input = "";
            input = TextBoxSearchBy.Text.Trim();
            if (TextBoxSearchBy.Text == "")
            {
                MessageBox.Show("Search Value should not be empty!", "Invalid Search", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextBoxSearchBy.Text = string.Empty;
                TextBoxSearchBy.Focus();
                return false;
            }
            return true;
        }
        protected void ImageButtonSearch_Click(object sender, ImageClickEventArgs e)
        {
            GridViewOrderedItems.DataSource = null;
            GridViewOrderedItems.DataBind();


            if (!IsValidSeach())
            {
                return;
            }

            List<Order> orderList = new List<Order>();

            if (DropDownListSearchBy.SelectedItem.Text == "Item ID")
            {
                Order order = new Order();
                int itemID = Convert.ToInt32(TextBoxSearchBy.Text);
                orderList = order.GetInventoryByItemID(itemID);

                if (orderList.Count > 0)
                {
                    GridViewOrderedItems.DataSource = orderList;
                    GridViewOrderedItems.DataBind();
                }
                else
                {
                    MessageBox.Show("Item not found!", "No Item", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (DropDownListSearchBy.SelectedItem.Text == "Item Name")
            {
                Order order = new Order();
                string itemName = TextBoxSearchBy.Text;
                orderList = order.GetInventoryByItemName(itemName);

                if (orderList.Count > 0)
                {
                    GridViewOrderedItems.DataSource = orderList;
                    GridViewOrderedItems.DataBind();
                }
                else
                {
                    MessageBox.Show("Item not found!", "No Item", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



                TextBoxSearchBy.Text = "";

            }
        }

        public bool AreAllValidFieldsForUpdate()
        {

            Order order = new Order();


            string input = "";
            input = TextBoxItemId.Text.Trim();

            // ID should be Numeric
            if (!ValidatorManager.IsValidNumeric(input))
            {
                MessageBox.Show("Id must be numeric!", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //TextBoxItemId.Text = string.Empty;
                TextBoxItemId.Focus();
                return false;
            }

            // Item Name should be not be Empty and should be String
            input = TextBoxItemName.Text.Trim();
            if (!ValidatorManager.IsValidName(input))
            {
                MessageBox.Show("Item Name should only consist alphabets!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //TextBoxItemName.Text = string.Empty;
                TextBoxItemName.Focus();
                return false;
            }


            // Quantity should be Numeric
            input = TextBoxQuantity.Text.Trim();
            if (!ValidatorManager.IsValidNumeric(input))
            {
                MessageBox.Show("Quantity should be numeric!", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //TextBoxQuantity.Text = string.Empty;
                TextBoxQuantity.Focus();
                return false;
            }

            // Unit Price should be Numeric
            input = TextBoxUnitPrice.Text.Trim();
            if (!ValidatorManager.IsValidNumeric(input))
            {
                MessageBox.Show("Unit Price should be numeric!", "Invalid Unit Price", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //TextBoxUnitPrice.Text = string.Empty;
                TextBoxUnitPrice.Focus();
                return false;
            }

            // Unit of Measure should not be empty and should be String
            input = TextBoxUnitOfMeasure.Text.Trim();
            if (!ValidatorManager.IsValidName(input))
            {
                MessageBox.Show("Unit of measure should only consist alphabets!", "Invalid Unit Measure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //TextBoxUnitOfMeasure.Text = string.Empty;
                TextBoxUnitOfMeasure.Focus();
                return false;
            }

            return true;

        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            TextBoxItemId.Enabled = false;

            Order order = new Order();

            if (!AreAllValidFieldsForUpdate())
            {
                return;
            }


            order.ItemID = Convert.ToInt32(TextBoxItemId.Text.Trim());
            order.Name = TextBoxItemName.Text.Trim();
            order.Quantity = Convert.ToInt32(TextBoxQuantity.Text.Trim());
            order.UnitPrice = Convert.ToDecimal(TextBoxUnitPrice.Text.Trim());
            order.UnitOfMeasure = TextBoxUnitOfMeasure.Text.Trim();


            order.UpdateOrderItem(order);

            Service.ClearAllTextBoxes(this);
            MessageBox.Show("Order has been updated successfully!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            order.ItemID = Convert.ToInt32(TextBoxItemId.Text.Trim());
            order.DeleteOrder(order);
            Service.ClearAllTextBoxes(this);
            MessageBox.Show("Order for "+order.Name+" has been deleted successfully!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}