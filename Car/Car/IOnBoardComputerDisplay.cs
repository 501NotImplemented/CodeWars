namespace Car
{
    public interface IOnBoardComputerDisplay
    {
        double ActualConsumptionByDistance { get; }

        double ActualConsumptionByTime { get; }

        int ActualSpeed { get; }

        int EstimatedRange { get; }

        double TotalAverageConsumptionByDistance { get; }

        double TotalAverageConsumptionByTime { get; }

        double TotalAverageSpeed { get; }

        double TotalDrivenDistance { get; }

        int TotalDrivingTime { get; }

        int TotalRealTime { get; }

        double TripAverageConsumptionByDistance { get; }

        double TripAverageConsumptionByTime { get; }

        double TripAverageSpeed { get; }

        double TripDrivenDistance { get; }

        int TripDrivingTime { get; }

        int TripRealTime { get; }

        void TotalReset();

        void TripReset();
    }
}