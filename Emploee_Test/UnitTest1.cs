using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EmploeeData_ClassLibrary;
namespace Emploee_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ShowInfoAboutEmploee_12345_Now_ArtemMardakhaev_19_180_DateOfBirth_place()
        {
            int id = 12345;
            DateTime dateOfCreate = DateTime.Now;
            string FulName = "Artem Mardakhaev";
            int age = 19;
            int height = 180;
            DateTime DOB = DateTime.Now;
            string Place = "Moscow";

            string Expected = $"{id,5} {dateOfCreate,15} {FulName,35} {age,3} {height,3} {DOB,15} {Place,20}";
            Emploee emploee = new Emploee(id, dateOfCreate, FulName, age, height, DOB, Place);
            string actual = emploee.ShowInfoAboutEmploee();
            Assert.AreEqual(Expected, actual);
        }
        [TestMethod]
        public void CleanArray_0_1()
        {
            Emploee[] worker = new Emploee[1];
            Files file = new Files("1.txt");

            int expected = 1;
            int actual = file.CleanArray(worker);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CleanArray_5_1()
        {
            Emploee[] worker1 = new Emploee[5];
            Files file = new Files("1.txt");

            int expected = 1;
            int actual = file.CleanArray(worker1);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ReSizeEmploeeArray_true_5_return_10()
        {
            Emploee[] emploee = new Emploee[5];
            Files file = new Files("1.txt");

            int expected = 10;
            int actual = file.ReSizeEmploeeArray(true, emploee);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ReSizeEmploeeArray_false_5_return_5()
        {
            Emploee[] emploee = new Emploee[5];
            Files file = new Files("1.txt");

            int expected = 5;
            int actual = file.ReSizeEmploeeArray(false, emploee);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AddEmploeeInArray_0_1()
        {
            Emploee[] emploee = new Emploee[1];
            Files file = new Files("1.txt");

            int expected = 1;
            int actual = file.AddEmploeeInArray(new Emploee(
                12345,
                DateTime.Now,
                "Test test",
                20,
                180,
                DateTime.Now.AddYears(-20),
                "Moscow"), emploee);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddEmploeeInArray_4_5()
        {
            Emploee[] emploee = new Emploee[5];
            Files file = new Files("txt");

            int expected = 5;

            for(int i = 0; i < 4; i++)
            {
                file.AddEmploeeInArray(new Emploee(
                    123 + i,
                    DateTime.Now,
                    "Unit Test" + i,
                    20 + 1,
                    175 + i,
                    DateTime.Now.AddYears(-20 - i),
                    "Test"),emploee);
            }
            int actual = file.AddEmploeeInArray(new Emploee(
                12345,
                DateTime.Today,
                "Test Test",
                25,
                180,
                DateTime.Now.AddYears(-25),
                "Moscow"), emploee);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AddEmploeeInArray_5_And_return_6()
        {
            Emploee[] emploee = new Emploee[15];
            Files file = new Files("txt");

            int expected =6;

            for (int i = 0; i < 5; i++)
            {
                file.AddEmploeeInArray(new Emploee(
                    123 + i,
                    DateTime.Now,
                    "Unit Test" + i,
                    20 + 1,
                    175 + i,
                    DateTime.Now.AddYears(-20 - i),
                    "Test"), emploee);
            }
            int actual = file.AddEmploeeInArray(new Emploee(
                12345,
                DateTime.Today,
                "Test Test",
                25,
                180,
                DateTime.Now.AddYears(-25),
                "Moscow"), emploee);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WriteTitle_emptyTitle_return_emptyTitle()
        {
            Files file = new Files("txt");
            string expected = "заголовок не может быть пустым";

            string actual = file.WriteTitle(null);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WriteTitle_emptyTitle_and_Address_return_emptyTitle()
        {
            Files file = new Files();
            string expected = "заголовок не может быть пустым";

            string actual = file.WriteTitle(null);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void WriteTitle_emptyAddress_return_excpeteon()
        {
            Files file = new Files();
            string expected = "Значение не может быть неопределенным.\r\nИмя параметра: path";

            string actual = file.WriteTitle("Title");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WriteTitle_Title1_return_Title1()
        {
            Files file = new Files("txt");
            string expected = "Title 1";
            string actual = file.WriteTitle("Title 1");

            Assert.AreEqual(expected, actual);
        }
    }
}
