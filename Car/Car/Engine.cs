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
            if (IsRunning)
            {
                fuelTank.Consume(liters);
                if (fuelTank.FillLevel <= 0)
                {
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