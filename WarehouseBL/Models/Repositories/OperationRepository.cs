using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarehouseBL.Models.DataBase;

namespace WarehouseBL.Models.Repositories
{
    public class OperationRepository : IRepository<Operation>
    {
        CoreDbContext context;
        public OperationRepository(CoreDbContext context)
        {
            this.context = context;
        }
        public void Add(Operation entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            context.SaveChanges();
        }

        public void Delete(Operation entity)
        {
            context.Operations.Remove(entity);
            context.SaveChanges();
        }

        public IEnumerable<Operation> GetAll()
        {
            var operations = (from x in context.Operations select x);
            return operations;
        }

        public IEnumerable<Operation> GetAll(DateTime start, DateTime end)
        {
            return context.Operations.Where(x => x.DateTime > start && x.DateTime < end);
        }


        public Operation GetById(int id)
        {
            return context.Operations.Single(s => s.OperationId == id);
        }
    }
}
