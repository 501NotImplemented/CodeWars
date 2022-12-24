namespace Car
{
    public interface IFuelTankDisplay
    {
        double FillLevel { get; }

        bool IsComplete { get; }

        bool IsOnReserve { get; }
    }
}