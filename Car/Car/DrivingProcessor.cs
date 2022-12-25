namespace Car
{
    public class DrivingProcessor : IDrivingProcessor
    {
        private readonly int defaultAccelerationPerSecond = 10;

        private readonly int maximumBreakSpeed = 10;

        private readonly int maximumSpeed = 250;

        public DrivingProcessor()
        {
            ActualSpeed = 0;
        }

        public int ActualSpeed { get; private set; }

        public void IncreaseSpeedTo(int speed)
        {
            if ((speed <= 0) | (speed >= maximumSpeed))
            {
                return;
            }

            ActualSpeed = ActualSpeed + defaultAccelerationPerSecond;
        }

        public void ReduceSpeed(int speed)
        {
            if ((speed == 0) | (speed >= maximumSpeed))
            {
                return;
            }

            ActualSpeed = ActualSpeed - maximumBreakSpeed;
        }
    }
}