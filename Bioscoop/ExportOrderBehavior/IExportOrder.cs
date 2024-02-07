namespace Bioscoop.ExportOrderBehavior;

public interface IExportOrder
{
    void ExportOrder(Order order, string path);
}