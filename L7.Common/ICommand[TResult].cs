using MediatR;

namespace L7.Common
{
    public interface ICommand<out TResult> : IRequest<TResult>
        where TResult : class
    {
    }
}