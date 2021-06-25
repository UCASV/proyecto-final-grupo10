using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Repository;
using Project.Context;

namespace Project.Services
{
    class LoginRegisterServices : IRepository<LoginRegister>
    {
        private ProjectContext _context;

        public LoginRegisterServices()
        {
            _context = new ProjectContext();
        }
        public void Create(LoginRegister item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        public void Delete(LoginRegister item)
        {
            _context.Remove(item);
            _context.SaveChanges();
        }

        public List<LoginRegister> GetAll()
        {
            return _context.LoginRegisters.ToList();
        }

        public void Update(LoginRegister item)
        {
            _context.Update(item);
            _context.SaveChanges();
        }
    }
}
