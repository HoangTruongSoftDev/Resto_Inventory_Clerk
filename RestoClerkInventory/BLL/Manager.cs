using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestoClerkInventory.DAL;

namespace RestoClerkInventory.BLL
{
    public class Manager
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

        public void SaveInventoryItem(Manager mngr) => ManagerDB.SaveItems(mngr);        
        public void UpdateInventoryItem(Manager mngr) => ManagerDB.UpdateItem(mngr);
        public void DeleteInventoryItem(Manager mngr) => ManagerDB.DeleteItem(mngr);
        public List<Manager> GetAllItemRecords() => ManagerDB.GetAllItems();
        public List<Manager> GetInventoryByItemID(int itemID) => ManagerDB.SelectRecordsByItemID(itemID);
        public List<Manager> GetInventoryByItemName(string name) => ManagerDB.SelectRecordsByItemName(name);
        public void UpdateInventoryForConsumedQ(int itemID, int quantity) => ManagerDB.UpdateRecordForConsumedQuantity(itemID, quantity);
        public bool getDuplicateItemId(int id) => ManagerDB.IsDuplicateId(id);



    }
}