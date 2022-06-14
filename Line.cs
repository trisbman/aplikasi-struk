using System;

namespace aplikasi_struk
{
    class Line
    {
        static char DefaultChar = '=';
        public static void Draw()
        {
            int n = 20;
            Console.WriteLine(new string(DefaultChar, n));
        }
        public static void Draw(int n)
        {
            Console.WriteLine(new string(DefaultChar, n));
        }
        public static void Draw(char karakter, int n)
        {
            Console.WriteLine(new string(karakter, n));
        }
    }
}
