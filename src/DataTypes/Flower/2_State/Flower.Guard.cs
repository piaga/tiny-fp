using System;
using System.Linq;

namespace TinyFp.DataTypes
{
    public partial class FlowerStep<T1, T2> : IFlowerStep<T1, T2>
    {
        private AT InnerGuardLinq<AT>(AT defaultExpression, params (Func<T1, T2, bool> evalExpression, AT expressionIfEvalIsTrue)[] guards)
            => guards.AsEnumerable()
                .Where(guard => guard.evalExpression((T1)_state1, (T2)_state2))
                .Select(guard => guard.expressionIfEvalIsTrue)
                .DefaultIfEmpty(defaultExpression)
                .FirstOrDefault();

        private AT InnerGuardLinq<AT>(AT defaultExpression, params (Func<bool> evalExpression, AT expressionIfEvalIsTrue)[] guards)
            => guards.AsEnumerable()
                .Where(guard => guard.evalExpression())
                .Select(guard => guard.expressionIfEvalIsTrue)
                .DefaultIfEmpty(defaultExpression)
                .FirstOrDefault();


        public IFlowerStep<T1, T2> Guard(Action<T1, T2> defaultExpression, params (Func<T1, T2, bool> evalExpression, Action<T1, T2> expressionIfEvalIsTrue)[] guards)
            => TryDelegate(InnerGuardLinq(defaultExpression, guards), _state1, _state2);
        
        
        public IFlowerStep<M, N> Guard<M, N>(Func<T1, T2, Tuple<M, N>> defaultExpression, params (Func<bool> evalExpression, Func<T1, T2, Tuple<M, N>> expressionIfEvalIsTrue)[] guards)
            => TryDelegate<M, N>(InnerGuardLinq(defaultExpression, guards), _state1, _state2);
        public IFlowerStep<M, N> Guard<M, N>(Func<T1, T2, Tuple<M, N>> defaultExpression, params (Func<T1, T2, bool> evalExpression, Func<T1, T2, Tuple<M, N>> expressionIfEvalIsTrue)[] guards)
            => TryDelegate<M, N>(InnerGuardLinq(defaultExpression, guards), _state1, _state2);
        public IFlowerStep<M, N> Guard<M, N>(Func<T1, T2, (M, N)> defaultExpression, params (Func<bool> evalExpression, Func<T1, T2, (M, N)> expressionIfEvalIsTrue)[] guards)
            => TryDelegate<M, N>(InnerGuardLinq(defaultExpression, guards), _state1, _state2);
        public IFlowerStep<M, N> Guard<M, N>(Func<T1, T2, (M, N)> defaultExpression, params (Func<T1, T2, bool> evalExpression, Func<T1, T2, (M, N)> expressionIfEvalIsTrue)[] guards)
            => TryDelegate<M, N>(InnerGuardLinq(defaultExpression, guards), _state1, _state2);

    }
}
