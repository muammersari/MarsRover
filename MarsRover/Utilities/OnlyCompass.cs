using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Utilities
{
    public class OnlyCompass
    {
        //Sadece Yön değerleri N-E-S-W değerleri girmek için
        public static string onlyCompass()
        {
            string yesNo = "";
            ConsoleKeyInfo karakter;
            do
            {
                karakter = Console.ReadKey(true);
                //Eğer Backspace tuşuna basılmamışsa 
                if ((karakter.Key == ConsoleKey.N || karakter.Key == ConsoleKey.E || karakter.Key == ConsoleKey.S || karakter.Key == ConsoleKey.W) && yesNo.Count() == 0)
                {
                    yesNo += karakter.KeyChar.ToString().ToUpper();
                    Console.Write(karakter.KeyChar.ToString().ToUpper());
                }
                else if (karakter.Key == ConsoleKey.Backspace && yesNo.Length > 0)
                //Eğer Backspace tuşuna basılmışsa değeri siliyoruz
                {
                    yesNo = yesNo.Substring(0, (yesNo.Length - 1));
                    Console.Write("\b \b");

                }
            }
            // Enter a basıldığında döngüden çıkıyoruz
            while (karakter.Key != ConsoleKey.Enter);
            Console.WriteLine();
            return yesNo;
        }
    }
}
