using OnlineStore.EFCore.Domain;
using OnlineStore.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.EFCore.Infra
{
    public class SchoolRepository:RepositoryBase<School>,ISchoolRepository
    {
        public SchoolRepository(OnlineStoreDbContext context):base(context)
        {

        }
    }
}
