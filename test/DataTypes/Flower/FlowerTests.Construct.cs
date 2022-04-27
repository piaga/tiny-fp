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
        [Test]
        public void Construct_Bi2MonoState()
            => FlowerFactory.Create((50, "60"))
                .Construct((l, r) => new SomethingToAssign {integer = l, literal = r})
                .Expect($"I was expecting {nameof(SomethingToAssign)} instance")
                .Should()
                .BeEquivalentTo(new SomethingToAssign { integer = 50, literal = "60"});
    }
}
