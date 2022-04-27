using System;
using System.Linq;
using System.Threading.Tasks;

namespace TinyFp.DataTypes
{
    public partial class FlowerStep<T1, T2>
    {


        public new FlowerStep<T1, T2> TryDelegate(Delegate @delegate, params object[] @params)
            => _exception == default ?
                    @delegate.Method.GetParameters().Length switch
                    {
                        0 => @delegate.Method.ReturnType == typeof(void) ?
                                this.Invoke((Action)@delegate) :
                                (@delegate is Func<Tuple<T1, T2>> ? 
                                    this.Invoke((Func<Tuple<T1,T2>>)@delegate):
                                    this.Invoke((Func<(T1, T2)>) @delegate)
                                ),
                        _ => @delegate.Method.ReturnType == typeof(void) ?
                                this.Invoke((Action<T1, T2>)@delegate, @params) :
                                @delegate is Func<T1, T2, Tuple<T1, T2>> ?
                                    this.Invoke(@delegate as Func<T1, T2, Tuple<T1, T2>>, @params) :
                                    this.Invoke(@delegate as Func<T1, T2, (T1, T2)>, @params)
                    } :
                    new FlowerStep<T1, T2>(this);

        public new FlowerStep<M, N> TryDelegate<M, N>(Delegate @delegate, params object[] @params)
            => _exception == default ?
                    @delegate.Method.GetParameters().Length switch
                    {
                        0 => this.Invoke((Func<Tuple<M, N>>)@delegate),
                        _ =>  @delegate switch
                        {
                            Func<T1, T2, Tuple<M, N>>  tuple => this.Invoke(tuple, @params),
                            _ => this.Invoke((Func<T1, T2, (M, N)>) @delegate, @params)
                        }       
                    } :
                    new FlowerStep<M, N>(this);

        public new FlowerStep<M, N> TryDelegate<T3, M, N>(Delegate @delegate, params object[] @params)
            => _exception == default ?
                @delegate switch
                {
                    Func<T1, T2, T3, Tuple<M, N>> tuple => this.Invoke(tuple, @params),
                    _ => this.Invoke((Func<T1, T2, T3, (M, N)>)@delegate, @params)
                }:
                new FlowerStep<M, N>(this);

        public new FlowerStep<M, N> TryDelegate<T3, T4, M, N>(Delegate @delegate, params object[] @params)
            => _exception == default ?
                @delegate switch
                {
                    Func<T1, T2, T3, T4, Tuple<M, N>> tuple => this.Invoke(tuple, @params),
                    _ => this.Invoke((Func<T1, T2, T3, T4, (M, N)>)@delegate, @params)
                } :
                new FlowerStep<M, N>(this);

        public new FlowerStep<M, N> TryDelegate<T3, T4, T5, M, N>(Delegate @delegate, params object[] @params)
            => _exception == default ?
                @delegate switch
                {
                    Func<T1, T2, T3, T4, T5, Tuple<M, N>> tuple => this.Invoke(tuple, @params),
                    _ => this.Invoke((Func<T1, T2, T3, T4, T5, (M, N)>)@delegate, @params)
                } :
                new FlowerStep<M, N>(this);

        public new FlowerStep<M, N> TryDelegate<T3, T4, T5, T6, M, N>(Delegate @delegate, params object[] @params)
            => _exception == default ?
                @delegate switch
                {
                    Func<T1, T2, T3, T4, T5, T6, Tuple<M, N>> tuple => this.Invoke(tuple, @params),
                    _ => this.Invoke((Func<T1, T2, T3, T4, T5, T6, (M, N)>)@delegate, @params)
                } :
                new FlowerStep<M, N>(this);

        public new FlowerStep<M, N> TryDelegate<T3, T4, T5, T6, T7, M, N>(Delegate @delegate, params object[] @params)
            => _exception == default ?
                @delegate switch
                {
                    Func<T1, T2, T3, T4, T5, T6, T7, Tuple<M, N>> tuple => this.Invoke(tuple, @params),
                    _ => this.Invoke((Func<T1, T2, T3, T4, T5, T6, T7, (M, N)>)@delegate, @params)
                } :
                new FlowerStep<M, N>(this);

