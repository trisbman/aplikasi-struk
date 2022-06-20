using System;

namespace aplikasi_struk
{
    class Page
    {
        #region Constructor
        private int Width;
        private string Title;

        public Page(string title = "Toko Keren")
        {
            Console.Title = title; Title = title;
        }
        public Page(string title = "Toko Keren", int pageWidth = 40)
        {
            Console.Title = title; Width = pageWidth;
            if (OperatingSystem.IsWindows()) Console.SetWindowSize(Width, Console.WindowHeight); // only on windows
        }
        #endregion

        public int TopMargin = 3;
        private void ClearLine()
        {            
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }
        private void ClearLine(int n)
        {
            int m = Console.GetCursorPosition().Top - n - 1;
            for (int i = 0; i < m + 2; i++) ClearLine();
            ScrollToTop();
            Console.SetCursorPosition(0, n);
        }

        public void ScrollToTop()
        {
            Console.SetCursorPosition(0, 0);
        }
        public void Clear()
        {
            ClearLine(TopMargin);
        }

        #region Writer
        public void WriteTitle(string text)
        {
            Console.SetCursorPosition(0, 0);
            int lineLength = Width;
            int spaceLength = (lineLength - text.Length) / 2;
            Line.Draw(lineLength);
            Console.WriteLine(new string(' ', spaceLength) + text + new string(' ', spaceLength));
            Line.Draw(lineLength);
        }
        private void WriteTitle(string text, bool restorePosition)
        {
            int lastYPos = Console.GetCursorPosition().Top;
            WriteTitle(text);
            if (restorePosition)
            {
                Console.SetCursorPosition(0, lastYPos);
            }
        }
        public void ChangeTitle(string text)
        {
            WriteTitle(text, true);
        }

        public void CreateList(string[] options)
        {
            for (int i = 0; i < options.Length; i++)
            {
                WriteLine(i + 1 + ". " + options[i]);
            }
        }

        // Specific method
        public void CreateCategoryList(Category[] categories)
        {
            for (int i = 0; i < categories.Length; i++)
            {
                WriteLine(i + 1 + ". " + categories[i].Name);
            }
        }
        public void CreateDishList(Dish[] dishes)
        {
            // TODO: make multi page instead of a long single page
            for (int i = 0; i < dishes.Length; i++)
            {
                WriteLine(i + 1 + ". " + dishes[i].Name);
            }
        }
        public void CreatePMList(PaymentMethod[] paymentMethods)
        {
            for (int i = 0; i < paymentMethods.Length; i++)
            {
                WriteLine(i + 1 + ". " + paymentMethods[i].Name);
            }
        }
        public void CreateOIList(Order.OrderItem[] orderItems)
        {
            for (int i = 0; i < orderItems.Length; i++)
            {
                Write(i + 1 + ". " + orderItems[i].Dish.Name);
                if (orderItems[i].Note != null)
                    WriteLine(" (catatan: " + orderItems[i].Note + ")");
                else
                    WriteLine("");
            }
        }


        public string AskInput(string question)
        {
            Write(question);
            string input = Console.ReadLine();
            return input;
        }
        public string AskInput(string question, int aLength)
        {
            Write($"{question} [1-{aLength}]: ");
            string input = Console.ReadLine();
            return input;
        }
        public void AskConfirmation(string msg = "Tekan Enter untuk melanjutkan")
        {
            Console.WriteLine(msg);
            Console.ReadKey();
        }

        public void Loading(int interval = 500, int n = 3)
        {
            for (int i = 0; i < n; i++)
            {
                Write(".");
                Pause(interval);
            }
        }

        private void Pause(int duration = 500)
        {
            System.Threading.Thread.Sleep(duration);
        }

        private void Write(string text)
        {
            Console.Write(text);
        }
        private void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
        #endregion
    }
}
