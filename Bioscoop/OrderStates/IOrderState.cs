namespace Bioscoop.OrderStates;

public interface IOrderState
{
    void Submit();
    void Cancel();
    void Pay();
    void Edit();
    void Complete();
    void Remind();
}