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

            var maxAcceleration = 20;
            var minimumAcceleration = 5;
            int acceleration = defaultAccelerationPerSecond;
            bool newSpeedExceedsMaximumAcceleration = speedDifference >= maxAcceleration;

            if (speedDifference == 0)
            {
                acceleration = 0;
            }

            if (newSpeedExceedsMaximumAcceleration)
            {
                acceleration = defaultAccelerationPerSecond;
            }
            else if (speedDifference != 0)
            {
                acceleration = defaultAccelerationPerSecond;
            }

            if (speedDifference == defaultAccelerationPerSecond)
            {
                acceleration = defaultAccelerationPerSecond;
            }
            else if (speedDifference > 0 && speedDifference <= minimumAcceleration)
            {
                acceleration = minimumAcceleration;
            }

            Console.WriteLine($"Acceleration is {acceleration}");

            return acceleration;
        }
    }
}