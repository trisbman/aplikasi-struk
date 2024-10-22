﻿using System;
using System.Collections.Generic;

namespace aplikasi_struk
{
    class Order
    {
        private int Id;
        private int LastItemId = 0;
        private int Total = 0;
        private DateTime DateTime;
        public List<OrderItem> ItemList = new();

        public PaymentMethod paymentMethod;

        public OrderItem NewItem()
        {
            OrderItem orderItem = new OrderItem(LastItemId + 1);
            ItemList.Add(orderItem);
            return orderItem;
        }

        public int GetTotal()
        {
            foreach (var item in ItemList)
            {
                Total += item.Dish.Price;
            }

            return Total;
        }

        public class OrderItem
        {
            public string Note;
            public Dish Dish;
            public int Id;

            public OrderItem(int id)
            {
                Id = id;
            }

            //public Dish MainDish;
            //public AddOn AddOn;
            //public Beverage Beverage;
            //public Other Other;
        }
    }
}
