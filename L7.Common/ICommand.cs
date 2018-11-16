using CSharpFunctionalExtensions;
using MediatR;

namespace L7.Common
{
    public interface ICommand : IRequest<Result>
    {
    }
}