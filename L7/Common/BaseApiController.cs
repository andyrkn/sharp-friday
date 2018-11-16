using CSharpFunctionalExtensions;
using EnsureThat;
using L7.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace L7
{
    public class BaseApiController : Controller
    {
        private readonly IMediator mediator;

        public BaseApiController(IMediator mediator)
        {
            EnsureArg.IsNotNull(mediator);
            this.mediator = mediator;
        }

        protected Result DispatchCommand<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            var result = mediator.Send(command).Result;
            return result;
        }


        protected TResult DispatchCommand<TCommand, TResult>(TCommand command)
            where TResult : class 
            where TCommand : ICommand<TResult>
        {
            var result = mediator.Send(command).Result;
            return result;
        }

        protected TData DispatchQuery<TQuery, TData>(TQuery query)
            where TQuery : IQuery<TData>
        {
            return mediator.Send(query).Result;
        }
    }
}