namespace Car
{
    public class Car : ICar
    {
        public IFuelTankDisplay fuelTankDisplay;

        private readonly IEngine engine;

        private readonly double fuelConsumptionPerSecond = 0.0003;

        private readonly IFuelTank fuelTank;

        public Car()
        {
            fuelTank = new FuelTank();
            fuelTankDisplay = new FuelTankDisplay(fuelTank);
            engine = new Engine();
        }

        public Car(double fuelLevel)
        {
            fuelTank = new FuelTank(fuelLevel);
            fuelTankDisplay = new FuelTankDisplay(fuelTank);
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
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }

            EngineStop();
            fuelTank.Refuel(amount);
            EngineStart();
        }

        public void RunningIdle()
        {
            fuelTank.Consume(fuelConsumptionPerSecond);
        }
    }
}