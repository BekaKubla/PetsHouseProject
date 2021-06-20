using PetsProject.Data;
using PetsProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsProject.Repositories
{
    public class VacancyRepo : IVacancyRepo
    {
        private readonly AppDbContext _context;

        public VacancyRepo(AppDbContext context)
        {
            _context = context;
        }
        public JobVacancy CreateJob(JobVacancy jobVacancy)
        {
            _context.GetVacancyRegistration.Add(jobVacancy);
            return jobVacancy;
        }

        public IEnumerable<JobVacancy> GetAllJob(JobVacancy jobVacancy)
        {
            return _context.GetVacancyRegistration;
        }

        public JobVacancy GetJobById(int id)
        {
            return _context.GetVacancyRegistration.FirstOrDefault(e => e.Id == id);
        }

        public JobVacancy RemoveJob(JobVacancy jobVacancy)
        {
            _context.GetVacancyRegistration.Remove(jobVacancy);
            return jobVacancy;
        }

        public bool SaveChange()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
