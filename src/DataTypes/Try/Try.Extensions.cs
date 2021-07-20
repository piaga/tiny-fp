﻿using System;
using System.Diagnostics.Contracts;
using TinyFp.Common;

namespace TinyFp
{
    public static class TryExtensions
    {
        [Pure]
        private static Result<T> EncapsulateTry<T>(this Try<T> @this)
        {
            try
            {
                return @this();
            }
            catch (Exception e)
            {
                return new Result<T>(e);
            }
        }

        public static Try<A> Memo<A>(this Try<A> @this)
        {
            var isMemoized = false;
            var memoized = new Result<A>();
            return () =>
            {
                if (isMemoized) return memoized;

                var @try = @this.EncapsulateTry();
                if (@try.IsSuccess)
                {
                    isMemoized = true;
                    memoized = @try;
                }

                return @try;
            };
        }

        [Pure]
        public static R Match<A, R>(this Try<A> @this, Func<A, R> Succ, Func<Exception, R> Fail)
        {
            var res = @this.EncapsulateTry();
            return res.IsSuccess ?
                Succ(res.Value) :
                Fail(res.Exception);
        }

        [Pure]
        public static R Match<A, R>(this Try<A> @this, Func<A, R> Succ, R Fail)
        {
            var res = @this.EncapsulateTry();
            return res.IsFaulted ?
                Fail :
                Succ(res.Value);
        }

        [Pure]
        public static A OnFail<A>(this Try<A> @this, A failValue)
            => OnFail(@this, () => failValue);

        [Pure]
        public static A OnFail<A>(this Try<A> @this, Func<A> Fail)
            => OnFail(@this, _ => Fail());

        [Pure]
        public static A OnFail<A>(this Try<A> @this, Func<Exception, A> Fail)
        {
            var res = @this.EncapsulateTry();
            return res.IsSuccess ?
                res.Value :
                Fail(res.Exception);
        }

        [Pure]
        public static Either<Exception, A> ToEither<A>(this Try<A> @this)
        {
            var res = @this.EncapsulateTry();
            return res.IsFaulted ?
                Either<Exception, A>.Left(res.Exception) :
                Either<Exception, A>.Right(res.Value);
        }

        [Pure]
        public static Try<B> Bind<A, B>(this Try<A> @this, Func<A, Try<B>> f)
            => Memo(() =>
                {
                    try
                    {
                        var ra = @this.EncapsulateTry();
                        return ra.IsSuccess ?
                            f(ra.Value)() :
                            new Result<B>(ra.Exception);
                    }
                    catch (Exception e)
                    {
                        return new Result<B>(e);
                    }
                });

        [Pure]
        public static Try<B> Map<A, B>(this Try<A> @this, Func<A, B> f)
            => Memo(() =>
                {
                    try
                    {
                        var ra = @this.EncapsulateTry();
                        return ra.IsSuccess ?
                            f(ra.Value) :
                            new Result<B>(ra.Exception);
                    }
                    catch (Exception e)
                    {
                        return new Result<B>(e);
                    }
                });

        public static Try<A> Do<A>(this Try<A> @this, Action<A> f) => () =>
        {
            var r = @this.EncapsulateTry();
            if (!r.IsFaulted)
            {
                f(r.Value);
            }
            return r;
        };
    }
}