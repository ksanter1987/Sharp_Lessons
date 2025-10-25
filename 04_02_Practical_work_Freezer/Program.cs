namespace _04_02_Practical_work_Freezer
{
    public class Freezer
    {
        private string brand;
        private string model;
        private int capacityLiters;
        private int temperature;
        private bool isDefrosting;
        private static int minAllowedTemperature = -25;
        private static double defaultPowerUsageKwh = 1.5;

        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public int CapacityLiters
        {
            get { return capacityLiters; }
            private set { capacityLiters = value; }
        }

        public int Temperature
        {
            get { return temperature; }
        }

        public bool IsDefrosting
        {
            get { return isDefrosting; }
        }

        public Freezer(string brand, string model, int capacity)
        {
            this.Brand = brand;
            this.Model = model;
            this.CapacityLiters = capacity;
            
            this.temperature = -18;
            this.isDefrosting = false;
        }

        public void SetTemperature(int newTemperature)
        {
            if (newTemperature < minAllowedTemperature)
            {
                this.temperature = minAllowedTemperature;
                Console.WriteLine($"Error: Temperature {newTemperature} is too low! Minimum is: {minAllowedTemperature} C.");
            }
    
            else if (newTemperature > 0)
            {
                this.temperature = 0;
                Console.WriteLine($"Error: Freezer don't freeze");
            }
            else
            {
                this.temperature = newTemperature;
                Console.WriteLine($"Temperature is: {this.temperature} C.");
            }
        }

        public void StartDefrost()
        {
            this.isDefrosting = true;
            this.temperature = 1;
            Console.WriteLine("Start defrosting, temperature is 1 C");
        }

        public void StopDefrost()
        {
            this.isDefrosting = false;
            Console.WriteLine("Stop defrosting, start freezing, temperature is -18 C");
            SetTemperature(-18);
        }    

        public void Print()
        {
            Console.WriteLine("\n========== Freezer ==========");
            Console.WriteLine($"Brand: {this.Brand}");
            Console.WriteLine($"Model: {this.Model}");
            Console.WriteLine($"Capacity: {this.CapacityLiters} л.");
            Console.WriteLine($"Temperature: {this.temperature} C");
            Console.WriteLine($"Defrosting mode: {(this.isDefrosting ? "Enable" : "Disable")}");
     
            Console.WriteLine($"Minimum allowed temoerature: {minAllowedTemperature} C");
            Console.WriteLine($"Standert power usage: {defaultPowerUsageKwh} kW/h");
            Console.WriteLine("==============================================");
            Console.WriteLine();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Freezer myFreezer = new Freezer("Samsung", "RZ32", 315);
            myFreezer.Print();
            myFreezer.SetTemperature(-30);
            myFreezer.SetTemperature(-15);
            myFreezer.Print();
            myFreezer.StartDefrost();
            myFreezer.StopDefrost();
            myFreezer.Print();
        }
    }
}
