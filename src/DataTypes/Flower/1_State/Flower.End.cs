namespace TinyFp.DataTypes
{
    public class FlowerEnd<T> : IFlowerEnd<T>
    {
        private FlowerStep<T> _step;
        internal FlowerEnd(FlowerStep<T> step)
        {
            _step = step;

        }

        public T Expect(string message)
        => (T)
        (
            _step.Exception != default && _step.Def != default ?
            (
                _step.Def.Method.GetParameters().Length switch
                {
                    1 => _step.Def.DynamicInvoke(_step.Exception),
                    2 => _step.Def.DynamicInvoke(_step.FaultyStep, _step.Exception),
                    3 => _step.Def.DynamicInvoke(message, _step.FaultyStep, _step.Exception),
                    _ => _step.Def.DynamicInvoke()
                }
            ) :
             _step.State
        );
    }
}