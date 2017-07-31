namespace Bionet.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}