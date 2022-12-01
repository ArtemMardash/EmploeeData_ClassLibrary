using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EmploeeData_ClassLibrary
{
    public struct Files
    {
        #region Поле
        /// <summary>
        /// Massive which saved all data about emploee
        /// </summary>
        private Emploee[] emploees;

        /// <summary>
        /// Massive of titles
        /// </summary>
        private string[] titlesOfFile;

        /// <summary>
        /// Index Emploee in Array
        /// </summary>
        private int indexEmploeeInArray;

        /// <summary>
        /// Adress of file which have all data
        /// </summary>
        private string adressOfFile;

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor of class File
        /// </summary>
        /// <param name="adressOfFile"> Adress of file</param>
        /// <param name="emploees">Massive of emploee</param>
        /// <param name="indexEmploeeInArray">Index of emploee in Massive</param>
        /// <param name="titlesifFile">Massive of titles</param>
        public Files(string adressOfFile)
        {
            this.adressOfFile = adressOfFile;
            this.emploees = new Emploee[1];
            titlesOfFile = new string[7];
            indexEmploeeInArray = 0;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Method which clear the array
        /// </summary>
        /// <param name="emploees">array which we clear in this method</param>
        /// <returns></returns>
        /// TODO: Сделать метод void и убрать Return
        public int CleanArray(Emploee[] emploees)
        {
            emploees = new Emploee[1];
            indexEmploeeInArray = 0;
            return emploees.Length;
        }
        /// <summary>
        /// Method which add emploee to array 
        /// </summary>
        /// <param name="newEmploee"></param>
        /// <returns></returns>
        /// TODO: Сделать метод void и убрать Return
        public int AddEmploeeInArray(Emploee newEmploee, Emploee[] emploee)
        {
            ReSizeEmploeeArray(indexEmploeeInArray >= emploee.Length, emploee);
            emploee[indexEmploeeInArray] = newEmploee;
            indexEmploeeInArray++;
            return indexEmploeeInArray;
        }
        
        /// <summary>
        /// Method to increase array for 2 times
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        /// TODO: Сделать Void
        public int ReSizeEmploeeArray(bool label, Emploee[] emploee)
        {
            if (label)
            {
                Array.Resize(ref emploee, emploee.Length * 2);
            }
            return emploee.Length;
        }
        /// <summary>
        /// Check for Int variable 
        /// </summary>
        /// <param name="output"></param>
        /// <param name="inputInt"></param>
        /// <returns></returns>
        public bool CheckData(string output, ref int inputInt)
        {
            bool flag = false;
            while (flag == false)
            {
                Console.WriteLine($"Write {output}");
                string input = (Console.ReadLine());
                bool key = int.TryParse(input, out inputInt);
                if (key == false)
                {
                    Console.WriteLine("Try again");
                }
                else
                {
                    flag = true;
                }
            }
            return flag;
        }
        /// <summary>
        /// Check for DateTime variable
        /// </summary>
        /// <param name="output"></param>
        /// <param name="inputDateTime"></param>
        /// <returns></returns>
        public bool CheckDataForDateTime(string output, ref DateTime inputDateTime)
        {
            bool flag = false;
            while (flag == false)
            {
                Console.WriteLine($"Write {output}");
                string input = (Console.ReadLine());
                bool key = DateTime.TryParse(input, out inputDateTime);
                if (key == false)
                {
                    Console.WriteLine("Try again");
                }
                else
                {
                    flag = true;
                }
            }
            return flag;
        }
        /// <summary>
        /// Не понял как сделать с перемеными типа string
        /// </summary>
        /// <param name="newEmploee"></param>
        /// <returns></returns>
        public string InputData(Emploee newEmploee)
        {
            int age = 0;
            CheckData("Age of Emploee", ref age);
            newEmploee.Age = age;
            int idEmploee = 0;
            CheckData("Id of Emploee", ref idEmploee);
            newEmploee.IdEmploee = idEmploee;
            int height = 0;
            CheckData("Height of Emploee", ref height);
            newEmploee.Heigth = height;
            string fulName = "";
            newEmploee.FullName = fulName;
            DateTime dateOfCreate = DateTime.Now;
            CheckDataForDateTime("Date of Create", ref dateOfCreate);
            newEmploee.DateOfCreate = dateOfCreate;
            DateTime dOB = DateTime.Now;
            CheckDataForDateTime("Date of Birth", ref dOB);
            newEmploee.DOB = dOB;
        }
        public string ArrayOutput()
        {
            Console.WriteLine($"{titlesOfFile[0], 5} " +
                $"{titlesOfFile[1],15} " +
                $"{titlesOfFile[2], 35} " +
                $"{titlesOfFile[3],3} " +
                $"{titlesOfFile[4],3} " +
                $"{titlesOfFile[5], 15} " +
                $"{titlesOfFile[6], 20}");
            for(int i = 0; i> emploees.Length-1; i++)
            {
                Console.WriteLine(emploees[i].ShowInfoAboutEmploee());  
            }
            return "Array on display";
        }
        public string DeleteElementInArray()
        {
            for (int i = 0; i<emploees.Length-1; i++)
            {
                Console.WriteLine("Do you want to delete this array element?(Answer must be yes or no)");
                string ans = Console.ReadLine();
                if(ans == "yes")
                {
                    Array.Clear(emploees, i, i);
                }
            }
            return "element of Array has deleted";
        }
        /// <summary>
        /// Запись первой строки в файле
        /// </summary>
        /// <param name="forRecord">Строка для записи</param>
        /// 
        public string WriteTitle(string forRecord)
        {
            try
            {
                if (!string.IsNullOrEmpty(forRecord))
                {
                    using (StreamWriter sw = new StreamWriter(adressOfFile, append: false))
                    {
                        sw.WriteLine(forRecord);
                        return forRecord;
                    }
                }
                else
                    return "заголовок не может быть пустым";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// Дозапись в файл
        /// </summary>0
        /// <param name="forRecord">Строка для записи</param>
        /// 
        public string Write(string forRecord)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(adressOfFile, append: true))
                {
                    sw.WriteLine(forRecord);
                    return "данные дозаписаны";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        /// <summary>
        /// Метод для чтения всего файла
        /// </summary>
        /// <param name="address"></param>
        private void Reader(string address)
        {
            try
            {
                CleanArray(emploees);
                using (StreamReader sr = new StreamReader(address))
                {
                    titlesOfFile = sr.ReadLine().Split('#');

                    while (!sr.EndOfStream)
                    {
                        string[] arg = sr.ReadLine().Split('#');
                        AddEmploeeInArray(new Emploee(
                            Convert.ToInt32(arg[0]),
                            Convert.ToDateTime(arg[1]),
                            arg[2],
                            Convert.ToInt32(arg[3]),
                            Convert.ToInt32(arg[4]),
                            Convert.ToDateTime(arg[5]),
                            arg[6]),
                            emploees
                            );
                    }
                    Console.WriteLine("Файл успешно прочитан.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Метод для редактирования данных по ID сотрудника
        /// </summary>
        /// TODO: сделать метод void, убрать return
        public string Edit(int id, Emploee[] employees)
        {
            try
            {
                Reader(adressOfFile);
                bool checkParse;
                string input;
                string result = "Файл не отредактирован. Такой ID отсутствует";
                for (int i = 0; i < employees.Length; i++)
                {
                    if (employees[i].IdEmploee == id)
                    {
                        Console.WriteLine("Введите новые ФИО сотрудника или нажмите enter для перехода к следующему параметру:");
                        input = Console.ReadLine();
                        if (!string.IsNullOrEmpty(input)) employees[i].FullName = input;

                        Console.WriteLine();
                        Console.WriteLine("Введите возраст сотрудника или нажмите enter для перехода к следующему параметру: ");
                        input = Console.ReadLine();
                        byte number;
                        checkParse = byte.TryParse(input, out number);
                        if (!string.IsNullOrEmpty(input) && checkParse) employees[i].Age = number;

                        Console.WriteLine();
                        Console.WriteLine("Введите рост сотрудника или нажмите enter для перехода к следующему параметру: ");
                        input = Console.ReadLine();
                        checkParse = byte.TryParse(input, out number);
                        if (!string.IsNullOrEmpty(input) && checkParse) employees[i].Heigth = number;

                        Console.WriteLine();
                        Console.WriteLine("Введите дату рождения сотрудника или нажмите enter для перехода к следующему параметру: ");
                        input = Console.ReadLine();
                        DateTime date;
                        checkParse = DateTime.TryParse(input, out date);
                        if (!string.IsNullOrEmpty(input) && checkParse) employees[i].DOB = date;

                        Console.WriteLine();
                        Console.WriteLine("Введите место рождения сотрудника или нажмите enter для завершения редактирования: ");
                        input = Console.ReadLine();
                        if (!string.IsNullOrEmpty(input)) employees[i].PlaceOfBirth = input;

                        result = "Файл успешно отредактирован.";
                        Console.WriteLine();
                    }
                }

                ReWrite(indexEmploeeInArray);
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        /// <summary>
        /// Используется для дозаписи отредактированного файла
        /// </summary>
        private void ReWrite(int count)
        {
            string forRecord = "ID#Дата добавления записи#ФИО сотрудника#Возраст#Рост#Дата рождения#Место рождения";
            WriteTitle(forRecord);

            forRecord = "";
            for (int i = 0; i < count; i++)
            {
                forRecord = string.Empty;
                forRecord = $"{emploees[i].IdEmploee + "#" + emploees[i].DateOfCreate + "#" + emploees[i].FullName + "#" + emploees[i].Age + "#" + emploees[i].Heigth + "#" + emploees[i].DOB + "#" + emploees[i].PlaceOfBirth}";

                Write(forRecord);
            }
            Console.WriteLine();
        }

        #endregion
    }
}
