using System.Drawing;

namespace _07_OverloadOperator
{
    class _3D_Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public _3D_Point() : this(0, 0, 0) { }

        public _3D_Point(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public override string ToString()
        {
            return $"X : {X}. Y : {Y}. Z : {Z}";
        }
    }


    class _2D_Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        
        public _2D_Point() : this(0, 0) { }
        
        public _2D_Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override string ToString()
        {
            return $"X : {X}. Y : {Y}";
        }

        public override bool Equals(object? obj)
        {
            return obj is _2D_Point point &&
                   X == point.X &&
                   Y == point.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
        #region Унарні оператори ++ -- ! -
        public static _2D_Point operator -(_2D_Point p)
        {
            _2D_Point newPoint = new _2D_Point()
            {
                X = -p.X,
                Y = p.Y * -1
            };
            return newPoint;
        }
        public static _2D_Point operator ++(_2D_Point p) //_2D_Point p = 0x2x5x58d8d
        {
            p.X++;
            p.Y++;
            return p;
        }
        public static _2D_Point operator --(_2D_Point p) //_2D_Point p = 0x2x5x58d8d
        {
            p.X--;
            p.Y--;
            return p;
        }
        #endregion
        #region Бінарні оператори + - * /
        public static _2D_Point operator +(_2D_Point p1, _2D_Point p2)
        {
            _2D_Point newPoint = new _2D_Point()
            {
                X = p1.X + p2.X,
                Y = p1.Y + p1.Y
            };
            return newPoint;
                        
        }
        public static _2D_Point operator -(_2D_Point p1, _2D_Point p2)
        {
            _2D_Point newPoint = new _2D_Point()
            {
                X = p1.X - p2.X,
                Y = p1.Y - p1.Y
            };
            return newPoint;
                      
        }
        public static _2D_Point operator *(_2D_Point p1, _2D_Point p2)
        {
            _2D_Point newPoint = new _2D_Point()
            {
                X = p1.X * p2.X,
                Y = p1.Y * p1.Y
            };
            return newPoint;
                      
        }
        public static _2D_Point operator /(_2D_Point p1, _2D_Point p2)
        {
            _2D_Point newPoint = new _2D_Point()
            {
                X = p1.X / p2.X,
                Y = p1.Y / p1.Y
            };
            return newPoint;
        }
        #endregion
        #region Логічні оператори рівності == !=
        public static bool operator ==(_2D_Point p1, _2D_Point p2)
        {
            //return p1.X == p2.X && p1.Y == p2.Y;
            return p1.Equals(p2);
        }
        //as pair
        public static bool operator !=(_2D_Point p1, _2D_Point p2)
        {
            return !(p1 == p2);
        }

        #endregion
        #region Логічні оператори порівняння < > <== >==
        public static bool operator >(_2D_Point p1, _2D_Point p2)
        {
            return p1.X + p2.Y > p2.X + p2.Y;
        }
        // in pair
        public static bool operator <(_2D_Point p1, _2D_Point p2)
        {
            return p1.X + p2.Y < p2.X + p2.Y;
        }
        public static bool operator >=(_2D_Point p1, _2D_Point p2)
        {
            return p1.X + p2.Y >= p2.X + p2.Y;
        }
        // in pair
        public static bool operator <=(_2D_Point p1, _2D_Point p2)
        {
            return p1.X + p2.Y <= p2.X + p2.Y;
        }

        #endregion
        #region True/False
        public static bool operator true(_2D_Point p)
        {
            return p.X >= 0 && p.Y >= 0;
        }
        //in pair
        public static bool operator false(_2D_Point p)
        {
            return p.X < 0 || p.Y < 0;
        }
        #endregion
        #region Overload types
        //public static implicit operator int(_2D_Point p)
        //{
        //    return p.X + p.Y;
        //}
        public static explicit operator int(_2D_Point p)
        {
            return p.X + p.Y;
        }
        public static implicit operator _3D_Point(_2D_Point p)
        {
            return new _3D_Point(p.X, p.Y, 0);
        }
        #endregion
        //overload operators
        //public static return_type operator[symbol](parameters)
        //{ // code}
    }

    class Program
    {
        static void Main(string[] args)
        {
            // + - * / > < >= <= == !=
            int a = 5, b = 6;
            Console.WriteLine($"Res = {a + b}");
            Console.WriteLine($"Res = {a - b}");
            Console.WriteLine($"Res = {a * b}");
            Console.WriteLine($"Res = {a / b}");

            _2D_Point p = new _2D_Point(15, 25); //p = 0x2x5x58d8d
            _2D_Point res = -p; // p.operator-()
            Console.WriteLine($"Original point : {p}");
            Console.WriteLine($"Original point : {res}");

            Console.WriteLine($"Original point : {p++}");
            Console.WriteLine($"Original point : {++p}");
            Console.WriteLine($"Original point : {p--}");
            Console.WriteLine($"Original point : {--p}");

            _2D_Point p2 = new _2D_Point(5, 3);
            res = p + p2;
            Console.WriteLine($"Original point : {p}");
            Console.WriteLine($"Original point : {p2}");
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"New point : {res}");
            res = p - p2;
            Console.WriteLine($"New point : {res}");
            res = p * p2;
            Console.WriteLine($"New point : {res}");
            res = p / p2;

            object obj = new object();


            string str1 = "Hello"; //1cd4d5f5443
            string str2 = "Hello"; //1cd4d5f5443
            if (str1.Equals(str2))
            {
                Console.WriteLine("equals");
            }
            else
                Console.WriteLine("not equals");
            if (p == p2)
            {
                Console.WriteLine("equals");
            }
            else
                Console.WriteLine("not equals");
            if (p)
            {
                Console.WriteLine("equals");
            }
            else
                Console.WriteLine("not equals");




            //Conversation data typ[es
            int d = 5;
            double f = 3.14;

            //int to double
            f = d;//f = 5 ---- implicit
            d = (int)f;// explicit double -----> int

            //d = p2; // _2D_Point -----> int
            //Console.WriteLine(d);
            d = (int)p2;
            Console.WriteLine(d);

            _3D_Point p3 = p2;
            Console.WriteLine(p3);



        }
    }
}
