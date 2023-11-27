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

        public void Delete(int Id)
        {
            var result = _applicationDbContext.ApplyLeaves.FirstOrDefault(l => l.Id == Id);
            if (result != null)
            {
                _applicationDbContext.ApplyLeaves.Remove(result);
                _applicationDbContext.SaveChanges();
            }
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

            // Assuming "Id" is the primary key property of ApplyLeave
            var existingEntity = entities.Find(entity.Id);

            if (existingEntity != null)
            {
                // Update the properties of the existing entity with the new values
                _applicationDbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
                _applicationDbContext.SaveChanges();
            }
        }

    }
}
