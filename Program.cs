using System;

namespace aplikasi_struk
{
    class Program
    {
        class Menu
        {
            public static string[] Category = { "Makanan", "Minuman", "Lain-lain" };
        }

        static Page page;

        static void Main(string[] args)
        {
            page = new Page("Dimsum Xpress", 50);
            page.WriteTitle("Selamat Datang di Dimsum Xpress Medan");

            

            Console.ReadKey();
        }
    }
}
