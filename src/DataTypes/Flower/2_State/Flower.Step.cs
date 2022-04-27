using TinyFp.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyFp.DataTypes
{
    public partial class FlowerStep<T1, T2> : IFlowerStep<T1, T2>
    {
        public new (T1, T2) Expect(string message)
            => _exception != default ?
            throw new Exception(message, _exception) :
            ((T1)_state1, (T2)_state2);

        public IFlowerEnd<T1, T2> OnThrow(Func<string, (Delegate @delegate, object faultyStatus), Exception, Tuple<T1, T2>> def)
            => new FlowerEnd<T1, T2>(this).Tee(_ => _def = def);

        public IFlowerEnd<T1, T2> OnThrow(Func<(Delegate @delegate, object faultyStatus), Exception, Tuple<T1, T2>> def)
            => new FlowerEnd<T1, T2>(this).Tee(_ => _def = def);

        public IFlowerEnd<T1, T2> OnThrow(Func<Exception, Tuple<T1, T2>> def)
            => new FlowerEnd<T1, T2>(this).Tee(_ => _def = def);

        public IFlowerEnd<T1, T2> OnThrow(Func<Tuple<T1, T2>> def)
            => new FlowerEnd<T1, T2>(this).Tee(_ => _def = def);

        public IFlowerEnd<T1, T2> OnThrow(Func<string, (Delegate @delegate, object faultyStatus), Exception, (T1, T2)> def)
            => new FlowerEnd<T1, T2>(this).Tee(_ => _def = def);
        public IFlowerEnd<T1, T2> OnThrow(Func<(Delegate @delegate, object faultyStatus), Exception, (T1, T2)> def)
            => new FlowerEnd<T1, T2>(this).Tee(_ => _def = def);
        public IFlowerEnd<T1, T2> OnThrow(Func<Exception, (T1, T2)> def)
            => new FlowerEnd<T1, T2>(this).Tee(_ => _def = def);
        public IFlowerEnd<T1, T2> OnThrow(Func<(T1, T2)> def)
            => new FlowerEnd<T1, T2>(this).Tee(_ => _def = def);

        public new IFlowerStep<T1, T2> Then(params Action[] a)
            => a.AsEnumerable()
                .Aggregate(this, (step, @delegate) => step.TryDelegate(@delegate));

        public IFlowerStep<T1, T2> Then(params Action<T1, T2>[] a)
            => TryDelegate(a);

        public IFlowerStep<T1, T2> Then(Func<T1, T2, Tuple<T1, T2>> f)
            => TryDelegate(f, _state1, _state2);

        public IFlowerStep<T1, T2> Then(Func<T1, T2, (T1, T2)> f)
            => TryDelegate(f, _state1, _state2);

        public IFlowerStep<T1, T2> Then(params Func<T1, T2, Tuple<T1, T2>>[] f)
            => TryDelegate(f);

        public IFlowerStep<T1, T2> Then(params Func<T1, T2, (T1, T2)>[] f)
            => TryDelegate(f);

        public IFlowerStep<M, N> Then<M, N>(Func<Tuple<M, N>> f)
            => TryDelegate<M, N>(f);

        public IFlowerStep<M, N> Then<M, N>(Func<(M, N)> f)
            => TryDelegate<M, N>(f);

        public IFlowerStep<M, N> Then<M, N>(Func<T1, T2, Tuple<M, N>> f)
            => TryDelegate<M, N>(f, _state1, _state2);

        public IFlowerStep<M, N> Then<M, N>(Func<T1, T2, (M, N)> f)
            => TryDelegate<M, N>(f, _state1, _state2);

        public IFlowerStep<M, N> Then<T3, M, N>(Func<T1, T2, T3, Tuple<M, N>> f, T3 t3)
            => TryDelegate<T3, M, N>(f, _state1, _state2, t3);

        public IFlowerStep<M, N> Then<T3, M, N>(Func<T1, T2, T3, (M, N)> f, T3 t3)
            => TryDelegate<T3, M, N>(f, _state1, _state2, t3);

        public IFlowerStep<M, N> Then<T3, T4, M, N>(Func<T1, T2, T3, T4, Tuple<M, N>> f, T3 t3, T4 t4)
            => TryDelegate<T3, T4, M, N>(f, _state1, _state2, t3, t4);

        public IFlowerStep<M, N> Then<T3, T4, M, N>(Func<T1, T2, T3, T4, (M, N)> f, T3 t3, T4 t4)
            => TryDelegate<T3, T4, M, N>(f, _state1, _state2, t3, t4);

        public IFlowerStep<M, N> Then<T3, T4, T5, M, N>(Func<T1, T2, T3, T4, T5, Tuple<M, N>> f, T3 t3, T4 t4, T5 t5)
            => TryDelegate<T3, T4, T5, M, N>(f, _state1, _state2, t3, t4, t5);

        public IFlowerStep<M, N> Then<T3, T4, T5, M, N>(Func<T1, T2, T3, T4, T5, (M, N)> f, T3 t3, T4 t4, T5 t5)
            => TryDelegate<T3, T4, T5, M, N>(f, _state1, _state2, t3, t4, t5);

        public IFlowerStep<M, N> Then<T3, T4, T5, T6, M, N>(Func<T1, T2, T3, T4, T5, T6, Tuple<M, N>> f, T3 t3, T4 t4, T5 t5, T6 t6)
            => TryDelegate<T3, T4, T5, T6, M, N>(f, _state1, _state2, t3, t4, t5, t6);

        public IFlowerStep<M, N> Then<T3, T4, T5, T6, M, N>(Func<T1, T2, T3, T4, T5, T6, (M, N)> f, T3 t3, T4 t4, T5 t5, T6 t6)
            => TryDelegate<T3, T4, T5, T6, M, N>(f, _state1, _state2, t3, t4, t5, t6);

        public IFlowerStep<M, N> Then<T3, T4, T5, T6, T7, M, N>(Func<T1, T2, T3, T4, T5, T6, T7, Tuple<M, N>> f, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
            => TryDelegate<T3, T4, T5, T6, T7, M, N>(f, _state1, _state2, t3, t4, t5, t6, t7);

        public IFlowerStep<M, N> Then<T3, T4, T5, T6, T7, M, N>(Func<T1, T2, T3, T4, T5, T6, T7, (M, N)> f, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
            => TryDelegate<T3, T4, T5, T6, T7, M, N>(f, _state1, _state2, t3, t4, t5, t6, t7);

        public IFlowerStep<M, N> Then<T3, T4, T5, T6, T7, T8, M, N>(Func<T1, T2, T3, T4, T5, T6, T7, T8, Tuple<M, N>> f, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8)
            => TryDelegate<T3, T4, T5, T6, T7, T8, M, N>(f, _state1, _state2, t3, t4, t5, t6, t7, t8);

        public IFlowerStep<M, N> Then<T3, T4, T5, T6, T7, T8, M, N>(Func<T1, T2, T3, T4, T5, T6, T7, T8, (M, N)> f, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8)
            => TryDelegate<T3, T4, T5, T6, T7, T8, M, N>(f, _state1, _state2, t3, t4, t5, t6, t7, t8);

        public IFlowerStep<M, N> Then<T3, T4, T5, T6, T7, T8, T9, M, N>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Tuple<M, N>> f, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9)
            => TryDelegate<T3, T4, T5, T6, T7, T8, T9, M, N>(f, _state1, _state2, t3, t4, t5, t6, t7, t8, t9);

        public IFlowerStep<M, N> Then<T3, T4, T5, T6, T7, T8, T9, M, N>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, (M, N)> f, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9)
            => TryDelegate<T3, T4, T5, T6, T7, T8, T9, M, N>(f, _state1, _state2, t3, t4, t5, t6, t7, t8, t9);

        public IFlowerStep<M, N> Then<T3, T4, T5, T6, T7, T8, T9, T10, M, N>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Tuple<M, N>> f, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10)
            => TryDelegate<T3, T4, T5, T6, T7, T8, T9, T10, M, N>(f, _state1, _state2, t3, t4, t5, t6, t7, t8, t9, t10);

        public IFlowerStep<M, N> Then<T3, T4, T5, T6, T7, T8, T9, T10, M, N>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, (M, N)> f, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10)
            => TryDelegate<T3, T4, T5, T6, T7, T8, T9, T10, M, N>(f, _state1, _state2, t3, t4, t5, t6, t7, t8, t9, t10);

        public IFlowerStep<M, N> Then<T3, T4, T5, T6, T7, T8, T9, T10, T11, M, N>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Tuple<M, N>> f, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11)
            => TryDelegate<T3, T4, T5, T6, T7, T8, T9, T10, T11, M, N>(f, _state1, _state2, t3, t4, t5, t6, t7, t8, t9, t10, t11);

        public IFlowerStep<M, N> Then<T3, T4, T5, T6, T7, T8, T9, T10, T11, M, N>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, (M, N)> f, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11)
            => TryDelegate<T3, T4, T5, T6, T7, T8, T9, T10, T11, M, N>(f, _state1, _state2, t3, t4, t5, t6, t7, t8, t9, t10, t11);

        public IFlowerStep<M, N> Then<T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, M, N>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Tuple<M, N>> f, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12)
            => TryDelegate<T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, M, N>(f, _state1, _state2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);

        public IFlowerStep<M, N> Then<T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, M, N>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, (M, N)> f, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12)
            => TryDelegate<T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, M, N>(f, _state1, _state2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);

        public IFlowerStep<T1, T2> ThenAsync(Func<Task<Tuple<T1, T2>>> f)
            => TryDelegateAsync<T1, T2>(f);

        public IFlowerStep<T1, T2> ThenAsync(Func<Task<(T1, T2)>> f)
            => TryDelegateAsync<T1, T2>(f);

        public IFlowerStep<M, N> ThenAsync<M, N>(Func<Task<Tuple<M, N>>> f)
            => TryDelegateAsync<M, N>(f);

        public IFlowerStep<M, N> ThenAsync<M, N>(Func<Task<(M, N)>> f)
            => TryDelegateAsync<M, N>(f);

        public IFlowerStep<M, N> ThenAsync<M, N>(Func<T1, T2, Task<Tuple<M, N>>> f)
            => TryDelegateAsync<M, N>(f, _state1, _state2);

        public IFlowerStep<M, N> ThenAsync<M, N>(Func<T1, T2, Task<(M, N)>> f)
            => TryDelegateAsync<M, N>(f, _state1, _state2);

        public IFlowerStep<M, N> ThenAsync<T3, M, N>(Func<T1, T2, T3, Task<Tuple<M, N>>> f, T3 t3)
            => TryDelegateAsync<T3, M, N>(f, _state1, _state2, t3);

        public IFlowerStep<M, N> ThenAsync<T3, M, N>(Func<T1, T2, T3, Task<(M,N)>> f, T3 t3)
            => TryDelegateAsync<T3, M, N>(f, _state1, _state2, t3);

        public IFlowerStep<M, N> ThenAsync<T3, T4, M, N>(Func<T1, T2, T3, T4, Task<Tuple<M, N>>> f, T3 t3, T4 t4)
            => TryDelegateAsync<T3, T4, M, N>(f, _state1, _state2, t3, t4);

        public IFlowerStep<M, N> ThenAsync<T3, T4, M, N>(Func<T1, T2, T3, T4, Task<(M, N)>> f, T3 t3, T4 t4)
            => TryDelegateAsync<T3, T4, M, N>(f, _state1, _state2, t3, t4);

        public IFlowerStep<M, N> ThenAsync<T3, T4, T5, M, N>(Func<T1, T2, T3, T4, T5, Task<Tuple<M, N>>> f, T3 t3, T4 t4, T5 t5)
            => TryDelegateAsync<T3, T4, T5, M, N>(f, _state1, _state2, t3, t4, t5);

        public IFlowerStep<M, N> ThenAsync<T3, T4, T5, M, N>(Func<T1, T2, T3, T4, T5, Task<(M, N)>> f, T3 t3, T4 t4, T5 t5)
            => TryDelegateAsync<T3, T4, T5, M, N>(f, _state1, _state2, t3, t4, t5);

        public IFlowerStep<M, N> ThenAsync<T3, T4, T5, T6, M, N>(Func<T1, T2, T3, T4, T5, T6, Task<Tuple<M, N>>> f, T3 t3, T4 t4, T5 t5, T6 t6)
            => TryDelegateAsync<T3, T4, T5, T6, M, N>(f, _state1, _state2, t3, t4, t5, t6);

        public IFlowerStep<M, N> ThenAsync<T3, T4, T5, T6, M, N>(Func<T1, T2, T3, T4, T5, T6, Task<(M, N)>> f, T3 t3, T4 t4, T5 t5, T6 t6)
            => TryDelegateAsync<T3, T4, T5, T6, M, N>(f, _state1, _state2, t3, t4, t5, t6);

        public IFlowerStep<M, N> ThenAsync<T3, T4, T5, T6, T7, M, N>(Func<T1, T2, T3, T4, T5, T6, T7, Task<Tuple<M, N>>> f, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
            => TryDelegateAsync<T3, T4, T5, T6, T7, M, N>(f, _state1, _state2, t3, t4, t5, t6, t7);

        public IFlowerStep<M, N> ThenAsync<T3, T4, T5, T6, T7, M, N>(Func<T1, T2, T3, T4, T5, T6, T7, Task<(M, N)>> f, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
            => TryDelegateAsync<T3, T4, T5, T6, T7, M, N>(f, _state1, _state2, t3, t4, t5, t6, t7);

        public IFlowerStep<M, N> ThenAsync<T3, T4, T5, T6, T7, T8, M, N>(Func<T1, T2, T3, T4, T5, T6, T7, T8, Task<Tuple<M, N>>> f, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8)
            => TryDelegateAsync<T3, T4, T5, T6, T7, T8, M, N>(f, _state1, _state2, t3, t4, t5, t6, t7, t8);

        public IFlowerStep<M, N> ThenAsync<T3, T4, T5, T6, T7, T8, M, N>(Func<T1, T2, T3, T4, T5, T6, T7, T8, Task<(M, N)>> f, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8)
            => TryDelegateAsync<T3, T4, T5, T6, T7, T8, M, N>(f, _state1, _state2, t3, t4, t5, t6, t7, t8);

        public IFlowerStep<M, N> ThenAsync<T3, T4, T5, T6, T7, T8, T9, M, N>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Task<Tuple<M, N>>> f, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9)
            => TryDelegateAsync<T3, T4, T5, T6, T7, T8, T9, M, N>(f, _state1, _state2, t3, t4, t5, t6, t7, t8, t9);

        public IFlowerStep<M, N> ThenAsync<T3, T4, T5, T6, T7, T8, T9, M, N>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Task<(M, N)>> f, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9)
            => TryDelegateAsync<T3, T4, T5, T6, T7, T8, T9, M, N>(f, _state1, _state2, t3, t4, t5, t6, t7, t8, t9);

        public IFlowerStep<M, N> ThenAsync<T3, T4, T5, T6, T7, T8, T9, T10, M, N>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Task<Tuple<M, N>>> f, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10)
            => TryDelegateAsync<T3, T4, T5, T6, T7, T8, T9, T10, M, N>(f, _state1, _state2, t3, t4, t5, t6, t7, t8, t9, t10);

        public IFlowerStep<M, N> ThenAsync<T3, T4, T5, T6, T7, T8, T9, T10, M, N>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Task<(M, N)>> f, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10)
            => TryDelegateAsync<T3, T4, T5, T6, T7, T8, T9, T10, M, N>(f, _state1, _state2, t3, t4, t5, t6, t7, t8, t9, t10);

        public IFlowerStep<M, N> ThenAsync<T3, T4, T5, T6, T7, T8, T9, T10, T11, M, N>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Task<Tuple<M, N>>> f, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11)
            => TryDelegateAsync<T3, T4, T5, T6, T7, T8, T9, T10, T11, M, N>(f, _state1, _state2, t3, t4, t5, t6, t7, t8, t9, t10, t11);

        public IFlowerStep<M, N> ThenAsync<T3, T4, T5, T6, T7, T8, T9, T10, T11, M, N>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Task<(M, N)>> f, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11)
            => TryDelegateAsync<T3, T4, T5, T6, T7, T8, T9, T10, T11, M, N>(f, _state1, _state2, t3, t4, t5, t6, t7, t8, t9, t10, t11);

        public IFlowerStep<M, N> ThenAsync<T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, M, N>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Task<Tuple<M, N>>> f, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12)
            => TryDelegateAsync<T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, M, N>(f, _state1, _state2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);

        public IFlowerStep<M, N> ThenAsync<T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, M, N>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Task<(M, N)>> f, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12)
            => TryDelegateAsync<T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, M, N>(f, _state1, _state2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
    }
}
