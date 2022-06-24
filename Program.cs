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
            static void HandleAddOn(AddOn addOn, Order.OrderItem orderItem)
            {

            }
            public static void HandleDish(Dish dish, Order.OrderItem orderItem)
            {
                orderItem.Dish = dish;
            }
            public static void HandleNote(string note, Order.OrderItem orderItem)
            {
                orderItem.Note = note;
            }

            public static void HandlePayment(PaymentMethod paymentMethod, Order order)
            {
                order.paymentMethod = paymentMethod;
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

                    Dish[] dishes = Menu.Categories[categoryId].Dishes;
                    Console.WriteLine("Pilihan yang tersedia: ");
                    page.CreateDishList(dishes);
                    int dishIndex = int.Parse(page.AskInput("Masukkan pilihan", dishes.Length)) - 1;
                    Dish dish = dishes[dishIndex];
                    Handler.HandleDish(dish, orderItem);


                    if (dish.GetType().IsAssignableFrom((new Dish(0, "", 0)).GetType()))
                    {
                        bool repeatAddOn = true;
                        do
                        {
                            // FGS: HandleAddOn()
                        } while (!repeatAddOn);
                    }

                    string note = page.AskInput("Catatan (kosongkan jika tidak ada): ");
                    bool isNote = Convert.ToBoolean(note.Length);
                    if (isNote) Handler.HandleNote(note, orderItem);

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

            // JQ + Tudabes: Bikin output pesanan (lanjutan kodingan ini)
            page.Clear();
            Console.WriteLine();
            Console.WriteLine(new string(' ',14)+Store.Address);
            Console.WriteLine(new string('-', 50));
            Console.WriteLine();
            Console.Write("Tanggal Pembelian   ");
            Console.WriteLine(new string(' ',9)+DateTime.Now.ToString("dd/MM/yyyy   hh:mm tt"));
            Console.Write("ID Pembelian        ");
            Console.WriteLine(new string(' ', 9));
            //perlu id pesanan
            Console.Write("Nama kasir          ");
            Console.WriteLine(new string(' ', 9)+Store.CashierName);
            Console.Write("Nama pelanggan      ");
            Console.WriteLine(new string(' ', 9)+customer.Name);
            Console.WriteLine(new string('-', 50));
            //daftar pesanan dengan harga, catatan
            Console.WriteLine(new string('-', 50));
            Console.Write("Total               ");
            Console.WriteLine();
            //perlu masukan total
            Console.WriteLine(new string('-', 50));
            Console.Write("Pembayaran          ");
            Console.WriteLine(new string(' ', 9));
            //perlu jenis pembayaran


            Console.ReadLine();
            Console.ReadKey();
        }
    }
}
