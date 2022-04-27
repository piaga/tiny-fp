using TinyFp.DataTypes;
using TinyFp.Extensions;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static TinyFp.Prelude;

namespace TinyFp.Tests.DataTypes.Flower
{
    public partial class FlowerTests
    {
        int GetFixedNumber() => 5;
        int GetIncremental(int number) => number + 1;

        int GetSum(int a, int b) => a + b;
        (int, int) GetBSum(int a, int b) => GetBSumParams(a, b);

        int GetNSum(params int[] @params)
            => @params.Sum();

        readonly string errorMessage = "Exception for testing purpose";

        void GetNotImplementedException(object any) => throw new NotImplementedException(errorMessage);
        private const string Message = "It should work";
        class SomethingToAssign
        {
            public int integer { get; set; }
            public long big_integer { get; set; }
            public string literal { get; set; }
        }

        (M left, N right) SometingToAssignB<M, N>(M Item1, N Item2)
            => (Item1, Item2);

        async Task<int> SumWithDelay(int a,int b, int delay)
            => await Task.FromResult(a.Tee(_ => Thread.Sleep(delay)).Tee(_ => _ + b));

        async Task<(int, int)> SumNWithDelay(int seed, int delay, params int[] addend)
            => await Task.FromResult((seed, seed.Tee(_ => Thread.Sleep(delay)).Tee(_ => _ + addend.Sum())));
    }
}
