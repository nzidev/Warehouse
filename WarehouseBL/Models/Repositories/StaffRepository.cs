using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarehouseBL.Models.DataBase;

namespace WarehouseBL.Models.Repositories
{
    public class StaffRepository : IRepository<Staff>
    {
        CoreDbContext context;

        public StaffRepository (CoreDbContext context)
        {
            this.context = context;
        }

        public void Add(Staff entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            context.SaveChanges();
        }
        public void Delete(Staff entity)
        {
            context.Staffs.Remove(entity);
            context.SaveChanges();
        }
        public IEnumerable<Staff> GetAll()
        {
            return context.Staffs;
        }

        public Staff GetById(int id)
        {
            return context.Staffs.Single(s => s.StaffId == id);
        }

        

        
    }
}
