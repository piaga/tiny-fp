namespace TinyFp.DataTypes
{
    public interface IFlowerEnd<T1, T2>
    {
        public (T1, T2) Expect(string message);
    }
}