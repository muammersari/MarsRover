using MarsRover.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Business
{
    public class MovementTransaction //Hareket İşlemleri
    {
        //Bu metotda bir robotun sırasıyla hareketleri geziliyor.
        public static Robot movementTransaction(Robot robot, Plato plato)
        {
            foreach (var movement in robot.movements)
            {
                switch (movement.ToString())
                {
                    case "M": // robotun hareketi M yani ileri ise
                        robot = Move(robot, plato);
                        break;

                    case "R": // robotun hareketi R yani sağa dön ise
                        robot.direction = Right(robot.direction);
                        break;

                    case "L": // Robotun hareketi L yani sola dön ise
                        robot.direction = Left(robot.direction);
                        break;
                }
            }
            return robot;
        }

        // Bu metotda robot ileri hareket ettiğinde yönüne göre konumu 1 ilerisi olarak güncelleniyor
        public static Robot Move(Robot robot, Plato plato)
        {
            switch (robot.direction)
            {
                case "N": // robotun yönü N yani kuzey ise y eksenin de 1 yukarıya gidiyor
                    if ((robot.y + 1) >= 0 && (robot.y + 1) <= plato.height)
                        robot.y += 1;
                    else
                        robot.outOfArea = true; //robot sınır dışına çıktı

                    break;

                case "E": // robotun yönü E yani doğu ise x eksenin de 1 sağa gidiyor
                    if ((robot.x + 1) >= 0 && (robot.x + 1) <= plato.width)
                        robot.x += 1;
                    else
                        robot.outOfArea = true; //robot sınır dışına çıktı

                    break;

                case "S": // robotun yönü S yani güney ise y eksenin de 1 aşağıya gidiyor
                    if ((robot.y - 1) >= 0 && (robot.y - 1) <= plato.height)
                        robot.y -= 1;
                    else
                        robot.outOfArea = true; //robot sınır dışına çıktı

                    break;

                case "W": // robotun yönü W yani batı ise x eksenin de 1 sola gidiyor
                    if ((robot.x - 1) >= 0 && (robot.x - 1) <= plato.height)
                        robot.x -= 1;
                    else
                        robot.outOfArea = true; //robot sınır dışına çıktı

                    break;

            }
            return robot;
        }

        //Bu metotda robotun hareketi sağa dön ise yönüne göre güncelleme yapılıyor
        public static string Right(string direction)
        {
            string requestDirection = "";
            switch (direction)
            {
                case "N": // robotun yönü N yani kuzey ise doğuya döndürülüyor
                    requestDirection = "E";
                    break;

                case "E": // robotun yönü E yani doğu ise güneye döndürülüyor
                    requestDirection = "S";
                    break;

                case "S": // robotun yönü S yani güney ise batıya döndürülüyor
                    requestDirection = "W";
                    break;

                case "W": // robotun yönü W yani batı ise kuzeye döndürülüyor
                    requestDirection = "N";
                    break;
            }
            return requestDirection;
        }

        //Bu metotda robotun hareketi sola dön ise yönüne göre güncelleme yapılıyor
        public static string Left(string direction)
        {
            string requestDirection = "";
            switch (direction)
            {
                case "N": // robotun yönü N yani kuzey ise batıya döndürülüyor
                    requestDirection = "W";
                    break;

                case "E": // robotun yönü E yani doğu ise kuzeye döndürülüyor
                    requestDirection = "N";
                    break;

                case "S": // robotun yönü S yani güney ise doğuya döndürülüyor
                    requestDirection = "E";
                    break;

                case "W": // robotun yönü W yani batı ise güneye döndürülüyor
                    requestDirection = "S";
                    break;
            }
            return requestDirection;
        }



    }
}
