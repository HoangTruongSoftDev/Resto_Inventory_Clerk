using RestoClerkInventory.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace RestoClerkInventory.GUI
{
    public partial class WebFormInventoryStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DropDownListSearch.Items.Add("Item ID");
                DropDownListSearch.Items.Add("Item Name");
            }

            ButtonConsume.Enabled = false;
            ImageButtonSearch.Enabled = false;


        }

        protected void ImageButtonSearch_Click(object sender, ImageClickEventArgs e)
        {

            List<Inventory> inventories = new List<Inventory>();

            
            if (DropDownListSearch.SelectedItem.Text == "Item ID")
            {
                Inventory inventory = new Inventory();
                int itemID = Convert.ToInt32(TextBoxSearch.Text);
                inventories = inventory.GetInventoryByItemID(itemID);
                if (inventories.Count == 0)
                {
                    MessageBox.Show("Item not found");
                    TextBoxSearch.Text = "";
                    return;
                }
                else
                {
                    GridViewInventory.DataSource = inventories;
                    GridViewInventory.DataBind();
                }
            }
            else if (DropDownListSearch.SelectedItem.Text == "Item Name")
            {
                Inventory inventory = new Inventory();
                inventories = inventory.GetInventoryByItemName(TextBoxSearch.Text);
                GridViewInventory.DataSource = inventories;
                GridViewInventory.DataBind();
            }

            TextBoxSearch.Text = "";

        }

        protected void GridViewInventory_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxItemId.Text = GridViewInventory.SelectedRow.Cells[0].Text.ToString();
            TextBoxName.Text = GridViewInventory.SelectedRow.Cells[1].Text.ToString();
            TextBoxQuantity.Text = GridViewInventory.SelectedRow.Cells[2].Text.ToString();
            TextBoxUnitPrice.Text = GridViewInventory.SelectedRow.Cells[3].Text.ToString();
            TextBoxMeasure.Text = GridViewInventory.SelectedRow.Cells[4].Text.ToString();

            int quantity = int.Parse(GridViewInventory.SelectedRow.Cells[2].Text);
            decimal unitPrice = decimal.Parse(GridViewInventory.SelectedRow.Cells[3].Text);
            decimal totalPrice = quantity * unitPrice;
            TextBoxTotalPrice.Text = totalPrice.ToString();

            GridViewInventory.DataSource = null;
            GridViewInventory.DataBind();
            ButtonConsume.Enabled = true;

        }

        protected void ButtonConsume_Click(object sender, EventArgs e)
        {
            int consumeQuantity = Convert.ToInt32(TextBoxConsume.Text);
            int currentQuantity;
            if (consumeQuantity > Convert.ToInt32(TextBoxQuantity.Text))
            {
                MessageBox.Show("Consume quantity cannot be greater than current quantity");
                TextBoxConsume.Text = "";

                return;
            }
            else
            {
                currentQuantity = Convert.ToInt32(TextBoxQuantity.Text) - consumeQuantity;
            }
           
            int itemID = Convert.ToInt32(TextBoxItemId.Text);

            Inventory inventory = new Inventory();
            inventory.UpdateInventory(itemID, currentQuantity);

            List<Inventory> inventories = new List<Inventory>();
            inventories = inventory.GetInventoryByItemID(itemID);
            GridViewInventory.DataSource = inventories;
            GridViewInventory.DataBind();

            TextBoxItemId.Text = "";
            TextBoxName.Text = "";
            TextBoxQuantity.Text = "";
            TextBoxUnitPrice.Text = "";
            TextBoxMeasure.Text = "";
            TextBoxTotalPrice.Text = "";
            TextBoxConsume.Text = "";

            ButtonConsume.Enabled = false;

        }

        protected void TextBoxConsume_TextChanged(object sender, EventArgs e)
        {
            ButtonConsume.Enabled = true;
        }

        protected void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            ImageButtonSearch.Enabled = true;
        }

        protected void ButtonExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormLogin.aspx");
        }
    }
}