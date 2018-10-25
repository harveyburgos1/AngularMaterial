using Day3Database.Models;
using Day3Database.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Day3Database
{
    class Program
    {
        static void Main(string[] args)
        {
            var roy = CreateApplicant("Roy", "Eamiguel", "Saberon", DateTime.Parse("1974-03-26"));
            CreateApplicant("Linus", "Eamiguel", "Saberon", DateTime.Parse("1974-03-26"));
            CreateApplicant("David", "Eamiguel", "Saberon", DateTime.Parse("1974-03-26"));
            CreateApplicant("Danielle", "Eamiguel", "Saberon", DateTime.Parse("1974-03-26"));


            var applicant = RetrieveApplicant(roy.ApplicantId);

            UpdateApplicant(applicant);

            var allApplicants = RetrieveAllApplicants();

            allApplicants.ForEach((a) => DeleteApplicant(a.ApplicantId));

            Console.ReadLine();
        }

        private static List<Applicant> RetrieveAllApplicants()
        {
            var repository = new ApplicantRepository();
            return repository.Retrieve();
        }

        private static Applicant RetrieveApplicant(Guid applicantId)
        {
            var repository = new ApplicantRepository();
            return repository.Retrieve(applicantId);
        }

        private static void UpdateApplicant(Applicant applicant)
        {
            applicant.FirstName = "Roy Jr.";
            var repository = new ApplicantRepository();
            repository.Update(applicant);

        }

        private static void DeleteApplicant(Guid applicantId)
        {
            var repository = new ApplicantRepository();
            repository.Delete(applicantId);
        }

        static Applicant CreateApplicant(string firstName, string lastName,
            string middleName, DateTime birthDate)
        {
            var applicant = new Applicant
            {
                ApplicantId = Guid.NewGuid(),
                FirstName = firstName,
                MiddleName = middleName,
                LastName = lastName,
                BirthDate = birthDate
            };

            var repository = new ApplicantRepository();
            var newApplicant = repository.Create(applicant);
            return newApplicant;
        }
    }
}
