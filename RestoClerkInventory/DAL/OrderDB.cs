using RestoClerkInventory.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using RestoClerkInventory.SERVICE;



namespace RestoClerkInventory.DAL
{
    public class OrderDB
    {

        public static void SaveItemOrder(Order ord)
        {
            SqlConnection conn = Service.GetDBConnection();         //connect DB
            try
            {
                //creating and customizing an object of SqlCommand
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = conn;
                cmdInsert.CommandText = "INSERT INTO Orders (ItemID,Name,Quantity,UnitPrice,UnitOfMeasure,OrderDateTime)" +
                    " VALUES(@ItemID,@Name,@Quantity,@UnitPrice,@UnitOfMeasure,@OrderDateTime)";

                cmdInsert.Parameters.AddWithValue("@ItemID", ord.ItemID);
                cmdInsert.Parameters.AddWithValue("@Name", ord.Name);
                cmdInsert.Parameters.AddWithValue("@Quantity", ord.Quantity);
                cmdInsert.Parameters.AddWithValue("@UnitPrice", ord.UnitPrice);
                cmdInsert.Parameters.AddWithValue("@UnitOfMeasure", ord.UnitOfMeasure);
                cmdInsert.Parameters.AddWithValue("@OrderDateTime", ord.OrderDateTime);
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

        public static List<Order> GetAllOrderedItems()
        {
            List<Order> items = new List<Order>();
            SqlConnection conn = Service.GetDBConnection();
            SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM Orders", conn);
            SqlDataReader reader = cmdSelectAll.ExecuteReader();

            while (reader.Read())
            {
                Order order = new Order();
                order.ItemID = Convert.ToInt32(reader["ItemID"]);
                order.Name = reader["Name"].ToString();
                order.Quantity = Convert.ToInt32(reader["Quantity"]);
                order.UnitPrice = (decimal)(reader["UnitPrice"]);
                order.UnitOfMeasure = reader["UnitOfMeasure"].ToString();
                order.OrderDateTime = (DateTime)reader["OrderDateTime"];

                items.Add(order);

            }
            conn.Close();
            return items;
        }

        public static List<Order> SelectRecordsByItemID(int itemID)
        {
            List<Order> orderlist = new List<Order>();
            SqlConnection conn = Service.GetDBConnection();
            SqlCommand cmdSelectByItemId = new SqlCommand("SELECT * FROM Orders WHERE ItemID = @ItemID", conn);
            cmdSelectByItemId.Parameters.AddWithValue("@ItemID", itemID);
            SqlDataReader reader = cmdSelectByItemId.ExecuteReader();
            if (reader.Read())
            {
                orderlist.Add(new Order()
                {
                    ItemID = (int)reader["ItemId"],
                    Name = reader["Name"].ToString(),
                    Quantity = (int)reader["Quantity"],
                    UnitPrice = (decimal)reader["UnitPrice"],
                    UnitOfMeasure = reader["UnitOfMeasure"].ToString(),
                    OrderDateTime = (DateTime)reader["OrderDateTime"]


            });

            }

            return orderlist;
        }

        public static List<Order> SelectRecordsByItemName(String name)
        {
            List<Order> orderList = new List<Order>();
            SqlConnection conn = Service.GetDBConnection();
            SqlCommand cmdSelectByName = new SqlCommand("SELECT * FROM Orders WHERE Name = @Name", conn);
            cmdSelectByName.Parameters.AddWithValue("@Name", name);
            SqlDataReader reader = cmdSelectByName.ExecuteReader();

            if (reader.Read())
            {
                orderList.Add(new Order()
                {
                    ItemID = (int)reader["ItemId"],
                    Name = reader["Name"].ToString(),
                    Quantity = (int)reader["Quantity"],
                    UnitPrice = (decimal)reader["UnitPrice"],
                    UnitOfMeasure = reader["UnitOfMeasure"].ToString(),
                    OrderDateTime = (DateTime)reader["OrderDateTime"]

                });
            }

            return orderList;
        }

        public static bool IsDuplicateId(int id)
        {
            List<Order> orderlist = SelectRecordsByItemID(id);

            if (orderlist.Count > 0)
            {
                return true; // Duplicate ID found
            }

            return false; // No duplicate ID found
        }

        public static void UpdateItem(Order order)
        {
            SqlConnection conn = Service.GetDBConnection();
            try
            {
                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = conn;
                cmdUpdate.CommandText = "UPDATE Orders " +
                    "SET Name = @Name, Quantity = @Quantity, UnitPrice = @UnitPrice, UnitOfMeasure = @UnitOfMeasure " +
                    "WHERE ItemID = @ItemID"; // no datetime

                cmdUpdate.Parameters.AddWithValue("@ItemID", order.ItemID);
                cmdUpdate.Parameters.AddWithValue("@Name", order.Name);
                cmdUpdate.Parameters.AddWithValue("@Quantity", order.Quantity);
                cmdUpdate.Parameters.AddWithValue("@UnitPrice", order.UnitPrice);
                cmdUpdate.Parameters.AddWithValue("@UnitOfMeasure", order.UnitOfMeasure);
                cmdUpdate.Parameters.AddWithValue("@OrderDateTime", DateTime.Now);
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

        public static void DeleteOrderedItem(Order order)
        {
            SqlConnection conn = Service.GetDBConnection();
            try
            {
                SqlCommand cmdDelete = new SqlCommand();
                cmdDelete.Connection = conn;
                cmdDelete.CommandText = "DELETE FROM Orders WHERE ItemID = @ItemID";
                cmdDelete.Parameters.AddWithValue("@ItemID", order.ItemID);
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

    }
}