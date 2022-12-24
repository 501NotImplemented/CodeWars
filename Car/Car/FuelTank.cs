namespace Car
{
    public class FuelTank : IFuelTank
    {
        public FuelTank(double fuelLevel)
        {
            Refuel(fuelLevel);
        }

        public FuelTank()
        {
            var defaultFuelLevel = 20;
            Refuel(defaultFuelLevel);
        }

        public double FillLevel { get; private set; }

        public bool IsComplete { get; private set; }

        public bool IsOnReserve { get; private set; }

        public void Consume(double liters)
        {
            if (FillLevel >= 0)
            {
                FillLevel = FillLevel - liters;
            }
        }

        public void Refuel(double liters)
        {
            var minimumReserveAmount = 5;
            if (liters <= minimumReserveAmount)
            {
                IsOnReserve = true;
            }

            double expectedLevel = FillLevel + liters;

            var maximumCapacity = 60;
            if (expectedLevel >= maximumCapacity)
            {
                IsComplete = true;
                FillLevel = maximumCapacity;
                return;
            }

            FillLevel = expectedLevel;
        }
    }
}