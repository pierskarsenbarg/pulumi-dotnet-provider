using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Pulumi.Experimental.Provider;

public class MyProvider : Provider
{
    readonly IHost _host;

    public MyProvider(IHost host)
    {
        _host = host;
    }

    public override Task<CheckResponse> Check(CheckRequest request, CancellationToken ct)
    {
        if (request.Type == "myprovider:index:MyResource")
        {
            return Task.FromResult(new CheckResponse() { Inputs = request.NewInputs });
        }

        throw new Exception($"Unknown resource type '{request.Type}'");
    }

    public override Task<CheckResponse> CheckConfig(CheckRequest request, CancellationToken ct)
    {
        return base.CheckConfig(request, ct);
    }

    public override Task<DiffResponse> DiffConfig(DiffRequest request, CancellationToken ct)
    {
        return Task.FromResult(new DiffResponse());
    }

    public override Task<ConfigureResponse> Configure(ConfigureRequest request, CancellationToken ct)
    {
        return Task.FromResult(new ConfigureResponse());
    }

    public override Task<GetSchemaResponse> GetSchema(GetSchemaRequest request, CancellationToken ct)
    {
        return base.GetSchema(request, ct);
    }

    public override Task<CreateResponse> Create(CreateRequest request, CancellationToken ct)
    {
        if (request.Type == "myprovider:index:MyResource")
        {
            var description = request.Properties["description"];
            var outputs = new Dictionary<string, PropertyValue>();
            outputs.Add("description", description);
            return Task.FromResult(new CreateResponse
            {
                Id = Guid.NewGuid().ToString(),
                Properties = outputs
            });
        }
        throw new Exception($"Unknown resource type '{request.Type}'");
    }

    public override Task<DiffResponse> Diff(DiffRequest request, CancellationToken ct)
    {
        if (request.Type == "myprovider:index:MyResource")
        {
            var changes = !request.OldState["description"].Equals(request.NewInputs["description"]);
            return Task.FromResult(new DiffResponse
            {
                Changes = changes,
                Replaces = new[] { "description" }
            });
        }
        throw new Exception($"Unknown resource type '{request.Type}'");
    }

    public override Task Delete(DeleteRequest request, CancellationToken ct)
    {
        return Task.CompletedTask;
    }

    public override Task<ReadResponse> Read(ReadRequest request, CancellationToken ct)
    {
        return Task.FromResult(new ReadResponse
        {
            Id = request.Id,
            Properties = request.Properties
        });
    }
}