﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private BionetDbContext dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public BionetDbContext DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}