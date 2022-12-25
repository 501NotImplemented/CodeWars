namespace Car
{
    public class DrivingInformationDisplay : IDrivingInformationDisplay
    {
        private readonly IDrivingProcessor drivingProcessor;

        public DrivingInformationDisplay(IDrivingProcessor drivingProcessor)
        {
            this.drivingProcessor = drivingProcessor;
        }

        public int ActualSpeed => drivingProcessor.ActualSpeed;
    }
}