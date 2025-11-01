using System;
using System.Globalization;
namespace _05_Practical_work_Worker
{
    public class Worker
    {
        private string _fullName;
        private int _age;
        private double _salary;
        private DateTime _hireDate;

        public string FullName
        {
            get { return _fullName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Прізвище та ініціали не можуть бути порожніми.");
                }
                _fullName = value;
            }
        }

        public int Age
        {
            get { return _age; }
            set
            {
                if (value < 18 || value > 65)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Вік працівника має бути в межах [18, 65].");
                }
                _age = value;
            }
        }

        public double Salary
        {
            get { return _salary; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Зарплата не може бути меншою 0.");
                }
                _salary = value;
            }
        }

        public DateTime HireDate
        {
            get { return _hireDate; }
            set
            {
                if (value > DateTime.Now)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Дата прийняття на роботу не може бути в майбутньому.");
                }
                _hireDate = value;
            }
        }

        public Worker(string fullName, int age, double salary, DateTime hireDate)
        {
            FullName = fullName;
            Age = age;
            Salary = salary;
            HireDate = hireDate;
        }

        public int ExperienceYears
        {
            get
            {
                DateTime today = DateTime.Today;
                int years = today.Year - _hireDate.Year;
                if (_hireDate.Date > today.AddYears(-years))
                {
                    years--;
                }
                return years;
            }
        }

        public override string ToString()
        {
            return $"Працівник: {FullName}, Вік: {Age} років, ЗП: {Salary:C}, Працює з: {HireDate.ToShortDateString()}, Стаж роботи: {ExperienceYears} р.)";
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            CultureInfo culture = new CultureInfo("uk-UA");
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;

            const int WORKER_COUNT = 5;
            Worker[] workers = new Worker[WORKER_COUNT];

            Console.WriteLine($"--- Введіть дані для {WORKER_COUNT} працівників ---");

            for (int i = 0; i < workers.Length; i++)
            {
                bool dataIsOk = false;
                while (!dataIsOk)
                {
                    try
                    {
                        Console.WriteLine($"\nВведіть дані для працівника {i + 1}:");

                        Console.Write("Прізвище та ініціали: ");
                        string name = Console.ReadLine();

                        Console.Write("Вік: ");
                        int age = int.Parse(Console.ReadLine());

                        Console.Write("Зарплата (грн): ");
                        double salary = double.Parse(Console.ReadLine());

                        Console.Write("Дата прийняття на роботу (дд.мм.рррр): ");
                        DateTime hireDate = DateTime.Parse(Console.ReadLine());

                        workers[i] = new Worker(name, age, salary, hireDate);

                        dataIsOk = true;
                    }
                    catch (ArgumentException ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"ПОМИЛКА: {ex.Message}. Спробуйте ще раз.");
                        Console.ResetColor();
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"НЕОЧІКУВАНА ПОМИЛКА: {ex.Message}. Спробуйте ще раз.");
                        Console.ResetColor();
                    }
                }
            }
            Console.WriteLine("\n--- Перелік працівників ---");
            foreach (var worker in workers)
            {
                Console.WriteLine(worker.ToString());
            }

            int minExperience = 0;
            bool inputOk = false;
            while (!inputOk)
            {
                try
                {
                    Console.Write("\nВведіть мінімальний стаж: ");
                    minExperience = int.Parse(Console.ReadLine());
                    if (minExperience < 0)
                    {
                        Console.WriteLine("Стаж не може бути меншим 0.");
                        continue;
                    }
                    inputOk = true;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"НЕОЧІКУВАНА ПОМИЛКА: {ex.Message}. Спробуйте ще раз.");
                    Console.ResetColor();
                }
            }

            Console.WriteLine($"\n--- Працівники зі стажем більше {minExperience} років ---");
            bool found = false;
            foreach (var worker in workers)
            {
                if (worker.ExperienceYears > minExperience)
                {
                    Console.WriteLine($"{worker.FullName}, стаж: {worker.ExperienceYears} р.");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Працівники з таким стажем відсутні.");
            }

        }
    }
}
