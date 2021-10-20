using MarsRover.Business;
using MarsRover.Model;
using System;
using Xunit;

namespace MarsRover.Test
{
    public class MarsRoverTest
    {
        //Move metodu yani robotun ileri gitme iþlemi testi
        [Fact]
        public void Move_Movement_Transaction_Test()
        {
            #region Arrange
            //Kaynaklar hazýrlanýyor.
            Plato plato = new Plato();
            plato.width = 5;
            plato.height = 5;

            Robot robot = new Robot(); // test için gönderilen modelimiz
            robot.x = 1;
            robot.y = 1;
            robot.direction = "E";
            robot.movements = "MMM";
            robot.outOfArea = true;

            string expected = "41E"; // beklenen deðer

            #endregion
            #region Act
            //Ýlgili metot Arrange'de ki kaynaklarla test ediliyor.
            foreach (var movements in robot.movements)
            {
                MovementTransaction.Move(robot, plato);
            }
            string result = robot.x.ToString() + robot.y.ToString() + robot.direction; // gelen deðer

            #endregion
            #region Assert
            //Test neticesinde gelen data doðrulanýyor.
            Assert.Equal("True", robot.outOfArea.ToString()); // robot sýnýr dýþýna çýkmamýþsa
            Assert.Equal(expected, result); // robotun son konumu beklenen konum ile eþitse
            #endregion
        }

        //Right Metodu testi
        [Fact]
        public void Right_Movement_Transaction_Test()
        {
            #region Arrange
            //Kaynaklar hazýrlanýyor.
            string direction = "E"; //gönderilen yön verisi doðu

            string expected = "S"; // beklenen deðer güney

            #endregion
            #region Act
            //Ýlgili metot Arrange'de ki kaynaklarla test ediliyor.
            string result = MovementTransaction.Right(direction); // gelen deðer

            #endregion
            #region Assert
            //Test neticesinde gelen data doðrulanýyor.
            Assert.Equal(expected, result); // robotun yönü beklenen yön ile eþitse
            #endregion
        }

        //Left Metodu Testi
        [Fact]
        public void Left_Movement_Transaction_Test()
        {
            #region Arrange
            //Kaynaklar hazýrlanýyor.
            string direction = "E"; //gönderilen yön verisi doðu

            string expected = "N"; // beklenen deðer kuzey

            #endregion
            #region Act
            //Ýlgili metot Arrange'de ki kaynaklarla test ediliyor.
            string result = MovementTransaction.Left(direction); // gelen deðer

            #endregion
            #region Assert
            //Test neticesinde gelen data doðrulanýyor.
            Assert.Equal(expected, result); // robotun yönü beklenen yön ile eþitse
            #endregion
        }

        //robotun tüm hareketlerinin sonucunun testi
        [Fact]
        public void MarsRover_Movement_Transaction_Test()
        {
            #region Arrange
            //Kaynaklar hazýrlanýyor.
            Plato plato = new Plato();
            plato.width = 5;
            plato.height = 5;

            Robot robot = new Robot(); // test için gönderilen modelimiz
            robot.x = 3;
            robot.y = 3;
            robot.direction = "E";
            robot.movements = "MMRMMRMRRM";
            robot.outOfArea = true;

            string expected = "51E"; // beklenen deðer

            #endregion
            #region Act
            //Ýlgili metot Arrange'de ki kaynaklarla test ediliyor.
            Robot response = MovementTransaction.movementTransaction(robot, plato);
            string result = response.x.ToString() + response.y.ToString() + response.direction; // gelen deðer

            #endregion
            #region Assert
            //Test neticesinde gelen data doðrulanýyor.
            Assert.Equal(expected, result);
            #endregion
        }
    }
}
