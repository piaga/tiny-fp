using System;
using System.Threading.Tasks;

namespace TinyFp.DataTypes
{
    public interface IFlowerStep<T>
    {
        internal object State { get; }
        public IFlowerStep<T> Then(params Action[] a);
        public IFlowerStep<T> Then(params Action<T>[] a);
        public IFlowerStep<T> Then(Func<T> f);
        public IFlowerStep<T> Then(params Func<T, T>[] f);
        public IFlowerStep<N> Then<N>(Func<N> f);
        public IFlowerStep<N> Then<N>(Func<T,N> f);
        public IFlowerStep<M> Then<T2, M>(Func<T, T2, M> f, T2 t1);
        public IFlowerStep<M> Then<T2, T3, M>(Func<T, T2, T3, M> f, T2 t2, T3 t3);
        public IFlowerStep<M> Then<T2, T3, T4, M>(Func<T, T2, T3, T4, M> f, T2 t2, T3 t3, T4 t4);
        public IFlowerStep<M> Then<T2, T3, T4, T5, M>(Func<T, T2, T3, T4, T5, M> f, T2 t2, T3 t3, T4 t4, T5 t5);
        public IFlowerStep<M> Then<T2, T3, T4, T5, T6, M>(Func<T, T2, T3, T4, T5, T6, M> f, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6);
        public IFlowerStep<M> Then<T2, T3, T4, T5, T6, T7, M>(Func<T, T2, T3, T4, T5, T6, T7, M> f, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7);
        public IFlowerStep<M> Then<T2, T3, T4, T5, T6, T7, T8, M>(Func<T, T2, T3, T4, T5, T6, T7, T8, M> f, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8);
        public IFlowerStep<M> Then<T2, T3, T4, T5, T6, T7, T8, T9, M>(Func<T, T2, T3, T4, T5, T6, T7, T8, T9, M> f, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9);
        public IFlowerStep<M> Then<T2, T3, T4, T5, T6, T7, T8, T9, T10, M>(Func<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, M> f, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10);
        public IFlowerStep<M> Then<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, M>(Func<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, M> f, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11);
        public IFlowerStep<M> Then<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, M>(Func<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, M> f, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12);
        public IFlowerStep<T> ThenAsync(Func<Task<T>> f);
        public IFlowerStep<N> ThenAsync<N>(Func<Task<N>> f);
        public IFlowerStep<N> ThenAsync<N>(Func<T, Task<N>> f);
        public IFlowerStep<M> ThenAsync<T2, M>(Func<T, T2, Task<M>> f, T2 t1);
        public IFlowerStep<M> ThenAsync<T2, T3, M>(Func<T, T2, T3, Task<M>> f, T2 t2, T3 t3);
        public IFlowerStep<M> ThenAsync<T2, T3, T4, M>(Func<T, T2, T3, T4, Task<M>> f, T2 t2, T3 t3, T4 t4);
        public IFlowerStep<M> ThenAsync<T2, T3, T4, T5, M>(Func<T, T2, T3, T4, T5, Task<M>> f, T2 t2, T3 t3, T4 t4, T5 t5);
        public IFlowerStep<M> ThenAsync<T2, T3, T4, T5, T6, M>(Func<T, T2, T3, T4, T5, T6, Task<M>> f, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6);
        public IFlowerStep<M> ThenAsync<T2, T3, T4, T5, T6, T7, M>(Func<T, T2, T3, T4, T5, T6, T7, Task<M>> f, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7);
        public IFlowerStep<M> ThenAsync<T2, T3, T4, T5, T6, T7, T8, M>(Func<T, T2, T3, T4, T5, T6, T7, T8, Task<M>> f, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8);
        public IFlowerStep<M> ThenAsync<T2, T3, T4, T5, T6, T7, T8, T9, M>(Func<T, T2, T3, T4, T5, T6, T7, T8, T9, Task<M>> f, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9);
        public IFlowerStep<M> ThenAsync<T2, T3, T4, T5, T6, T7, T8, T9, T10, M>(Func<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, Task<M>> f, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10);
        public IFlowerStep<M> ThenAsync<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, M>(Func<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Task<M>> f, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11);
        public IFlowerStep<M> ThenAsync<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, M>(Func<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Task<M>> f, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12);
        public IFlowerEnd<T> OnThrow(Func<string, (Delegate @delegate, object faultyStatus), Exception, T> def);
        public IFlowerEnd<T> OnThrow(Func<(Delegate @delegate, object faultyStatus), Exception, T> def);
        public IFlowerEnd<T> OnThrow(Func<Exception, T> def);
        public IFlowerEnd<T> OnThrow(Func<T> def);
        public IFlowerStep<T> Guard(Action<T> defaultExpression, params (Predicate<T> evalExpression, Action<T> expressionIfEvalIsTrue)[] guards);
        public IFlowerStep<T> Guard(Func<T> defaultExpression, params (Func<bool> evalExpression, Func<T> expressionIfEvalIsTrue)[] guards);
        public IFlowerStep<T> Guard(Func<T> defaultExpression, params (Predicate<T> evalExpression, Func<T> expressionIfEvalIsTrue)[] guards);
        public IFlowerStep<T> Guard(Func<T, T> defaultExpression, params (Predicate<T> evalExpression, Func<T, T> expressionIfEvalIsTrue)[] guards);
        public IFlowerStep<N> Guard<N>(Func<N> defaultExpression, params (Func<bool> evalExpression, Func<N> expressionIfEvalIsTrue)[] guards);
        public IFlowerStep<N> Guard<N>(Func<T, N> defaultExpression, params (Predicate<T> evalExpression, Func<T, N> expressionIfEvalIsTrue)[] guards);
        public IFlowerStep<T> While(Predicate<T> evalExpression, params Action<T>[] doStuffIfExpressionIsTrue);
        public IFlowerStep<T> While(Predicate<T> evalExpression, params Func<T,T>[] doStuffIfExpressionIsTrue);
        public T Expect(string message);
    }
}