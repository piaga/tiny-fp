using TinyFp.Extensions;
using System;

namespace TinyFp.DataTypes
{
    public static class FlowerDeconstructorsExtensions
    {
        public static IFlowerStep<M, N> Deconstruct<T, M, N>(this IFlowerStep<T> @this, Func<T, Tuple<M, N>> map)
            => FlowerFactory.Create(() => @this.Expect(string.Empty).Map(map));
        public static IFlowerStep<M, N> Deconstruct<T, M, N>(this IFlowerStep<T> @this, Func<T, (M, N)> map)
            => FlowerFactory.Create(() => @this.Expect(string.Empty).Map(map));
    }
}
