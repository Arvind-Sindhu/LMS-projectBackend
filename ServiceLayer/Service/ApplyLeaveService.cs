using DomainLayer.Model;
using RepositoryLayer.IRepo;
using ServiceLayer.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service
{
    public class ApplyLeaveService : IApplyLeaveService<ApplyLeave>
    {
        private readonly IApplyLeaveRepo<ApplyLeave> _ApplyLeaveRepo;
        public ApplyLeaveService(IApplyLeaveRepo<ApplyLeave> ApplyLeaveRepo)
        {
            _ApplyLeaveRepo = ApplyLeaveRepo;
        }
        public void Delete(ApplyLeave entity)
        {
            try
            {
                if (entity != null)
                {
                    _ApplyLeaveRepo.Delete(entity);
                    _ApplyLeaveRepo.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ApplyLeave Get(int Id)
        {
            try
            {
                var obj = _ApplyLeaveRepo.Get(Id);
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<ApplyLeave> GetAll()
        {
            try
            {
                var obj = _ApplyLeaveRepo.GetAll();
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Insert(ApplyLeave entity)
        {
            try
            {
                if (entity != null)
                {
                    _ApplyLeaveRepo.Insert(entity);
                    _ApplyLeaveRepo.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
      
        public void Update(ApplyLeave entity)
        {
            try
            {
                if (entity != null)
                {
                    _ApplyLeaveRepo.Update(entity);
                    _ApplyLeaveRepo.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
