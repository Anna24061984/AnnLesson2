using System;
using System.Text.RegularExpressions;

namespace AnnLesson2
{
    public static class AnnLesson2_1
    {
        public static void Task()
        {
            int minCount = 3;
            int maxCount = 7;
            double[] massiv = new double[maxCount];

            Console.WriteLine($"Введите от {minCount} до {maxCount} чисел, разделенных пробелами. По окончанию ввода нажмите Enter.");
            string input = Console.ReadLine();

            string[] inputToMas = new Regex(@"\s+").Replace(input, " ").Split(' ');                         //заменили несколько пробелов на один и собрали массив 
            if (inputToMas.Length < minCount || inputToMas.Length > maxCount)
                throw new Exception($"Количество введенных чисел должно быть от {minCount} до {maxCount}.");

            int cnt = 0;
            double result = 0;
            for (int i = 0; i < inputToMas.Length; i++)
            {
                try
                {
                    massiv[i] = double.Parse(inputToMas[i]);
                    cnt++;                                      //если не попали в ошибку, значит попали в число и можно увеличить счетчик
                    result += massiv[i];                        //ну и можно сразу собирать результат
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка преобразования значения '{inputToMas[i]}' в число: {ex}.");
                }
            }

            try
            {
                result = 1.0 * result / cnt;
                if (result is double.NaN)
                    throw new ArithmeticException("Результат - NaN");                                   //поскольку чисел может не быть, обработаем NaN
                Console.WriteLine($"Среднее арифметическое введенных чисел равно {result}.");           //независимо от возможной ошибки при вводе все таки посчитаем среднее арифметическое имеющихся чисел
            }
            catch (Exception ex)
            {
                Console.WriteLine($"При вычислении среднего арифметического возникла ошибка: {ex}");    //кажется, сюда мы так и не зайдем...
            }

            Console.ReadKey();
        }
    }
}
