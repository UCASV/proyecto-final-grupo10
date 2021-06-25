using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Repository;
using Project.Context;

namespace Project.Services
{
    class InstitutionServices : IRepository<EssentialInstitution>
    {
        private ProjectContext _context;
        public InstitutionServices()
        {
            _context = new ProjectContext();
        }
        public void Create(EssentialInstitution item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        public void Delete(EssentialInstitution item)
        {
            _context.Remove(item);
            _context.SaveChanges();
        }

        public List<EssentialInstitution> GetAll()
        {
            return _context.EssentialInstitutions.ToList();
        }

        public void Update(EssentialInstitution item)
        {
            _context.Update(item);
            _context.SaveChanges();
        }
    }
}
