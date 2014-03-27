namespace Squire.Decoupled.Moq
{
    using global::Moq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Squire.Validation;
    using Squire.Decoupled.Queries;

    public class QuerySetup<TQuery>
    {
        public QuerySetup(Mock<IDispatchQuery> mock)
        {
            mock.VerifyParam("mock").IsNotNull();
            this.Mock = mock;
        }

        public Mock<IDispatchQuery> Mock
        {
            get;
            private set;
        }
    }
}
