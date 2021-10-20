using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Utilities
{
    public class OnlyNumber
    {
        //Sadece sayı değeri girmek için
        public static string onlyNumber()
        {
            string result = "";
            ConsoleKeyInfo karakter;
            do
            {
                karakter = Console.ReadKey(true);
                //Eğer Backspace tuşuna basılmamışsa 

                if (karakter.Key != ConsoleKey.Backspace)
                {
                    double val = 0;
                    //Klavyeden okunan değerin sayı olup olmadığını kontrol ediyoruz
                    //Diğer karakterin yanına ekliyoruz..
                    bool kontrol = double.TryParse(karakter.KeyChar.ToString(), out val);
                    if (kontrol)
                    {
                        result += karakter.KeyChar;
                        Console.Write(karakter.KeyChar);
                    }
                }
                else
                //Eğer Backspace tuşuna basılmışsa sayıyı siliyoruz
                {
                    if (karakter.Key == ConsoleKey.Backspace && result.Length > 0)
                    {
                        result = result.Substring(0, (result.Length - 1));
                        Console.Write("\b \b");
                    }
                }
            }
            // Enter a basıldığında döngüden çıkıyoruz
            while (karakter.Key != ConsoleKey.Enter);
            Console.WriteLine();
         
            return result;
        }



    }
}
