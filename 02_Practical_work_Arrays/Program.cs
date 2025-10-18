using System;

namespace _2_Practical_work_Arrays
{
    internal class Program
    {
        static Random rand = new Random();

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Оберіть завдання:");
                Console.WriteLine("1. Задання 1");
                Console.WriteLine("2. Завдання 2");
                Console.WriteLine("3. Завдання 3");
                Console.WriteLine("0. Вихід");
                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Task1();
                }
                else if (choice == "2")
                {
                    Task2();
                }
                else if (choice == "3")
                {
                    Task3();
                }
                else if (choice == "0")
                {
                    Console.WriteLine("Вихід з програми.");
                    break;
                }
                else
                {
                    Console.WriteLine("Введіть коректне значення");
                }

                Console.WriteLine("\nНатисніть будь-яку клавішу, щоб повернутись до меню");
                Console.ReadKey();
            }
        }

        static void Task1()
        {
            Console.WriteLine("\n--- Завдання 1: ---");

            int[] array = new int[15];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(1, 26);
            }

            int evenCount = 0;
            int oddCount = 0;

            Console.Write("Масив: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + "  ");
            }
            Console.WriteLine();

            foreach (int number in array)
            {
                if (number % 2 == 0)
                {
                    evenCount++;
                }
                else
                {
                    oddCount++;
                }
            }

            int uniqueCount = 0;

            for (int i = 0; i < array.Length; i++)
            {
                bool isDuplicate = false;
                for (int j = 0; j < i; j++)
                {
                    if (array[i] == array[j])
                    {
                        isDuplicate = true;
                        break;
                    }
                }
                if (!isDuplicate)
                {
                    uniqueCount++;
                }
            }

            Console.WriteLine($"Кількість парних елементів: {evenCount}");
            Console.WriteLine($"Кількість непарних елементів: {oddCount}");
            Console.WriteLine($"Кількість унікальних елементів: {uniqueCount}");
        }

        static void Task2()
        {
            Console.WriteLine("\n--- Завдання 2 ---");

            int[] array = new int[20];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(1, 101);
            }

            Console.Write("Масив: ");

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();

            Console.Write("Введіть число для порівняння: ");

            int userValue;
            if (!int.TryParse(Console.ReadLine(), out userValue))
            {
                Console.WriteLine("Введіть число.");
                return;
            }

            int lessThanCount = 0;
            foreach (int number in array)
            {
                if (number < userValue)
                {
                    lessThanCount++;
                }
            }
            Console.WriteLine($"Кількість значень у масиві, менших ніж {userValue}: {lessThanCount}");
        }

        static void Task3()
        {
            Console.WriteLine("\n--- Завдання 3 ---");

            int[] A = new int[5];
            double[,] B = new double[3, 4];

            Console.WriteLine("\nВведіть 5 цілих чисел для масиву A:");
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write($"Елемент {i + 1}: ");
                while (!int.TryParse(Console.ReadLine(), out A[i]))
                {
                    Console.Write("Введіть ціле число: ");
                }
            }

            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    double randomValue = rand.NextDouble() * 100;
                    B[i, j] = Math.Round(randomValue, 2);
                }
            }

            Console.Write("\nМасив A: ");
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write(A[i] + "\t");
            }
            Console.WriteLine();

            Console.WriteLine("\nМасив B:");
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    Console.Write($"{B[i, j],8} \t");
                }
                Console.WriteLine();
            }

            double maxElement = A[0];
            double minElement = A[0];
            double totalSum = 0;
            double totalProduct = 1;
            int sumEvenA = 0;
            double sumOddColsB = 0;

            foreach (int value in A)
            {
                totalSum += value;
                totalProduct *= value;
                if (value > maxElement) maxElement = value;
                if (value < minElement) minElement = value;
                if (value % 2 == 0)
                {
                    sumEvenA += value;
                }
            }

            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    double value = B[i, j];
                    totalSum += value;
                    totalProduct *= value;
                    if (value > maxElement) maxElement = value;
                    if (value < minElement) minElement = value;
                    if (j % 2 != 0)
                    {
                        sumOddColsB += value;
                    }
                }
            }
            Console.WriteLine("\n--- Результати обчислень ---");
            Console.WriteLine($"Загальний максимальний елемент: {maxElement}");
            Console.WriteLine($"Загальний мінімальний елемент: {minElement}");
            Console.WriteLine($"Загальна сума всіх елементів: {Math.Round(totalSum, 2)}");
            Console.WriteLine($"Загальний добуток всіх елементів: {totalProduct}");
            Console.WriteLine($"Сума парних елементів масиву А: {sumEvenA}");
            Console.WriteLine($"Сума елементів непарних стовпців масиву В: {Math.Round(sumOddColsB, 2)}");
        }
    }
}

