using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Repository;
using Project.Context;

namespace Project.Services
{
    class SideEffectServices : IRepository<SideEffect>
    {
        private ProjectContext _context;

        public SideEffectServices()
        {
            _context = new ProjectContext();
        }
        public void Create(SideEffect item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        public void Delete(SideEffect item)
        {
            _context.Remove(item);
            _context.SaveChanges();
        }

        public List<SideEffect> GetAll()
        {
            return _context.SideEffects.ToList();
        }

        public void Update(SideEffect item)
        {
            _context.Update(item);
            _context.SaveChanges();
        }
    }
}
