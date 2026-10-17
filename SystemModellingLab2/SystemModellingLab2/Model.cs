using SystemModellingLab2;

public class Model
{
    private readonly List<Element> _elements;

    public double TCurrent { get; private set; }

    public Model(IEnumerable<Element> elements)
    {
        _elements = elements.ToList();
        TCurrent = 0;
    }

    public void Simulate(double simulationTime)
    {
        while (TCurrent < simulationTime)
        {
            var nextElement = _elements.MinBy(e => e.TNext);

            if (nextElement == null || nextElement.TNext == double.MaxValue)
            {
                break;
            }

            if (nextElement.TNext > simulationTime)
            {
                TCurrent = simulationTime;
                break;
            }

            TCurrent = nextElement.TNext;

            foreach (var element in _elements)
            {
                element.TCurrent = TCurrent;
            }

            nextElement.OutAct();

            PrintInfo(nextElement);
        }

        PrintResults();
    }

    private void PrintInfo(Element currentElement)
    {
        Console.WriteLine($"t = {TCurrent:F2}, event = {currentElement.Name}");

        foreach (var element in _elements)
        {
            if (element is Process process)
            {
                Console.WriteLine($"  {process.Name}: state = {process.State}, queue = {process.Queue}, processed = {process.Quantity}, failures = {process.Failure}");
            }
            else
            {
                Console.WriteLine($"  {element.Name}: quantity = {element.Quantity}");
            }
        }

        Console.WriteLine();
    }

    private void PrintResults()
    {
        Console.WriteLine("---------- Results ----------");
        Console.WriteLine($"Simulation time: {TCurrent:F2}");

        foreach (var element in _elements)
        {
            Console.WriteLine($"{element.Name}: quantity = {element.Quantity}");

            if (element is Process process)
            {
                Console.WriteLine($"  queue = {process.Queue}");
                Console.WriteLine($"  failures = {process.Failure}");
            }
        }
    }
}