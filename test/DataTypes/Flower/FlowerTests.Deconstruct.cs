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
        public void Deconstruct_Mono2BiState()
            => FlowerFactory.Create(new SomethingToAssign() { integer = 50, literal = "60" })
                .Deconstruct(_ => (_.integer, _.literal))
                .Expect("I was expecting a tuple with 2 states")
                .Should()
                .BeEquivalentTo((50, "60"));
                
            
    }
}
