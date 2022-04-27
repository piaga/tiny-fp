using TinyFp.Extensions;
using System;


namespace TinyFp.DataTypes
{
    public partial class FlowerStep<T1, T2> : FlowerStep<T1>
    {
        internal protected object _state2;
        object IFlowerStep<T1, T2>.State => ((T1)_state1,(T2) _state2);
        internal override object State => ((T1)_state1,(T2) _state2);

        public FlowerStep() : base()
        {
            _state2 = default;
        }

        internal protected FlowerStep(FlowerState faultyFlowerState): base(faultyFlowerState)
        {
            _state2 = default;
        }

        internal protected FlowerStep(Exception ex, (Delegate @delegate, object faultyState) faultyStep): base(ex, faultyStep)
        {
            _state2 = default;
        }

        protected internal override FlowerState SetState(params object[] states)
        => this.Tee(_ => 
        {
            _._state1 = states[0];
            _._state2 = states[1];
        });
    }
    
}