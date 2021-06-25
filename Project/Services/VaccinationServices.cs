using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Repository;
using Project.Context;

namespace Project.Services
{
    class VaccinationServices : IRepository<Vaccination>
    {
        private ProjectContext _context;

        public VaccinationServices()
        {
            _context = new ProjectContext();
        }
        public void Create(Vaccination item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        public void Delete(Vaccination item)
        {
            _context.Remove(item);
            _context.SaveChanges();
        }

        public List<Vaccination> GetAll()
        {
            return _context.Vaccinations.ToList();
        }

        public void Update(Vaccination item)
        {
            _context.Update(item);
            _context.SaveChanges();
        }
    }
}
