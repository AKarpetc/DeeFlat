using MediatR;
using System.Threading.Tasks;

namespace DeeFlat.Core.Abstractions
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
