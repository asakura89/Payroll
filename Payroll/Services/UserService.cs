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

        public void ChangePassword(String username, String oldPassword, String confirmPassword, String newPassword)
        {
            var securityService = new SecurityService();

            M_USER existing = GetByUsername(username);

            if (oldPassword == String.Empty)
                throw new InvalidOperationException("Old Password must not empty.");
            if (confirmPassword == String.Empty)
                throw new InvalidOperationException("Confirm Old Password must not empty.");
            if (securityService.HashString(oldPassword) != securityService.HashString(confirmPassword))
                throw new InvalidOperationException("Confirm Password is not same as Old Password.");
            if (securityService.HashString(oldPassword) != existing.USERPASS)
                throw new InvalidOperationException("Old Password is incorrect.");
            if (securityService.HashString(oldPassword) == securityService.HashString(newPassword))
                throw new InvalidOperationException("New Password must not same as before.");

            existing.USERPASS = securityService.HashString(newPassword);

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