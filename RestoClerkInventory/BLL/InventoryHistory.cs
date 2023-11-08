using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestoClerkInventory.DAL;

namespace RestoClerkInventory.BLL
{
    public class InventoryHistory
    {
        private int itemID;
        private int currentQuantity;
        private int previousQuantity;
        private DateTime dateTimestamp;

        public int ItemID
        {
            get { return this.itemID; }
            set { this.itemID = value; }
        }

        public int CurrentQuantity
        {
            get { return this.currentQuantity; }
            set { this.currentQuantity = value; }
        }

        public int PreviousQuantity
        {
            get { return this.previousQuantity; }
            set { this.previousQuantity = value; }
        }

        public DateTime DateTimestamp
        {
            get { return this.dateTimestamp; }
            set { this.dateTimestamp = value; }
        }
        public List<InventoryHistory> GetInventoryHistoryByItemID(int itemID) => InventoryHistoryDB.SelectRecordsByItemID(itemID);

        public void AddInventoryHistoryItem(InventoryHistory inventoryHistory) => InventoryHistoryDB.InsertRecord(inventoryHistory);
    }
}