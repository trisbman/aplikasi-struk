using System;

namespace aplikasi_struk
{
    class Program
    {
        static Page page;

        static void HandleCategory(Dish[] dishes, Order.OrderItem orderItem)
        {
            Console.WriteLine("Pilihan yang tersedia: ");
            page.CreateDishList(dishes);
            int dishIndex = int.Parse(page.AskInput("Masukkan pilihan", dishes.Length)) - 1;
            orderItem.DishList.Add(dishes[dishIndex]);
            int len = orderItem.DishList.ToArray().Length;

            Console.WriteLine();
            Console.WriteLine(orderItem.DishList[len - 1].Name + " telah ditambahkan ke pesanan!");
            Console.Write("Tekan Enter untuk melanjutkan");
            Console.ReadLine();

        }
        static void Main(string[] args)
        {
            page = new Page("Dimsum Xpress", 50);
            page.WriteTitle("Selamat Datang di Dimsum Xpress Medan");
            Customer customer = new(page.AskInput("Silakan masukkan nama Anda: "));

            page.ChangeTitle("Hi " + customer.Name + "! Silakan pilih menu di bawah ini ya");
            page.Clear();

            Order order = new();
            Order.OrderItem orderItem = order.NewItem();

            string msg = "Mau pesan apa?"; bool fired = false; // config
            bool repeat = true;
            do
            {
                page.Clear();
                Console.WriteLine(msg);
                if (fired) Console.WriteLine("0. Selesai");
                page.CreateCategoryList(Menu.Categories);
                int categoryId = int.Parse(page.AskInput("Masukkan pilihan", Menu.Categories.Length)) - 1;
                Console.WriteLine();
                if (categoryId == -1) repeat = false;
                else HandleCategory(Menu.Categories[categoryId].Dishes, orderItem);

                msg = "Ingin pesan lagi?"; fired = true; // config            
            } while (repeat);

            page.Clear();


            page.ChangeTitle("Konfirmasi Pesanan Anda");
            Console.WriteLine("Daftar pesanan Anda: ");
            page.CreateDishList(orderItem.DishList.ToArray());
            Console.Write("Lanjutkan? [y/n]: ");
            bool confirmed = Console.ReadLine().ToLower() == "y";
            if (confirmed)
            {
                Console.Write("Sedang memproses pesanan Anda");
                page.Loading();
            }

            // Tudabes: handle inputan `confirmed` selain "y"
            // JQ: Bikin output pesanan (lanjutan kodingan ini)
            // FGS: Input Menu di `Menu.cs` (sekarang itu asal2an)
            // C: Bikin fitur catatan hehehe

            Console.ReadLine();
            Console.ReadKey();
        }
    }
}
