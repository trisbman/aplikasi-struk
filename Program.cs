using System;

namespace aplikasi_struk
{
    class Program
    {
        // variables
        static Page page;
        static readonly PaymentMethod[] paymentMethods = PaymentMethods.Default;

        class Handler
        {
            public static void HandleDish(Dish dish, Order.OrderItem orderItem)
            {
                orderItem.Dish = dish;
            }
            public static void HandlePayment(PaymentMethod paymentMethod, Order order)
            {
                order.paymentMethod = paymentMethod;
            }
        }

        static void CreateInvoice(Customer customer, Order order)
        {
            page.Clear();

            Console.WriteLine();
            Console.WriteLine(new string(' ', 14) + Store.Address);
            Line.Draw('-', 50);
            Console.WriteLine();

            Console.Write("Waktu Pembelian");
            page.WriteFrom(DateTime.Now.ToString("dd/MM/yyyy   hh:mm tt"));

            Console.Write("ID Pembelian");
            page.WriteFrom(Store.GetCode());

            Console.Write("Nama kasir");
            page.WriteFrom(Store.CashierName);

            Console.Write("Nama pelanggan");
            page.WriteFrom(customer.Name);

            Console.WriteLine();
            Line.Draw('-', 50);

            Order.OrderItem[] orderItems = order.ItemList.ToArray();
            for (int i = 0; i < orderItems.Length; i++)
            {
                Console.Write(i + 1 + ". " + orderItems[i].Dish.Name);
                page.WriteFrom(page.FormatInt(orderItems[i].Dish.Price));
                Line.Draw(' ', 20);

                Console.WriteLine();
            }

            Console.Write("Total");
            page.WriteFrom(page.FormatInt(order.GetTotal()));
            Line.Draw('-', 50);
            Console.Write("Pembayaran");
            page.WriteFrom(order.paymentMethod.Name);


            page.Break();
            int duration = 5 + order.ItemList.Count * 5;
            Timer timer = new("Program akan tutup otomatis dalam", duration);
            timer.Start();
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

                    Dish[] dishes = Menu.Categories[categoryId].Dishes;
                    Console.WriteLine("Pilihan yang tersedia: ");
                    page.CreateDishList(dishes);
                    int dishIndex = int.Parse(page.AskInput("Masukkan pilihan", dishes.Length)) - 1;
                    Dish dish = dishes[dishIndex];
                    Handler.HandleDish(dish, orderItem);

                    Console.WriteLine();
                    Console.WriteLine(dish.Name + " telah ditambahkan ke pesanan ke-" + orderItem.Id + "!");
                    page.AskConfirmation();
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
            // TODO: y/n are the English options, how about Indonesian? 
            Console.Write("Lanjutkan? [y/n]: ");
            string lanjut = Console.ReadLine().ToLower();

            if (lanjut == "y")
            {
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
                    page.AskConfirmation();
                    goto konfirmasi;
                }

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("INPUTAN ANDA TIDAK VALID!\nSILAHKAN KONFIRMASI ULANG");
                Console.ResetColor();
                page.AskConfirmation();
                goto konfirmasi;
            }
            #endregion

            page.Clear();
            Console.WriteLine("Pilih metode pembayaran:");
            page.CreatePMList(paymentMethods);
            int pmIndex = int.Parse(page.AskInput("Masukkan pilihan", paymentMethods.Length)) - 1;
            PaymentMethod paymentMethod = paymentMethods[pmIndex];
            Handler.HandlePayment(paymentMethod, order);
            Console.WriteLine(paymentMethod.Name + " telah dipilih sebagai metode pembayaran!");
            page.AskConfirmation();

            CreateInvoice(customer, order);

            Console.ReadKey();
        }
    }
}
