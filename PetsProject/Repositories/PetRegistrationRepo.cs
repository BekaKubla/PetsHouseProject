using PetsProject.Data;
using PetsProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsProject.Repositories
{
    public class PetRegistrationRepo : IPetRegistrationRepo
    {
        private readonly AppDbContext _context;

        public PetRegistrationRepo(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<PetRegistration> GetAllPet(PetRegistration petRegistracion)
        {
            return _context.GetPetRegistration;
        }

        public PetRegistration GetPetById(int id)
        {
            return _context.GetPetRegistration.FirstOrDefault(e => e.ID == id);
        }

        public PetRegistration RegisterPet(PetRegistration petRegistracion)
        {
            _context.GetPetRegistration.Add(petRegistracion);
            return petRegistracion;
        }

        public PetRegistration RemovePet(PetRegistration petRegistracion)
        {
            _context.GetPetRegistration.Remove(petRegistracion);
            return petRegistracion;
        }

        public bool SaveChange()
        {
            return (_context.SaveChanges()>=0);
        }
    }
}
