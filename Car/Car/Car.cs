namespace Car
{
    public class Car : ICar
    {
        public IFuelTankDisplay fuelTankDisplay;

        private IEngine engine;

        private IFuelTank fuelTank;

        public Car()
        {
        }

        public Car(double fuelLevel)
        {
        }

        public bool EngineIsRunning => engine != null;

        public void EngineStart()
        {
            throw new NotImplementedException();
        }

        public void EngineStop()
        {
            throw new NotImplementedException();
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
    }

    public class FuelTank : IFuelTank
    {
    }

    public class FuelTankDisplay : IFuelTankDisplay
    {
        public double FillLevel { get; set; }

        public bool IsComplete { get; set; }

        public bool IsOnReserve { get; set; }
    }
}