using System;
using System.Collections;
using System.Linq;

/* В задаче не использовать циклы for, while. Все действия по обработке данных выполнять с использованием LINQ
 * 
 * На вход подается строка, состоящая из целых чисел типа int, разделенных одним или несколькими пробелами.
 * Необходимо оставить только те элементы коллекции, которые предшествуют нулю, или все, если нуля нет.
 * Дважды вывести среднее арифметическое квадратов элементов новой последовательности.
 * Вывести элементы коллекции через пробел.
 * Остальные указания см. непосредственно в коде.
 * 
 * Пример входных данных:
 * 1 2 0 4 5
 * 
 * Пример выходных:
 * 2,500
 * 2,500
 * 1 2
 * 
 * Обрабатывайте возможные исключения путем вывода на экран типа этого исключения 
 * (не использовать GetType(), пишите тип руками).
 * Например, 
 *          catch (SomeException)
            {
                Console.WriteLine("SomeException");
            }
 * В случае возникновения иных нештатных ситуаций (например, в случае попытки итерирования по пустой коллекции) 
 * выбрасывайте InvalidOperationException!
 */
namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTesk02();
        }

        public static void RunTesk02()
        {
            try
            {
                int[] arr = null;
                try
                {
                    // Считывание целочисленного массива
                    arr = Array.ConvertAll(Console.ReadLine().Split(new[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries), x => int.Parse(x));
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("ArgumentNullException");
                }
                catch (FormatException)
                {
                    Console.WriteLine("FormatException");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("OverflowException");
                }

                // Выюираем элементы до 0, если 0 есть.
                var filteredCollection = arr.Where(a => Array.IndexOf(arr, 0) > Array.IndexOf(arr, a) || Array.IndexOf(arr, 0) == -1);

                try
                {

                    // использовать статическую форму вызова метода подсчета среднего
                    double averageUsingStaticForm = Enumerable.Average(filteredCollection, x => checked(x * x));

                    // использовать объектную форму вызова метода подсчета среднего
                    double averageUsingInstanceForm = filteredCollection.Average(a => checked(a * a));

                    // Выводим среднее значение
                    Console.WriteLine(string.Format("{0:F3}", averageUsingStaticForm).Replace('.',','));
                    Console.WriteLine(string.Format("{0:F3}", averageUsingInstanceForm).Replace('.', ','));

                    // вывести элементы коллекции в одну строку
                    Console.WriteLine(filteredCollection.Select(el => el.ToString())
                         .Aggregate((a, b) => a.ToString() + " " + b.ToString()));
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("ArgumentNullExcpetion");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("OverflowException");
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("InvalidOperationException");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Exception");
            }
        }
        
    }
}
