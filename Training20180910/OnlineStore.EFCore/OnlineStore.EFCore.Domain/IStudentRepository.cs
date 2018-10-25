using OnlineStore.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.EFCore.Domain
{
    public interface IStudentRepository:IRepository<Student>
    {
        Person GetPersonWithForeignKey(Guid id);
    }
}
