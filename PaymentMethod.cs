namespace aplikasi_struk
{
    class PaymentMethod
    {
        public int Id { get; }
        public string Name { get; }
        public int Fee { get; }
        public PaymentMethod(int id, string name, int fee)
        {
            Id = id;
            Name = name;
            Fee = fee;
        }
    }
    class Emoney : PaymentMethod
    {
        static int ProcessedId;
        public Emoney(int id, string name, int fee) : base(ProcessedId, name, fee)
        {
            ProcessedId = int.Parse("9" + id.ToString());
        }
    }

    class PaymentMethods
    {
        public static PaymentMethod[] Default =
        {
            new PaymentMethod(9000, "Cash", 0),
            new Emoney(9001, "Gopay", 2),
            new Emoney(9002, "Dana", 2),
            new Emoney(9003, "ShopeePay", 4),
        };

    }
}
