using PetsProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsProject.Repositories
{
    public interface IVetRegistraitonRepo
    {
        VetRegistracion RegisterVet(VetRegistracion vetRegistracion);
        IEnumerable<VetRegistracion> GetAllVet(VetRegistracion vetRegistracion);
        VetRegistracion GetVetById(int id);
        VetRegistracion RemoveVet(VetRegistracion vetRegistracion);
        bool SaveChange();
    }
}
