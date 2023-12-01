using RestoClerkInventory.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestoClerkInventory.BLL
{
    public class Order
    {
        private int itemID;
        private string name;
        private int quantity;
        private decimal unitPrice;
        private string unitOfMeasure;
        private DateTime orderDateTime;

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

        public DateTime OrderDateTime
        {
            get { return this.orderDateTime; }
            set { this.orderDateTime = value; }
        }

        public List<Order> GetAllItemRecords() => OrderDB.GetAllOrderedItems();
        public void SaveOrder(Order order) => OrderDB.SaveItemOrder(order);
        public bool getDuplicateItemId(int id) => OrderDB.IsDuplicateId(id);
        public List<Order> GetInventoryByItemID(int itemID) => OrderDB.SelectRecordsByItemID(itemID);
        public List<Order> GetInventoryByItemName(string name) => OrderDB.SelectRecordsByItemName(name);
        public void UpdateOrderItem(Order order) => OrderDB.UpdateItem(order);
        public void DeleteOrder(Order order) => OrderDB.DeleteOrderedItem(order);









    }
}