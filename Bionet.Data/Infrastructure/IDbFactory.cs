using System;

namespace Bionet.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        BionetDbContext Init();
    }
}