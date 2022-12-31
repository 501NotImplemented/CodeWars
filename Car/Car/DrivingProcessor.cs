namespace Car
{
    public class DrivingProcessor : IDrivingProcessor
    {
        private readonly int currentMaximumAcceleration;

        private readonly int defaultAccelerationPerSecond = 10;

        private readonly int maximumBreakSpeed = 10;

        private readonly int maximumSpeed = 250;

        private readonly int minimumAccelerationPerSecond = 5;

        public DrivingProcessor(int maximumAcceleration)
        {
            ActualSpeed = 0;
            currentMaximumAcceleration = maximumAcceleration;
        }

        public double ActualConsumption { get; }

        public int ActualSpeed { get; private set; }

        public void EngineStart()
        {
            throw new NotImplementedException();
        }

        public void EngineStop()
        {
            throw new NotImplementedException();
        }

        public void IncreaseSpeedTo(int speed)
        {
            int accelerationSpeed = GetAccelerationSpeed(speed);
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
            bool newSpeedExceedsMaximumAcceleration = speedDifference >= currentMaximumAcceleration;

            if (speedDifference == 0)
            {
                acceleration = 0;
            }
            else if (newSpeedExceedsMaximumAcceleration)
            {
                acceleration = currentMaximumAcceleration;
            }
            else if (speedDifference == currentMaximumAcceleration)
            {
                acceleration = currentMaximumAcceleration;
            }
            else if (speedDifference > 0 && speedDifference <= minimumAccelerationPerSecond)
            {
                acceleration = speedDifference;
            }
            else if (speedDifference < defaultAccelerationPerSecond && speedDifference > 0)
            {
                acceleration = speedDifference;
            }
            else if (speedDifference < currentMaximumAcceleration && speedDifference > 0)
            {
                acceleration = speedDifference;
            }

            return acceleration;
        }
    }
}