using OnlineStore.EFCore.Domain;
using OnlineStore.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.EFCore.Infra
{
    public class PersonRepository:RepositoryBase<Person>,IPersonRepository
    {
        public PersonRepository(OnlineStoreDbContext context):base(context)
        {

        }

        //public PaginationResult<Person> GetPersonWithPagination(int page, int itemsPerPage, string filter)
        //{
        //    PaginationResult<Person> result = new PaginationResult<Person>();
        //    PaginationResult<Person> result2 = new PaginationResult<Person>();

        //    if (string.IsNullOrEmpty(filter))
        //    {
        //        result.Results = context.Set<Person>().OrderBy(x => x.LastName)
        //     .Skip(page).Take(itemsPerPage).ToList();
        //        if (result.Results.Count > 0)
        //        {
        //            result.TotalRecords = context.Set<Person>().Count();
        //        }
        //    }
        //    else
        //    {
        //        result.Results = context.Set<Person>().Where(x => x.FirstName.ToLower().Contains(filter.ToLower()))
        //            .OrderBy(x => x.FirstName)
        //            .Skip(page).Take(itemsPerPage).ToList();

        //        result2.Results = context.Set<Person>().Where(x => x.LastName.ToLower().Contains(filter.ToLower()))
        //            .OrderBy(x => x.LastName)
        //            .Skip(page).Take(itemsPerPage).ToList();

        //        result.Results.AddRange(result2.Results);

        //        if (result.Results.Count > 0)
        //        {
        //            result.TotalRecords = context.Set<Person>().Where(x => x.FirstName.ToLower().Contains(filter.ToLower())).Count();
        //            result.TotalRecords += context.Set<Person>().Where(x => x.LastName.ToLower().Contains(filter.ToLower())).Count();
        //        }
        //    }

        //    return result;
        //}

        public PaginationResult<Person> GetPersonWithPagination(int page, int itemsPerPage, string filter)
        {
            PaginationResult<Person> result = new PaginationResult<Person>();

            if (string.IsNullOrEmpty(filter))
            {
                result.Results = context.Set<Person>().OrderBy(x => x.LastName)
             .Skip(page).Take(itemsPerPage).ToList();
                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Person>().Count();
                }
            }
            else
            {
                result.Results = context.Set<Person>().Where(x => x.FirstName.ToLower().Contains(filter.ToLower()) ||
                        x.LastName.ToLower().Contains(filter.ToLower())) 
                    .OrderBy(x => x.FirstName)
                    .Skip(page).Take(itemsPerPage).ToList();


                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Person>().Where(x => x.FirstName.ToLower().Contains(filter.ToLower()) ||
                        x.LastName.ToLower().Contains(filter.ToLower())).Count();
                }
            }

            return result;
        }

 
    }
}
