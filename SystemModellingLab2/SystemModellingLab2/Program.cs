using SystemModellingLab2;

var create = new Create("CREATE", 2.0);

var process1 = new Process("PROCESS 1", 1.0)
{
    MaxQueue = 5
};

var process2 = new Process("PROCESS 2", 2.0, new List<Device>
{
    new Device()
})
{
    MaxQueue = 5
};

var process3 = new Process("PROCESS 3", 0.5)
{
    MaxQueue = 5
};

var dispose = new Dispose("DISPOSE");


create.NextElement = process1;
process1.Connections.Add(process2);
process2.Connections.Add(process3);
process2.Connections.Add(process1);
process3.Connections.Add(dispose);

var model = new Model([create, process1, process2, process3, dispose]);
model.Simulate(1000);
