using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* В задаче не использовать циклы for, while. Все действия по обработке данных выполнять с использованием LINQ
 * 
 * На вход подается строка, состоящая из целых чисел типа int, разделенных одним или несколькими пробелами.
 * Необходимо отфильтровать полученные коллекцию, оставив только отрицательные или четные числа.
 * Дважды вывести коллекцию, разделив элементы специальным символом.
 * Остальные указания см. непосредственно в коде!
 * 
 * Пример входных данных:
 * 1 2 3 4 5
 * 
 * Пример выходных:
 * 2:4
 * 2*4
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
 * 
 */

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTesk01();
        }

        public static void RunTesk01()
        {
            try
            {
                int[] arr = null;
                try
                {
                    // Считывание массива, состоящего из целых чисел
                    arr = Array.ConvertAll((Console.ReadLine().Split(new[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries)), x => int.Parse(x));
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

                // Использован синтаксис запросов
                IEnumerable<int> arrQuery = from a in arr where a < 0 || a % 2 == 0 select a;


                // Использован синтаксис методов
                IEnumerable<int> arrMethod = arr.Where(a => a < 0 || a % 2 == 0);

                try
                {
                    // Вывод результатов
                    PrintEnumerableCollection<int>(arrQuery, ":");
                    PrintEnumerableCollection<int>(arrMethod, "*");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("ArgumentNullException");
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

        // Попробуйте осуществить вывод элементов коллекции с учетом разделителя, записав это ОДНИМ ВЫРАЖЕНИЕМ.
        // P.S. Есть два способа, оставьте тот, в котором применяется LINQ...
        public static void PrintEnumerableCollection<T>(IEnumerable<T> collection, string separator)
        {
            Console.WriteLine(collection.Select(el => el.ToString())
                        .Aggregate((a, b) => a.ToString() + separator + b.ToString()));
        }
    }
}
