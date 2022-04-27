using TinyFp.DataTypes;
using System;

namespace TinyFp.Extensions
{
    public static partial class Functional
    {
        public static IFlowerStep<T> ToFlower<T>(this T @this)
            => FlowerFactory.Create(() => @this);

        public static IFlowerStep<B> ToFlower<A,B>(this A @this, Func<A,B> map)
            => FlowerFactory.Create(() => map(@this));

        public static IFlowerStep<M, N> ToFlower<M, N>(this Tuple<M, N> @this)
            => FlowerFactory.Create(@this);

        public static IFlowerStep<M, N> ToFlower<M, N>(this (M, N) @this)
            => FlowerFactory.Create(@this);

        public static IFlowerStep<M, N> ToFlower<T1, T2, M, N>(this Tuple<T1, T2> @this, Func<T1, T2, (M, N)> map)
            => FlowerFactory.Create(map(@this.Item1, @this.Item2));

        public static IFlowerStep<M, N> ToFlower<T1, T2, M, N>(this (T1, T2) @this, Func<T1, T2, (M, N)> map)
            => FlowerFactory.Create(map(@this.Item1, @this.Item2));
    }
}
