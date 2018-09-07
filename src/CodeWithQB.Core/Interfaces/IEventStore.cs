using CodeWithQB.Core.Common;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace CodeWithQB.Core.Interfaces
{
    public interface IEventStore : IDisposable
    {
        void Save(AggregateRoot aggregateRoot);
        TAggregateRoot[] Query<TAggregateRoot>()
            where TAggregateRoot : AggregateRoot;

        ConcurrentDictionary<string, ConcurrentBag<AggregateRoot>> 
            UpdateState<TAggregateRoot>(Type type, TAggregateRoot aggregateRoot, Guid aggregateId)
            where TAggregateRoot : AggregateRoot;

        Task PersistStateAsync();
    }
}
