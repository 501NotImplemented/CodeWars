namespace Car
{
    public class FuelTank : IFuelTank
    {
        public FuelTank(double fuelLevel = 20)
        {
            Refuel(fuelLevel);
        }

        public double FillLevel { get; private set; }

        public bool IsComplete { get; private set; }

        public bool IsOnReserve { get; private set; }

        public void Consume(double liters)
        {
            if (FillLevel > 0)
            {
                Console.WriteLine($"Consuming {liters} liters. Fuel level before consumption {FillLevel}");
                FillLevel = FillLevel - liters;
                Console.WriteLine($"New fuel level {FillLevel}");
            }
        }

        public void Refuel(double liters)
        {
            if (liters <= 0)
            {
                liters = 0;
            }

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