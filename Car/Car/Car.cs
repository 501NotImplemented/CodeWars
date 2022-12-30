namespace Car
{
    public class Car : ICar
    {
        private const int AirResistanceSlowdown = 1;

        private const int MaxSpeed = 250;

        private static readonly double idleConsumptionPerSecond = 0.0003;

        public IDrivingInformationDisplay drivingInformationDisplay;

        public IFuelTankDisplay fuelTankDisplay;

        private readonly IDrivingProcessor drivingProcessor;

        private readonly IEngine engine;

        private readonly IFuelTank fuelTank;

        private readonly int maximumAccelerationPerSecond = 20;

        private readonly int minimumAccelerationPerSecond = 5;

        private double fuelConsumptionPerSecond = idleConsumptionPerSecond;

        public Car(double fuelLevel = 20, int maxAcceleration = 10)
        {
            Console.WriteLine($"Constructing car with fuel level {fuelLevel} and {maxAcceleration} max acceleration");

            if (maxAcceleration < minimumAccelerationPerSecond)
            {
                maxAcceleration = minimumAccelerationPerSecond;
            }

            if (maxAcceleration > maximumAccelerationPerSecond)
            {
                maxAcceleration = maximumAccelerationPerSecond;
            }

            fuelTank = new FuelTank(fuelLevel);
            fuelTankDisplay = new FuelTankDisplay(fuelTank);
            engine = new Engine(fuelTank);
            drivingProcessor = new DrivingProcessor(maxAcceleration);
            drivingInformationDisplay = new DrivingInformationDisplay(drivingProcessor);
        }

        public bool EngineIsRunning => engine.IsRunning;

        public void Accelerate(int speed)
        {
            Console.WriteLine($"Accelerate from {drivingProcessor.ActualSpeed} to {speed}");

            bool newSpeedExceedsMaximum = speed > MaxSpeed;
            if (newSpeedExceedsMaximum)
            {
                speed = MaxSpeed;
            }

            double newConsumption;
            if (!EngineIsRunning)
            {
                Console.WriteLine($"Engine is not running. Actual speed {drivingProcessor.ActualSpeed}. No action.");
                return;
            }

            if (drivingProcessor.ActualSpeed > speed)
            {
                Console.WriteLine(
                    $"Actual speed {drivingProcessor.ActualSpeed} is more than expected {speed}. Free wheeling");
                newConsumption = GetFuelConsumption(drivingProcessor.ActualSpeed);
                engine.Consume(newConsumption);
                return;
            }

            if (drivingProcessor.ActualSpeed == MaxSpeed)
            {
                Console.WriteLine(
                    $"Actual speed {drivingProcessor.ActualSpeed} is already at max {MaxSpeed}. No action.");
                newConsumption = GetFuelConsumption(drivingProcessor.ActualSpeed);
                engine.Consume(newConsumption);
                return;
            }

            int speedDifference = speed - drivingProcessor.ActualSpeed;
            if (speedDifference == 0)
            {
                newConsumption = GetFuelConsumption(drivingProcessor.ActualSpeed);
                engine.Consume(newConsumption);
                return;
            }

            drivingProcessor.IncreaseSpeedTo(speed);
            newConsumption = GetFuelConsumption(drivingProcessor.ActualSpeed);
            Console.WriteLine($"New consumption {newConsumption}");
            engine.Consume(newConsumption);
        }

        public void BrakeBy(int speed)
        {
            if (!EngineIsRunning || drivingProcessor.ActualSpeed == 0)
            {
                return;
            }

            Console.WriteLine($"Braking from {drivingProcessor.ActualSpeed} by {speed}");

            drivingProcessor.ReduceSpeed(speed);
        }

        public void EngineStart()
        {
            engine.Start();
            Console.WriteLine("Started engine");
            Console.WriteLine($"Fuel level {fuelTank.FillLevel}");
        }

        public void EngineStop()
        {
            engine.Stop();
        }

        public void FreeWheel()
        {
            Console.WriteLine("Free wheeling");
            if (drivingProcessor.ActualSpeed > 0)
            {
                drivingProcessor.ReduceSpeed(AirResistanceSlowdown);
            }
        }

        public void Refuel(double liters)
        {
            if (liters < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(liters));
            }

            EngineStop();
            fuelTank.Refuel(liters);
            EngineStart();
        }

        public void RunningIdle()
        {
            engine.Consume(idleConsumptionPerSecond);
        }

        private double GetFuelConsumption(int currentSpeed)
        {
            switch (currentSpeed)
            {
                case 0:
                    fuelConsumptionPerSecond = idleConsumptionPerSecond;
                    break;
                case >= 1 and <= 60:
                    fuelConsumptionPerSecond = 0.0020;
                    break;
                case >= 61 and <= 100:
                    fuelConsumptionPerSecond = 0.0014;
                    break;
                case >= 101 and <= 140:
                    fuelConsumptionPerSecond = 0.0020;
                    break;
                case >= 141 and <= 200:
                    fuelConsumptionPerSecond = 0.0025;
                    break;
                case >= 201 and <= MaxSpeed:
                    fuelConsumptionPerSecond = 0.0030;
                    break;
                default:
                    return fuelConsumptionPerSecond;
            }

            Console.WriteLine($"Fuel consumption at speed {currentSpeed} is {fuelConsumptionPerSecond}");
            return fuelConsumptionPerSecond;
        }
    }
}