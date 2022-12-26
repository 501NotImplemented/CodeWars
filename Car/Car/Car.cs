namespace Car
{
    public class Car : ICar
    {
        private const int AirResistanceSlowdown = 1;

        private const int MaxSpeed = 250;

        public IDrivingInformationDisplay drivingInformationDisplay;

        public IFuelTankDisplay fuelTankDisplay;

        private readonly IDrivingProcessor drivingProcessor;

        private readonly IEngine engine;

        private readonly IFuelTank fuelTank;

        private double fuelConsumptionPerSecond = 0.0003;

        public Car(double fuelLevel = 20, int maxAcceleration = 20)
        {
            fuelTank = new FuelTank(fuelLevel);
            fuelTankDisplay = new FuelTankDisplay(fuelTank);
            engine = new Engine(fuelTank);
            drivingProcessor = new DrivingProcessor();
            drivingInformationDisplay = new DrivingInformationDisplay(drivingProcessor);
        }

        public bool EngineIsRunning => engine.IsRunning;

        public void Accelerate(int speed)
        {
            if (drivingProcessor.ActualSpeed >= speed)
            {
                FreeWheel();
                return;
            }

            if (drivingProcessor.ActualSpeed == MaxSpeed)
            {
                return;
            }

            if (!EngineIsRunning)
            {
                return;
            }

            drivingProcessor.IncreaseSpeedTo(speed);
            double newConsumption = GetFuelConsumption(drivingProcessor.ActualSpeed);
            engine.Consume(newConsumption);
        }

        public void BrakeBy(int speed)
        {
            if (!EngineIsRunning || drivingProcessor.ActualSpeed == 0)
            {
                return;
            }

            drivingProcessor.ReduceSpeed(speed);
        }

        public void EngineStart()
        {
            engine.Start();
            engine.Consume(fuelConsumptionPerSecond);
        }

        public void EngineStop()
        {
            engine.Stop();
        }

        public void FreeWheel()
        {
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
            engine.Consume(fuelConsumptionPerSecond);
        }

        private double GetFuelConsumption(int currentSpeed)
        {
            switch (currentSpeed)
            {
                case > 1 and <= 60:
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

            return fuelConsumptionPerSecond;
        }
    }
}