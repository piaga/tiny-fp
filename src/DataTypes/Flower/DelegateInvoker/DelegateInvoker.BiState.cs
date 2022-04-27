using TinyFp.Extensions;
using System;
using System.Threading.Tasks;
using static TinyFp.Prelude;

namespace TinyFp.DataTypes
{
    internal static partial class DelegateInvoker
    {
        private static FlowerStep<T1, T2> TryMatch<T1, T2>(this Try<FlowerState> @this, Delegate @delegate,object prevState)
            => @this.Match(_ => _ as FlowerStep<T1, T2>, ex => new FlowerStep<T1, T2>(ex, (@delegate, prevState)));

        private static FlowerStep<T1, T2> TryMatch<T1, T2>(this Try<FlowerStep<T1, T2>> @this,Delegate @delegate, object prevState)
            => @this.Match(_ => _, ex => new FlowerStep<T1, T2>(ex, (@delegate, prevState)));

        private static Task<FlowerStep<T1, T2>> TryMatchAsync<T1, T2>(this Try<Task<FlowerStep<T1, T2>>> @this, Delegate @delegate, object prevState)
            => @this.Match(_ => _, ex => Task.FromResult(new FlowerStep<T1, T2>(ex, (@delegate, prevState))));

        internal static FlowerStep<T1, T2> Invoke<T1, T2>(this FlowerStep<T1, T2> @this, Action action)
            => Try(() => @this.Tee(_ => action()))
                .TryMatch(action, @this._state1);

        internal static FlowerStep<T1, T2> Invoke<T1, T2>(this FlowerStep<T1, T2> @this, Action<T1, T2> action, params object[] @params)
            => Try(() => @this.Tee(_ => action((T1)@params[0], (T2)@params[1])))
                .TryMatch(action, (@this._state1, @this._state2));

        internal static FlowerStep<M, N> Invoke<T1, T2, M, N>(this FlowerStep<T1, T2> @this, Func<Tuple<M,N>> func)
            => Try(() => typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
                        @this.SetState(func().ToArray()) :
                        new FlowerStep<M, N>().SetState(func().ToArray()))
                .TryMatch<M, N>(func, (@this._state1, @this._state2));

        internal static FlowerStep<M, N> Invoke<T1, T2, M, N>(this FlowerStep<T1, T2> @this, Func<(M, N)> func)
            => Try(() => typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
                        @this.SetState(func().ToArray()) :
                        new FlowerStep<M, N>().SetState(func().ToArray()))
                .TryMatch<M, N>(func, (@this._state1, @this._state2));

        internal static FlowerStep<M, N> Invoke<T1, T2, M, N>(this FlowerStep<T1, T2> @this, Func<T1, T2, Tuple<M, N>> func, params object[] @params)
            => Try(() => typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
                    @this.SetState(func((T1)@params[0],(T2)@params[1]).ToArray()) :
                    new FlowerStep<M, N>().SetState(func((T1)@params[0], (T2)@params[1]).ToArray()))
                .TryMatch<M, N>(func, (@this._state1, @this._state2));

        internal static FlowerStep<M, N> Invoke<T1, T2, M, N>(this FlowerStep<T1, T2> @this, Func<T1, T2,  (M, N)> func, params object[] @params)
            => Try(() => typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
                    @this.SetState(func((T1)@params[0], (T2)@params[1]).ToArray()) :
                    new FlowerStep<M, N>().SetState(func((T1)@params[0], (T2)@params[1]).ToArray()))
                .TryMatch<M, N>(func, (@this._state1, @this._state2));

        internal static FlowerStep<M, N> Invoke<T1, T2, TI3, M, N>(this FlowerStep<T1, T2> @this, Func<T1, T2, TI3, Tuple<M,N>> func, params object[] @params)
            => Try(() => typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
                    @this.SetState(func((T1)@params[0], (T2)@params[1], (TI3)@params[2]).ToArray()) :
                    new FlowerStep<M, N>().SetState(func((T1)@params[0], (T2)@params[1], (TI3)@params[2]).ToArray()))
                .TryMatch<M, N>(func, (@this._state1, @this._state2));

