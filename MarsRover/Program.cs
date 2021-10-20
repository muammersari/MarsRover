using MarsRover.Business;
using MarsRover.Model;
using MarsRover.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Program
    {
        public static List<Robot> robots = new List<Robot>();
        public static Plato plato = new Plato();

        public static void Main(string[] args)
        {
            //program ilk çalıştığında kullanıcıdan plato ve robotlarla ilgili bilgileri almak için AddData metodunu çalıştırıyoruz.
            AddData();

            Console.WriteLine("\n\nPlato Alanı : " + plato.width + " " + plato.height);
            int count = 1;
            // Bu döngüde robotların bilgileri yazdırılıyor.
            foreach (var robot in robots)
            {
                Console.WriteLine("---------------------------------------------------\n");
                Console.WriteLine(count + ". Robotun Verileri\n");
                Console.WriteLine("Robot Konumu : " + robot.x + " " + robot.y + " " + robot.direction);
                Console.WriteLine("Robot Hareketleri : " + robot.movements);
                count++;
            }

            //Bu döngüde robotlar sırayla hareket işlemleri için Business klasörü altındaki movementTransaction fonksiyonuna gönderiliyor.
            foreach (var robot in robots)
            {
                var response = MovementTransaction.movementTransaction(robot, plato);
            }

            count = 1;
            Console.WriteLine("---------------------------------------------------\n");

            // Bu döngüde robotların son konumları sırasıyla yazdırılıyor.
            foreach (var robot in robots)
            {
                if (robot.outOfArea == false)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(count + ". Robotun Son Konumu : " + robot.x + " " + robot.y + " " + robot.direction + "\n");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(count + ". Robot Plato Sınırları Dışına Çıkarak Uzayın Karanlık Boşluğunda Kayıplara Karıştı\n\tKendisinden Şu Ana Kadar Haber Alınamadı. Aramaya Devam Ediyoruz !!! \n");
                }

                count++;
            }
            Console.ReadLine();
        }

        public static void AddData()
        {
            string platoWidth = "";
            int count = 1;
            //Plato genişliğini alıyoruz
            do
            {
                Console.Write("Plato Genişliği(birim) : ");
                platoWidth = OnlyNumber.onlyNumber();

            } while (platoWidth == ""); // Değer boş ise soruyu tekrar sor

            plato.width = int.Parse(platoWidth);

            string platoHeight = "";
            //Plato yüksekliğini alıyoruz
            do
            {
                Console.Write("Plato Yüksekliği(birim) : ");
                platoHeight = OnlyNumber.onlyNumber();

            } while (platoHeight == "");

            plato.height = int.Parse(platoHeight);

            string newAddRobot = "E";

            while (newAddRobot == "E" || newAddRobot == "e")
            {
                Robot robot = new Robot();
                robot.outOfArea = false;

                Console.WriteLine("\n---> " + count + ". Robotun Değerlerini Giriniz <---");
                Console.WriteLine("");

                string x = "", y = "", direction = "", hareketler = "";

                //Gezicinin x konumunu alıyoruz
                do
                {
                    Console.Write("Gezicinin X Konumunu Giriniz : ");
                    x = OnlyNumber.onlyNumber();

                } while (x == ""); // Değer boş ise soruyu tekrar sor

                robot.x = int.Parse(x);

                //Gezicinin y konumunu alıyoruz
                do
                {
                    Console.Write("Gezicinin Y Konumunu Giriniz : ");
                    y = OnlyNumber.onlyNumber();

                } while (y == ""); // Değer boş ise soruyu tekrar sor

                robot.y = int.Parse(y);

                //Gezicinin yönünü alıyoruz
                do
                {
                    Console.Write("Gezicinin Yönünü Giriniz(N(north)-E(east)-S(south)-W(west)) : ");
                    direction = OnlyCompass.onlyCompass();

                } while (direction == ""); // Değer boş ise soruyu tekrar sor

                robot.direction = direction;

                //Gezicinin hareketlerini alıyoruz
                do
                {
                    Console.Write("Gezicinin Hareketlerini Giriniz(R(right)-L(left)-M(move)) : ");
                    hareketler = OnlyMove.onlyMove();

                } while (hareketler == ""); // Değer boş ise soruyu tekrar sor

                robot.movements = hareketler;

                robots.Add(robot);
                //Yeni Gezici Eklenecek mi soruyoruz. Evet ise yeni gezici ekliyoruz
                do
                {
                    Console.Write("\nYeni Gezici Eklemek İster misiniz ?(E(evet) / H(hayır)) : ");
                    newAddRobot = OnlyYesNo.onlyYesNo();

                } while (newAddRobot == ""); // Değer boş ise soruyu tekrar sor
                count++;
                Console.WriteLine("\n\n- - - - - - - - - - - - - - - - - - - - - - - - - - - - ");

            }
        }
    }
}
