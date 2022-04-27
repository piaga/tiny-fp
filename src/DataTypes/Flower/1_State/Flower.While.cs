using System;

namespace TinyFp.DataTypes
{
    public partial class FlowerStep<T> : IFlowerStep<T>
    {
        public IFlowerStep<T> While(Predicate<T> evalExpression, params Action<T>[] doStuffIfExpressionIsTrue)
            => this.Then(_ =>
            {
                while (evalExpression(_))
                    foreach (var action in doStuffIfExpressionIsTrue)
                        action(_);
                return _;
            });

        public IFlowerStep<T> While(Predicate<T> evalExpression, params Func<T, T>[] doStuffIfExpressionIsTrue)
         => this.Then(_ =>
         {
             while (evalExpression(_))
                 foreach (var action in doStuffIfExpressionIsTrue)
                     _ = action(_);
             return _;
         });
    }
}
