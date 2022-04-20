using System;
using System.Collections.Generic;

namespace Collection4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> directoryOfWorkers = new List<string>();

            directoryOfWorkers.Add("Иванов Иван Иванович");
            directoryOfWorkers.Add("Сидоров Сидр Сидорович");
            directoryOfWorkers.Add("Тихонов Тихон Тихонович");
            directoryOfWorkers.Add("Самсонов Самсон Самсонович");

            int correctioun = 1;

            Console.Clear();
            OutputMenu();

            bool isContinueProgram = true;

            while (isContinueProgram)
            {
                string menu = Console.ReadLine();

                switch (menu)
                {
                    case "добавить":

                        AddDossier(directoryOfWorkers);

                        break;
                    case "вывести":

                        ShowDossier(directoryOfWorkers, correctioun);

                        break;
                    case "удалить":

                        DeleteDossier(directoryOfWorkers, correctioun);

                        break;
                    case "закрыть":

                        isContinueProgram = false;

                        break;
                    default:

                        DefaultMesadge(directoryOfWorkers, correctioun);

                        break;
                }
            }
        }
        static void DeleteDossier(List<string> directoryOfWorkers, int correctioun)
        {
            int tempNumber;

            bool isContinueCycle = true;

            while (isContinueCycle)
            {
                Console.Write("Для удаления работника введите его номер - ");

                string inputString = Console.ReadLine();

                if (int.TryParse(inputString, out tempNumber))
                {
                    tempNumber = int.Parse(inputString);
                    tempNumber -= correctioun;

                    if (directoryOfWorkers.Count > tempNumber)
                    {
                        directoryOfWorkers.RemoveAt(tempNumber);
                        isContinueCycle = false;
                    }
                    else
                    {
                        Console.WriteLine("Вы ввели не корректный номер");
                        inputString = "";
                    }
                }
                else
                {
                    inputString = "";
                    Console.Write("Для указания работника используйте только номер ");
                    Console.WriteLine();
                }
            }
            DefaultMesadge(directoryOfWorkers, correctioun);
        }

        static void DefaultMesadge(List<string> directoryOfWorkers, int correctioun)
        {
            Console.Clear();
            OutputMenu();
            ShowDossier(directoryOfWorkers, correctioun);
        }

        static void ShowDossier(List<string> directoryOfWorkers, int correctioun)
        {
            Console.WriteLine("   " + "Фамилия Имя Отчество");

            int iteration = correctioun;

            foreach (var fullName in directoryOfWorkers)
            {
                Console.WriteLine($"{iteration} - {fullName} ");
                iteration++;
            }
        }

        static void AddDossier(List<string> directoryOfWorkers)
        {
            Console.Write("Введите фамилию - ");
            string lastName = Console.ReadLine();
            Console.Write("Введите имя - ");
            string name = Console.ReadLine();
            Console.Write("Введите отчество - ");
            string patronymic = Console.ReadLine();

            string tempString = lastName + " " + name + " " + patronymic;
            directoryOfWorkers.Add(tempString);
        }

        static void OutputMenu()
        {
            Console.WriteLine("Для вывода данных работника наберите       - вывести");
            Console.WriteLine("Для добавления даных работника наберите    - добавить");
            Console.WriteLine("Удаления работника из базы данных наберите - удалить");
            Console.WriteLine("Для закрыти программы наберите             - закрыть");
        }
    }
}
