namespace Car
{
    public class FuelTank : IFuelTank
    {
        private double _fillLevel;

        public FuelTank(double fuelLevel = 20)
        {
            Refuel(fuelLevel);
        }

        public double FillLevel
        {
            get => Math.Round(_fillLevel, 10);
            private set => _fillLevel = value;
        }

        public bool IsComplete { get; private set; }

        public bool IsOnReserve { get; private set; }

        public void Consume(double liters)
        {
            _fillLevel -= liters;
            _fillLevel = Math.Round(_fillLevel, 10);

            if (_fillLevel < 0)
            {
                _fillLevel = 0;
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