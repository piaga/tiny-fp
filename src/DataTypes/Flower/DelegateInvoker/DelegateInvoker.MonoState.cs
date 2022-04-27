using TinyFp.Extensions;
using System;
using System.Threading.Tasks;
using static TinyFp.Prelude;

namespace TinyFp.DataTypes
{
    internal static partial class DelegateInvoker
    {
        private static FlowerStep<T> TryMatch<T>(this Try<FlowerState> @this, Delegate @delegate,object prevState)
            => @this.Match(_ => _ as FlowerStep<T>, ex => new FlowerStep<T>(ex, (@delegate, prevState)));

        private static FlowerStep<T> TryMatch<T>(this Try<FlowerStep<T>> @this,Delegate @delegate, object prevState)
            => @this.Match(_ => _, ex => new FlowerStep<T>(ex, (@delegate, prevState)));

        private static Task<FlowerStep<T>> TryMatchAsync<T>(this Try<Task<FlowerStep<T>>> @this, Delegate @delegate, object prevState)
            => @this.Match(_ => _, ex => Task.FromResult(new FlowerStep<T>(ex, (@delegate, prevState))));

        internal static FlowerStep<T> Invoke<T>(this FlowerStep<T> @this, Action action)
            => Try(() => @this.Tee(_ => action()))
                .TryMatch(action, @this._state1);

        internal static FlowerStep<T> Invoke<T>(this FlowerStep<T> @this, Action<T> action, params object[] @params)
            => Try(() => @this.Tee(_ => action((T)@params[0])))
                .TryMatch(action, @this._state1);

        internal static FlowerStep<M> Invoke<T, M>(this FlowerStep<T> @this, Func<M> func)
            => Try(() => typeof(T) == typeof(M) ?
                        @this.SetState(func()) :
                        new FlowerStep<M>().SetState(func()))
                .TryMatch<M>(func, @this._state1);

        internal static FlowerStep<M> Invoke<T, M>(this FlowerStep<T> @this, Func<T, M> func, params object[] @params)
            => Try(() => typeof(T).IsEquivalentTo(typeof(M)) ?
                    @this.SetState(func((T)@params[0])) :
                    new FlowerStep<M>().SetState(func((T)@params[0])))
                .TryMatch<M>(func, @this._state1);

        internal static FlowerStep<M> Invoke<TI1,TI2, M>(this FlowerStep<TI1> @this, Func<TI1, TI2, M> func, params object[] @params)
            => Try(() => typeof(TI1).IsEquivalentTo(typeof(M)) ?
                    @this.SetState(func((TI1)@params[0], (TI2)@params[1])) :
                    new FlowerStep<M>().SetState(func((TI1)@params[0], (TI2)@params[1])))
                .TryMatch<M>(func, @this._state1);

        internal static FlowerStep<M> Invoke<TI1, TI2, TI3, M>(this FlowerStep<TI1> @this, Func<TI1, TI2, TI3, M> func, params object[] @params)
            => Try(() => typeof(TI1).IsEquivalentTo(typeof(M)) ?
                    @this.SetState(func((TI1)@params[0], (TI2)@params[1], (TI3)@params[2])) :
                    new FlowerStep<M>().SetState(func((TI1)@params[0], (TI2)@params[1], (TI3)@params[2])))
                .TryMatch<M>(func, @this._state1);

        internal static FlowerStep<M> Invoke<TI1, TI2, TI3, TI4, M>(this FlowerStep<TI1> @this, Func<TI1, TI2, TI3, TI4, M> func, params object[] @params)
            => Try(() => typeof(TI1).IsEquivalentTo(typeof(M)) ?
                    @this.SetState(func((TI1)@params[0], (TI2)@params[1], (TI3)@params[2], (TI4)@params[3])) :
                    new FlowerStep<M>().SetState(func((TI1)@params[0], (TI2)@params[1], (TI3)@params[2], (TI4)@params[3])))
                .TryMatch<M>(func, @this._state1);

        internal static FlowerStep<M> Invoke<TI1, TI2, TI3, TI4, TI5, M>(this FlowerStep<TI1> @this, Func<TI1, TI2, TI3, TI4, TI5, M> func, params object[] @params)
            => Try(() => typeof(TI1).IsEquivalentTo(typeof(M)) ?
                    @this.SetState(func((TI1)@params[0], (TI2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4])) :
                    new FlowerStep<M>().SetState(func((TI1)@params[0], (TI2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4])))
                .TryMatch<M>(func, @this._state1);

