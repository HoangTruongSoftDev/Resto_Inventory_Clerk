using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestoClerkInventory.DAL;

namespace RestoClerkInventory.BLL
{
    public class Inventory
    {
        private int itemID;
        private string name;
        private int quantity;
        private decimal unitPrice;
        private string unitOfMeasure;

        public int ItemID
        {
            get { return this.itemID; }
            set { this.itemID = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Quantity
        {
            get { return this.quantity; }
            set { this.quantity = value; }
        }

        public decimal UnitPrice
        {
            get { return this.unitPrice; }
            set { this.unitPrice = value; }
        }

        public string UnitOfMeasure
        {
            get { return this.unitOfMeasure; }
            set { this.unitOfMeasure = value; }
        }

        public List<Inventory> GetInventoryByItemID(int itemID) => InventoryDB.SelectRecordsByItemID(itemID);

        public List<Inventory> GetInventoryByItemName(string name) => InventoryDB.SelectRecordsByItemName(name);

        public void UpdateInventory(int itemID, int quantity) => InventoryDB.UpdateRecord(itemID, quantity);

        public void AddInventoryItem(Inventory inventory) => InventoryDB.InsertRecord(inventory);
    }
}