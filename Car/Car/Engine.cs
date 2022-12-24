namespace Car
{
    public class Engine : IEngine
    {
        public bool IsRunning { get; set; }

        public void Consume(double liters)
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            IsRunning = true;
        }

        public void Stop()
        {
            IsRunning = false;
        }
    }
}