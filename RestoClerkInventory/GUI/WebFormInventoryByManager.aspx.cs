using RestoClerkInventory.BLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Text.Json;
using RestoClerkInventory.SERVICE;
using RestoClerkInventory.DAL;
using System.Security.Policy;
using System.Xml.Linq;
using RestoClerkInventory.Validation;

namespace RestoClerkInventory.GUI
{
    public partial class WebFormInventoryByManager : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownListSearchByManager.Items.Add("Item ID");
                DropDownListSearchByManager.Items.Add("Item Name");
                Threshold threshold = new Threshold();
                threshold = threshold.GetThresholdByManagerId(((User)Session["Manager"]).UserId);
                if (threshold != null)
                {
                    if (threshold.ModeId == 1)
                    {

                        List<Inventory> inventories = InventoryDB.GetAllItems();
                        foreach (Inventory currentInventory in inventories)
                        {
                            if (currentInventory.Quantity < threshold.ThresholdNumber)
                            {
                                currentInventory.Quantity = threshold.ThresholdNumber + 20;
                                InventoryDB.UpdateRecord(currentInventory.ItemID, currentInventory.Quantity);
                            }
                        }
                    }
                    else
                    {
                        bool check = false;
                        string message = "Your items below threshold are: ";
                        List<Inventory> inventories = InventoryDB.GetAllItems();
                        foreach (Inventory currentInventory in inventories)
                        {
                            if (currentInventory.Quantity < threshold.ThresholdAlarm)
                            {
                                message += currentInventory.Name + " ";
                                check = true;
                            }
                        }
                        if (check)
                        {
                            var result = MessageBox.Show(message + "\nDo you want to place order item", "Warning!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                            if (result == DialogResult.Yes)
                            {
                                Response.Redirect("WebFormInventoryOrder.aspx");
                            }
                        }

                    }
                }
                
            }
            ButtonConsumedManager.Enabled = false;
            TextBoxQuantityConsumedManager.Enabled = false;
            TextBoxTotalPriceManager.Enabled = false;
        }

        public bool AreAllValidFieldsForSave()
        {

            Manager manager = new Manager();


            string input = "";
            input = TextBoxItemIdManager.Text.Trim();

            // ID should be Numeric
            if (!ValidatorManager.IsValidNumeric(input))
            {
                MessageBox.Show("Id must be numeric!", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //TextBoxItemIdManager.Text = string.Empty;
                TextBoxItemIdManager.Focus();
                return false;
            }

            // ID should not be Duplicate
            input = TextBoxItemIdManager.Text.Trim();
            if (manager.getDuplicateItemId(Convert.ToInt32(input)))
            {
                MessageBox.Show("This Item Id already exist!", "Duplicate Id", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //TextBoxItemIdManager.Text = string.Empty;
                TextBoxItemIdManager.Focus();
                return false;
            }


            // Item Name should be not be Empty and should be String
            input = TextBoxItemNameManager.Text.Trim();
            if (!ValidatorManager.IsValidName(input))
            {
                MessageBox.Show("Item name should only consist alphabets!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //TextBoxItemNameManager.Text = string.Empty;
                TextBoxItemNameManager.Focus();
                return false;
            }


            // Quantity should be Numeric
            input = TextBoxQuantityManager.Text.Trim();
            if (!ValidatorManager.IsValidNumeric(input))
            {
                MessageBox.Show("Quantity should be numeric!", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //TextBoxQuantityManager.Text = string.Empty;
                TextBoxQuantityManager.Focus();
                return false;
            }

            // Unit Price should be Numeric
            input = TextBoxUnitPriceManager.Text.Trim();
            if (!ValidatorManager.IsValidNumeric(input))
            {
                MessageBox.Show("Unit Price should be numeric!", "Invalid Unit Price", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //TextBoxUnitPriceManager.Text = string.Empty;
                TextBoxUnitPriceManager.Focus();
                return false;
            }

            // Unit of Measure should not be empty and should be String
            input = TextBoxUnitOfMeasureManager.Text.Trim();
            if (!ValidatorManager.IsValidName(input))
            {
                MessageBox.Show("Unit of measure should only consist alphabets!", "Invalid Unit Measure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //TextBoxUnitOfMeasureManager.Text = string.Empty;
                TextBoxUnitOfMeasureManager.Focus();
                return false;
            }

            return true;

        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            Manager manager = new Manager();

            if (!AreAllValidFieldsForSave())
            {
                return;
            }

            manager.ItemID = Convert.ToInt32(TextBoxItemIdManager.Text.Trim());
            manager.Name = TextBoxItemNameManager.Text.Trim();
            manager.Quantity = Convert.ToInt32(TextBoxQuantityManager.Text.Trim());
            manager.UnitPrice = Convert.ToDecimal(TextBoxUnitPriceManager.Text.Trim());
            manager.UnitOfMeasure = TextBoxUnitOfMeasureManager.Text.Trim();

            manager.SaveInventoryItem(manager);
            Service.ClearAllTextBoxes(this);
            MessageBox.Show("Item has been saved successfully!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected void ButtonClear_Click(object sender, EventArgs e)
        {

            Service.ClearAllTextBoxes(this);
            GridViewInventoryByManager.DataSource = null;
            GridViewInventoryByManager.DataBind();
            TextBoxItemIdManager.ReadOnly = false;
            ButtonDeleteManager.Enabled = false;
            ButtonUpdateManager.Enabled = false;

        }

        public bool AreAllValidFieldsForUpdate()
        {

            Manager manager = new Manager();


            string input = "";
            input = TextBoxItemIdManager.Text.Trim();

            // ID should be Numeric
            if (!ValidatorManager.IsValidNumeric(input))
            {
                MessageBox.Show("Id must be numeric!", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //TextBoxItemIdManager.Text = string.Empty;
                TextBoxItemIdManager.Focus();
                return false;
            }

            // Item Name should be not be Empty and should be String
            input = TextBoxItemNameManager.Text.Trim();
            if (!ValidatorManager.IsValidName(input))
            {
                MessageBox.Show("Item Name should only consist alphabets!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //TextBoxItemNameManager.Text = string.Empty;
                TextBoxItemNameManager.Focus();
                return false;
            }


            // Quantity should be Numeric
            input = TextBoxQuantityManager.Text.Trim();
            if (!ValidatorManager.IsValidNumeric(input))
            {
                MessageBox.Show("Quantity should be numeric!", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //TextBoxQuantityManager.Text = string.Empty;
                TextBoxQuantityManager.Focus();
                return false;
            }

            // Unit Price should be Numeric
            input = TextBoxUnitPriceManager.Text.Trim();
            if (!ValidatorManager.IsValidNumeric(input))
            {
                MessageBox.Show("Unit Price should be numeric!", "Invalid Unit Price", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //TextBoxUnitPriceManager.Text = string.Empty;
                TextBoxUnitPriceManager.Focus();
                return false;
            }

            // Unit of Measure should not be empty and should be String
            input = TextBoxUnitOfMeasureManager.Text.Trim();
            if (!ValidatorManager.IsValidName(input))
            {
                MessageBox.Show("Unit of measure should only consist alphabets!", "Invalid Unit Measure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //TextBoxUnitOfMeasureManager.Text = string.Empty;
                TextBoxUnitOfMeasureManager.Focus();
                return false;
            }

            return true;

        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            TextBoxItemIdManager.Enabled = false;

            Manager manager = new Manager();

            if (!AreAllValidFieldsForUpdate())
            {
                return;
            }


            manager.ItemID = Convert.ToInt32(TextBoxItemIdManager.Text.Trim());
            manager.Name = TextBoxItemNameManager.Text.Trim();
            manager.Quantity = Convert.ToInt32(TextBoxQuantityManager.Text.Trim());
            manager.UnitPrice = Convert.ToDecimal(TextBoxUnitPriceManager.Text.Trim());
            manager.UnitOfMeasure = TextBoxUnitOfMeasureManager.Text.Trim();

            int previousQuantity = InventoryDB.GetLastQuantity(manager.ItemID);

            manager.UpdateInventoryItem(manager);        

            InventoryHistory inventoryHistory = new InventoryHistory();
            inventoryHistory.ItemID = manager.ItemID;
            inventoryHistory.CurrentQuantity = manager.Quantity;
            inventoryHistory.PreviousQuantity = previousQuantity;
            inventoryHistory.DateTimestamp = DateTime.Now;
            inventoryHistory.AddInventoryHistoryItem(inventoryHistory);

            Service.ClearAllTextBoxes(this);
            MessageBox.Show("Item has been updated successfully!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            Manager manager = new Manager();
            manager.ItemID = Convert.ToInt32(TextBoxItemIdManager.Text.Trim());
            manager.DeleteInventoryItem(manager);
            Service.ClearAllTextBoxes(this);
            MessageBox.Show("Item has been deleted successfully!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected void ButtonListAll_Click(object sender, EventArgs e)
        {
            Manager manager = new Manager();
            GridViewInventoryByManager.DataSource = manager.GetAllItemRecords();
            GridViewInventoryByManager.DataBind();
            TextBoxQuantityConsumedManager.Text = "";
        }

        public bool IsValidQuantityConsumed()
        {
            TextBoxQuantityConsumedManager.Enabled = true;
            ButtonConsumedManager.Enabled = true;
            string input = "";
            input = TextBoxQuantityConsumedManager.Text.Trim();
            if (TextBoxQuantityConsumedManager.Text == "")
            {
                MessageBox.Show("Consumed Quantity should not be empty!", "Invalid Quantity Consumed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextBoxQuantityConsumedManager.Text = string.Empty;
                TextBoxQuantityConsumedManager.Focus();
                return false;
            }
            if (!ValidatorManager.IsValidNumeric(input))
            {
                MessageBox.Show("Consumed Quantity should be numeric!", "Invalid Quantity Consumed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextBoxQuantityConsumedManager.Text = string.Empty;
                TextBoxQuantityConsumedManager.Focus();
                return false;
                
            }
            return true;

        }

        protected void ButtonConsumedManager_Click(object sender, EventArgs e)
        {

            if (!IsValidQuantityConsumed())
            {
                return;
            }
            

            int consumeQuantity = Convert.ToInt32(TextBoxQuantityConsumedManager.Text);
            int currentQuantity;
            if (consumeQuantity > Convert.ToInt32(TextBoxQuantityManager.Text))
            {
                MessageBox.Show("Consume quantity cannot be greater than current quantity");
                TextBoxQuantityConsumedManager.Text = "";
                TextBoxQuantityConsumedManager.Enabled = true;
                return;
            }
            else
            {
                currentQuantity = Convert.ToInt32(TextBoxQuantityManager.Text) - consumeQuantity;
            }

            int itemID = Convert.ToInt32(TextBoxItemIdManager.Text);

            Manager manager = new Manager();
            manager.UpdateInventoryForConsumedQ(itemID, currentQuantity);

            InventoryHistory inventoryHistory = new InventoryHistory();
            inventoryHistory.ItemID = itemID;
            inventoryHistory.CurrentQuantity = currentQuantity;
            inventoryHistory.PreviousQuantity = Convert.ToInt32(TextBoxQuantityManager.Text);
            inventoryHistory.DateTimestamp = DateTime.Now;
            inventoryHistory.AddInventoryHistoryItem(inventoryHistory);

            List<Manager> mngList = new List<Manager>();
            mngList = manager.GetInventoryByItemID(itemID);
            GridViewInventoryByManager.DataSource = mngList;
            GridViewInventoryByManager.DataBind();

            TextBoxItemIdManager.Text = "";
            TextBoxItemNameManager.Text = "";
            TextBoxQuantityManager.Text = "";
            TextBoxUnitPriceManager.Text = "";
            TextBoxUnitOfMeasureManager.Text = "";
            TextBoxTotalPriceManager.Text = "";
            TextBoxQuantityConsumedManager.Text = "";

            ButtonConsumedManager.Enabled = false;
            MessageBox.Show("Quantity of this item has been updated!", "Quantity Update", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        protected void TextBoxQuantityConsumedManager_TextChanged(object sender, EventArgs e)
        {
            //ButtonConsumedManager.Enabled = true;

        }

        public bool IsValidSeach()
        {
            TextBoxSearchByManager.Enabled = true;
            string input = "";
            input = TextBoxSearchByManager.Text.Trim();
            if (TextBoxSearchByManager.Text == "")
            {
                MessageBox.Show("Search Value should not be empty!", "Invalid Search", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextBoxSearchByManager.Text = string.Empty;
                TextBoxSearchByManager.Focus();
                return false;
            }
            return true;
        }

        protected void ImageButtonSearch_Click(object sender, ImageClickEventArgs e)
        {

            GridViewInventoryHistory.DataSource = null;
            GridViewInventoryHistory.DataBind();


            if (!IsValidSeach())
            {
                return;
            }

            List<Manager> managerList = new List<Manager>();

            if (DropDownListSearchByManager.SelectedItem.Text == "Item ID")
            {
                Manager manager = new Manager();
                int itemID = Convert.ToInt32(TextBoxSearchByManager.Text);
                managerList = manager.GetInventoryByItemID(itemID);

                if (managerList.Count > 0)
                {
                    GridViewInventoryByManager.DataSource = managerList;
                    GridViewInventoryByManager.DataBind();
                }
                else
                {
                    MessageBox.Show("Item not found!", "No Item", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (DropDownListSearchByManager.SelectedItem.Text == "Item Name")
            {
                Manager manager = new Manager();
                string itemName = TextBoxSearchByManager.Text;
                managerList = manager.GetInventoryByItemName(itemName);

                if (managerList.Count > 0)
                {
                    GridViewInventoryByManager.DataSource = managerList;
                    GridViewInventoryByManager.DataBind();
                }
                else
                {
                    MessageBox.Show("Item not found!", "No Item", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            //if (DropDownListSearchByManager.SelectedItem.Text == "Item Name")
            //{
            //    Manager manager = new Manager();
            //    managerList = manager.GetInventoryByItemName(TextBoxSearchByManager.Text);
            //    GridViewInventoryByManager.DataSource = managerList;
            //    GridViewInventoryByManager.DataBind();
            //}


            TextBoxQuantityConsumedManager.Text = "";
            TextBoxSearchByManager.Text = "";
        }


        protected void GridViewInventory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Select")
            {
                GridViewInventoryHistory.DataSource = null;
                GridViewInventoryHistory.DataBind();

                

                GridViewRow selectedRow = GridViewInventoryByManager.Rows[rowIndex];

                if (selectedRow != null)
                {
                    TextBoxItemIdManager.Text = selectedRow.Cells[0].Text;
                    TextBoxItemNameManager.Text = selectedRow.Cells[1].Text;
                    TextBoxQuantityManager.Text = selectedRow.Cells[2].Text;
                    TextBoxUnitPriceManager.Text = selectedRow.Cells[3].Text;
                    TextBoxUnitOfMeasureManager.Text = selectedRow.Cells[4].Text;

                    int quantity = int.Parse(selectedRow.Cells[2].Text);
                    decimal unitPrice = decimal.Parse(selectedRow.Cells[3].Text);
                    decimal totalPrice = quantity * unitPrice;
                    TextBoxTotalPriceManager.Text = totalPrice.ToString();

                    GridViewInventoryByManager.DataSource = null;
                    GridViewInventoryByManager.DataBind();

                    TextBoxItemIdManager.ReadOnly = true;
                    TextBoxTotalPriceManager.ReadOnly = true;
                    TextBoxQuantityConsumedManager.Enabled = true;
                    ButtonUpdateManager.Enabled = true;
                    ButtonDeleteManager.Enabled = true;
                    ButtonConsumedManager.Enabled = true;



                }
            }
            else if (e.CommandName == "Show")
            {

                GridViewRow selectedRow = GridViewInventoryByManager.Rows[rowIndex];
                if (selectedRow != null)
                {
                    int itemID = Convert.ToInt32(selectedRow.Cells[0].Text);
                    InventoryHistory inventoryHistory = new InventoryHistory();
                    List<InventoryHistory> inventoryHistories = inventoryHistory.GetInventoryHistoryByItemID(itemID);
                    GridViewInventoryHistory.DataSource = inventoryHistories.OrderByDescending(x => x.DateTimestamp).ToList();
                    GridViewInventoryHistory.DataBind();
                }
            }
        }

        //protected void GridViewInventory_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //GridViewInventoryByManager.Enabled = false;

        //    TextBoxItemIdManager.Text = GridViewInventoryByManager.SelectedRow.Cells[0].Text.ToString();
        //    TextBoxItemNameManager.Text = GridViewInventoryByManager.SelectedRow.Cells[1].Text.ToString();
        //    TextBoxQuantityManager.Text = GridViewInventoryByManager.SelectedRow.Cells[2].Text.ToString();
        //    TextBoxUnitPriceManager.Text = GridViewInventoryByManager.SelectedRow.Cells[3].Text.ToString();
        //    TextBoxUnitOfMeasureManager.Text = GridViewInventoryByManager.SelectedRow.Cells[4].Text.ToString();


        //    int quantity = int.Parse(GridViewInventoryByManager.SelectedRow.Cells[2].Text);
        //    decimal unitPrice = decimal.Parse(GridViewInventoryByManager.SelectedRow.Cells[3].Text);
        //    decimal totalPrice = quantity * unitPrice;
        //    TextBoxTotalPriceManager.Text = totalPrice.ToString();

        //    GridViewInventoryByManager.DataSource = null;
        //    GridViewInventoryByManager.DataBind();

        //    TextBoxItemIdManager.ReadOnly = true;
        //    TextBoxTotalPriceManager.ReadOnly = true;
        //    TextBoxQuantityConsumedManager.Enabled = true;
        //    ButtonUpdateManager.Enabled = true;
        //    ButtonDeleteManager.Enabled = true;
        //    ButtonConsumedManager.Enabled = true;
        //}


        protected void TextBoxSearchByManager_TextChanged(object sender, EventArgs e)
        {
            //ImageButtonSearch.Enabled = true;
        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            if (FileUploadControl.HasFile)
            {
                try
                {
                    // Get the physical path for the uploaded file
                    string filePath = Server.MapPath("~" + FileUploadControl.FileName);

                    // Save the uploaded file to the server
                    FileUploadControl.SaveAs(filePath);

                    // Read the JSON data from the uploaded file
                    string json = File.ReadAllText(filePath);

                    // Deserialize the JSON to a list of Inventory objects
                    List<Inventory> items = JsonSerializer.Deserialize<List<Inventory>>(json);

                    // Iterate through the items and check if they already exist
                    foreach (Inventory item in items)
                    {
                        // Check if an item with the same ID already exists in your inventory
                        Inventory existingItem = InventoryDB.SelectRecordsByItemID(item.ItemID).FirstOrDefault();
                        if (existingItem != null)
                        {
                            // Update the existing item with the new data
                            int newQuantity = existingItem.Quantity + item.Quantity;
                            item.UpdateInventory(item.ItemID, newQuantity);

                        }
                        else
                        {
                            // If the item does not exist, add it to the inventory
                            item.AddInventoryItem(item);
                        }
                    }

                    // Bind the updated inventory to the GridView
                    GridViewInventoryByManager.DataSource = InventoryDB.GetAllItems().OrderBy(item => item.ItemID);
                    GridViewInventoryByManager.DataBind();

                    // Display a success message or perform other actions
                    MessageBox.Show("File uploaded successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a file to upload.");
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

        protected void ButtonAdvancedManagement_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormAdvancedManagement.aspx");
        }

        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormInventoryOrder.aspx");
            MessageBox.Show("You are now in Order Window!");


        }
    }
}