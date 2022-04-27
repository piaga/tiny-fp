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
        public void Test_B_Begin_OnThrow()
        {
            FlowerFactory
                .Create((3,string.Empty))
                .OnThrow(e => (-1,"-1"))
                .Expect(Message)
                .Should()
                .Be((3,string.Empty));
        }

        [Test]
        public void Test_B_Begin_Then_OnThrow()
        {
            FlowerFactory
                .Create((3, string.Empty))
                .Then((left, right) => new Tuple<int, string>(left, left.ToString()))
                .OnThrow(e => (-1, string.Empty))
                .Expect(Message)
                .Item2
                .Should()
                .Be("3");
        }

        [Test]
        public void Test_B_Begin_Then_2Params_OnThrow()
        {
            FlowerFactory
                .Create((0, 1))
                .Then(GetBSum)
                .Then((a, b) => new Tuple<int,string>(a, b.ToString()))
                .OnThrow(e => (-1, e.ToString()))
                .Expect(Message)
                .Item2
                .Should()
                .Be("1");
        }

        [Test]
        public void Test_B_Begin_Then_Map_Error_OnThrow()
        {
            FlowerFactory
                .Create((0,1))
                .Then(GetBSum)
                .Then((l, r) => (l.ToString(), r.ToString()))
                .Then((l ,r) => GetNotImplementedException(l))
                .OnThrow(e => (e.ToString(), string.Empty))
                .Expect(Message)
                .Item1
                .Should()
                .Contain(errorMessage);
        }

        [Test]
        public void Test_B_Begin_Map_Error_OnThrow_MultiParameters()
        {
            FlowerFactory
                .Create((0, string.Empty))
                .Then((value, stringValue) => (GetIncremental(value), GetIncremental(value).ToString()))
                .Then((value, stringValue) => (stringValue, value))
                .OnThrow(e => (string.Empty, int.MinValue))
                .Expect(Message)
                .Item1
                .Should()
                .Be("1");
        }

        [Test]
        public void Test_B_Begin_SingleAction_Assignment()
        {
            FlowerFactory
                .Create(SometingToAssignB(string.Empty, new SomethingToAssign()))
                .Then((left, right) => { 
                    right.integer = int.MaxValue;
                    right.literal = "Y";
                })
                .Then(
                    (left, right) => Console.WriteLine($"Assigned integer: {right.integer}"),
                    (left, right) => Console.WriteLine($"Assigned big integer: {right.big_integer}"),
                    (left, right) => Console.WriteLine($"Assigned literal: {right.literal}")
                )
                .Then(
                    (left, right) => right.integer.Should().Be(int.MaxValue),
                    (left, right) => right.big_integer.Should().Be(0),
                    (left, right) => right.literal.Should().Be("Y")
                )
            .Expect("SomethingToAssign object expected")
            .Item2
            .Should()
            .Match<SomethingToAssign>(_ => _.integer == int.MaxValue);
        }

        [Test]
        public void Test_B_Begin_MultipleAction_FakeLogging_Assignment()
        {
            FlowerFactory
                .Create(SometingToAssignB(string.Empty, new SomethingToAssign()
                {
                    integer = int.MaxValue,
                    big_integer = long.MaxValue,
                    literal = "Y"
                }))
                .Then(
                    () => Console.WriteLine("Assigned integer"),
                    () => Console.WriteLine("Assigned big integer"),
                    () => Console.WriteLine("Assigned literal")
                )
                .Then(
                    (left, right) => right.integer.Should().Be(int.MaxValue),
                    (left, right) => right.big_integer.Should().Be(long.MaxValue),
                    (left, right) => right.literal.Should().Be("Y")
                )
            .Expect("SomethingToAssign object expected")
            .Item2
            .Should()
            .Match<SomethingToAssign>(_ => _.integer == int.MaxValue);
        }

        [Test]
        public void Test_B_Begin_MultipleAction_Assignments_NativeObject()
        {
            FlowerFactory
                .Create(SometingToAssignB(0,int.MinValue))
                .Then(
                    (l, r) => (l+1, l/5),
                    (l, r) => (l+1, l/5),
                    (l, r) => (l+1, l/5),
                    (l, r) => (l+1, l/5),
                    (l, r) => (l+1, l/5),
                    (l, r) => (l+1, l/5)
                )
                .Then(
                    (l, r) => r.Should().Be(1)
                )
            .Expect("Integer object expected");
        }

        [Test]
        public void Test_B_Begin_MultipleAction_Assignments_ComplexObject()
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
        public void Test_B_Begin_AsyncThen()
        {
            FlowerFactory
                .Create((1,0))
                .ThenAsync((l, r) => SumNWithDelay(l, 500, 4))
                .ThenAsync((l, r) => Task.FromResult((l, r/5)))
                .Expect("Expecting some integer")
                .Item2
                .Should()
                .Be(1);
        }

        [Test]
        public void Test_B_Begin_Assign_FailExpectation()
        {
            Try(() => FlowerFactory
                .Create((0,new SomethingToAssign()))
                .Then(
                    (l, r) => r.integer = 5,
                    (l, r) => r.big_integer = 5L,
                    (l, r) => r.literal = "Assign something written",
                    (l, r) => throw new ApplicationException("Why i'm still assigning!?")
                )
                .Expect("The expectation is not worthed"))
            .Match(_ => _.Tee(sta => Assert.Fail("Assigned object not expected", _)),
                ex => (0, new SomethingToAssign { literal = ex.ToString() }))
            .Item2
            .literal
            .Should()
            .Contain("The expectation is not worthed");
        }

        [Test]
        public void Test_B_Begin_Assign_ManagingException_FailExpectation()
        {
            FlowerFactory
                .Create((0, new SomethingToAssign()))
                .Then(
                    (l, r) => r.integer = 5,
                    (l, r) => r.big_integer = 5L,
                    (l, r) => r.literal = "Assign something written",
                    (l, r) => throw new ApplicationException("Why i'm still assigning!?"))
                .OnThrow(() => (0, new SomethingToAssign() { integer = -1, big_integer = -1L, literal = string.Empty }))
                .Expect("You're not getting the expected one")
                .Item2
                .literal
                .Should()
                .BeEmpty();

            FlowerFactory
                .Create((0,new SomethingToAssign()))
                .Then(
                    (l, r) => r.integer = 5,
                    (l, r) => r.big_integer = 5L,
                    (l, r) => r.literal = "Assign something written",
                    (l, r) => throw new ApplicationException("Why i'm still assigning!?"))
                .OnThrow(ex => (0, new SomethingToAssign() { integer = -1, big_integer = -1L, literal = ex.ToString() }))
                .Expect("You're not getting the expected one")
                .Item2
                .literal
                .Should()
                .NotContain("You're not getting the expected one")
                .And
                .NotBeEmpty();

            FlowerFactory
                .Create((0, new SomethingToAssign()))
                .Then(
                    (l, r) => r.integer = 5,
                    (l, r) => r.big_integer = 5L,
                    (l, r) => r.literal = "Assign something written",
                    (l, r) => throw new ApplicationException("Why i'm still assigning!?"))
                .OnThrow((customString, faultyStep, ex) => (0, new SomethingToAssign() { integer = -1, big_integer = -1L, literal = customString + ex.ToString() }))
                .Expect("You're not getting the expected one")
                .Item2
                .literal
                .Should()
                .Contain("You're not getting the expected one")
                .And
                .NotBeEmpty();
        }

        [Test]
        public void Test_B_Begin_Guard_ActionWithParams()
        {
            FlowerFactory
                .Create((0, new SomethingToAssign() { integer = 5 }))
                .Guard((l, r) => { r.integer++; },
                ((l, r) => r.integer % 2 == 0, (l, r) => r.integer /= 2))
                .Expect("Error while managing somethingToAssign")
                .Tee(_ => _.Item2.integer.Should().Be(6))
                .ToFlower()
                .Guard((l, r) => { r.integer++; },
                    ((l, r) => r.integer % 2 == 0, (l, r) => r.integer /= 2))
                .Expect("Error while managing somethingToAssign")
                .Item2
                .integer
                .Should()
                .Be(3);
        }

        [Test]
        public void Test_B_Begin_Guard_ParameterlessFunc()
        {
            var somethingFromExternal = 50;

            FlowerFactory.Create((0,0))
                .Guard((l, r) => (0, new SomethingToAssign() { integer = somethingFromExternal }),
                    (
                        (l, r) => somethingFromExternal >= 100,
                        (l, r) => (0, new SomethingToAssign() { integer = 100 + new Random().Next() % 100 })
                    )
                )
                .Expect("New somethingToAssign expected")
                .Tee(_ => _.Item2.integer.Should().Be(50))
                .Tee(_ => somethingFromExternal += _.Item2.integer)
                .ToFlower()
                .Guard((l, r) => (0, new SomethingToAssign() { integer = somethingFromExternal }),
                    (
                        () => somethingFromExternal >= 100,
                        (l, r) => (0, new SomethingToAssign() { integer = 100 + 1 + new Random().Next() % 100 })
                    )
                )
                .Expect("New somethingToAssign expected")
                .Tee(_ => _.Item2.integer.Should().BeGreaterOrEqualTo(100))
                .ToFlower()
                .Guard((l, r) => (l, r).Tee(inner=>inner.r.integer/=inner.r.integer),
                    (
                        (l, r) => r.integer < 100,
                        (l, r) => (0, new SomethingToAssign() { integer = 100 })
                    )
                )
                .Expect("New somethingToAssign expected")
                .Item2
                .integer
                .Should()
                .Be(1);
        }

        [Test]
        public void Test_B_Begin_GuardMap_ParameteredFunc()
        {
            FlowerFactory.Create((0, new SomethingToAssign() { integer = 50 }))
                .Guard((l, r) => (0, r.integer),
                    (
                        (l, r) => r.integer >= 100,
                        (l, r) => (0, 100 + new Random().Next() % 100) 
                    )
                )
                .Expect("New integer expected")
                .Tee(_ => _.Item2.Should().Be(50))
                .ToFlower((l, r) => (0, new SomethingToAssign() { integer = r*2 }))
                .Guard((l, r) => (0,r.integer),
                    (
                        (l, r) => r.integer >= 100,
                        (l, r) => (0,100 + new Random().Next() % 100)
                    )
                )
                .Expect("New integer expected")
                .Item2
                .Should()
                .BeGreaterOrEqualTo(100);
        }

        [Test]
        public void Test_B_Begin_While_Action()
        {
            FlowerFactory.Create((0, new SomethingToAssign()))
                .While(
                    (l, r) => r.integer < Math.Pow(10,6),
                    (l, r) => r.integer = r.integer + 1)
                .Expect("Stacktrace exception can occurs")
                .Item2
                .integer
                .Should()
                .Be(Convert.ToInt32(Math.Pow(10, 6)));
        }

        [Test]
        public void Test_B_Begin_While_Function()
        {
            FlowerFactory.Create((0,0))
                .While(
                    (l, r) => r < Math.Pow(10, 6),
                    (l, r) => (0,r + 1))
                .Expect("Stacktrace exception can occurs")
                .Item2
                .Should()
                .Be(Convert.ToInt32(Math.Pow(10, 6)));
        }

        public (int, int) GetBSumParams(params int[] @params)
            => (0,@params.AsEnumerable().Sum());
        
    }
}
