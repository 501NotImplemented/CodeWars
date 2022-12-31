namespace Car
{
    public interface IOnBoardComputer
    {
        double ActualConsumptionByDistance { get; }

        double ActualConsumptionByTime { get; }

        int ActualSpeed { get; }

        int EstimatedRange { get; }

        double TotalAverageConsumptionByDistance { get; }

        double TotalAverageConsumptionByTime { get; }

        double TotalAverageSpeed { get; }

        int TotalDrivenDistance { get; }

        int TotalDrivingTime { get; }

        int TotalRealTime { get; }

        double TripAverageConsumptionByDistance { get; }

        double TripAverageConsumptionByTime { get; }

        double TripAverageSpeed { get; }

        int TripDrivenDistance { get; }

        int TripDrivingTime { get; }

        int TripRealTime { get; }

        void ElapseSecond();

        void TotalReset();

        void TripReset();
    }
}