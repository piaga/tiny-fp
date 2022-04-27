using TinyFp.DataTypes;
using TinyFp.Extensions;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;
using static TinyFp.Prelude;

namespace TinyFp.Tests.DataTypes.Flower
{
    public partial class FlowerTests
    {
        [Test]
        public void Test_Begin_OnThrow()
        {
            FlowerFactory
                .Create(GetFixedNumber)
                .OnThrow(e => -1)
                .Expect(Message)
                .Should()
                .Be(5);
        }

        [Test]
        public void Test_Begin_Then_OnThrow()
        {
            FlowerFactory
                .Create(GetFixedNumber)
                .Then(GetIncremental)
                .OnThrow(e => -1)
                .Expect(Message)
                .Should()
                .Be(6);
        }

        [Test]
        public void Test_Begin_Then_Map_OnThrow()
        {
            FlowerFactory
                .Create(GetFixedNumber)
                .Then(GetIncremental)
                .Then(integer => integer.ToString())
                .OnThrow(e => e.ToString())
                .Expect(Message)
                .Should()
                .Be("6");
        }

        [Test]
        public void Test_Begin_Then_Map_Error_OnThrow()
        {
            FlowerFactory
                .Create(GetFixedNumber)
                .Then(GetIncremental)
                .Then(integer => integer.ToString())
                .Then(GetNotImplementedException)
                .OnThrow(e => e.ToString())
                .Expect(Message)
                .Should()
                .Contain(errorMessage);
        }

        [Test]
        public void Test_Begin_Map_Error_OnThrow_MultiParameters()
        {
            FlowerFactory
                .Create(GetFixedNumber)
                .Then(GetIncremental)
                .Then(GetSum, 4)
                .OnThrow(e => int.MinValue)
                .Expect(Message)
                .Should()
                .Be(10);
        }

        [Test]
        public void Test_Begin_OnThrow_Either()
        {
            FlowerFactory
                .Create(() => Either<string, int>.Right(GetFixedNumber()))
                .OnThrow(e => Either<string, int>.Left(e.ToString()))
                .Expect(Message)
                .OnLeft(Assert.Fail)
                .OnRight(inner => inner.Should().Be(GetFixedNumber()));
        }

        [Test]
        public void Test_Begin_Then_OnThrow_Either_Map()
        {
            FlowerFactory
                .Create(() => Either<string, int>.Right(GetFixedNumber()))
                .Then(_ => _.Map(inner => inner.ToString()))
                .OnThrow(e => Either<string, string>.Left(e.ToString()))
                .Expect(Message)
                .OnLeft(Assert.Fail)
                .OnRight(inner => inner.Should().Be(GetFixedNumber().ToString()));
        }

        [Test]
        public void Test_Begin_SingleAction_Assignment()
        {
            FlowerFactory
                .Create(() => new SomethingToAssign()
                {
                    integer = int.MaxValue,
                    big_integer = long.MaxValue,
                    literal = "Y"
                })
                .Then(_ => _.Tee(s => s.big_integer = 0))
                .Then(
                    _ => Console.WriteLine($"Assigned integer: {_.integer}"),
                    _ => Console.WriteLine($"Assigned big integer: {_.big_integer}"),
                    _ => Console.WriteLine($"Assigned literal: {_.literal}")
                )
                .Then(
                    _ => _.integer.Should().Be(int.MaxValue),
                    _ => _.big_integer.Should().Be(0),
                    _ => _.literal.Should().Be("Y")
                )
            .Expect("SomethingToAssign object expected")
            .Should()
            .Match<SomethingToAssign>(_ => _.integer == int.MaxValue);
        }

