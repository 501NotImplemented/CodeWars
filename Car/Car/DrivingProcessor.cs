namespace Car
{
    public class DrivingProcessor : IDrivingProcessor
    {
        private readonly int currentAcceleration;

        private readonly int defaultAccelerationPerSecond = 10;

        private readonly int maximumAccelerationPerSecond = 20;

        private readonly int maximumBreakSpeed = 10;

        private readonly int maximumSpeed = 250;

        private readonly int minimumAccelerationPerSecond = 5;

        public DrivingProcessor(int acceleration)
        {
            ActualSpeed = 0;
            currentAcceleration = acceleration;
        }

        public int ActualSpeed { get; private set; }

        public void IncreaseSpeedTo(int speed)
        {
            int accelerationSpeed = GetAccelerationSpeed(speed);
            Console.WriteLine($"Increasing speed by {accelerationSpeed}");
            ActualSpeed = ActualSpeed + accelerationSpeed;
        }

        public void ReduceSpeed(int speed)
        {
            if ((speed == 0) | (speed >= maximumSpeed))
            {
                return;
            }

            if (speed > maximumBreakSpeed)
            {
                speed = maximumBreakSpeed;
            }

            ActualSpeed = ActualSpeed - speed;
        }

        private int GetAccelerationSpeed(int speed)
        {
            int speedDifference = speed - ActualSpeed;

            int acceleration = defaultAccelerationPerSecond;
            bool newSpeedExceedsMaximumAcceleration = speedDifference >= maximumAccelerationPerSecond;

            if (speedDifference == 0)
            {
                acceleration = 0;
            }

            if (newSpeedExceedsMaximumAcceleration)
            {
                acceleration = currentAcceleration;
            }
            else if (speedDifference != 0)
            {
                acceleration = currentAcceleration;
            }

            if (speedDifference == currentAcceleration)
            {
                acceleration = currentAcceleration;
            }
            else if (speedDifference > 0 && speedDifference <= minimumAccelerationPerSecond)
            {
                acceleration = minimumAccelerationPerSecond;
            }

            Console.WriteLine($"Acceleration is {acceleration}");
            return acceleration;
        }
    }
}