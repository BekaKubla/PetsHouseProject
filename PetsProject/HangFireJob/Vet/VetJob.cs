using PetsProject.Models;
using PetsProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsProject.HangFireJob.Vet
{
    public class VetJob : IVetJob
    {
        private readonly IVetRegistraitonRepo _vetContext;

        public VetJob(IVetRegistraitonRepo vetRegistraitonRepo)
        {
            _vetContext = vetRegistraitonRepo;
        }
        public void VetCurrnetJob()
        {
            VetRegistracion vet = new VetRegistracion();
            var getAllProd = _vetContext.GetAllVet(vet);
            foreach (var item in getAllProd)
            {
                var productEndDateInStirng = item.RegistrationDateTime.AddDays(31).ToString("MM/dd/yyyy");
                if (productEndDateInStirng == DateTime.Now.ToString("MM/dd/yyyy"))
                {
                    _vetContext.RemoveVet(item);
                    //_vetContext.SaveChange();
                    
                }

            }
        }
    }
}
