namespace Squire.Decoupled.Moq
{
    using global::Moq;
    using Squire.Decoupled.DomainEvents;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Squire.Validation;
    using System.Linq.Expressions;

    public class DomainEventMonitor<TEvent>
        where TEvent : class, IDomainEvent
    {
        private DomainEventMonitor()
        {
            this.HasEventFired = false;
            this.Mock = null;
        }

        public DomainEventMonitor(Mock<IDomainEventDispatcher> mock, Expression<Func<TEvent, bool>> match)
        {
            mock.VerifyParam("mock").IsNotNull();
            match.VerifyParam("match").IsNotNull();
            mock.Setup(d => d.Dispatch(It.Is<TEvent>(match)))
                .Callback(() => this.HasEventFired = true);
            this.Mock = mock;
        }

        public DomainEventMonitor(Mock<IDomainEventDispatcher> mock)
            : this()
        {
            mock.VerifyParam("mock").IsNotNull();
            mock.Setup(d => d.Dispatch(It.IsAny<TEvent>()))
                .Callback(() => this.HasEventFired = true);
            this.Mock = mock;
        }

        public IMock<IDomainEventDispatcher> Mock
        {
            get;
            private set;
        }

        public bool HasEventFired
        {
            get;
            private set;
        }
    }
}
