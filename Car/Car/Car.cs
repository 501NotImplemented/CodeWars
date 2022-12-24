namespace Car
{
    public class Car : ICar
    {
        public IFuelTankDisplay fuelTankDisplay;

        private readonly IEngine engine;

        private IFuelTank fuelTank;

        public Car()
        {
            fuelTank = new FuelTank();
            engine = new Engine();
        }

        public Car(double fuelLevel)
        {
            fuelTank = new FuelTank(fuelLevel);
            engine = new Engine();
        }

        public bool EngineIsRunning => engine.IsRunning;

        public void EngineStart()
        {
            engine.Start();
        }

        public void EngineStop()
        {
            engine.Stop();
        }

        public void Refuel(double amount)
        {
            throw new NotImplementedException();
        }

        public void RunningIdle()
        {
            throw new NotImplementedException();
        }
    }

    public class Engine : IEngine
    {
        public bool IsRunning { get; set; }

        public void Start()
        {
            IsRunning = true;
        }

        public void Stop()
        {
            IsRunning = false;
        }
    }

    public class FuelTank : IFuelTank
    {
        private double fuelLevel;

        public FuelTank()
        {
        }

        public FuelTank(double fuelLevel)
        {
            this.fuelLevel = fuelLevel;
        }
    }

    public class FuelTankDisplay : IFuelTankDisplay
    {
        public double FillLevel { get; set; }

        public bool IsComplete { get; set; }

        public bool IsOnReserve { get; set; }
    }
}