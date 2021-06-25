using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Repository;
using Project.Context;

namespace Project.Services
{
    public class CitizenServices : IRepository<Citizen>
    {
        private ProjectContext _context;

        public CitizenServices()
        {
            _context = new ProjectContext();
        }
        public void Create(Citizen item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        public void Delete(Citizen item)
        {
            _context.Remove(item);
            _context.SaveChanges();
        }

        public List<Citizen> GetAll()
        {
            return _context.Citizens.ToList();
        }

        public void Update(Citizen item)
        {
            _context.Update(item);
            _context.SaveChanges();
        }
    }
}
