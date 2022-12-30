namespace Car
{
    public class Engine : IEngine
    {
        private readonly IFuelTank fuelTank;

        public Engine(IFuelTank fuelTank)
        {
            this.fuelTank = fuelTank;
        }

        public bool IsRunning { get; set; }

        public void Consume(double liters)
        {
            Console.WriteLine($"Consuming {liters}. Fill level is {fuelTank.FillLevel}");
            if (IsRunning)
            {
                fuelTank.Consume(liters);
                if (fuelTank.FillLevel < 0)
                {
                    Console.WriteLine($"Fuel tank level is {fuelTank.FillLevel}, stopping the engine");
                    Stop();
                }
            }
        }

        public void Start()
        {
            if (fuelTank.FillLevel > 0)
            {
                IsRunning = true;
            }
        }

        public void Stop()
        {
            IsRunning = false;
        }
    }
}