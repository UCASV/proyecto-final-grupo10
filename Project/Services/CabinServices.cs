using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Repository;
using Project.Context;

namespace Project.Services
{
    class CabinServices : IRepository<Cabin>
    {
        private ProjectContext _context;

        public CabinServices()
        {
            _context = new ProjectContext();
        }
        public void Create(Cabin item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        public void Delete(Cabin item)
        {
            _context.Remove(item);
            _context.SaveChanges();
        }

        public List<Cabin> GetAll()
        {
            return _context.Cabins.ToList();
        }

        public void Update(Cabin item)
        {
            _context.Update(item);
            _context.SaveChanges();
        }
    }
}
