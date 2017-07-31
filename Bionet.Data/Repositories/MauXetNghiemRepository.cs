﻿using Bionet.Data.Infrastructure;
using Bionet.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.Data.Repositories
{
    public interface IMauXetNghiemRepository : IRepository<MauXetNghiem>
    {
    }

    public class MauXetNghiemRepository : RepositoryBase<MauXetNghiem>, IMauXetNghiemRepository
    {
        public MauXetNghiemRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}