        public new FlowerStep<M, N> TryDelegate<T3, T4, T5, T6, T7, T8, M, N>(Delegate @delegate, params object[] @params)
            => _exception == default ?
                @delegate switch
                {
                    Func<T1, T2, T3, T4, T5, T6, T7, T8, Tuple<M, N>> tuple => this.Invoke(tuple, @params),
                    _ => this.Invoke((Func<T1, T2, T3, T4, T5, T6, T7, T8, (M, N)>)@delegate, @params)
                } :
                new FlowerStep<M, N>(this);

        public new FlowerStep<M, N> TryDelegate<T3, T4, T5, T6, T7, T8, T9, M, N>(Delegate @delegate, params object[] @params)
            => _exception == default ?
                @delegate switch
                {
                    Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Tuple<M, N>> tuple => this.Invoke(tuple, @params),
                    _ => this.Invoke((Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, (M, N)>)@delegate, @params)
                } :
                new FlowerStep<M, N>(this);

        public new FlowerStep<M, N> TryDelegate<T3, T4, T5, T6, T7, T8, T9, T10, M, N>(Delegate @delegate, params object[] @params)
            => _exception == default ?
                @delegate switch
                {
                    Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Tuple<M, N>> tuple => this.Invoke(tuple, @params),
                    _ => this.Invoke((Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, (M, N)>)@delegate, @params)
                } :
                new FlowerStep<M, N>(this);

        public new FlowerStep<M, N> TryDelegate<T3, T4, T5, T6, T7, T8, T9, T10, T11, M, N>(Delegate @delegate, params object[] @params)
            => _exception == default ?
                @delegate switch
                {
                    Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Tuple<M, N>> tuple => this.Invoke(tuple, @params),
                    _ => this.Invoke((Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, (M, N)>)@delegate, @params)
                } :
                new FlowerStep<M, N>(this);

        public new FlowerStep<M, N> TryDelegate<T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, M, N>(Delegate @delegate, params object[] @params)
            => _exception == default ?
                @delegate switch
                {
                    Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Tuple<M, N>> tuple => this.Invoke(tuple, @params),
                    _ => this.Invoke((Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, (M, N)>)@delegate, @params)
                } :
                new FlowerStep<M, N>(this);

        public FlowerStep<T1, T2> TryDelegate(Action<T1, T2>[] actions)
            => _exception == default ? 
                actions.AsEnumerable()
                .Aggregate(this, (step, action)=> step.Invoke(action, step._state1, step._state2)) :
                new FlowerStep<T1, T2>(this);

        public FlowerStep<T1, T2> TryDelegate(Func<T1, T2, Tuple<T1, T2>>[] functions)
            => _exception == default ?
                functions.AsEnumerable()
                .Aggregate(this, (step, function) => step.Invoke(function, step._state1, step._state2)) :
            new FlowerStep<T1, T2>(this);

        public FlowerStep<T1, T2> TryDelegate(Func<T1, T2, (T1, T2)>[] functions)
            => _exception == default ?
                functions.AsEnumerable()
                .Aggregate(this, (step, function) => step.Invoke(function, step._state1, step._state2)) :
            new FlowerStep<T1, T2>(this);

        public new FlowerStep<M, N> TryDelegateAsync<M, N>(Delegate @delegate, params object[] @params)
            => _exception == default ?
            @delegate.Method.GetParameters().Length switch
            {
                0 => (@delegate switch
                {
                    Func<Task<Tuple<M, N>>> tuple => this.Invoke(tuple),
                    _ => this.Invoke((Func<Task<(M, N)>>)@delegate)
                }).Result,
                _ => (@delegate switch
                {
                    Func<T1, T2, Task<Tuple<M, N>>> tuple => this.Invoke(tuple, @params),
                    _ => this.Invoke((Func<T1, T2, Task<(M, N)>>)@delegate, @params)
                }).Result
            } :
            new FlowerStep<M, N>(this);

        //public FlowerStep<M, N> TryDelegateAsync<M, N>(Delegate @delegate)
        //    => _exception == default ?
        //    (@delegate switch
        //    {
        //        Func<T1, T2, Task<Tuple<M, N>>> tuple => this.Invoke(tuple),
        //        _ => this.Invoke((Func<T1, T2, Task<(M, N)>>)@delegate)
        //    }).Result :
            //new FlowerStep<M, N>(this);

        public new FlowerStep<M, N> TryDelegateAsync<T3, M, N>(Delegate @delegate, params object[] @params)
            => _exception == default ?
            (@delegate switch
            {
                Func<T1, T2, T3, Task<Tuple<M, N>>> tuple => this.Invoke(tuple),
                _ => this.Invoke((Func<T1, T2, T3, Task<(M, N)>>)@delegate)
            }).Result :
            new FlowerStep<M, N>(this);

