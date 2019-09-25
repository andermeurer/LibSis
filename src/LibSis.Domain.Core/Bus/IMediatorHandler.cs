using System.Threading.Tasks;
using LibSis.Domain.Core.Commands;
using LibSis.Domain.Core.Events;


namespace LibSis.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
