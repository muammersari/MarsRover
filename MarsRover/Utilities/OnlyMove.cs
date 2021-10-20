using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Utilities
{
    public class OnlyMove
    {
        public static string onlyMove()
        {
            //Sadece R - L - M karakterlerini girmek için
            string movements = "";
            ConsoleKeyInfo karakter;
            do
            {
                karakter = Console.ReadKey(true);
                //Eğer Backspace tuşuna basılmamışsa 
                if (karakter.Key == ConsoleKey.R || karakter.Key == ConsoleKey.L || karakter.Key == ConsoleKey.M)
                {
                    movements += karakter.KeyChar.ToString().ToUpper();
                    Console.Write(karakter.KeyChar.ToString().ToUpper());
                }
                else if (karakter.Key == ConsoleKey.Backspace && movements.Length > 0)
                //Eğer Backspace tuşuna basılmışsa değeri siliyoruz
                {
                    movements = movements.Substring(0, (movements.Length - 1));
                    Console.Write("\b \b");

                }
            }
            // Enter a basıldığında döngüden çıkıyoruz
            while (karakter.Key != ConsoleKey.Enter);
            Console.WriteLine();
            return movements;
        }
    }
}
