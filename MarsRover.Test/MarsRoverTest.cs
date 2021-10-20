using MarsRover.Business;
using MarsRover.Model;
using System;
using Xunit;

namespace MarsRover.Test
{
    public class MarsRoverTest
    {
        //Move metodu yani robotun ileri gitme i�lemi testi
        [Fact]
        public void Move_Movement_Transaction_Test()
        {
            #region Arrange
            //Kaynaklar haz�rlan�yor.
            Plato plato = new Plato();
            plato.width = 5;
            plato.height = 5;

            Robot robot = new Robot(); // test i�in g�nderilen modelimiz
            robot.x = 1;
            robot.y = 1;
            robot.direction = "E";
            robot.movements = "MMM";
            robot.outOfArea = true;

            string expected = "41E"; // beklenen de�er

            #endregion
            #region Act
            //�lgili metot Arrange'de ki kaynaklarla test ediliyor.
            foreach (var movements in robot.movements)
            {
                MovementTransaction.Move(robot, plato);
            }
            string result = robot.x.ToString() + robot.y.ToString() + robot.direction; // gelen de�er

            #endregion
            #region Assert
            //Test neticesinde gelen data do�rulan�yor.
            Assert.Equal("True", robot.outOfArea.ToString()); // robot s�n�r d���na ��kmam��sa
            Assert.Equal(expected, result); // robotun son konumu beklenen konum ile e�itse
            #endregion
        }

        //Right Metodu testi
        [Fact]
        public void Right_Movement_Transaction_Test()
        {
            #region Arrange
            //Kaynaklar haz�rlan�yor.
            string direction = "E"; //g�nderilen y�n verisi do�u

            string expected = "S"; // beklenen de�er g�ney

            #endregion
            #region Act
            //�lgili metot Arrange'de ki kaynaklarla test ediliyor.
            string result = MovementTransaction.Right(direction); // gelen de�er

            #endregion
            #region Assert
            //Test neticesinde gelen data do�rulan�yor.
            Assert.Equal(expected, result); // robotun y�n� beklenen y�n ile e�itse
            #endregion
        }

        //Left Metodu Testi
        [Fact]
        public void Left_Movement_Transaction_Test()
        {
            #region Arrange
            //Kaynaklar haz�rlan�yor.
            string direction = "E"; //g�nderilen y�n verisi do�u

            string expected = "N"; // beklenen de�er kuzey

            #endregion
            #region Act
            //�lgili metot Arrange'de ki kaynaklarla test ediliyor.
            string result = MovementTransaction.Left(direction); // gelen de�er

            #endregion
            #region Assert
            //Test neticesinde gelen data do�rulan�yor.
            Assert.Equal(expected, result); // robotun y�n� beklenen y�n ile e�itse
            #endregion
        }

        //robotun t�m hareketlerinin sonucunun testi
        [Fact]
        public void MarsRover_Movement_Transaction_Test()
        {
            #region Arrange
            //Kaynaklar haz�rlan�yor.
            Plato plato = new Plato();
            plato.width = 5;
            plato.height = 5;

            Robot robot = new Robot(); // test i�in g�nderilen modelimiz
            robot.x = 3;
            robot.y = 3;
            robot.direction = "E";
            robot.movements = "MMRMMRMRRM";
            robot.outOfArea = true;

            string expected = "51E"; // beklenen de�er

            #endregion
            #region Act
            //�lgili metot Arrange'de ki kaynaklarla test ediliyor.
            Robot response = MovementTransaction.movementTransaction(robot, plato);
            string result = response.x.ToString() + response.y.ToString() + response.direction; // gelen de�er

            #endregion
            #region Assert
            //Test neticesinde gelen data do�rulan�yor.
            Assert.Equal(expected, result);
            #endregion
        }
    }
}
