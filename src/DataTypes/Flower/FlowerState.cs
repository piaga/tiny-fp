using System;

namespace TinyFp.DataTypes
{
    public abstract class FlowerState
    {
        internal protected Exception _exception;
        internal protected Delegate _def;
        internal protected (Delegate @delegate, object faultyStatus) _faultyStep;

        internal virtual Exception Exception => _exception;
        internal virtual Delegate Def => _def;
        internal virtual (Delegate @delegate, object faultyStatus) FaultyStep => _faultyStep;

        internal FlowerState()
        {
            _exception = default;
            _def = default;
        }

        internal FlowerState(FlowerState faultyFlowerState)
        {
            _exception = faultyFlowerState.Exception;
            _faultyStep = faultyFlowerState._faultyStep;
        }

        internal FlowerState(Exception ex, (Delegate @delegate, object faultyStatus) faultyStep)
        {
            _exception = ex;
            _faultyStep = faultyStep;
        }

        internal protected abstract FlowerState SetState(params object[] states);
    }
}
