using MediatR;

namespace SpARe.Requests;

public interface IParameterlessRequest<TSelf> : IRequest
{
    static abstract TSelf Instance { get; }
}
