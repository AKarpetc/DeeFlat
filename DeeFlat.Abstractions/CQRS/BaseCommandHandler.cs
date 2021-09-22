using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeFlat.Abstractions.CQRS
{
    /// <summary>
    /// Параметры команды
    /// </summary>
    public interface ICommand : IRequest
    {
    }

    /// <summary>
    /// Команда выполняющая операцию изменяющую состояние системы
    /// </summary>
    /// <typeparam name="TCommand">Параметры команды</typeparam>
    public abstract class BaseCommandHandler<TCommand> : AsyncRequestHandler<TCommand>
        where TCommand : ICommand
    {
    }
}
