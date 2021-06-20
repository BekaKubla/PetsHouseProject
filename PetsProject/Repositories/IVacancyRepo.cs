using PetsProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsProject.Repositories
{
    public interface IVacancyRepo
    {
        JobVacancy CreateJob(JobVacancy jobVacancy);
        IEnumerable<JobVacancy> GetAllJob(JobVacancy jobVacancy);
        JobVacancy GetJobById(int id);
        JobVacancy RemoveJob(JobVacancy jobVacancy);
        bool SaveChange();
    }
}