        [Test]
        public void Test_Begin_MultipleAction_FakeLogging_Assignment()
        {
            FlowerFactory
                .Create(() => new SomethingToAssign()
                {
                    integer = int.MaxValue,
                    big_integer = long.MaxValue,
                    literal = "Y"
                })
                .Then(
                    () => Console.WriteLine("Assigned integer"),
                    () => Console.WriteLine("Assigned big integer"),
                    () => Console.WriteLine("Assigned literal")
                )
                .Then(
                    _ => _.integer.Should().Be(int.MaxValue),
                    _ => _.big_integer.Should().Be(long.MaxValue),
                    _ => _.literal.Should().Be("Y")
                )
            .Expect("SomethingToAssign object expected")
            .Should()
            .Match<SomethingToAssign>(_ => _.integer == int.MaxValue);
        }

        [Test]
        public void Test_Begin_MultipleAction_Assignments_NativeObject()
        {
            FlowerFactory
                .Create(() => 0)
                .Then(
                    _ => ++_,
                    _ => ++_,
                    _ => ++_,
                    _ => ++_,
                    _ => ++_,
                    _ => _ / 5
                )
                .Then(
                    _ => _.Should().Be(1)
                )
            .Expect("Integer object expected");
        }

        [Test]
        public void Test_Begin_MultipleAction_Assignments_ComplexObject()
        {
            FlowerFactory
                .Create(() => new SomethingToAssign()
                {
                    integer = int.MaxValue,
                    big_integer = long.MaxValue,
                    literal = "Y"
                })
                .Then(
                    _ => _.integer = int.MinValue,
                    _ => _.big_integer = long.MinValue,
                    _ => _.literal = "N",
                    _ => _.literal += "N",
                    _ => _.big_integer = 0
                )
                .Then(
                    _ => _.integer.Should().Be(int.MinValue),
                    _ => _.big_integer.Should().Be(0),
                    _ => _.literal.Should().Be("NN")
                )
            .Expect("SomethingToAssign object expected")
            .integer
            .Should()
            .Be(int.MinValue);
        }

        [Test]
        public void Test_Begin_AsyncThen()
        {
            FlowerFactory
                .Create(() => 5)
                .ThenAsync(_ => SumWithDelay(_, 5, 1000))
                .ThenAsync(_ => Task.FromResult(_ / 5))
                .Expect("Expecting some integer")
                .Should()
                .Be(2);
        }

        [Test]
        public void Test_Begin_Assign_FailExpectation()
        {
            Try(() => FlowerFactory
                .Create(() => new SomethingToAssign())
                .Then(
                    _ => _.integer = 5,
                    _ => _.big_integer = 5L,
                    _ => _.literal = "Assign something written",
                    _ => throw new ApplicationException("Why i'm still assigning!?")
                )
                .Expect("The expectation is not worthed"))
            .Match(_ => _.Tee(sta => Assert.Fail("Assigned object not expected", _)),
                ex => new SomethingToAssign() { literal = ex.ToString() })
            .literal
            .Should()
            .Contain("The expectation is not worthed");
        }

        [Test]
        public void Test_Begin_Assign_ManagingException_FailExpectation()
        {
            FlowerFactory
                .Create(() => new SomethingToAssign())
                .Then(
                    _ => _.integer = 5,
                    _ => _.big_integer = 5L,
                    _ => _.literal = "Assign something written",
                    _ => throw new ApplicationException("Why i'm still assigning!?"))
                .OnThrow(() => new SomethingToAssign() { integer = -1, big_integer = -1L, literal = string.Empty })
                .Expect("You're not getting the expected one")
                .literal
                .Should()
                .BeEmpty();

            FlowerFactory
                .Create(() => new SomethingToAssign())
                .Then(
                    _ => _.integer = 5,
                    _ => _.big_integer = 5L,
                    _ => _.literal = "Assign something written",
                    _ => throw new ApplicationException("Why i'm still assigning!?"))
                .OnThrow(ex => new SomethingToAssign() { integer = -1, big_integer = -1L, literal = ex.ToString() })
                .Expect("You're not getting the expected one")
                .literal
                .Should()
                .NotContain("You're not getting the expected one")
                .And
                .NotBeEmpty();

            FlowerFactory
                .Create(() => new SomethingToAssign())
                .Then(
                    _ => _.integer = 5,
                    _ => _.big_integer = 5L,
                    _ => _.literal = "Assign something written",
                    _ => throw new ApplicationException("Why i'm still assigning!?"))
                .OnThrow((customString, faultyStep, ex) => new SomethingToAssign() { integer = -1, big_integer = -1L, literal = customString + ex.ToString() })
                .Expect("You're not getting the expected one")
                .literal
                .Should()
                .Contain("You're not getting the expected one")
                .And
                .NotBeEmpty();
        }

