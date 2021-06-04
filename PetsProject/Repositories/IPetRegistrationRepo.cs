using PetsProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsProject.Repositories
{
   public interface IPetRegistrationRepo
    {
        PetRegistration RegisterPet(PetRegistration petRegistracion);
        IEnumerable<PetRegistration> GetAllPet(PetRegistration petRegistracion);
        PetRegistration GetPetById(int id);
        PetRegistration RemovePet(PetRegistration petRegistracion);
        bool SaveChange();
    }
}
