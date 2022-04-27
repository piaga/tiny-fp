using System;

namespace TinyFp.DataTypes
{
    public static class FlowerFactory
    {
        public static IFlowerStep<T> Create<T>(Func<T> f)
            => new FlowerStep<T>().TryDelegate(f);
        public static IFlowerStep<T> Create<T>(T item)
            => new FlowerStep<T>() { _state1 = item };
        public static IFlowerStep<T1, T2> Create<T1, T2>(Func<Tuple<T1, T2>> f)
            => new FlowerStep<T1, T2>().TryDelegate(f);
        public static IFlowerStep<T1, T2> Create<T1, T2>(Func<(T1, T2)> f)
            => new FlowerStep<T1, T2>().TryDelegate(f);
        public static IFlowerStep<T1, T2> Create<T1, T2>(Func<T1, T2, Tuple<T1, T2>> f)
            => new FlowerStep<T1, T2>().TryDelegate(f);
        public static IFlowerStep<T1, T2> Create<T1, T2>(Func<T1, T2, (T1, T2)> f)
            => new FlowerStep<T1, T2>().TryDelegate(f);
        public static IFlowerStep<T1, T2> Create<T1, T2>(Tuple<T1, T2> tuple)
            => new FlowerStep<T1, T2>() { _state1 = tuple.Item1, _state2 = tuple.Item2};
        public static IFlowerStep<T1, T2> Create<T1, T2>((T1, T2) tuple)
            => new FlowerStep<T1, T2>() { _state1 = tuple.Item1, _state2 = tuple.Item2 };
    }
}