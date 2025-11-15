
namespace _07_Practical_work_OverloadPOperator_Square_Rectangle
{
    public class Rectangle
    {
        public double A { get; set; }
        public double B { get; set; }

        public double Area => A * B;

        public Rectangle()
        {
            A = 0;
            B = 0;
        }

        public Rectangle(double a, double b)
        {
            A = (a < 0) ? 0 : a;
            B = (b < 0) ? 0 : b;
        }

        public override string ToString()
        {
            return $"Прямокутник зі сторонами {A} та {B}";
        }

        #region Унарні оператори
        public static Rectangle operator ++(Rectangle r)
        {
            r.A++;
            r.B++;
            return r;
        }

        public static Rectangle operator --(Rectangle r)
        {
            double newA = r.A - 1;
            double newB = r.B - 1;

            r.A = (newA < 0) ? 0 : newA;
            r.B = (newB < 0) ? 0 : newB;
            return r;
        }
        #endregion
        #region Бінарні оператори
        public static Rectangle operator +(Rectangle r1, Rectangle r2)
        {
            return new Rectangle(r1.A + r2.A, r1.B + r2.B);
        }

        public static Rectangle operator -(Rectangle r1, Rectangle r2)
        {
            double newA = r1.A - r2.A;
            double newB = r1.B - r2.B;

            return new Rectangle((newA < 0) ? 0 : newA, (newB < 0) ? 0 : newB);
        }

        public static Rectangle operator *(Rectangle r1, Rectangle r2)
        {
            return new Rectangle(r1.A * r2.A, r1.B * r2.B);
        }

        public static Rectangle operator /(Rectangle r1, Rectangle r2)
        {
            double newA = r2.A == 0 ? 0 : r1.A / r2.A;
            double newB = r2.B == 0 ? 0 : r1.B / r2.B;

            if (r2.A == 0 || r2.B == 0)
            {
                Console.WriteLine("Помилка. Ділення на нуль");
            }
            return new Rectangle(newA, newB);
        }
        #endregion
        #region Оператори порівняння
        public static bool operator >(Rectangle r1, Rectangle r2)
        {
            return r1.Area > r2.Area;
        }

        public static bool operator <(Rectangle r1, Rectangle r2)
        {
            return r1.Area < r2.Area;
        }

        public static bool operator >=(Rectangle r1, Rectangle r2)
        {
            return r1.Area >= r2.Area;
        }

        public static bool operator <=(Rectangle r1, Rectangle r2)
        {
            return r1.Area <= r2.Area;
        }
        #endregion
        #region Оператори рівності
        public static bool operator ==(Rectangle r1, Rectangle r2)
        {
            if ((object)r1 == null)
            {
                return (object)r2 == null;
            }
            return r1.Equals(r2);
        }

        public static bool operator !=(Rectangle r1, Rectangle r2)
        {
            return !(r1 == r2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Rectangle))
            {
                return false;
            }

            Rectangle other = (Rectangle)obj;
            return this.A == other.A && this.B == other.B;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(A, B);
        }
        #endregion
        #region true/false
        public static bool operator true(Rectangle r)
        {
            return r.A != 0 && r.B != 0;
        }

        public static bool operator false(Rectangle r)
        {
            return r.A == 0 || r.B == 0;
        }
        #endregion
        #region Оператори приведення типу
        public static explicit operator Square(Rectangle r)
        {
            return new Square(r.A);
        }

