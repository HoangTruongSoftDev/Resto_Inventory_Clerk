using RestoClerkInventory.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Windows.Forms;
using RestoClerkInventory.SERVICE;
using System.Net;


namespace RestoClerkInventory.DAL
{
    public class ManagerDB
    {
        public static void SaveItems(Manager mngr)
        {  
            SqlConnection conn = Service.GetDBConnection();         //connect DB
            try
            {
                //creating and customizing an object of SqlCommand
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = conn;
                cmdInsert.CommandText = "INSERT INTO Inventories (ItemID,Name,Quantity,UnitPrice,UnitOfMeasure)" +
                    " VALUES(@ItemID,@Name,@Quantity,@UnitPrice,@UnitOfMeasure)";

                cmdInsert.Parameters.AddWithValue("@ItemID", mngr.ItemID);
                cmdInsert.Parameters.AddWithValue("@Name", mngr.Name);
                cmdInsert.Parameters.AddWithValue("@Quantity", mngr.Quantity);
                cmdInsert.Parameters.AddWithValue("@UnitPrice", mngr.UnitPrice);
                cmdInsert.Parameters.AddWithValue("@UnitOfMeasure", mngr.UnitOfMeasure);
                cmdInsert.ExecuteNonQuery();            //Excute the inserted query
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally                          //clean the code and close database
            {
                conn.Close();                //close DB
                conn.Dispose();              //perform the job right away, will dispose the garbage
            }

        }

        public static void UpdateItem(Manager mngr)
        {
            SqlConnection conn = Service.GetDBConnection();
            try
            {
                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = conn;
                cmdUpdate.CommandText = "UPDATE Inventories " +
                    "SET Name = @Name, Quantity = @Quantity, UnitPrice = @UnitPrice, UnitOfMeasure = @UnitOfMeasure " +
                    "WHERE ItemID = @ItemID";

                cmdUpdate.Parameters.AddWithValue("@ItemID", mngr.ItemID);
                cmdUpdate.Parameters.AddWithValue("@Name", mngr.Name);
                cmdUpdate.Parameters.AddWithValue("@Quantity", mngr.Quantity);
                cmdUpdate.Parameters.AddWithValue("@UnitPrice", mngr.UnitPrice);
                cmdUpdate.Parameters.AddWithValue("@UnitOfMeasure", mngr.UnitOfMeasure);
                cmdUpdate.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public static void DeleteItem(Manager mngr) 
        {
            SqlConnection conn = Service.GetDBConnection();
            try
            {
                SqlCommand cmdDelete = new SqlCommand();
                cmdDelete.Connection = conn;
                cmdDelete.CommandText = "DELETE FROM Inventories WHERE ItemID = @ItemID";
                cmdDelete.Parameters.AddWithValue("@ItemID", mngr.ItemID);
                cmdDelete.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public static bool IsDuplicateId(int id)
        {
            List<Manager> managerList = SelectRecordsByItemID(id);

            if (managerList.Count > 0)
            {
                return true; // Duplicate ID found
            }

            return false; // No duplicate ID found
        }



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