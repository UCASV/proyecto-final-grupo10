using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Repository;
using Project.Context;

namespace Project.Services
{
    public class CitizenxVaccinationServices : IRepository<CitizenxVaccination>
    {
        private ProjectContext _context;

        public CitizenxVaccinationServices()
        {
            _context = new ProjectContext();
        }
        public void Create(CitizenxVaccination item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        public void Delete(CitizenxVaccination item)
        {
            _context.Remove(item);
            _context.SaveChanges();
        }

        public List<CitizenxVaccination> GetAll()
        {
            return _context.CitizenxVaccinations.ToList();
        }

        public void Update(CitizenxVaccination item)
        {
            _context.Update(item);
            _context.SaveChanges();
        }
    }
}