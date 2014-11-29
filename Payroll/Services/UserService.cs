using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Payroll.Models;

namespace Payroll.Services
{
    public class UserService : IDisposable
    {
        private PayrollEntities db = new PayrollEntities();

        public List<M_USER> GetAllUsers()
        {
            return db.M_USER.ToList();
        }

        public M_USER GetByUsername(String username)
        {
            M_USER user = db.M_USER.Find(username);

            if (user == null)
                throw new ObjectNotFoundException("User with Username: " + username);

            return user;
        }

        public void CreateNewUser(M_USER user)
        {
            var securityService = new SecurityService();

            user.USERPASS = securityService.HashString(user.USERPASS);
            db.M_USER.Add(user);
            db.SaveChanges();
        }

        public void UpdateExistingUser(M_USER user)
        {
            M_USER existing = GetByUsername(user.USERNAME);
            existing.USER_CATEGORY = user.USER_CATEGORY;

            db.Entry(existing).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void ChangePassword(M_USER user)
        {
            var securityService = new SecurityService();

            M_USER existing = GetByUsername(user.USERNAME);
            existing.USERPASS = securityService.HashString(user.USERPASS);

            db.Entry(existing).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteExistingUser(String username)
        {
            M_USER user = GetByUsername(username);
            db.M_USER.Remove(user);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}