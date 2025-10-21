namespace RentCarApp.Interfaces
{
    // التجريد: واجهة للإيجار 
    public interface IRentable
    {
        bool Rent(string customerName);
        bool Return();
        bool IsAvailable { get; }
    }
}
