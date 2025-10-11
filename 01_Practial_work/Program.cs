namespace _1_Practical_work
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Select a task:");
                Console.WriteLine("1 - Quote");
                Console.WriteLine("2 - Sum");
                Console.WriteLine("3 - Reverse");
                Console.WriteLine("0 - Quit");

                Console.Write("Your choice: ");
                string choice = Console.ReadLine()!;

                if (choice == "1")
                {
                    Console.WriteLine("\nIt's easy");
                    Console.WriteLine("\tto win forgiveness for being wrong;");
                    Console.WriteLine("\t\tbeing right is what gets you into real trouble.");
                    Console.WriteLine("\t\t\t\t\t\t\tBjarne Stroustrup");
                }
                else if (choice == "2")
                {
                    Console.Write("Enter 1 number: ");
                    int n1 = int.Parse(Console.ReadLine()!);

                    Console.Write("Enter 2 number: ");
                    int n2 = int.Parse(Console.ReadLine()!);

                    Console.Write("Enter 3 number: ");
                    int n3 = int.Parse(Console.ReadLine()!);

                    Console.Write("Enter 4 number: ");
                    int n4 = int.Parse(Console.ReadLine()!);

                    Console.Write("Enter 5 number: ");
                    int n5 = int.Parse(Console.ReadLine()!);

                    int sum = n1 + n2 + n3 + n4 + n5;
                    int product = n1 * n2 * n3 * n4 * n5;
                    int max = n1;
                    if (n2 > max) max = n2;
                    if (n3 > max) max = n3;
                    if (n4 > max) max = n4;
                    if (n5 > max) max = n5;

                    int min = n1;
                    if (n2 < min) min = n2;
                    if (n3 < min) min = n3;
                    if (n4 < min) min = n4;
                    if (n5 < min) min = n5;

                    Console.WriteLine("\nSum: " + sum);
                    Console.WriteLine("Produt: " + product);
                    Console.WriteLine("Max: " + max);
                    Console.WriteLine("Min: " + min);
                }
                else if (choice == "3")
                {
                    Console.Write("Enter 6-digit number: ");
                    int number = int.Parse(Console.ReadLine()!);
                    int reversed = 0;

                    while (number > 0)
                    {
                        int digit = number % 10;
                        reversed = reversed * 10 + digit;
                        number = number / 10;
                    }

                    Console.WriteLine("Result: " + reversed);
                }
                else if (choice == "0")
                {
                    Console.WriteLine("Good bye!");
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong choice");
                }

                Console.WriteLine("\nEnter any key to exit");
            }

        }
    }
}
