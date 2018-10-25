using OnlineStore.EFCore.Domain;
using OnlineStore.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineStore.EFCore.Infra
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(OnlineStoreDbContext context) : base(context)
        {

        }

        public Person GetPersonWithForeignKey(Guid id)
        {
            Person result = new Person();
            result = context.Set<Person>().Where(x => x.PersonID == id).FirstOrDefault();
            return result;
        }
    }
}

