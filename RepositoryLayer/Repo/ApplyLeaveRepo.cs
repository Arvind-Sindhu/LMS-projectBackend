// ApplyLeaveRepo.cs
using DomainLayer.Data;
using DomainLayer.Model;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryLayer.Repo
{
    public class ApplyLeaveRepo : IApplyLeaveRepo<ApplyLeave>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private DbSet<ApplyLeave> entities;

        public ApplyLeaveRepo(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            entities = _applicationDbContext.Set<ApplyLeave>();
        }

        public void Delete(ApplyLeave entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            _applicationDbContext.SaveChanges();
        }

        public ApplyLeave Get(int Id)
        {
            return entities.SingleOrDefault(c => c.Id == Id);
        }

        public IEnumerable<ApplyLeave> GetAll()
        {
            return entities.AsEnumerable();
        }

        public IEnumerable<string> GetManagerNames()
        {
            return entities.Select(e => e.ManagerName).Distinct().ToList();
        }

        public List<ApplyLeave> GetLeaveStatusForManagedUsers(string managerName)
        {
            return entities.Where(leave => leave.ManagerName == managerName).ToList();
        }

        public void Insert(ApplyLeave entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            _applicationDbContext.SaveChanges();
        }

        public void SaveChanges()
        {
            _applicationDbContext.SaveChanges();
        }

        public void Update(ApplyLeave entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            _applicationDbContext.SaveChanges();
        }
    }
}
