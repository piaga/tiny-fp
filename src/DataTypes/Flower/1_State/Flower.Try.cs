using System;
using System.Linq;
using System.Threading.Tasks;

namespace TinyFp.DataTypes
{
    public partial class FlowerStep<T>
    {
        public FlowerStep<T> TryDelegate(Delegate @delegate, params object[] @params)
            => _exception == default ?
                    @delegate.Method.GetParameters().Length switch
                    {
                        0 => @delegate.Method.ReturnType == typeof(void) ?
                                this.Invoke((Action)@delegate) :
                                this.Invoke((Func<T>)@delegate),
                        _ => @delegate.Method.ReturnType == typeof(void) ?
                                this.Invoke((Action<T>)@delegate, @params) :
                                this.Invoke((Func<T,T>)@delegate, @params)
                    } :
                    new FlowerStep<T>(this);

        public FlowerStep<M> TryDelegate<M>(Delegate @delegate, params object[] @params)
            => _exception == default ?
                    @delegate.Method.GetParameters().Length switch
                    {
                        0 => this.Invoke((Func<M>)@delegate),
                        _ => this.Invoke((Func<T, M>)@delegate, @params)
                    } :
                    new FlowerStep<M>(this);

        public FlowerStep<M> TryDelegate<T2, M>(Delegate @delegate, params object[] @params)
            => _exception == default ?
                this.Invoke((Func<T, T2, M>)@delegate, @params) :
                new FlowerStep<M>(this);

        public FlowerStep<M> TryDelegate<T2, T3, M>(Delegate @delegate, params object[] @params)
            => _exception == default ?
                this.Invoke((Func<T, T2, T3, M>)@delegate, @params) :
                new FlowerStep<M>(this);

        public FlowerStep<M> TryDelegate<T2, T3, T4, M>(Delegate @delegate, params object[] @params)
            => _exception == default ?
                this.Invoke((Func<T, T2, T3, T4, M>)@delegate, @params) :
                new FlowerStep<M>(this);

        public FlowerStep<M> TryDelegate<T2, T3, T4, T5, M>(Delegate @delegate, params object[] @params)
            => _exception == default ?
                this.Invoke((Func<T, T2, T3, T4, T5, M>)@delegate, @params) :
                new FlowerStep<M>(this);

        public FlowerStep<M> TryDelegate<T2, T3, T4, T5, T6, M>(Delegate @delegate, params object[] @params)
            => _exception == default ?
                this.Invoke((Func<T, T2, T3, T4, T5, T6, M>)@delegate, @params) :
                new FlowerStep<M>(this);

        public FlowerStep<M> TryDelegate<T2, T3, T4, T5, T6, T7, M>(Delegate @delegate, params object[] @params)
            => _exception == default ?
                this.Invoke((Func<T, T2, T3, T4, T5, T6, T7, M>)@delegate, @params) :
                new FlowerStep<M>(this);

        public FlowerStep<M> TryDelegate<T2, T3, T4, T5, T6, T7, T8, M>(Delegate @delegate, params object[] @params)
            => _exception == default ?
                this.Invoke((Func<T, T2, T3, T4, T5, T6, T7, T8, M>)@delegate, @params) :
                new FlowerStep<M>(this);

        public FlowerStep<M> TryDelegate<T2, T3, T4, T5, T6, T7, T8, T9, M>(Delegate @delegate, params object[] @params)
            => _exception == default ?
                this.Invoke((Func<T, T2, T3, T4, T5, T6, T7, T8, T9, M>)@delegate, @params) :
                new FlowerStep<M>(this);

        public FlowerStep<M> TryDelegate<T2, T3, T4, T5, T6, T7, T8, T9, T10, M>(Delegate @delegate, params object[] @params)
            => _exception == default ?
                this.Invoke((Func<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, M>)@delegate, @params) :
                new FlowerStep<M>(this);

        public FlowerStep<M> TryDelegate<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, M>(Delegate @delegate, params object[] @params)
            => _exception == default ?
                this.Invoke((Func<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, M>)@delegate, @params) :
                new FlowerStep<M>(this);

        public FlowerStep<M> TryDelegate<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, M>(Delegate @delegate, params object[] @params)
            => _exception == default ?
                this.Invoke((Func<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, M>)@delegate, @params) :
                new FlowerStep<M>(this);

