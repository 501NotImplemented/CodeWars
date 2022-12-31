namespace Car
{
    public class OnBoardComputer : IOnBoardComputer
    {
        private readonly IDrivingProcessor drivingProcessor;

        public OnBoardComputer(IDrivingProcessor drivingProcessor)
        {
            this.drivingProcessor = drivingProcessor;
        }

        public double ActualConsumptionByDistance
        {
            get
            {
                double consumption = double.NaN;

                return consumption;
            }
        }

        public double ActualConsumptionByTime => ActualSpeed;

        public int ActualSpeed { get; } = 0;

        public int EstimatedRange { get; }

        public double TotalAverageConsumptionByDistance { get; }

        public double TotalAverageConsumptionByTime { get; }

        public double TotalAverageSpeed { get; }

        public int TotalDrivenDistance { get; }

        public int TotalDrivingTime { get; }

        public int TotalRealTime { get; }

        public double TripAverageConsumptionByDistance { get; }

        public double TripAverageConsumptionByTime { get; }

        public double TripAverageSpeed { get; }

        public int TripDrivenDistance { get; }

        public int TripDrivingTime { get; }

        public int TripRealTime { get; }

        public void ElapseSecond()
        {
            throw new NotImplementedException();
        }

        public void TotalReset()
        {
            throw new NotImplementedException();
        }

        public void TripReset()
        {
            throw new NotImplementedException();
        }
    }
}