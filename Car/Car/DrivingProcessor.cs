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

            Console.WriteLine($"Accelerating speed from {ActualSpeed} to {speed}");
            int accelerationSpeed = GetAccelerationSpeed(speed);
            Console.WriteLine($"Acceleration speed is {accelerationSpeed}");

            ActualSpeed = ActualSpeed + accelerationSpeed;
        }

        public void ReduceSpeed(int speed)
        {
            if ((speed == 0) | (speed >= maximumSpeed))
            {
                return;
            }

            ActualSpeed = ActualSpeed - maximumBreakSpeed;
        }

        private int GetAccelerationSpeed(int speed)
        {
            int speedDifference = speed - ActualSpeed;
            var maxAcceleration = 20;
            var minimumAcceleration = 5;
            int acceleration = defaultAccelerationPerSecond;

            if (speedDifference == 0)
            {
                acceleration = 0;
            }

            if (speedDifference >= maxAcceleration)
            {
                acceleration = defaultAccelerationPerSecond;
            }

            if (speedDifference == defaultAccelerationPerSecond)
            {
                acceleration = defaultAccelerationPerSecond;
            }
            else if (speedDifference <= minimumAcceleration)
            {
                acceleration = minimumAcceleration;
            }

            return acceleration;
        }
    }
}