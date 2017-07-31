namespace Bionet.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private BionetDbContext dbContext;

        public BionetDbContext Init()
        {
            return dbContext ?? (dbContext = new BionetDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}