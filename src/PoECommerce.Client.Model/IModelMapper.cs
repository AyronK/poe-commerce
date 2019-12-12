namespace PoECommerce.Core
{
    public interface IModelMapper<in TIn, out TOut>
    {
        TOut Map(TIn mapOperand);
    }
}