        public static explicit operator int(Rectangle r)
        {
            return (int)r.Area;
        }
        #endregion
    }

    public class Square
    {
        public double A { get; set; }

        public Square()
        {
            A = 0;
        }
        public Square(double a)
        {
            A = (a < 0) ? 0 : a;
        }

        public override string ToString()
        {
            return $"Квадрат зі стороною {A}";
        }

        #region Унарні оператори
        public static Square operator ++(Square s)
        {
            s.A++;
            return s;
        }

        public static Square operator --(Square s)
        {
            double newA = s.A - 1;
            s.A = (newA < 0) ? 0 : newA;
            return s;
        }
        #endregion
        #region Бінарні оператори
        public static Square operator +(Square s1, Square s2)
        {
            return new Square(s1.A + s2.A);
        }

        public static Square operator -(Square s1, Square s2)
        {
            double newA = s1.A - s2.A;
            return new Square((newA < 0) ? 0 : newA);
        }

        public static Square operator *(Square s1, Square s2)
        {
            return new Square(s1.A * s2.A);
        }

        public static Square operator /(Square s1, Square s2)
        {
            if (s2.A == 0)
            {
                Console.WriteLine("Помилка. Ділення на нуль");
                return new Square(0);
            }
            return new Square(s1.A / s2.A);
        }
        #endregion
        #region Оператори порівняння
        public static bool operator >(Square s1, Square s2)
        {
            return s1.A > s2.A;
        }

        public static bool operator <(Square s1, Square s2)
        {
            return s1.A < s2.A;
        }

        public static bool operator >=(Square s1, Square s2)
        {
            return s1.A >= s2.A;
        }

        public static bool operator <=(Square s1, Square s2)
        {
            return s1.A <= s2.A;
        }
        #endregion
        #region Оператори рівності
        public static bool operator ==(Square s1, Square s2)
        {
            if ((object)s1 == null)
            {
                return (object)s2 == null;
            }
            return s1.Equals(s2);
        }

        public static bool operator !=(Square s1, Square s2)
        {
            return !(s1 == s2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Square))
            {
                return false;
            }

            Square other = (Square)obj;
            return this.A == other.A;
        }

        public override int GetHashCode()
        {
            return A.GetHashCode();
        }
        #endregion
        #region true/false
        public static bool operator true(Square s)
        {
            return s.A != 0;
        }

        public static bool operator false(Square s)
        {
            return s.A == 0;
        }
        #endregion
        #region Оператори приведення типу
        public static implicit operator Rectangle(Square s)
        {
            return new Rectangle(s.A, s.A);
        }

        public static implicit operator int(Square s)
        {
            return (int)(s.A * s.A);
        }
        #endregion
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Square s1 = new Square(5);
            Square s2 = new Square(10);
            Square s0 = new Square();
            Rectangle r1 = new Rectangle(4, 8);
            Rectangle r2 = new Rectangle(5, 10);
            Rectangle r0 = new Rectangle();
            Console.WriteLine($"s1 = {s1}");
            Console.WriteLine($"s2 = {s2}");
            Console.WriteLine($"s0 = {s0}");
            Console.WriteLine($"r1 = {r1}");
            Console.WriteLine($"r2 = {r2}");
            Console.WriteLine($"r0 = {r0}");
            s1++;
            s2--;
            r1++;
            r2--;
            Console.WriteLine($"s1++: {s1}"); 
            Console.WriteLine($"s2--: {s2}"); 
            Console.WriteLine($"r1++: {r1}");
            Console.WriteLine($"r2--: {r2}");
            Console.WriteLine($"s1 + s2 : {s1 + s2}");
            Console.WriteLine($"s2 - s1 : {s2 - s1}");
            Console.WriteLine($"s1 - s2 : {s1 - s2}");
            Console.WriteLine($"r1 + r2 : {r1 + r2}");
            Console.WriteLine($"r2 - r1 : {r2 - r1}");
            Console.WriteLine($"r1 - r2 : {r1 - r2}");
            Console.WriteLine($"s1 * s2 : {s1 * s2}"); 
            Console.WriteLine($"r1 * r2 : {r1 * r2}"); 
            Console.WriteLine($"s1 / s2 : {s1 / s2}"); 
            Console.WriteLine($"s1 / s0 : {s1 / s0}"); 
            Console.WriteLine($"r1 / r2 : {r1 / r2}"); 
            Console.WriteLine($"r1 / r0 : {r1 / r0}"); 
            Console.WriteLine($"s1 > s2 : {s1 > s2}"); 
            Console.WriteLine($"s1 < s2 : {s1 < s2}"); 
            Console.WriteLine($"s1 >= s2 : {s1 >= s2}"); 
            Console.WriteLine($"s1 <= s2 : {s1 <= s2}"); 
            Console.WriteLine($"r1 < r2 : {r1 < r2}");
            Console.WriteLine($"r1 > r2 : {r1 > r2}");
            Console.WriteLine($"r1 <= r2 : {r1 <= r2}");
            Console.WriteLine($"r1 >= r2 : {r1 >= r2}");
            Square s0_copy = new Square();
            Console.WriteLine($"s0 == s0_copy : {s0 == s0_copy}");
            Console.WriteLine($"r1 != r2: {r1 != r2}");
            
            if (s1) Console.WriteLine("s1 - true");
            else Console.WriteLine("s1 - false");

            if (s0) Console.WriteLine("s0 - true");
            else Console.WriteLine("s0 - false");

            Rectangle rect_from_s1 = s1;
            Console.WriteLine($"Square -> Rectangle: {rect_from_s1}");

            Square sq_from_r2 = (Square)r2;
            Console.WriteLine($"Rectangle -> Square: {sq_from_r2}");

            int area_s1 = s1;
            Console.WriteLine($"Square -> int: {area_s1}");

            int area_r2 = (int)r2;
            Console.WriteLine($"Rectangle -> int: {area_r2}");


            Rectangle rect_squar = r1 + s1;
            Console.WriteLine($"rect_squar: {rect_squar}");
        }
    }
}
