using System;
using System.Text.RegularExpressions;

namespace AnnLesson2
{
    public static class AnnLesson2_2
    {
        public static void Task()
        {
            int masRows = 5;
            int masColumns = 6;
            string[,] mas = new string[masRows, masColumns];
            Console.WriteLine(
                $"Введите данные о пользователях.\n" +
                $"Количество пользователей не более {masRows}.\n" +
                $"Количество слов в ФИО не более {masColumns}, слова разделены пробелами).\n" +
                $"Ввод строки заканчивается Enter. Если данных больше нет, нажмите еще один Enter.\n");

            int totalUsers;
            for (totalUsers = 0; totalUsers < masRows; totalUsers++)
            {
                string str = Console.ReadLine();
                if (str == "")
                {
                    break;
                }
                else
                {
                    string[] nameParts = new Regex(@"\s+").Replace(str, " ").Split(' ');
                    for (int j = 0; j < nameParts.Length && j < masColumns; j++)
                    {
                        mas[totalUsers, j] = nameParts[j];
                    }
                }
            }
            Console.WriteLine("Введите порядковый номер пользователя, данные о котором нужно вывести, начиная с 1.");
            try
            {
                int userNumber = int.Parse(Console.ReadLine());
                if (userNumber < 1)
                {
                    Console.WriteLine($"Число {userNumber} не может быть порядковым номером.");
                }
                else if (userNumber > totalUsers)
                {
                    Console.WriteLine($"Отсутствуют данные о пользователе с порядковым номером {userNumber}.");
                }
                else
                {
                    for (int j = 0; j < masColumns; j++)
                    {
                        if (mas[userNumber - 1, j] != null && mas[userNumber - 1, j].Length > 0)
                        {
                            Console.Write($"{mas[userNumber - 1, j]} ");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Не удалось прочитать число: {ex.Message}");
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
