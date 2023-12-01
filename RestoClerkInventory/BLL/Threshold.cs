using RestoClerkInventory.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestoClerkInventory.BLL
{
    public class Threshold
    {
        private int thresholdId;
        private int modeId;
        private int managerId;
        private int thresholdNumber;
        private int thresholdAlarm;
        public int ThresholdId
        {
            get { return this.thresholdId; }
            set { this.thresholdId = value; }
        }
        public int ThresholdAlarm
        {
            get { return this.thresholdAlarm; }
            set { this.thresholdAlarm = value; }
        }
        public int ModeId
        {
            set { this.modeId = value; }
            get { return this.modeId; }
        }
        public int ManagerId
        {
            set => this.managerId = value;
            get => this.managerId;
        }
        public int ThresholdNumber { get => this.thresholdNumber; set => this.thresholdNumber = value; }

        public void InsertThreshold(Threshold threshold) => ThresholdDB.InsertRecord(threshold);

        public void UpdateThreshold(Threshold threshold) => ThresholdDB.UpdateRecord(threshold);
        public void DeleteThreshold(Threshold threshold) => ThresholdDB.DeleteRecord(threshold);

        public Threshold GetThresholdById(int thresholdId) => ThresholdDB.SelectRecordById(thresholdId);

        public List<Threshold> GetAllThresholds() => ThresholdDB.SelectAllRecords();
        public Threshold GetThresholdByManagerId(int managerId) => ThresholdDB.SelectRecordByManagerId(managerId);
    }
}