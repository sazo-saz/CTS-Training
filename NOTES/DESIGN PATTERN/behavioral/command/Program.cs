using System;
using System.Collections.Generic;
namespace FoodiesDelight
{
    // Command Interface
    public interface IOrder
    {
        void Execute();
    }
    // Receiver
    public class Chef
    {
        public void PrepareBurger()
        {
            Console.WriteLine("Chef: Preparing a delicious Burger!");
        }
        public void PreparePizza()
        {
            Console.WriteLine("Chef: Preparing a cheesy Pizza!");
        }
        public void PreparePasta()
        {
            Console.WriteLine("Chef: Preparing creamy Pasta!");
        }
    }
    // Concrete Commands
    public class BurgerOrder : IOrder
    {
        private Chef _chef;
        public BurgerOrder(Chef chef)
        {
            _chef = chef;
        }
        public void Execute()
        {
            _chef.PrepareBurger();
        }
    }
    public class PizzaOrder : IOrder
    {
        private Chef _chef;
        public PizzaOrder(Chef chef)
        {
            _chef = chef;
        }
        public void Execute()
        {
            _chef.PreparePizza();
        }
    }
    public class PastaOrder : IOrder
    {
        private Chef _chef;
        public PastaOrder(Chef chef)
        {
            _chef = chef;
        }
        public void Execute()
        {
            _chef.PreparePasta();
        }
    }
    // Invoker
    public class Waiter
    {
        private List<IOrder> _orderList = new List<IOrder>();
        public void TakeOrder(IOrder order)
        {
            _orderList.Add(order);
            Console.WriteLine("Waiter: Order received.");
        }
        public void PlaceOrders()
        {
            Console.WriteLine("\nWaiter: Sending orders to the chef...");
            foreach (var order in _orderList)
            {
                order.Execute();
            }
            _orderList.Clear();
        }
    }
    // Client
    class CommandPatternFoodiesDelight
    {
        static void Main()
        {
            // Receiver
            Chef chef = new Chef();
            // Commands
            IOrder burger = new BurgerOrder(chef);
            IOrder pizza = new PizzaOrder(chef);
            IOrder pasta = new PastaOrder(chef);
            // Invoker
            Waiter waiter = new Waiter();
            waiter.TakeOrder(burger);
            waiter.TakeOrder(pizza);
            waiter.TakeOrder(pasta);
            // Execute all orders
            waiter.PlaceOrders();
        }
    }
}