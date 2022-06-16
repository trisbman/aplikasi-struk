using System;
using System.Collections.Generic;

namespace aplikasi_struk
{
    class Order
    {
        private int Id;
        private DateTime DateTime;
        public OrderItem NewItem()
        {
            return new OrderItem();
        }
        public class OrderItem
        {
            private int Id;
            public List<Dish> DishList = new();
            public string Note;
            public PaymentMethod paymentMethod;

            public OrderItem()
            {

            }

            //public Dish MainDish;
            //public AddOn AddOn;
            //public Beverage Beverage;
            //public Other Other;
        }
    }
}
