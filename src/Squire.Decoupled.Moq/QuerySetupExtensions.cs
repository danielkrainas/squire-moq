namespace Squire.Decoupled.Moq
{
    using global::Moq.Language.Flow;
    using global::Moq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Squire.Decoupled.Queries;

    public static class QuerySetupExtensions
    {
        public static Mock<IDispatchQuery> Returns<TQuery, TReturn>(this QuerySetup<TQuery> target, TReturn value)
            where TQuery : class, IQuery<TReturn>
        {
            target.Mock
                .Setup(d => d.Execute(It.IsAny<TQuery>()))
                .Returns(value);
            return target.Mock;
        }

        public static Mock<IDispatchQuery> ReturnsNoData<TQuery, TModel>(this QuerySetup<TQuery> target)
            where TQuery : class, IQuery<IEnumerable<TModel>>
        {
            target.Mock
                .Setup(d => d.Execute(It.IsAny<TQuery>()))
                .Returns(Enumerable.Empty<TModel>());
            return target.Mock;
        }
    }
}
