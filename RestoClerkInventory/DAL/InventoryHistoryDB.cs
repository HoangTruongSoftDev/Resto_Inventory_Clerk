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
    public static class InventoryHistoryDB
    {

        public static void InsertRecord(InventoryHistory inventoryHistory)
        {
            SqlConnection conn = Service.GetDBConnection();
            SqlCommand cmdInsert = new SqlCommand("INSERT INTO InventoryHistories (ItemId, CurQuantity, PreQuantity, ChangeTime ) VALUES (@ItemID, @CurrentQuantity, @PreviousQuantity, @dateTimestamp)", conn);
            cmdInsert.Parameters.AddWithValue("@ItemID", inventoryHistory.ItemID);
            cmdInsert.Parameters.AddWithValue("@CurrentQuantity", inventoryHistory.CurrentQuantity);
            cmdInsert.Parameters.AddWithValue("@PreviousQuantity", inventoryHistory.PreviousQuantity);
            cmdInsert.Parameters.AddWithValue("@dateTimestamp", inventoryHistory.DateTimestamp);
            cmdInsert.ExecuteNonQuery();
            
        }
        public static List<InventoryHistory> SelectRecordsByItemID(int itemID)
        {
            List<InventoryHistory> inventoryHistories = new List<InventoryHistory>();
            SqlConnection conn = Service.GetDBConnection();
            SqlCommand cmdSelectByItemId = new SqlCommand("SELECT * FROM InventoryHistories WHERE ItemId = @ItemID", conn);
            cmdSelectByItemId.Parameters.AddWithValue("@ItemID", itemID);
            SqlDataReader reader = cmdSelectByItemId.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    InventoryHistory inventoryHistory = new InventoryHistory();
                    inventoryHistory.ItemID = Convert.ToInt32(reader["ItemId"]);
                    inventoryHistory.CurrentQuantity = Convert.ToInt32(reader["CurQuantity"]);
                    inventoryHistory.PreviousQuantity = Convert.ToInt32(reader["PreQuantity"]);
                    inventoryHistory.DateTimestamp = Convert.ToDateTime(reader["ChangeTime"]);
                    inventoryHistories.Add(inventoryHistory);
                }
            }
            
            else
            {
                MessageBox.Show("Item not found");
            }
            return inventoryHistories;
        }
        
    }
}