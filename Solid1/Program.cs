using System;
using System.Collections.Generic;
//SRP (single responsibility principle
namespace Solid1
{
    // Item class representing an item in the order
    class Item
    {
        // Item properties and methods
    }

    // Order class responsible only for order management
    class Order
    {
        private List<Item> itemList = new List<Item>();

        public List<Item> ItemList
        {
            get { return itemList; }
            set { itemList = value; }
        }

        public void CalculateTotalSum() { /*...*/ }
        public List<Item> GetItems() { return itemList; }
        public int GetItemCount() { return itemList.Count; }
        public void AddItem(Item item) { itemList.Add(item); }
        public void DeleteItem(Item item) { itemList.Remove(item); }
    }

    // Interface for order persistence operations
    interface IOrderPersistence
    {
        void Load(Order order);
        void Save(Order order);
        void Update(Order order);
        void Delete(Order order);
    }

    // Class responsible for order persistence
    class OrderPersistence : IOrderPersistence
    {
        public void Load(Order order) { /*...*/ }
        public void Save(Order order) { /*...*/ }
        public void Update(Order order) { /*...*/ }
        public void Delete(Order order) { /*...*/ }
    }

    // Interface for order display operations
    interface IOrderDisplay
    {
        void PrintOrder(Order order);
        void ShowOrder(Order order);
    }

    // Class responsible for order display
    class OrderDisplay : IOrderDisplay
    {
        public void PrintOrder(Order order) { /*...*/ }
        public void ShowOrder(Order order) { /*...*/ }
    }

    class Program
    {
        static void Main()
        {
            // Create a new order and add items
            Order order = new Order();
            order.AddItem(new Item());

            // Use the persistence class to save the order
            IOrderPersistence persistence = new OrderPersistence();
            persistence.Save(order);

            // Use the display class to show the order
            IOrderDisplay display = new OrderDisplay();
            display.PrintOrder(order);
        }
    }
}
