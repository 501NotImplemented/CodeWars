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
    }

    public class Engine : IEngine
    {
    }

    public class FuelTank : IFuelTank
    {
    }

    public class FuelTankDisplay : IFuelTankDisplay
    {
    }
}