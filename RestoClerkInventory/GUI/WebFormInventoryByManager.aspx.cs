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
            }
            ButtonConsumedManager.Enabled = false;
            //ImageButtonSearch.Enabled = false;
            TextBoxQuantityConsumedManager.Enabled = false;
            TextBoxTotalPriceManager.Enabled = false;
            //ButtonSaveManager.Enabled = false;



        }

        public bool AreAllValidFields() {

            Manager manager = new Manager();


            string input = "";
            input = TextBoxItemIdManager.Text.Trim();

            // ID should be Numeric
            if (!ValidatorManager.IsValidId(input))
            {
                MessageBox.Show("Id must be numeric!", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextBoxItemIdManager.Text = string.Empty;
                TextBoxItemIdManager.Focus();
                return false;                        
            }

            // ID should not be Duplicate
            input = TextBoxItemIdManager.Text.Trim();
            if (manager.getDuplicateItemId(Convert.ToInt32(input)))
            {
                MessageBox.Show("This Item Id already exist!", "Duplicate Id", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextBoxItemIdManager.Text = string.Empty;
                TextBoxItemIdManager.Focus();
                return false;
            }


            // Item Name should be not be Empty and should be String
            input = TextBoxItemNameManager.Text.Trim();
            if (!ValidatorManager.IsValidName(input))
            {
                MessageBox.Show("Unit of measure should only consist alphabets!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextBoxItemNameManager.Text = string.Empty;
                TextBoxItemNameManager.Focus();
                return false;
            }


            // Quantity should be Numeric
            input = TextBoxQuantityManager.Text.Trim();
            if (!ValidatorManager.IsValidNumeric(input))
            {
                MessageBox.Show("Quantity should be numeric!", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextBoxQuantityManager.Text = string.Empty;
                TextBoxQuantityManager.Focus();
                return false;
            }

            // Unit Price should be Numeric
            input = TextBoxUnitPriceManager.Text.Trim();
            if (!ValidatorManager.IsValidNumeric(input))
            {
                MessageBox.Show("Unit Price should be numeric!", "Invalid Unit Price", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextBoxUnitPriceManager.Text = string.Empty;
                TextBoxUnitPriceManager.Focus();
                return false;
            }

            // Unit of Measure should not be empty and should be String
            input = TextBoxUnitOfMeasureManager.Text.Trim();
            if (!ValidatorManager.IsValidName(input))
            {
                MessageBox.Show("Unit of measure should only consist alphabets!", "Invalid Unit Measure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextBoxUnitOfMeasureManager.Text = string.Empty;
                TextBoxUnitOfMeasureManager.Focus();
                return false;
            }

            return true;

        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            Manager manager = new Manager();
            if (!AreAllValidFields())
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
            MessageBox.Show("Item has been saved successfully", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);



        }

        protected void ButtonClear_Click(object sender, EventArgs e)
        {
            //ButtonClearManager.Enabled = false;

            Service.ClearAllTextBoxes(this);
            GridViewInventoryByManager.DataSource = null;
            GridViewInventoryByManager.DataBind();
            TextBoxItemIdManager.ReadOnly = false;
            ButtonDeleteManager.Enabled = false;
            ButtonUpdateManager.Enabled = false;

        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            ButtonUpdateManager.Enabled = false;

        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            ButtonDeleteManager.Enabled = false;

        }

        protected void ButtonListAll_Click(object sender, EventArgs e)
        {
            Manager manager = new Manager();
            GridViewInventoryByManager.DataSource = manager.GetAllItemRecords();
            GridViewInventoryByManager.DataBind();
            TextBoxQuantityConsumedManager.Text = "";
        }

   

        protected void ButtonConsumedManager_Click(object sender, EventArgs e)
        {
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

        }

        protected void TextBoxQuantityConsumedManager_TextChanged(object sender, EventArgs e)
        {
            ButtonConsumedManager.Enabled = true;

        }

        // FIX THE CODES


        public bool IsValidQuantityConsumed(){

            string input = "";
            input = TextBoxQuantityConsumedManager.Text.Trim();
            if (TextBoxQuantityConsumedManager.Text != "")
            {
                MessageBox.Show("Consumed Quantity should not be empty", "Invalid Quantity Consumed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextBoxQuantityConsumedManager.Text = string.Empty;
                TextBoxQuantityConsumedManager.Focus();
                return false;
            }

            // && !ValidatorManager.IsValidNumeric(input)

            return true;

        }



            protected void ImageButtonSearch_Click(object sender, ImageClickEventArgs e)
            {
           

            IsValidQuantityConsumed();

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

        protected void GridViewInventory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GridViewInventoryByManager.Enabled = false;

            TextBoxItemIdManager.Text = GridViewInventoryByManager.SelectedRow.Cells[0].Text.ToString();
            TextBoxItemNameManager.Text = GridViewInventoryByManager.SelectedRow.Cells[1].Text.ToString();
            TextBoxQuantityManager.Text = GridViewInventoryByManager.SelectedRow.Cells[2].Text.ToString();
            TextBoxUnitPriceManager.Text = GridViewInventoryByManager.SelectedRow.Cells[3].Text.ToString();
            TextBoxUnitOfMeasureManager.Text = GridViewInventoryByManager.SelectedRow.Cells[4].Text.ToString();


            int quantity = int.Parse(GridViewInventoryByManager.SelectedRow.Cells[2].Text);
            decimal unitPrice = decimal.Parse(GridViewInventoryByManager.SelectedRow.Cells[3].Text);
            decimal totalPrice = quantity * unitPrice;
            TextBoxTotalPriceManager.Text = totalPrice.ToString();

            GridViewInventoryByManager.DataSource = null;
            GridViewInventoryByManager.DataBind();
            TextBoxQuantityConsumedManager.Enabled = true;
            TextBoxTotalPriceManager.ReadOnly = true;
            TextBoxItemIdManager.ReadOnly = true;
        }

        protected void ButtonExitManager_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormLogin.aspx");

        }

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


    }
}