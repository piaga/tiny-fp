using System;
using System.Linq;

namespace TinyFp.DataTypes
{
    public partial class FlowerStep<T> : IFlowerStep<T>
    {
        private AT InnerGuardLinq<AT>(AT defaultExpression, params (Predicate<T> evalExpression, AT expressionIfEvalIsTrue)[] guards)
            => guards.AsEnumerable()
                .Where(guard => guard.evalExpression((T)_state1))
                .Select(guard => guard.expressionIfEvalIsTrue)
                .DefaultIfEmpty(defaultExpression)
                .FirstOrDefault();

        private AT InnerGuardLinq<AT>(AT defaultExpression, params (Func<bool> evalExpression, AT expressionIfEvalIsTrue)[] guards)
            => guards.AsEnumerable()
                .Where(guard => guard.evalExpression())
                .Select(guard => guard.expressionIfEvalIsTrue)
                .DefaultIfEmpty(defaultExpression)
                .FirstOrDefault();


        public IFlowerStep<T> Guard(Action<T> defaultExpression, params (Predicate<T> evalExpression, Action<T> expressionIfEvalIsTrue)[] guards)
            => TryDelegate(InnerGuardLinq(defaultExpression, guards), _state1);
        public IFlowerStep<T> Guard(Func<T> defaultExpression, params (Func<bool> evalExpression, Func<T> expressionIfEvalIsTrue)[] guards)
            => TryDelegate(InnerGuardLinq(defaultExpression, guards));

        public IFlowerStep<T> Guard(Func<T> defaultExpression, params (Predicate<T> evalExpression, Func<T> expressionIfEvalIsTrue)[] guards)
            => TryDelegate(InnerGuardLinq(defaultExpression, guards));

        public IFlowerStep<T> Guard(Func<T, T> defaultExpression, params (Predicate<T> evalExpression, Func<T, T> expressionIfEvalIsTrue)[] guards)
            => TryDelegate(InnerGuardLinq(defaultExpression, guards), _state1);

        public IFlowerStep<N> Guard<N>(Func<N> defaultExpression, params (Func<bool> evalExpression, Func<N> expressionIfEvalIsTrue)[] guards)
            => TryDelegate<N>(InnerGuardLinq(defaultExpression, guards));

        public IFlowerStep<N> Guard<N>(Func<T, N> defaultExpression, params (Predicate<T> evalExpression, Func<T, N> expressionIfEvalIsTrue)[] guards)
            => TryDelegate<N>(InnerGuardLinq(defaultExpression, guards), _state1);
    }
}
