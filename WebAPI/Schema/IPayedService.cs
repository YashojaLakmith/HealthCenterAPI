namespace WebAPI.Schema;

public interface IPayedService
{
    string ServiceName { get; }
    decimal ServicePrice { get; }
    string ServiceDescription {  get; }
}
