using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Utilities
{
    public class OnlyYesNo
    {
        //Sadece E ve H karakterleri girmek için 
        public static string onlyYesNo()
        {
            string yesNo = "";
            ConsoleKeyInfo karakter;
            do
            {
                karakter = Console.ReadKey(true);
                //Eğer Backspace tuşuna basılmamışsa 
                if ((karakter.Key == ConsoleKey.E || karakter.Key == ConsoleKey.H) && yesNo.Count() == 0)
                {
                    yesNo += karakter.KeyChar;
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
            return yesNo;
        }

    }
}
