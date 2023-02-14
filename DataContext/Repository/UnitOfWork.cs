using DataAccessLayer.DataContext;
using InterfaceEntity.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly DataAccessLayerContext _dbContext;
       
        public IAddressRepository address { get; }

        public ITaskPersonRepository taskperson { get; }

        public UnitOfWork(DataAccessLayerContext dbContext,
                            ITaskPersonRepository personRepository , IAddressRepository Address)
        {
            _dbContext = dbContext;
            taskperson = personRepository;
            address = Address;
        }

        public int Save()
        {
            
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
    }
}
