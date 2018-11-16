using MediatR;

namespace L7.Common
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}
