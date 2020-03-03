using System;
using System.Linq.Expressions;

namespace CustomAutomapper
{
    public static class FactoryHelper<TInstance>
    {
        private static readonly Func<TInstance> createInstanceFunc =
            Expression.Lambda<Func<TInstance>>(Expression.New(typeof(TInstance))).Compile();

        //private static Func<TInstance> createInstanceFunc()
        //{
        //    NewExpression newExpression = Expression.New(typeof(TInstance));
        //    return Expression
        //            .Lambda<Func<TInstance>>(newExpression)
        //            .Compile();
        //}

        public static TInstance Instance => createInstanceFunc();
        //public static Func<TInstance> Instance = createInstanceFunc;
    }
}
