namespace Car
{
    public interface ICar
    {
        bool EngineIsRunning { get; }

        void Accelerate(int speed);

        void BrakeBy(int speed);

        void EngineStart();

        void EngineStop();

        void FreeWheel();

        void Refuel(double liters);

        void RunningIdle();
    }
}