using TinyFp.Extensions;
using System;

namespace TinyFp.DataTypes
{
    public static class FlowerConstructorsExtensions
    {
        public static IFlowerStep<T> Construct<M, N, T>(this IFlowerStep<M, N> @this, Func<M, N, T> map)
            => FlowerFactory.Create(() => @this.Expect(string.Empty).Map(_ => map(_.Item1, _.Item2)));
    }
}
