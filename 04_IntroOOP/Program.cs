namespace _04_IntroOOP
{
    partial class Point
    {

    }
    partial class Point
    {

    }


    partial class Point /*: object*/
    {
        ////private
        //private int number;
        //private string name;
        //private const float PI = 3.14f;
        //private readonly int id;


        //public Point()
        //{
        //    id = 10;
        //}



        //void setId(int id)
        //{
        //    this.id = id;
        //}


        //private int _xCoord;
        //private int _yCoord;


        static int count;
        static Point() // для початкової ініціалізації статичної змінної
        {
            count = 0;
        }

        public Point() : this(0, 0) { }
        //{
        //    _xCoord = 0;
        //    _yCoord = 0;
        //}
        public Point(int x, int y)
        {
            setX(x);
            setY(y);
            count++;
        }

        

        //properties

        //propfull + tab
        //private string name;

        //public string Name  
        //{
        //    get { return name; }
        //    set { name = value; }
        //}
        //prop auto
        //prop + tab
        public int Name { get; set; }

        public string Color { get; set; }






        private int _xCoord;
        public int XCoord //value == newX
        {
            get { return _xCoord; }
            set {
                if (value > 0)
                    _xCoord = value;
                else
                    _xCoord = 0;
            }
        }
        private int _yCoord;
        public int YCoord //value == newY
        {
            get { return _yCoord; }
            set {
                if (value > 0)
                    _yCoord = value;
                else
                    _yCoord = 0;
            }
        }


        public void Print()
        {
            Console.WriteLine($"X : {_xCoord}. Y : {_yCoord}");
        }

        public override string ToString()
        {
            return $"X : {_xCoord}. Y : {_yCoord}";
        }
    }

    class DerivedClass : Point //public default
    {

    }

    //class MyClass : DerivedClass немає подвійного наслідування




    internal class Program
    {
        static void Main(string[] args)
        {
            //Point @class = new Point();

            Point point = new Point();

            point.Print();

            Console.WriteLine(point);
            Console.WriteLine(point.ToString());

            point.setX(100);
            Console.WriteLine(point);

            point.setY(-100);
            Console.WriteLine(point.getY());
            Console.WriteLine(point);


            point.XCoord = 150;//value = 150
            int x = point.XCoord;//getter
            Console.WriteLine(x);
            Console.WriteLine(point);

        }
    }
}