        public new FlowerStep<M, N> TryDelegateAsync<T3, T4, M, N>(Delegate @delegate, params object[] @params)
            => _exception == default ?
            (@delegate switch
            {
                Func<T1, T2, T3, T4, Task<Tuple<M, N>>> tuple => this.Invoke(tuple),
                _ => this.Invoke((Func<T1, T2, T3, T4, Task<(M, N)>>)@delegate)
            }).Result :
            new FlowerStep<M, N>(this);

        public new FlowerStep<M, N> TryDelegateAsync<T3, T4, T5, M, N>(Delegate @delegate, params object[] @params)
            => _exception == default ?
            (@delegate switch
            {
                Func<T1, T2, T3, T4, T5, Task<Tuple<M, N>>> tuple => this.Invoke(tuple),
                _ => this.Invoke((Func<T1, T2, T3, T4, T5, Task<(M, N)>>)@delegate)
            }).Result :
            new FlowerStep<M, N>(this);

        public new FlowerStep<M, N> TryDelegateAsync<T3, T4, T5, T6, M, N>(Delegate @delegate, params object[] @params)
            => _exception == default ?
            (@delegate switch
            {
                Func<T1, T2, T3, T4, T5, T6, Task<Tuple<M, N>>> tuple => this.Invoke(tuple),
                _ => this.Invoke((Func<T1, T2, T3, T4, T5, T6, Task<(M, N)>>)@delegate)
            }).Result :
            new FlowerStep<M, N>(this);

        public new FlowerStep<M, N> TryDelegateAsync<T3, T4, T5, T6, T7, M, N>(Delegate @delegate, params object[] @params)
            => _exception == default ?
            (@delegate switch
            {
                Func<T1, T2, T3, T4, T5, T6, T7, Task<Tuple<M, N>>> tuple => this.Invoke(tuple),
                _ => this.Invoke((Func<T1, T2, T3, T4, T5, T6, T7, Task<(M, N)>>)@delegate)
            }).Result :
            new FlowerStep<M, N>(this);

        public new FlowerStep<M, N> TryDelegateAsync<T3, T4, T5, T6, T7, T8, M, N>(Delegate @delegate, params object[] @params)
            => _exception == default ?
            (@delegate switch
            {
                Func<T1, T2, T3, T4, T5, T6, T7, T8, Task<Tuple<M, N>>> tuple => this.Invoke(tuple),
                _ => this.Invoke((Func<T1, T2, T3, T4, T5, T6, T7, T8, Task<(M, N)>>)@delegate)
            }).Result :
            new FlowerStep<M, N>(this);

        public new FlowerStep<M, N> TryDelegateAsync<T3, T4, T5, T6, T7, T8, T9, M, N>(Delegate @delegate, params object[] @params)
            => _exception == default ?
            (@delegate switch
            {
                Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Task<Tuple<M, N>>> tuple => this.Invoke(tuple),
                _ => this.Invoke((Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Task<(M, N)>>)@delegate)
            }).Result :
            new FlowerStep<M, N>(this);

        public new FlowerStep<M, N> TryDelegateAsync<T3, T4, T5, T6, T7, T8, T9, T10, M, N>(Delegate @delegate, params object[] @params)
            => _exception == default ?
            (@delegate switch
            {
                Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Task<Tuple<M, N>>> tuple => this.Invoke(tuple),
                _ => this.Invoke((Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Task<(M, N)>>)@delegate)
            }).Result :
            new FlowerStep<M, N>(this);

        public new FlowerStep<M, N> TryDelegateAsync<T3, T4, T5, T6, T7, T8, T9, T10, T11, M, N>(Delegate @delegate, params object[] @params)
            => _exception == default ?
            (@delegate switch
            {
                Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Task<Tuple<M, N>>> tuple => this.Invoke(tuple),
                _ => this.Invoke((Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Task<(M, N)>>)@delegate)
            }).Result :
            new FlowerStep<M, N>(this);

        public new FlowerStep<M, N> TryDelegateAsync<T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, M, N>(Delegate @delegate, params object[] @params)
            => _exception == default ?
            (@delegate switch
            {
                Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Task<Tuple<M, N>>> tuple => this.Invoke(tuple),
                _ => this.Invoke((Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Task<(M, N)>>)@delegate)
            }).Result :
            new FlowerStep<M, N>(this);
    }
}
