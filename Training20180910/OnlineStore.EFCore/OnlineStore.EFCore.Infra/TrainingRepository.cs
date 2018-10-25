using OnlineStore.EFCore.Domain;
using OnlineStore.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.EFCore.Infra
{
    public class TrainingRepository:RepositoryBase<Training>,ITrainingRepository
    {
        public TrainingRepository(OnlineStoreDbContext context):base(context)
        {

        }
    }
}
