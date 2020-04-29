using System;
using System.Collections.Generic;
using System.Linq;

/*Все действия по обработке данных выполнять с использованием LINQ
 * 
 * Объявите перечисление Manufacturer, состоящее из элементов
 * Dell (код производителя - 0), Asus (1), Apple (2), Microsoft (3).
 * 
 * Обратите внимание на класс ComputerInfo, он содержит поле типа Manufacturer
 * 
 * На вход подается число N.
 * На следующих N строках через пробел записана информация о компьютере: 
 * фамилия владельца, код производителя (от 0 до 3) и год выпуска (в диапазоне 1970-2020).
 * Затем с помощью средств LINQ двумя разными способами (как запрос или через методы)
 * отсортируйте коллекцию следующим образом:
 * 1. Первоочередно объекты ComputerInfo сортируются по фамилии владельца в убывающем порядке
 * 2. Для объектов, у которых фамилии владельцев сопадают, 
 * сортировка идет по названию компании производителя (НЕ по коду) в возрастающем порядке.
 * 3. Если совпадают и фамилия, и имя производителя, то сортировать по году выпуска в порядке возрастания.
 * 
 * Выведите элементы каждой коллекции на экран в формате:
 * <Фамилия_владельца>: <Имя_производителя> [<Год_производства>]
 * 
 * Пример ввода:
 * 3
 * Ivanov 1970 0
 * Ivanov 1971 0
 * Ivanov 1970 1
 * 
 * Пример вывода:
 * Ivanov: Asus [1970]
 * Ivanov: Dell [1971]
 * Ivanov: Dell [1970]
 * 
 * Ivanov: Asus [1970]
 * Ivanov: Dell [1971]
 * Ivanov: Dell [1970]
 * 
 * 
 *  * Обрабатывайте возможные исключения путем вывода на экран типа этого исключения 
 * (не использовать GetType(), пишите тип руками).
 * Например, 
 *          catch (SomeException)
            {
                Console.WriteLine("SomeException");
            }
 * При некорректных входных данных (не связанных с созданием объекта) выбрасывайте FormatException
 * При невозможности создать объект класса ComputerInfo выбрасывайте ArgumentException!
 */
namespace Task03
{
    class Program
    {
        static void Main()
        {
            try
            {
                int N;
                List<ComputerInfo> computerInfoList = new List<ComputerInfo>();
                try
                {
                    N = int.Parse(Console.ReadLine());

                    for (int i = 0; i < N; i++)
                    {
                        var data = Console.ReadLine().Split(new[] { ' ' },
                            StringSplitOptions.RemoveEmptyEntries);
                        computerInfoList.Add(new ComputerInfo(data[0], int.Parse(data[1]),
                            (Manufacturer)(int.Parse(data[2]))));
                    }
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("ArgumentNullException");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("ArgumentException");
                }
                catch (FormatException)
                {
                    Console.WriteLine("FormatException");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("OverflowExcepion");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("IndexOutOfRangeException");
                }

                try
                {
                    // выполните сортировку одним выражением
                    var computerInfoQuery = from c in computerInfoList
                                            orderby c.Year descending
                                            orderby c.ComputerManufacturer.ToString() ascending
                                            orderby c.Owner descending
                                            select c;


                    PrintCollectionInOneLine(computerInfoQuery);
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("ArgumentNullException");
                }
                Console.WriteLine();

                try
                {
                    // выполните сортировку одним выражением
                    var computerInfoMethods = computerInfoList.OrderByDescending(x => x.Year)
                        .OrderBy(x => x.ComputerManufacturer.ToString()).
                        OrderByDescending(x => x.Owner);

                    PrintCollectionInOneLine(computerInfoMethods);
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("ArgumentNullException");
                }
            }
            catch (Exception)
            {
                //Console.WriteLine("Exception");
            }
        }

        // выведите элементы коллекции на экран с помощью кода, состоящего из одной линии (должна быть одна точка с запятой)
        public static void PrintCollectionInOneLine(IEnumerable<ComputerInfo> collection)
        {
            Console.WriteLine(collection.Select(el => el.ToString())
                         .Aggregate((a, b) => a.ToString() + "\n" + b.ToString()));
        }
    }


    class ComputerInfo
    {
        public ComputerInfo(string owner, int year, Manufacturer computerManufacturer)
        {
            if (year < 1970 || year > 2020)
                throw new ArgumentOutOfRangeException();
            if (computerManufacturer < Manufacturer.Dell || computerManufacturer > Manufacturer.Microsoft)
                throw new ArgumentOutOfRangeException();

            Year = year;
            Owner = owner;
            ComputerManufacturer = computerManufacturer;
        }

        public int Year { get; set; }
        public string Owner { get; set; }
        public Manufacturer ComputerManufacturer { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: {1} [{2}]", Owner, ComputerManufacturer, Year);
        }

    }
    enum Manufacturer
    {
        Dell = 0,
        Asus = 1,
        Apple = 2,
        Microsoft = 3
    }
}
