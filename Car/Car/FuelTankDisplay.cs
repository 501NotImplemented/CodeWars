namespace Car
{
    public class FuelTankDisplay : IFuelTankDisplay
    {
        private readonly IFuelTank fuelTank;

        public FuelTankDisplay(IFuelTank fuelTank)
        {
            this.fuelTank = fuelTank;
        }

        public double FillLevel => Math.Round(fuelTank.FillLevel, 2);

        public bool IsComplete => fuelTank.IsComplete;

        public bool IsOnReserve => fuelTank.IsOnReserve;
    }
}