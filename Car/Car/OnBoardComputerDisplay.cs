namespace Car
{
    public class OnBoardComputerDisplay : IOnBoardComputerDisplay
    {
        private readonly IOnBoardComputer _onboardComputer;

        public OnBoardComputerDisplay(IOnBoardComputer onBoardComputer)
        {
            _onboardComputer = onBoardComputer;
        }

        public double ActualConsumptionByDistance => _onboardComputer.ActualConsumptionByDistance;

        public double ActualConsumptionByTime => _onboardComputer.ActualConsumptionByTime;

        public int ActualSpeed => _onboardComputer.ActualSpeed;

        public int EstimatedRange => _onboardComputer.EstimatedRange;

        public double TotalAverageConsumptionByDistance => _onboardComputer.TotalAverageConsumptionByDistance;

        public double TotalAverageConsumptionByTime => _onboardComputer.TotalAverageConsumptionByTime;

        public double TotalAverageSpeed => _onboardComputer.TotalAverageSpeed;

        public double TotalDrivenDistance => _onboardComputer.TotalDrivenDistance;

        public int TotalDrivingTime => _onboardComputer.TotalDrivingTime;

        public int TotalRealTime => _onboardComputer.TotalRealTime;

        public double TripAverageConsumptionByDistance => _onboardComputer.TripAverageConsumptionByDistance;

        public double TripAverageConsumptionByTime => _onboardComputer.TripAverageConsumptionByTime;

        public double TripAverageSpeed => _onboardComputer.TripAverageSpeed;

        public double TripDrivenDistance => _onboardComputer.TripDrivenDistance;

        public int TripDrivingTime => _onboardComputer.TripDrivingTime;

        public int TripRealTime => _onboardComputer.TripRealTime;

        public void TotalReset()
        {
            _onboardComputer.TotalReset();
        }

        public void TripReset()
        {
            _onboardComputer.TripReset();
        }
    }
}