using SystemModellingLab2;

var create = new Create("CREATE", 2.0);

var process1 = new Process("PROCESS 1", 1.0)
{
    MaxQueue = 5
};

var process2 = new Process("PROCESS 2", 2)
{
    MaxQueue = 5
};

var process3 = new Process("PROCESS 3", 0.5)
{
    MaxQueue = 5
};

var dispose = new Dispose("DISPOSE");


create.NextElement = process1;
process1.NextElement = process2;
process2.NextElement = process3;
process3.NextElement = dispose;

var model = new Model([create, process1, process2, process3, dispose]);
model.Simulate(1000);