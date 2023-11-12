using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestoClerkInventory.BLL;
using System.Data.SqlClient;
using System.Windows.Forms;
using RestoClerkInventory.SERVICE;

namespace RestoClerkInventory.DAL
{
    public static class InventoryDB
    {
        public static List<Inventory> SelectRecordsByItemID(int itemID)
        {
            List<Inventory> inventories = new List<Inventory>();
            SqlConnection conn = Service.GetDBConnection();
            SqlCommand cmdSelectByItemId = new SqlCommand("SELECT * FROM Inventories WHERE ItemID = @ItemID", conn);
            cmdSelectByItemId.Parameters.AddWithValue("@ItemID", itemID);
            SqlDataReader reader = cmdSelectByItemId.ExecuteReader();
            if (reader.Read())
            {
                inventories.Add(new Inventory()
                {
                    ItemID = (int)reader["ItemId"],
                    Name = reader["Name"].ToString(),
                    Quantity = (int)reader["Quantity"],
                    UnitPrice = (decimal)reader["UnitPrice"],
                    UnitOfMeasure = reader["UnitOfMeasure"].ToString()
                });
            
            }
            //else
            //{
            //    MessageBox.Show("Item not found");
            //}
            return inventories;
        }

        public static List<Inventory> SelectRecordsByItemName(String name)
        {
            List<Inventory> inventories = new List<Inventory>();
            SqlConnection conn = Service.GetDBConnection();
            SqlCommand cmdSelectByName = new SqlCommand("SELECT * FROM Inventories WHERE Name = @Name", conn);
            cmdSelectByName.Parameters.AddWithValue("@Name", name);
            SqlDataReader reader = cmdSelectByName.ExecuteReader();

            if (reader.Read())
            {
                inventories.Add(new Inventory()
                {
                    ItemID = (int)reader["ItemId"],
                    Name = reader["Name"].ToString(),
                    Quantity = (int)reader["Quantity"],
                    UnitPrice = (decimal)reader["UnitPrice"],
                    UnitOfMeasure = reader["UnitOfMeasure"].ToString()
                });
            }
            else
            {
                MessageBox.Show("Item not found");
            }
            return inventories;
        }

        public static void UpdateRecord(int itemID, int quantity)
        {
            try
            {
                SqlConnection conn = Service.GetDBConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE Inventories SET Quantity = @Quantity WHERE ItemID = @ItemID", conn);
                cmdUpdate.Parameters.AddWithValue("@Quantity", quantity);
                cmdUpdate.Parameters.AddWithValue("@ItemID", itemID);
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void InsertRecord(Inventory item)
        {
            try
            {
                SqlConnection conn = Service.GetDBConnection();
                SqlCommand cmdInsert = new SqlCommand("INSERT INTO Inventories VALUES (@ItemID, @Name, @Quantity, @UnitPrice, @UnitOfMeasure)", conn);
                cmdInsert.Parameters.AddWithValue("@ItemID", item.ItemID);
                cmdInsert.Parameters.AddWithValue("@Name", item.Name);
                cmdInsert.Parameters.AddWithValue("@Quantity", item.Quantity);
                cmdInsert.Parameters.AddWithValue("@UnitPrice", item.UnitPrice);
                cmdInsert.Parameters.AddWithValue("@UnitOfMeasure", item.UnitOfMeasure);
                cmdInsert.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static List<Inventory> GetAllItems()
        {
            List<Inventory> inventories = new List<Inventory>();
            SqlConnection conn = Service.GetDBConnection();
            SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM Inventories", conn);
            SqlDataReader reader = cmdSelectAll.ExecuteReader();
            while (reader.Read())
            {
                inventories.Add(new Inventory()
                {
                    ItemID = (int)reader["ItemId"],
                    Name = reader["Name"].ToString(),
                    Quantity = (int)reader["Quantity"],
                    UnitPrice = (decimal)reader["UnitPrice"],
                    UnitOfMeasure = reader["UnitOfMeasure"].ToString()
                });
            }
            return inventories;
        }

        public static int GetLastQuantity(int itemID)
        {
            int lastQuantity = 0;
            SqlConnection conn = Service.GetDBConnection();
            SqlCommand cmdSelectByItemId = new SqlCommand("SELECT Quantity FROM Inventories WHERE ItemId = @ItemID", conn);
            cmdSelectByItemId.Parameters.AddWithValue("@ItemID", itemID);
            SqlDataReader reader = cmdSelectByItemId.ExecuteReader();
            if (reader.Read())
            {
                lastQuantity = Convert.ToInt32(reader["Quantity"]);
            }
            else
            {
                MessageBox.Show("Item not found");
            }

            return lastQuantity;
        }
    }
}