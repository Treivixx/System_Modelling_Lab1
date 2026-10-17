namespace SystemModellingLab2;

public abstract class Element
{
    public string Name { get; set; }

    public double TCurrent { get; set; }

    public double TNext { get; protected set; }

    public double DelayMean { get; set; }

    public int State { get; protected set; }

    public int Quantity { get; protected set; }

    public Element? NextElement { get; set; }

    protected Element(string name, double delayMean)
    {
        Name = name;
        DelayMean = delayMean;

        TCurrent = 0;
        TNext = double.MaxValue;
        State = 0;
    }

    protected double GetDelay()
    {
        return FunRand.Exp(DelayMean);
    }

    public virtual void InAct()
    {
    }

    public virtual void OutAct()
    {
        Quantity++;
    }
}