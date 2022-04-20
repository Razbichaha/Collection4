using System;
using System.Collections.Generic;

namespace Collection4
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<int, string> directoryOfWorkers = new Dictionary<int, string>();

            directoryOfWorkers.Add(0, "Иванов Иван Иванович");
            directoryOfWorkers.Add(1, "Сидоров Сидр Сидорович");
            directoryOfWorkers.Add(2, "Тихонов Тихон Тихонович");
            directoryOfWorkers.Add(3, "Самсонов Самсон Самсонович");

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
        static void DeleteDossier(Dictionary<int, string> directoryOfWorkers, int correctioun)
        {
            int tempNumber;

            bool isContinueCycle = true;

            while (isContinueCycle)
            {
                Console.Write("Для удаления работника введите его номер - ");

                string inputString = Console.ReadLine();

                if (int.TryParse(inputString, out tempNumber) /*char.IsNumber(inputString, i)*/)
                {

                    tempNumber = int.Parse(inputString);

                    if (directoryOfWorkers.ContainsKey(tempNumber))
                    {
                        directoryOfWorkers.Remove(tempNumber);
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

        static void DefaultMesadge(Dictionary<int, string> directoryOfWorkers, int correctioun)
        {
            Console.Clear();
            OutputMenu();
            ShowDossier(directoryOfWorkers, correctioun);
        }

        static void ShowDossier(Dictionary<int, string> directoryOfWorkers, int correctioun)
        {
            Console.WriteLine("  " + "Фамилия Имя Отчество");

            foreach (var fullName in directoryOfWorkers)
            {
                Console.WriteLine($"{fullName.Key + correctioun} - {fullName.Value} ");
            }
        }

        static void AddDossier(Dictionary<int, string> directoryOfWorkers)
        {
            Console.Write("Введите фамилию - ");
            string lastName = Console.ReadLine();
            Console.Write("Введите имя - ");
            string name = Console.ReadLine();
            Console.Write("Введите отчество - ");
            string patronymic = Console.ReadLine();

            string tempString = lastName + " " + name + " " + patronymic;

            directoryOfWorkers.Add(directoryOfWorkers.Count, tempString);
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
