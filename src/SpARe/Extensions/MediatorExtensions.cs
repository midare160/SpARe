using MediatR;
using SpARe.Requests;

namespace SpARe.Extensions;

public static class MediatorExtensions
{
    public static Task Send<TRequest>(this IMediator mediator, CancellationToken cancellationToken = default)
        where TRequest : IParameterlessRequest<TRequest>
    {
        return mediator.Send(TRequest.Instance, cancellationToken);
    }
}