        internal static FlowerStep<M> Invoke<TI1, TI2, TI3, TI4, TI5, TI6, M>(this FlowerStep<TI1> @this, Func<TI1, TI2, TI3, TI4, TI5, TI6, M> func, params object[] @params)
            => Try(() => typeof(TI1).IsEquivalentTo(typeof(M)) ?
                    @this.SetState(func((TI1)@params[0], (TI2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5])) :
                    new FlowerStep<M>().SetState(func((TI1)@params[0], (TI2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5])))
                .TryMatch<M>(func, @this._state1);

        internal static FlowerStep<M> Invoke<TI1, TI2, TI3, TI4, TI5, TI6,TI7, M>(this FlowerStep<TI1> @this, Func<TI1, TI2, TI3, TI4, TI5, TI6, TI7, M> func, params object[] @params)
            => Try(() => typeof(TI1).IsEquivalentTo(typeof(M)) ?
                    @this.SetState(func((TI1)@params[0], (TI2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6])) :
                    new FlowerStep<M>().SetState(func((TI1)@params[0], (TI2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6])))
                .TryMatch<M>(func, @this._state1);

        internal static FlowerStep<M> Invoke<TI1, TI2, TI3, TI4, TI5, TI6, TI7, TI8, M>(this FlowerStep<TI1> @this, Func<TI1, TI2, TI3, TI4, TI5, TI6, TI7, TI8, M> func, params object[] @params)
            => Try(() => typeof(TI1).IsEquivalentTo(typeof(M)) ?
                    @this.SetState(func((TI1)@params[0], (TI2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7])) :
                    new FlowerStep<M>().SetState(func((TI1)@params[0], (TI2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7])))
                .TryMatch<M>(func, @this._state1);

        internal static FlowerStep<M> Invoke<TI1, TI2, TI3, TI4, TI5, TI6, TI7, TI8, TI9, M>(this FlowerStep<TI1> @this, Func<TI1, TI2, TI3, TI4, TI5, TI6, TI7, TI8, TI9, M> func, params object[] @params)
            => Try(() => typeof(TI1).IsEquivalentTo(typeof(M)) ?
                    @this.SetState(func((TI1)@params[0], (TI2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7], (TI9)@params[8])) :
                    new FlowerStep<M>().SetState(func((TI1)@params[0], (TI2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7], (TI9)@params[8])))
                .TryMatch<M>(func, @this._state1);

        internal static FlowerStep<M> Invoke<TI1, TI2, TI3, TI4, TI5, TI6, TI7, TI8, TI9, TI10, M>(this FlowerStep<TI1> @this, Func<TI1, TI2, TI3, TI4, TI5, TI6, TI7, TI8, TI9, TI10, M> func, params object[] @params)
            => Try(() => typeof(TI1).IsEquivalentTo(typeof(M)) ?
                    @this.SetState(func((TI1)@params[0], (TI2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7], (TI9)@params[8], (TI10)@params[9])) :
                    new FlowerStep<M>().SetState(func((TI1)@params[0], (TI2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7], (TI9)@params[8], (TI10)@params[9])))
                .TryMatch<M>(func, @this._state1);

        internal static FlowerStep<M> Invoke<TI1, TI2, TI3, TI4, TI5, TI6, TI7, TI8, TI9, TI10, TI11, M>(this FlowerStep<TI1> @this, Func<TI1, TI2, TI3, TI4, TI5, TI6, TI7, TI8, TI9, TI10, TI11, M> func, params object[] @params)
            => Try(() => typeof(TI1).IsEquivalentTo(typeof(M)) ?
                    @this.SetState(func((TI1)@params[0], (TI2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7], (TI9)@params[8], (TI10)@params[9], (TI11)@params[10])) :
                    new FlowerStep<M>().SetState(func((TI1)@params[0], (TI2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7], (TI9)@params[8], (TI10)@params[9], (TI11)@params[10])))
                .TryMatch<M>(func, @this._state1);

        internal static FlowerStep<M> Invoke<TI1, TI2, TI3, TI4, TI5, TI6, TI7, TI8, TI9, TI10, TI11, TI12, M>(this FlowerStep<TI1> @this, Func<TI1, TI2, TI3, TI4, TI5, TI6, TI7, TI8, TI9, TI10, TI11, TI12, M> func, params object[] @params)
            => Try(() => typeof(TI1).IsEquivalentTo(typeof(M)) ?
                    @this.SetState(func((TI1)@params[0], (TI2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7], (TI9)@params[8], (TI10)@params[9], (TI11)@params[10], (TI12)@params[11])) :
                    new FlowerStep<M>().SetState(func((TI1)@params[0], (TI2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7], (TI9)@params[8], (TI10)@params[9], (TI11)@params[10], (TI12)@params[11])))
                .TryMatch<M>(func, @this._state1);

