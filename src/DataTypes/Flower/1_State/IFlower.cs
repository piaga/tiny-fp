using System;

namespace TinyFp.DataTypes
{
    public interface IFlower
    {
        IFlowerStep<T> Create<T>(Func<T> f);
        IFlowerStep<T> Create<T>(T item);
    }
}