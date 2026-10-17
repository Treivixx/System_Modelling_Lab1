namespace SystemModellingLab2;

public static class FunRand
{
    public static double Exp(double mean)
    {
        double value;

        do
        {
            value = Random.Shared.NextDouble();
        }
        while (value == 0);

        return -mean * Math.Log(value);
    }
}