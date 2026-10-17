namespace SystemModellingLab2;

public class Dispose : Element
{
    public Dispose(string name)
        : base(name, 0)
    {
    }

    public override void InAct()
    {
        Quantity++;
    }
}