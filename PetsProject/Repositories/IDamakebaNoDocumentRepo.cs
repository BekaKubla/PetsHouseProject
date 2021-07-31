using PetsProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsProject.Repositories
{
   public interface IDamakebaNoDocumentRepo
    {
        IEnumerable<Damakeba> GetAllProduct(Damakeba damakebaNoDocument);
        Damakeba CreateProduct(Damakeba damakebaNoDocument);
        Damakeba GetProductById(int id);
        Damakeba RemoveProduct(Damakeba damakebaNoDocument);
        bool SaveChange();
    }
}