        [Test]
        public void Test_Begin_Guard_ActionWithParams()
        {
            FlowerFactory
                .Create(() => new SomethingToAssign() { integer = 5 })
                .Guard(_ => { _.integer++; },
                (_ => _.integer % 2 == 0, _ => _.integer /= 2))
                .Expect("Error while managing somethingToAssign")
                .Tee(_ => _.integer.Should().Be(6))
                .ToFlower()
                .Guard(_ => { _.integer++; },
                    (_ => _.integer % 2 == 0, _ => _.integer /= 2))
                .Expect("Error while managing somethingToAssign")
                .integer
                .Should()
                .Be(3);
        }

        [Test]
        public void Test_Begin_Guard_ParameterlessFunc()
        {
            var somethingFromExternal = 50;

            FlowerFactory.Create(() => new object())
                .Guard(() => new SomethingToAssign() { integer = somethingFromExternal },
                    (
                        () => somethingFromExternal >= 100,
                        () => new SomethingToAssign() { integer = 100 + new Random().Next() % 100 }
                    )
                )
                .Expect("New somethingToAssign expected")
                .Tee(_ => _.integer.Should().Be(50))
                .Tee(_ => somethingFromExternal += _.integer)
                .ToFlower()
                .Guard(() => new SomethingToAssign() { integer = somethingFromExternal },
                    (
                        () => somethingFromExternal >= 100,
                        () => new SomethingToAssign() { integer = 100 + 1 + new Random().Next() % 100 }
                    )
                )
                .Expect("New somethingToAssign expected")
                .Tee(_ => _.integer.Should().BeGreaterOrEqualTo(100))
                .ToFlower()
                .Guard(_ => _.Tee(inner=>inner.integer/=inner.integer),
                    (
                        _ => _.integer < 100,
                        _ => new SomethingToAssign() { integer = 100 }
                    )
                )
                .Expect("New somethingToAssign expected")
                .integer
                .Should()
                .Be(1);
        }

        [Test]
        public void Test_Begin_GuardMap_ParameteredFunc()
        {
            FlowerFactory.Create(() => new SomethingToAssign() { integer = 50 })
                .Guard(_ => _.integer,
                    (
                        _ => _.integer >= 100,
                        _ => _.integer = 100 + new Random().Next() % 100 
                    )
                )
                .Expect("New integer expected")
                .Tee(_ => _.Should().Be(50))
                .Tee(_ => _ += 50)
                .ToFlower(_ => new SomethingToAssign() { integer = _ })
                .Guard(_ => _.integer,
                    (
                        _ => _.integer >= 100,
                        _ => _.integer = 100 + new Random().Next() % 100
                    )
                )
                .Expect("New integer expected")
                .Should()
                .BeGreaterOrEqualTo(100);
        }

        [Test]
        public void Test_Begin_While_Action()
        {
            FlowerFactory.Create(() => new SomethingToAssign())
                .While(
                    _ => _.integer < Math.Pow(10,6),
                    _ => _.integer = _.integer + 1)
                .Expect("Stacktrace exception can occurs")
                .integer
                .Should()
                .Be(Convert.ToInt32(Math.Pow(10, 6)));
        }

        [Test]
        public void Test_Begin_While_Function()
        {
            FlowerFactory.Create(() => 0)
                .While(
                    _ => _ < Math.Pow(10, 6),
                    _ => _ + 1)
                .Expect("Stacktrace exception can occurs")
                .Should()
                .Be(Convert.ToInt32(Math.Pow(10, 6)));
        }
    }
}
