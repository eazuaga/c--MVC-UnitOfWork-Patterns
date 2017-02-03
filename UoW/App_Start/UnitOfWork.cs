using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UoW.Models;

namespace UoW.App_Start
{
    public class UnitOfWork
    {
        public UnitOfWork()
        {
            this.context = new MyDbContext();
        }
        private readonly MyDbContext context;

        private GenericRepository<User> clientsRepository;
        public GenericRepository<User> ClientsRepository
        {
            get
            {
                if (this.clientsRepository == null)
                {
                    this.clientsRepository = new GenericRepository<User>(this.context);
                }
                return this.clientsRepository;
            }
        }

       

        public async Task SaveChangesAsync()
        {
            await this.context.SaveChangesAsync();
        }
    }
}