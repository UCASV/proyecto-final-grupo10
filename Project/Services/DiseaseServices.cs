using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Repository;
using Project.Context;

namespace Project.Services
{
    public class DiseaseServices : IRepository<Disease>
    {
        private ProjectContext _context;

        public DiseaseServices()
        {
            _context = new ProjectContext();
        }
        public void Create(Disease item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        public void Delete(Disease item)
        {
            _context.Remove(item);
            _context.SaveChanges();
        }

        public List<Disease> GetAll()
        {
            return _context.Diseases.ToList();
        }

        public void Update(Disease item)
        {
            _context.Update(item);
            _context.SaveChanges();
        }
    }
}