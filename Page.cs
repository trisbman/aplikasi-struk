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
            Console.SetWindowSize(Width, Console.WindowHeight); // only on windows
        }
        #endregion

        private void ClearLine()
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }
        public void Clear()
        {
            ClearLine(3);
        }
        private void ClearLine(int n)
        {
            int m = Console.GetCursorPosition().Top - n - 1;
            for (int i = 0; i < m + 2; i++) ClearLine();
            Console.SetCursorPosition(0, n);
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
        public string AskInput(string question)
        {
            Write(question);
            string input = Console.ReadLine();
            return input;
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
