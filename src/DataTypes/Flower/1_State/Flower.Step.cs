using TinyFp.Extensions;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace TinyFp.DataTypes
{

    public partial class FlowerStep<T> : IFlowerStep<T>
    {
        public IFlowerEnd<T> OnThrow(Func<string, (Delegate @delegate, object faultyStatus), Exception, T> def)
            => new FlowerEnd<T>(this).Tee(_ => _def = def);
        public IFlowerEnd<T> OnThrow(Func<(Delegate @delegate, object faultyStatus), Exception, T> def)
            => new FlowerEnd<T>(this).Tee(_ => _def = def);
        public IFlowerEnd<T> OnThrow(Func<Exception, T> def)
            => new FlowerEnd<T>(this).Tee(_ => _def = def);

        public IFlowerEnd<T> OnThrow(Func<T> def)
            => new FlowerEnd<T>(this).Tee(_ => _def = def);

        public IFlowerStep<T> Then(Func<T> f)
            => TryDelegate(f);

        public IFlowerStep<N> Then<N>(Func<N> f)
            => TryDelegate<N>(f);

        public IFlowerStep<N> Then<N>(Func<T, N> f)
            => TryDelegate<N>(f, _state1);

        public IFlowerStep<M> Then<T2, M>(Func<T, T2, M> f, T2 t2)
            => TryDelegate<T2, M>(f, _state1, t2);
        public IFlowerStep<M> Then<T2, T3, M>(Func<T, T2, T3, M> f, T2 t2, T3 t3)
            => TryDelegate<T2, T3, M>(f, _state1, t2, t3);
        public IFlowerStep<M> Then<T2, T3, T4, M>(Func<T, T2, T3, T4, M> f, T2 t2, T3 t3, T4 t4)
            => TryDelegate<T2, T3, T4, M>(f, _state1, t2, t3, t4);
        public IFlowerStep<M> Then<T2, T3, T4, T5, M>(Func<T, T2, T3, T4, T5, M> f, T2 t2, T3 t3, T4 t4, T5 t5)
            => TryDelegate<T2, T3, T4, T5, M>(f, _state1, t2, t3, t4, t5);
        public IFlowerStep<M> Then<T2, T3, T4, T5, T6, M>(Func<T, T2, T3, T4, T5, T6, M> f, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
            => TryDelegate<T2, T3, T4, T5, T6, M>(f, _state1, t2, t3, t4, t5, t6);
        public IFlowerStep<M> Then<T2, T3, T4, T5, T6, T7, M>(Func<T, T2, T3, T4, T5, T6, T7, M> f, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
            => TryDelegate<T2, T3, T4, T5, T6, T7, M>(f, _state1, t2, t3, t4, t5, t6, t7);
        public IFlowerStep<M> Then<T2, T3, T4, T5, T6, T7, T8, M>(Func<T, T2, T3, T4, T5, T6, T7, T8, M> f, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8)
            => TryDelegate<T2, T3, T4, T5, T6, T7, T8, M>(f, _state1, t2, t3, t4, t5, t6, t7, t8);
        public IFlowerStep<M> Then<T2, T3, T4, T5, T6, T7, T8, T9, M>(Func<T, T2, T3, T4, T5, T6, T7, T8, T9, M> f, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9)
            => TryDelegate<T2, T3, T4, T5, T6, T7, T8, T9, M>(f, _state1, t2, t3, t4, t5, t6, t7, t8, t9);
        public IFlowerStep<M> Then<T2, T3, T4, T5, T6, T7, T8, T9, T10, M>(Func<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, M> f, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10)
            => TryDelegate<T2, T3, T4, T5, T6, T7, T8, T9, T10, M>(f, _state1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
        public IFlowerStep<M> Then<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, M>(Func<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, M> f, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11)
            => TryDelegate<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, M>(f, _state1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
        public IFlowerStep<M> Then<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, M>(Func<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, M> f, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12)
            => TryDelegate<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, M>(f, _state1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
        public IFlowerStep<N> ThenAsync<N>(Func<Task<N>> f)
            => TryDelegateAsync<N>(f);
        public IFlowerStep<N> ThenAsync<N>(Func<T, Task<N>> f)
            => TryDelegateAsync<N>(f);
        public IFlowerStep<M> ThenAsync<T2, M>(Func<T, T2, Task<M>> f, T2 t2)
            => TryDelegateAsync<T2, M>(f, _state1, t2);
        public IFlowerStep<M> ThenAsync<T2, T3, M>(Func<T, T2, T3, Task<M>> f, T2 t2, T3 t3)
            => TryDelegateAsync<T2, T3, M>(f, _state1, t2, t3);
        public IFlowerStep<M> ThenAsync<T2, T3, T4, M>(Func<T, T2, T3, T4, Task<M>> f, T2 t2, T3 t3, T4 t4)
            => TryDelegateAsync<T2, T3, T4, M>(f, _state1, t2, t3, t4);
        public IFlowerStep<M> ThenAsync<T2, T3, T4, T5, M>(Func<T, T2, T3, T4, T5, Task<M>> f, T2 t2, T3 t3, T4 t4, T5 t5)
            => TryDelegateAsync<T2, T3, T4, T5, M>(f, _state1, t2, t3, t4, t5);
        public IFlowerStep<M> ThenAsync<T2, T3, T4, T5, T6, M>(Func<T, T2, T3, T4, T5, T6, Task<M>> f, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
            => TryDelegateAsync<T2, T3, T4, T5, T6, M>(f, _state1, t2, t3, t4, t5, t6);
        public IFlowerStep<M> ThenAsync<T2, T3, T4, T5, T6, T7, M>(Func<T, T2, T3, T4, T5, T6, T7, Task<M>> f, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
            => TryDelegateAsync<T2, T3, T4, T5, T6, T7, M>(f, _state1, t2, t3, t4, t5, t6, t7);
        public IFlowerStep<M> ThenAsync<T2, T3, T4, T5, T6, T7, T8, M>(Func<T, T2, T3, T4, T5, T6, T7, T8, Task<M>> f, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8)
            => TryDelegateAsync<T2, T3, T4, T5, T6, T7, T8, M>(f, _state1, t2, t3, t4, t5, t6, t7, t8);
        public IFlowerStep<M> ThenAsync<T2, T3, T4, T5, T6, T7, T8, T9, M>(Func<T, T2, T3, T4, T5, T6, T7, T8, T9, Task<M>> f, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9)
            => TryDelegateAsync<T2, T3, T4, T5, T6, T7, T8, T9, M>(f, _state1, t2, t3, t4, t5, t6, t7, t8, t9);
        public IFlowerStep<M> ThenAsync<T2, T3, T4, T5, T6, T7, T8, T9, T10, M>(Func<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, Task<M>> f, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10)
            => TryDelegateAsync<T2, T3, T4, T5, T6, T7, T8, T9, T10, M>(f, _state1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
        public IFlowerStep<M> ThenAsync<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, M>(Func<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Task<M>> f, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11)
            => TryDelegateAsync<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, M>(f, _state1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
        public IFlowerStep<M> ThenAsync<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, M>(Func<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Task<M>> f, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12)
            => TryDelegateAsync<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, M>(f, _state1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
        public IFlowerStep<T> ThenAsync(Func<Task<T>> f)
            => TryDelegateAsync<T>(f);
        public T Expect(string message)
            => _exception != default ?
                throw new Exception(message, _exception) :
                (T)_state1;

        public IFlowerStep<T> Then(params Action[] a)
            => a.AsEnumerable()
                .Aggregate(this, (step, @delegate) => step.TryDelegate(@delegate));

        public IFlowerStep<T> Then(params Action<T>[] a)
            => TryDelegate(a);

        public IFlowerStep<T> Then(params Func<T, T>[] f)
            => TryDelegate(f);
    }
}