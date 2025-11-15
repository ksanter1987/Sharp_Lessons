using System.Collections;
using System.Data;
using System.Runtime.Serialization;
using System.Threading.Channels;
//using static System.Console;

namespace _06_Exceptions
{
    class UserException : Exception
    {
        public void Method()
        {
            Console.WriteLine("My Exception!");
        }
    }

    class MyClass
    {
        public void BadMethod()
        {
            Exception exception = new Exception("My exception message");

            exception.HelpLink = "https://google.com";
            exception.Data.Add("Exception reason", "Test exception");
            exception.Data.Add("Time invokation", DateTime.Now);
            exception.Data.Add("User name", "Alex");
            throw exception;
        }
    }

    class ConvertToIntegerException : Exception
    {
        public DateTime Time {  get; set; } = DateTime.Now;
        public ConvertToIntegerException()
        {
            //Time = DateTime.Now;
        }

        public ConvertToIntegerException(string? message) : base(message)
        {
            //Time = DateTime.Now;
        }

        public ConvertToIntegerException(string? message, Exception? innerException) : base(message, innerException)
        {
            //Time = DateTime.Now;
        }

        protected ConvertToIntegerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    class ConsoleReader
    {
        public static int GetInt32FromConsole()
        {
            try
            {
                return int.Parse(Console.ReadLine()!);
            }
            catch (FormatException ex)
            {

                throw new ConvertToIntegerException("Argument has incorrect format", ex);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }


    internal class Program
    {
        static double SafeDivision(double x, double y)
        {
            if (y == 0)
            {
                throw new DivideByZeroException("Second operand = 0. Error");
            }
            return x / y;
        }
        static void Main(string[] args)
        {

            #region Example 1
            //int a = 1, b = 2;
            //double res = 0;



            //try
            //{
            //    Console.WriteLine("Enter a : ");
            //    a = int.Parse(Console.ReadLine()!);
            //    Console.WriteLine("Enter b : ");
            //    b = int.Parse(Console.ReadLine()!);

            //    res = a / b;
            //    Console.WriteLine($"Result = {res}");
            //}
            //catch (DivideByZeroException ex)
            //{

            //    Console.WriteLine(ex.Message); ;
            //}
            //catch (ArgumentException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //catch (FormatException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //catch (OverflowException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            #endregion
            #region Example 2
            //double a = 98, b = 2;
            //double result = 0;

            //try
            //{
            //    result = SafgeDivision(a, b);
            //    Console.WriteLine($"{a} / {b} = {result}");
            //}
            //catch (DivideByZeroException ex)
            //{

            //    Console.WriteLine(ex.Message);
            //}
            #endregion
            #region Example 3
            //try
            //{
            //    MyClass myClass = new MyClass();
            //    myClass.BadMethod();
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine($"Member name : {ex.TargetSite}");
            //    Console.WriteLine($"Member class : {ex.TargetSite.DeclaringType}");
            //    Console.WriteLine($"Member type : {ex.TargetSite.MemberType}");
            //    Console.WriteLine($"Method name : {ex.TargetSite.Name}");
            //    Console.WriteLine($"Message : {ex.Message}");
            //    Console.WriteLine($"Source : {ex.Source}");
            //    Console.WriteLine($"Help link : {ex.HelpLink}");
            //    Console.WriteLine($"Stack Trace : {ex.StackTrace}");

            //    foreach (DictionaryEntry item in ex.Data)
            //    {
            //        Console.WriteLine($"{item.Key} {item.Value}");
            //    }
            //}
            #endregion
            #region Example 4
            //int number = 0;
            //try
            //{
            //    number = ConsoleReader.GetInt32FromConsole();
            //    Console.WriteLine(new string('*', number));
            //}
            //catch (ConvertToIntegerException ex)
            //{

            //    Console.WriteLine("My own class exception");
            //    Console.WriteLine(ex.Message);
            //    Console.WriteLine(ex.Time);

            //}
            #endregion
            #region Example 5
            //try
            //{
            //    throw new UserException();
            //}
            //catch (UserException userException)
            //{
            //    Console.WriteLine("Exception catch!.");
            //    userException.Method();

            //    try
            //    {
            //        FileStream fs = File.Open(@"C:\NonExistentFile.log", FileMode.Open);
            //        //write

            //        //....exception 
            //        fs.Close();
            //    }
            //    catch (Exception exception)
            //    {
            //        Console.WriteLine(exception.Message);

            //    }
            //}
            #endregion
            #region Example 6
            //int a = 1, n = 2;
            //try
            //{
            //    n = int.Parse(Console.ReadLine());
            //    Console.ForegroundColor = ConsoleColor.Yellow;
            //    Console.WriteLine("Zero division.");
            //    Console.WriteLine("a / (2 - n) = {0}", a / (2 - n));
            //}
            //catch (DivideByZeroException e)
            //{
            //    //open.....
            //    Console.ForegroundColor = ConsoleColor.White;
            //    //ex
            //    //throw new Exception("Test ex");
            //    Console.BackgroundColor = ConsoleColor.Red;
            //    Console.WriteLine("Exception catch!");
            //    //ex
            //    Console.WriteLine(e.Message);

            //    //file.close()
            //}
            //catch (Exception e)
            //{
            //    Console.ForegroundColor = ConsoleColor.White;
            //    Console.BackgroundColor = ConsoleColor.Red;
            //    Console.WriteLine("Def Exception catch!");
            //    Console.WriteLine(e.Message);
            //}
            //finally
            //{
            //    Console.ResetColor();
            //    //Console.ForegroundColor = ConsoleColor.Gray;
            //    //Console.BackgroundColor = ConsoleColor.Black;

            //    // close connection
            //    //file.close()
            //}
            ////ex

            //Console.WriteLine("Press any key...");
            #endregion
            #region Example 7
            //byte b = 100;//0.....255
            //b = (byte)(b + 200);
            ////discharges that do not fall into the Byte range discarded
            //Console.WriteLine($"(byte)300 = {b}"); // 44
            //int n = 65537;
            //short s = (short)n;//65536
            //                   //discharges that do not fall into the Short range discarded
            //Console.WriteLine($"(short)65537 = {s}"); // 0


            ////byte  : 0...255
            ////  sbyte : -128...127
            //byte b = 255;
            ////b++;
            //Console.WriteLine(b);
            //try
            //{
            //    checked
            //    {
            //        b++; // generate OverflowException
            //    }
            //    Console.WriteLine(b);
            //}
            //catch (OverflowException e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            //try
            //{
            //    unchecked
            //    {
            //        b++; // ignore overflow
            //    }
            //    Console.WriteLine(b); //0
            //}
            //catch (OverflowException e)
            //{
            //    Console.WriteLine(e.Message);
            //}


            byte b = 100;
            Console.WriteLine(unchecked((byte)(b + 200))); // b = 44
            try
            {
                //generate exception
                Console.WriteLine(checked((byte)(b + 200)));
            }
            catch (OverflowException oe)
            {
                Console.WriteLine(oe.Message);
                Console.WriteLine();
            }


            #endregion
            Console.WriteLine("Continue...........");
            Console.WriteLine("Continue...........");
            Console.WriteLine("Continue...........");
            Console.WriteLine("Continue...........");
        }
    }
}
