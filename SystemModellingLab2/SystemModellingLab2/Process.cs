namespace SystemModellingLab2;

public class Process : Element
{
    public int Queue { get; private set; }

    public int MaxQueue { get; set; } = int.MaxValue;

    public int Failure { get; private set; }
    
    public double TBusy { get; private set; }

    public Process(string name, double delayMean)
        : base(name, delayMean)
    {
    }

    public override void InAct()
    {
        if (State == 0)
        {
            State = 1;
            TNext = TCurrent + GetDelay();
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
        base.OutAct();

        State = 0;
        TNext = double.MaxValue;

        if (Queue > 0)
        {
            Queue--;
            State = 1;
            TNext = TCurrent + GetDelay();
        }
    }
    
    public void UpdateTimeBusy(double delta)
    {
        TBusy += delta;
    }
}