        internal static Task<FlowerStep<M>> Invoke<T, M>(this FlowerStep<T> @this, Func<Task<M>> func)
            => Try(async () => (typeof(T).IsEquivalentTo(typeof(M)) ?
                                @this.SetState(await func()) :
                            new FlowerStep<M>().SetState(await func())) as FlowerStep<M>)
                .TryMatchAsync(func, @this._state1);

        internal static Task<FlowerStep<T>> Invoke<T>(this FlowerStep<T> @this, Func<T, Task<T>> func, params object[] @params)
            => Try(async () => @this.SetState(await func((T)@params[0])) as FlowerStep<T>)
                .TryMatchAsync(func, @this._state1);

        internal static Task<FlowerStep<M>> Invoke<T, M>(this FlowerStep<T> @this, Func<T, Task<M>> func, params object[] @params)
            => Try(async () => ( typeof(T).IsEquivalentTo(typeof(M)) ?
                    @this.SetState(await func((T)@params[0])) :
                    new FlowerStep<M>().SetState(await func((T)@params[0]))) as FlowerStep<M>)
                .TryMatchAsync(func, @this._state1);

        internal static Task<FlowerStep<M>> Invoke<TI1, TI2, M>(this FlowerStep<TI1> @this, Func<TI1, TI2, Task<M>> func, params object[] @params)
            => Try(async () => (typeof(TI1).IsEquivalentTo(typeof(M)) ?
                    @this.SetState(await func((TI1)@params[0], (TI2)@params[1])) :
                    new FlowerStep<M>().SetState(await func((TI1)@params[0], (TI2)@params[1]))) as FlowerStep<M>)
                .TryMatchAsync(func, @this._state1);

        internal static Task<FlowerStep<M>> Invoke<TI1, TI2, TI3, M>(this FlowerStep<TI1> @this, Func<TI1, TI2, TI3, Task<M>> func, params object[] @params)
            => Try(async () => (typeof(TI1).IsEquivalentTo(typeof(M)) ?
                    @this.SetState(await func((TI1)@params[0], (TI2)@params[1], (TI3)@params[2])) :
                    new FlowerStep<M>().SetState(await func((TI1)@params[0], (TI2)@params[1], (TI3)@params[2]))) as FlowerStep<M>)
                .TryMatchAsync(func, @this._state1);

        internal static Task<FlowerStep<M>> Invoke<TI1, TI2, TI3, TI4, M>(this FlowerStep<TI1> @this, Func<TI1, TI2, TI3, TI4, Task<M>> func, params object[] @params)
            => Try(async () => (typeof(TI1).IsEquivalentTo(typeof(M)) ?
                    @this.SetState(await func((TI1)@params[0], (TI2)@params[1], (TI3)@params[2], (TI4)@params[3])) :
                    new FlowerStep<M>().SetState(await func((TI1)@params[0], (TI2)@params[1], (TI3)@params[2], (TI4)@params[3]))) as FlowerStep<M>)
                .TryMatchAsync(func, @this._state1);

        internal static Task<FlowerStep<M>> Invoke<TI1, TI2, TI3, TI4, TI5, M>(this FlowerStep<TI1> @this, Func<TI1, TI2, TI3, TI4, TI5, Task<M>> func, params object[] @params)
            => Try(async () => (typeof(TI1).IsEquivalentTo(typeof(M)) ?
                    @this.SetState(await func((TI1)@params[0], (TI2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4])) :
                    new FlowerStep<M>().SetState(await func((TI1)@params[0], (TI2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4]))) as FlowerStep<M>)
                .TryMatchAsync(func, @this._state1);

        internal static Task<FlowerStep<M>> Invoke<TI1, TI2, TI3, TI4, TI5, TI6, M>(this FlowerStep<TI1> @this, Func<TI1, TI2, TI3, TI4, TI5, TI6, Task<M>> func, params object[] @params)
            => Try(async () => (typeof(TI1).IsEquivalentTo(typeof(M)) ?
                    @this.SetState(await func((TI1)@params[0], (TI2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5])) :
                    new FlowerStep<M>().SetState(await func((TI1)@params[0], (TI2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5]))) as FlowerStep<M>)
                .TryMatchAsync(func, @this._state1);

