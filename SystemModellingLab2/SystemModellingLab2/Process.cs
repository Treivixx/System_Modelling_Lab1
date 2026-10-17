namespace SystemModellingLab2;

public class Process : Element
{
    public int Queue { get; private set; }

    public int MaxQueue { get; set; } = int.MaxValue;

    public int Failure { get; private set; }
    
    public double TBusy { get; private set; }
    
    public IReadOnlyList<Device> Devices { get; }

    public int DevicesCount => Devices.Count;
    
    public int DevicesBusy => Devices.Count(device => device.IsBusy);
    
    private Device? _nextDevice;

    public Process(string name, double delayMean)
        : this(name, delayMean, [new Device()])
    {
    }

    public Process(string name, double delayMean, IReadOnlyList<Device> devices)
        : base(name, delayMean)
    {
        Devices = devices;
    }

    public override void InAct()
    {
        var device = Devices.FirstOrDefault(device => !device.IsBusy);

        if (device is not null)
        {
            device.Start(TCurrent, GetDelay());
            UpdateState();
        }
        else
        {
            if (Queue < MaxQueue)
            {
                Queue++;
            }
            else
            {
                Failure++;
            }
        }
    }

    public override void OutAct()
    {
        var device = _nextDevice ?? throw new InvalidOperationException("No device has a scheduled completion.");

        base.OutAct();

        device.Release();

        if (Queue > 0)
        {
            Queue--;
            device.Start(TCurrent, GetDelay());
        }

        UpdateState();

        NextElement?.InAct();
    }

    private void UpdateState()
    {
        State = DevicesBusy > 0 ? 1 : 0;
        
        _nextDevice = Devices
            .Where(device => device.IsBusy)
            .OrderBy(device => device.TNext)
            .FirstOrDefault();

        TNext = _nextDevice?.TNext ?? double.MaxValue;
    }
    
    public void UpdateTimeBusy(double delta)
    {
        TBusy += DevicesBusy * delta;
    }
}
