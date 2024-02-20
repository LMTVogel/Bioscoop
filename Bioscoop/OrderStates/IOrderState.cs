namespace Bioscoop.OrderStates;

public interface IOrderState
{
    void Submit(IOrder order);
    void Cancel(IOrder order);
    void Pay(IOrder order);
    void Edit(IOrder order);
    void Complete(IOrder order);
    void Remind(IOrder order);
}