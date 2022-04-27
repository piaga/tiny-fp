using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;

namespace TinyFp.DataTypes
{
    public interface IFlowerStep<T1, T2>
    {
        internal object State { get; }
        public IFlowerStep<T1, T2> Then(params Action[] a);
        public IFlowerStep<T1, T2> Then(params Action<T1, T2>[] a);
        public IFlowerStep<T1, T2> Then(Func<T1, T2, Tuple<T1, T2>> f);
        public IFlowerStep<T1, T2> Then(Func<T1, T2, (T1, T2)> f);
        public IFlowerStep<T1, T2> Then(params Func<T1, T2, Tuple<T1, T2>>[] f);
        public IFlowerStep<T1, T2> Then(params Func<T1, T2, (T1, T2)>[] f);
        public IFlowerStep<M, N> Then<M, N>(Func<(M, N)> f);
        public IFlowerStep<M, N> Then<M, N>(Func<T1, T2, Tuple<M, N>> f);
        public IFlowerStep<M, N> Then<M, N>(Func<T1, T2, (M, N)> f);
        public IFlowerStep<M, N> Then<T3, M, N>(Func<T1, T2, T3, Tuple<M, N>> f, T3 t3);
        public IFlowerStep<M, N> Then<T3, M, N>(Func<T1, T2, T3, (M, N)> f, T3 t3);
        public IFlowerStep<M, N> Then<T3, T4, M, N>(Func<T1, T2, T3, T4, Tuple<M, N>> f, T3 t3, T4 t4);
        public IFlowerStep<M, N> Then<T3, T4, M, N>(Func<T1, T2, T3, T4, (M, N)> f, T3 t3, T4 t4);
        public IFlowerStep<M, N> Then<T3, T4, T5, M, N>(Func<T1, T2, T3, T4, T5, Tuple<M, N>> f, T3 t3, T4 t4, T5 t5);
        public IFlowerStep<M, N> Then<T3, T4, T5, M, N>(Func<T1, T2, T3, T4, T5, (M, N)> f, T3 t3, T4 t4, T5 t5);
        public IFlowerStep<M, N> Then<T3, T4, T5, T6, M, N>(Func<T1, T2, T3, T4, T5, T6, Tuple<M, N>> f, T3 t3, T4 t4, T5 t5, T6 t6);
        public IFlowerStep<M, N> Then<T3, T4, T5, T6, M, N>(Func<T1, T2, T3, T4, T5, T6, (M, N)> f, T3 t3, T4 t4, T5 t5, T6 t6);
        public IFlowerStep<M, N> Then<T3, T4, T5, T6, T7, M, N>(Func<T1, T2, T3, T4, T5, T6, T7, Tuple<M, N>> f, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7);
        public IFlowerStep<M, N> Then<T3, T4, T5, T6, T7, M, N>(Func<T1, T2, T3, T4, T5, T6, T7, (M, N)> f, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7);
        public IFlowerStep<M, N> Then<T3, T4, T5, T6, T7, T8, M, N>(Func<T1, T2, T3, T4, T5, T6, T7, T8, Tuple<M, N>> f, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8);
        public IFlowerStep<M, N> Then<T3, T4, T5, T6, T7, T8, M, N>(Func<T1, T2, T3, T4, T5, T6, T7, T8, (M, N)> f, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8);
        public IFlowerStep<M, N> Then<T3, T4, T5, T6, T7, T8, T9, M, N>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Tuple<M, N>> f, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9);
        public IFlowerStep<M, N> Then<T3, T4, T5, T6, T7, T8, T9, M, N>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, (M, N)> f, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9);
        public IFlowerStep<M, N> Then<T3, T4, T5, T6, T7, T8, T9, T10, M, N>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Tuple<M, N>> f, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10);
        public IFlowerStep<M, N> Then<T3, T4, T5, T6, T7, T8, T9, T10, M, N>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, (M, N)> f, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10);
        public IFlowerStep<M, N> Then<T3, T4, T5, T6, T7, T8, T9, T10, T11, M, N>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Tuple<M, N>> f, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11);
        public IFlowerStep<M, N> Then<T3, T4, T5, T6, T7, T8, T9, T10, T11, M, N>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, (M, N)> f, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11);
        public IFlowerStep<M, N> Then<T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, M, N>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Tuple<M, N>> f, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12);
        public IFlowerStep<M, N> Then<T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, M, N>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, (M, N)> f, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12);
        public IFlowerStep<T1, T2> ThenAsync(Func<Task<Tuple<T1, T2>>> f);
        public IFlowerStep<T1, T2> ThenAsync(Func<Task<(T1, T2)>> f);
        public IFlowerStep<M, N> ThenAsync<M, N>(Func<Task<Tuple<M, N>>> f);
        public IFlowerStep<M, N> ThenAsync<M, N>(Func<Task<(M, N)>> f);
        public IFlowerStep<M, N> ThenAsync<M, N>(Func<T1, T2, Task<Tuple<M, N>>> f);
        public IFlowerStep<M, N> ThenAsync<M, N>(Func<T1, T2, Task<(M, N)>> f);
        public IFlowerStep<M, N> ThenAsync<T3, M, N>(Func<T1, T2, T3, Task<Tuple<M, N>>> f, T3 t3);
        public IFlowerStep<M, N> ThenAsync<T3, M, N>(Func<T1, T2, T3, Task<(M, N)>> f, T3 t3);
        public IFlowerStep<M, N> ThenAsync<T3, T4, M, N>(Func<T1, T2, T3, T4, Task<Tuple<M, N>>> f, T3 t3, T4 t4);
        public IFlowerStep<M, N> ThenAsync<T3, T4, M, N>(Func<T1, T2, T3, T4, Task<(M, N)>> f, T3 t3, T4 t4);
        public IFlowerStep<M, N> ThenAsync<T3, T4, T5, M, N>(Func<T1, T2, T3, T4, T5, Task<Tuple<M, N>>> f, T3 t3, T4 t4, T5 t5);
        public IFlowerStep<M, N> ThenAsync<T3, T4, T5, M, N>(Func<T1, T2, T3, T4, T5, Task<(M, N)>> f, T3 t3, T4 t4, T5 t5);
        public IFlowerStep<M, N> ThenAsync<T3, T4, T5, T6, M, N>(Func<T1, T2, T3, T4, T5, T6, Task<Tuple<M, N>>> f, T3 t3, T4 t4, T5 t5, T6 t6);
        public IFlowerStep<M, N> ThenAsync<T3, T4, T5, T6, M, N>(Func<T1, T2, T3, T4, T5, T6, Task<(M, N)>> f, T3 t3, T4 t4, T5 t5, T6 t6);
        public IFlowerStep<M, N> ThenAsync<T3, T4, T5, T6, T7, M, N>(Func<T1, T2, T3, T4, T5, T6, T7, Task<Tuple<M, N>>> f, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7);
        public IFlowerStep<M, N> ThenAsync<T3, T4, T5, T6, T7, M, N>(Func<T1, T2, T3, T4, T5, T6, T7, Task<(M, N)>> f, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7);
        public IFlowerStep<M, N> ThenAsync<T3, T4, T5, T6, T7, T8, M, N>(Func<T1, T2, T3, T4, T5, T6, T7, T8, Task<Tuple<M, N>>> f, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8);
        public IFlowerStep<M, N> ThenAsync<T3, T4, T5, T6, T7, T8, M, N>(Func<T1, T2, T3, T4, T5, T6, T7, T8, Task<(M, N)>> f, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8);
        public IFlowerStep<M, N> ThenAsync<T3, T4, T5, T6, T7, T8, T9, M, N>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Task<Tuple<M, N>>> f, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9);
        public IFlowerStep<M, N> ThenAsync<T3, T4, T5, T6, T7, T8, T9, M, N>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Task<(M, N)>> f, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9);
        public IFlowerStep<M, N> ThenAsync<T3, T4, T5, T6, T7, T8, T9, T10, M, N>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Task<Tuple<M, N>>> f, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10);
        public IFlowerStep<M, N> ThenAsync<T3, T4, T5, T6, T7, T8, T9, T10, M, N>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Task<(M, N)>> f, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10);
        public IFlowerStep<M, N> ThenAsync<T3, T4, T5, T6, T7, T8, T9, T10, T11, M, N>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Task<Tuple<M, N>>> f, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11);
        public IFlowerStep<M, N> ThenAsync<T3, T4, T5, T6, T7, T8, T9, T10, T11, M, N>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Task<(M, N)>> f, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11);
        public IFlowerStep<M, N> ThenAsync<T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, M, N>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Task<Tuple<M, N>>> f, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12);
        public IFlowerStep<M, N> ThenAsync<T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, M, N>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Task<(M, N)>> f, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9, T10 t10, T11 t11, T12 t12);


        public IFlowerEnd<T1, T2> OnThrow(Func<string, (Delegate @delegate, object faultyStatus), Exception, Tuple<T1, T2>> def);
        public IFlowerEnd<T1, T2> OnThrow(Func<(Delegate @delegate, object faultyStatus), Exception, Tuple<T1, T2>> def);
        public IFlowerEnd<T1, T2> OnThrow(Func<Exception, Tuple<T1, T2>> def);
        public IFlowerEnd<T1, T2> OnThrow(Func<Tuple<T1, T2>> def);
        public IFlowerEnd<T1, T2> OnThrow(Func<string, (Delegate @delegate, object faultyStatus), Exception, (T1, T2)> def);
        public IFlowerEnd<T1, T2> OnThrow(Func<(Delegate @delegate, object faultyStatus), Exception, (T1, T2)> def);
        public IFlowerEnd<T1, T2> OnThrow(Func<Exception, (T1, T2)> def);
        public IFlowerEnd<T1, T2> OnThrow(Func<(T1, T2)> def);


        public IFlowerStep<T1, T2> Guard(Action<T1, T2> defaultExpression, params (Func<T1, T2, bool> evalExpression, Action<T1, T2> expressionIfEvalIsTrue)[] guards);
        public IFlowerStep<M, N> Guard<M, N>(Func<T1, T2, Tuple<M, N>> defaultExpression, params (Func<bool> evalExpression, Func<T1, T2, Tuple<M, N>> expressionIfEvalIsTrue)[] guards);
        public IFlowerStep<M, N> Guard<M, N>(Func<T1, T2, Tuple<M, N>> defaultExpression, params (Func<T1, T2, bool> evalExpression, Func<T1, T2, Tuple<M, N>> expressionIfEvalIsTrue)[] guards);
        public IFlowerStep<M, N> Guard<M, N>(Func<T1, T2, (M, N)> defaultExpression, params (Func<bool> evalExpression, Func<T1, T2, (M, N)> expressionIfEvalIsTrue)[] guards);
        public IFlowerStep<M, N> Guard<M, N>(Func<T1, T2, (M, N)> defaultExpression, params (Func<T1, T2, bool> evalExpression, Func<T1, T2, (M, N)> expressionIfEvalIsTrue)[] guards);


        public IFlowerStep<T1, T2> While(Func<T1, T2, bool> evalExpression, params Action<T1, T2>[] doStuffIfExpressionIsTrue);
        public IFlowerStep<T1, T2> While(Func<T1, T2, bool> evalExpression, params Func<T1, T2, Tuple<T1, T2>>[] doStuffIfExpressionIsTrue);
        public IFlowerStep<T1, T2> While(Func<T1, T2, bool> evalExpression, params Func<T1, T2, (T1, T2)>[] doStuffIfExpressionIsTrue);
        public (T1, T2) Expect(string message);
    }
}
