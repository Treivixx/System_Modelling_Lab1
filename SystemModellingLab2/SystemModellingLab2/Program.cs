using SystemModellingLab2;

var create = new Create("CREATE", 2.0);

var process = new Process("PROCESS", 1.0)
{
    MaxQueue = 5
};

create.NextElement = process;

var model = new Model([create, process]);

model.Simulate(1000);