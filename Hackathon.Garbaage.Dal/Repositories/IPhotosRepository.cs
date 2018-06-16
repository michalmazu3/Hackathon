namespace Hackathon.Garbage.Dal.Repositories
{
    public interface IPhotosRepository
    {
        string[] GetByOrder(int orderId);
    }
}