        internal static FlowerStep<M, N> Invoke<T1, T2, TI3, M, N>(this FlowerStep<T1, T2> @this, Func<T1, T2, TI3, (M, N)> func, params object[] @params)
            => Try(() => typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
                    @this.SetState(func((T1)@params[0], (T2)@params[1], (TI3)@params[2]).ToArray()) :
                    new FlowerStep<M, N>().SetState(func((T1)@params[0], (T2)@params[1], (TI3)@params[2]).ToArray()))
                .TryMatch<M, N>(func, (@this._state1, @this._state2));

        internal static FlowerStep<M, N> Invoke<T1, T2, TI3, TI4, M, N>(this FlowerStep<T1, T2> @this, Func<T1, T2, TI3, TI4, Tuple<M,N>> func, params object[] @params)
            => Try(() => typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
                    @this.SetState(func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3]).ToArray()) :
                    new FlowerStep<M, N>().SetState(func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3]).ToArray()))
                .TryMatch<M, N>(func, (@this._state1, @this._state2));

        internal static FlowerStep<M, N> Invoke<T1, T2, TI3, TI4, M, N>(this FlowerStep<T1, T2> @this, Func<T1, T2, TI3, TI4, (M, N)> func, params object[] @params)
            => Try(() => typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
                    @this.SetState(func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3]).ToArray()) :
                    new FlowerStep<M, N>().SetState(func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3]).ToArray()))
                .TryMatch<M, N>(func, (@this._state1, @this._state2));

        internal static FlowerStep<M, N> Invoke<T1, T2, TI3, TI4, TI5, M, N>(this FlowerStep<T1, T2> @this, Func<T1, T2, TI3, TI4, TI5, Tuple<M,N>> func, params object[] @params)
            => Try(() => typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
                    @this.SetState(func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4]).ToArray()) :
                    new FlowerStep<M, N>().SetState(func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4]).ToArray()))
                .TryMatch<M, N>(func, (@this._state1, @this._state2));

        internal static FlowerStep<M, N> Invoke<T1, T2, TI3, TI4, TI5, M, N>(this FlowerStep<T1, T2> @this, Func<T1, T2, TI3, TI4, TI5, (M, N)> func, params object[] @params)
            => Try(() => typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
                    @this.SetState(func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4]).ToArray()) :
                    new FlowerStep<M, N>().SetState(func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4]).ToArray()))
                .TryMatch<M, N>(func, (@this._state1, @this._state2));

        internal static FlowerStep<M, N> Invoke<T1, T2, TI3, TI4, TI5, TI6, M, N>(this FlowerStep<T1, T2> @this, Func<T1, T2, TI3, TI4, TI5, TI6, Tuple<M,N>> func, params object[] @params)
            => Try(() => typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
                    @this.SetState(func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5]).ToArray()) :
                    new FlowerStep<M, N>().SetState(func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5]).ToArray()))
                .TryMatch<M, N>(func, (@this._state1, @this._state2));

        internal static FlowerStep<M, N> Invoke<T1, T2, TI3, TI4, TI5, TI6, M, N>(this FlowerStep<T1, T2> @this, Func<T1, T2, TI3, TI4, TI5, TI6, (M, N)> func, params object[] @params)
            => Try(() => typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
                    @this.SetState(func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5]).ToArray()) :
                    new FlowerStep<M, N>().SetState(func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5]).ToArray()))
                .TryMatch<M, N>(func, (@this._state1, @this._state2));

        internal static FlowerStep<M, N> Invoke<T1, T2, TI3, TI4, TI5, TI6,TI7, M, N>(this FlowerStep<T1, T2> @this, Func<T1, T2, TI3, TI4, TI5, TI6, TI7, Tuple<M,N>> func, params object[] @params)
            => Try(() => typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
                    @this.SetState(func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6]).ToArray()) :
                    new FlowerStep<M, N>().SetState(func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6]).ToArray()))
                .TryMatch<M, N>(func, (@this._state1, @this._state2));

        internal static FlowerStep<M, N> Invoke<T1, T2, TI3, TI4, TI5, TI6, TI7, M, N>(this FlowerStep<T1, T2> @this, Func<T1, T2, TI3, TI4, TI5, TI6, TI7, (M, N)> func, params object[] @params)
            => Try(() => typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
                    @this.SetState(func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6]).ToArray()) :
                    new FlowerStep<M, N>().SetState(func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6]).ToArray()))
                .TryMatch<M, N>(func, (@this._state1, @this._state2));

        internal static FlowerStep<M, N> Invoke<T1, T2, TI3, TI4, TI5, TI6, TI7, TI8, M, N>(this FlowerStep<T1, T2> @this, Func<T1, T2, TI3, TI4, TI5, TI6, TI7, TI8, Tuple<M,N>> func, params object[] @params)
            => Try(() => typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
                    @this.SetState(func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7]).ToArray()) :
                    new FlowerStep<M, N>().SetState(func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7]).ToArray()))
                .TryMatch<M, N>(func, (@this._state1, @this._state2));

        internal static FlowerStep<M, N> Invoke<T1, T2, TI3, TI4, TI5, TI6, TI7, TI8, M, N>(this FlowerStep<T1, T2> @this, Func<T1, T2, TI3, TI4, TI5, TI6, TI7, TI8, (M, N)> func, params object[] @params)
            => Try(() => typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
                    @this.SetState(func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7]).ToArray()) :
                    new FlowerStep<M, N>().SetState(func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7]).ToArray()))
                .TryMatch<M, N>(func, (@this._state1, @this._state2));

        internal static FlowerStep<M, N> Invoke<T1, T2, TI3, TI4, TI5, TI6, TI7, TI8, TI9, M, N>(this FlowerStep<T1, T2> @this, Func<T1, T2, TI3, TI4, TI5, TI6, TI7, TI8, TI9, Tuple<M,N>> func, params object[] @params)
            => Try(() => typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
                    @this.SetState(func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7], (TI9)@params[8]).ToArray()) :
                    new FlowerStep<M, N>().SetState(func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7], (TI9)@params[8]).ToArray()))
                .TryMatch<M, N>(func, (@this._state1, @this._state2));

        internal static FlowerStep<M, N> Invoke<T1, T2, TI3, TI4, TI5, TI6, TI7, TI8, TI9, M, N>(this FlowerStep<T1, T2> @this, Func<T1, T2, TI3, TI4, TI5, TI6, TI7, TI8, TI9, (M, N)> func, params object[] @params)
            => Try(() => typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
                    @this.SetState(func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7], (TI9)@params[8]).ToArray()) :
                    new FlowerStep<M, N>().SetState(func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7], (TI9)@params[8]).ToArray()))
                .TryMatch<M, N>(func, (@this._state1, @this._state2));

        internal static FlowerStep<M, N> Invoke<T1, T2, TI3, TI4, TI5, TI6, TI7, TI8, TI9, T10, M, N>(this FlowerStep<T1, T2> @this, Func<T1, T2, TI3, TI4, TI5, TI6, TI7, TI8, TI9, T10, Tuple<M,N>> func, params object[] @params)
            => Try(() => typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
                    @this.SetState(func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7], (TI9)@params[8], (T10)@params[9]).ToArray()) :
                    new FlowerStep<M, N>().SetState(func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7], (TI9)@params[8], (T10)@params[9]).ToArray()))
                .TryMatch<M, N>(func, (@this._state1, @this._state2));

        internal static FlowerStep<M, N> Invoke<T1, T2, TI3, TI4, TI5, TI6, TI7, TI8, TI9, T10, M, N>(this FlowerStep<T1, T2> @this, Func<T1, T2, TI3, TI4, TI5, TI6, TI7, TI8, TI9, T10, (M, N)> func, params object[] @params)
            => Try(() => typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
                    @this.SetState(func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7], (TI9)@params[8], (T10)@params[9]).ToArray()) :
                    new FlowerStep<M, N>().SetState(func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7], (TI9)@params[8], (T10)@params[9]).ToArray()))
                .TryMatch<M, N>(func, (@this._state1, @this._state2));

        internal static FlowerStep<M, N> Invoke<T1, T2, TI3, TI4, TI5, TI6, TI7, TI8, TI9, T10, T11, M, N>(this FlowerStep<T1, T2> @this, Func<T1, T2, TI3, TI4, TI5, TI6, TI7, TI8, TI9, T10, T11, Tuple<M,N>> func, params object[] @params)
            => Try(() => typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
                    @this.SetState(func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7], (TI9)@params[8], (T10)@params[9], (T11)@params[10]).ToArray()) :
                    new FlowerStep<M, N>().SetState(func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7], (TI9)@params[8], (T10)@params[9], (T11)@params[10]).ToArray()))
                .TryMatch<M, N>(func, (@this._state1, @this._state2));

        internal static FlowerStep<M, N> Invoke<T1, T2, TI3, TI4, TI5, TI6, TI7, TI8, TI9, T10, T11, M, N>(this FlowerStep<T1, T2> @this, Func<T1, T2, TI3, TI4, TI5, TI6, TI7, TI8, TI9, T10, T11, (M, N)> func, params object[] @params)
            => Try(() => typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
                    @this.SetState(func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7], (TI9)@params[8], (T10)@params[9], (T11)@params[10]).ToArray()) :
                    new FlowerStep<M, N>().SetState(func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7], (TI9)@params[8], (T10)@params[9], (T11)@params[10]).ToArray()))
                .TryMatch<M, N>(func, (@this._state1, @this._state2));

        internal static FlowerStep<M, N> Invoke<T1, T2, TI3, TI4, TI5, TI6, TI7, TI8, TI9, T10, T11, T12, M, N>(this FlowerStep<T1, T2> @this, Func<T1, T2, TI3, TI4, TI5, TI6, TI7, TI8, TI9, T10, T11, T12, Tuple<M,N>> func, params object[] @params)
            => Try(() => typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
                    @this.SetState(func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7], (TI9)@params[8], (T10)@params[9], (T11)@params[10], (T12)@params[11]).ToArray()) :
                    new FlowerStep<M, N>().SetState(func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7], (TI9)@params[8], (T10)@params[9], (T11)@params[10], (T12)@params[11]).ToArray()))
                .TryMatch<M, N>(func, (@this._state1, @this._state2));

        internal static FlowerStep<M, N> Invoke<T1, T2, TI3, TI4, TI5, TI6, TI7, TI8, TI9, T10, T11, T12, M, N>(this FlowerStep<T1, T2> @this, Func<T1, T2, TI3, TI4, TI5, TI6, TI7, TI8, TI9, T10, T11, T12, (M, N)> func, params object[] @params)
            => Try(() => typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
                    @this.SetState(func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7], (TI9)@params[8], (T10)@params[9], (T11)@params[10], (T12)@params[11]).ToArray()) :
                    new FlowerStep<M, N>().SetState(func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7], (TI9)@params[8], (T10)@params[9], (T11)@params[10], (T12)@params[11]).ToArray()))
                .TryMatch<M, N>(func, (@this._state1, @this._state2));

        internal static Task<FlowerStep<M, N>> Invoke<T1, T2, M, N>(this FlowerStep<T1, T2> @this, Func<Task<Tuple<M, N>>> func)
            => Try(async () => (typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
                                @this.SetState(await func()) :
                            new FlowerStep<M, N>().SetState(await func())) as FlowerStep<M, N>)
                .TryMatchAsync(func, (@this._state1, @this._state2));

        internal static Task<FlowerStep<M, N>> Invoke<T1, T2, M, N>(this FlowerStep<T1, T2> @this, Func<Task<(M, N)>> func)
            => Try(async () => (typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
                                @this.SetState(await func()) :
                            new FlowerStep<M, N>().SetState(await func())) as FlowerStep<M, N>)
                .TryMatchAsync(func, (@this._state1, @this._state2));

        internal static Task<FlowerStep<T1, T2>> Invoke<T1, T2>(this FlowerStep<T1, T2> @this, Func<T1, T2, Task<Tuple<T1, T2>>> func, params object[] @params)
            => Try(async () => @this.SetState((await func((T1)@params[0], (T2)@params[1])).ToArray()) as FlowerStep<T1, T2>)
                .TryMatchAsync(func, (@this._state1, @this._state2));

        internal static Task<FlowerStep<T1, T2>> Invoke<T1, T2>(this FlowerStep<T1, T2> @this, Func<T1, T2, Task<(T1, T2)>> func, params object[] @params)
            => Try(async () => @this.SetState((await func((T1)@params[0], (T2)@params[1])).ToArray()) as FlowerStep<T1, T2>)
                .TryMatchAsync(func, (@this._state1, @this._state2));

        internal static Task<FlowerStep<M, N>> Invoke<T1, T2, M, N>(this FlowerStep<T1, T2> @this, Func<T1, T2, Task<Tuple<M, N>>> func, params object[] @params)
            => Try(async () => ( typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
                    @this.SetState((await func((T1)@params[0], (T2)@params[1])).ToArray()) :
                    new FlowerStep<M, N>().SetState((await func((T1)@params[0], (T2)@params[1])).ToArray())) as FlowerStep<M, N>)
                .TryMatchAsync(func, (@this._state1, @this._state2));

        internal static Task<FlowerStep<M, N>> Invoke<T1, T2, M, N>(this FlowerStep<T1, T2> @this, Func<T1, T2, Task<(M, N)>> func, params object[] @params)
            => Try(async () => (typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
                    @this.SetState((await func((T1)@params[0], (T2)@params[1])).ToArray()) :
                    new FlowerStep<M, N>().SetState((await func((T1)@params[0], (T2)@params[1])).ToArray())) as FlowerStep<M, N>)
                .TryMatchAsync(func, (@this._state1, @this._state2));

        //internal static Task<FlowerStep<M, N>> Invoke<T1, T2, M, N>(this FlowerStep<T1, T2> @this, Func<T1, T2, Task<Tuple<M, N>>> func, params object[] @params)
        //    => Try(async () => (typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
        //            @this.SetState((await func((T1)@params[0], (T2)@params[1])).ToArray()) :
        //            new FlowerStep<M, N>().SetState(await func((T1)@params[0], (T2)@params[1]))) as FlowerStep<M, N>)
        //        .TryMatchAsync(func, (@this._state1, @this._state2));

        internal static Task<FlowerStep<M, N>> Invoke<T1, T2, TI3, M, N>(this FlowerStep<T1, T2> @this, Func<T1, T2, TI3, Task<Tuple<M, N>>> func, params object[] @params)
            => Try(async () => (typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
                    @this.SetState((await func((T1)@params[0], (T2)@params[1], (TI3)@params[2])).ToArray()) :
                    new FlowerStep<M, N>().SetState((await func((T1)@params[0], (T2)@params[1], (TI3)@params[2])).ToArray())) as FlowerStep<M, N>)
                .TryMatchAsync(func, (@this._state1, @this._state2));

        internal static Task<FlowerStep<M, N>> Invoke<T1, T2, TI3, M, N>(this FlowerStep<T1, T2> @this, Func<T1, T2, TI3, Task<(M, N)>> func, params object[] @params)
            => Try(async () => (typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
                    @this.SetState((await func((T1)@params[0], (T2)@params[1], (TI3)@params[2])).ToArray()) :
                    new FlowerStep<M, N>().SetState((await func((T1)@params[0], (T2)@params[1], (TI3)@params[2])).ToArray())) as FlowerStep<M, N>)
                .TryMatchAsync(func, (@this._state1, @this._state2));

        internal static Task<FlowerStep<M, N>> Invoke<T1, T2, TI3, TI4, M, N>(this FlowerStep<T1, T2> @this, Func<T1, T2, TI3, TI4, Task<Tuple<M, N>>> func, params object[] @params)
            => Try(async () => (typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
                    @this.SetState((await func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3])).ToArray()) :
                    new FlowerStep<M, N>().SetState((await func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3])).ToArray())) as FlowerStep<M, N>)
                .TryMatchAsync(func, (@this._state1, @this._state2));

        internal static Task<FlowerStep<M, N>> Invoke<T1, T2, TI3, TI4, M, N>(this FlowerStep<T1, T2> @this, Func<T1, T2, TI3, TI4, Task<(M, N)>> func, params object[] @params)
            => Try(async () => (typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
                    @this.SetState((await func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3])).ToArray()) :
                    new FlowerStep<M, N>().SetState((await func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3])).ToArray())) as FlowerStep<M, N>)
                .TryMatchAsync(func, (@this._state1, @this._state2));

        internal static Task<FlowerStep<M, N>> Invoke<T1, T2, TI3, TI4, TI5, M, N>(this FlowerStep<T1, T2> @this, Func<T1, T2, TI3, TI4, TI5, Task<Tuple<M, N>>> func, params object[] @params)
            => Try(async () => (typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
                    @this.SetState((await func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4])).ToArray()) :
                    new FlowerStep<M, N>().SetState((await func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4])).ToArray())) as FlowerStep<M, N>)
                .TryMatchAsync(func, (@this._state1, @this._state2));

        internal static Task<FlowerStep<M, N>> Invoke<T1, T2, TI3, TI4, TI5, M, N>(this FlowerStep<T1, T2> @this, Func<T1, T2, TI3, TI4, TI5, Task<(M, N)>> func, params object[] @params)
            => Try(async () => (typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
                    @this.SetState((await func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4])).ToArray()) :
                    new FlowerStep<M, N>().SetState((await func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4])).ToArray())) as FlowerStep<M, N>)
                .TryMatchAsync(func, (@this._state1, @this._state2));

        internal static Task<FlowerStep<M, N>> Invoke<T1, T2, TI3, TI4, TI5, TI6, M, N>(this FlowerStep<T1, T2> @this, Func<T1, T2, TI3, TI4, TI5, TI6, Task<Tuple<M, N>>> func, params object[] @params)
            => Try(async () => (typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
                    @this.SetState((await func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5])).ToArray()) :
                    new FlowerStep<M, N>().SetState((await func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5])).ToArray())) as FlowerStep<M, N>)
                .TryMatchAsync(func, (@this._state1, @this._state2));

        internal static Task<FlowerStep<M, N>> Invoke<T1, T2, TI3, TI4, TI5, TI6, M, N>(this FlowerStep<T1, T2> @this, Func<T1, T2, TI3, TI4, TI5, TI6, Task<(M, N)>> func, params object[] @params)
            => Try(async () => (typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
                    @this.SetState((await func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5])).ToArray()) :
                    new FlowerStep<M, N>().SetState((await func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5])).ToArray())) as FlowerStep<M, N>)
                .TryMatchAsync(func, (@this._state1, @this._state2));

        internal static Task<FlowerStep<M, N>> Invoke<T1, T2, TI3, TI4, TI5, TI6, TI7, M, N>(this FlowerStep<T1, T2> @this, Func<T1, T2, TI3, TI4, TI5, TI6, TI7, Task<Tuple<M, N>>> func, params object[] @params)
            => Try(async () => (typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
                    @this.SetState((await func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6])).ToArray()) :
                    new FlowerStep<M, N>().SetState((await func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6])).ToArray())) as FlowerStep<M, N>)
                .TryMatchAsync(func, (@this._state1, @this._state2));

        internal static Task<FlowerStep<M, N>> Invoke<T1, T2, TI3, TI4, TI5, TI6, TI7, M, N>(this FlowerStep<T1, T2> @this, Func<T1, T2, TI3, TI4, TI5, TI6, TI7, Task<(M, N)>> func, params object[] @params)
            => Try(async () => (typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
                    @this.SetState((await func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6])).ToArray()) :
                    new FlowerStep<M, N>().SetState((await func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6])).ToArray())) as FlowerStep<M, N>)
                .TryMatchAsync(func, (@this._state1, @this._state2));

        internal static Task<FlowerStep<M, N>> Invoke<T1, T2, TI3, TI4, TI5, TI6, TI7, TI8, M, N>(this FlowerStep<T1, T2> @this, Func<T1, T2, TI3, TI4, TI5, TI6, TI7, TI8, Task<Tuple<M, N>>> func, params object[] @params)
            => Try(async () => (typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
                    @this.SetState((await func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7])).ToArray()) :
                    new FlowerStep<M, N>().SetState((await func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7])).ToArray())) as FlowerStep<M, N>)
                .TryMatchAsync(func, (@this._state1, @this._state2));

        internal static Task<FlowerStep<M, N>> Invoke<T1, T2, TI3, TI4, TI5, TI6, TI7, TI8, M, N>(this FlowerStep<T1, T2> @this, Func<T1, T2, TI3, TI4, TI5, TI6, TI7, TI8, Task<(M, N)>> func, params object[] @params)
            => Try(async () => (typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
                    @this.SetState((await func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7])).ToArray()) :
                    new FlowerStep<M, N>().SetState((await func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7])).ToArray())) as FlowerStep<M, N>)
                .TryMatchAsync(func, (@this._state1, @this._state2));

        internal static Task<FlowerStep<M, N>> Invoke<T1, T2, TI3, TI4, TI5, TI6, TI7, TI8, TI9, M, N>(this FlowerStep<T1, T2> @this, Func<T1, T2, TI3, TI4, TI5, TI6, TI7, TI8, TI9, Task<Tuple<M, N>>> func, params object[] @params)
            => Try(async () => (typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
                    @this.SetState((await func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7], (TI9)@params[8])).ToArray()) :
                    new FlowerStep<M, N>().SetState((await func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7], (TI9)@params[8])).ToArray())) as FlowerStep<M, N>)
                .TryMatchAsync(func, (@this._state1, @this._state2));

        internal static Task<FlowerStep<M, N>> Invoke<T1, T2, TI3, TI4, TI5, TI6, TI7, TI8, TI9, M, N>(this FlowerStep<T1, T2> @this, Func<T1, T2, TI3, TI4, TI5, TI6, TI7, TI8, TI9, Task<(M, N)>> func, params object[] @params)
            => Try(async () => (typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
                    @this.SetState((await func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7], (TI9)@params[8])).ToArray()) :
                    new FlowerStep<M, N>().SetState((await func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7], (TI9)@params[8])).ToArray())) as FlowerStep<M, N>)
                .TryMatchAsync(func, (@this._state1, @this._state2));

        internal static Task<FlowerStep<M, N>> Invoke<T1, T2, TI3, TI4, TI5, TI6, TI7, TI8, TI9, T10, M, N>(this FlowerStep<T1, T2> @this, Func<T1, T2, TI3, TI4, TI5, TI6, TI7, TI8, TI9, T10, Task<Tuple<M, N>>> func, params object[] @params)
            => Try(async () => (typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
                    @this.SetState((await func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7], (TI9)@params[8], (T10)@params[9])).ToArray()) :
                    new FlowerStep<M, N>().SetState((await func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7], (TI9)@params[8], (T10)@params[9])).ToArray())) as FlowerStep<M, N>)
                .TryMatchAsync(func, (@this._state1, @this._state2));

        internal static Task<FlowerStep<M, N>> Invoke<T1, T2, TI3, TI4, TI5, TI6, TI7, TI8, TI9, T10, M, N>(this FlowerStep<T1, T2> @this, Func<T1, T2, TI3, TI4, TI5, TI6, TI7, TI8, TI9, T10, Task<(M, N)>> func, params object[] @params)
            => Try(async () => (typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
                    @this.SetState((await func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7], (TI9)@params[8], (T10)@params[9])).ToArray()) :
                    new FlowerStep<M, N>().SetState((await func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7], (TI9)@params[8], (T10)@params[9])).ToArray())) as FlowerStep<M, N>)
                .TryMatchAsync(func, (@this._state1, @this._state2));

        internal static Task<FlowerStep<M, N>> Invoke<T1, T2, TI3, TI4, TI5, TI6, TI7, TI8, TI9, T10, T11, M, N>(this FlowerStep<T1, T2> @this, Func<T1, T2, TI3, TI4, TI5, TI6, TI7, TI8, TI9, T10, T11, Task<Tuple<M, N>>> func, params object[] @params)
            => Try(async () => (typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
                    @this.SetState((await func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7], (TI9)@params[8], (T10)@params[9], (T11)@params[10])).ToArray()) :
                    new FlowerStep<M, N>().SetState((await func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7], (TI9)@params[8], (T10)@params[9], (T11)@params[10])).ToArray())) as FlowerStep<M, N>)
                .TryMatchAsync(func, (@this._state1, @this._state2));

        internal static Task<FlowerStep<M, N>> Invoke<T1, T2, TI3, TI4, TI5, TI6, TI7, TI8, TI9, T10, T11, M, N>(this FlowerStep<T1, T2> @this, Func<T1, T2, TI3, TI4, TI5, TI6, TI7, TI8, TI9, T10, T11, Task<(M, N)>> func, params object[] @params)
            => Try(async () => (typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
                    @this.SetState((await func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7], (TI9)@params[8], (T10)@params[9], (T11)@params[10])).ToArray()) :
                    new FlowerStep<M, N>().SetState((await func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7], (TI9)@params[8], (T10)@params[9], (T11)@params[10])).ToArray())) as FlowerStep<M, N>)
                .TryMatchAsync(func, (@this._state1, @this._state2));

        internal static Task<FlowerStep<M, N>> Invoke<T1, T2, TI3, TI4, TI5, TI6, TI7, TI8, TI9, T10, T11, T12, M, N>(this FlowerStep<T1, T2> @this, Func<T1, T2, TI3, TI4, TI5, TI6, TI7, TI8, TI9, T10, T11, T12, Task<Tuple<M, N>>> func, params object[] @params)
            => Try(async () => (typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
                    @this.SetState((await func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7], (TI9)@params[8], (T10)@params[9], (T11)@params[10], (T12)@params[11])).ToArray()) :
                    new FlowerStep<M, N>().SetState((await func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7], (TI9)@params[8], (T10)@params[9], (T11)@params[10], (T12)@params[11])).ToArray())) as FlowerStep<M, N>)
                .TryMatchAsync(func, (@this._state1, @this._state2));

        internal static Task<FlowerStep<M, N>> Invoke<T1, T2, TI3, TI4, TI5, TI6, TI7, TI8, TI9, T10, T11, T12, M, N>(this FlowerStep<T1, T2> @this, Func<T1, T2, TI3, TI4, TI5, TI6, TI7, TI8, TI9, T10, T11, T12, Task<(M, N)>> func, params object[] @params)
            => Try(async () => (typeof(T1).IsEquivalentTo(typeof(M)) && typeof(T2).IsEquivalentTo(typeof(N)) ?
                    @this.SetState((await func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7], (TI9)@params[8], (T10)@params[9], (T11)@params[10], (T12)@params[11])).ToArray()) :
                    new FlowerStep<M, N>().SetState((await func((T1)@params[0], (T2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7], (TI9)@params[8], (T10)@params[9], (T11)@params[10], (T12)@params[11])).ToArray())) as FlowerStep<M, N>)
                .TryMatchAsync(func, (@this._state1, @this._state2));
    }
}
