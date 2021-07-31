using PetsProject.Data;
using PetsProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsProject.Repositories
{
    public class DamakebaNoDocumentRepo : IDamakebaNoDocumentRepo
    {
        private readonly AppDbContext _context;

        public DamakebaNoDocumentRepo(AppDbContext context)
        {
            _context = context;
        }
        public Damakeba CreateProduct(Damakeba damakebaNoDocument)
        {
             _context.Damakeba.Add(damakebaNoDocument);
            return damakebaNoDocument;
        }

        public IEnumerable<Damakeba> GetAllProduct(Damakeba damakebaNoDocument)
        {
            return _context.Damakeba;
        }

        public Damakeba GetProductById(int id)
        {
            return _context.Damakeba.FirstOrDefault(e => e.ID == id);
        }

        public Damakeba RemoveProduct(Damakeba damakebaNoDocument)
        {
            _context.Damakeba.Remove(damakebaNoDocument);
            return damakebaNoDocument;
        }

        public bool SaveChange()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
