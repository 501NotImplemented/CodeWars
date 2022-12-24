namespace Car
{
    public interface IFuelTankDisplay
    {
        public double FillLevel { get; set; }

        public bool IsComplete { get; set; }

        public bool IsOnReserve { get; set; }
    }
}