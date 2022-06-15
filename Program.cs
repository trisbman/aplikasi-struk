using System;

namespace aplikasi_struk
{
    struct Order
    {
        private int Id;
        public int[] MealId;
        private DateTime DateTime;
    }
    class Program
    {
        static Page page;
        static void Main(string[] args)
        {
            page = new Page("Dimsum Xpress", 50);
            page.WriteTitle("Selamat Datang di Dimsum Xpress Medan");

            page.CreateList(Menu.Category);
            int categoryIndex = page.AskInput("Masukkan pilihan : ") - 1;
            Console.WriteLine("Pilihan Anda : " + Menu.Category[categoryIndex]);
            
            Console.ReadLine();
            page.Clear();


            Console.ReadKey();
        }
    }
}
