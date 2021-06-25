using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Repository;
using Project.Context;

namespace Project.Services
{
    class AppointmentServices : IRepository<Appointment>
    {
        private ProjectContext _context;

        public AppointmentServices()
        {
            _context = new ProjectContext();
        }
        public void Create(Appointment item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        public void Delete(Appointment item)
        {
            _context.Remove(item);
            _context.SaveChanges();
        }

        public List<Appointment> GetAll()
        {
            return _context.Appointments.ToList();
        }

        public void Update(Appointment item)
        {
            _context.Update(item);
            _context.SaveChanges();
        }
    }
}
