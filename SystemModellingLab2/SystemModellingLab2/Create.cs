namespace SystemModellingLab2;

public class Create : Element
{
    public Create(string name, double delayMean)
        : base(name, delayMean)
    {
        TNext = 0;
    }

    public override void OutAct()
    {
        base.OutAct();

        TNext = TCurrent + GetDelay();

        NextElement?.InAct();
    }
}