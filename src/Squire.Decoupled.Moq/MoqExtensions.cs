namespace Squire.Decoupled.Moq
{
    using Squire.Decoupled.Queries;
    using global::Moq;
    using global::Moq.Language.Flow;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Squire.Validation;
    using System.Linq.Expressions;
    using Squire.Decoupled.DomainEvents;

    public static class MoqExtensions
    {
        public static QuerySetup<T> Query<T>(this Mock<IDispatchQuery> mock)
        {
            return new QuerySetup<T>(mock);
        }

        public static IReturnsResult<T> ReturnsNothing<T, U>(this ISetup<T, IEnumerable<U>> setup)
            where T : class
        {
            setup.VerifyParam("setup").IsNotNull();
            var mock = new Mock<IDispatchQuery>();
            return setup.Returns(Enumerable.Empty<U>());
        }

        public static DomainEventMonitor<TEvent> ListenFor<TEvent>(this Mock<IDomainEventDispatcher> mock)
            where TEvent : class, IDomainEvent
        {
            return new DomainEventMonitor<TEvent>(mock);
        }
    }
}
