using MediatR;

namespace DeeFlat.Core.Abstractions
{
    /// <summary>
    /// Параметры запроса
    /// </summary>
    /// <typeparam name="TResult">Тип возвращаемого результата</typeparam>
    public interface IQuery<TResult> : IRequest<TResult>
    {
    }

    /// <summary>
    /// Запрос для получения данных
    /// </summary>
    /// <typeparam name="TQuery">Параметры запроса</typeparam>
    /// <typeparam name="TResult">Тип возвращаемого результата</typeparam>
    public abstract class BaseQueryHandler<TQuery, TResult> : RequestHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
    }
}
