using System;

namespace TinyFp.DataTypes
{
    public partial class FlowerStep<T1, T2> : IFlowerStep<T1, T2>
    {
        public IFlowerStep<T1, T2> While(Func<T1, T2, bool> evalExpression, params Action<T1, T2>[] doStuffIfExpressionIsTrue)
            => Then((t1, t2) =>
            {
                while (evalExpression(t1, t2))
                    foreach (var action in doStuffIfExpressionIsTrue)
                        action(t1, t2);
                return new Tuple<T1, T2>(t1, t2);
            });

        public IFlowerStep<T1, T2> While(Func<T1, T2, bool> evalExpression, params Func<T1, T2, Tuple<T1, T2>>[] doStuffIfExpressionIsTrue)
         => Then((t1, t2) =>
         {
             while (evalExpression(t1, t2))
                 foreach (var func in doStuffIfExpressionIsTrue)
                     (t1, t2) = func(t1, t2);
             return new Tuple<T1, T2>(t1, t2);
         });

        public IFlowerStep<T1, T2> While(Func<T1, T2, bool> evalExpression, params Func<T1, T2, (T1, T2)>[] doStuffIfExpressionIsTrue)
         => Then((t1, t2) =>
         {
             while (evalExpression(t1, t2))
                 foreach (var func in doStuffIfExpressionIsTrue)
                     (t1, t2) = func(t1, t2);
             return new Tuple<T1, T2>(t1, t2);
         });
    }
}
