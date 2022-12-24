namespace Car
{
    public interface IEngine
    {
        public bool IsRunning { get; set; }

        void Start();

        void Stop();
    }
}