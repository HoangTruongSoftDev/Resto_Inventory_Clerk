using RestoClerkInventory.BLL;
using RestoClerkInventory.ENUM;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using RestoClerkInventory.SERVICE;
namespace RestoClerkInventory.DAL
{
    public class ThresholdDB
    {
        public static void InsertRecord(Threshold threshold)
        {

            SqlConnection conn = Service.GetDBConnection();
            SqlCommand cmdInsert = new SqlCommand("INSERT INTO Thresholds VALUES (@thresholdId, @modeId, @managerId, @thresholdNumber, @thresholdAlarm); ", conn);
            cmdInsert.Parameters.AddWithValue("@thresholdId", threshold.ThresholdId);
            cmdInsert.Parameters.AddWithValue("@modeId", threshold.ModeId);
            cmdInsert.Parameters.AddWithValue("@managerId", threshold.ManagerId);
            cmdInsert.Parameters.AddWithValue("@thresholdNumber", threshold.ThresholdNumber);
            cmdInsert.Parameters.AddWithValue("@thresholdAlarm", threshold.ThresholdAlarm);         
            cmdInsert.ExecuteNonQuery();
            conn.Close();
        }
        public static void UpdateRecord(Threshold threshold)
        {
            SqlConnection conn = Service.GetDBConnection();
            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.CommandText = "UPDATE Thresholds SET ModeId = @modeId, ManagerId = @managerId, ThresholdNumber = @thresholdNumber, ThresholdAlarm = @thresholdAlarm WHERE ThresholdId = @thresholdId;";
            cmdUpdate.Connection = conn;
            cmdUpdate.Parameters.AddWithValue("@thresholdId", threshold.ThresholdId);
            cmdUpdate.Parameters.AddWithValue("@modeId", threshold.ModeId);
            cmdUpdate.Parameters.AddWithValue("@managerId", threshold.ManagerId);
            cmdUpdate.Parameters.AddWithValue("@thresholdNumber", threshold.ThresholdNumber);
            cmdUpdate.Parameters.AddWithValue("@thresholdAlarm", threshold.ThresholdAlarm);
            cmdUpdate.ExecuteNonQuery();
            conn.Close();
        }
        public static void DeleteRecord(Threshold threshold)
        {
            SqlConnection conn = Service.GetDBConnection();
            SqlCommand cmdDelete = new SqlCommand("DELETE FROM Thresholds WHERE ThresholdId = @thresholdId; ", conn);
            cmdDelete.Parameters.AddWithValue("@thresholdId", threshold.ThresholdId);
            cmdDelete.ExecuteNonQuery();
            conn.Close();
        }
        public static List<Threshold> SelectAllRecords()
        {
            List<Threshold> listAllThresholds = new List<Threshold>();
            SqlConnection conn = Service.GetDBConnection();
            SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM Thresholds; ", conn);
            SqlDataReader reader = cmdSelectAll.ExecuteReader();
            Threshold threshold;
            while (reader.Read())
            {
                threshold = new Threshold();
                threshold.ThresholdId = Convert.ToInt32(reader["ThresholdId"]);
                threshold.ModeId = Convert.ToInt32(reader["ModeId"]);
                threshold.ManagerId = Convert.ToInt32(reader["ManagerId"]);
                threshold.ThresholdNumber = Convert.ToInt32(reader["ThresholdNumber"]);
                threshold.ThresholdAlarm = Convert.ToInt32(reader["ThresholdAlarm"]);
                listAllThresholds.Add(threshold);
            }
            conn.Close();

            if (listAllThresholds.Any())
                return listAllThresholds;
            return null;

        }
        public static Threshold SelectRecordById(int thresholdId)
        {
            SqlConnection conn = Service.GetDBConnection();
            SqlCommand cmdSelectById = new SqlCommand("SELECT * FROM Thresholds WHERE ThresholdId = @thresholdId; ", conn);
            cmdSelectById.Parameters.AddWithValue("@thresholdId", thresholdId);
            SqlDataReader reader = cmdSelectById.ExecuteReader();
            Threshold threshold = null;
            if (reader.Read())
            {
                threshold = new Threshold();
                threshold.ThresholdId = Convert.ToInt32(reader["ThresholdId"]);
                threshold.ModeId = Convert.ToInt32(reader["ModeId"]);
                threshold.ManagerId = Convert.ToInt32(reader["ManagerId"]);
                threshold.ThresholdNumber = Convert.ToInt32(reader["ThresholdNumber"]);
                threshold.ThresholdAlarm = Convert.ToInt32(reader["ThresholdAlarm"]);
            }
            conn.Close();

            return threshold;


        }
        public static Threshold SelectRecordByManagerId(int managerId)
        {
            SqlConnection conn = Service.GetDBConnection();
            SqlCommand cmdSelectById = new SqlCommand("SELECT * FROM Thresholds WHERE ManagerId = @managerId; ", conn);
            cmdSelectById.Parameters.AddWithValue("@managerId", managerId);
            SqlDataReader reader = cmdSelectById.ExecuteReader();
            Threshold threshold = null;
            if (reader.Read())
            {
                threshold = new Threshold();
                threshold.ThresholdId = Convert.ToInt32(reader["ThresholdId"]);
                threshold.ModeId = Convert.ToInt32(reader["ModeId"]);
                threshold.ManagerId = Convert.ToInt32(reader["ManagerId"]);
                threshold.ThresholdNumber = Convert.ToInt32(reader["ThresholdNumber"]);
                threshold.ThresholdAlarm = Convert.ToInt32(reader["ThresholdAlarm"]);
            }
            conn.Close();

            return threshold;


        }
    }
}