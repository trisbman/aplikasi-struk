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
        public Beverage(int Id, string Name, int Price) : base(Id, Name, Price)
        {

        }
    }

    class Other : Dish
    {
        public Other(int Id, string Name, int Price) : base(Id, Name, Price)
        {

        }
    }
    class Category
    {
        public string Name { get; }
        public Dish[] Dishes { get; }
        public Category(Dish[] dishes, string name)
        {
            Name = name;
            Dishes = dishes;
        }
    }

    class Menu
    {
        public static Dish[] MainDishes =
        {
            new Dish(1001, "Pau Ayam Steam", 20800),
            new Dish(1002, "Sio Mai Ayam", 21900),
            new Dish(1003, "Sio Mai Rumput Laut", 26300),
            new Dish(1004, "Sio Mai Jala-Jala", 21900),
            new Dish(1005, "Sio Mai Udang", 21900),
            new Dish(1006, "Sio Mai Kepiting", 21900),
            new Dish(1007, "Kaki Ayam Saus Tiram", 21900),
            new Dish(1008, "Ha Kaou Kepiting", 30700),
            new Dish(1009, "Ha Kaou Udang", 30700),
            new Dish(1010, "Lumpia Udang Kit Tahu", 30700),
            new Dish(1011, "Hatosi Rambutan", 26300),
            new Dish(1012, "Leng Hong Kien", 20700),
            new Dish(1013, "Pangsit Udang Mayo", 30700),
            new Dish(1014, "Kwotiek", 47200),
            new Dish(1015, "Lumpia Udang Salad", 26300),
            new Dish(1016, "Lumpia Ayam Rumput Laut", 21900),
            new Dish(1017, "Ca Kue Isi Special", 21900),
            new Dish(1018, "Lobak Ebi", 21900)
        };

        public static Beverage[] Beverages =
        {
            new Beverage(3001, "Liang Teh 5 Rasa", 14200),
            new Beverage(3002, "Orange Juice", 19700),
            new Beverage(3003, "Ice Milk Tea", 19700),
            new Beverage(3004, "Ice Lime Juice", 14200),
            new Beverage(3005, "Lemon Tea", 14200),
            new Beverage(3006, "Ice Green Tea", 19700),
            new Beverage(3007, "Ice Jelly Lychee Tea", 17500),
            new Beverage(3008, "Ice Jelly Coco Pandan", 14200),
            new Beverage(3009, "Ice Jelly Java Tea", 14200),
            new Beverage(3010, "Ice Tea Bunga", 14200),
            new Beverage(3011, "Air Mineral", 5999)
        };

        public static Other[] Others =
        {
            new Other(7001, "Lapis Medan", 9600),
            new Other(7002, "Puding Special", 13100),
            new Other(7002, "Puding Kelapa Thai", 3000),
            new Other(7002, "Pancake Avocado", 15700),
            new Other(7002, "Pancake Durian", 18500),
            new Other(7002, "Tako Ala Thai", 1200),
            new Other(7002, "Puding Sunkist", 45000)
        };

        public static Category[] Categories = {
            new Category(MainDishes, "Makanan"),
            new Category(Beverages, "Minuman"),
            new Category(Others, "Lain-lain")
        };
    }
}
