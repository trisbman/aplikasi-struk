using System;

namespace aplikasi_struk
{
    class Store
    {
        public static string Name = "Dimsum Xpress Medan";
        public static string CashierName = new string[] { "Charles", "Felia", "Calista", "Jacqueline", "Ricky" }[new Random().Next(0, 4)];
        public static string Address = "Jl. Brigjend Katamso";

        // Order id config
        private static int Code = 123456;
        private static string Prefix = "FF";

        public static string GetCode()
        {
            return Prefix + Code;
        }
    }
}
