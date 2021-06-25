using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Context;
using Project.Repository;

namespace Project.Services
{
    class ManagerServices : IRepository<Manager>
    {
        private ProjectContext _context;

        public ManagerServices()
        {
            _context = new ProjectContext();
        }
        public void Create(Manager item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        public void Delete(Manager item)
        {
            _context.Remove(item);
            _context.SaveChanges();
        }

        public List<Manager> GetAll()
        {
            return _context.Managers.ToList();
        }

        public void Update(Manager item)
        {
            _context.Update(item);
            _context.SaveChanges();
        }
    }
}