        internal static Task<FlowerStep<M>> Invoke<TI1, TI2, TI3, TI4, TI5, TI6, TI7, M>(this FlowerStep<TI1> @this, Func<TI1, TI2, TI3, TI4, TI5, TI6, TI7, Task<M>> func, params object[] @params)
            => Try(async () => (typeof(TI1).IsEquivalentTo(typeof(M)) ?
                    @this.SetState(await func((TI1)@params[0], (TI2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6])) :
                    new FlowerStep<M>().SetState(await func((TI1)@params[0], (TI2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6]))) as FlowerStep<M>)
                .TryMatchAsync(func, @this._state1);

        internal static Task<FlowerStep<M>> Invoke<TI1, TI2, TI3, TI4, TI5, TI6, TI7, TI8, M>(this FlowerStep<TI1> @this, Func<TI1, TI2, TI3, TI4, TI5, TI6, TI7, TI8, Task<M>> func, params object[] @params)
            => Try(async () => (typeof(TI1).IsEquivalentTo(typeof(M)) ?
                    @this.SetState(await func((TI1)@params[0], (TI2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7])) :
                    new FlowerStep<M>().SetState(await func((TI1)@params[0], (TI2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7]))) as FlowerStep<M>)
                .TryMatchAsync(func, @this._state1);

        internal static Task<FlowerStep<M>> Invoke<TI1, TI2, TI3, TI4, TI5, TI6, TI7, TI8, TI9, M>(this FlowerStep<TI1> @this, Func<TI1, TI2, TI3, TI4, TI5, TI6, TI7, TI8, TI9, Task<M>> func, params object[] @params)
            => Try(async () => (typeof(TI1).IsEquivalentTo(typeof(M)) ?
                    @this.SetState(await func((TI1)@params[0], (TI2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7], (TI9)@params[8])) :
                    new FlowerStep<M>().SetState(await func((TI1)@params[0], (TI2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7], (TI9)@params[8]))) as FlowerStep<M>)
                .TryMatchAsync(func, @this._state1);

        internal static Task<FlowerStep<M>> Invoke<TI1, TI2, TI3, TI4, TI5, TI6, TI7, TI8, TI9, TI10, M>(this FlowerStep<TI1> @this, Func<TI1, TI2, TI3, TI4, TI5, TI6, TI7, TI8, TI9, TI10, Task<M>> func, params object[] @params)
            => Try(async () => (typeof(TI1).IsEquivalentTo(typeof(M)) ?
                    @this.SetState(await func((TI1)@params[0], (TI2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7], (TI9)@params[8], (TI10)@params[9])) :
                    new FlowerStep<M>().SetState(await func((TI1)@params[0], (TI2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7], (TI9)@params[8], (TI10)@params[9]))) as FlowerStep<M>)
                .TryMatchAsync(func, @this._state1);

        internal static Task<FlowerStep<M>> Invoke<TI1, TI2, TI3, TI4, TI5, TI6, TI7, TI8, TI9, TI10, TI11, M>(this FlowerStep<TI1> @this, Func<TI1, TI2, TI3, TI4, TI5, TI6, TI7, TI8, TI9, TI10, TI11, Task<M>> func, params object[] @params)
            => Try(async () => (typeof(TI1).IsEquivalentTo(typeof(M)) ?
                    @this.SetState(await func((TI1)@params[0], (TI2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7], (TI9)@params[8], (TI10)@params[9], (TI11)@params[10])) :
                    new FlowerStep<M>().SetState(await func((TI1)@params[0], (TI2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7], (TI9)@params[8], (TI10)@params[9], (TI11)@params[10]))) as FlowerStep<M>)
                .TryMatchAsync(func, @this._state1);

        internal static Task<FlowerStep<M>> Invoke<TI1, TI2, TI3, TI4, TI5, TI6, TI7, TI8, TI9, TI10, TI11, TI12, M>(this FlowerStep<TI1> @this, Func<TI1, TI2, TI3, TI4, TI5, TI6, TI7, TI8, TI9, TI10, TI11, TI12, Task<M>> func, params object[] @params)
            => Try(async () => (typeof(TI1).IsEquivalentTo(typeof(M)) ?
                    @this.SetState(await func((TI1)@params[0], (TI2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7], (TI9)@params[8], (TI10)@params[9], (TI11)@params[10], (TI12)@params[11])) :
                    new FlowerStep<M>().SetState(await func((TI1)@params[0], (TI2)@params[1], (TI3)@params[2], (TI4)@params[3], (TI5)@params[4], (TI6)@params[5], (TI7)@params[6], (TI8)@params[7], (TI9)@params[8], (TI10)@params[9], (TI11)@params[10], (TI12)@params[11]))) as FlowerStep<M>)
                .TryMatchAsync(func, @this._state1);
    }
}