        public FlowerStep<T> TryDelegate(Action<T>[] actions)
            => _exception == default ? 
                actions.AsEnumerable()
                .Aggregate(this, (step, action)=> step.Invoke(action, step._state1)) :
                new FlowerStep<T>(this);

        public FlowerStep<T> TryDelegate(Func<T, T>[] functions)
            => _exception == default ?
                functions.AsEnumerable()
                .Aggregate(this, (step, function) => step.Invoke(function, step._state1)) :
            new FlowerStep<T>(this);

        public FlowerStep<M> TryDelegateAsync<M>(Delegate @delegate)
            => _exception == default ?
            @delegate.Method.GetParameters().Length switch
            {
                0 => this.Invoke((Func<Task<M>>)@delegate).Result,
                _ => this.Invoke((Func<T, Task<M>>)@delegate, State).Result
            } :
            new FlowerStep<M>(this);

        public FlowerStep<M> TryDelegateAsync<T2, M>(Delegate @delegate, params object[] @params)
            => _exception == default ?
            this.Invoke((Func<T, T2, Task<M>>)@delegate, @params).Result :
            new FlowerStep<M>(this);

        public FlowerStep<M> TryDelegateAsync<T2, T3, M>(Delegate @delegate, params object[] @params)
            => _exception == default ?
            this.Invoke((Func<T, T2, T3, Task<M>>)@delegate, @params).Result :
            new FlowerStep<M>(this);

        public FlowerStep<M> TryDelegateAsync<T2, T3, T4,M>(Delegate @delegate, params object[] @params)
            => _exception == default ?
            this.Invoke((Func<T, T2, T3, T4, Task<M>>)@delegate, @params).Result :
            new FlowerStep<M>(this);

        public FlowerStep<M> TryDelegateAsync<T2, T3, T4, T5, M>(Delegate @delegate, params object[] @params)
            => _exception == default ?
            this.Invoke((Func<T, T2, T3, T4, T5, Task<M>>)@delegate, @params).Result :
            new FlowerStep<M>(this);

        public FlowerStep<M> TryDelegateAsync<T2, T3, T4, T5, T6, M>(Delegate @delegate, params object[] @params)
            => _exception == default ?
            this.Invoke((Func<T, T2, T3, T4, T5, T6, Task<M>>)@delegate, @params).Result :
            new FlowerStep<M>(this);

        public FlowerStep<M> TryDelegateAsync<T2, T3, T4, T5, T6, T7, M>(Delegate @delegate, params object[] @params)
            => _exception == default ?
            this.Invoke((Func<T, T2, T3, T4, T5, T6, T7, Task<M>>)@delegate, @params).Result :
            new FlowerStep<M>(this);

        public FlowerStep<M> TryDelegateAsync<T2, T3, T4, T5, T6, T7, T8, M>(Delegate @delegate, params object[] @params)
            => _exception == default ?
            this.Invoke((Func<T, T2, T3, T4, T5, T6, T7, T8, Task<M>>)@delegate, @params).Result :
            new FlowerStep<M>(this);

        public FlowerStep<M> TryDelegateAsync<T2, T3, T4, T5, T6, T7, T8, T9, M>(Delegate @delegate, params object[] @params)
            => _exception == default ?
            this.Invoke((Func<T, T2, T3, T4, T5, T6, T7, T8, T9, Task<M>>)@delegate, @params).Result :
            new FlowerStep<M>(this);

        public FlowerStep<M> TryDelegateAsync<T2, T3, T4, T5, T6, T7, T8, T9, T10, M>(Delegate @delegate, params object[] @params)
            => _exception == default ?
            this.Invoke((Func<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, Task<M>>)@delegate, @params).Result :
            new FlowerStep<M>(this);

        public FlowerStep<M> TryDelegateAsync<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, M>(Delegate @delegate, params object[] @params)
            => _exception == default ?
            this.Invoke((Func<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Task<M>>)@delegate, @params).Result :
            new FlowerStep<M>(this);

        public FlowerStep<M> TryDelegateAsync<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, M>(Delegate @delegate, params object[] @params)
            => _exception == default ?
            this.Invoke((Func<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Task<M>>)@delegate, @params).Result :
            new FlowerStep<M>(this);
    }
}
