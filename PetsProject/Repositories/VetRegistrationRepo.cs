using PetsProject.Data;
using PetsProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsProject.Repositories
{
    public class VetRegistrationRepo : IVetRegistraitonRepo
    {
        private readonly AppDbContext _context;

        public VetRegistrationRepo(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<VetRegistracion> GetAllVet(VetRegistracion vetRegistracion)
        {
            return _context.GetVetRegistraiton;
        }

        public VetRegistracion GetVetById(int id)
        {
            return _context.GetVetRegistraiton.FirstOrDefault(e => e.ID == id);
        }

        public VetRegistracion RegisterVet(VetRegistracion vetRegistracion)
        {
             _context.GetVetRegistraiton.Add(vetRegistracion);
            return vetRegistracion;
        }

        public VetRegistracion RemoveVet(VetRegistracion vetRegistracion)
        {
            _context.GetVetRegistraiton.Remove(vetRegistracion);
            return vetRegistracion;
        }

        public bool SaveChange()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
