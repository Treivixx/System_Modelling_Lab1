namespace SystemModellingLab2
{
    public class Device
    {
        public bool IsBusy { get; private set; }
        public double TNext { get; private set; } = double.MaxValue;

        public void Start(double currentTime, double serviceTime)
        {
            IsBusy = true;
            TNext = currentTime + serviceTime;
        }

        public void Release()
        {
            IsBusy = false;
            TNext = double.MaxValue;
        }
    }
}