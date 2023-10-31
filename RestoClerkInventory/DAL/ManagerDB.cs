using RestoClerkInventory.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Windows.Forms;
using RestoClerkInventory.SERVICE;


namespace RestoClerkInventory.DAL
{
    public class ManagerDB
    {

        public static List<Manager> GetAllItems()
        {
            List<Manager> items = new List<Manager>();
            SqlConnection conn = Service.GetDBConnection();
            SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM Inventories", conn);
            SqlDataReader reader = cmdSelectAll.ExecuteReader();

            while (reader.Read())
            {
                Manager manager = new Manager();
                manager.ItemID = Convert.ToInt32(reader["ItemID"]);
                manager.Name = reader["Name"].ToString();
                manager.Quantity = Convert.ToInt32(reader["Quantity"]);
                manager.UnitPrice = (decimal)(reader["UnitPrice"]);
                manager.UnitOfMeasure = reader["UnitOfMeasure"].ToString();
                items.Add(manager);

            }
            conn.Close();
            return items;
        }

        public static List<Manager> SelectRecordsByItemID(int itemID)
        {
            List<Manager> managerList = new List<Manager>();
            SqlConnection conn = Service.GetDBConnection();
            SqlCommand cmdSelectByItemId = new SqlCommand("SELECT * FROM Inventories WHERE ItemID = @ItemID", conn);
            cmdSelectByItemId.Parameters.AddWithValue("@ItemID", itemID);
            SqlDataReader reader = cmdSelectByItemId.ExecuteReader();
            if (reader.Read())
            {
                managerList.Add(new Manager()
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
            return managerList;
        }

        public static List<Manager> SelectRecordsByItemName(String name)
        {
            List<Manager> managerList = new List<Manager>();
            SqlConnection conn = Service.GetDBConnection();
            SqlCommand cmdSelectByName = new SqlCommand("SELECT * FROM Inventories WHERE Name = @Name", conn);
            cmdSelectByName.Parameters.AddWithValue("@Name", name);
            SqlDataReader reader = cmdSelectByName.ExecuteReader();

            if (reader.Read())
            {
                managerList.Add(new Manager()
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
            return managerList;
        }

        public static void UpdateRecordForConsumedQuantity(int itemID, int quantity)
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

    }
}