using System.Text;

namespace _03_01_StringBuilder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = "hello";//5
            str += "Hello";
            str += "Hello";
            str += "Hello";
            str += "Hello";
            str += "Hello";
            str += "Hello";
            str += "Hello";
            str += "Hello";
            str += "Hello";
            str += "Hello";
            str += "Hello";
            str += "Hello";
            Console.WriteLine(str);
            Console.WriteLine(str.Length);


            StringBuilder builder = new StringBuilder();
            Console.WriteLine(builder.Length);
            Console.WriteLine(builder.Capacity);
            builder.Append("bla");
            builder.Append("bla");
            builder.Append("bla");
            Console.WriteLine(builder.Length);
            Console.WriteLine(builder.Capacity);
            builder.Append("bla");
            builder.Append("bla");
            builder.Append("bla");
            builder.Append("bla");
            builder.Append("bla");
            builder.Append("bla");
            builder.Append("bla");
            builder.Append("bla");
            builder.Append("bla");
            builder.Append("bla");
            builder.Append("bla");
            builder.Append("bla");
            builder.Append("bla");
            Console.WriteLine(builder.Length);
            Console.WriteLine(builder.Capacity);
            builder.Append("bla");
            builder.Append("bla");
            builder.Append("bla");
            builder.AppendLine();
            Console.WriteLine(builder);
        }
    }
}
