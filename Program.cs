using System;

namespace aplikasi_struk
{
    class Program
    {
        // variables
        static Page page;
        static readonly PaymentMethod[] paymentMethod = PaymentMethods.Default;

        class Handler
        {
            static void HandleAddOn(AddOn addOn, Order.OrderItem orderItem)
            {

            }
            static void HandleDish(Dish dish, Order.OrderItem orderItem)
            {
                orderItem.Dish = dish;

                Console.WriteLine();
                Console.WriteLine(dish.Name + " telah ditambahkan ke pesanan ke-" + orderItem.Id + "!");

                if (dish.GetType().IsAssignableFrom((new Dish(0, "", 0)).GetType()))
                {
                    bool repeat = true;
                    do
                    {
                    } while (!repeat);
                }

                page.AskConfirm();

            }
            public static void HandleCategory(Dish[] dishes, Order.OrderItem orderItem)
            {
                Console.WriteLine("Pilihan yang tersedia: ");
                page.CreateDishList(dishes);
                int dishIndex = int.Parse(page.AskInput("Masukkan pilihan", dishes.Length)) - 1;
                HandleDish(dishes[dishIndex], orderItem);

            }

            public static void HandlePayment(PaymentMethod paymentMethod, Order order)
            {
                order.paymentMethod = paymentMethod;
                Console.WriteLine(paymentMethod.Name + " telah dipilih sebagai metode pembayaran!");
                page.AskConfirm();
            }
        }

        static void Main(string[] args)
        {
        #region start
        mulai:
            page = new Page(Store.Name, 50);
            page.WriteTitle(Store.Name);
            Customer customer = new(page.AskInput("Silakan masukkan nama pelanggan: "));
        #endregion

        #region order
        pesan:
            page.Clear();

            Order order = new();

            // config
            bool fired = false;
            int i = 1;
            string msg = "Pilih kategori pesanan ke-" + i.ToString();
            bool repeat = true;
            do
            {
                page.Clear();
                Console.WriteLine(msg);
                if (fired) Console.WriteLine("0. Selesai");
                page.CreateCategoryList(Menu.Categories);
                int categoryId = int.Parse(page.AskInput("Masukkan pilihan", Menu.Categories.Length)) - 1;
                Console.WriteLine();
                if (categoryId == -1)
                {
                    repeat = false;
                }
                else
                {
                    Order.OrderItem orderItem = order.NewItem();
                    // TODO: extract other handler from end of each handler and use it here instead
                    Handler.HandleCategory(Menu.Categories[categoryId].Dishes, orderItem);
                }

                // config            
                i++;
                msg = "Pilih kategori pesanan ke-" + i;
                fired = true;
            } while (repeat);
        #endregion

        #region confirmation
        konfirmasi:
            page.Clear();

            Console.WriteLine("Daftar pesanan: ");
            page.CreateOIList(order.ItemList.ToArray());
            Console.Write("Lanjutkan? [y/n]: ");
            string lanjut = Console.ReadLine().ToLower();

            if (lanjut == "y")
            {
                Console.Write("Sedang memproses pesanan Anda");
                page.Loading();
            }
            else if (lanjut == "n")
            {
                Console.Write("Ingin mengulang pemesanan? [y/n] : ");
                string ulang = Console.ReadLine().ToLower();
                if (ulang == "y")
                {
                    Console.Write("Sedang mengulang pemesanan anda");
                    page.Loading();
                    goto pesan;
                }
                else if (ulang == "n")
                {
                    Console.Write("Terima kasih");
                    page.Loading();
                    Console.Clear();
                    goto mulai;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("INPUTAN ANDA TIDAK VALID!\nSILAHKAN KONFIRMASI ULANG");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    page.AskConfirm();
                    goto konfirmasi;
                }

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("INPUTAN ANDA TIDAK VALID!\nSILAHKAN KONFIRMASI ULANG");
                Console.ForegroundColor = ConsoleColor.Gray;
                page.AskConfirm();
                goto konfirmasi;
            }
            #endregion

            page.Clear();
            Console.WriteLine("Pilih metode pembayaran:");
            page.CreatePMList(paymentMethod);
            int pmId = int.Parse(page.AskInput("Masukkan pilihan", paymentMethod.Length)) - 1;
            Handler.HandlePayment(paymentMethod[pmId], order);


            // JQ: Bikin output pesanan (lanjutan kodingan ini)
            // C: Bikin fitur catatan hehehe

            Console.ReadLine();
            Console.ReadKey();
        }
    }
}
