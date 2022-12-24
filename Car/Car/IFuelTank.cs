namespace Car
{
    public interface IFuelTank
    {
        double FillLevel { get; }

        bool IsComplete { get; }

        bool IsOnReserve { get; }

        void Consume(double liters);

        void Refuel(double liters);
    }
}