using TinyFp.Extensions;
using System;

namespace TinyFp.DataTypes
{
    public class FlowerEnd<T1, T2> : IFlowerEnd<T1, T2>
    {
        private FlowerStep<T1, T2> _step;
        internal FlowerEnd(FlowerStep<T1, T2> step)
        {
            _step = step;
        }

        public (T1, T2) Expect(string message)
        =>  
        (
            _step.Exception != default && _step.Def != default ?
                ExecuteDef(message) :
                _step.State
        ).Map(result => 
            result.GetType().IsEquivalentTo(typeof(Tuple<T1,T2>)) ? 
            (((Tuple<T1, T2>)result).Item1, ((Tuple<T1, T2>)result).Item2) : 
            (((T1, T2)) result));


        private object ExecuteDef(string message)
            => _step.Def.Method.GetParameters().Length switch
            {
                1 => _step.Def.DynamicInvoke(_step.Exception),
                2 => _step.Def.DynamicInvoke(_step.FaultyStep, _step.Exception),
                3 => _step.Def.DynamicInvoke(message, _step.FaultyStep, _step.Exception),
                _ => _step.Def.DynamicInvoke()
            };
    }
}