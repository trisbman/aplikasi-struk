namespace aplikasi_struk
{
    class Dish
    {
        public int Id { get; }
        public string Name { get; }
        public int Price { get; }
        public Dish(int id, string name, int price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
    class Beverage : Dish
    {
        public Beverage(int Id, string BaseString, int Price) : base(Id, BaseString, Price)
        {

        }
    }

    class AddOn : Dish
    {
        public AddOn(int Id, string BaseString, int Price) : base(Id, BaseString, Price)
        {

        }
    }
    class Menu
    {
        public static string[] Category = {
            "Makanan",
            "Minuman",
            "Lain-lain"
        };

        public static Dish[] MainDishes =
        {
            new Dish(1001, "Apple", 10000),
            new Dish(1002, "Orange", 20000),
        };

        public static AddOn[] AddOns =
        {
            new AddOn(2001, "Udang", 5000),
            new AddOn(2002, "Bakso", 2500)
        };

        public static Beverage[] Beverages =
        {
            new Beverage(3001, "Fanta", 15000),
            new Beverage(3002, "Susu", 12500)
        };
    }
}
