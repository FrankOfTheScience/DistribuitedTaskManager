var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.DistribuitedTaskManager>("distribuitedtaskmanager");

builder.Build().Run();
