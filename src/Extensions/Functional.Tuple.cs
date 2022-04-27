using System;
using System.Collections.Generic;
using System.Text;

namespace TinyFp.Extensions
{
    public static class TupleExtensions
    {
        public static object[] ToArray<T1, T2>(this Tuple<T1, T2> @this)
            => @this.Map(_ => new object[] { _.Item1, _.Item2 });
        public static object[] ToArray<T1, T2>(this (T1, T2) @this)
            => @this.Map(_ => new object[] { _.Item1, _.Item2 });
        public static object[] ToArray<T1, T2, T3>(this Tuple<T1, T2, T3> @this)
            => @this.Map(_ => new object[] { _.Item1, _.Item2, _.Item3 });
        public static object[] ToArray<T1, T2, T3>(this (T1, T2, T3) @this)
            => @this.Map(_ => new object[] { _.Item1, _.Item2, _.Item3 });
        public static object[] ToArray<T1, T2, T3, T4>(this Tuple<T1, T2, T3, T4> @this)
            => @this.Map(_ => new object[] { _.Item1, _.Item2, _.Item3 });
        public static object[] ToArray<T1, T2, T3, T4>(this (T1, T2, T3, T4) @this)
            => @this.Map(_ => new object[] { _.Item1, _.Item2, _.Item3 });
        public static object[] ToArray<T1, T2, T3, T4, T5>(this Tuple<T1, T2, T3, T4, T5> @this)
            => @this.Map(_ => new object[] { _.Item1, _.Item2, _.Item3 });
        public static object[] ToArray<T1, T2, T3, T4, T5>(this (T1, T2, T3, T4, T5) @this)
            => @this.Map(_ => new object[] { _.Item1, _.Item2, _.Item3 });
        public static object[] ToArray<T1, T2, T3, T4, T5, T6>(this Tuple<T1, T2, T3, T4, T5, T6> @this)
            => @this.Map(_ => new object[] { _.Item1, _.Item2, _.Item3 });
        public static object[] ToArray<T1, T2, T3, T4, T5, T6>(this (T1, T2, T3, T4, T5, T6) @this)
            => @this.Map(_ => new object[] { _.Item1, _.Item2, _.Item3 });
        public static object[] ToArray<T1, T2, T3, T4, T5, T6, T7>(this Tuple<T1, T2, T3, T4, T5, T6, T7> @this)
            => @this.Map(_ => new object[] { _.Item1, _.Item2, _.Item3 });
        public static object[] ToArray<T1, T2, T3, T4, T5, T6, T7>(this (T1, T2, T3, T4, T5, T6, T7) @this)
            => @this.Map(_ => new object[] { _.Item1, _.Item2, _.Item3 });
        public static object[] ToArray<T1, T2, T3, T4, T5, T6, T7, T8>(this Tuple<T1, T2, T3, T4, T5, T6, T7, T8> @this)
            => @this.Map(_ => new object[] { _.Item1, _.Item2, _.Item3 });
        public static object[] ToArray<T1, T2, T3, T4, T5, T6, T7, T8>(this (T1, T2, T3, T4, T5, T6, T7, T8) @this)
            => @this.Map(_ => new object[] { _.Item1, _.Item2, _.Item3 });
        public static object[] ToArray<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this (T1, T2, T3, T4, T5, T6, T7, T8, T9) @this)
            => @this.Map(_ => new object[] { _.Item1, _.Item2, _.Item3 });
        public static object[] ToArray<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this (T1, T2, T3, T4, T5, T6, T7, T8, T9, T10) @this)
            => @this.Map(_ => new object[] { _.Item1, _.Item2, _.Item3 });
        public static object[] ToArray<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this (T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11) @this)
            => @this.Map(_ => new object[] { _.Item1, _.Item2, _.Item3 });
        public static object[] ToArray<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this (T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12) @this)
            => @this.Map(_ => new object[] { _.Item1, _.Item2, _.Item3 });
    }
}
