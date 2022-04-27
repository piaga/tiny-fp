using TinyFp.Extensions;
using System;


namespace TinyFp.DataTypes
{
    public partial class FlowerStep<T> : FlowerState
    {
        internal protected object _state1;
        object IFlowerStep<T>.State => _state1;
        internal virtual object State => _state1;

        public FlowerStep() : base()
        {
            _state1 = default;
        }

        internal protected FlowerStep(FlowerState faultyFlowerState): base(faultyFlowerState)
        {
            _state1 = default;
        }

        internal protected FlowerStep(Exception ex, (Delegate @delegate, object faultyState) faultyStep): base(ex, faultyStep)
        {
            _state1 = default;
        }

        protected internal override FlowerState SetState(params object[] states)
            => this.Tee(_ => { _._state1 = states[0]; });
    }
    
}