using System;

namespace aplikasi_struk
{
    class Menu
    {
        public static string[] Category = { "Makanan", "Minuman", "Lain-lain" };
    }
    class Program
    {

        static Page page;

        static void Main(string[] args)
        {
            page = new Page("Dimsum Xpress", 50);
            page.WriteTitle("Selamat Datang di Dimsum Xpress Medan");



            Console.ReadKey();
        }
    }
}
